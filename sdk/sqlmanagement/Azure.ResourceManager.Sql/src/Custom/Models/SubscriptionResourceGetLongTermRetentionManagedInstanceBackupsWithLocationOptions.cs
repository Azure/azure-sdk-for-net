// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class SubscriptionResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions
    {
        public SubscriptionResourceGetLongTermRetentionManagedInstanceBackupsWithLocationOptions(AzureLocation locationName)
        {
            LocationName = locationName;
        }

        [WirePath("locationName")]
        public AzureLocation LocationName { get; set; }
        [WirePath("onlyLatestPerDatabase")]
        public bool? OnlyLatestPerDatabase { get; set; }
        [WirePath("databaseState")]
        public SqlDatabaseState? DatabaseState { get; set; }
        [WirePath("skip")]
        public long? Skip { get; set; }
        [WirePath("top")]
        public long? Top { get; set; }
        [WirePath("filter")]
        public string Filter { get; set; }
    }
}
