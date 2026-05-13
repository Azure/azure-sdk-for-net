// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class InstancePoolUsage
    {
        public ResourceIdentifier Id { get; set; }
        public InstancePoolUsageName Name { get; set; }
        public ResourceType? ResourceType { get; set; }
        public string Unit { get; set; }
        public int? CurrentValue { get; set; }
        public int? Limit { get; set; }
        public int? RequestedLimit { get; set; }
    }
}
