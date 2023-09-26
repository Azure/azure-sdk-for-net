// <copyright file="AspNetCoreMetrics.cs" company="OpenTelemetry Authors">
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
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using OpenTelemetry.Instrumentation.AspNetCore.Implementation;
using OpenTelemetry.Internal;

namespace OpenTelemetry.Instrumentation.AspNetCore
{
    /// <summary>
    /// Asp.Net Core Requests instrumentation.
    /// </summary>
    internal sealed class AspNetCoreMetrics : IDisposable
    {
        internal static readonly AssemblyName AssemblyName = typeof(HttpInListener).Assembly.GetName();
        internal static readonly string InstrumentationName = AssemblyName.Name;
        internal static readonly string InstrumentationVersion = AssemblyName.Version.ToString();

        private static readonly HashSet<string> DiagnosticSourceEvents = new()
        {
            "Microsoft.AspNetCore.Hosting.HttpRequestIn",
            "Microsoft.AspNetCore.Hosting.HttpRequestIn.Start",
            "Microsoft.AspNetCore.Hosting.HttpRequestIn.Stop",
        };

        private readonly Func<string, object, object, bool> isEnabled = (eventName, _, _)
            => DiagnosticSourceEvents.Contains(eventName);

        private readonly DiagnosticSourceSubscriber diagnosticSourceSubscriber;
        private readonly Meter meter;

        internal AspNetCoreMetrics(AspNetCoreMetricsInstrumentationOptions options)
        {
            Guard.ThrowIfNull(options);
            this.meter = new Meter(InstrumentationName, InstrumentationVersion);
            var metricsListener = new HttpInMetricsListener("Microsoft.AspNetCore", this.meter, options);
            this.diagnosticSourceSubscriber = new DiagnosticSourceSubscriber(metricsListener, this.isEnabled);
            this.diagnosticSourceSubscriber.Subscribe();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.diagnosticSourceSubscriber?.Dispose();
            this.meter?.Dispose();
        }
    }
}
