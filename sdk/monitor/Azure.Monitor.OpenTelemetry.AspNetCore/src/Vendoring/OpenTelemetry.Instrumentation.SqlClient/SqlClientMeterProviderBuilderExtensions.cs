// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

#if NET
using System.Diagnostics.CodeAnalysis;
#endif
using OpenTelemetry.Instrumentation.SqlClient;
using OpenTelemetry.Instrumentation.SqlClient.Implementation;
using OpenTelemetry.Internal;

namespace OpenTelemetry.Metrics;

/// <summary>
/// Extension methods to simplify registering of dependency instrumentation.
/// </summary>
internal static class SqlClientMeterProviderBuilderExtensions
{
    /// <summary>
    /// Enables SqlClient instrumentation.
    /// </summary>
    /// <param name="builder"><see cref="MeterProviderBuilder"/> being configured.</param>
    /// <returns>The instance of <see cref="MeterProviderBuilder"/> to chain the calls.</returns>
#if NET
    [RequiresUnreferencedCode(SqlClientInstrumentation.SqlClientTrimmingUnsupportedMessage)]
#endif
    public static MeterProviderBuilder AddSqlClientInstrumentation(this MeterProviderBuilder builder)
    {
        Guard.ThrowIfNull(builder);

        builder.AddInstrumentation(sp =>
        {
            return SqlClientInstrumentation.AddMetricHandle();
        });

        builder.AddMeter(SqlActivitySourceHelper.MeterName);

        return builder;
    }
}
