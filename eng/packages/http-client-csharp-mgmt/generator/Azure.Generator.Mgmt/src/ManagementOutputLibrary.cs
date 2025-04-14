// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
using Azure.Generator.Management.Providers;
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
                BuildResourceCore(result, client);
            }
            return result;
        }

        private static void BuildResourceCore(List<ResourceClientProvider> result, Microsoft.TypeSpec.Generator.Input.InputClient client)
        {
            // A resource client should contain the decorator "Azure.ResourceManager.@resourceMetadata"
            var resourceMetadata = client.Decorators.FirstOrDefault(d => d.Name.Equals(KnownDecorators.ResourceMetadata));
            if (resourceMetadata is not null)
            {
                var resource = new ResourceClientProvider(client);
                ManagementClientGenerator.Instance.AddTypeToKeep(resource.Name);
                result.Add(resource);
            }

            foreach (var child in client.Children)
            {
                BuildResourceCore(result, child);
            }
        }

        /// <inheritdoc/>
        // TODO: generate collections
        protected override TypeProvider[] BuildTypeProviders()
        {
            var resources = BuildResources();
            var test = base.BuildTypeProviders();
            return [.. test, ArmOperation, GenericArmOperation, .. resources, .. resources.Select(r => r.Source)];
        }
    }
}
