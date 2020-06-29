// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Iot.Hub.Service
{
    /// <summary>
    /// Helper functions for using the <see cref="IfMatchPrecondition"/> enum.
    /// </summary>
    internal static class IfMatchPreconditionExtensions
    {
        /// <summary>
        /// Get the ifMatch header value for an HTTP request that targets a particular service resource.
        /// </summary>
        /// <param name="precondition">The user supplied if match precondition.</param>
        /// <param name="ETag">The ETag of the resource that the HTTP request is targeting.</param>
        /// <returns>The ifMatch header value.</returns>
        internal static string GetIfMatchHeaderValue(IfMatchPrecondition precondition, string ETag)
        {
            return precondition switch
            {
                IfMatchPrecondition.IfMatch => $"\"{ETag}\"",
                IfMatchPrecondition.UnconditionalIfMatch => "*",
                _ => null,
            };
        }
    }
}
