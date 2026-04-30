// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Primitives;
using Azure.Generator.Provisioning.Utilities;
using Azure.Provisioning;
using Azure.Provisioning.Authorization;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Roles;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;
using BicepFunction = Azure.Provisioning.Expressions.BicepFunction;
using BicepIdentifierExpression = Azure.Provisioning.Expressions.IdentifierExpression;

namespace Azure.Generator.Provisioning.Providers
{
    /// <summary>
    /// Generates a ProvisionableResource subclass from an InputModelType + ArmResourceMetadata.
    /// Flattens the ARM "properties" bag, includes system properties from the base model chain,
    /// and generates ResourceVersions, FromExisting, and the resource constructor.
    /// </summary>
    internal class ProvisioningResourceProvider : ModelProvider, IProvisioningPropertyInfo
    {
        // System properties that should always be output-only
        private static readonly HashSet<string> OutputOnlyProperties = new(StringComparer.OrdinalIgnoreCase)
        {
            "id", "systemData", "type"
        };

        // System properties that should always be required, even when marked readOnly (path parameters)
        private static readonly HashSet<string> RequiredInputProperties = new(StringComparer.OrdinalIgnoreCase)
        {
            "name"
        };

        // Properties to skip entirely (type is implied by the resource type)
        private static readonly HashSet<string> SkipProperties = new(StringComparer.OrdinalIgnoreCase)
        {
            "type"
        };

        private readonly InputModelType _inputModel;
        private readonly ArmResourceMetadata? _resourceMetadata;
        private readonly string? _defaultApiVersion;
        /// <summary>
        /// All collected properties for the resource, including flattened and inherited ones,
        /// with their resolved isOutput/isRequired/bicepPath metadata.
        /// Used to build the C# Properties, Fields, and DefineProvisionableProperties() method.
        /// </summary>
        private readonly List<ResourcePropertyInfo> _allProperties;
        /// <summary>
        /// Lookup from InputModelProperty to ResourcePropertyInfo for O(1) access in
        /// <see cref="IProvisioningPropertyInfo.GetProvisioningPropertyInfo"/>.
        /// </summary>
        private readonly Dictionary<InputModelProperty, ResourcePropertyInfo> _propertyLookup;
        /// <summary>
        /// Serialized property names that are writable in the create/update request body model.
        /// When the resource model is output-only (e.g., a ProxyResource with a separate create body),
        /// its properties may be marked readOnly even though the create body accepts them as input.
        /// This set is used during <see cref="_allProperties"/> construction to avoid incorrectly
        /// marking such properties as output-only.
        /// </summary>
        private readonly HashSet<string> _createBodyWritableProperties;

        private FieldProvider? _parentField;
        private PropertyProvider? _parentProperty;
        private CSharpType? _parentType;

        /// <summary>
        /// Gets the resource metadata, if this is a base resource type.
        /// </summary>
        internal ArmResourceMetadata? ResourceMetadata => _resourceMetadata;

        /// <summary>
        /// Gets the parent resource's CSharpType via the output library, or null for top-level resources.
        /// </summary>
        private CSharpType? ParentResourceType
            => _resourceMetadata?.ParentResourceId is { } parentId
                ? ProvisioningGenerator.Instance.OutputLibrary.GetResourceByIdPattern(parentId)?.Type
                : null;

        /// <inheritdoc/>
        ProvisioningPropertyInfo? IProvisioningPropertyInfo.GetProvisioningPropertyInfo(InputModelProperty inputProp)
        {
            if (!_propertyLookup.TryGetValue(inputProp, out var propInfo))
                return null;
            return new ProvisioningPropertyInfo(
                propInfo.PropertyName,
                propInfo.IsOutput,
                propInfo.IsRequired,
                propInfo.BicepPath,
                propInfo.DefaultValue,
                propInfo.TypeOverride);
        }

        /// <summary>
        /// Constructor for base resource types (with metadata from ARM provider schema).
        /// </summary>
        public ProvisioningResourceProvider(InputModelType inputModel, ArmResourceMetadata metadata)
            : base(inputModel)
        {
            _inputModel = inputModel;
            _resourceMetadata = metadata;
            _defaultApiVersion = metadata.ApiVersions.Count > 0
                ? metadata.ApiVersions.Last()
                : null;
            _createBodyWritableProperties = BuildCreateBodyWritableProperties();
            _allProperties = CollectAllProperties();
            _propertyLookup = _allProperties.ToDictionary(p => p.Property);
        }

        /// <summary>
        /// Constructor for derived discriminated resource types (no metadata, inherits from base resource).
        /// </summary>
        internal ProvisioningResourceProvider(InputModelType inputModel)
            : base(inputModel)
        {
            _inputModel = inputModel;
            _resourceMetadata = null;
            _defaultApiVersion = null;
            _createBodyWritableProperties = [];
            _allProperties = CollectAllProperties();
            _propertyLookup = _allProperties.ToDictionary(p => p.Property);
        }

        public override void Reset()
        {
            base.Reset();
            _parentField = null;
            _parentProperty = null;
            _parentType = null;
        }

        protected override string BuildNamespace()
            => ProvisioningGenerator.Instance.TypeFactory.PrimaryNamespace;

        protected override string BuildName()
        {
            // When the same input model is shared by multiple resources (e.g. parent +
            // child views like ContainerGroupProfile + ContainerGroupProfileRevision),
            // fall back to the metadata's ResourceName to avoid file/type collisions.
            return _resourceMetadata?.ResourceName ?? base.BuildName();
        }

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

        protected override CSharpType? BuildBaseType()
        {
            // Derived discriminated resources inherit from their base resource type
            if (_inputModel.DiscriminatorValue != null && _inputModel.BaseModel != null)
            {
                var baseProvider = CodeModelGenerator.Instance.TypeFactory.CreateModel(_inputModel.BaseModel);
                if (baseProvider != null)
                    return baseProvider.Type;
            }
            return new CSharpType(typeof(ProvisionableResource));
        }

        protected override FieldProvider[] BuildFields()
        {
            var fields = Properties.OfType<ProvisioningPropertyProvider>().Select(p => p.BackingField!).ToList();
            if (_parentField != null)
            {
                fields.Add(_parentField);
            }
            return [.. fields];
        }

        protected override PropertyProvider[] BuildProperties()
        {
            var properties = new List<PropertyProvider>();
            foreach (var propInfo in _allProperties)
            {
                var property = CodeModelGenerator.Instance.TypeFactory.CreateProperty(propInfo.Property, this);
                if (property != null)
                    properties.Add(property);
            }

            // Create parent property for child resources
            _parentType = ParentResourceType;
            if (_parentType != null)
            {
                _parentField = new FieldProvider(
                    FieldModifiers.Private,
                    new CSharpType(typeof(ResourceReference<>), _parentType),
                    "_parent",
                    this);
                _parentProperty = BuildParentProperty(_parentField, _parentType);
                properties.Add(_parentProperty);
            }

            return [.. properties];
        }

        private PropertyProvider BuildParentProperty(FieldProvider parentField, CSharpType parentType)
        {
            var nullableParentType = parentType.WithNullable(true);

            MethodBodyStatement[] parentGetter =
            [
                This.Invoke("Initialize").Terminate(),
                Return(parentField.AsValueExpression.Property("Value"))
            ];
            MethodBodyStatement[] parentSetter =
            [
                This.Invoke("Initialize").Terminate(),
                parentField.AsValueExpression.Property("Value").Assign(Value).Terminate()
            ];

            return new PropertyProvider(
                null,
                MethodSignatureModifiers.Public,
                nullableParentType,
                "Parent",
                new MethodPropertyBody(parentGetter, parentSetter),
                this);
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            var bicepIdentifierParam = new ParameterProvider("bicepIdentifier", $"The bicep identifier name.", typeof(string));
            var resourceVersionParam = new ParameterProvider("resourceVersion", $"The resource API version.", typeof(string), DefaultOf(new CSharpType(typeof(string), true)));

            if (_inputModel.DiscriminatorValue != null)
            {
                // Derived discriminated resource: (string bicepIdentifier, string? resourceVersion = default) : base(bicepIdentifier, resourceVersion)
                var initializer = new ConstructorInitializer(true, [bicepIdentifierParam, resourceVersionParam]);
                var sig = new ConstructorSignature(
                    Type,
                    $"Creates a new {Name}.",
                    MethodSignatureModifiers.Public,
                    [bicepIdentifierParam, resourceVersionParam],
                    null,
                    initializer);
                return [new ConstructorProvider(sig, MethodBodyStatement.Empty, this)];
            }

            // Base resource: base(bicepIdentifier, "ResourceType", resourceVersion ?? "defaultVersion")
            var resourceVersionArg = _defaultApiVersion != null
                ? (ValueExpression)new BinaryOperatorExpression("??",
                    resourceVersionParam,
                    Literal(_defaultApiVersion))
                : resourceVersionParam;
            var baseInitializer = new ConstructorInitializer(
                true,
                [
                    bicepIdentifierParam,
                    Literal(_resourceMetadata!.ResourceType),
                    resourceVersionArg
                ]);

            var baseSig = new ConstructorSignature(
                Type,
                $"Creates a new {Name}.",
                MethodSignatureModifiers.Public,
                [bicepIdentifierParam, resourceVersionParam],
                null,
                baseInitializer);

            return [new ConstructorProvider(baseSig, MethodBodyStatement.Empty, this)];
        }

        protected override MethodProvider[] BuildMethods()
        {
            var methods = new List<MethodProvider>();

            // DefineProvisionableProperties() override
            methods.Add(BuildDefineProvisionablePropertiesMethod());

            // FromExisting() static method — only for base resources
            if (_inputModel.DiscriminatorValue == null)
            {
                methods.Add(BuildFromExistingMethod());
            }

            // DefineAdditionalProperties() partial method for customization
            methods.Add(BuildDefineAdditionalPropertiesMethod());

            // GetResourceNameRequirements() override — only for base resource types
            var nameRequirementsMethod = BuildGetResourceNameRequirementsMethod(_resourceMetadata, this);
            if (nameRequirementsMethod != null)
            {
                methods.Add(nameRequirementsMethod);
            }

            // CreateRoleAssignment() overloads — only for resources that have RBAC roles
            if (_inputModel.DiscriminatorValue == null && _resourceMetadata?.RbacRoles?.Count > 0)
            {
                var outputLibrary = (ProvisioningOutputLibrary)ProvisioningGenerator.Instance.OutputLibrary;
                var builtInRole = outputLibrary.BuiltInRole;
                if (builtInRole != null)
                {
                    methods.Add(BuildCreateRoleAssignmentWithIdentityMethod(builtInRole.Type));
                    methods.Add(BuildCreateRoleAssignmentWithPrincipalMethod(builtInRole.Type));
                }
            }

            return [.. methods];
        }

        protected override TypeProvider[] BuildNestedTypes()
        {
            // Derived discriminated resources don't have their own ResourceVersions
            if (_inputModel.DiscriminatorValue != null)
                return [];

            var apiVersions = _resourceMetadata?.ApiVersions;
            if (apiVersions == null || apiVersions.Count == 0)
                return [];

            // When the current (default) API version is GA, exclude preview versions.
            // Preview versions are only included when the current version is itself a preview.
            if (!IsPreviewApiVersion(apiVersions[^1]))
            {
                var gaVersions = apiVersions.Where(v => !IsPreviewApiVersion(v)).ToList();
                if (gaVersions.Count == 0)
                    return [];
                apiVersions = gaVersions;
            }

            // ResourceVersions nested class
            return [new ResourceVersionsProvider(this, apiVersions)];
        }

        protected override TypeProvider[] BuildSerializationProviders()
            => [];

        // ── Property collection ──────────────────────────────────────

        /// <summary>
        /// Builds a set of serialized property names that are writable in the create/update request body.
        /// When the resource model is output-only (e.g., ProxyResource with separate create body),
        /// its properties may be marked readOnly even though the create body has them as writable.
        /// </summary>
        private HashSet<string> BuildCreateBodyWritableProperties()
        {
            var result = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (_resourceMetadata == null) return result;

            var createMethod = _resourceMetadata.Methods
                .FirstOrDefault(m => m.Kind == ResourceOperationKind.Create)?.InputMethod;
            if (createMethod == null) return result;

            foreach (var parameter in createMethod.Parameters)
            {
                if (parameter.Location == InputRequestLocation.Body && parameter.Type is InputModelType bodyModel)
                {
                    CollectWritableProperties(bodyModel, result);
                }
            }

            return result;
        }

        /// <summary>
        /// Collects serialized names of writable properties from a model and its base model chain.
        /// </summary>
        private static void CollectWritableProperties(InputModelType model, HashSet<string> result)
        {
            var current = model;
            while (current != null)
            {
                foreach (var prop in current.Properties)
                {
                    if (!prop.IsReadOnly)
                    {
                        result.Add(prop.SerializedName ?? prop.Name);
                    }
                }
                current = current.BaseModel;
            }
        }

        private List<ResourcePropertyInfo> CollectAllProperties()
        {
            // Derived discriminated resources only collect their own properties
            if (_inputModel.DiscriminatorValue != null)
                return CollectOwnProperties();

            var result = new List<ResourcePropertyInfo>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // Collect from the base chain first (top-most ancestor → immediate base),
            // then from the resource model itself. This ensures inherited ARM common
            // properties (name, location, tags) appear before leaf-defined properties
            // (e.g., the "properties" bag), which controls the Bicep emission order.
            var chain = new Stack<InputModelType>();
            chain.Push(_inputModel);
            var baseModel = _inputModel.BaseModel;
            while (baseModel != null)
            {
                chain.Push(baseModel);
                baseModel = baseModel.BaseModel;
            }

            foreach (var model in chain)
            {
                CollectPropertiesFromModel(model, result, seen, basePath: null);
            }

            return result;
        }

        private void CollectPropertiesFromModel(
            InputModelType model,
            List<ResourcePropertyInfo> result,
            HashSet<string> seen,
            string[]? basePath)
        {
            foreach (var prop in model.Properties)
            {
                if (prop.IsDiscriminator) continue;

                var serializedName = prop.SerializedName ?? prop.Name;

                if (seen.Contains(serializedName)) continue;
                seen.Add(serializedName);

                // Skip "type" property
                if (SkipProperties.Contains(serializedName)) continue;

                var bicepPath = basePath != null
                    ? [.. basePath, serializedName]
                    : new[] { serializedName };

                var isOutput = (prop.IsReadOnly && !RequiredInputProperties.Contains(serializedName)
                        && !_createBodyWritableProperties.Contains(serializedName))
                    || OutputOnlyProperties.Contains(serializedName);
                var isRequired = prop.IsRequired || RequiredInputProperties.Contains(serializedName);

                var propertyName = prop.Name.ToIdentifierName();
                // For singleton resources, the "name" property is output-only with a default value
                string? defaultValue = null;
                if (serializedName == "name"
                    && _resourceMetadata?.SingletonResourceName is not null)
                {
                    defaultValue = _resourceMetadata.SingletonResourceName;
                    isOutput = true;
                }
                // Ensure "location" at the resource level always uses AzureLocation,
                // even when the TypeSpec defines it as plain string.
                // TODO - this is currently a workaround until we have a more reliable way to detect such violations from the spec level.
                CSharpType? typeOverride = null;
                if (basePath is null
                    && string.Equals(serializedName, "location", StringComparison.OrdinalIgnoreCase))
                {
                    typeOverride = new CSharpType(typeof(BicepValue<>), typeof(Azure.Core.AzureLocation));
                }

                result.Add(new ResourcePropertyInfo(prop, propertyName, bicepPath, isOutput, isRequired, defaultValue, typeOverride));
            }
        }

        // ── Method builders ──────────────────────────────────────────

        private MethodProvider BuildDefineProvisionablePropertiesMethod()
        {
            var statements = new List<MethodBodyStatement>();
            statements.Add(Base.Invoke("DefineProvisionableProperties").Terminate());

            // Emit discriminator property for derived discriminated resource types
            if (_inputModel.DiscriminatorValue != null)
            {
                var discriminatorProp = FindDiscriminatorProperty();
                if (discriminatorProp != null)
                {
                    var serializedName = discriminatorProp.SerializedName ?? discriminatorProp.Name;
                    statements.Add(
                        This.Invoke(
                            "DefineProperty",
                            [
                                Literal(serializedName),
                                New.Array(typeof(string), [Literal(serializedName)]),
                                new PositionalParameterReferenceExpression("defaultValue", Literal(_inputModel.DiscriminatorValue))
                            ],
                            [typeof(string)],
                            false
                        ).Terminate()
                    );
                }
            }

            foreach (var provProp in Properties.OfType<ProvisioningPropertyProvider>())
            {
                var field = provProp.BackingField!;
                string methodName;
                CSharpType[] typeArgs;

                if (BicepTypeHelpers.IsModelType(field.Type))
                {
                    methodName = "DefineModelProperty";
                    typeArgs = [field.Type];
                }
                else if (BicepTypeHelpers.IsBicepListType(field.Type))
                {
                    methodName = "DefineListProperty";
                    typeArgs = [BicepTypeHelpers.GetGenericArgument(field.Type)];
                }
                else if (BicepTypeHelpers.IsBicepDictionaryType(field.Type))
                {
                    methodName = "DefineDictionaryProperty";
                    typeArgs = [BicepTypeHelpers.GetGenericArgument(field.Type)];
                }
                else
                {
                    methodName = "DefineProperty";
                    typeArgs = [BicepTypeHelpers.GetGenericArgument(field.Type)];
                }

                statements.Add(field.Assign(
                    This.Invoke(
                        methodName,
                        BicepTypeHelpers.BuildDefinePropertyArgs(provProp.Name, provProp.BicepPath, provProp.IsOutput, provProp.IsRequired, provProp.DefaultValue),
                        typeArgs,
                        false)
                ).Terminate());
            }

            // Add DefineResource call for parent on child resources
            if (_parentField != null && _parentType != null)
            {
                statements.Add(_parentField.Assign(
                    This.Invoke(
                        "DefineResource",
                        [
                            Literal("Parent"),
                            New.Array(typeof(string), [Literal("parent")]),
                            new PositionalParameterReferenceExpression("isRequired", Literal(true))
                        ],
                        [_parentType],
                        false)
                ).Terminate());
            }

            // Call the partial method for customization
            statements.Add(This.Invoke("DefineAdditionalProperties").Terminate());

            return new MethodProvider(
                new MethodSignature(
                    "DefineProvisionableProperties",
                    $"Define all the provisionable properties for {Name}.",
                    MethodSignatureModifiers.Protected | MethodSignatureModifiers.Override,
                    null,
                    null,
                    []),
                statements,
                this);
        }

        private MethodProvider BuildFromExistingMethod()
        {
            var bicepIdentifierParam = new ParameterProvider("bicepIdentifier", $"The bicep identifier name.", typeof(string));
            var resourceVersionParam = new ParameterProvider("resourceVersion", $"The resource API version.", typeof(string), DefaultOf(new CSharpType(typeof(string), true)));

            var sig = new MethodSignature(
                "FromExisting",
                $"Creates a reference to an existing {Name}.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                Type,
                null,
                [bicepIdentifierParam, resourceVersionParam]);

            // Build the body: var result = new Type(bicepIdentifier, resourceVersion); result.IsExistingResource = true; return result;
            var resultVar = new VariableExpression(Type, "result");
            MethodBodyStatement[] bodyStatements =
            [
                Declare(resultVar, New.Instance(Type, [bicepIdentifierParam, resourceVersionParam])),
                resultVar.Property("IsExistingResource").Assign(True).Terminate(),
                Return(resultVar)
            ];

            return new MethodProvider(sig, bodyStatements, this);
        }

        private MethodProvider BuildDefineAdditionalPropertiesMethod()
        {
            var sig = new MethodSignature(
                "DefineAdditionalProperties",
                $"Define additional provisionable properties for {Name} that are not part of the generated code.",
                MethodSignatureModifiers.Partial,
                null,
                null,
                []);

            return new MethodProvider(sig, this);
        }

        private static MethodProvider? BuildGetResourceNameRequirementsMethod(ArmResourceMetadata? resourceMetadata, TypeProvider enclosingType)
        {
            if (resourceMetadata is null)
            {
                return null;
            }

            var constraints = resourceMetadata.NameConstraints;

            // Only generate the override when the spec actually specifies name constraints
            if (constraints.Pattern is null && constraints.MinLength is null && constraints.MaxLength is null)
            {
                return null;
            }

            int minLength = constraints.MinLength ?? 1;
            int maxLength = constraints.MaxLength ?? 24;

            // Parse valid characters from pattern, or use conservative default
            var validCharacters = constraints.Pattern != null
                ? constraints.Pattern.ParsePatternToResourceNameCharacters()
                : ResourceNameCharacters.LowercaseLetters;

            // If parsing produced no characters, fall back to conservative default
            if (validCharacters == (ResourceNameCharacters)0)
            {
                validCharacters = ResourceNameCharacters.LowercaseLetters;
            }

            // Build the flags expression by OR-ing the individual flag values
            ValueExpression flagsExpression = BuildResourceNameCharactersExpression(validCharacters);

            var sig = new MethodSignature(
                "GetResourceNameRequirements",
                $"Get the requirements for naming this resource.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                typeof(ResourceNameRequirements),
                $"Naming requirements.",
                [],
                Attributes: [new AttributeStatement(typeof(EditorBrowsableAttribute), [new MemberExpression(typeof(EditorBrowsableState), nameof(EditorBrowsableState.Never))])]);

            var body = New.Instance(
                typeof(ResourceNameRequirements),
                [Literal(minLength), Literal(maxLength), flagsExpression]);

            return new MethodProvider(sig, body, enclosingType);
        }

        private static ValueExpression BuildResourceNameCharactersExpression(ResourceNameCharacters characters)
        {
            var flags = new List<ValueExpression>();

            if (characters.HasFlag(ResourceNameCharacters.LowercaseLetters))
                flags.Add(FrameworkEnumValue(ResourceNameCharacters.LowercaseLetters));
            if (characters.HasFlag(ResourceNameCharacters.UppercaseLetters))
                flags.Add(FrameworkEnumValue(ResourceNameCharacters.UppercaseLetters));
            if (characters.HasFlag(ResourceNameCharacters.Numbers))
                flags.Add(FrameworkEnumValue(ResourceNameCharacters.Numbers));
            if (characters.HasFlag(ResourceNameCharacters.Hyphen))
                flags.Add(FrameworkEnumValue(ResourceNameCharacters.Hyphen));
            if (characters.HasFlag(ResourceNameCharacters.Underscore))
                flags.Add(FrameworkEnumValue(ResourceNameCharacters.Underscore));
            if (characters.HasFlag(ResourceNameCharacters.Period))
                flags.Add(FrameworkEnumValue(ResourceNameCharacters.Period));
            if (characters.HasFlag(ResourceNameCharacters.Parentheses))
                flags.Add(FrameworkEnumValue(ResourceNameCharacters.Parentheses));

            // OR them together
            var result = flags[0];
            for (int i = 1; i < flags.Count; i++)
            {
                result = new BinaryOperatorExpression("|", result, flags[i]);
            }
            return result;
        }

        // ── CreateRoleAssignment helpers ─────────────────────────────

        /// <summary>
        /// Builds: CreateRoleAssignment(XxxBuiltInRole role, UserAssignedIdentity identity)
        /// </summary>
        private MethodProvider BuildCreateRoleAssignmentWithIdentityMethod(CSharpType builtInRoleType)
        {
            var roleParam = new ParameterProvider("role", $"The role to grant.", builtInRoleType);
            var identityParam = new ParameterProvider("identity", $"The <see cref=\"UserAssignedIdentity\"/>.", typeof(UserAssignedIdentity));

            var sig = new MethodSignature(
                "CreateRoleAssignment",
                $"Creates a role assignment for a user-assigned identity that grants access to this {Name}.",
                MethodSignatureModifiers.Public,
                typeof(RoleAssignment),
                $"The <see cref=\"RoleAssignment\"/>.",
                [roleParam, identityParam]);

            var resultVar = new VariableExpression(typeof(RoleAssignment), "result");
            var roleNameVar = new VariableExpression(typeof(string), "roleName");

            // string roleName = XxxBuiltInRole.GetBuiltInRoleName(role);
            var getRoleName = Static(builtInRoleType).Invoke("GetBuiltInRoleName", [(ValueExpression)roleParam]);

            // Constructor arg: $"{BicepIdentifier}_{identity.BicepIdentifier}_{roleName}"
            var constructorArg = new FormattableStringExpression(
                "{0}_{1}_{2}",
                [
                    new MemberExpression(null, "BicepIdentifier"),
                    new MemberExpression(identityParam, "BicepIdentifier"),
                    roleNameVar
                ]);

            // BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())
            var roleDefId = Static(typeof(BicepFunction)).Invoke(
                "GetSubscriptionResourceId",
                [Literal("Microsoft.Authorization/roleDefinitions"), ((ValueExpression)roleParam).InvokeToString()]);

            MethodBodyStatement[] body = [
                Declare(roleNameVar, getRoleName),
                Declare(resultVar, New.Instance(typeof(RoleAssignment), [constructorArg])),
                resultVar.Property("Name").Assign(
                    Static(typeof(BicepFunction)).Invoke("CreateGuid", [
                        new MemberExpression(null, "Id"),
                        new MemberExpression(identityParam, "PrincipalId"),
                        roleDefId
                    ])
                ).Terminate(),
                resultVar.Property("Scope").Assign(
                    New.Instance(typeof(BicepIdentifierExpression), [new MemberExpression(null, "BicepIdentifier")])
                ).Terminate(),
                resultVar.Property("PrincipalType").Assign(
                    new MemberExpression(Static(typeof(RoleManagementPrincipalType)), nameof(RoleManagementPrincipalType.ServicePrincipal))
                ).Terminate(),
                resultVar.Property("RoleDefinitionId").Assign(roleDefId).Terminate(),
                resultVar.Property("PrincipalId").Assign(
                    new MemberExpression(identityParam, "PrincipalId")
                ).Terminate(),
                Return(resultVar)
            ];

            return new MethodProvider(sig, body, this);
        }

        /// <summary>
        /// Builds: CreateRoleAssignment(XxxBuiltInRole role, BicepValue&lt;RoleManagementPrincipalType&gt; principalType, BicepValue&lt;Guid&gt; principalId, string? bicepIdentifierSuffix)
        /// </summary>
        private MethodProvider BuildCreateRoleAssignmentWithPrincipalMethod(CSharpType builtInRoleType)
        {
            var roleParam = new ParameterProvider("role", $"The role to grant.", builtInRoleType);
            var principalTypeParam = new ParameterProvider(
                "principalType",
                $"The type of the principal to assign to.",
                new CSharpType(typeof(BicepValue<>)).MakeGenericType([typeof(RoleManagementPrincipalType)]));
            var principalIdParam = new ParameterProvider(
                "principalId",
                $"The principal to assign to.",
                new CSharpType(typeof(BicepValue<>)).MakeGenericType([typeof(Guid)]));
            var suffixParam = new ParameterProvider(
                "bicepIdentifierSuffix",
                $"Optional role assignment identifier name suffix.",
                new CSharpType(typeof(string), true),
                DefaultOf(new CSharpType(typeof(string), true)));

            var sig = new MethodSignature(
                "CreateRoleAssignment",
                $"Creates a role assignment for a principal that grants access to this {Name}.",
                MethodSignatureModifiers.Public,
                typeof(RoleAssignment),
                $"The <see cref=\"RoleAssignment\"/>.",
                [roleParam, principalTypeParam, principalIdParam, suffixParam]);

            var resultVar = new VariableExpression(typeof(RoleAssignment), "result");
            var roleNameVar = new VariableExpression(typeof(string), "roleName");
            var suffixSepVar = new VariableExpression(typeof(string), "suffixSep");

            // string roleName = XxxBuiltInRole.GetBuiltInRoleName(role);
            var getRoleName = Static(builtInRoleType).Invoke("GetBuiltInRoleName", [(ValueExpression)roleParam]);

            // string suffixSep = bicepIdentifierSuffix is null ? "" : "_";
            var declareSuffixSep = Declare(suffixSepVar, new TernaryConditionalExpression(
                ((ValueExpression)suffixParam).Is(Null),
                Literal(""),
                Literal("_")));

            // Constructor arg: $"{BicepIdentifier}_{roleName}{suffixSep}{bicepIdentifierSuffix}"
            var constructorArg = new FormattableStringExpression(
                "{0}_{1}{2}{3}",
                [
                    new MemberExpression(null, "BicepIdentifier"),
                    roleNameVar,
                    suffixSepVar,
                    (ValueExpression)suffixParam
                ]);

            // BicepFunction.GetSubscriptionResourceId("Microsoft.Authorization/roleDefinitions", role.ToString())
            var roleDefId = Static(typeof(BicepFunction)).Invoke(
                "GetSubscriptionResourceId",
                [Literal("Microsoft.Authorization/roleDefinitions"), ((ValueExpression)roleParam).InvokeToString()]);

            MethodBodyStatement[] body = [
                Declare(roleNameVar, getRoleName),
                declareSuffixSep,
                Declare(resultVar, New.Instance(typeof(RoleAssignment), [constructorArg])),
                resultVar.Property("Name").Assign(
                    Static(typeof(BicepFunction)).Invoke("CreateGuid", [
                        new MemberExpression(null, "Id"),
                        (ValueExpression)principalIdParam,
                        roleDefId
                    ])
                ).Terminate(),
                resultVar.Property("Scope").Assign(
                    New.Instance(typeof(BicepIdentifierExpression), [new MemberExpression(null, "BicepIdentifier")])
                ).Terminate(),
                resultVar.Property("PrincipalType").Assign((ValueExpression)principalTypeParam).Terminate(),
                resultVar.Property("RoleDefinitionId").Assign(roleDefId).Terminate(),
                resultVar.Property("PrincipalId").Assign((ValueExpression)principalIdParam).Terminate(),
                Return(resultVar)
            ];

            return new MethodProvider(sig, body, this);
        }

        // ── Type resolution helpers ──────────────────────────────────

        private CSharpType GetPropertyType(InputModelProperty prop)
        {
            // TODO: Improve error message with more context about what went wrong
            return CodeModelGenerator.Instance.TypeFactory.CreateCSharpType(prop.Type)
                ?? throw new InvalidOperationException(
                    $"Failed to resolve CSharpType for property '{prop.Name}' of type '{prop.Type}' in model '{_inputModel.Name}'.");
        }

        // ── Discriminator helpers ────────────────────────────────────

        /// <summary>
        /// Collects only the derived type's own properties (no base chain, no flattening).
        /// Used for derived discriminated resources.
        /// </summary>
        private List<ResourcePropertyInfo> CollectOwnProperties()
        {
            var result = new List<ResourcePropertyInfo>();
            foreach (var prop in _inputModel.Properties)
            {
                if (prop.IsDiscriminator) continue;
                var serializedName = prop.SerializedName ?? prop.Name;
                string[] bicepPath = [serializedName];
                result.Add(new ResourcePropertyInfo(
                    prop,
                    prop.Name.ToIdentifierName(),
                    bicepPath,
                    prop.IsReadOnly,
                    prop.IsRequired));
            }
            return result;
        }

        /// <summary>
        /// Finds the discriminator property by walking up the model's base chain.
        /// </summary>
        private InputModelProperty? FindDiscriminatorProperty()
        {
            var model = _inputModel;
            while (model != null)
            {
                if (model.DiscriminatorProperty != null)
                    return model.DiscriminatorProperty;
                model = model.BaseModel;
            }
            return null;
        }

        // ── Property info record ─────────────────────────────────────

        internal record ResourcePropertyInfo(
            InputModelProperty Property,
            string PropertyName,
            string[] BicepPath,
            bool IsOutput,
            bool IsRequired,
            string? DefaultValue = null,
            CSharpType? TypeOverride = null);

        // ── ResourceVersions nested class ────────────────────────────

        private class ResourceVersionsProvider : TypeProvider
        {
            private readonly ProvisioningResourceProvider _parent;
            private readonly IReadOnlyList<string> _apiVersions;

            public ResourceVersionsProvider(ProvisioningResourceProvider parent, IReadOnlyList<string> apiVersions)
            {
                _parent = parent;
                _apiVersions = apiVersions;
            }

            protected override string BuildName() => "ResourceVersions";

            protected override string BuildNamespace()
                => ProvisioningGenerator.Instance.TypeFactory.PrimaryNamespace;

            protected override string BuildRelativeFilePath()
                => _parent.RelativeFilePath; // Same file as parent

            protected override TypeSignatureModifiers BuildDeclarationModifiers()
                => TypeSignatureModifiers.Public | TypeSignatureModifiers.Static | TypeSignatureModifiers.Class;

            protected override FieldProvider[] BuildFields()
            {
                var fields = new List<FieldProvider>();

                foreach (var version in _apiVersions.Reverse())
                {
                    var fieldName = "V" + version.Replace('.', '_').Replace('-', '_').ToUpperInvariant();

                    // Preview API versions are marked with [Experimental] to signal they may change or be removed.
                    var isPreview = IsPreviewApiVersion(version);
                    var attributes = isPreview
                        ? [new AttributeStatement(typeof(ExperimentalAttribute), [Literal("AZPROVISION001")])]
                        : Array.Empty<AttributeStatement>();

                    fields.Add(new FieldProvider(
                        FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly,
                        typeof(string),
                        fieldName,
                        this,
                        description: $"API version \"{version}\".",
                        initializationValue: Literal(version),
                        attributes: attributes));
                }

                return [.. fields];
            }
        }

        internal static bool IsPreviewApiVersion(string version)
            => version.Contains("preview", StringComparison.OrdinalIgnoreCase);
    }
}
