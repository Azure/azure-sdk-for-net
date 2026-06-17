// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotHub
{
    public partial class IotHubCertificateDescriptionData
    {
        /// <summary> The entity tag. </summary>
        [CodeGenMember("Etag")]
        public ETag? ETag { get; }
    }
}
