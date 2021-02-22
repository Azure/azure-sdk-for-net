// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Models
{
    [CodeGenModel("ChangeableAttributes")]
    public partial class ContentPermissions
    {
        // TODO: why are these nullable?  We should figure out how to make then not nullable
        // TODO: Should these be settable? <-- Yes, should be settable, unless we wanted to handle that via constructor only

        [CodeGenMember("DeleteEnabled")]
        public bool? CanDelete { get; set; }

        [CodeGenMember("WriteEnabled")]
        public bool? CanWrite { get; set; }

        [CodeGenMember("ListEnabled")]
        public bool? CanList { get; set; }

        [CodeGenMember("ReadEnabled")]
        public bool? CanRead { get; set; }
    }
}
