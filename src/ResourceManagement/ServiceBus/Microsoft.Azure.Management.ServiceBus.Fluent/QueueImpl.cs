// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Queue.Definition;
    using Queue.Update;
    using System.Collections.Generic;
    using System;
    using Management.Fluent.ServiceBus.Models;
    using ServiceBus.Fluent;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ResourceActions;
    using Management.Fluent.ServiceBus;
    using System.Linq;

    /// <summary>
    /// Implementation for Queue.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uUXVldWVJbXBs
    internal partial class QueueImpl  :
        IndependentChildResourceImpl<IQueue,
            ServiceBusNamespaceImpl,
            QueueInner,
            QueueImpl,
            IHasId,
            Queue.Update.IUpdate,
            IServiceBusManager>,
        IQueue,
        IDefinition,
        IUpdate
    {
        private IList<ICreatable<Microsoft.Azure.Management.Servicebus.Fluent.IQueueAuthorizationRule>> rulesToCreate;
        private IList<string> rulesToDelete;

        ///GENMHASH:2E16A3C3DDA5707111D704BA0D4871AD:E384D1DC0323D2359E002A2334C75FD1
        internal QueueImpl(string resourceGroupName, 
            string namespaceName, 
            string name, 
            Region region, 
            QueueInner inner, 
            IServiceBusManager manager) : base(name, inner, manager)
        {
            this.WithExistingParentResource(resourceGroupName, namespaceName);
            InitChildrenOperationsCache();
            if (inner.Location == null)
            {
                inner.Location = region.ToString();
            }
        }

        public override IQueue Refresh()
        {
            var inner = this.GetInnerAsync(CancellationToken.None).Result;
            SetInner(inner);
            return this as IQueue;
        }

        ///GENMHASH:E3E1FE37EF46DBB99588AC2854B0739F:DA91B2CE4D0B6442C970C7DC794FF87E
        public QueueImpl WithoutDuplicateMessageDetection()
        {
            this.Inner.RequiresDuplicateDetection = false;
            return this;
        }

        ///GENMHASH:222157AD1451FFB4EFBFEFE6E60359F4:1D5E24AC19DB3A3576807E165DD6D14E
        public bool IsDeadLetteringEnabledForExpiredMessages()
        {
            if (this.Inner.DeadLetteringOnMessageExpiration == null || !this.Inner.DeadLetteringOnMessageExpiration.HasValue)
            {
                return false;
            }
            return this.Inner.DeadLetteringOnMessageExpiration.Value;
        }

        ///GENMHASH:1BAB6E8ABFA430BDAD850B867896CA84:C0642B099990F1E5F891942B11E04CF0
        public long MessageCount()
        {
            if (this.Inner.MessageCount == null || !this.Inner.MessageCount.HasValue)
            {
                return 0;
            }
            return this.Inner.MessageCount.Value;
        }

        ///GENMHASH:C1A58BF0014F5C84224E6BF6230B35E2:A032431A79B461F60FEB9055B4D7EB6F
        public QueueImpl WithSession()
        {
            this.Inner.RequiresSession = true;
            return this;
        }

        ///GENMHASH:5AED064BCD1AFBB944FA447A0E36B00E:ABF31DE467BD8911FF3F028B5F889968
        public long MaxSizeInMB()
        {
            if (this.Inner.MaxSizeInMegabytes == null || !this.Inner.MaxSizeInMegabytes.HasValue)
            {
                return 0;
            }
            return this.Inner.MaxSizeInMegabytes.Value;
        }

        ///GENMHASH:396C89E2447B0E70C3C95439926DFC1A:E32C091119D6FB6D73E1D3322965866B
        public QueueImpl WithNewManageRule(string name)
        {
            this.rulesToCreate.Add(this.AuthorizationRules().Define(name).WithManagementEnabled());
            return this;
        }

        ///GENMHASH:DA182C520E29E8DE59B3C983DCCA22F7:CE43118A731138A0FE2E95A594AA0B53
        public long TransferMessageCount()
        {
            if (this.Inner.CountDetails == null
                || this.Inner.CountDetails.TransferMessageCount == null) {
                return 0;
            }
            if (this.Inner.CountDetails.TransferMessageCount == null 
                || !this.Inner.CountDetails.TransferMessageCount.HasValue)
            {
                return 0;
            }
            return this.Inner.CountDetails.TransferMessageCount.Value;
        }

        ///GENMHASH:8911278EAF12BC5F0E2B7B33F06FAE96:6AFFC6820340BA72BF0C0369DDF29661
        public QueueAuthorizationRulesImpl AuthorizationRules()
        {
            return new QueueAuthorizationRulesImpl(this.ResourceGroupName,
                this.parentName,
                this.Name,
                this.Region,
                this.Manager);
        }

        ///GENMHASH:AB43CAB847CF58797CAF155C313C9470:1F268B13CEEAC2DB0E277180DA5B2B23
        public QueueImpl WithoutMessageBatching()
        {
            this.Inner.EnableBatchedOperations = false;
            return this;
        }

        ///GENMHASH:668CB5207E60D0286BC2EB234C18BE3A:03341220ADB1B1B9996EEC3BF0547D54
        public long LockDurationInSeconds()
        {
            if (this.Inner.LockDuration == null)
            {
                return 0;
            }
            return (long) TimeSpan.Parse(this.Inner.LockDuration).TotalSeconds;
        }

        ///GENMHASH:DA1D6CD0EA6714E3CECEFA0F43674911:AE9119898216FD471C4241E3ADCCA164
        public QueueImpl WithPartitioning()
        {
            this.Inner.EnablePartitioning = true;
            return this;
        }

        ///GENMHASH:7F20EE5668A545847B616FEDDD9D7A4B:1EE45DA97175AB941AF344765CA8BCEA
        public QueueImpl WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(int deliveryCount)
        {
            this.Inner.MaxDeliveryCount = deliveryCount;
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:338FF71B5ABADE33BE2440EC7B543A5A
        protected Task<QueueInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.Manager.Inner.Queues
                .GetAsync(this.ResourceGroupName,
                this.parentName,
                this.Name);
        }

        ///GENMHASH:6FB4FA11D202AAD778571470EBAA0B2E:5AD7D97214C222B06E2C12800013833A
        public QueueImpl WithoutPartitioning()
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
            if (this.Inner.AutoDeleteOnIdle == null) {
                return 0;
            }
            return (long) TimeSpan.Parse(this.Inner.AutoDeleteOnIdle).TotalMinutes;
        }

        ///GENMHASH:41482A7907F5C3C16FDB1A8E3CEB3B9F:B5BA3212E181BC7B599A722AEFAC04B4
        public QueueImpl WithNewSendRule(string name)
        {
            this.rulesToCreate.Add(this.AuthorizationRules().Define(name).WithSendingEnabled());
            return this;
        }

        ///GENMHASH:2B55FDDC00E5EE76AD5C4B7D72CBA6F2:A53A238C2C751C27ED47B7783EACF7C6
        public TimeSpan DuplicateMessageDetectionHistoryDuration()
        {
            if (this.Inner.DuplicateDetectionHistoryTimeWindow == null) {
                return TimeSpan.MaxValue;
            }
            return TimeSpan.Parse(this.Inner.DuplicateDetectionHistoryTimeWindow);
        }

        ///GENMHASH:1D23568874BE06880E14E0FB7622F67C:C668F81A8DA344C037D3349C4B8E22EA
        private async Task SubmitChildrenOperationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.AuthorizationRules().CreateAsync(this.rulesToCreate.ToArray());
            await this.AuthorizationRules().DeleteByNameAsync(this.rulesToDelete);
        }

        ///GENMHASH:E1A70C93622FE40F497284FABDDB605E:E5111569019FB6C2D9B4CECED7418140
        public int MaxDeliveryCountBeforeDeadLetteringMessage()
        {
            if (this.Inner.MaxDeliveryCount == null || !this.Inner.MaxDeliveryCount.HasValue)
            {
                return 0;
            }
            return this.Inner.MaxDeliveryCount.Value;
        }

        ///GENMHASH:42F51CC366F331E210DA0D280A607DC3:46766F6B1FAC81EB53D3B180E9E37C4E
        public QueueImpl WithoutExpiredMessageMovedToDeadLetterQueue()
        {
            this.Inner.DeadLetteringOnMessageExpiration = false;
            return this;
        }

        ///GENMHASH:FAD58514475FBDD5ADFE0AFE4F821FA2:0E94794501F4861D7BC8CF1B8EC0F1E1
        public DateTime UpdatedAt()
        {
            if (this.Inner.UpdatedAt == null || ! this.Inner.UpdatedAt.HasValue)
            {
                return DateTime.MinValue;
            }
            return this.Inner.UpdatedAt.Value;
        }

        ///GENMHASH:AB2668DDFA1990AA37745B2B65576B94:214A76C50356372A113C3FB025343090
        public QueueImpl WithExpiredMessageMovedToDeadLetterQueue()
        {
            this.Inner.DeadLetteringOnMessageExpiration = true;
            return this;
        }

        ///GENMHASH:71F8DCDFAE47215AB503AAB2D182CEFF:9050343652C4A458FFF584C8C6AD8595
        public QueueImpl WithExpressMessage()
        {
            this.Inner.EnableExpress = true;
            return this;
        }

        ///GENMHASH:A310C258C80DD19DCDBD4A3629B90E97:368B3D4A2853C9B98D02AD23843BECD6
        private void InitChildrenOperationsCache()
        {
            this.rulesToCreate = new List<ICreatable<IQueueAuthorizationRule>>();
            this.rulesToDelete = new List<string>();
        }

        ///GENMHASH:E29C745E7C55BBEE309F5CA91C41558B:967A4BCB50FEDDE914F512D7480C00EA
        public long TransferDeadLetterMessageCount()
        {
            if (this.Inner.CountDetails == null
                || this.Inner.CountDetails.TransferDeadLetterMessageCount == null
                || !this.Inner.CountDetails.TransferDeadLetterMessageCount.HasValue) {
                 return 0;
            }
            return this.Inner.CountDetails.TransferDeadLetterMessageCount.Value;
        }

        ///GENMHASH:46FECF62ED260BC112B80AF62C686306:58BE3B502F6AF20A9111654D441335CD
        public QueueImpl WithoutExpressMessage()
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
        public QueueImpl WithoutAuthorizationRule(string name)
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
        public QueueImpl WithDeleteOnIdleDurationInMinutes(int durationInMinutes)
        {
            var timespan = new TimeSpan(0, durationInMinutes, 0);
            this.Inner.AutoDeleteOnIdle = timespan.ToString();
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

        ///GENMHASH:8470B94781A585DD3ED7D04B4FDC1FAE:2C67AF0D30BB71DD958AC49D4E8A4B75
        public long CurrentSizeInBytes()
        {
            if (this.Inner.SizeInBytes == null || !this.Inner.SizeInBytes.HasValue)
            {
                return 0;
            }
            return this.Inner.SizeInBytes.Value;
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

        ///GENMHASH:0528195D56802C53049B175998349788:6A2B15DC582327EF91835262AE29E287
        public QueueImpl WithoutSession()
        {
            this.Inner.RequiresSession = false;
            return this;
        }

        ///GENMHASH:CDD03FD7067A183B7EF67F8C76F3BEF8:A3F5367F58646B0F09B92648ACA6707C
        public QueueImpl WithSizeInMB(long sizeInMB)
        {
            this.Inner.MaxSizeInMegabytes = sizeInMB;
            return this;
        }

        ///GENMHASH:936C3217C73954650336153ED9177264:05DAE515E479A1DF210DAF9CFC14667A
        public bool IsSessionEnabled()
        {
            if (this.Inner.RequiresSession == null || !this.Inner.RequiresSession.HasValue)
            {
                return false;
            }
            return this.Inner.RequiresSession.Value;
        }

        ///GENMHASH:3B2A360F977A78F31ACAD3AF5E995284:EC1F917ADA042B405846E5D213C2E58F
        public TimeSpan DefaultMessageTtlDuration()
        {
            if (this.Inner.DefaultMessageTimeToLive == null) {
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

        ///GENMHASH:249BBB24345B234DAC1A9C813BCC0A9C:2B5FDDF105C0AC663E603D997CD2B2D3
        public QueueImpl WithDuplicateMessageDetection(TimeSpan duplicateDetectionHistoryDuration)
        {
            this.Inner.RequiresDuplicateDetection = true;
            this.Inner.DuplicateDetectionHistoryTimeWindow = duplicateDetectionHistoryDuration.ToString();
            return this;
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

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:92202640FA5E86BA9A0B8B1004BEF8C7
        protected async override Task<Microsoft.Azure.Management.Servicebus.Fluent.IQueue> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var inner = await this.Manager.Inner.Queues.CreateOrUpdateAsync(this.ResourceGroupName,
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

        ///GENMHASH:F51B0A889F1B18982BB40AAE9B8FC6A6:1446E7FFFBEC1D4153FA0E9D00A844D8
        public QueueImpl WithMessageBatching()
        {
            this.Inner.EnableBatchedOperations = true;
            return this;
        }

        ///GENMHASH:0561FFA5E77E3CD3DC689B375678281D:2675CCF4E5F9AB96B396013D812518A2
        public QueueImpl WithDuplicateMessageDetectionHistoryDuration(TimeSpan duration)
        {
            return WithDuplicateMessageDetection(duration);
        }

        ///GENMHASH:F7EF7F108726A21429C99DF63DAAA800:DEED29230AA7A59FB44FFD56ED4F9EB6
        public QueueImpl WithDefaultMessageTTL(TimeSpan ttl)
        {
            this.Inner.DefaultMessageTimeToLive = ttl.ToString();
            return this;
        }

        ///GENMHASH:CF2CF801A7E4A9CAE7624D815E5EE4F4:E6E0C1CF73E25181AD5C0BE989C2DE15
        public QueueImpl WithNewListenRule(string name)
        {
            this.rulesToCreate.Add(this.AuthorizationRules().Define(name).WithListeningEnabled());
            return this;
        }

        ///GENMHASH:2D5CAF0AEEF0BD622FB87526DB686956:0132F721ED8F4FA288C2D0F05EAE18CA
        public QueueImpl WithMessageLockDurationInSeconds(int durationInSeconds)
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, durationInSeconds);
            this.Inner.LockDuration = timeSpan.ToString();
            return this;
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
    }
}