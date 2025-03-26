// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.IO;
using System.Linq;

namespace Azure.Generator.Management
{
    internal class ResourceVisitor : ScmLibraryVisitor
    {
        protected override ModelProvider? PreVisitModel(InputModelType model, ModelProvider? type)
        {
            if (type is not null)
            {
                TransformResource(model, type);
            }
            return type;
        }

        private void TransformResource(InputModelType model, TypeProvider type)
        {
            if (type is ModelProvider && model.Decorators.Any(d => d.Name.Equals(KnownDecorators.ArmResourceInternal)))
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
