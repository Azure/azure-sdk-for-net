// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

using System;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    public readonly partial struct CdnResourceType : IEquatable<CdnResourceType>
    {
        /// <summary>
        /// Microsoft.Cdn/Profiles/Endpoints
        /// </summary>
        [CodeGenMember("MicrosoftCdnProfilesEndpoints")]
        public static CdnResourceType Endpoints { get; } = new CdnResourceType(MicrosoftCdnProfilesEndpointsValue);

        /// <summary>
        /// Microsoft.Cdn/Profiles/AfdEndpoints
        /// </summary>
        [CodeGenMember("MicrosoftCdnProfilesAfdEndpoints")]
        public static CdnResourceType FrontDoorEndpoints { get; } = new CdnResourceType(MicrosoftCdnProfilesAfdEndpointsValue);
    }
}
