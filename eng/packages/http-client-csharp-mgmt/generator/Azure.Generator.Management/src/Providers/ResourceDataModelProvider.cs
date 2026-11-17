// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Utilities;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
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

namespace Azure.Generator.Management.Providers
{
    /// <summary>
    /// ModelProvider used for Azure resource data classes.
    /// </summary>
    /// <remarks>
    /// Overrides identity-shaping members (<see cref="BuildName"/>, <see cref="BuildNamespace"/>,
    /// <see cref="BuildRelativeFilePath"/>) so that resource data classes are constructed with the
    /// final name, namespace, and file path from the very first <c>Type</c> access.
    /// <para>
    /// In particular, overriding <see cref="BuildName"/> to append <c>"Data"</c> is the only way to
    /// prevent a user's resource-client customization partial (e.g.
    /// <c>partial class FooResource : ArmResource</c>) from polluting <c>CustomCodeView.BaseType</c>:
    /// once <c>Type</c> is constructed, the base type is captured into the immutable
    /// <c>CSharpType._baseType</c>, and no subsequent visitor-driven rename can rewrite it.
    /// </para>
    /// </remarks>
    internal class ResourceDataModelProvider : ScmModelProvider
    {
        public ResourceDataModelProvider(InputModelType inputModel)
            : base(inputModel)
        {
            InputModel = inputModel;
        }

        // Preserve the original input model so later visitors can distinguish output-only resource data
        // from input-capable request models after the provider has been converted to a C# type.
        internal InputModelType InputModel { get; }

        protected override PropertyProvider[] BuildProperties()
        {
            var properties = base.BuildProperties().ToList();
            var inheritedName = BaseModelProvider is { } baseModel
                ? PropertyHelpers.GetAllProperties(baseModel).FirstOrDefault(property =>
                    property.Name == nameof(ResourceData.Name) && property.Type.Equals(typeof(string)) &&
                    (property.WireInfo is null || property.WireInfo.SerializedName == "name"))
                : null;
            if (inheritedName is null)
            {
                return properties.ToArray();
            }

            foreach (var inputProperty in InputModel.Properties.Where(property => property.SerializedName == "name"))
            {
                var alias = ManagementClientGenerator.Instance.TypeFactory.CreateProperty(inputProperty, this);
                if (alias is null || alias.Body.HasSetter || !alias.Type.WithNullable(false).Equals(typeof(string)) ||
                    alias.Name == inheritedName.Name || properties.Any(property => property.Name == alias.Name))
                {
                    continue;
                }

                // A distinct CLR name remains part of the SDK contract even when MTG consumes its original name as inherited.
                // Forward without wire metadata so the inherited name is serialized only once.
                var wirePath = new AttributeStatement(ManagementClientGenerator.Instance.OutputLibrary.WirePathAttributeDefinition.Type, [Literal("name")]);
                properties.Add(new PropertyProvider(alias.Description, alias.Modifiers, alias.Type, alias.Name,
                    new ExpressionPropertyBody(Base.Property(inheritedName.Name)), this, attributes: [.. alias.Attributes, wirePath]));
            }
            return properties.ToArray();
        }

        protected override IReadOnlyList<ConstructorProvider> BuildConstructorsForBackCompatibility(IEnumerable<ConstructorProvider> originalConstructors)
        {
            var original = originalConstructors.ToArray();
            return ConstructorProviderHelpers.RestoreValueTypeNullabilityOverloads(
                this, original, base.BuildConstructorsForBackCompatibility(original));
        }

        protected override string BuildName()
        {
            var name = InputModel.IsExactName ? InputModel.Name : InputModel.Name.ToIdentifierName();
            name = name.EndsWith("Data", StringComparison.Ordinal) ? name : $"{name}Data";

            // Look up the final data-class name before treating its unsuffixed model name as a new contract.
            return NormalizeTypeNameForNewContract(name, BuildNamespace(), null, _ =>
            {
                var normalizedName = base.BuildName();
                return normalizedName.EndsWith("Data", StringComparison.Ordinal) ? normalizedName : $"{normalizedName}Data";
            });
        }

        protected override string BuildNamespace()
            => ManagementClientGenerator.Instance.TypeFactory.PrimaryNamespace;

        protected override string BuildRelativeFilePath()
            => Path.Combine("src", "Generated", $"{Type.Name}.cs");
    }
}
