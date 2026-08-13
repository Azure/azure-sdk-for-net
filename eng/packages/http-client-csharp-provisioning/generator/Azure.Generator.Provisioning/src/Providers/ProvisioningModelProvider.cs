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
            => base.BuildBaseType() ?? new CSharpType(typeof(ProvisionableConstruct));

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
            var baseProperties = GetBaseProperties();
            var properties = new List<PropertyProvider>();

            // The TypeSpec hierarchy and the generated C# hierarchy are allowed to differ. In
            // particular, an input base can be intentionally omitted, or custom code can replace it
            // with a C# base that has no corresponding InputModelType. Build every property that the
            // input hierarchy could contribute, then reconcile that complete set against the actual
            // C# base surface. This keeps property ownership tied to the emitted hierarchy rather
            // than to assumptions about which input models happen to be generated.
            foreach (var property in GetAllPossibleProperties())
            {
                if (baseProperties.TryGetValue(property.Name, out var baseProperty))
                {
                    if (IsBasePropertyMatch(property, baseProperty))
                    {
                        continue;
                    }

                    // A same-name base member with a different type or provisioning contract does
                    // not implement this input property. The derived property must still be emitted,
                    // but it deliberately hides the incompatible base member.
                    property.Update(modifiers: property.Modifiers | MethodSignatureModifiers.New);
                }

                properties.Add(property);
            }

            // Input hierarchies can repeat a C# property name after renaming or hierarchy
            // customization. Candidates are produced from the most-derived model toward the root,
            // so retaining the first surviving property gives the highest input layer ownership.
            var names = new HashSet<string>(StringComparer.Ordinal);
            return [.. properties.Where(property => names.Add(property.Name))];
        }

        private IEnumerable<ProvisioningPropertyProvider> GetAllPossibleProperties()
        {
            for (var model = _inputModel; model != null; model = model.BaseModel)
            {
                foreach (var inputProperty in model.Properties)
                {
                    if (inputProperty.IsDiscriminator)
                    {
                        continue;
                    }

                    if (ProvisioningGenerator.Instance.TypeFactory.CreateProvisioningProperty(inputProperty, this)
                        is ProvisioningPropertyProvider property)
                    {
                        yield return property;
                    }
                }
            }
        }

        private Dictionary<string, PropertyProvider> GetBaseProperties()
        {
            var properties = new Dictionary<string, PropertyProvider>(StringComparer.Ordinal);
            var visitedTypes = new HashSet<CSharpType>();

            // TypeProvider.BaseTypeProvider is the direct provider chain used by the core generator,
            // but it is internal to Microsoft.TypeSpec.Generator and cannot be accessed from this
            // generator assembly. Walk the public BaseType chain instead and resolve each provider
            // here so generated and customization-only bases can both contribute canonical properties.
            var baseType = BaseType;

            while (baseType != null && visitedTypes.Add(baseType))
            {
                var baseProvider = ResolveTypeProvider(baseType);
                if (baseProvider == null)
                {
                    break;
                }

                // Walk from the immediate C# base toward the root and keep the first property for
                // each name. That is the member visible to the derived class when multiple base
                // layers hide one another.
                foreach (var property in baseProvider.CanonicalView.Properties)
                {
                    properties.TryAdd(property.Name, property);
                }

                baseType = baseProvider.BaseType;
            }

            return properties;
        }

        private static TypeProvider? ResolveTypeProvider(CSharpType type)
        {
            var typeFactory = ProvisioningGenerator.Instance.TypeFactory;
            if (typeFactory.CSharpTypeMap.TryGetValue(type, out var provider))
            {
                return provider;
            }

            if (string.IsNullOrEmpty(type.Namespace))
            {
                return null;
            }

            // A base declared entirely in custom code is not a ModelProvider and has no
            // InputModelType. Resolve its Roslyn-backed provider directly so its canonical
            // properties still participate in the same reconciliation as generated bases.
            provider = ProvisioningGenerator.Instance.SourceInputModel.FindForTypeInCurrentCompilation(
                type.Namespace,
                type.Name,
                type.DeclaringType?.Name,
                includeReferencedAssemblies: true);
            if (provider != null)
            {
                typeFactory.CSharpTypeMap[type] = provider;
            }

            return provider;
        }

        private static bool IsBasePropertyMatch(
            ProvisioningPropertyProvider property,
            PropertyProvider baseProperty)
        {
            if (!property.Type.Equals(baseProperty.Type))
            {
                return false;
            }

            // Custom properties do not expose provisioning metadata. Once their C# name and type
            // match, treat the base member as authoritative rather than generating a duplicate
            // property whose semantic equivalence cannot be disproved.
            if (baseProperty is not ProvisioningPropertyProvider baseProvisioningProperty)
            {
                return true;
            }

            // The same InputModelProperty instance represents the same TypeSpec declaration, including
            // all metadata that is not visible in the C# signature. Different instances represent a
            // redeclaration and must remain distinct even when their resolved name and type match.
            return ReferenceEquals(property.InputProperty, baseProvisioningProperty.InputProperty);
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
                        BicepTypeHelpers.BuildDefinePropertyArgs(field.Type, provProp.Name, provProp.BicepPath, provProp.IsOutput, provProp.IsRequired, provProp.DefaultValue, provProp.Format),
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
