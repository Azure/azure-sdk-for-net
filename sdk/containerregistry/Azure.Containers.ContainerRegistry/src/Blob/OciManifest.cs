﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    [CodeGenModel("OCIManifest")]
    public partial class OciManifest
    {
        /// <summary> Initializes a new instance of OciManifest. </summary>
        public OciManifest()
        {
            Layers = new ChangeTrackingList<OciBlobDescriptor>();
            SchemaVersion = 2;
        }
    }
}
