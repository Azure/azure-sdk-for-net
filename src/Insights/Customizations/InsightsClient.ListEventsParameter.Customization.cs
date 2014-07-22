﻿//
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
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Common.OData;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// The parameters to get the events for a subscription
    /// </summary>
    public class ListEventsParameters
    {
        /// <summary>
        /// Gets or sets the start time
        /// </summary>
        [FilterParameter("eventTimestamp", "O")]
        public DateTime EventTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the event channel
        /// </summary>
        [FilterParameter("eventChannels")]
        public EventChannels? EventChannels { get; set; }
    }

    /// <summary>
    /// The parameters to get the events for a correlation id
    /// </summary>
    public class ListEventsForCorrelationIdParameters : ListEventsParameters
    {
        /// <summary>
        /// Gets or sets the correlation id
        /// </summary>
        [FilterParameter("correlationId")]
        public string CorrelationId { get; set; }
    }

    /// <summary>
    /// The parameters to get the events for an event source
    /// </summary>
    public class ListEventsForEventSourceParameters : ListEventsParameters
    {
        /// <summary>
        /// Gets or sets the event source
        /// </summary>
        [FilterParameter("eventSource")]
        public string EventSource { get; set; }
    }

    /// <summary>
    /// The parameters to get the events for a resource
    /// </summary>
    public class ListEventsForResourceParameters : ListEventsParameters
    {
        /// <summary>
        /// Get or set the resource uri
        /// </summary>
        [FilterParameter("resourceUri")]
        public string ResourceUri { get; set; }
    }

    /// <summary>
    /// The parameters to get the events for a resource group
    /// </summary>
    public class ListEventsForResourceGroupParameters : ListEventsParameters
    {
        /// <summary>
        /// Get or set the resource group name
        /// </summary>
        [FilterParameter("resourceGroupName")]
        public string ResourceGroupName { get; set; }
    }

    /// <summary>
    /// The parameters to get the events for a resource provider
    /// </summary>
    public class ListEventsForResourceProviderParameters : ListEventsParameters
    {
        /// <summary>
        /// Get or set the resource provider
        /// </summary>
        [FilterParameter("resourceProvider")]
        public string ResourceProvider { get; set; }
    }
}
