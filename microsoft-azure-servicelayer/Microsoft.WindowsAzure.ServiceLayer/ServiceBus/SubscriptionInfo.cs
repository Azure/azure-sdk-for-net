using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Windows.Web.Syndication;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Service bus subscription information.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name = "SubscriptionDescription")]
    public sealed class SubscriptionInfo
    {
        /// <summary>
        /// Gets the lock duration.
        /// </summary>
        [DataMember(Order = 0)]
        public TimeSpan LockDuration { get; internal set; }

        /// <summary>
        /// Tells whether the subscription should be session-avare.
        /// </summary>
        [DataMember(Order = 1)]
        public bool RequiresSession { get; internal set; }

        /// <summary>
        /// Determines how long a message lives in the subscription.
        /// </summary>
        [DataMember(Order = 2)]
        public TimeSpan DefaultMessageTimeToLive { get; internal set; }

        /// <summary>
        /// Specifies how the Service Bus handles a message whose TTL has 
        /// expired.
        /// </summary>
        [DataMember(Order = 3)]
        public bool DeadLetteringOnMessageExpiration { get; internal set; }

        /// <summary>
        /// Determines how the Service Bus handles a message that causes an 
        /// exception during a subscription’s filter evaluation.
        /// </summary>
        [DataMember(Order = 4)]
        public bool DeadLetteringOnFilterEvaluationExceptions { get; internal set; }

        /// <summary>
        /// Gets the number of messages in the queue as reported by the
        /// monitoring system.
        /// </summary>
        [DataMember(Order = 5)]
        public int MessageCount { get; internal set; }

        /// <summary>
        /// Tells the maximum number of times a message Service Bus will try 
        /// to deliver before being dead lettered or discarded.
        /// </summary>
        [DataMember(Order = 6)]
        public int MaxDeliveryCount { get; internal set; }

        /// <summary>
        /// Tells whether server side batching is enabled.
        /// </summary>
        [DataMember(Order = 7)]
        public bool EnableBatchedOperations { get; internal set; }

        /// <summary>
        /// Gets the name of the subscription.
        /// </summary>
        [IgnoreDataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the URI of the subscription.
        /// </summary>
        [IgnoreDataMember]
        public Uri Uri { get; private set; }

        /// <summary>
        /// Constructor. We don't want users to create instances of this class,
        /// so we make it internal.
        /// </summary>
        internal SubscriptionInfo()
        {
        }

        /// <summary>
        /// Initializes the object from the given atom item.
        /// </summary>
        /// <param name="item">Source atom item</param>
        internal void Initialize(SyndicationItem item)
        {
            Name = item.Title.Text;
            Uri = new Uri(item.Id);
        }
    }
}
