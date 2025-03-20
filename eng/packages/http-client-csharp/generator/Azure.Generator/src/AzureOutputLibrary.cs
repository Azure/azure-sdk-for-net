// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Primitives;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.ClientModel;
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

        private IReadOnlyList<ResourceClientProvider> BuildResources()
        {
            var result = new List<ResourceClientProvider>();
            foreach (var client in AzureClientGenerator.Instance.InputLibrary.InputNamespace.Clients)
            {
                // A resource client should contain the decorator "Azure.ResourceManager.@resourceMetadata"
                var resourceMetadata = client.Decorators.FirstOrDefault(d => d.Name.Equals(KnownDecorators.ResourceMetadata));
                if (resourceMetadata is null)
                {
                    continue;
                }
                var resource = new ResourceClientProvider(client);
                AzureClientGenerator.Instance.AddTypeToKeep(resource.Name);
                result.Add(resource);
            }
            return result;
        }

        /// <inheritdoc/>
        // TODO: generate collections
        protected override TypeProvider[] BuildTypeProviders()
        {
            var baseProviders = base.BuildTypeProviders();
            if (AzureClientGenerator.Instance.IsAzureArm.Value == true)
            {
                var resources = BuildResources();
                return [.. baseProviders, new RequestContextExtensionsDefinition(), ArmOperation, GenericArmOperation, .. resources, .. resources.Select(r => r.Source)];
            }
            return [.. baseProviders, new RequestContextExtensionsDefinition()];
        }
    }
}
