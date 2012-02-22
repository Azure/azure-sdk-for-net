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
using System.Runtime.Serialization;

using Windows.Data.Xml.Dom;
using Windows.Web.Syndication;


namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Service bus queue info
    /// </summary>
    [DataContract(Namespace="http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name="QueueDescription")]
    public sealed class QueueInfo
    {
        [DataMember(Order=0)]
        public TimeSpan LockDuration { get; internal set; }

        [DataMember(Order=1)]
        public int MaxSizeInMegabytes { get; internal set; }

        [DataMember(Order=2)]
        public bool RequiresDuplicateDetection { get; internal set; }

        [DataMember(Order=3)]
        public bool RequiresSession { get; internal set; }

        [DataMember(Order=4)]
        public TimeSpan DefaultMessageTimeToLive { get; internal set; }

        [DataMember(Order=5, Name="DeadLetteringOnMessageExpiration")]
        public bool EnableDeadLetteringOnMessageExpiration { get; internal set; }

        [DataMember(Order=6)]
        public TimeSpan DuplicateDetectionHistoryTimeWindow { get; internal set; }

        [DataMember(Order=7)]
        public int MaxDeliveryCount { get; internal set; }

        [DataMember(Order=8)]
        public bool EnableBatchedOperations { get; internal set; }

        [DataMember(Order=9)]
        public int SizeInBytes { get; internal set; }

        [DataMember(Order=10)]
        public int MessageCount { get; internal set; }

        [IgnoreDataMember]
        public string Name { get; private set; }

        [IgnoreDataMember]
        public Uri Uri { get; private set; }

        /// <summary>
        /// Constructor for serialization purposes.
        /// </summary>
        internal QueueInfo()
        {
        }

        /// <summary>
        /// Initializes the object after deserialization.
        /// </summary>
        /// <param name="item">Atom item</param>
        internal void Initialize(SyndicationItem item)
        {
            Name = item.Title.Text;
            Uri = new Uri(item.Id);
        }
    }
}
