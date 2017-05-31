// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.DocumentDB.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.DocumentDB.Fluent.DatabaseAccount.Definition;
    using Microsoft.Azure.Management.DocumentDB.Fluent.DatabaseAccount.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;

    public partial class DatabaseAccountImpl 
    {
        /// <summary>
        /// The database account kind for the DocumentDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        DatabaseAccount.Definition.IWithConsistencyPolicy DatabaseAccount.Definition.IWithKind.WithKind(string kind)
        {
            return this.WithKind(kind) as DatabaseAccount.Definition.IWithConsistencyPolicy;
        }

        /// <summary>
        /// The consistency policy for the DocumentDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        DatabaseAccount.Update.IWithOptionals DatabaseAccount.Update.IWithConsistencyPolicy.WithSessionConsistency()
        {
            return this.WithSessionConsistency() as DatabaseAccount.Update.IWithOptionals;
        }

        /// <summary>
        /// The consistency policy for the DocumentDB account.
        /// </summary>
        /// <param name="maxStalenessPrefix">The max staleness prefix.</param>
        /// <param name="maxIntervalInSeconds">The max interval in seconds.</param>
        /// <return>The next stage of the definition.</return>
        DatabaseAccount.Update.IWithOptionals DatabaseAccount.Update.IWithConsistencyPolicy.WithBoundedStalenessConsistency(int maxStalenessPrefix, int maxIntervalInSeconds)
        {
            return this.WithBoundedStalenessConsistency(maxStalenessPrefix, maxIntervalInSeconds) as DatabaseAccount.Update.IWithOptionals;
        }

        /// <summary>
        /// The consistency policy for the DocumentDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        DatabaseAccount.Update.IWithOptionals DatabaseAccount.Update.IWithConsistencyPolicy.WithEventualConsistency()
        {
            return this.WithEventualConsistency() as DatabaseAccount.Update.IWithOptionals;
        }

        /// <summary>
        /// The consistency policy for the DocumentDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        DatabaseAccount.Update.IWithOptionals DatabaseAccount.Update.IWithConsistencyPolicy.WithStrongConsistency()
        {
            return this.WithStrongConsistency() as DatabaseAccount.Update.IWithOptionals;
        }

        /// <summary>
        /// The session consistency policy for the DocumentDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        DatabaseAccount.Definition.IWithWriteReplication DatabaseAccount.Definition.IWithConsistencyPolicy.WithSessionConsistency()
        {
            return this.WithSessionConsistency() as DatabaseAccount.Definition.IWithWriteReplication;
        }

        /// <summary>
        /// The bounded staleness consistency policy for the DocumentDB account.
        /// </summary>
        /// <param name="maxStalenessPrefix">The max staleness prefix.</param>
        /// <param name="maxIntervalInSeconds">The max interval in seconds.</param>
        /// <return>The next stage of the definition.</return>
        DatabaseAccount.Definition.IWithWriteReplication DatabaseAccount.Definition.IWithConsistencyPolicy.WithBoundedStalenessConsistency(int maxStalenessPrefix, int maxIntervalInSeconds)
        {
            return this.WithBoundedStalenessConsistency(maxStalenessPrefix, maxIntervalInSeconds) as DatabaseAccount.Definition.IWithWriteReplication;
        }

        /// <summary>
        /// The eventual consistency policy for the DocumentDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        DatabaseAccount.Definition.IWithWriteReplication DatabaseAccount.Definition.IWithConsistencyPolicy.WithEventualConsistency()
        {
            return this.WithEventualConsistency() as DatabaseAccount.Definition.IWithWriteReplication;
        }

        /// <summary>
        /// The strong consistency policy for the DocumentDB account.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        DatabaseAccount.Definition.IWithCreate DatabaseAccount.Definition.IWithConsistencyPolicy.WithStrongConsistency()
        {
            return this.WithStrongConsistency() as DatabaseAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// A georeplication location for the DocumentDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        DatabaseAccount.Definition.IWithCreate DatabaseAccount.Definition.IWithReadReplication.WithReadReplication(Region region)
        {
            return this.WithReadReplication(region) as DatabaseAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// DocumentDB Firewall Support: This value specifies the set of IP addresses or IP address ranges in CIDR
        /// form to be included as the allowed list of client IPs for a given database account. IP addresses/ranges
        /// must be comma separated and must not contain any spaces.
        /// </summary>
        /// <param name="ipRangeFilter">Specifies the set of IP addresses or IP address ranges.</param>
        /// <return>The next stage of the definition.</return>
        DatabaseAccount.Update.IWithOptionals DatabaseAccount.Update.IWithIpRangeFilter.WithIpRangeFilter(string ipRangeFilter)
        {
            return this.WithIpRangeFilter(ipRangeFilter) as DatabaseAccount.Update.IWithOptionals;
        }

        /// <summary>
        /// DocumentDB Firewall Support: This value specifies the set of IP addresses or IP address ranges in CIDR
        /// form to be included as the allowed list of client IPs for a given database account. IP addresses/ranges
        /// must be comma separated and must not contain any spaces.
        /// </summary>
        /// <param name="ipRangeFilter">Specifies the set of IP addresses or IP address ranges.</param>
        /// <return>The next stage of the definition.</return>
        DatabaseAccount.Definition.IWithCreate DatabaseAccount.Definition.IWithIpRangeFilter.WithIpRangeFilter(string ipRangeFilter)
        {
            return this.WithIpRangeFilter(ipRangeFilter) as DatabaseAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// A georeplication location for the DocumentDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        DatabaseAccount.Definition.IWithCreate DatabaseAccount.Definition.IWithWriteReplication.WithWriteReplication(Region region)
        {
            return this.WithWriteReplication(region) as DatabaseAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// A georeplication location for the DocumentDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        DatabaseAccount.Update.IWithReadLocations DatabaseAccount.Update.IWithReadLocations.WithoutReadReplication(Region region)
        {
            return this.WithoutReadReplication(region) as DatabaseAccount.Update.IWithReadLocations;
        }

        /// <summary>
        /// A georeplication location for the DocumentDB account.
        /// </summary>
        /// <param name="region">The region for the location.</param>
        /// <return>The next stage.</return>
        DatabaseAccount.Update.IWithReadLocations DatabaseAccount.Update.IWithReadLocations.WithReadReplication(Region region)
        {
            return this.WithReadReplication(region) as DatabaseAccount.Update.IWithReadLocations;
        }

        /// <return>The connection strings for the specified Azure DocumentDB database account.</return>
        async Task<Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner> Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.ListConnectionStringsAsync(CancellationToken cancellationToken)
        {
            return await this.ListConnectionStringsAsync(cancellationToken) as Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner;
        }

        /// <summary>
        /// Gets an array that contains the readable georeplication locations enabled for the DocumentDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.Location> Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.ReadableReplications
        {
            get
            {
                return this.ReadableReplications() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.Location>;
            }
        }

        /// <summary>
        /// Gets the default consistency level for the DocumentDB database account.
        /// </summary>
        Microsoft.Azure.Management.DocumentDB.Fluent.Models.DefaultConsistencyLevel Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.DefaultConsistencyLevel
        {
            get
            {
                return this.DefaultConsistencyLevel();
            }
        }

        /// <param name="keyKind">The key kind.</param>
        void Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.RegenerateKey(string keyKind)
        {
 
            this.RegenerateKey(keyKind);
        }

        /// <summary>
        /// Gets an array that contains the writable georeplication locations enabled for the DocumentDB account.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.Location> Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.WritableReplications
        {
            get
            {
                return this.WritableReplications() as System.Collections.Generic.IReadOnlyList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.Location>;
            }
        }

        /// <summary>
        /// Gets specifies the set of IP addresses or IP address ranges in CIDR form.
        /// </summary>
        string Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.IPRangeFilter
        {
            get
            {
                return this.IPRangeFilter();
            }
        }

        /// <summary>
        /// Gets the connection endpoint for the DocumentDB database account.
        /// </summary>
        string Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.DocumentEndpoint
        {
            get
            {
                return this.DocumentEndpoint();
            }
        }

        /// <param name="keyKind">The key kind.</param>
        /// <return>The ServiceResponse object if successful.</return>
        async Task Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.RegenerateKeyAsync(string keyKind, CancellationToken cancellationToken)
        {
 
            await this.RegenerateKeyAsync(keyKind, cancellationToken);
        }

        /// <summary>
        /// Gets the consistency policy for the DocumentDB database account.
        /// </summary>
        Microsoft.Azure.Management.DocumentDB.Fluent.Models.ConsistencyPolicy Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.ConsistencyPolicy
        {
            get
            {
                return this.ConsistencyPolicy() as Microsoft.Azure.Management.DocumentDB.Fluent.Models.ConsistencyPolicy;
            }
        }

        /// <return>The access keys for the specified Azure DocumentDB database account.</return>
        async Task<Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListKeysResultInner> Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.ListKeysAsync(CancellationToken cancellationToken)
        {
            return await this.ListKeysAsync(cancellationToken) as Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListKeysResultInner;
        }

        /// <summary>
        /// Gets the offer type for the DocumentDB database account.
        /// </summary>
        Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountOfferType Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.DatabaseAccountOfferType
        {
            get
            {
                return this.DatabaseAccountOfferType();
            }
        }

        /// <return>The access keys for the specified Azure DocumentDB database account.</return>
        Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListKeysResultInner Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.ListKeys()
        {
            return this.ListKeys() as Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListKeysResultInner;
        }

        /// <summary>
        /// Gets indicates the type of database account.
        /// </summary>
        string Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.Kind
        {
            get
            {
                return this.Kind() as string;
            }
        }

        /// <return>The connection strings for the specified Azure DocumentDB database account.</return>
        Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner Microsoft.Azure.Management.DocumentDB.Fluent.IDatabaseAccount.ListConnectionStrings()
        {
            return this.ListConnectionStrings() as Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner;
        }
    }
}