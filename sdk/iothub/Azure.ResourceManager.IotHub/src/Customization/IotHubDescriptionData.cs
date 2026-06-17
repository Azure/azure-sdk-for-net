// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.IotHub
{
    public partial class IotHubDescriptionData
    {
        /// <summary> The managed identities for the IotHub. </summary>
        [CodeGenMember("Identity")]
        public ManagedServiceIdentity Identity { get; set; }
    }
}
