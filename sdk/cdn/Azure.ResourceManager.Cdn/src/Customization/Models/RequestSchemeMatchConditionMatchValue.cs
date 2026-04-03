// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Cdn.Models
{
    // Backward compatibility: old API used Http/Https instead of HTTP/HTTPS
    public readonly partial struct RequestSchemeMatchConditionMatchValue
    {
        [CodeGenMember("HTTP")]
        public static RequestSchemeMatchConditionMatchValue Http { get; } = new RequestSchemeMatchConditionMatchValue(HTTPValue);

        [CodeGenMember("HTTPS")]
        public static RequestSchemeMatchConditionMatchValue Https { get; } = new RequestSchemeMatchConditionMatchValue(HTTPSValue);
    }
}
