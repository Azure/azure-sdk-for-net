// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.StorageCache.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.StorageCache
{
    public partial class AutoExportJobData : TrackedResourceData
    {
        // This custom property preserves the previous setter for source compatibility, but service status is read-only.
        /// <summary>
        /// The operational state of auto export. InProgress indicates the export is running. Disabling indicates the user has requested to disable the export but the disabling is still in progress. Disabled indicates auto export has been disabled. DisableFailed indicates the disabling has failed. Failed means the export was unable to continue, due to a fatal error.
        /// The setter does not work because this service-defined status is not meant to be settable.
        /// </summary>
        [CodeGenMember("State")]
        public AutoExportStatusType? State
        {
            get
            {
                return Properties is null ? default : Properties.State;
            }
            [EditorBrowsable(EditorBrowsableState.Never)]
            [Obsolete("This setter does not work because this service-defined status is not meant to be settable.", false)]
            set
            {
            }
        }
    }
}
