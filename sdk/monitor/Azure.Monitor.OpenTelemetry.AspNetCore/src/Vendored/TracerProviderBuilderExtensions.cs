#pragma warning disable SA1636

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

using System;
using Microsoft.Extensions.Options;
using OpenTelemetry.Instrumentation.Http;
using OpenTelemetry.Instrumentation.Http.Implementation;
using OpenTelemetry.Internal;

namespace OpenTelemetry.Trace;

/// <summary>
/// Extension methods to simplify registering of HttpClient instrumentation.
/// </summary>
internal static class TracerProviderBuilderExtensions
{
    /// <summary>
    /// Enables HttpClient instrumentation.
    /// </summary>
    /// <param name="builder"><see cref="TracerProviderBuilder"/> being configured.</param>
    /// <param name="options">options</param>
    /// <returns>The instance of <see cref="TracerProviderBuilder"/> to chain the calls.</returns>
    public static TracerProviderBuilder AddHttpClientInstrumentation(
        this TracerProviderBuilder builder,
        HttpClientInstrumentationOptions options)
    {
        Guard.ThrowIfNull(builder);

        // Note: Warm-up the status code mapping.
        _ = TelemetryHelper.BoxedStatusCodes;

#if NETFRAMEWORK
        builder.AddSource(HttpWebRequestActivitySource.ActivitySourceName);

        if (builder is IDeferredTracerProviderBuilder deferredTracerProviderBuilder)
        {
            deferredTracerProviderBuilder.Configure((sp, builder) =>
            {
                HttpWebRequestActivitySource.Options = options;
            });
        }
#else
        AddHttpClientInstrumentationSource(builder);

        builder.AddInstrumentation(sp =>
        {
            Type? httpClientOptions = Type.GetType("OpenTelemetry.Instrumentation.Http.HttpClientInstrumentationOptions, OpenTelemetry.Instrumentation.Http");
            bool optionsConfigRegistered = httpClientOptions == null || sp.GetService(typeof(IConfigureOptions<>).MakeGenericType(httpClientOptions)) == null;
            return new HttpClientInstrumentation(options, optionsConfigRegistered);
        });
#endif
        return builder;
    }

#if !NETFRAMEWORK
    internal static void AddHttpClientInstrumentationSource(
        this TracerProviderBuilder builder)
    {
        if (HttpHandlerDiagnosticListener.IsNet7OrGreater)
        {
            builder.AddSource(HttpHandlerDiagnosticListener.HttpClientActivitySourceName);
        }
        else
        {
            builder.AddSource(HttpHandlerDiagnosticListener.ActivitySourceName);
            builder.AddLegacySource("System.Net.Http.HttpRequestOut");
        }
    }
#endif
}
#pragma warning restore SA1636
