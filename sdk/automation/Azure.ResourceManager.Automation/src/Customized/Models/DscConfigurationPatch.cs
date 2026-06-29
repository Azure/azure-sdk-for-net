// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated DSC configuration patch exposes other flattened fields but not a public Source setter.
    // Keep the GA Source setter by rebuilding the nested Properties payload.
    public partial class DscConfigurationPatch
    {
        /// <summary> Gets or sets the source. </summary>
        public AutomationContentSource Source
        {
            get => Properties is null ? default : Properties.Source;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                Properties = new DscConfigurationCreateOrUpdateProperties(
                    Properties?.IsLogVerboseEnabled,
                    Properties?.IsLogProgressEnabled,
                    value,
                    Properties?.Parameters ?? new ChangeTrackingDictionary<string, DscConfigurationParameterDefinition>(),
                    Properties?.Description,
                    default);
            }
        }
    }
}
