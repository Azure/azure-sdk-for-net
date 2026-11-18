// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;

namespace Extensions.Plugin.Visitors
{
    internal sealed class PreserveDatePropertyNamesVisitor : ScmLibraryVisitor
    {
        // Rename before the generator builds constructor parameters and serialization from the property.
        protected override PropertyProvider PreVisitProperty(InputProperty property, PropertyProvider propertyProvider)
        {
            if (propertyProvider is null || property.IsExactName || !IsDateTimeType(property.Type))
            {
                return propertyProvider;
            }

            var inputName = property.Name.ToIdentifierName();
            if (!inputName.EndsWith("At", StringComparison.Ordinal))
            {
                return propertyProvider;
            }

            var generatedName = propertyProvider.Name;
            var model = propertyProvider.EnclosingType;
            if (!generatedName.EndsWith("On", StringComparison.Ordinal)
                || model.LastContractView?.Properties.Any(p => p.Name == generatedName
                    && (p.Modifiers & (MethodSignatureModifiers.Public | MethodSignatureModifiers.Protected)) != 0) == true)
            {
                return propertyProvider;
            }

            // Keep the generator's acronym casing in the shared stem, but undo date-specific changes
            // such as StartAt -> StartsOn.
            int sharedLength = 0;
            int maxStemLength = Math.Min(inputName.Length - 2, generatedName.Length);
            while (sharedLength < maxStemLength
                && char.ToUpperInvariant(inputName[sharedLength]) == char.ToUpperInvariant(generatedName[sharedLength]))
            {
                sharedLength++;
            }

            var name = generatedName[..sharedLength] + inputName[sharedLength..];
            if (name != model.Name)
            {
                propertyProvider.Update(name: name);
            }

            return propertyProvider;
        }

        private static bool IsDateTimeType(InputType type) => type switch
        {
            InputDateTimeType => true,
            InputPrimitiveType { Kind: InputPrimitiveTypeKind.PlainDate } => true,
            InputNullableType nullable => IsDateTimeType(nullable.Type),
            _ => false,
        };
    }
}
