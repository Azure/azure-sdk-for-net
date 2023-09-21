// <copyright file="AspNetCoreInstrumentation.cs" company="OpenTelemetry Authors">
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
using OpenTelemetry.Instrumentation.AspNetCore.Implementation;

namespace OpenTelemetry.Instrumentation.AspNetCore
{
    /// <summary>
    /// Asp.Net Core Requests instrumentation.
    /// </summary>
    internal sealed class AspNetCoreInstrumentation : IDisposable
    {
        private static readonly HashSet<string> DiagnosticSourceEvents = new()
        {
            "Microsoft.AspNetCore.Hosting.HttpRequestIn",
            "Microsoft.AspNetCore.Hosting.HttpRequestIn.Start",
            "Microsoft.AspNetCore.Hosting.HttpRequestIn.Stop",
            "Microsoft.AspNetCore.Mvc.BeforeAction",
            "Microsoft.AspNetCore.Diagnostics.UnhandledException",
            "Microsoft.AspNetCore.Hosting.UnhandledException",
        };

        private readonly Func<string, object, object, bool> isEnabled = (eventName, _, _)
            => DiagnosticSourceEvents.Contains(eventName);

        private readonly DiagnosticSourceSubscriber diagnosticSourceSubscriber;

        public AspNetCoreInstrumentation(HttpInListener httpInListener)
        {
            this.diagnosticSourceSubscriber = new DiagnosticSourceSubscriber(httpInListener, this.isEnabled);
            this.diagnosticSourceSubscriber.Subscribe();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.diagnosticSourceSubscriber?.Dispose();
        }
    }
}
