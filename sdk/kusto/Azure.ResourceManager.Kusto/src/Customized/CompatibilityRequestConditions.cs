// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;

namespace Azure.ResourceManager.Kusto
{
    // The previous AutoRest SDK exposed the If-Match / If-None-Match conditional headers as separate
    // string parameters. The TypeSpec generator merges them into a single Azure.MatchConditions
    // parameter, so this helper converts the legacy string values into MatchConditions for the
    // backward-compatible convenience overloads.
    internal static class CompatibilityRequestConditions
    {
        internal static MatchConditions Create(string ifMatch, string ifNoneMatch)
        {
            MatchConditions conditions = null;

            if (ifMatch != null)
            {
                conditions ??= new MatchConditions();
                conditions.IfMatch = new ETag(ifMatch);
            }

            if (ifNoneMatch != null)
            {
                conditions ??= new MatchConditions();
                conditions.IfNoneMatch = new ETag(ifNoneMatch);
            }

            return conditions;
        }
    }
}
