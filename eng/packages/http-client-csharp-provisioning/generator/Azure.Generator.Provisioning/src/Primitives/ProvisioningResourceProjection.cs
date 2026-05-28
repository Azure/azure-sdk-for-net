// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Provisioning.Primitives
{
    /// <summary>
    /// Provisioning-specific view over one or more compatible management resource
    /// metadata entries that should emit as one provisioning resource type.
    /// </summary>
    internal sealed class ProvisioningResourceProjection
    {
        private ProvisioningResourceProjection(IReadOnlyList<ArmResourceMetadata> metadata)
        {
            Metadata = metadata;
            PrimaryMetadata = metadata[0];
            ResourceModel = PrimaryMetadata.ResourceModel;
            ResourceType = PrimaryMetadata.ResourceType;
            ResourceIdPatterns = [.. CollectResourceIdPatterns(metadata)];
            ApiVersions = [.. CollectApiVersions(metadata)];
        }

        internal ArmResourceMetadata PrimaryMetadata { get; }

        internal IReadOnlyList<ArmResourceMetadata> Metadata { get; }

        internal InputModelType ResourceModel { get; }

        internal string ResourceType { get; }

        internal IReadOnlyList<RequestPathPattern> ResourceIdPatterns { get; }

        internal IReadOnlyList<string> ApiVersions { get; }

        internal static IReadOnlyList<ProvisioningResourceProjection> Create(IReadOnlyList<ArmResourceMetadata> metadata)
        {
            var groups = new Dictionary<(string ResourceType, InputModelType ResourceModel), List<ArmResourceMetadata>>();
            var orderedGroups = new List<List<ArmResourceMetadata>>();

            foreach (var resource in metadata)
            {
                var key = (resource.ResourceType, resource.ResourceModel);
                if (!groups.TryGetValue(key, out var group))
                {
                    group = [];
                    groups.Add(key, group);
                    orderedGroups.Add(group);
                }
                group.Add(resource);
            }

            return [.. orderedGroups.Select(group => new ProvisioningResourceProjection(group))];
        }

        private static IEnumerable<RequestPathPattern> CollectResourceIdPatterns(IReadOnlyList<ArmResourceMetadata> metadata)
        {
            var seen = new HashSet<RequestPathPattern>();
            foreach (var resource in metadata)
            {
                if (seen.Add(resource.ResourceIdPattern))
                {
                    yield return resource.ResourceIdPattern;
                }
            }
        }

        private static IEnumerable<string> CollectApiVersions(IReadOnlyList<ArmResourceMetadata> metadata)
        {
            var seen = new HashSet<string>();
            foreach (var resource in metadata)
            {
                foreach (var apiVersion in resource.ApiVersions)
                {
                    if (seen.Add(apiVersion))
                    {
                        yield return apiVersion;
                    }
                }
            }
        }
    }
}
