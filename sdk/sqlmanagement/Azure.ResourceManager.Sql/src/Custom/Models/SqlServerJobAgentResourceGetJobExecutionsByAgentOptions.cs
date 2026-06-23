// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class SqlServerJobAgentResourceGetJobExecutionsByAgentOptions
    {
        [WirePath("createTimeMin")]
        public DateTimeOffset? CreateTimeMin { get; set; }
        [WirePath("createTimeMax")]
        public DateTimeOffset? CreateTimeMax { get; set; }
        [WirePath("endTimeMin")]
        public DateTimeOffset? EndTimeMin { get; set; }
        [WirePath("endTimeMax")]
        public DateTimeOffset? EndTimeMax { get; set; }
        [WirePath("isActive")]
        public bool? IsActive { get; set; }
        [WirePath("skip")]
        public long? Skip { get; set; }
        [WirePath("top")]
        public long? Top { get; set; }
    }
}
