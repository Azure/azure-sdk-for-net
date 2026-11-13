// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;

namespace Azure.ResourceManager.DnsResolver
{
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
