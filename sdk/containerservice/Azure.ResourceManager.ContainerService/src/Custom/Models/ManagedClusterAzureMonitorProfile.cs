// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.ContainerService.Models
{
    public partial class ManagedClusterAzureMonitorProfile
    {
        // This property is retained for backward compatibility. The value now lives on the nested
        // AppMonitoring model, so this shim reads from and writes through to AppMonitoring.
        /// <summary> Indicates if Application Monitoring Auto Instrumentation is enabled or not. </summary>
        [WirePath("appMonitoring.autoInstrumentation.enabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsAppMonitoringAutoInstrumentationEnabled
        {
            get
            {
                return AppMonitoring is null ? default : AppMonitoring.IsAppMonitoringAutoInstrumentationEnabled;
            }
            set
            {
                if (AppMonitoring is null)
                {
                    AppMonitoring = new ManagedClusterAzureMonitorProfileAppMonitoring();
                }
                AppMonitoring.IsAppMonitoringAutoInstrumentationEnabled = value;
            }
        }
    }
}
