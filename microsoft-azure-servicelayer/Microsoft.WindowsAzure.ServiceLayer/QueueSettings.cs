using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// Queue creation options
    /// </summary>
    [DataContract(Namespace="http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name="QueueDescription")]
    public sealed class QueueSettings
    {
        [DataMember(Order = 0)]
        public TimeSpan? LockDuration { get; internal set; }

        [DataMember(Order = 1)]
        public int? MaxSizeInMegabytes { get; internal set; }

        [DataMember(Order = 2)]
        public bool? RequiresDuplicateDetection { get; internal set; }

        [DataMember(Order = 3)]
        public bool? RequiresSession { get; internal set; }

        [DataMember(Order = 4)]
        public TimeSpan? DefaultMessageTimeToLive { get; internal set; }

        [DataMember(Order = 5, Name = "DeadLetteringOnMessageExpiration")]
        public bool? EnableDeadLetteringOnMessageExpiration { get; internal set; }

        [DataMember(Order = 6)]
        public TimeSpan? DuplicateDetectionHistoryTimeWindow { get; internal set; }

        [DataMember(Order = 7)]
        public int? MaxDeliveryCount { get; internal set; }

        [DataMember(Order = 8)]
        public bool? EnableBatchedOperations { get; internal set; }

        [DataMember(Order = 9)]
        public int? SizeInBytes { get; internal set; }

        [DataMember(Order = 10)]
        public int? MessageCount { get; internal set; }
    }
}
