// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace OpenTelemetry.Internal;

/// <summary>
/// Helper class for Database Semantic Conventions.
/// </summary>
/// <remarks>
/// Due to a breaking change in the semantic convention, affected instrumentation libraries
/// must inspect an environment variable to determine which attributes to emit.
/// This is expected to be removed when the instrumentation libraries reach Stable.
/// <see href="https://github.com/open-telemetry/semantic-conventions/blob/v1.28.0/docs/database/database-spans.md"/>.
/// </remarks>
internal static class DatabaseSemanticConventionHelper
{
    internal const string SemanticConventionOptInKeyName = "OTEL_SEMCONV_STABILITY_OPT_IN";
    internal static readonly char[] Separator = [',', ' '];

    [Flags]
    internal enum DatabaseSemanticConvention
    {
        /// <summary>
        /// Instructs an instrumentation library to emit the old experimental Database attributes.
        /// </summary>
        Old = 0x1,

        /// <summary>
        /// Instructs an instrumentation library to emit the new, v1.28.0 Database attributes.
        /// </summary>
        New = 0x2,

        /// <summary>
        /// Instructs an instrumentation library to emit both the old and new attributes.
        /// </summary>
        Dupe = Old | New,
    }

    public static DatabaseSemanticConvention GetSemanticConventionOptIn(IConfiguration configuration)
    {
        if (TryGetConfiguredValues(configuration, out var values))
        {
            if (values.Contains("database/dup"))
            {
                return DatabaseSemanticConvention.Dupe;
            }
            else if (values.Contains("database"))
            {
                return DatabaseSemanticConvention.New;
            }
        }

        return DatabaseSemanticConvention.Old;
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

            var stringValues = stringValue!.Split(separator: Separator, options: StringSplitOptions.RemoveEmptyEntries);
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
