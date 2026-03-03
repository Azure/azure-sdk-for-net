// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
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
    internal class ProvisioningResourceProvider : ModelProvider
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

        // Thread-static used to make inputModel accessible during base class construction,
        // since _inputModel is only set after base constructor returns.
        [ThreadStatic]
        private static InputModelType? t_currentModel;

        private readonly InputModelType _inputModel;
        private readonly ResourceMetadata? _resourceMetadata;
        private readonly string? _defaultApiVersion;
        private readonly bool _isDerivedDiscriminator;
        private readonly List<ResourcePropertyInfo> _allProperties;

        private static InputModelType Capture(InputModelType model)
        {
            t_currentModel = model;
            return model;
        }

        /// <summary>
        /// Constructor for base resource types (with metadata from ARM provider schema).
        /// </summary>
        public ProvisioningResourceProvider(InputModelType inputModel, ResourceMetadata metadata)
            : base(Capture(inputModel))
        {
            _inputModel = inputModel;
            t_currentModel = null;
            _resourceMetadata = metadata;
            _isDerivedDiscriminator = false;
            _defaultApiVersion = ProvisioningGenerator.Instance.InputLibrary.InputNamespace.ApiVersions.Last();
            _allProperties = CollectAllProperties();
        }

        /// <summary>
        /// Constructor for derived discriminated resource types (no metadata, inherits from base resource).
        /// </summary>
        internal ProvisioningResourceProvider(InputModelType inputModel)
            : base(Capture(inputModel))
        {
            _inputModel = inputModel;
            t_currentModel = null;
            _resourceMetadata = null;
            _isDerivedDiscriminator = true;
            _defaultApiVersion = null;
            _allProperties = CollectAllProperties();
        }

        protected override string BuildName() => (_inputModel ?? t_currentModel)!.Name.ToIdentifierName();

        protected override string BuildNamespace()
            => ProvisioningGenerator.Instance.TypeFactory.PrimaryNamespace;

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

        protected override CSharpType? BuildBaseType()
        {
            // Derived discriminated resources inherit from their base resource type
            if (_isDerivedDiscriminator && _inputModel.BaseModel != null)
            {
                var baseProvider = CodeModelGenerator.Instance.TypeFactory.CreateModel(_inputModel.BaseModel);
                if (baseProvider != null)
                    return baseProvider.Type;
            }
            return new CSharpType(typeof(ProvisionableResource));
        }

        protected override FieldProvider[] BuildFields()
        {
            var fields = new List<FieldProvider>();
            foreach (var propInfo in _allProperties)
            {
                var bicepType = GetPropertyType(propInfo.Property);
                fields.Add(new FieldProvider(
                    FieldModifiers.Private,
                    bicepType,
                    $"_{propInfo.PropertyName.ToVariableName()}",
                    this));
            }
            return fields.ToArray();
        }

        protected override PropertyProvider[] BuildProperties()
        {
            var properties = new List<PropertyProvider>(_allProperties.Count);
            for (int i = 0; i < _allProperties.Count; i++)
            {
                var propInfo = _allProperties[i];
                var bicepType = GetPropertyType(propInfo.Property);
                var isReadOnly = propInfo.IsOutput;
                // TODO: Index-based field access may not work correctly when customized code
                // adds additional fields. Refactor to use name-based lookup if needed.
                var field = Fields[i];

                var getter = new MethodBodyStatement[]
                {
                    This.Invoke("Initialize").Terminate(),
                    Return(field)
                };

                MethodPropertyBody body;
                if (isReadOnly)
                {
                    body = new MethodPropertyBody(getter);
                }
                else if (BicepTypeHelpers.IsModelType(bicepType))
                {
                    var setter = new MethodBodyStatement[]
                    {
                        This.Invoke("Initialize").Terminate(),
                        This.Invoke("AssignOrReplace", new KeywordExpression("ref", field), Value).Terminate()
                    };
                    body = new MethodPropertyBody(getter, setter);
                }
                else
                {
                    var setter = new MethodBodyStatement[]
                    {
                        This.Invoke("Initialize").Terminate(),
                        field.AsValueExpression.Invoke("Assign", Value).Terminate()
                    };
                    body = new MethodPropertyBody(getter, setter);
                }

                properties.Add(new PropertyProvider(
                    null,
                    MethodSignatureModifiers.Public,
                    bicepType,
                    propInfo.PropertyName,
                    body,
                    this));
            }
            return properties.ToArray();
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            var bicepIdentifierParam = new ParameterProvider("bicepIdentifier", $"The bicep identifier name.", typeof(string));
            var resourceVersionParam = new ParameterProvider("resourceVersion", $"The resource API version.", typeof(string), DefaultOf(new CSharpType(typeof(string), true)));

            if (_isDerivedDiscriminator)
            {
                // Derived discriminated resource: (string bicepIdentifier, string? resourceVersion = default) : base(bicepIdentifier, resourceVersion)
                var initializer = new ConstructorInitializer(true, new ParameterProvider[] { bicepIdentifierParam, resourceVersionParam });
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
                    new TernaryConditionalExpression(
                        resourceVersionParam.NotEqual(Null),
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
            if (!_isDerivedDiscriminator)
            {
                methods.Add(BuildFromExistingMethod());
            }

            // TODO: Generate `private partial void DefineAdditionalProperties()` for customization.
            // MethodSignatureModifiers does not support Partial modifier yet.
            // See: https://github.com/microsoft/typespec/issues/9863

            return methods.ToArray();
        }

        protected override TypeProvider[] BuildNestedTypes()
        {
            // Derived discriminated resources don't have their own ResourceVersions
            if (_isDerivedDiscriminator)
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
            if (_isDerivedDiscriminator)
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
                        ? basePath.Append(serializedName).ToArray()
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
                        ? basePath.Append(serializedName).ToArray()
                        : new[] { serializedName };

                    var isOutput = prop.IsReadOnly || OutputOnlyProperties.Contains(serializedName);
                    var isRequired = prop.IsRequired || RequiredInputProperties.Contains(serializedName);

                    var propertyName = prop.Name.ToIdentifierName();
                    // For singleton resources, the "name" property gets a default value
                    string? defaultValue = null;
                    if (serializedName == "name"
                        && _resourceMetadata?.SingletonResourceName is not null)
                    {
                        defaultValue = _resourceMetadata.SingletonResourceName;
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
            if (_isDerivedDiscriminator && _inputModel.DiscriminatorValue != null)
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

            for (int i = 0; i < _allProperties.Count; i++)
            {
                var propInfo = _allProperties[i];
                var bicepType = GetPropertyType(propInfo.Property);
                var field = Fields[i];

                string methodName;
                CSharpType[] typeArgs;

                if (BicepTypeHelpers.IsModelType(bicepType))
                {
                    methodName = "DefineModelProperty";
                    typeArgs = [bicepType];
                }
                else if (BicepTypeHelpers.IsBicepListType(bicepType))
                {
                    methodName = "DefineListProperty";
                    typeArgs = [BicepTypeHelpers.GetGenericArgument(bicepType)];
                }
                else if (BicepTypeHelpers.IsBicepDictionaryType(bicepType))
                {
                    methodName = "DefineDictionaryProperty";
                    typeArgs = [BicepTypeHelpers.GetGenericArgument(bicepType)];
                }
                else
                {
                    methodName = "DefineProperty";
                    typeArgs = [BicepTypeHelpers.GetGenericArgument(bicepType)];
                }

                statements.Add(field.Assign(
                    This.Invoke(
                        methodName,
                        BicepTypeHelpers.BuildDefinePropertyArgs(propInfo.PropertyName, propInfo.BicepPath, propInfo.IsOutput, propInfo.IsRequired, propInfo.DefaultValue),
                        typeArgs,
                        false)
                ).Terminate());
            }

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
            var bodyStatements = new MethodBodyStatement[]
            {
                Declare(resultVar, New.Instance(Type, [bicepIdentifierParam, resourceVersionParam])),
                resultVar.Property("IsExistingResource").Assign(True).Terminate(),
                Return(resultVar)
            };

            return new MethodProvider(sig, bodyStatements, this);
        }

        // ── Type resolution helpers ──────────────────────────────────

        private CSharpType GetPropertyType(InputModelProperty prop)
        {
            return CodeModelGenerator.Instance.TypeFactory.CreateCSharpType(prop.Type)
                ?? new CSharpType(typeof(BicepValue<>), typeof(object));
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
                var bicepPath = new[] { serializedName };
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

        private record ResourcePropertyInfo(
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
