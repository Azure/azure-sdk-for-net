// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Azure.ResourceManager.StorageCache.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.StorageCache
{
    public partial class AutoExportJobData : TrackedResourceData
    {
        // status is read-only in TypeSpec, but the previous C# surface allowed State to be set.
        /// <summary> The operational state of auto export. InProgress indicates the export is running.  Disabling indicates the user has requested to disable the export but the disabling is still in progress. Disabled indicates auto export has been disabled.  DisableFailed indicates the disabling has failed.  Failed means the export was unable to continue, due to a fatal error. </summary>
        [CodeGenMember("State")]
        public AutoExportStatusType? State
        {
            get
            {
                return Properties is null ? default : Properties.State;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new AutoExportJobProperties();
                }
                Properties.State = value;
            }
        }
    }
}
