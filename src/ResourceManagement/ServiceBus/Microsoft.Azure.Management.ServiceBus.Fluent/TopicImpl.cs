// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Topic.Definition;
    using Topic.Update;
    using System.Collections.Generic;
    using System;
    using ResourceManager.Fluent.Core;
    using Management.Fluent.ServiceBus.Models;
    using ServiceBus.Fluent;
    using ResourceManager.Fluent.Core.ResourceActions;
    using Management.Fluent.ServiceBus;
    using System.Linq;

    /// <summary>
    /// Implementation for Topic.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uVG9waWNJbXBs
    internal partial class TopicImpl  :
        IndependentChildResourceImpl<ITopic,
            ServiceBusNamespaceImpl,
            TopicInner,
            TopicImpl,
            IHasId,
            Topic.Update.IUpdate,
            IServiceBusManager>,
        ITopic,
        IDefinition,
        IUpdate
    {
        private IList<ICreatable<Microsoft.Azure.Management.Servicebus.Fluent.ISubscription>> subscriptionsToCreate;
        private IList<ICreatable<Microsoft.Azure.Management.Servicebus.Fluent.ITopicAuthorizationRule>> rulesToCreate;
        private IList<string> subscriptionsToDelete;
        private IList<string> rulesToDelete;


        ///GENMHASH:192754CFA0B3938FEF9289BC13D648DC:E384D1DC0323D2359E002A2334C75FD1
        internal TopicImpl(string resourceGroupName, string namespaceName, string name, Region region, TopicInner inner, IServiceBusManager manager) : base(name, inner, manager)
        {
            this.WithExistingParentResource(resourceGroupName, namespaceName);
            InitChildrenOperationsCache();
            if (inner.Location == null) {
                inner.Location = region.ToString();
            }
        }

        public override ITopic Refresh()
        {
            var inner = this.GetInnerAsync(CancellationToken.None).Result;
            SetInner(inner);
            return this as ITopic;
        }

        ///GENMHASH:E3E1FE37EF46DBB99588AC2854B0739F:DA91B2CE4D0B6442C970C7DC794FF87E
        public TopicImpl WithoutDuplicateMessageDetection()
        {
            this.Inner.RequiresDuplicateDetection = false;
            return this;
        }

        ///GENMHASH:F74B853F92511C1700069E4495582CE4:0B055CD61F7ED6E20D6E56CA7F962F9E
        public TopicImpl WithoutSubscription(string name)
        {
            this.subscriptionsToDelete.Add(name);
            return this;
        }

        ///GENMHASH:6958189CF3C711BFBEA8C5E53C92A76C:DB4DF2C5582D0121F3649C325E97BC24
        public SubscriptionsImpl Subscriptions()
        {
            return new SubscriptionsImpl(this.ResourceGroupName,
                this.parentName,
                this.Name,
                this.Region,
                Manager);
        }

        ///GENMHASH:5AED064BCD1AFBB944FA447A0E36B00E:ABF31DE467BD8911FF3F028B5F889968
        public long MaxSizeInMB()
        {
            if (this.Inner.MaxSizeInMegabytes == null
                || !this.Inner.MaxSizeInMegabytes.HasValue)
            {
                return 0;
            }
            return this.Inner.MaxSizeInMegabytes.Value;
        }

        ///GENMHASH:396C89E2447B0E70C3C95439926DFC1A:E32C091119D6FB6D73E1D3322965866B
        public TopicImpl WithNewManageRule(string name)
        {
            Microsoft.Azure.Management.Servicebus.Fluent.ITopicAuthorizationRules rules = this.AuthorizationRules();
            this.rulesToCreate.Add(rules.Define(name).WithManagementEnabled());
            return this;
        }

        ///GENMHASH:CDD03FD7067A183B7EF67F8C76F3BEF8:A3F5367F58646B0F09B92648ACA6707C
        public TopicImpl WithSizeInMB(long sizeInMB)
        {
            this.Inner.MaxSizeInMegabytes = sizeInMB;
            return this;
        }

        ///GENMHASH:DA182C520E29E8DE59B3C983DCCA22F7:CE43118A731138A0FE2E95A594AA0B53
        public long TransferMessageCount()
        {
            if (this.Inner.CountDetails == null
                || this.Inner.CountDetails.TransferMessageCount == null)
            {
                return 0;
            }
            if (this.Inner.CountDetails.TransferMessageCount == null
                || !this.Inner.CountDetails.TransferMessageCount.HasValue)
            {
                return 0;
            }
            return this.Inner.CountDetails.TransferMessageCount.Value;
        }

        ///GENMHASH:8911278EAF12BC5F0E2B7B33F06FAE96:5D7AA55C0062C53E1EC569388F588AAD
        public TopicAuthorizationRulesImpl AuthorizationRules()
        {
            return new TopicAuthorizationRulesImpl(this.ResourceGroupName,
                this.parentName,
                this.Name,
                this.Region,
                Manager);
        }

        ///GENMHASH:3B2A360F977A78F31ACAD3AF5E995284:C832373561FBC59128220812809337CA
        public TimeSpan DefaultMessageTtlDuration()
        {
            if (this.Inner.DefaultMessageTimeToLive == null)
            {
                return TimeSpan.MaxValue;
            }
            return TimeSpan.Parse(this.Inner.DefaultMessageTimeToLive);
        }

        ///GENMHASH:56C6A82F1068747CBC7818C64CB0F0D6:43D29E0743B484841FAD53C707D7934E
        public bool IsBatchedOperationsEnabled()
        {
            if (this.Inner.EnableBatchedOperations == null || !this.Inner.EnableBatchedOperations.HasValue)
            {
                return false;
            }
            return this.Inner.EnableBatchedOperations.Value;
        }

        ///GENMHASH:AB43CAB847CF58797CAF155C313C9470:1F268B13CEEAC2DB0E277180DA5B2B23
        public TopicImpl WithoutMessageBatching()
        {
            this.Inner.EnableBatchedOperations = false;
            return this;
        }

        ///GENMHASH:DA1D6CD0EA6714E3CECEFA0F43674911:AE9119898216FD471C4241E3ADCCA164
        public TopicImpl WithPartitioning()
        {
            this.Inner.EnablePartitioning = true;
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:5296EC1C2BF632FB405AED151EB16468
        protected Task<TopicInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Manager.Inner.Topics
                .GetAsync(this.ResourceGroupName,
                    this.parentName,
                    this.Name, 
                    cancellationToken);
        }

        ///GENMHASH:6FB4FA11D202AAD778571470EBAA0B2E:5AD7D97214C222B06E2C12800013833A
        public TopicImpl WithoutPartitioning()
        {
            this.Inner.EnablePartitioning = false;
            return this;
        }

        ///GENMHASH:9157FD0110376DF53A83D529D7A1A4E1:385804CDAC891325C8D939BDF7A1D4FF
        public DateTime CreatedAt()
        {
            if (this.Inner.CreatedAt == null || !this.Inner.CreatedAt.HasValue)
            {
                return DateTime.MinValue;
            }
            return this.Inner.CreatedAt.Value;
        }

        ///GENMHASH:92D1FA2E75A52DFA9843DFD2C5154FB3:2625AB68CBC1A5B9EC885AA0FC482AD1
        public long DeleteOnIdleDurationInMinutes()
        {
            if (this.Inner.AutoDeleteOnIdle == null)
            {
                return 0;
            }
            return (long)TimeSpan.Parse(this.Inner.AutoDeleteOnIdle).TotalMinutes;
        }

        ///GENMHASH:41482A7907F5C3C16FDB1A8E3CEB3B9F:B5BA3212E181BC7B599A722AEFAC04B4
        public TopicImpl WithNewSendRule(string name)
        {
            Microsoft.Azure.Management.Servicebus.Fluent.ITopicAuthorizationRules rules = this.AuthorizationRules();
            this.rulesToCreate.Add(rules.Define(name).WithSendingEnabled());
            return this;
        }

        ///GENMHASH:2B55FDDC00E5EE76AD5C4B7D72CBA6F2:A53A238C2C751C27ED47B7783EACF7C6
        public TimeSpan DuplicateMessageDetectionHistoryDuration()
        {
            if (this.Inner.DuplicateDetectionHistoryTimeWindow == null)
            {
                return TimeSpan.MaxValue;
            }
            return TimeSpan.Parse(this.Inner.DuplicateDetectionHistoryTimeWindow);
        }

        ///GENMHASH:1D23568874BE06880E14E0FB7622F67C:BEFB1540B9E220B3B11C29E80D17FD1C
        private async Task SubmitChildrenOperationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.Subscriptions().CreateAsync(this.subscriptionsToCreate.ToArray());
            await this.Subscriptions().DeleteByNameAsync(this.subscriptionsToDelete);
            await this.AuthorizationRules().CreateAsync(this.rulesToCreate.ToArray());
            await this.AuthorizationRules().DeleteByNameAsync(this.rulesToDelete);
        }

        ///GENMHASH:FAD58514475FBDD5ADFE0AFE4F821FA2:0E94794501F4861D7BC8CF1B8EC0F1E1
        public DateTime UpdatedAt()
        {
            if (this.Inner.UpdatedAt == null || !this.Inner.UpdatedAt.HasValue)
            {
                return DateTime.MinValue;
            }
            return this.Inner.UpdatedAt.Value;
        }

        ///GENMHASH:C9DAE4BC5B8D28759976D191CF3F2F49:132DDA9E524ED4559BBB94874F4BABA8
        public TopicImpl WithNewSubscription(string name)
        {
            Microsoft.Azure.Management.Servicebus.Fluent.ISubscriptions subscriptions = this.Subscriptions();
            this.subscriptionsToCreate.Add(subscriptions.Define(name));
            return this;
        }

        ///GENMHASH:249BBB24345B234DAC1A9C813BCC0A9C:2B5FDDF105C0AC663E603D997CD2B2D3
        public TopicImpl WithDuplicateMessageDetection(TimeSpan duplicateDetectionHistoryDuration)
        {
            this.Inner.RequiresDuplicateDetection = true;
            this.Inner.DuplicateDetectionHistoryTimeWindow = duplicateDetectionHistoryDuration.ToString();
            return this;
        }

        ///GENMHASH:71F8DCDFAE47215AB503AAB2D182CEFF:9050343652C4A458FFF584C8C6AD8595
        public TopicImpl WithExpressMessage()
        {
            this.Inner.EnableExpress = true;
            return this;
        }

        ///GENMHASH:A310C258C80DD19DCDBD4A3629B90E97:46F48BEC269EE349B67CF8AC3F2043F8
        private void InitChildrenOperationsCache()
        {
            this.subscriptionsToCreate = new List<ICreatable<ISubscription>>();
            this.rulesToCreate = new List<ICreatable<ITopicAuthorizationRule>>();
            this.subscriptionsToDelete = new List<string>();
            this.rulesToDelete = new List<string>();
        }

        ///GENMHASH:58A51D8B1AAAD3EC7A897EBEE2B65040:D0E268D56BCA88C4DC556AFC1646D434
        public DateTime AccessedAt()
        {
            if (this.Inner.AccessedAt == null || !this.Inner.AccessedAt.HasValue)
            {
                return DateTime.MinValue;
            }
            return this.Inner.AccessedAt.Value;
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:645BAB1C541C407A2777CECFAAF22EBC
        protected async override Task<Microsoft.Azure.Management.Servicebus.Fluent.ITopic> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var inner = await this.Manager.Inner.Topics.CreateOrUpdateAsync(this.ResourceGroupName,
                    this.parentName,
                    this.Name,
                    this.Inner,
                    cancellationToken);
                SetInner(inner);
                await SubmitChildrenOperationsAsync();
            }
            finally
            {
                InitChildrenOperationsCache();
            }
            return this;
        }

        ///GENMHASH:839B23AF4843DCB6D8F2D31D8A415A72:AB2ABD4D61AAF3AA9963547A984E9961
        public int SubscriptionCount()
        {
            if (this.Inner.SubscriptionCount == null || !this.Inner.SubscriptionCount.HasValue) {
                return 0;
            }
            return this.Inner.SubscriptionCount.Value;
        }

        ///GENMHASH:E29C745E7C55BBEE309F5CA91C41558B:967A4BCB50FEDDE914F512D7480C00EA
        public long TransferDeadLetterMessageCount()
        {
            if (this.Inner.CountDetails == null
                || this.Inner.CountDetails.TransferDeadLetterMessageCount == null
                || !this.Inner.CountDetails.TransferDeadLetterMessageCount.HasValue)
            {
                return 0;
            }
            return this.Inner.CountDetails.TransferDeadLetterMessageCount.Value;
        }

        ///GENMHASH:F51B0A889F1B18982BB40AAE9B8FC6A6:1446E7FFFBEC1D4153FA0E9D00A844D8
        public TopicImpl WithMessageBatching()
        {
            this.Inner.EnableBatchedOperations = true;
            return this;
        }

        ///GENMHASH:46FECF62ED260BC112B80AF62C686306:58BE3B502F6AF20A9111654D441335CD
        public TopicImpl WithoutExpressMessage()
        {
            this.Inner.EnableExpress = false;
            return this;
        }

        ///GENMHASH:5C19E2E0366491AC1AA3A80F34BFE724:18528CCCCE9AAAF74AE88F12B21D7E8C
        public long DeadLetterMessageCount()
        {
            if (this.Inner.CountDetails == null
                || this.Inner.CountDetails.DeadLetterMessageCount == null
                 || !this.Inner.CountDetails.DeadLetterMessageCount.HasValue)
            {
                return 0;
            }
            return this.Inner.CountDetails.DeadLetterMessageCount.Value;
        }

        ///GENMHASH:7701B5E45C28C739B5610C34A2EF5559:5BCC0A5E68F721378DE24C6D3EE350E5
        public TopicImpl WithoutAuthorizationRule(string name)
        {
            this.rulesToDelete.Add(name);
            return this;
        }

        ///GENMHASH:A6F166713162A83EB57AC3FEE9320E5E:1BDC6CEAD4F0C9FCFC8F76E4B4AC3E25
        public bool IsDuplicateDetectionEnabled()
        {
            if (this.Inner.RequiresDuplicateDetection == null || !this.Inner.RequiresDuplicateDetection.HasValue)
            {
                return false;
            }
            return this.Inner.RequiresDuplicateDetection.Value;
        }

        ///GENMHASH:0E17D4BBCB9C51BDF488109DAB715495:97C4628AD1F2197E40346D447A471D3E
        public TopicImpl WithDeleteOnIdleDurationInMinutes(int durationInMinutes)
        {
            var timespan = new TimeSpan(0, durationInMinutes, 0);
            this.Inner.AutoDeleteOnIdle = timespan.ToString();
            return this;
        }

        ///GENMHASH:0561FFA5E77E3CD3DC689B375678281D:DB2A5D5695E84F43EE1DBB7540DBFCA9
        public TopicImpl WithDuplicateMessageDetectionHistoryDuration(TimeSpan duration)
        {
            this.Inner.DuplicateDetectionHistoryTimeWindow = duration.ToString();
            // Below shortcut cannot be used as 'WithRequiresDuplicateDetection' cannot be changed
            // once the topic is created.
            // return WithRequiresDuplicateDetection(duration);
            return this;
        }

        ///GENMHASH:F7EF7F108726A21429C99DF63DAAA800:DEED29230AA7A59FB44FFD56ED4F9EB6
        public TopicImpl WithDefaultMessageTTL(TimeSpan ttl)
        {
            this.Inner.DefaultMessageTimeToLive = ttl.ToString();
            return this;
        }

        ///GENMHASH:CF2CF801A7E4A9CAE7624D815E5EE4F4:E6E0C1CF73E25181AD5C0BE989C2DE15
        public TopicImpl WithNewListenRule(string name)
        {
            Microsoft.Azure.Management.Servicebus.Fluent.ITopicAuthorizationRules rules = this.AuthorizationRules();
            this.rulesToCreate.Add(rules.Define(name).WithListeningEnabled());
            return this;
        }

        ///GENMHASH:7899677A11C7269015972C6B36DED9D4:9A0F9624144BB515A8FECC59C26C0CEE
        public bool IsExpressEnabled()
        {
            if (this.Inner.EnableExpress == null || !this.Inner.EnableExpress.HasValue)
            {
                return false;
            }
            return this.Inner.EnableExpress.Value;
        }

        ///GENMHASH:5B5F9D3A99AE0D9481B1C610B9517A73:8D284CBACC724E3DD3BC26B1612DB78C
        public long ScheduledMessageCount()
        {
            if (this.Inner.CountDetails == null
                || this.Inner.CountDetails.ScheduledMessageCount == null)
            {
                return 0;
            }
            if (this.Inner.CountDetails.ScheduledMessageCount == null
                || !this.Inner.CountDetails.ScheduledMessageCount.HasValue)
            {
                return 0;
            }
            return this.Inner.CountDetails.ScheduledMessageCount.Value;
        }

        ///GENMHASH:D52241923D4C596EC463C0F8F469DB53:E791E23C8227DFEC860FF853D4BECAA0
        public bool IsPartitioningEnabled()
        {
            if (this.Inner.EnablePartitioning == null || !this.Inner.EnablePartitioning.HasValue)
            {
                return false;
            }
            return this.Inner.EnablePartitioning.Value;
        }

        ///GENMHASH:8470B94781A585DD3ED7D04B4FDC1FAE:2C67AF0D30BB71DD958AC49D4E8A4B75
        public long CurrentSizeInBytes()
        {
            if (this.Inner.SizeInBytes == null || !this.Inner.SizeInBytes.HasValue)
            {
                return 0;
            }
            return this.Inner.SizeInBytes.Value;
        }

        ///GENMHASH:DB317C55708995AFE3109A145FB49665:18B17F43DC47937B3611332D70BBD995
        public long ActiveMessageCount()
        {
            if (this.Inner.CountDetails == null
                || this.Inner.CountDetails.ScheduledMessageCount == null)
            {
                return 0;
            }
            if (this.Inner.CountDetails.ActiveMessageCount == null
                || !this.Inner.CountDetails.ActiveMessageCount.HasValue)
            {
                return 0;
            }
            return this.Inner.CountDetails.ActiveMessageCount.Value;
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:1ABA34EF946CBD0278FAD778141792B2
        public EntityStatus Status()
        {
            if (this.Inner.Status == null || !this.Inner.Status.HasValue)
            {
                return EntityStatus.Unknown;
            }
            return this.Inner.Status.Value;
        }
    }
}