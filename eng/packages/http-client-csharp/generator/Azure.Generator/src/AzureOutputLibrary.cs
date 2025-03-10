// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Primitives;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator
{
    /// <inheritdoc/>
    public class AzureOutputLibrary : ScmOutputLibrary
    {
        private LongRunningOperationProvider? _armOperation;
        internal LongRunningOperationProvider ArmOperation => _armOperation ??= new LongRunningOperationProvider(false);

        private LongRunningOperationProvider? _genericArmOperation;
        internal LongRunningOperationProvider GenericArmOperation => _genericArmOperation ??= new LongRunningOperationProvider(true);

        private IReadOnlyList<TypeProvider> BuildResources()
        {
            var result = new List<TypeProvider>();
            foreach (var client in AzureClientPlugin.Instance.InputLibrary.InputNamespace.Clients)
            {
                // A resource client should contain the decorator "Azure.ResourceManager.@resourceMetadata"
                var resourceMetadata = client.Decorators.FirstOrDefault(d => d.Name.Equals(KnownDecorators.ResourceMetadata));
                if (resourceMetadata is null)
                {
                    continue;
                }
                var resource = CreateResourceClientCore(client);
                AzureClientPlugin.Instance.AddTypeToKeep(resource.Name);
                result.Add(CreateResourceClientCore(client));
            }
            return result;
        }

        /// <summary>
        /// Create a resource client
        /// </summary>
        /// <param name="inputClient"></param>
        /// <returns></returns>
        public virtual TypeProvider CreateResourceClientCore(InputClient inputClient) => new ResourceClientProvider(inputClient);

        /// <inheritdoc/>
        // TODO: generate collections
        protected override TypeProvider[] BuildTypeProviders()
        {
            var baseProviders = base.BuildTypeProviders();
            if (AzureClientPlugin.Instance.IsAzureArm.Value == true)
            {
                var resources = BuildResources();
                return [.. baseProviders, new RequestContextExtensionsDefinition(), ArmOperation, GenericArmOperation, .. resources, .. resources.Select(r => ((ResourceClientProvider)r).Source)];
            }
            return [.. baseProviders, new RequestContextExtensionsDefinition()];
        }
    }
}
