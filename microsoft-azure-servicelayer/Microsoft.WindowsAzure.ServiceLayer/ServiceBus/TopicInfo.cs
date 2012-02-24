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

using Windows.Web.Syndication;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Service bus topic.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect", Name = "TopicDescription")]
    public sealed class TopicInfo
    {
        /// <summary>
        /// Determines how long a message lives in the associated subscriptions.
        /// </summary>
        [DataMember(Order = 0)]
        public TimeSpan DefaultMessageTimeToLive { get; internal set; }

        /// <summary>
        /// Specifies the maximum topic size in megabytes.
        /// </summary>
        [DataMember(Order=1)]
        public int MaxSizeInMegabytes { get; internal set; }

        /// <summary>
        /// If enabled, the topic will detect duplicate messages within the 
        /// time span specified by the DuplicateDetectionHistoryTimeWindow property.
        /// </summary>
        [DataMember(Order=2)]
        public bool RequiresDuplicateDetection { get; internal set; }

        /// <summary>
        /// Specifies the time span during which the Service Bus will detect 
        /// message duplication.
        /// </summary>
        [DataMember(Order=3)]
        public TimeSpan DuplicateDetectionHistoryTimeWindow { get; internal set; }

        /// <summary>
        /// Specifies whether service side batching operations are enabled.
        /// </summary>
        [DataMember(Order=4)]
        public bool EnableBatchedOperations { get; internal set; }

        /// <summary>
        /// Reflects the actual bytes toward the topic quota that messages in
        /// the topic currently occupy. 
        /// </summary>
        [DataMember(Order=5)]
        public int SizeInBytes { get; internal set; }

        /// <summary>
        /// Gets the name of the topic.
        /// </summary>
        [IgnoreDataMember]
        public string Name { get; private set; }

        /// <summary>
        /// Gets URI of the topic.
        /// </summary>
        [IgnoreDataMember]
        public Uri Uri { get; private set; }

        /// <summary>
        /// Constructor for serialization purposes.
        /// </summary>
        internal TopicInfo()
        {
        }

        /// <summary>
        /// Initializes the item after deserialization.
        /// </summary>
        /// <param name="item">Source atom item.</param>
        internal void Initialize(SyndicationItem item)
        {
            Name = item.Title.Text;
            Uri = new Uri(item.Id);
        }
    }
}
