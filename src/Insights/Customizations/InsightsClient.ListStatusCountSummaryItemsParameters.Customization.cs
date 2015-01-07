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

using System;
using Microsoft.Azure.Common.OData;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// The parameters to get the events for a subscription
    /// </summary>
    public class ListStatusCountItemCollectionParameters
    {
        /// <summary>
        /// Gets or sets the start time
        /// </summary>
        [FilterParameter("startTime", "O")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        [FilterParameter("endTime", "O")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the status
        /// </summary>
        [FilterParameter("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the caller
        /// </summary>
        [FilterParameter("caller")]
        public string Caller { get; set; }
    }

    /// <summary>
    /// The parameters to get the event status count summary for an event source
    /// </summary>
    public class ListStatusCountItemCollectionForEventSourceParameters : ListStatusCountItemCollectionParameters
    {
        /// <summary>
        /// Gets or sets the event source
        /// </summary>
        [FilterParameter("eventSource")]
        public string EventSource { get; set; }
    }

    /// <summary>
    /// The parameters to get the event status count summary for a resource
    /// </summary>
    public class ListStatusCountItemCollectionForResourceParameters : ListStatusCountItemCollectionParameters
    {
        /// <summary>
        /// Gets or sets the resource uri
        /// </summary>
        [FilterParameter("resourceUri")]
        public string ResourceUri { get; set; }
    }

    /// <summary>
    /// The parameters to get the event status count summary for a resource group
    /// </summary>
    public class ListStatusCountItemCollectionForResourceGroupParameters : ListStatusCountItemCollectionParameters
    {
        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [FilterParameter("resourceGroupName")]
        public string ResourceGroupName { get; set; }
    }

    /// <summary>
    /// The parameters to get the event status count summary for a resource provider
    /// </summary>
    public class ListStatusCountItemCollectionForResourceProviderParameters : ListStatusCountItemCollectionParameters
    {
        /// <summary>
        /// Gets or sets the resource provider
        /// </summary>
        [FilterParameter("resourceProvider")]
        public string ResourceProvider { get; set; }
    }
}
