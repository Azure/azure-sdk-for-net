// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update
{
    using Microsoft.Azure.Management.CosmosDB.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The stage of the cosmos db update allowing to set the consistency policy.
    /// </summary>
    public interface IWithConsistencyPolicy 
    {
        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <param name="maxStalenessPrefix">The max staleness prefix.</param>
        /// <param name="maxIntervalInSeconds">The max interval in seconds.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithBoundedStalenessConsistency(int maxStalenessPrefix, int maxIntervalInSeconds);

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithStrongConsistency();

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithEventualConsistency();

        /// <summary>
        /// The consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithSessionConsistency();
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to set the IP range filter.
    /// </summary>
    public interface IWithIpRangeFilter 
    {
        /// <summary>
        /// CosmosDB Firewall Support: This value specifies the set of IP addresses or IP address ranges in CIDR
        /// form to be included as the allowed list of client IPs for a given database account. IP addresses/ranges
        /// must be comma separated and must not contain any spaces.
        /// </summary>
        /// <param name="ipRangeFilter">Specifies the set of IP addresses or IP address ranges.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals WithIpRangeFilter(string ipRangeFilter);
    }

    /// <summary>
    /// Grouping of cosmos db update stages.
    /// </summary>
    public interface IWithOptionals  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithConsistencyPolicy,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithIpRangeFilter
    {
    }

    /// <summary>
    /// Grouping of cosmos db update stages.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithReadLocations,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithOptionals
    {
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing the definition of a write location.
    /// </summary>
    public interface IWithReadLocations  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>
    {
        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithReadLocations WithReadReplication(Region region);

        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Update.IWithReadLocations WithoutReadReplication(Region region);
    }
}