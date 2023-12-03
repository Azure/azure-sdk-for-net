// <copyright file="SpanHelper.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using System.Diagnostics;

namespace OpenTelemetry.Trace;

/// <summary>
/// A collection of helper methods to be used when building spans.
/// </summary>
internal static class SpanHelper
{
    /// <summary>
    /// Helper method that populates span properties from http status code according
    /// to https://github.com/open-telemetry/semantic-conventions/blob/main/docs/http/http-spans.md#common-attributes.
    /// </summary>
    /// <param name="kind">The span kind.</param>
    /// <param name="httpStatusCode">Http status code.</param>
    /// <returns>Resolved span <see cref="Status"/> for the Http status code.</returns>
    public static ActivityStatusCode ResolveSpanStatusForHttpStatusCode(ActivityKind kind, int httpStatusCode)
    {
        var lowerBound = kind == ActivityKind.Client ? 400 : 500;
        var upperBound = 599;
        if (httpStatusCode >= lowerBound && httpStatusCode <= upperBound)
        {
            return ActivityStatusCode.Error;
        }

        return ActivityStatusCode.Unset;
    }
}
