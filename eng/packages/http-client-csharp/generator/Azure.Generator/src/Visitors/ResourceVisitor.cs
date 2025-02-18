// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;

namespace Azure.Generator.Visitors
{
    internal class ResourceVisitor : ScmLibraryVisitor
    {
        protected override ModelProvider? Visit(InputModelType model, ModelProvider? type)
        {
            base.Visit(model, type);
            if (type is not null)
            {
                TransformResource(type);
            }
            return type;
        }

        protected override TypeProvider? Visit(TypeProvider type)
        {
            base.Visit(type);
            TransformResource(type);
            return type;
        }

        private static void TransformResource(TypeProvider type)
        {
            if (type is ModelProvider && AzureClientPlugin.Instance.OutputLibrary.IsResource(type.Name))
            {
                type.RelativeFilePath = TransformRelativeFilePath(type);
                type.Name = TransformName(type);
                foreach (var serialization in type.SerializationProviders)
                {
                    serialization.RelativeFilePath = TransformRelativeFilePathForSerialization(serialization);
                    serialization.Name = TransformName(serialization);
                }
            }
        }

        private static string TransformName(TypeProvider model) => $"{model.Name}Data";

        private static string TransformRelativeFilePath(TypeProvider model)
            => Path.Combine("src", "Generated", $"{TransformName(model)}.RestClient.cs");

        private static string TransformRelativeFilePathForSerialization(TypeProvider model)
            => Path.Combine("src", "Generated", $"{TransformName(model)}.Serialization.cs");
    }
}
