// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving the GA flattened DSC configuration source setter.
    [CodeGenSuppress("Source")]
    public partial class DscConfigurationPatch
    {
        /// <summary> Gets or sets the source. </summary>
        public AutomationContentSource Source
        {
            get => Properties is null ? default : Properties.Source;
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
