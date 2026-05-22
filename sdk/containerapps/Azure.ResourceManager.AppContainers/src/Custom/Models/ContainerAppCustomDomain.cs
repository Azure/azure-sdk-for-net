// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.AppContainers.Models
{
    public partial class ContainerAppCustomDomain
    {
        // Preserve the shipped convenience constructor that allowed setting CertificateId at construction time.
        /// <summary> Initializes a new instance of <see cref="ContainerAppCustomDomain"/>. </summary>
        /// <param name="name"> Hostname. </param>
        /// <param name="certificateId"> Resource Id of the Certificate to be bound to this hostname. </param>
        public ContainerAppCustomDomain(string name, ResourceIdentifier certificateId)
            : this(name)
        {
            CertificateId = certificateId;
        }
    }
}
