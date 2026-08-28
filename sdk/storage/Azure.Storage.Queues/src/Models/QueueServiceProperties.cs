// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueServiceProperties.
    /// </summary>
    public partial class QueueServiceProperties
    {
        /// <summary>
        /// The set of CORS rules.
        /// </summary>
        [CodeGenMember("Cors")]
#pragma warning disable CA2227 // Collection properties should be read only
        public IList<QueueCorsRule> Cors { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

        /// <summary>
        /// Creates a new QueueServiceProperties instance.
        /// </summary>
        public QueueServiceProperties()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new QueueServiceProperties instance.
        /// </summary>
        /// <param name="skipInitialization">Whether to skip initializing nested objects.</param>
        internal QueueServiceProperties(bool skipInitialization)
        {
            if (!skipInitialization)
            {
                Logging = new QueueAnalyticsLogging();
                HourMetrics = new QueueMetrics();
                MinuteMetrics = new QueueMetrics();
            }
        }
    }
}
