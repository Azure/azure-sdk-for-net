// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Primitives;
using Microsoft.Generator.CSharp.ClientModel;
using Microsoft.Generator.CSharp.Input;
using Microsoft.Generator.CSharp.Primitives;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureTypeFactory : ScmTypeFactory
    {
        /// <inheritdoc/>
        protected override CSharpType? CreateCSharpTypeCore(InputType inputType)
        {
            if (inputType is InputPrimitiveType inputPrimitiveType)
            {
                var result = CreateKnownPrimitiveType(inputPrimitiveType);
                if (result != null)
                {
                    return result;
                }
            }
            return base.CreateCSharpTypeCore(inputType);
        }

        private CSharpType? CreateKnownPrimitiveType(InputPrimitiveType inputType)
        {
            InputPrimitiveType? primitiveType = inputType;
            while (primitiveType != null)
            {
                if (KnownAzureTypes.PrimitiveTypes.TryGetValue(primitiveType.CrossLanguageDefinitionId, out var knownType))
                {
                    return knownType;
                }

                primitiveType = primitiveType.BaseType;
            }

            return null;
        }
    }
}
