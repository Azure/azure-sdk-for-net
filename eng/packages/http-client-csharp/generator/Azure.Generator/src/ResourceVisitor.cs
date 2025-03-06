// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Primitives;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Azure.Generator
{
    internal class ResourceVisitor : ScmLibraryVisitor
    {
        private HashSet<string> _resourceNames;

        public ResourceVisitor()
        {
            _resourceNames = AzureClientPlugin.Instance.InputLibrary.InputNamespace.Clients
                .Where(client => client.Decorators.Any(d => d.Name.Equals(KnownDecorators.ArmResourceOperations)) && client.Operations.Any(operation => operation.Decorators.Any(d => d.Name.Equals(KnownDecorators.ArmResourceRead))))
                .Select(client => client.Operations.First(operation => operation.Decorators.Any(d => d.Name.Equals(KnownDecorators.ArmResourceRead))).Responses.First(r => r.BodyType != null).BodyType!.Name).ToHashSet();
        }

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

        private void TransformResource(TypeProvider type)
        {
            if (type is ModelProvider && _resourceNames.Contains(type.Name))
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
