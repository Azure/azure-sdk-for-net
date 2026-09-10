// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Hci.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci
{
    // These obsolete properties should be suppressed during generation, otherwise build will fail
    [CodeGenSuppress("StartTimeUtc")]
    [CodeGenSuppress("EndTimeUtc")]
    [CodeGenSuppress("LastUpdatedTimeUtc")]
    public partial class HciClusterUpdateRunData
    {
        // We suppressed the base Name property, so we need to re-declare it here to point to Progress.Name for backward compatibility with older versions of autorest that flattened Step.name to Progress.Name. This allows existing code that uses the old property name to continue working without modification.
        /// <summary> Name of the progress step. </summary>
        [WirePath("properties.progress.name")]
        [CodeGenMember("Name")]
        public string NamePropertiesProgressName
        {
            get
            {
                return Properties.Progress is null ? default : Properties.Progress.Name;
            }
            set
            {
                if (Properties.Progress is null)
                {
                    Properties.Progress = new HciUpdateStep();
                }
                Properties.Progress.Name = value;
            }
        }
    }
}
