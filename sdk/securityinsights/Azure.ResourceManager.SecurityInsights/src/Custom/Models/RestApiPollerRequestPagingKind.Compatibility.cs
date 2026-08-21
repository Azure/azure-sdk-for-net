// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    public readonly partial struct RestApiPollerRequestPagingKind
    {
        // TODO: Remove this customization after https://github.com/microsoft/typespec/issues/11708 is fixed.
        /// <summary> NextPageUrl. </summary>
        [CodeGenMember("NextPageUri")]
        public static RestApiPollerRequestPagingKind NextPageUrl { get; } = new RestApiPollerRequestPagingKind(NextPageUriValue);
    }
}
