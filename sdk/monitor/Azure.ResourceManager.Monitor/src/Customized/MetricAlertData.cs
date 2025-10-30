// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    /// <summary>
    /// A class representing the MetricAlert data model.
    /// </summary>
    public partial class MetricAlertData
    {
        // Backing field for WindowSize to handle both nullable and non-nullable access
        private TimeSpan? _windowSizeValue;

        /// <summary> Initializes a new instance of <see cref="MetricAlertData"/>. </summary>
        /// <param name="location"> The location. </param>
        /// <param name="severity"> Alert severity {0, 1, 2, 3, 4}. </param>
        /// <param name="isEnabled"> The flag that indicates whether the metric alert is enabled. </param>
        /// <param name="scopes"> The list of resource id's that this metric alert is scoped to. </param>
        /// <param name="evaluationFrequency"> How often the metric alert is evaluated represented in ISO 8601 duration format. </param>
        /// <param name="windowSize"> The period of time (in ISO 8601 duration format) that is used to monitor alert activity based on the threshold. </param>
        /// <param name="criteria"> Defines the specific alert criteria information. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scopes"/> is null. </exception>
        public MetricAlertData(AzureLocation location, int severity, bool isEnabled, IEnumerable<string> scopes, TimeSpan evaluationFrequency, TimeSpan windowSize, MetricAlertCriteria criteria)
            : this(location, severity, isEnabled, scopes, evaluationFrequency, criteria)
        {
            _windowSizeValue = windowSize;
        }
    }
}
