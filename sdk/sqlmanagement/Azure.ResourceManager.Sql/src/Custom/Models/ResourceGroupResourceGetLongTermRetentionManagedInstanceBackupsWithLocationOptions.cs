// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class ResourceGroupResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions
    {
        public ResourceGroupResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions(AzureLocation locationName)
        {
            LocationName = locationName;
        }

        public AzureLocation LocationName { get; set; }
        public bool? OnlyLatestPerDatabase { get; set; }
        public SqlDatabaseState? DatabaseState { get; set; }
        public long? Skip { get; set; }
        public long? Top { get; set; }
        public string Filter { get; set; }
    }
}
