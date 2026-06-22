// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Compute
{
    /// <summary>
    /// Helpers used by backward-compatibility shims that still expose <c>ifMatch</c> / <c>ifNoneMatch</c> as positional string parameters.
    /// </summary>
    internal static class ConditionalRequestExtensions
    {
        /// <summary> Builds a <see cref="MatchConditions"/> from legacy string-typed <c>ifMatch</c> / <c>ifNoneMatch</c> parameters; returns <c>null</c> when both inputs are <c>null</c>. </summary>
        public static MatchConditions BuildMatchConditions(string ifMatch, string ifNoneMatch)
        {
            if (ifMatch == null && ifNoneMatch == null)
            {
                return null;
            }
            return new MatchConditions
            {
                IfMatch = ifMatch != null ? new ETag(ifMatch) : default(ETag?),
                IfNoneMatch = ifNoneMatch != null ? new ETag(ifNoneMatch) : default(ETag?),
            };
        }
    }
}
