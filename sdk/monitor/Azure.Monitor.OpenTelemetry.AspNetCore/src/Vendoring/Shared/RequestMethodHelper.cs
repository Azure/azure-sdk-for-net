// <copyright file="RequestMethodHelper.cs" company="OpenTelemetry Authors">
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

#if NET8_0_OR_GREATER
using System.Collections.Frozen;
#endif
using System.Diagnostics;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Internal;

internal static class RequestMethodHelper
{
    // The value "_OTHER" is used for non-standard HTTP methods.
    // https://github.com/open-telemetry/semantic-conventions/blob/v1.22.0/docs/http/http-spans.md#common-attributes
    public const string OtherHttpMethod = "_OTHER";

#if NET8_0_OR_GREATER
    internal static readonly FrozenDictionary<string, string> KnownMethods;
#else
    internal static readonly Dictionary<string, string> KnownMethods;
#endif

    static RequestMethodHelper()
    {
        var knownMethodSet = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "GET", "GET" },
            { "PUT", "PUT" },
            { "POST", "POST" },
            { "DELETE", "DELETE" },
            { "HEAD", "HEAD" },
            { "OPTIONS", "OPTIONS" },
            { "TRACE", "TRACE" },
            { "PATCH", "PATCH" },
            { "CONNECT", "CONNECT" },
        };

        // KnownMethods ignores case. Use the value returned by the dictionary to have a consistent case.
#if NET8_0_OR_GREATER
        KnownMethods = FrozenDictionary.ToFrozenDictionary(knownMethodSet, StringComparer.OrdinalIgnoreCase);
#else
        KnownMethods = knownMethodSet;
#endif
    }

    public static string GetNormalizedHttpMethod(string method)
    {
        return KnownMethods.TryGetValue(method, out var normalizedMethod)
            ? normalizedMethod
            : OtherHttpMethod;
    }

    public static void SetHttpMethodTag(Activity activity, string method)
    {
        if (KnownMethods.TryGetValue(method, out var normalizedMethod))
        {
            activity?.SetTag(SemanticConventions.AttributeHttpRequestMethod, normalizedMethod);
        }
        else
        {
            activity?.SetTag(SemanticConventions.AttributeHttpRequestMethod, OtherHttpMethod);
            activity?.SetTag(SemanticConventions.AttributeHttpRequestMethodOriginal, method);
        }
    }
}
