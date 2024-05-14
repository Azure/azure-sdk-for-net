// <copyright file="DiagnosticSourceListener.cs" company="OpenTelemetry Authors">
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

using System.Diagnostics;
using OpenTelemetry.Internal;

namespace OpenTelemetry.Instrumentation;

internal sealed class DiagnosticSourceListener : IObserver<KeyValuePair<string, object>>
{
    private readonly ListenerHandler handler;

    private readonly Action<string, string, Exception> logUnknownException;

    public DiagnosticSourceListener(ListenerHandler handler, Action<string, string, Exception> logUnknownException)
    {
        Guard.ThrowIfNull(handler);

        this.handler = handler;
        this.logUnknownException = logUnknownException;
    }

    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(KeyValuePair<string, object> value)
    {
        if (!this.handler.SupportsNullActivity && Activity.Current == null)
        {
            return;
        }

        try
        {
            this.handler.OnEventWritten(value.Key, value.Value);
        }
        catch (Exception ex)
        {
            this.logUnknownException?.Invoke(this.handler?.SourceName, value.Key, ex);
        }
    }
}
