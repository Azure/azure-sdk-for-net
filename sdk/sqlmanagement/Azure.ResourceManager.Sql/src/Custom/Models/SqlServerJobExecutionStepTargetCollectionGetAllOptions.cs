// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class SqlServerJobExecutionStepTargetCollectionGetAllOptions
    {
        public DateTimeOffset? CreateTimeMin { get; set; }
        public DateTimeOffset? CreateTimeMax { get; set; }
        public DateTimeOffset? EndTimeMin { get; set; }
        public DateTimeOffset? EndTimeMax { get; set; }
        public bool? IsActive { get; set; }
        public long? Skip { get; set; }
        public long? Top { get; set; }
    }
}
