// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class FunctionAppScaleAndConcurrency
    {
        /// <summary> The maximum number of instances for the function app. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("maximumInstanceCount")]
        public float? MaximumInstanceCount
        {
            get => FunctionAppMaximumInstanceCount.Value;
            set => FunctionAppMaximumInstanceCount = (int?)value;
        }

        /// <summary> Set the amount of memory allocated to each instance of the function app in MB. CPU and network bandwidth are allocated proportionally. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("instanceMemoryMB")]
        public float? InstanceMemoryMB
        {
            get => FunctionAppInstanceMemoryMB.Value;
            set => FunctionAppInstanceMemoryMB = (int?)value;
        }

        /// <summary> The maximum number of concurrent HTTP trigger invocations per instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("triggers.http.perInstanceConcurrency")]
        public float? HttpPerInstanceConcurrency
        {
            get => Triggers is null ? default : Triggers.ConcurrentHttpPerInstanceConcurrency;
            set
            {
                if (Triggers is null)
                    Triggers = new FunctionsScaleAndConcurrencyTriggers();
                Triggers.ConcurrentHttpPerInstanceConcurrency = (int?)value;
            }
        }
    }
}