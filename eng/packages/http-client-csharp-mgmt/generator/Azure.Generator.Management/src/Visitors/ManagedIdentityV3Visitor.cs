// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Snippets;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.ClientModel.Primitives;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Management.Visitors
{
    /// <summary>
    /// Adds the <c>WireV3Options</c> and <c>JsonV3Options</c> fields to <see cref="ModelSerializationExtensionsDefinition"/>
    /// when the input schema's <c>ManagedServiceIdentityType</c> enum contains the no-space value
    /// <c>"SystemAssigned,UserAssigned"</c>, indicating v3/v5/v6 common-types format.
    /// </summary>
    internal class ManagedIdentityV3Visitor : ScmLibraryVisitor
    {
        protected override TypeProvider PostVisitType(TypeProvider type)
        {
            if (type is ModelSerializationExtensionsDefinition &&
                ManagementClientGenerator.Instance.TypeFactory.UseManagedServiceIdentityV3)
            {
                var wireV3OptionsField = new FieldProvider(
                    FieldModifiers.Internal | FieldModifiers.Static | FieldModifiers.ReadOnly,
                    typeof(ModelReaderWriterOptions),
                    ModelSerializationExtensionsSnippets.WireV3OptionsName,
                    type,
                    description: $"The wire v3 options for model serialization.",
                    initializationValue: New.Instance(typeof(ModelReaderWriterOptions), Literal("W|v3")));

                var jsonV3OptionsField = new FieldProvider(
                    FieldModifiers.Internal | FieldModifiers.Static | FieldModifiers.ReadOnly,
                    typeof(ModelReaderWriterOptions),
                    ModelSerializationExtensionsSnippets.JsonV3OptionsName,
                    type,
                    description: $"The JSON v3 options for model serialization.",
                    initializationValue: New.Instance(typeof(ModelReaderWriterOptions), Literal("J|v3")));

                type.Update(fields: [.. type.Fields, wireV3OptionsField, jsonV3OptionsField]);
            }

            return base.PostVisitType(type)!;
        }
    }
}
