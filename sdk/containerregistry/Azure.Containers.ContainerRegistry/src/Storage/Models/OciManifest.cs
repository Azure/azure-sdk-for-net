﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Storage.Models
{
    [CodeGenModel("OCIManifest")]
    public partial class OciManifest
    {
        /// <summary> V2 image config descriptor. </summary>
        [CodeGenMember("Config")]
        public ContentDescriptor ConfigDescriptor { get; set; }
    }
}
