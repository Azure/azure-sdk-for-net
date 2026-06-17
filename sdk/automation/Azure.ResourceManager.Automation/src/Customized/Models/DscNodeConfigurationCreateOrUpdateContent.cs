// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated DSC node configuration content nests Source and ConfigurationName under Properties.Configuration.
    // Keep the GA top-level setters by updating the nested properties payload.
    public partial class DscNodeConfigurationCreateOrUpdateContent
    {
        /// <summary> Gets or sets the source. </summary>
        public AutomationContentSource Source
        {
            get => Properties is null ? default : Properties.Source;
            [EditorBrowsable(EditorBrowsableState.Never)]
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
            [EditorBrowsable(EditorBrowsableState.Never)]
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
