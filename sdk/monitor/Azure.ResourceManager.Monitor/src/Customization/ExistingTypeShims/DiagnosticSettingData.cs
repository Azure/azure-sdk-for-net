// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Monitor.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Monitor
{
    [CodeGenSuppress("DiagnosticSettingData")]
    public partial class DiagnosticSettingData
    {
        /// <summary> Initializes a new instance of <see cref="DiagnosticSettingData"/>. </summary>
        public DiagnosticSettingData()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> The name of the event hub. If none is specified, the default event hub will be selected. </summary>
        public string EventHubName { get; set; }

        /// <summary> A string indicating whether the export to Log Analytics should use the default destination type. </summary>
        public string LogAnalyticsDestinationType { get; set; }

        /// <summary> The full ARM resource ID of the Marketplace resource to which you would like to send Diagnostic Logs. </summary>
        public ResourceIdentifier MarketplacePartnerId { get; set; }
    }
}
