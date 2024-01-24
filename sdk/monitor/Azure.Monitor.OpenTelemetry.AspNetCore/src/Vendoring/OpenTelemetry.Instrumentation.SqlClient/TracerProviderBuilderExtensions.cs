// <copyright file="TracerProviderBuilderExtensions.cs" company="OpenTelemetry Authors">
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

#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry.Instrumentation.SqlClient;
using OpenTelemetry.Instrumentation.SqlClient.Implementation;
using OpenTelemetry.Internal;

namespace OpenTelemetry.Trace;

/// <summary>
/// Extension methods to simplify registering of dependency instrumentation.
/// </summary>
internal static class SqlClient_TracerProviderBuilderExtensions
{
    /// <summary>
    /// Enables SqlClient instrumentation.
    /// </summary>
    /// <param name="builder"><see cref="TracerProviderBuilder"/> being configured.</param>
    /// <returns>The instance of <see cref="TracerProviderBuilder"/> to chain the calls.</returns>
#if NET6_0_OR_GREATER
    [RequiresUnreferencedCode(SqlClientInstrumentation.SqlClientTrimmingUnsupportedMessage)]
#endif
    public static TracerProviderBuilder AddSqlClientInstrumentation(this TracerProviderBuilder builder)
        => AddSqlClientInstrumentation(builder, name: null, configureSqlClientInstrumentationOptions: null);

    /// <summary>
    /// Enables SqlClient instrumentation.
    /// </summary>
    /// <param name="builder"><see cref="TracerProviderBuilder"/> being configured.</param>
    /// <param name="configureSqlClientInstrumentationOptions">Callback action for configuring <see cref="SqlClientInstrumentationOptions"/>.</param>
    /// <returns>The instance of <see cref="TracerProviderBuilder"/> to chain the calls.</returns>
#if NET6_0_OR_GREATER
    [RequiresUnreferencedCode(SqlClientInstrumentation.SqlClientTrimmingUnsupportedMessage)]
#endif
    public static TracerProviderBuilder AddSqlClientInstrumentation(
        this TracerProviderBuilder builder,
        Action<SqlClientInstrumentationOptions> configureSqlClientInstrumentationOptions)
        => AddSqlClientInstrumentation(builder, name: null, configureSqlClientInstrumentationOptions);

    /// <summary>
    /// Enables SqlClient instrumentation.
    /// </summary>
    /// <param name="builder"><see cref="TracerProviderBuilder"/> being configured.</param>
    /// <param name="name">Name which is used when retrieving options.</param>
    /// <param name="configureSqlClientInstrumentationOptions">Callback action for configuring <see cref="SqlClientInstrumentationOptions"/>.</param>
    /// <returns>The instance of <see cref="TracerProviderBuilder"/> to chain the calls.</returns>
#if NET6_0_OR_GREATER
    [RequiresUnreferencedCode(SqlClientInstrumentation.SqlClientTrimmingUnsupportedMessage)]
#endif

    public static TracerProviderBuilder AddSqlClientInstrumentation(
        this TracerProviderBuilder builder,
        string name,
        Action<SqlClientInstrumentationOptions> configureSqlClientInstrumentationOptions)
    {
        Guard.ThrowIfNull(builder);

        name ??= Options.DefaultName;

        builder.ConfigureServices(services =>
        {
            if (configureSqlClientInstrumentationOptions != null)
            {
                services.Configure(name, configureSqlClientInstrumentationOptions);
            }

            services.RegisterOptionsFactory(configuration => new SqlClientInstrumentationOptions(configuration));
        });

        builder.AddInstrumentation(sp =>
        {
            var sqlOptions = sp.GetRequiredService<IOptionsMonitor<SqlClientInstrumentationOptions>>().Get(name);

            return new SqlClientInstrumentation(sqlOptions);
        });

        builder.AddSource(SqlActivitySourceHelper.ActivitySourceName);

        return builder;
    }
}
