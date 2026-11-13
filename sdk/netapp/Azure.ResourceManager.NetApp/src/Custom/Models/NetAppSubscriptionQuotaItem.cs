// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class NetAppSubscriptionQuotaItem : ResourceData
    {
        public NetAppSubscriptionQuotaItem()
        {
        }

        public NetAppSubscriptionQuotaItem(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, int? current = null, int? @default = null, int? usage = null)
            : base(id, name, resourceType, systemData)
        {
            Current = current;
            Default = @default;
            Usage = usage;
        }

        public int? Current { get; }
        public int? Default { get; }
        public int? Usage { get; }
    }
}
