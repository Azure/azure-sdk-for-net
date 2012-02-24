using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Service bus subscription creation options.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name = "SubscriptionDescription")]
    public sealed class SubscriptionSettings
    {
        [DataMember(Order = 0)]
        public TimeSpan? LockDuration { get; set; }
        [DataMember(Order = 1)]
        public bool? RequiresSession { get; set; }
        [DataMember(Order = 2)]
        public TimeSpan? DefaultMessageTimeToLive { get; set; }
        [DataMember(Order = 3)]
        public bool? DeadLetteringOnMessageExpiration { get; set; }
        [DataMember(Order = 4)]
        public bool? DeadLetteringOnFilterEvaluationExceptions { get; set; }
        [DataMember(Order = 5)]
        public int? MaxDeliveryCount { get; set; }
        [DataMember(Order = 6)]
        public bool? EnableBatchedOperations { get; set; }
    }
}
