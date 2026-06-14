// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving GA flattened DSC node configuration source and name setters.
    [CodeGenSuppress("ConfigurationName")]
    [CodeGenSuppress("Source")]
    public partial class DscNodeConfigurationCreateOrUpdateContent
    {
        /// <summary> Gets or sets the source. </summary>
        public AutomationContentSource Source
        {
            get => Properties is null ? default : Properties.Source;
            set
            {
                Properties = new DscNodeConfigurationCreateOrUpdateParametersProperties(
                    value,
                    Properties?.Configuration,
                    Properties?.IsIncrementNodeConfigurationBuildRequired,
                    default);
            }
        }

        /// <summary> Gets or sets the name of the Dsc configuration. </summary>
        public string ConfigurationName
        {
            get => Properties?.Configuration?.ConfigurationName;
            set
            {
                var configuration = Properties?.Configuration ?? new DscConfigurationAssociationProperty();
                configuration.ConfigurationName = value;
                Properties = new DscNodeConfigurationCreateOrUpdateParametersProperties(
                    Properties?.Source,
                    configuration,
                    Properties?.IsIncrementNodeConfigurationBuildRequired,
                    default);
            }
        }
    }
}
