// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Servicebus.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Subscription.Definition;
    using Subscription.Update;
    using System;
    using Org.Joda.Time;
    using ResourceManager.Fluent.Core;
    using ServiceBus.Fluent;

    /// <summary>
    /// Implementation for Subscription.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNlcnZpY2VidXMuaW1wbGVtZW50YXRpb24uU3Vic2NyaXB0aW9uSW1wbA==
    internal partial class SubscriptionImpl  :
        IndependentChildResourceImpl<Microsoft.Azure.Management.Servicebus.Fluent.ISubscription,Microsoft.Azure.Management.Servicebus.Fluent.ITopic,Microsoft.Azure.Management.Servicebus.Fluent.SubscriptionInner,Microsoft.Azure.Management.Servicebus.Fluent.SubscriptionImpl,Microsoft.Azure.Management.Servicebus.Fluent.ServiceBusManager>,
        ISubscription,
        IDefinition,
        IUpdate
    {
        private string namespaceName;
        private Region region;
        ///GENMHASH:0528195D56802C53049B175998349788:6A2B15DC582327EF91835262AE29E287
        public SubscriptionImpl WithoutSession()
        {
            //$ this.Inner.WithRequiresSession(false);
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

        ///GENMHASH:83451D169A4B33856A9C47EFB90A4598:2C99FB79A8C8F3BE1232EC22FA0E6912
        public bool IsDeadLetteringEnabledForFilterEvaluationFailedMessages()
        {
            //$ return Utils.ToPrimitiveBoolean(this.Inner.DeadLetteringOnFilterEvaluationExceptions());

            return false;
        }

        ///GENMHASH:C1A58BF0014F5C84224E6BF6230B35E2:A032431A79B461F60FEB9055B4D7EB6F
        public SubscriptionImpl WithSession()
        {
            //$ this.Inner.WithRequiresSession(true);
            //$ return this;

            return this;
        }

        ///GENMHASH:936C3217C73954650336153ED9177264:05DAE515E479A1DF210DAF9CFC14667A
        public bool IsSessionEnabled()
        {
            //$ return Utils.ToPrimitiveBoolean(this.Inner.RequiresSession());

            return false;
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

        ///GENMHASH:3B2A360F977A78F31ACAD3AF5E995284:C832373561FBC59128220812809337CA
        public Period DefaultMessageTtlDuration()
        {
            //$ if (this.Inner.DefaultMessageTimeToLive() == null) {
            //$ return null;
            //$ }
            //$ TimeSpan timeSpan = TimeSpan.Parse(this.Inner.DefaultMessageTimeToLive());
            //$ return new Period()
            //$ .WithDays(timeSpan.Days())
            //$ .WithHours(timeSpan.Hours())
            //$ .WithMinutes(timeSpan.Minutes())
            //$ .WithSeconds(timeSpan.Seconds())
            //$ .WithMillis(timeSpan.Milliseconds());

            return null;
        }

        ///GENMHASH:56C6A82F1068747CBC7818C64CB0F0D6:43D29E0743B484841FAD53C707D7934E
        public bool IsBatchedOperationsEnabled()
        {
            //$ return Utils.ToPrimitiveBoolean(this.Inner.EnableBatchedOperations());

            return false;
        }

        ///GENMHASH:AB43CAB847CF58797CAF155C313C9470:1F268B13CEEAC2DB0E277180DA5B2B23
        public SubscriptionImpl WithoutMessageBatching()
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

        ///GENMHASH:2F2EF0FE71A7DC4B85DE8C657CCA92D7:21177EF8658A56EE7AC900DDADA3C032
        public SubscriptionImpl WithoutMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException()
        {
            //$ this.Inner.WithDeadLetteringOnFilterEvaluationExceptions(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:7F20EE5668A545847B616FEDDD9D7A4B:1EE45DA97175AB941AF344765CA8BCEA
        public SubscriptionImpl WithMessageMovedToDeadLetterQueueOnMaxDeliveryCount(int deliveryCount)
        {
            //$ this.Inner.WithMaxDeliveryCount(deliveryCount);
            //$ return this;

            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:749030CA5C22BFCBAE3439E2BC57EE23
        protected async Task<Microsoft.Azure.Management.Servicebus.Fluent.SubscriptionInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.Manager().Inner.Subscriptions()
            //$ .GetAsync(this.ResourceGroupName(),
            //$ this.namespaceName,
            //$ this.ParentName,
            //$ this.Name());

            return null;
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

        ///GENMHASH:E1A70C93622FE40F497284FABDDB605E:E5111569019FB6C2D9B4CECED7418140
        public int MaxDeliveryCountBeforeDeadLetteringMessage()
        {
            //$ return Utils.ToPrimitiveInt(this.Inner.MaxDeliveryCount());

            return 0;
        }

        ///GENMHASH:47B8BA931EAD94FF703386F99945FF39:214A76C50356372A113C3FB025343090
        public SubscriptionImpl WithExpiredMessageMovedToDeadLetterSubscription()
        {
            //$ this.Inner.WithDeadLetteringOnMessageExpiration(true);
            //$ return this;

            return this;
        }

        ///GENMHASH:F7291612CB88E44B1AA004E287504109:46766F6B1FAC81EB53D3B180E9E37C4E
        public SubscriptionImpl WithoutExpiredMessageMovedToDeadLetterSubscription()
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

        ///GENMHASH:58A51D8B1AAAD3EC7A897EBEE2B65040:D0E268D56BCA88C4DC556AFC1646D434
        public DateTime AccessedAt()
        {
            //$ return this.Inner.AccessedAt();

            return DateTime.Now;
        }

        ///GENMHASH:B2EB74D988CD2A7EFC551E57BE9B48BB:250033B2F34291DBD013248656522902
        protected async Task<Microsoft.Azure.Management.Servicebus.Fluent.ISubscription> CreateChildResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ Subscription self = this;
            //$ return this.Manager().Inner.Subscriptions()
            //$ .CreateOrUpdateAsync(this.ResourceGroupName(),
            //$ this.namespaceName,
            //$ this.ParentName,
            //$ this.Name(),
            //$ this.Inner)
            //$ .Map(new Func1<SubscriptionInner, Subscription>() {
            //$ @Override
            //$ public Subscription call(SubscriptionInner inner) {
            //$ setInner(inner);
            //$ return self;
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:68782FB4241FCE8C93994E341D571F84:19C7141ECFBA2F3F6733933D34ED6F18
        public SubscriptionImpl WithMessageMovedToDeadLetterSubscriptionOnFilterEvaluationException()
        {
            //$ this.Inner.WithDeadLetteringOnFilterEvaluationExceptions(true);
            //$ return this;

            return this;
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

        ///GENMHASH:F51B0A889F1B18982BB40AAE9B8FC6A6:1446E7FFFBEC1D4153FA0E9D00A844D8
        public SubscriptionImpl WithMessageBatching()
        {
            //$ this.Inner.WithEnableBatchedOperations(true);
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

        ///GENMHASH:514385EE4D1CB2C644E88CCE3BD80E06:1EE45DA97175AB941AF344765CA8BCEA
        public SubscriptionImpl WithMessageMovedToDeadLetterSubscriptionOnMaxDeliveryCount(int deliveryCount)
        {
            //$ this.Inner.WithMaxDeliveryCount(deliveryCount);
            //$ return this;

            return this;
        }

        ///GENMHASH:0E17D4BBCB9C51BDF488109DAB715495:97C4628AD1F2197E40346D447A471D3E
        public SubscriptionImpl WithDeleteOnIdleDurationInMinutes(int durationInMinutes)
        {
            //$ TimeSpan timeSpan = new TimeSpan().WithMinutes(durationInMinutes);
            //$ this.Inner.WithAutoDeleteOnIdle(timeSpan.ToString());
            //$ return this;

            return this;
        }

        ///GENMHASH:F7EF7F108726A21429C99DF63DAAA800:DEED29230AA7A59FB44FFD56ED4F9EB6
        public SubscriptionImpl WithDefaultMessageTTL(TimeSpan ttl)
        {
            //$ this.Inner.WithDefaultMessageTimeToLive(TimeSpan.FromPeriod(ttl).ToString());
            //$ return this;

            return this;
        }

        ///GENMHASH:2D5CAF0AEEF0BD622FB87526DB686956:0132F721ED8F4FA288C2D0F05EAE18CA
        public SubscriptionImpl WithMessageLockDurationInSeconds(int durationInSeconds)
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

        ///GENMHASH:D34AFBD0F174F19A653AA4494C6644CF:FAF1EE7AC452C290A5530A75FBBD6949
        internal  SubscriptionImpl(string resourceGroupName, string namespaceName, string topicName, string name, Region region, Management.Fluent.ServiceBus.Models.SubscriptionInner inner, IServiceBusManager manager)
        {
            //$ {
            //$ super(name, inner, manager);
            //$ this.namespaceName = namespaceName;
            //$ this.region = region;
            //$ this.WithExistingParentResource(resourceGroupName, topicName);
            //$ if (inner.Location() == null) {
            //$ inner.WithLocation(this.region.ToString());
            //$ }
            //$ }

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

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:1ABA34EF946CBD0278FAD778141792B2
        public EntityStatus Status()
        {
            //$ return this.Inner.Status();

            return EntityStatus.ACTIVE;
        }
    }
}