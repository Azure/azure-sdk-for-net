// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Compute.Batch
{
    public partial class ContainerRegistryReference
    {
        /// <summary> Gets or sets the registry server, such as <c>myregistry.azurecr.io</c>. If omitted, the default is <c>docker.io</c>. </summary>
        public string RegistryServerUri { get; set; }
    }
}
