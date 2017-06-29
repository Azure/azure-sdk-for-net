// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.DocumentDB.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.DocumentDB.Fluent.DocumentDBAccount.Definition;
    using Microsoft.Azure.Management.DocumentDB.Fluent.DocumentDBAccount.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;
    using ResourceManager.Fluent.Core.Resource.Update;
    using System;

    /// <summary>
    /// The implementation for DatabaseAccount.
    /// </summary>
    public partial class DocumentDBAccountImpl :
        GroupableResource<
            IDocumentDBAccount,
            Models.DatabaseAccountInner,
            DocumentDBAccountImpl,
            IDocumentDBManager,
            IWithGroup,
            IWithKind,
            IWithCreate,
            IUpdate>,
        IDocumentDBAccount,
        IDefinition,
        IUpdate
    {
        private IList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.FailoverPolicyInner> failoverPolicies;
        private bool hasFailoverPolicyChanges;
        private const int maxDelayDueToMissingFailovers = 5000 * 12 * 10;

        public DocumentDBAccountImpl WithReadReplication(Region region)
        {
            this.EnsureFailoverIsInitialized();
            Models.FailoverPolicyInner failoverPolicyInner = new Models.FailoverPolicyInner();
            failoverPolicyInner.LocationName = region.Name;
            failoverPolicyInner.FailoverPriority = this.failoverPolicies.Count;
            this.hasFailoverPolicyChanges = true;
            this.failoverPolicies.Add(failoverPolicyInner);
            return this;
        }

        private async Task<Microsoft.Azure.Management.DocumentDB.Fluent.IDocumentDBAccount> DoDatabaseUpdateCreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            DocumentDBAccountImpl self = this;
            int currentDelayDueToMissingFailovers = 0;
            Models.DatabaseAccountCreateUpdateParametersInner createUpdateParametersInner =
                this.CreateUpdateParametersInner(this.Inner);
            await this.Manager.Inner.DatabaseAccounts.CreateOrUpdateAsync(
                ResourceGroupName, Name, createUpdateParametersInner);
            this.failoverPolicies.Clear();
            this.hasFailoverPolicyChanges = false;
            bool done = false;
            IDocumentDBAccount databaseAccount = null;
            while (!done)
            {
                await SdkContext.DelayProvider.DelayAsync(5000, cancellationToken);
                databaseAccount = await this.Manager.DocumentDBAccounts.GetByResourceGroupAsync(
                    ResourceGroupName, Name);

                if (maxDelayDueToMissingFailovers > currentDelayDueToMissingFailovers && 
                    (databaseAccount.Id == null
                    || databaseAccount.Id.Length == 0
                    || createUpdateParametersInner.Location.Length >
                        databaseAccount.Inner.FailoverPolicies.Count))
                {
                    currentDelayDueToMissingFailovers += 5000;
                    continue;
                }

                if (this.IsProvisioningStateFinal(databaseAccount.Inner.ProvisioningState))
                {
                    done = true;
                    foreach (Models.Location location in databaseAccount.ReadableReplications)
                    {
                        if (!this.IsProvisioningStateFinal(location.ProvisioningState))
                        {
                            done = false;
                            break;
                        }
                    }
                }
            }

            this.SetInner(databaseAccount.Inner);
            this.initializeFailover();
            return databaseAccount;
        }

        private Models.DatabaseAccountCreateUpdateParametersInner CreateUpdateParametersInner(Models.DatabaseAccountInner inner)
        {
            this.EnsureFailoverIsInitialized();
            Models.DatabaseAccountCreateUpdateParametersInner createUpdateParametersInner =
            new Models.DatabaseAccountCreateUpdateParametersInner();
            createUpdateParametersInner.Location = this.RegionName.ToLower();
            createUpdateParametersInner.ConsistencyPolicy = inner.ConsistencyPolicy;
            createUpdateParametersInner.IpRangeFilter = inner.IpRangeFilter;
            createUpdateParametersInner.Kind = inner.Kind;
            createUpdateParametersInner.Tags = inner.Tags;
            this.AddLocationsForCreateUpdateParameters(createUpdateParametersInner, this.failoverPolicies);
            return createUpdateParametersInner;
        }

        private bool IsProvisioningStateFinal(string state)
        {
            switch (state.ToLower())
            {
                case "succeeded":
                case "canceled":
                case "failed":
                    return true;
                default:
                    return false;
            }
        }

        public IReadOnlyList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.Location> WritableReplications()
        {
            return this.Inner.WriteLocations as IReadOnlyList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.Location>;
        }

        public async Task<Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListKeysResultInner> ListKeysAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.DatabaseAccounts.ListKeysAsync(this.ResourceGroupName,
                this.Name);
        }

        public override async Task<Microsoft.Azure.Management.DocumentDB.Fluent.IDocumentDBAccount> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.DoDatabaseUpdateCreateAsync(cancellationToken);
        }

        public Models.DatabaseAccountListKeysResultInner ListKeys()
        {
            return this.ListKeysAsync().GetAwaiter().GetResult();
        }

        public string IPRangeFilter()
        {
            return this.Inner.IpRangeFilter;
        }

        public string Kind()
        {
            return this.Inner.Kind;
        }

        private void EnsureFailoverIsInitialized()
        {
            if (this.IsInCreateMode) {
                return;
            }

            if (!this.hasFailoverPolicyChanges) {
                this.initializeFailover();
            }
        }

        private void initializeFailover()
        {
            this.failoverPolicies.Clear();
            Models.FailoverPolicyInner[] policyInners = new Models.FailoverPolicyInner[this.Inner.FailoverPolicies.Count];
            for (var i = 0; i < policyInners.Length; i++)
            {
                policyInners[i] = this.Inner.FailoverPolicies[i];
            }

            Array.Sort(policyInners, (o1, o2) =>
            {
                return o1.FailoverPriority.GetValueOrDefault().CompareTo(o2.FailoverPriority.GetValueOrDefault());
            });

            for (int i = 0; i < policyInners.Length; i++)
            {
                this.failoverPolicies.Add(policyInners[i]);
            }

            this.hasFailoverPolicyChanges = true;
        }

        public DocumentDBAccountImpl WithStrongConsistency()
        {
            this.SetConsistencyPolicy(Models.DefaultConsistencyLevel.Strong, 0, 0);
            return this;
        }

        private void SetConsistencyPolicy(Models.DefaultConsistencyLevel level, int maxIntervalInSeconds, long maxStalenessPrefix)
        {
            var policy = new Models.ConsistencyPolicy();
            policy.DefaultConsistencyLevel = level;
            if (level == Models.DefaultConsistencyLevel.BoundedStaleness)
            {
                policy.MaxIntervalInSeconds = maxIntervalInSeconds;
                policy.MaxStalenessPrefix = (long)maxStalenessPrefix;
            }

            this.Inner.ConsistencyPolicy = policy;
        }

        public async Task<Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountListConnectionStringsResultInner> ListConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.DatabaseAccounts.ListConnectionStringsAsync(this.ResourceGroupName,
                this.Name);
        }

        public async Task RegenerateKeyAsync(string keyKind, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Manager.Inner.DatabaseAccounts.RegenerateKeyAsync(this.ResourceGroupName, this.Name, keyKind);
        }

        public DocumentDBAccountImpl WithKind(string kind)
        {
            this.Inner.Kind = kind;
            return this;
        }

        public DocumentDBAccountImpl WithEventualConsistency()
        {
            this.SetConsistencyPolicy(Models.DefaultConsistencyLevel.Eventual, 0, 0);
            return this;
        }

        public DocumentDBAccountImpl WithBoundedStalenessConsistency(int maxStalenessPrefix, int maxIntervalInSeconds)
        {
            this.SetConsistencyPolicy(Models.DefaultConsistencyLevel.BoundedStaleness,
                maxStalenessPrefix,
                maxIntervalInSeconds);
            return this;
        }

        public Models.DefaultConsistencyLevel DefaultConsistencyLevel()
        {
            if (this.Inner.ConsistencyPolicy == null) {
                throw new Exception("Consistency policy is missing!");
            }

            return this.Inner.ConsistencyPolicy.DefaultConsistencyLevel;
        }

        public Models.DatabaseAccountListConnectionStringsResultInner ListConnectionStrings()
        {
            return this.ListConnectionStringsAsync().GetAwaiter().GetResult();
        }

        internal DocumentDBAccountImpl(string name, Models.DatabaseAccountInner innerObject, IDocumentDBManager manager) :
            base(name, innerObject, manager)
        {
            this.failoverPolicies = new List<Models.FailoverPolicyInner>();
        }

        public Models.ConsistencyPolicy ConsistencyPolicy()
        {
            return this.Inner.ConsistencyPolicy;
        }

        public DocumentDBAccountImpl WithoutReadReplication(Region region)
        {
            this.EnsureFailoverIsInitialized();
            for (int i = 1; i < this.failoverPolicies.Count; i++)
            {
                if (this.failoverPolicies[i].LocationName != null)
                {
                    string locName = this.failoverPolicies[i].LocationName.Replace(" ", "").ToLower();
                    if (locName.Equals(region.Name))
                    {
                        this.failoverPolicies.RemoveAt(i);
                    }
                }
            }

            return this;
        }

        public DocumentDBAccountImpl WithSessionConsistency()
        {
            this.SetConsistencyPolicy(Models.DefaultConsistencyLevel.Session, 0, 0);
            return this;
        }

        private void AddLocationsForCreateUpdateParameters(Models.DatabaseAccountCreateUpdateParametersInner createUpdateParametersInner, IList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.FailoverPolicyInner> failoverPolicies)
        {
            List<Models.Location> locations = new List<Models.Location>();
            for (int i = 0; i < failoverPolicies.Count; i++) {
                Models.FailoverPolicyInner policyInner = failoverPolicies[i];
                Models.Location location = new Models.Location();
                location.FailoverPriority = i;
                location.LocationName = policyInner.LocationName;
                locations.Add(location);
            }

            if (locations.Count > 0) {
                createUpdateParametersInner.Locations = locations;
            }
        }

        public DocumentDBAccountImpl WithIpRangeFilter(string ipRangeFilter)
        {
            this.Inner.IpRangeFilter = ipRangeFilter;
            return this;
        }

        public DocumentDBAccountImpl WithWriteReplication(Region region)
        {
            Models.FailoverPolicyInner failoverPolicyInner = new Models.FailoverPolicyInner();
            failoverPolicyInner.LocationName = region.Name;
            this.hasFailoverPolicyChanges = true;
            this.failoverPolicies.Add(failoverPolicyInner);
            return this;
        }

        public string DocumentEndpoint()
        {
            return this.Inner.DocumentEndpoint;
        }

        public IReadOnlyList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.Location> ReadableReplications()
        {
            return this.Inner.ReadLocations as IReadOnlyList<Microsoft.Azure.Management.DocumentDB.Fluent.Models.Location>;
        }

        protected override async Task<Microsoft.Azure.Management.DocumentDB.Fluent.Models.DatabaseAccountInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.DatabaseAccounts.GetAsync(this.ResourceGroupName, this.Name);
        }

        public Models.DatabaseAccountOfferType DatabaseAccountOfferType()
        {
            return this.Inner.DatabaseAccountOfferType.GetValueOrDefault();
        }

        public void RegenerateKey(string keyKind)
        {
            this.RegenerateKeyAsync(keyKind).GetAwaiter().GetResult();

        }

        private static string FixDBName(string name)
        {
            return name.ToLower();
        }

        IWithOptionals IUpdateWithTags<IWithOptionals>.WithTags(IDictionary<string, string> tags)
        {
            this.WithTags(tags);
            return this;
        }

        IWithOptionals IUpdateWithTags<IWithOptionals>.WithTag(string key, string value)
        {
            this.WithTag(key, value);
            return this;
        }

        IWithOptionals IUpdateWithTags<IWithOptionals>.WithoutTag(string key)
        {
            this.WithoutTag(key);
            return this;
        }
    }
}