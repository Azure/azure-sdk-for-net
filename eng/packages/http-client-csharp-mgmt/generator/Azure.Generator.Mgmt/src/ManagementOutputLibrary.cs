// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
using Azure.Generator.Providers;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Management
{
    /// <inheritdoc/>
    public class ManagementOutputLibrary : AzureOutputLibrary
    {
        private ManagementLongRunningOperationProvider? _armOperation;
        internal ManagementLongRunningOperationProvider ArmOperation => _armOperation ??= new ManagementLongRunningOperationProvider(false);

        private ManagementLongRunningOperationProvider? _genericArmOperation;
        internal ManagementLongRunningOperationProvider GenericArmOperation => _genericArmOperation ??= new ManagementLongRunningOperationProvider(true);

        private IReadOnlyList<ResourceClientProvider> BuildResources()
        {
            var result = new List<ResourceClientProvider>();
            foreach (var client in ManagementClientGenerator.Instance.InputLibrary.InputNamespace.Clients)
            {
                // A resource client should contain the decorator "Azure.ResourceManager.@resourceMetadata"
                var resourceMetadata = client.Decorators.FirstOrDefault(d => d.Name.Equals(KnownDecorators.ResourceMetadata));
                if (resourceMetadata is null)
                {
                    continue;
                }
                var resource = new ResourceClientProvider(client);
                ManagementClientGenerator.Instance.AddTypeToKeep(resource.Name);
                result.Add(resource);
            }
            return result;
        }

        /// <inheritdoc/>
        // TODO: generate collections
        protected override TypeProvider[] BuildTypeProviders()
        {
            var resources = BuildResources();
            return [.. base.BuildTypeProviders().Where(p => p is not SystemObjectTypeProvider), ArmOperation, GenericArmOperation, .. resources, .. resources.Select(r => r.Source)];
        }
    }
}
