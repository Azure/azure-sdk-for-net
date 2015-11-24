// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a schedule for indexer execution.
    /// </summary>
    public class IndexingSchedule
    {
        /// <summary>
        /// Initializes a new instance of the IndexingSchedule class.
        /// </summary>
        public IndexingSchedule() { }

        /// <summary>
        /// Initializes a new instance of the IndexingSchedule class.
        /// </summary>
        public IndexingSchedule(TimeSpan interval, DateTimeOffset? startTime = default(DateTimeOffset?))
        {
            Interval = interval;
            StartTime = startTime;
        }

        /// <summary>
        /// Gets or sets the interval of time between indexer executions.
        /// </summary>
        [JsonProperty(PropertyName = "interval")]
        public TimeSpan Interval { get; set; }

        /// <summary>
        /// Gets or sets the time when an indexer should start running.
        /// </summary>
        [JsonProperty(PropertyName = "startTime")]
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
        }
    }
}
