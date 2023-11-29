// <copyright file="MeterProviderBuilderExtensions.cs" company="OpenTelemetry Authors">
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

#if !NET8_0_OR_GREATER
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenTelemetry.Instrumentation.Http;
using OpenTelemetry.Instrumentation.Http.Implementation;
#endif

using OpenTelemetry.Internal;

namespace OpenTelemetry.Metrics;

/// <summary>
/// Extension methods to simplify registering of HttpClient instrumentation.
/// </summary>
internal static class HttpClient_MeterProviderBuilderExtensions
{
    /// <summary>
    /// Enables HttpClient instrumentation.
    /// </summary>
    /// <param name="builder"><see cref="MeterProviderBuilder"/> being configured.</param>
    /// <returns>The instance of <see cref="MeterProviderBuilder"/> to chain the calls.</returns>
    public static MeterProviderBuilder AddHttpClientInstrumentation(
        this MeterProviderBuilder builder)
    {
        Guard.ThrowIfNull(builder);

#if NET8_0_OR_GREATER
        return builder
            .AddMeter("System.Net.Http")
            .AddMeter("System.Net.NameResolution");
#else
        // Note: Warm-up the status code and method mapping.
        _ = TelemetryHelper.BoxedStatusCodes;
        _ = RequestMethodHelper.KnownMethods;

        builder.ConfigureServices(services =>
        {
            services.RegisterOptionsFactory(configuration => new HttpClientMetricInstrumentationOptions(configuration));
        });

#if NETFRAMEWORK
        builder.AddMeter(HttpWebRequestActivitySource.MeterName);

        if (builder is IDeferredMeterProviderBuilder deferredMeterProviderBuilder)
        {
            deferredMeterProviderBuilder.Configure((sp, builder) =>
            {
                var options = sp.GetRequiredService<IOptionsMonitor<HttpClientMetricInstrumentationOptions>>().Get(Options.DefaultName);

                HttpWebRequestActivitySource.MetricsOptions = options;
            });
        }
#else
        builder.AddMeter(HttpHandlerMetricsDiagnosticListener.MeterName);

        builder.AddInstrumentation(sp => new HttpClientMetrics(
            sp.GetRequiredService<IOptionsMonitor<HttpClientMetricInstrumentationOptions>>().Get(Options.DefaultName)));
#endif
        return builder;
#endif
    }
}
