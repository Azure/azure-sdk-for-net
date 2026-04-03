// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Backward compatibility: old API used ClientIP and Uri instead of ClientIp and Url
    public readonly partial struct WafRankingType
    {
        [CodeGenMember("ClientIp")]
        public static WafRankingType ClientIP { get; } = new WafRankingType(ClientIpValue);

        [CodeGenMember("Url")]
        public static WafRankingType Uri { get; } = new WafRankingType(UrlValue);
    }
}
