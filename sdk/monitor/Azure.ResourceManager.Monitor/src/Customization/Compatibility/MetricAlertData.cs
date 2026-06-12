// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Monitor.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Monitor
{
    [CodeGenSuppress("WindowSize")]
    public partial class MetricAlertData
    {
        /// <summary> Initializes a new instance of <see cref="MetricAlertData"/>. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="severity"> Alert severity. </param>
        /// <param name="isEnabled"> Whether the metric alert is enabled. </param>
        /// <param name="scopes"> The list of resource IDs this metric alert is scoped to. </param>
        /// <param name="evaluationFrequency"> How often the metric alert is evaluated. </param>
        /// <param name="windowSize"> The time window used to monitor alert activity. </param>
        /// <param name="criteria"> The alert criteria. </param>
        public MetricAlertData(AzureLocation location, int severity, bool isEnabled, IEnumerable<string> scopes, TimeSpan evaluationFrequency, TimeSpan windowSize, MetricAlertCriteria criteria)
            : this(location, severity, isEnabled, scopes, evaluationFrequency, criteria)
        {
            WindowSize = windowSize;
        }

        /// <summary> The period of time that is used to monitor alert activity based on the threshold. </summary>
        public TimeSpan WindowSize
        {
            get => Properties?.WindowSize ?? default;
            set
            {
                if (Properties is null)
                {
                    Properties = new MetricAlertProperties();
                }
                Properties.WindowSize = value;
            }
        }
    }
}
