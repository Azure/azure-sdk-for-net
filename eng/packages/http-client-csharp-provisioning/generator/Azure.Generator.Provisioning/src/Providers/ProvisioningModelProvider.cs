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

        // Populated by CreateProvisioningProperty (called from ProvisioningTypeFactory.CreatePropertyCore).
        private readonly Dictionary<InputModelProperty, (FieldProvider Field, PropertyProvider Property)> _propertyFieldMap = new();

        // Lazily initialized linked field-property triples (see EnsureFieldsInitialized)
        private List<(FieldProvider Field, PropertyProvider Property, InputModelProperty InputProp)>? _fieldPropertyPairs;

        public ProvisioningModelProvider(InputModelType inputModel) : base(inputModel)
        {
            _inputModel = inputModel;
        }

        protected override string BuildNamespace()
            => ProvisioningGenerator.Instance.TypeFactory.PrimaryNamespace;

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", "Models", $"{Name}.cs");

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

        /// <summary>
        /// Called from <see cref="ProvisioningTypeFactory.CreatePropertyCore"/> to create a provisioning-style
        /// property with BicepValue getter/setter and a linked backing field.
        /// Stores the field in <see cref="_propertyFieldMap"/> for later collection by <see cref="EnsureFieldsInitialized"/>.
        /// </summary>
        internal PropertyProvider? CreateProvisioningProperty(InputModelProperty inputProp, PropertyProvider? baseProperty)
        {
            if (inputProp.IsDiscriminator) return null;

            // Use the visitor-renamed name from base property if available, otherwise use the raw name
            var resolvedName = baseProperty?.Name ?? inputProp.Name.ToIdentifierName();
            var bicepType = GetPropertyType(inputProp);
            var field = new FieldProvider(
                FieldModifiers.Private,
                bicepType,
                $"_{resolvedName.ToVariableName()}",
                this);

            MethodBodyStatement[] getter =
            [
                This.Invoke("Initialize").Terminate(),
                Return(field)
            ];

            MethodPropertyBody body;
            if (inputProp.IsReadOnly)
            {
                body = new MethodPropertyBody(getter);
            }
            else if (BicepTypeHelpers.IsModelType(bicepType))
            {
                MethodBodyStatement[] setter =
                [
                    This.Invoke("Initialize").Terminate(),
                    This.Invoke("AssignOrReplace", new KeywordExpression("ref", field), Value).Terminate()
                ];
                body = new MethodPropertyBody(getter, setter);
            }
            else
            {
                MethodBodyStatement[] setter =
                [
                    This.Invoke("Initialize").Terminate(),
                    field.AsValueExpression.Invoke("Assign", Value).Terminate()
                ];
                body = new MethodPropertyBody(getter, setter);
            }

            var property = new PropertyProvider(
                null,
                MethodSignatureModifiers.Public,
                bicepType,
                resolvedName,
                body,
                this);

            _propertyFieldMap[inputProp] = (field, property);

            return property;
        }

        /// <summary>
        /// Triggers property creation through TypeFactory (which calls CreatePropertyCore → CreateProvisioningProperty),
        /// then collects the linked field-property triples.
        /// </summary>
        private void EnsureFieldsInitialized()
        {
            if (_fieldPropertyPairs != null)
                return;

            _fieldPropertyPairs = new List<(FieldProvider, PropertyProvider, InputModelProperty)>();
            foreach (var prop in _inputModel.Properties)
            {
                if (prop.IsDiscriminator) continue;

                var cachedProperty = CodeModelGenerator.Instance.TypeFactory.CreateProperty(prop, this);

                if (!_propertyFieldMap.ContainsKey(prop))
                {
                    CreateProvisioningProperty(prop, cachedProperty);
                }

                if (_propertyFieldMap.TryGetValue(prop, out var pair))
                {
                    _fieldPropertyPairs.Add((pair.Field, pair.Property, prop));
                }
            }
        }

        protected override FieldProvider[] BuildFields()
        {
            EnsureFieldsInitialized();
            return [.. _fieldPropertyPairs!.Select(p => p.Field)];
        }

        protected override PropertyProvider[] BuildProperties()
        {
            EnsureFieldsInitialized();
            return [.. _fieldPropertyPairs!.Select(p => p.Property)];
        }

        protected override ConstructorProvider[] BuildConstructors()
        {
            if (_inputModel.DiscriminatorValue != null)
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

            EnsureFieldsInitialized();
            foreach (var (field, property, prop) in _fieldPropertyPairs!)
            {
                var serializedName = prop.SerializedName ?? prop.Name;
                var bicepPath = new[] { serializedName };

                var isOutput = prop.IsReadOnly;
                var isRequired = prop.IsRequired;

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
                        BicepTypeHelpers.BuildDefinePropertyArgs(property.Name, bicepPath, isOutput, isRequired),
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
