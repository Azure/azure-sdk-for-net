// <copyright file="SqlClientInstrumentation.cs" company="OpenTelemetry Authors">
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
using OpenTelemetry.Instrumentation.SqlClient.Implementation;

namespace OpenTelemetry.Instrumentation.SqlClient;

/// <summary>
/// SqlClient instrumentation.
/// </summary>
internal sealed class SqlClientInstrumentation : IDisposable
{
    internal const string SqlClientDiagnosticListenerName = "SqlClientDiagnosticListener";
#if NET6_0_OR_GREATER
    internal const string SqlClientTrimmingUnsupportedMessage = "Trimming is not yet supported with SqlClient instrumentation.";
#endif
#if NETFRAMEWORK
    private readonly SqlEventSourceListener sqlEventSourceListener;
#else
    private static readonly HashSet<string> DiagnosticSourceEvents = new()
    {
        "System.Data.SqlClient.WriteCommandBefore",
        "Microsoft.Data.SqlClient.WriteCommandBefore",
        "System.Data.SqlClient.WriteCommandAfter",
        "Microsoft.Data.SqlClient.WriteCommandAfter",
        "System.Data.SqlClient.WriteCommandError",
        "Microsoft.Data.SqlClient.WriteCommandError",
    };

    private readonly Func<string, object, object, bool> isEnabled = (eventName, _, _)
        => DiagnosticSourceEvents.Contains(eventName);

    private readonly DiagnosticSourceSubscriber diagnosticSourceSubscriber;
#endif

    /// <summary>
    /// Initializes a new instance of the <see cref="SqlClientInstrumentation"/> class.
    /// </summary>
    /// <param name="options">Configuration options for sql instrumentation.</param>
#if NET6_0_OR_GREATER
    [RequiresUnreferencedCode(SqlClientTrimmingUnsupportedMessage)]
#endif
    public SqlClientInstrumentation(
        SqlClientInstrumentationOptions options = null)
    {
#if NETFRAMEWORK
        this.sqlEventSourceListener = new SqlEventSourceListener(options);
#else
        this.diagnosticSourceSubscriber = new DiagnosticSourceSubscriber(
           name => new SqlClientDiagnosticListener(name, options),
           listener => listener.Name == SqlClientDiagnosticListenerName,
           this.isEnabled,
           SqlClientInstrumentationEventSource.Log.UnknownErrorProcessingEvent);
        this.diagnosticSourceSubscriber.Subscribe();
#endif
    }

    /// <inheritdoc/>
    public void Dispose()
    {
#if NETFRAMEWORK
        this.sqlEventSourceListener?.Dispose();
#else
        this.diagnosticSourceSubscriber?.Dispose();
#endif
    }
}
