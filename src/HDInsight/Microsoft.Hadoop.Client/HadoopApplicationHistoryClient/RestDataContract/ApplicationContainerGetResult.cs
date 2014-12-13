// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Client
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Represents the result of a get application container REST call against a Hadoop cluster.
    /// </summary>
    [DataContract]
    internal class ApplicationContainerGetResult
    {
        /// <summary>
        /// Gets or sets the container ID.
        /// </summary>
        [DataMember(Name = "containerId")]
        public string ContainerId { get; set; }

        /// <summary>
        /// Gets or sets the node on which this container was assigned.
        /// </summary>
        [DataMember(Name = "assignedNodeId")]
        public string NodeId { get; set; }

        /// <summary>
        /// Gets or sets the container state.
        /// </summary>
        [DataMember(Name = "containerState")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the container' exit status.
        /// </summary>
        [DataMember(Name = "containerExitStatus")]
        public string ExitStatus { get; set; }

        /// <summary>
        /// Gets or sets the container priority.
        /// </summary>
        [DataMember(Name = "priority")]
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the number of cores allocated to this container.
        /// </summary>
        [DataMember(Name = "allocatedVCores")]
        public int AllocatedCores { get; set; }

        /// <summary>
        /// Gets or sets the amount of memory in MB allocated to this container.
        /// </summary>
        [DataMember(Name = "allocatedMB")]
        public int AllocatedMemoryInMegabytes { get; set; }

        /// <summary>
        /// Gets or sets the diagnostic information for this container.
        /// </summary>
        [DataMember(Name = "diagnosticsInfo")]
        public string DiagnosticInfo { get; set; }

        /// <summary>
        /// Gets or sets the container start time in milliseconds since unix epoch.
        /// </summary>
        [DataMember(Name = "startedTime")]
        internal long StartTimeInMillisecondsSinceUnixEpoch { get; set; }

        /// <summary>
        /// Gets or sets the container finish time in milliseconds since unix epoch.
        /// </summary>
        [DataMember(Name = "finishedTime")]
        internal long FinishTimeInMillisecondsSinceUnixEpoch { get; set; }
    }
}