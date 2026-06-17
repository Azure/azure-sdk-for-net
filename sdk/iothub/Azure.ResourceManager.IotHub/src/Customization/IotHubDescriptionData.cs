// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotHub
{
    public partial class IotHubDescriptionData
    {
        /// <summary> The Etag field is <i>not</i> required. If it is provided in the response body, it must also be provided as a header per the normal ETag convention. </summary>
        [CodeGenMember("Etag")]
        public ETag? ETag { get; set; }

        /// <summary> The managed identities for the IotHub. </summary>
        [CodeGenMember("Identity")]
        public ManagedServiceIdentity Identity { get; set; }
    }
}
