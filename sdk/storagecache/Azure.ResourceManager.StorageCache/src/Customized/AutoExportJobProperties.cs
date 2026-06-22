// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.StorageCache.Models
{
    internal partial class AutoExportJobProperties
    {
        // status is read-only in TypeSpec, but the previous C# surface allowed State to be set.
        [CodeGenMember("Status")]
        internal AutoExportJobPropertiesStatus Status { get; set; }

        [CodeGenMember("State")]
        public AutoExportStatusType? State
        {
            get
            {
                return Status is null ? default : Status.State;
            }
            set
            {
                if (Status is null)
                {
                    Status = new AutoExportJobPropertiesStatus();
                }
                Status.State = value;
            }
        }
    }
}
