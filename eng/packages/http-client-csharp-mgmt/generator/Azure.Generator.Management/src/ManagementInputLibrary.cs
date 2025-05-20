// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Management.Primitives;
using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementInputLibrary : InputLibrary
    {
        private readonly Lazy<IReadOnlyList<InputClient>> _allClients;
        private readonly Lazy<IReadOnlyDictionary<InputClient, ResourceMetadata>> _resourceMetadata;
        private readonly Lazy<IReadOnlyDictionary<string, InputModelType>> _inputModelsByCrossLanguageDefinitionId;
        private readonly Lazy<IReadOnlyDictionary<string, InputClient>> _inputClientsByCrossLanguageDefinitionId;

        /// <inheritdoc/>
        public ManagementInputLibrary(string configPath) : base(configPath)
        {
            _allClients = new(EnumerateClients);
            _resourceMetadata = new(BuildResourceMetadata);
            _inputModelsByCrossLanguageDefinitionId = new(BuildModelCrossLanguageDefinitionIds);
            _inputClientsByCrossLanguageDefinitionId = new(() => AllClients.ToDictionary(c => c.CrossLanguageDefinitionId, c => c));
        }

        /// <summary>
        /// All clients in the input library, including the subclients.
        /// </summary>
        public IReadOnlyList<InputClient> AllClients => _allClients.Value;

        internal ResourceMetadata? GetResourceMetadata(InputClient client)
            => _resourceMetadata.Value.TryGetValue(client, out var metadata) ? metadata : null;

        internal InputModelType? GetModelByCrossLanguageDefinitionId(string crossLanguageDefinitionId)
            => _inputModelsByCrossLanguageDefinitionId.Value.TryGetValue(crossLanguageDefinitionId, out var model) ? model : null;

        internal InputClient? GetClientByCrossLanguageDefinitionId(string crossLanguageDefinitionId)
            => _inputClientsByCrossLanguageDefinitionId.Value.TryGetValue(crossLanguageDefinitionId, out var client) ? client : null;

        internal bool IsResourceModel(InputModelType model)
            => model.Decorators.Any(d => d.Name.Equals(KnownDecorators.ArmResourceInternal));

        private IReadOnlyList<InputClient> EnumerateClients()
        {
            var clients = new List<InputClient>(InputNamespace.Clients);
            for (int i = 0; i < clients.Count; i++)
            {
                var client = clients[i];
                clients.AddRange(client.Children);
            }

            return clients;
        }

        private IReadOnlyDictionary<string, InputModelType> BuildModelCrossLanguageDefinitionIds()
        {
            // TODO -- we must have this because of a bug or a design issue in TCGC: https://github.com/Azure/typespec-azure/issues/1297
            // once this is solved, we could change this to the simple invocation of `ToDictionary`.
            var result = new Dictionary<string, InputModelType>();
            foreach (var model in InputNamespace.Models)
            {
                if (!result.ContainsKey(model.CrossLanguageDefinitionId))
                {
                    result.Add(model.CrossLanguageDefinitionId, model);
                }
            }
            return result;
        }

        private IReadOnlyDictionary<InputClient, ResourceMetadata> BuildResourceMetadata()
        {
            var resourceMetadata = new Dictionary<InputClient, ResourceMetadata>();
            foreach (var client in AllClients)
            {
                var decorator = client.Decorators.FirstOrDefault(d => d.Name == KnownDecorators.ResourceMetadata);
                if (decorator != null)
                {
                    var metadata = BuildResourceMetadata(decorator);
                    resourceMetadata.Add(client, metadata);
                }
            }
            return resourceMetadata;

            ResourceMetadata BuildResourceMetadata(InputDecoratorInfo decorator)
            {
                var args = decorator.Arguments ?? throw new InvalidOperationException();
                string? resourceType = null;
                InputModelType? resourceModel = null;
                InputClient? resourceClient = null;
                bool isSingleton = false;
                ResourceScope resourceScope = default;
                if (args.TryGetValue("resourceType", out var resourceTypeData))
                {
                    resourceType = resourceTypeData.ToObjectFromJson<string>();
                }

                if (args.TryGetValue("resourceModel", out var resourceModelData))
                {
                    var resourceModelId = resourceModelData.ToObjectFromJson<string>();
                    if (resourceModelId != null)
                    {
                        resourceModel = GetModelByCrossLanguageDefinitionId(resourceModelId!);
                    }
                }

                if (args.TryGetValue("resourceClient", out var resourceClientData))
                {
                    var resourceClientId = resourceClientData.ToObjectFromJson<string>();
                    if (resourceClientId != null)
                    {
                        resourceClient = GetClientByCrossLanguageDefinitionId(resourceClientId!);
                    }
                }

                if (args.TryGetValue("isSingleton", out var isSingletonData))
                {
                    isSingleton = isSingletonData.ToObjectFromJson<bool>();
                }

                if (args.TryGetValue("resourceScope", out var scopeData))
                {
                    var scopeString = scopeData.ToObjectFromJson<string>();
                    resourceScope = Enum.Parse<ResourceScope>(scopeString!, true);
                }

                // TODO -- I know we should never throw the exception, but here we just put it here and refine it later
                return new(resourceType ?? throw new InvalidOperationException("resourceType cannot be null"),
                    resourceModel ?? throw new InvalidOperationException("resourceModel cannot be null"),
                    resourceClient ?? throw new InvalidOperationException("resourceClient cannot be null"),
                    isSingleton,
                    resourceScope
                    );
            }
        }
    }
}
