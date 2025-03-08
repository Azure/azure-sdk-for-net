// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;

namespace Azure.Generator
{
    internal class ResourceVisitor : ScmLibraryVisitor
    {
        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (type is not null)
            {
                TransformResource(type);
            }
            return type;
        }

        protected override TypeProvider? VisitType(TypeProvider type)
        {
            TransformResource(type);
            return type;
        }

        private static void TransformResource(TypeProvider type)
        {
            if (type is ModelProvider && AzureClientPlugin.Instance.OutputLibrary.IsResource(type.Name))
            {
                type.Update(relativeFilePath: TransformRelativeFilePath(type));
                type.Type.Update(TransformName(type));
                foreach (var serialization in type.SerializationProviders)
                {
                    serialization.Update(relativeFilePath: TransformRelativeFilePathForSerialization(serialization));
                    serialization.Type.Update(TransformName(serialization));
                }
            }
        }

        private static string TransformName(TypeProvider model) => $"{model.Name}Data";

        private static string TransformRelativeFilePath(TypeProvider model)
            => Path.Combine("src", "Generated", $"{TransformName(model)}.cs");

        private static string TransformRelativeFilePathForSerialization(TypeProvider model)
            => Path.Combine("src", "Generated", $"{TransformName(model)}.Serialization.cs");
    }
}
