//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

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
        /// <summary>
        /// Sets the lock duration. 
        /// </summary>
        [DataMember(Order = 0)]
        public TimeSpan? LockDuration { get; set; }

        /// <summary>
        /// Tells whether the subscription should be session-avare.
        /// </summary>
        [DataMember(Order = 1)]
        public bool? RequiresSession { get; set; }

        /// <summary>
        /// Determines how long a message lives in the subscription.
        /// </summary>
        [DataMember(Order = 2)]
        public TimeSpan? DefaultMessageTimeToLive { get; set; }

        /// <summary>
        /// Specifies how the Service Bus handles a message whose TTL has 
        /// expired.
        /// </summary>
        [DataMember(Order = 3)]
        public bool? DeadLetteringOnMessageExpiration { get; set; }

        /// <summary>
        /// Determines how the Service Bus handles a message that causes an 
        /// exception during a subscription’s filter evaluation.
        /// </summary>
        [DataMember(Order = 4)]
        public bool? DeadLetteringOnFilterEvaluationExceptions { get; set; }

        /// <summary>
        /// Tells the maximum number of times a message Service Bus will try 
        /// to deliver before being dead lettered or discarded.
        /// </summary>
        [DataMember(Order = 5)]
        public int? MaxDeliveryCount { get; set; }

        /// <summary>
        /// Enables or disables service side batching behavior when performing 
        /// operations for the specific queue
        /// </summary>
        [DataMember(Order = 6)]
        public bool? EnableBatchedOperations { get; set; }
    }
}
