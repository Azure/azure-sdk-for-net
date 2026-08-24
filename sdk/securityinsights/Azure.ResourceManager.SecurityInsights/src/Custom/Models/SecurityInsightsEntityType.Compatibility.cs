// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    public readonly partial struct SecurityInsightsEntityType
    {
        // TODO: Remove this customization after https://github.com/microsoft/typespec/issues/11708 is fixed.
        /// <summary> Entity represents url in the system. </summary>
        [CodeGenMember("Uri")]
        public static SecurityInsightsEntityType Url { get; } = new SecurityInsightsEntityType(UriValue);
    }
}
