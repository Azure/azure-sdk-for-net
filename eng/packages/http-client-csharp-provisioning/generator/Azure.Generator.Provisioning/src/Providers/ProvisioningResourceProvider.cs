// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Primitives;
using Azure.Generator.Provisioning.Utilities;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Provisioning.Providers
{
    /// <summary>
    /// Generates a ProvisionableResource subclass from an InputModelType + ResourceMetadata.
    /// Flattens the ARM "properties" bag, includes system properties from the base model chain,
    /// and generates ResourceVersions, FromExisting, and the resource constructor.
    /// </summary>
    internal class ProvisioningResourceProvider : ModelProvider, IProvisioningPropertyInfo
    {
        private const string FlattenPropertyDecoratorName = "Azure.ResourceManager.@flattenProperty";

        // System properties that should always be output-only
        private static readonly HashSet<string> OutputOnlyProperties = new(StringComparer.OrdinalIgnoreCase)
        {
            "id", "systemData", "type"
        };

        // System properties that should always be required
        private static readonly HashSet<string> RequiredInputProperties = new(StringComparer.OrdinalIgnoreCase)
        {
            "name", "location"
        };

        // Properties to skip entirely (type is implied by the resource type)
        private static readonly HashSet<string> SkipProperties = new(StringComparer.OrdinalIgnoreCase)
        {
            "type"
        };

        private readonly InputModelType _inputModel;
        private readonly ResourceMetadata? _resourceMetadata;
        private readonly string? _defaultApiVersion;
        private readonly List<ResourcePropertyInfo> _allProperties;

        private FieldProvider? _parentField;
        private PropertyProvider? _parentProperty;
        private CSharpType? _parentType;

        /// <summary>
        /// Gets the resource metadata, if this is a base resource type.
        /// </summary>
        internal ResourceMetadata? ResourceMetadata => _resourceMetadata;

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
            var propInfo = _allProperties.FirstOrDefault(p => p.Property == inputProp);
            if (propInfo == null) return null;
            return new ProvisioningPropertyInfo(
                propInfo.PropertyName,
                propInfo.IsOutput,
                propInfo.IsRequired,
                propInfo.BicepPath,
                propInfo.DefaultValue);
        }

        /// <summary>
        /// Constructor for base resource types (with metadata from ARM provider schema).
        /// </summary>
        public ProvisioningResourceProvider(InputModelType inputModel, ResourceMetadata metadata)
            : base(inputModel)
        {
            _inputModel = inputModel;
            _resourceMetadata = metadata;
            _defaultApiVersion = ProvisioningGenerator.Instance.InputLibrary.InputNamespace.ApiVersions.Last();
            _allProperties = CollectAllProperties();
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
            _allProperties = CollectAllProperties();
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
            var baseInitializer = new ConstructorInitializer(
                true,
                [
                    bicepIdentifierParam,
                    Literal(_resourceMetadata!.ResourceType),
                    new BinaryOperatorExpression("??",
                        resourceVersionParam,
                        Literal(_defaultApiVersion!))
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

            // TODO(https://github.com/Azure/azure-sdk-for-net/issues/56743): Generate
            // `GetResourceNameRequirements()` override with min/max length and valid characters
            // parsed from the ARM spec's @pattern/@minLength/@maxLength decorators.

            return [.. methods];
        }

        protected override TypeProvider[] BuildNestedTypes()
        {
            // Derived discriminated resources don't have their own ResourceVersions
            if (_inputModel.DiscriminatorValue != null)
                return [];

            var apiVersions = ProvisioningGenerator.Instance.InputLibrary.InputNamespace.ApiVersions;
            if (apiVersions.Count == 0)
                return [];

            // ResourceVersions nested class
            return [new ResourceVersionsProvider(this, _defaultApiVersion!)];
        }

        protected override TypeProvider[] BuildSerializationProviders()
            => [];

        // ── Property collection ──────────────────────────────────────

        private List<ResourcePropertyInfo> CollectAllProperties()
        {
            // Derived discriminated resources only collect their own properties
            if (_inputModel.DiscriminatorValue != null)
                return CollectOwnProperties();

            var result = new List<ResourcePropertyInfo>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // Collect from the resource model and its base chain
            CollectPropertiesFromModel(_inputModel, result, seen, basePath: null);

            var baseModel = _inputModel.BaseModel;
            while (baseModel != null)
            {
                CollectPropertiesFromModel(baseModel, result, seen, basePath: null);
                baseModel = baseModel.BaseModel;
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

                // Check if this property should be flattened (only via explicit decorator)
                bool shouldFlatten = prop.Decorators.Any(d => d.Name == FlattenPropertyDecoratorName);

                if (shouldFlatten && prop.Type is InputModelType flattenModel)
                {
                    var flattenPath = basePath != null
                        ? [.. basePath, serializedName]
                        : new[] { serializedName };

                    // Flatten the child model's properties
                    CollectPropertiesFromModel(flattenModel, result, seen, flattenPath);

                    // Also walk the child model's base chain
                    var childBase = flattenModel.BaseModel;
                    while (childBase != null)
                    {
                        CollectPropertiesFromModel(childBase, result, seen, flattenPath);
                        childBase = childBase.BaseModel;
                    }
                }
                else
                {
                    if (seen.Contains(serializedName)) continue;
                    seen.Add(serializedName);

                    // Skip "type" property
                    if (SkipProperties.Contains(serializedName)) continue;

                    var bicepPath = basePath != null
                        ? [.. basePath, serializedName]
                        : new[] { serializedName };

                    var isOutput = (prop.IsReadOnly && !RequiredInputProperties.Contains(serializedName))
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
                    result.Add(new ResourcePropertyInfo(prop, propertyName, bicepPath, isOutput, isRequired, defaultValue));
                }
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
            string? DefaultValue = null);

        // ── ResourceVersions nested class ────────────────────────────

        private class ResourceVersionsProvider : TypeProvider
        {
            private readonly ProvisioningResourceProvider _parent;
            private readonly string _defaultApiVersion;

            public ResourceVersionsProvider(ProvisioningResourceProvider parent, string defaultApiVersion)
            {
                _parent = parent;
                _defaultApiVersion = defaultApiVersion;
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
                var apiVersions = ProvisioningGenerator.Instance.InputLibrary.InputNamespace.ApiVersions;
                var fields = new List<FieldProvider>();

                foreach (var version in apiVersions.Reverse())
                {
                    var fieldName = "V" + version.Replace('.', '_').Replace('-', '_');
                    fields.Add(new FieldProvider(
                        FieldModifiers.Public | FieldModifiers.Static | FieldModifiers.ReadOnly,
                        typeof(string),
                        fieldName,
                        this,
                        description: $"API version \"{version}\".",
                        initializationValue: Literal(version)));
                }

                return [.. fields];
            }
        }
    }
}
