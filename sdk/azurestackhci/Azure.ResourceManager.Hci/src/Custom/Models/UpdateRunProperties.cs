// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    [CodeGenSuppress("StartTimeUtc")]
    [CodeGenSuppress("EndTimeUtc")]
    [CodeGenSuppress("LastUpdatedTimeUtc")]
    // The flatten propety "Name" will hide the base property Name, so we need to suppress the base property to avoid codegen errors. This is needed for backward compatibility as well since Name was previously flattened to Progress.Name in older versions of autorest.
    // TODO: we meed to tweak the naming strategy for property flattening
    [CodeGenSuppress("Name")]
    internal partial class UpdateRunProperties
    {
        // We suppressed the base Name property, so we need to re-declare it here to point to Progress.Name for backward compatibility with older versions of autorest that flattened Step.name to Progress.Name. This allows existing code that uses the old property name to continue working without modification.
        /// <summary> Name of the step. </summary>
        [WirePath("progress.name")]
        public string NamePropertiesProgressName
        {
            get
            {
                return Progress is null ? default : Progress.Name;
            }
            set
            {
                if (Progress is null)
                {
                    Progress = new HciUpdateStep();
                }
                Progress.Name = value;
            }
        }
    }
}
