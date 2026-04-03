// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Backward compatibility: old API used Uri instead of Url
    public readonly partial struct LogRanking
    {
        [CodeGenMember("Url")]
        public static LogRanking Uri { get; } = new LogRanking(UrlValue);
    }
}
