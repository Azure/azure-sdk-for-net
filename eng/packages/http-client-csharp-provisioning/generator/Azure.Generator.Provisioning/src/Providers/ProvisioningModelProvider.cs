// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
using System.Diagnostics.CodeAnalysis;
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
    internal class ProvisioningModelProvider : ModelProvider, IProvisioningPropertyInfo
    {
        private readonly InputModelType _inputModel;
        private readonly bool _hasSettableUsage;

        public ProvisioningModelProvider(InputModelType inputModel) : base(inputModel)
        {
            _inputModel = inputModel;
            _hasSettableUsage = ProvisioningGenerator.Instance.InputLibrary.IsModelSettable(inputModel);
        }

        protected override string BuildNamespace()
            => ProvisioningGenerator.Instance.TypeFactory.PrimaryNamespace;

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", "Models", $"{Name}.cs");

        protected override TypeSignatureModifiers BuildDeclarationModifiers()
            => TypeSignatureModifiers.Public | TypeSignatureModifiers.Partial | TypeSignatureModifiers.Class;

        protected override CSharpType? BuildBaseType()
        {
            if (CustomCodeView?.BaseType != null)
            {
                var customBaseType = CustomCodeView.BaseType;
                if (TryResolveCustomBaseTypeProvider(customBaseType, out var provider))
                {
                    return provider.Type;
                }

                if (ProvisioningGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(customBaseType, out var mappedProvider)
                    && mappedProvider != null)
                {
                    return mappedProvider.Type;
                }

                return customBaseType;
            }

            // Derived discriminated types inherit from their base model type.
            if (_inputModel.DiscriminatorValue != null && _inputModel.BaseModel != null)
            {
                var baseProvider = ProvisioningGenerator.Instance.TypeFactory.CreateModel(_inputModel.BaseModel);
                if (baseProvider != null)
                    return baseProvider.Type;
            }
            return new CSharpType(typeof(ProvisionableConstruct));
        }

        private static bool TryResolveCustomBaseTypeProvider(CSharpType customBaseType, [NotNullWhen(true)] out TypeProvider? provider)
        {
            provider = null;
            if (!string.IsNullOrEmpty(customBaseType.Namespace))
            {
                return false;
            }

            if (TryResolveTypeProviderByName(customBaseType.Name, out provider))
            {
                return true;
            }

            foreach (var model in ProvisioningGenerator.Instance.InputLibrary.InputNamespace.Models
                .Where(model => string.Equals(model.Name, customBaseType.Name, StringComparison.Ordinal)
                    || string.Equals(model.Name.ToIdentifierName(), customBaseType.Name, StringComparison.Ordinal)))
            {
                ProvisioningGenerator.Instance.TypeFactory.CreateModel(model);
            }

            return TryResolveTypeProviderByName(customBaseType.Name, out provider);
        }

        private static bool TryResolveTypeProviderByName(string name, [NotNullWhen(true)] out TypeProvider? provider)
        {
            provider = ProvisioningGenerator.Instance.TypeFactory.CSharpTypeMap.Values
                .OfType<TypeProvider>()
                .FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.Ordinal));
            return provider != null;
        }

        /// <inheritdoc/>
        ProvisioningPropertyInfo? IProvisioningPropertyInfo.GetProvisioningPropertyInfo(InputModelProperty property)
        {
            if (property.IsDiscriminator) return null;
            var serializedName = property.SerializedName ?? property.Name;
            return new ProvisioningPropertyInfo(
                property.Name.ToIdentifierName(),
                property.IsReadOnly,
                !property.IsReadOnly && _hasSettableUsage,
                property.IsRequired && _hasSettableUsage,
                [serializedName]);
        }

        protected override FieldProvider[] BuildFields()
        {
            return [.. Properties.OfType<ProvisioningPropertyProvider>().Select(p => p.BackingField!)];
        }

        protected override PropertyProvider[] BuildProperties()
        {
            var properties = new List<PropertyProvider>();
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var customBasePropertyNames = new HashSet<string>(StringComparer.Ordinal);
            var customBaseWireNames = new HashSet<string>(StringComparer.Ordinal);
            if (CustomCodeView?.BaseType != null
                && TryResolveCustomBaseTypeProvider(CustomCodeView.BaseType, out var customBaseProvider))
            {
                AddBaseProperties(customBaseProvider, customBasePropertyNames, customBaseWireNames, []);
            }

            // Collect properties from the model and its base chain.
            // Non-discriminated models use ProvisionableConstruct as C# base (not the TypeSpec base),
            // so inherited properties must be explicitly collected here. If custom code supplies the base type,
            // skip inherited properties already exposed by that base type.
            var model = _inputModel;
            while (model != null)
            {
                foreach (var prop in model.Properties)
                {
                    if (prop.IsDiscriminator) continue;
                    if (!seen.Add(prop.Name)) continue;
                    if (ShouldSkipCustomBaseProperty(prop, customBasePropertyNames, customBaseWireNames)) continue;

                    var property = ProvisioningGenerator.Instance.TypeFactory.CreateProvisioningProperty(prop, this);
                    if (property != null)
                        properties.Add(property);
                }
                // Discriminated types use C# inheritance, so only collect own properties.
                if (_inputModel.DiscriminatorValue != null) break;
                model = model.BaseModel;
            }
            return [.. properties];
        }

        private static void AddBaseProperties(
            TypeProvider provider,
            HashSet<string> propertyNames,
            HashSet<string> wireNames,
            HashSet<TypeProvider> visited)
        {
            if (!visited.Add(provider))
            {
                return;
            }

            foreach (var property in provider.Properties.Concat(provider.CustomCodeView?.Properties ?? []))
            {
                propertyNames.Add(property.Name);
                if (property is ProvisioningPropertyProvider provisioningProperty)
                {
                    foreach (var segment in provisioningProperty.BicepPath)
                    {
                        wireNames.Add(segment);
                    }
                }
                else if (!string.IsNullOrEmpty(property.WireInfo?.SerializedName))
                {
                    wireNames.Add(property.WireInfo.SerializedName);
                }
            }

            if (provider.BaseType != null
                && ProvisioningGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(provider.BaseType, out var baseProvider)
                && baseProvider != null)
            {
                AddBaseProperties(baseProvider, propertyNames, wireNames, visited);
            }
        }

        private static bool ShouldSkipCustomBaseProperty(
            InputModelProperty property,
            HashSet<string> customBasePropertyNames,
            HashSet<string> customBaseWireNames)
        {
            if (customBasePropertyNames.Count == 0 && customBaseWireNames.Count == 0)
            {
                return false;
            }

            var propertyName = property.Name.ToIdentifierName();
            var wireName = property.SerializedName ?? property.Name;
            return customBasePropertyNames.Contains(propertyName) || customBaseWireNames.Contains(wireName);
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

            statements.Add(This.Invoke("DefineAdditionalProperties").Terminate());

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

            return [method, BuildDefineAdditionalPropertiesMethod()];
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
