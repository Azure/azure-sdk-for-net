//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System.Runtime.Serialization;


namespace Microsoft.WindowsAzure.Scheduler.Models
{
    /// <summary>
    /// Storage queue message
    /// </summary>
    [DataContract]
    public sealed class StorageQueueMessage
    {
        /// <summary>
        /// Gets or sets the ETag 
        /// </summary>
        [DataMember(Order = 1)]
        public string ExecutionTag { get; set; }

        /// <summary>
        /// Gets or sets the Client Request ID
        /// </summary>
        [DataMember(Order = 2)]
        public string ClientRequestId { get; set; }

        /// <summary>
        /// Gets or sets the Expected executionTime
        /// </summary>
        [DataMember(Order = 3)]
        public string ExpectedExecutionTime { get; set; }

        /// <summary>
        /// Gets or sets the Scheduler Job ID
        /// </summary>
        [DataMember(Order = 4)]
        public string SchedulerJobId { get; set; }

        /// <summary>
        /// Gets or sets the Scheduler JobCollection ID
        /// </summary>
        [DataMember(Order = 5)]
        public string SchedulerJobCollectionId { get; set; }

        /// <summary>
        /// Gets or sets the Region
        /// </summary>
        [DataMember(Order = 6)]
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the Message
        /// </summary>
        [DataMember(Order = 7)]
        public string Message { get; set; }
    }
}