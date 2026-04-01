// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci
{
    [CodeGenSuppress("StartOn")]
    [CodeGenSuppress("EndOn")]
    [CodeGenSuppress("LastUpdatedOn")]
    public partial class HciClusterUpdateRunData
    {
        /// <summary> Name of the progress step. </summary>
        [WirePath("properties.progress.name")]
        public string NamePropertiesProgressName { get => Name; set => Name = value; }

        /// <summary> When the step started, or empty if it has not started executing. </summary>
        [WirePath("properties.progress.startTimeUtc")]
        public DateTimeOffset? StartOn
        {
            get => Properties is null ? default : Properties.StartTimeUtc;
            set
            {
                if (Properties == null)
                { Properties = new Models.UpdateRunProperties(); }
                if (value.HasValue)
                { Properties.StartTimeUtc = value.Value; }
            }
        }

        /// <summary> When the step reached a terminal state. </summary>
        [WirePath("properties.progress.endTimeUtc")]
        public DateTimeOffset? EndOn
        {
            get => Properties is null ? default : Properties.EndTimeUtc;
            set
            {
                if (Properties == null)
                { Properties = new Models.UpdateRunProperties(); }
                if (value.HasValue)
                { Properties.EndTimeUtc = value.Value; }
            }
        }

        /// <summary> Completion time of this step or the last completed sub-step. </summary>
        [WirePath("properties.progress.lastUpdatedTimeUtc")]
        public DateTimeOffset? LastUpdatedOn
        {
            get => Properties is null ? default : Properties.LastUpdatedTimeUtc;
            set
            {
                if (Properties == null)
                { Properties = new Models.UpdateRunProperties(); }
                if (value.HasValue)
                { Properties.LastUpdatedTimeUtc = value.Value; }
            }
        }
    }
}
