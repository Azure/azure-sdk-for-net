// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Runtime.CompilerServices;

namespace Azure.ResourceManager.ContainerServiceFleet
{
    internal static class ETagHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ETag? ToETag(string value) => value != null ? new ETag(value) : null;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static MatchConditions ToMatchConditions(string ifMatch, string ifNoneMatch) => new MatchConditions
        {
            IfMatch = ToETag(ifMatch),
            IfNoneMatch = ToETag(ifNoneMatch)
        };
    }
}
