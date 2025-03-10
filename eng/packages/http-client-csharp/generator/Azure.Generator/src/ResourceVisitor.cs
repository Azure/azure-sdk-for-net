// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Primitives;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Azure.Generator
{
    internal class ResourceVisitor : ScmLibraryVisitor
    {
        private HashSet<string> _resourceCrossLanguageDefinitionIds;

        public ResourceVisitor()
        {
            _resourceCrossLanguageDefinitionIds = AzureClientPlugin.Instance.InputLibrary.InputNamespace.Clients
                .Where(client => client.Decorators.Any(d => d.Name.Equals(KnownDecorators.ResourceMetadata)))
                .Select(client => JsonDocument.Parse(client.Decorators.First(d => d.Name.Equals(KnownDecorators.ResourceMetadata)).Arguments?[KnownDecorators.ResourceModel]).RootElement.ToString())
                .ToHashSet();
        }

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
            if (type is ModelProvider && _resourceCrossLanguageDefinitionIds.Contains(model.CrossLanguageDefinitionId))
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
