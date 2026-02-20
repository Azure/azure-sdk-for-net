// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppSubscriptionQuotaItem
    {
        public NetAppSubscriptionQuotaItem(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, int? current = null, int? @default = null, int? usage = null)
        {
            Id = id;
            Name = name;
            ResourceType = resourceType;
            SystemData = systemData;
            Current = current;
            Default = @default;
            Usage = usage;
        }

        public ResourceIdentifier Id { get; }
        public string Name { get; }
        public ResourceType ResourceType { get; }
        public Azure.ResourceManager.Models.SystemData SystemData { get; }
        public int? Current { get; }
        public int? Default { get; }
        public int? Usage { get; }
    }
}
