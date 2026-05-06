// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

using System;
using Azure.Core;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This file uses CodeGenMember to rename struct static members to maintain the naming convention from the previous SDK.
    // Reason: The TypeSpec generator concatenates resource type path segments after removing slashes to produce member names
    // (e.g., MicrosoftCdnProfilesEndpoints, MicrosoftCdnProfilesAfdEndpoints),
    // but the old SDK used shorter names (e.g., Endpoints, FrontDoorEndpoints).
    // CodeGenMember attributes map the generated names to the old names to preserve public API naming compatibility.
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
