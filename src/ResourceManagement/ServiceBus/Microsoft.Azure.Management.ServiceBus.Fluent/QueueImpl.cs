// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Queue.Definition;
    using Queue.Update;
    using System.Collections.Generic;
    using System;
    using Org.Joda.Time;

    /// <summary>
    /// Implementation for Queue.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uUXVldWVJbXBs
    internal partial class QueueImpl  :
        IndependentChildResourceImpl<Microsoft.Azure.Management.Servicebus.Fluent.IQueue,Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusNamespaceImpl,Microsoft.Azure.Management.Servicebus.Fluent.QueueInner,Microsoft.Azure.Management.Servicebus.Fluent.QueueImpl,Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusManager>,
        IQueue,
        IDefinition,
        IUpdate
    {
        private IList<Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.Servicebus.Fluent.IQueueAuthorizationRule>> rulesToCreate;
        private IList<string> rulesToDelete;
        ///GENMHASH:E3E1FE37EF46DBB99588AC2854B0739F:DA91B2CE4D0B6442C970C7DC794FF87E
        public QueueImpl WithoutDuplicateMessageDetection()
        {
            //$ this.Inner.WithRequiresDuplicateDetection(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:222157AD1451FFB4EFBFEFE6E60359F4:1D5E24AC19DB3A3576807E165DD6D14E
        public bool IsDeadLetteringEnabledForExpiredMessages()
        {
            //$ return Utils.ToPrimitiveBoolean(this.Inner.DeadLetteringOnMessageExpiration());

            return false;
        }

        ///GENMHASH:1BAB6E8ABFA430BDAD850B867896CA84:C0642B099990F1E5F891942B11E04CF0
        public long MessageCount()
        {
            //$ return Utils.ToPrimitiveLong(this.Inner.MessageCount());

            return 0;
        }

        ///GENMHASH:C1A58BF0014F5C84224E6BF6230B35E2:A032431A79B461F60FEB9055B4D7EB6F
        public QueueImpl WithSession()
        {
            //$ this.Inner.WithRequiresSession(true);
            //$ return this;

            return this;
        }

        ///GENMHASH:5AED064BCD1AFBB944FA447A0E36B00E:ABF31DE467BD8911FF3F028B5F889968
        public long MaxSizeInMB()
        {
            //$ return Utils.ToPrimitiveLong(this.Inner.MaxSizeInMegabytes());

            return 0;
        }

        ///GENMHASH:396C89E2447B0E70C3C95439926DFC1A:E32C091119D6FB6D73E1D3322965866B
        public QueueImpl WithNewManageRule(string name)
        {
            //$ this.rulesToCreate.Add(this.AuthorizationRules().Define(name).WithManagementEnabled());
            //$ return this;

            return this;
        }

        ///GENMHASH:DA182C520E29E8DE59B3C983DCCA22F7:CE43118A731138A0FE2E95A594AA0B53
        public long TransferMessageCount()
        {
            //$ if (this.Inner.CountDetails() == null
            //$ || this.Inner.CountDetails().TransferMessageCount() == null) {
            //$ return 0;
            //$ }
            //$ return Utils.ToPrimitiveLong(this.Inner.CountDetails().TransferMessageCount());

            return 0;
        }

        ///GENMHASH:8911278EAF12BC5F0E2B7B33F06FAE96:6AFFC6820340BA72BF0C0369DDF29661
        public QueueAuthorizationRulesImpl AuthorizationRules()
        {
            //$ return new QueueAuthorizationRulesImpl(this.ResourceGroupName(),
            //$ this.ParentName,
            //$ this.Name(),
            //$ this.Region(),
            //$ manager());

            return null;
        }

        ///GENMHASH:AB43CAB847CF58797CAF155C313C9470:1F268B13CEEAC2DB0E277180DA5B2B23
        public QueueImpl WithoutMessageBatching()
        {
            //$ this.Inner.WithEnableBatchedOperations(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:668CB5207E60D0286BC2EB234C18BE3A:03341220ADB1B1B9996EEC3BF0547D54
        public long LockDurationInSeconds()
        {
            //$ if (this.Inner.LockDuration() == null) {
            //$ return 0;
            //$ }
            //$ TimeSpan timeSpan = TimeSpan.Parse(this.Inner.LockDuration());
            //$ return (long) timeSpan.TotalSeconds();

            return 0;
        }

        ///GENMHASH:DA1D6CD0EA6714E3CECEFA0F43674911:AE9119898216FD471C4241E3ADCCA164
        public QueueImpl WithPartitioning()
        {
            //$ this.Inner.WithEnablePartitioning(true);
            //$ return this;

            return this;
        }

        ///GENMHASH:7F20EE5668A545847B616FEDDD9D7A4B:1EE45DA97175AB941AF344765CA8BCEA
        public QueueImpl WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(int deliveryCount)
        {
            //$ this.Inner.WithMaxDeliveryCount(deliveryCount);
            //$ return this;

            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:338FF71B5ABADE33BE2440EC7B543A5A
        protected async Task<Microsoft.Azure.Management.Servicebus.Fluent.QueueInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Manager().Inner.Queues()
            //$ .GetAsync(this.ResourceGroupName(),
            //$ this.ParentName,
            //$ this.Name());

            return null;
        }

        ///GENMHASH:2E16A3C3DDA5707111D704BA0D4871AD:E384D1DC0323D2359E002A2334C75FD1
        internal  QueueImpl(string resourceGroupName, string namespaceName, string name, Region region, QueueInner inner, ServiceBusManager manager)
        {
            //$ {
            //$ super(name, inner, manager);
            //$ this.WithExistingParentResource(resourceGroupName, namespaceName);
            //$ initChildrenOperationsCache();
            //$ if (inner.Location() == null) {
            //$ inner.WithLocation(region.ToString());
            //$ }
            //$ }

        }

        ///GENMHASH:6FB4FA11D202AAD778571470EBAA0B2E:5AD7D97214C222B06E2C12800013833A
        public QueueImpl WithoutPartitioning()
        {
            //$ this.Inner.WithEnablePartitioning(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:9157FD0110376DF53A83D529D7A1A4E1:385804CDAC891325C8D939BDF7A1D4FF
        public DateTime CreatedAt()
        {
            //$ return this.Inner.CreatedAt();

            return DateTime.Now;
        }

        ///GENMHASH:92D1FA2E75A52DFA9843DFD2C5154FB3:2625AB68CBC1A5B9EC885AA0FC482AD1
        public long DeleteOnIdleDurationInMinutes()
        {
            //$ if (this.Inner.AutoDeleteOnIdle() == null) {
            //$ return 0;
            //$ }
            //$ TimeSpan timeSpan = TimeSpan.Parse(this.Inner.AutoDeleteOnIdle());
            //$ return (long) timeSpan.TotalMinutes();

            return 0;
        }

        ///GENMHASH:41482A7907F5C3C16FDB1A8E3CEB3B9F:B5BA3212E181BC7B599A722AEFAC04B4
        public QueueImpl WithNewSendRule(string name)
        {
            //$ this.rulesToCreate.Add(this.AuthorizationRules().Define(name).WithSendingEnabled());
            //$ return this;

            return this;
        }

        ///GENMHASH:2B55FDDC00E5EE76AD5C4B7D72CBA6F2:A53A238C2C751C27ED47B7783EACF7C6
        public Period DuplicateMessageDetectionHistoryDuration()
        {
            //$ if (this.Inner.DuplicateDetectionHistoryTimeWindow() == null) {
            //$ return null;
            //$ }
            //$ TimeSpan timeSpan = TimeSpan.Parse(this.Inner.DuplicateDetectionHistoryTimeWindow());
            //$ return new Period()
            //$ .WithDays(timeSpan.Days())
            //$ .WithHours(timeSpan.Hours())
            //$ .WithMinutes(timeSpan.Minutes())
            //$ .WithSeconds(timeSpan.Seconds())
            //$ .WithMillis(timeSpan.Milliseconds());

            return null;
        }

        ///GENMHASH:1D23568874BE06880E14E0FB7622F67C:C668F81A8DA344C037D3349C4B8E22EA
        private async Completable SubmitChildrenOperationsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ Observable<?> rulesCreateStream = Observable.Empty();
            //$ if (this.rulesToCreate.Size() > 0) {
            //$ rulesCreateStream = this.AuthorizationRules().CreateAsync(this.rulesToCreate);
            //$ }
            //$ Observable<?> rulesDeleteStream = Observable.Empty();
            //$ if (this.rulesToDelete.Size() > 0) {
            //$ rulesDeleteStream = this.AuthorizationRules().DeleteByNameAsync(this.rulesToDelete);
            //$ }
            //$ return Completable.MergeDelayError(rulesCreateStream.ToCompletable(),
            //$ rulesDeleteStream.ToCompletable());
            //$ }

            return null;
        }

        ///GENMHASH:E1A70C93622FE40F497284FABDDB605E:E5111569019FB6C2D9B4CECED7418140
        public int MaxDeliveryCountBeforeDeadLetteringMessage()
        {
            //$ return Utils.ToPrimitiveInt(this.Inner.MaxDeliveryCount());

            return 0;
        }

        ///GENMHASH:42F51CC366F331E210DA0D280A607DC3:46766F6B1FAC81EB53D3B180E9E37C4E
        public QueueImpl WithoutExpiredMessageMovedToDeadLetterQueue()
        {
            //$ this.Inner.WithDeadLetteringOnMessageExpiration(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:FAD58514475FBDD5ADFE0AFE4F821FA2:0E94794501F4861D7BC8CF1B8EC0F1E1
        public DateTime UpdatedAt()
        {
            //$ return this.Inner.UpdatedAt();

            return DateTime.Now;
        }

        ///GENMHASH:AB2668DDFA1990AA37745B2B65576B94:214A76C50356372A113C3FB025343090
        public QueueImpl WithExpiredMessageMovedToDeadLetterQueue()
        {
            //$ this.Inner.WithDeadLetteringOnMessageExpiration(true);
            //$ return this;

            return this;
        }

        ///GENMHASH:71F8DCDFAE47215AB503AAB2D182CEFF:9050343652C4A458FFF584C8C6AD8595
        public QueueImpl WithExpressMessage()
        {
            //$ this.Inner.WithEnableExpress(true);
            //$ return this;

            return this;
        }

        ///GENMHASH:A310C258C80DD19DCDBD4A3629B90E97:368B3D4A2853C9B98D02AD23843BECD6
        private void InitChildrenOperationsCache()
        {
            //$ this.rulesToCreate = new ArrayList<>();
            //$ this.rulesToDelete = new ArrayList<>();
            //$ }

        }

        ///GENMHASH:E29C745E7C55BBEE309F5CA91C41558B:967A4BCB50FEDDE914F512D7480C00EA
        public long TransferDeadLetterMessageCount()
        {
            //$ if (this.Inner.CountDetails() == null
            //$ || this.Inner.CountDetails().TransferDeadLetterMessageCount() == null) {
            //$ return 0;
            //$ }
            //$ return Utils.ToPrimitiveLong(this.Inner.CountDetails().TransferDeadLetterMessageCount());

            return 0;
        }

        ///GENMHASH:46FECF62ED260BC112B80AF62C686306:58BE3B502F6AF20A9111654D441335CD
        public QueueImpl WithoutExpressMessage()
        {
            //$ this.Inner.WithEnableExpress(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:5C19E2E0366491AC1AA3A80F34BFE724:18528CCCCE9AAAF74AE88F12B21D7E8C
        public long DeadLetterMessageCount()
        {
            //$ if (this.Inner.CountDetails() == null
            //$ || this.Inner.CountDetails().DeadLetterMessageCount() == null) {
            //$ return 0;
            //$ }
            //$ return Utils.ToPrimitiveLong(this.Inner.CountDetails().DeadLetterMessageCount());

            return 0;
        }

        ///GENMHASH:7701B5E45C28C739B5610C34A2EF5559:5BCC0A5E68F721378DE24C6D3EE350E5
        public QueueImpl WithoutAuthorizationRule(string name)
        {
            //$ this.rulesToDelete.Add(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:A6F166713162A83EB57AC3FEE9320E5E:1BDC6CEAD4F0C9FCFC8F76E4B4AC3E25
        public bool IsDuplicateDetectionEnabled()
        {
            //$ return Utils.ToPrimitiveBoolean(this.Inner.RequiresDuplicateDetection());

            return false;
        }

        ///GENMHASH:0E17D4BBCB9C51BDF488109DAB715495:97C4628AD1F2197E40346D447A471D3E
        public QueueImpl WithDeleteOnIdleDurationInMinutes(int durationInMinutes)
        {
            //$ TimeSpan timeSpan = new TimeSpan().WithMinutes(durationInMinutes);
            //$ this.Inner.WithAutoDeleteOnIdle(timeSpan.ToString());
            //$ return this;

            return this;
        }

        ///GENMHASH:7899677A11C7269015972C6B36DED9D4:9A0F9624144BB515A8FECC59C26C0CEE
        public bool IsExpressEnabled()
        {
            //$ return Utils.ToPrimitiveBoolean(this.Inner.EnableExpress());

            return false;
        }

        ///GENMHASH:8470B94781A585DD3ED7D04B4FDC1FAE:2C67AF0D30BB71DD958AC49D4E8A4B75
        public long CurrentSizeInBytes()
        {
            //$ return Utils.ToPrimitiveLong(this.Inner.SizeInBytes());

            return 0;
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:1ABA34EF946CBD0278FAD778141792B2
        public EntityStatus Status()
        {
            //$ return this.Inner.Status();

            return EntityStatus.ACTIVE;
        }

        ///GENMHASH:0528195D56802C53049B175998349788:6A2B15DC582327EF91835262AE29E287
        public QueueImpl WithoutSession()
        {
            //$ this.Inner.WithRequiresSession(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:CDD03FD7067A183B7EF67F8C76F3BEF8:A3F5367F58646B0F09B92648ACA6707C
        public QueueImpl WithSizeInMB(long sizeInMB)
        {
            //$ this.Inner.WithMaxSizeInMegabytes(sizeInMB);
            //$ return this;

            return this;
        }

        ///GENMHASH:936C3217C73954650336153ED9177264:05DAE515E479A1DF210DAF9CFC14667A
        public bool IsSessionEnabled()
        {
            //$ return Utils.ToPrimitiveBoolean(this.Inner.RequiresSession());

            return false;
        }

        ///GENMHASH:3B2A360F977A78F31ACAD3AF5E995284:EC1F917ADA042B405846E5D213C2E58F
        public Period DefaultMessageTtlDuration()
        {
            //$ if (this.Inner.DefaultMessageTimeToLive() == null) {
            //$ return null;
            //$ }
            //$ TimeSpan timeSpan = TimeSpan.Parse(this.Inner.DefaultMessageTimeToLive());
            //$ return new Period()
            //$ .WithDays(timeSpan.Days())
            //$ .WithHours(timeSpan.Hours())
            //$ .WithSeconds(timeSpan.Seconds())
            //$ .WithMinutes(timeSpan.Minutes())
            //$ .WithMillis(timeSpan.Milliseconds());

            return null;
        }

        ///GENMHASH:56C6A82F1068747CBC7818C64CB0F0D6:43D29E0743B484841FAD53C707D7934E
        public bool IsBatchedOperationsEnabled()
        {
            //$ return Utils.ToPrimitiveBoolean(this.Inner.EnableBatchedOperations());

            return false;
        }

        ///GENMHASH:249BBB24345B234DAC1A9C813BCC0A9C:2B5FDDF105C0AC663E603D997CD2B2D3
        public QueueImpl WithDuplicateMessageDetection(TimeSpan duplicateDetectionHistoryDuration)
        {
            //$ this.Inner.WithRequiresDuplicateDetection(true);
            //$ this.Inner.WithDuplicateDetectionHistoryTimeWindow(TimeSpan
            //$ .FromPeriod(duplicateDetectionHistoryDuration)
            //$ .ToString());
            //$ return this;

            return this;
        }

        ///GENMHASH:58A51D8B1AAAD3EC7A897EBEE2B65040:D0E268D56BCA88C4DC556AFC1646D434
        public DateTime AccessedAt()
        {
            //$ return this.Inner.AccessedAt();

            return DateTime.Now;
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:92202640FA5E86BA9A0B8B1004BEF8C7
        protected async Task<Microsoft.Azure.Management.Servicebus.Fluent.IQueue> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ Completable createQueueCompletable = this.Manager().Inner.Queues()
            //$ .CreateOrUpdateAsync(this.ResourceGroupName(),
            //$ this.ParentName,
            //$ this.Name(),
            //$ this.Inner)
            //$ .Map(new Func1<QueueInner, QueueInner>() {
            //$ @Override
            //$ public QueueInner call(QueueInner inner) {
            //$ setInner(inner);
            //$ return inner;
            //$ }
            //$ }).ToCompletable();
            //$ Completable childrenOperationsCompletable = submitChildrenOperationsAsync();
            //$ Queue self = this;
            //$ return Completable.Concat(createQueueCompletable, childrenOperationsCompletable)
            //$ .DoOnTerminate(new Action0() {
            //$ @Override
            //$ public void call() {
            //$ initChildrenOperationsCache();
            //$ }
            //$ })
            //$ .AndThen(Observable.Just(self));

            return null;
        }

        ///GENMHASH:F51B0A889F1B18982BB40AAE9B8FC6A6:1446E7FFFBEC1D4153FA0E9D00A844D8
        public QueueImpl WithMessageBatching()
        {
            //$ this.Inner.WithEnableBatchedOperations(true);
            //$ return this;

            return this;
        }

        ///GENMHASH:0561FFA5E77E3CD3DC689B375678281D:2675CCF4E5F9AB96B396013D812518A2
        public QueueImpl WithDuplicateMessageDetectionHistoryDuration(TimeSpan duration)
        {
            //$ return withDuplicateMessageDetection(duration);

            return this;
        }

        ///GENMHASH:F7EF7F108726A21429C99DF63DAAA800:DEED29230AA7A59FB44FFD56ED4F9EB6
        public QueueImpl WithDefaultMessageTTL(TimeSpan ttl)
        {
            //$ this.Inner.WithDefaultMessageTimeToLive(TimeSpan.FromPeriod(ttl).ToString());
            //$ return this;

            return this;
        }

        ///GENMHASH:CF2CF801A7E4A9CAE7624D815E5EE4F4:E6E0C1CF73E25181AD5C0BE989C2DE15
        public QueueImpl WithNewListenRule(string name)
        {
            //$ this.rulesToCreate.Add(this.AuthorizationRules().Define(name).WithListeningEnabled());
            //$ return this;

            return this;
        }

        ///GENMHASH:2D5CAF0AEEF0BD622FB87526DB686956:0132F721ED8F4FA288C2D0F05EAE18CA
        public QueueImpl WithMessageLockDurationInSeconds(int durationInSeconds)
        {
            //$ TimeSpan timeSpan = new TimeSpan().WithSeconds(durationInSeconds);
            //$ this.Inner.WithLockDuration(timeSpan.ToString());
            //$ return this;

            return this;
        }

        ///GENMHASH:5B5F9D3A99AE0D9481B1C610B9517A73:8D284CBACC724E3DD3BC26B1612DB78C
        public long ScheduledMessageCount()
        {
            //$ if (this.Inner.CountDetails() == null
            //$ || this.Inner.CountDetails().ScheduledMessageCount() == null) {
            //$ return 0;
            //$ }
            //$ return Utils.ToPrimitiveLong(this.Inner.CountDetails().ScheduledMessageCount());

            return 0;
        }

        ///GENMHASH:D52241923D4C596EC463C0F8F469DB53:E791E23C8227DFEC860FF853D4BECAA0
        public bool IsPartitioningEnabled()
        {
            //$ return Utils.ToPrimitiveBoolean(this.Inner.EnablePartitioning());

            return false;
        }

        ///GENMHASH:DB317C55708995AFE3109A145FB49665:18B17F43DC47937B3611332D70BBD995
        public long ActiveMessageCount()
        {
            //$ if (this.Inner.CountDetails() == null
            //$ || this.Inner.CountDetails().ActiveMessageCount() == null) {
            //$ return 0;
            //$ }
            //$ return Utils.ToPrimitiveLong(this.Inner.CountDetails().ActiveMessageCount());

            return 0;
        }
    }
}