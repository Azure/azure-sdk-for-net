// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    /// Generates a ProvisionableConstruct subclass from an InputModelType.
    /// Uses TypeFactory.CreateCSharpType() for all type resolution, which returns
    /// BicepValue&lt;T&gt; / BicepList&lt;T&gt; / BicepDictionary&lt;T&gt; types directly.
    /// </summary>
    internal class ProvisioningModelProvider : ModelProvider
    {
        private readonly InputModelType _inputModel;
        private readonly bool _isDiscriminatedResource;

        public ProvisioningModelProvider(InputModelType inputModel, bool isDiscriminatedResource = false) : base(inputModel)
        {
            _inputModel = inputModel;
            _isDiscriminatedResource = isDiscriminatedResource;
        }

        protected override string BuildName() => _inputModel.Name.ToIdentifierName();

        protected override string BuildNamespace()
            => ProvisioningGenerator.Instance.TypeFactory.PrimaryNamespace;

        protected override string BuildRelativeFilePath()
        {
            // Discriminated derived resources are placed alongside resources, not in Models/
            if (_inputModel.DiscriminatorValue != null && _isDiscriminatedResource)
                return Path.Combine("src", "Generated", $"{Name}.cs");
            return Path.Combine("src", "Generated", "Models", $"{Name}.cs");
        }

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

        protected override CSharpType? BuildBaseType()
        {
            // Derived discriminated types inherit from their base model type
            if (_inputModel.DiscriminatorValue != null && _inputModel.BaseModel != null)
            {
                var baseProvider = CodeModelGenerator.Instance.TypeFactory.CreateModel(_inputModel.BaseModel);
                if (baseProvider != null)
                    return baseProvider.Type;
            }
            return new CSharpType(typeof(ProvisionableConstruct));
        }

        protected override FieldProvider[] BuildFields()
        {
            var fields = new List<FieldProvider>();
            foreach (var prop in _inputModel.Properties)
            {
                // Skip discriminator properties — they are emitted as DefineProperty with defaultValue
                // in derived types, not as C# properties.
                if (prop.IsDiscriminator)
                    continue;

                var bicepType = GetPropertyType(prop);
                fields.Add(new FieldProvider(
                    FieldModifiers.Private,
                    bicepType,
                    $"_{prop.Name.ToIdentifierName().ToVariableName()}",
                    this));
            }
            return fields.ToArray();
        }

        protected override PropertyProvider[] BuildProperties()
        {
            var properties = new List<PropertyProvider>();
            var fieldIndex = 0;
            foreach (var prop in _inputModel.Properties)
            {
                // Skip discriminator properties — handled separately in DefineProvisionableProperties.
                if (prop.IsDiscriminator)
                    continue;

                var bicepType = GetPropertyType(prop);
                var isReadOnly = prop.IsReadOnly;
                var field = Fields[fieldIndex++];

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
                    prop.Name.ToIdentifierName(),
                    body,
                    this));
            }
            return properties.ToArray();
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            if (_inputModel.DiscriminatorValue != null)
            {
                if (_isDiscriminatedResource)
                {
                    // Derived discriminated resource: (string bicepIdentifier, string? resourceVersion = default) : base(bicepIdentifier, resourceVersion)
                    var bicepIdentifierParam = new ParameterProvider("bicepIdentifier", $"The bicep identifier name.", typeof(string));
                    var resourceVersionParam = new ParameterProvider("resourceVersion", $"The resource API version.", typeof(string), DefaultOf(new CSharpType(typeof(string), true)));
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
                else
                {
                    // Derived discriminated model: () : base()
                    var initializer = new ConstructorInitializer(true, Array.Empty<ValueExpression>());
                    var sig = new ConstructorSignature(
                        Type,
                        $"Creates a new {Name}.",
                        MethodSignatureModifiers.Public,
                        [],
                        null,
                        initializer);
                    return [new ConstructorProvider(sig, MethodBodyStatement.Empty, this)];
                }
            }

            var regularSig = new ConstructorSignature(
                Type,
                $"Creates a new {Name}.",
                MethodSignatureModifiers.Public,
                []);
            return [new ConstructorProvider(regularSig, MethodBodyStatement.Empty, this)];
        }

        protected override MethodProvider[] BuildMethods()
        {
            var statements = new List<MethodBodyStatement>();
            statements.Add(Base.Invoke("DefineProvisionableProperties").Terminate());

            // Emit discriminator property for derived discriminated types
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

            var fieldIndex = 0;
            foreach (var prop in _inputModel.Properties)
            {
                // Skip discriminator properties — handled above with defaultValue.
                if (prop.IsDiscriminator)
                    continue;

                var bicepType = GetPropertyType(prop);
                var serializedName = prop.SerializedName ?? prop.Name;
                var bicepPath = new[] { serializedName };
                var field = Fields[fieldIndex++];

                var isOutput = prop.IsReadOnly;
                var isRequired = prop.IsRequired;

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
                        BicepTypeHelpers.BuildDefinePropertyArgs(prop.Name.ToIdentifierName(), bicepPath, isOutput, isRequired),
                        typeArgs,
                        false)
                ).Terminate());
            }

            var method = new MethodProvider(
                new MethodSignature(
                    "DefineProvisionableProperties",
                    $"Define all the provisionable properties for {Name}.",
                    MethodSignatureModifiers.Protected | MethodSignatureModifiers.Override,
                    null,
                    null,
                    []),
                statements,
                this);

            return [method];
        }

        protected override TypeProvider[] BuildSerializationProviders()
            => [];

        // ── Discriminator helpers ────────────────────────────────────

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

        // ── Type resolution helpers ──────────────────────────────────

        private CSharpType GetPropertyType(InputModelProperty prop)
        {
            return CodeModelGenerator.Instance.TypeFactory.CreateCSharpType(prop.Type)
                ?? new CSharpType(typeof(BicepValue<>), typeof(object));
        }
    }
}
