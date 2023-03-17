// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Specialized
{
    [CodeGenModel("OCIManifest")]
    public partial class OciImageManifest
    {
        /// <summary> Initializes a new instance of OciImageManifest. </summary>
        public OciImageManifest()
        {
            Layers = new ChangeTrackingList<OciBlobDescriptor>();
            SchemaVersion = 2;
        }
    }
}
