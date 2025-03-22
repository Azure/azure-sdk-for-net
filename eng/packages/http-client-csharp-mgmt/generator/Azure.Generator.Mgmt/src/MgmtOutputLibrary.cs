// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Mgmt.Primitives;
using Azure.Generator.Mgmt.Providers;
using Microsoft.TypeSpec.Generator.Providers;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Mgmt
{
    /// <inheritdoc/>
    public class MgmtOutputLibrary : AzureOutputLibrary
    {
        private MgmtLongRunningOperationProvider? _armOperation;
        internal MgmtLongRunningOperationProvider ArmOperation => _armOperation ??= new MgmtLongRunningOperationProvider(false);

        private MgmtLongRunningOperationProvider? _genericArmOperation;
        internal MgmtLongRunningOperationProvider GenericArmOperation => _genericArmOperation ??= new MgmtLongRunningOperationProvider(true);

        private IReadOnlyList<ResourceClientProvider> BuildResources()
        {
            var result = new List<ResourceClientProvider>();
            foreach (var client in MgmtClientGenerator.Instance.InputLibrary.InputNamespace.Clients)
            {
                // A resource client should contain the decorator "Azure.ResourceManager.@resourceMetadata"
                var resourceMetadata = client.Decorators.FirstOrDefault(d => d.Name.Equals(KnownDecorators.ResourceMetadata));
                if (resourceMetadata is null)
                {
                    continue;
                }
                var resource = new ResourceClientProvider(client);
                MgmtClientGenerator.Instance.AddTypeToKeep(resource.Name);
                result.Add(resource);
            }
            return result;
        }

        /// <inheritdoc/>
        // TODO: generate collections
        protected override TypeProvider[] BuildTypeProviders()
        {
            var resources = BuildResources();
            return [.. base.BuildTypeProviders(), ArmOperation, GenericArmOperation, .. resources, .. resources.Select(r => r.Source)];
        }
    }
}
