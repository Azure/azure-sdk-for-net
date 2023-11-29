// <copyright file="HttpSemanticConventionHelper.cs" company="OpenTelemetry Authors">
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

#nullable enable

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace OpenTelemetry.Internal;

/// <summary>
/// Helper class for Http Semantic Conventions.
/// </summary>
/// <remarks>
/// Due to a breaking change in the semantic convention, affected instrumentation libraries
/// must inspect an environment variable to determine which attributes to emit.
/// This is expected to be removed when the instrumentation libraries reach Stable.
/// <see href="https://github.com/open-telemetry/semantic-conventions/blob/v1.21.0/docs/http/http-spans.md"/>.
/// </remarks>
internal static class HttpSemanticConventionHelper
{
    public const string SemanticConventionOptInKeyName = "OTEL_SEMCONV_STABILITY_OPT_IN";

    [Flags]
    public enum HttpSemanticConvention
    {
        /// <summary>
        /// Instructs an instrumentation library to emit the old experimental HTTP attributes.
        /// </summary>
        Old = 0x1,

        /// <summary>
        /// Instructs an instrumentation library to emit the new, v1.21.0 Http attributes.
        /// </summary>
        New = 0x2,

        /// <summary>
        /// Instructs an instrumentation library to emit both the old and new attributes.
        /// </summary>
        Dupe = Old | New,
    }

    public static HttpSemanticConvention GetSemanticConventionOptIn(IConfiguration configuration)
    {
        Debug.Assert(configuration != null, "configuration was null");

        if (configuration != null && TryGetConfiguredValues(configuration, out var values))
        {
            if (values.Contains("http/dup"))
            {
                return HttpSemanticConvention.Dupe;
            }
            else if (values.Contains("http"))
            {
                return HttpSemanticConvention.New;
            }
        }

        return HttpSemanticConvention.Old;
    }

    private static bool TryGetConfiguredValues(IConfiguration configuration, [NotNullWhen(true)] out HashSet<string>? values)
    {
        try
        {
            var stringValue = configuration[SemanticConventionOptInKeyName];

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                values = null;
                return false;
            }

            var stringValues = stringValue!.Split(separator: new[] { ',', ' ' }, options: StringSplitOptions.RemoveEmptyEntries);
            values = new HashSet<string>(stringValues, StringComparer.OrdinalIgnoreCase);
            return true;
        }
        catch
        {
            values = null;
            return false;
        }
    }
}
