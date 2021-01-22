// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// HealthcareOperationProperties.
    /// </summary>
    public class HealthcareOperationProperties
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthcareOperationProperties"/> class.
        /// </summary>
        /// <param name="createdDateTime"></param>
        /// <param name="lastUpdateDateTime"></param>
        /// <param name="status"></param>
        public HealthcareOperationProperties(DateTimeOffset createdDateTime, DateTimeOffset lastUpdateDateTime, JobStatus status)
        {
            CreatedDateTime = createdDateTime;
            LastUpdateDateTime = lastUpdateDateTime;
            Status = status;
        }

        /// <summary>
        /// CreatedDateTime
        /// </summary>
        public DateTimeOffset CreatedDateTime { get; }

        /// <summary>
        /// CreatedDateTime
        /// </summary>
        public DateTimeOffset LastUpdateDateTime { get; }

        /// <summary>
        /// Status
        /// </summary>
        public JobStatus Status { get; }
    }
}
