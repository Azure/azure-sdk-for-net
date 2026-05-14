// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class ManagedInstanceServerTrustCertificateResource : ServerTrustCertificateResource
    {
        public static new readonly ResourceType ResourceType = ServerTrustCertificateResource.ResourceType;

        protected ManagedInstanceServerTrustCertificateResource()
        {
        }

        internal ManagedInstanceServerTrustCertificateResource(ArmClient client, ServerTrustCertificateData data) : base(client, data)
        {
        }

        internal ManagedInstanceServerTrustCertificateResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }
    }
}
