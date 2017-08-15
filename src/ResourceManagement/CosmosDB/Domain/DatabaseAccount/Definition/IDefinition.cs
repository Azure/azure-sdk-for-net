// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.CosmosDB.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;

    /// <summary>
    /// The stage of the cosmos db definition allowing to specify the resource group.
    /// </summary>
    public interface IWithGroup  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroup<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithKind>
    {
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to set the database account kind.
    /// </summary>
    public interface IWithKind 
    {
        /// <summary>
        /// The database account kind for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithConsistencyPolicy WithKind(string kind);
    }

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for
    /// the resource to be created, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.CosmosDB.Fluent.ICosmosDBAccount>,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithConsistencyPolicy,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithReadReplication,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithIpRangeFilter
    {
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing the definition of a write location.
    /// </summary>
    public interface IWithReadReplication 
    {
        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithReadReplication(Region region);
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
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithIpRangeFilter(string ipRangeFilter);
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing the definition of a read location.
    /// </summary>
    public interface IWithWriteReplication 
    {
        /// <summary>
        /// A georeplication location for the CosmosDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithWriteReplication(Region region);
    }

    /// <summary>
    /// Grouping of cosmos db definition stages.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IBlank,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithGroup,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithKind,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithWriteReplication,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithReadReplication,
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The first stage of a cosmos db definition.
    /// </summary>
    public interface IBlank  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithRegion<Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithGroup>
    {
    }

    /// <summary>
    /// The stage of the cosmos db definition allowing to set the consistency policy.
    /// </summary>
    public interface IWithConsistencyPolicy 
    {
        /// <summary>
        /// The bounded staleness consistency policy for the CosmosDB account.
        /// </summary>
        /// <param name="maxStalenessPrefix">The max staleness prefix.</param>
        /// <param name="maxIntervalInSeconds">The max interval in seconds.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithWriteReplication WithBoundedStalenessConsistency(int maxStalenessPrefix, int maxIntervalInSeconds);

        /// <summary>
        /// The strong consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithCreate WithStrongConsistency();

        /// <summary>
        /// The eventual consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithWriteReplication WithEventualConsistency();

        /// <summary>
        /// The session consistency policy for the CosmosDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.CosmosDB.Fluent.CosmosDBAccount.Definition.IWithWriteReplication WithSessionConsistency();
    }
}