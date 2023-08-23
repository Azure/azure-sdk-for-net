#pragma warning disable SA1636
// <copyright file="DiagnosticSourceSubscriber.cs" company="OpenTelemetry Authors">
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
using System.Diagnostics;
using System.Threading;
using OpenTelemetry.Instrumentation.Http.Implementation;
using OpenTelemetry.Internal;

namespace OpenTelemetry.Instrumentation;

internal sealed class DiagnosticSourceSubscriber : IDisposable, IObserver<DiagnosticListener>
{
    private readonly List<IDisposable>? listenerSubscriptions;
    private readonly Func<string, ListenerHandler>? _handlerFactory;
    private readonly Func<DiagnosticListener, bool>? diagnosticSourceFilter;
    private readonly Func<string, object?, object?, bool>? isEnabledFilter;
    private readonly Action<string?, string, Exception>? logUnknownException;
    private long disposed;
    private IDisposable? allSourcesSubscription;
    private HttpHandlerDiagnosticListener? _httpHandlerDiagnosticListener;
    private Func<string, object, object, bool>? _isEnabledNet7OrGreater;
    private Action<string, string, Exception>? _unknownErrorProcessingEvent;

    public DiagnosticSourceSubscriber(
        ListenerHandler handler,
        Func<string, object?, object?, bool>? isEnabledFilter,
        Action<string?, string, Exception>? logUnknownException)
        : this(_ => handler, value => handler.SourceName == value.Name, isEnabledFilter, logUnknownException)
    {
    }

    public DiagnosticSourceSubscriber(
        Func<string, ListenerHandler> handlerFactory,
        Func<DiagnosticListener, bool> diagnosticSourceFilter,
        Func<string, object?, object?, bool>? isEnabledFilter,
        Action<string?, string, Exception>? logUnknownException)
    {
        Guard.ThrowIfNull(handlerFactory);

        this.listenerSubscriptions = new List<IDisposable>();
        this._handlerFactory = handlerFactory;
        this.diagnosticSourceFilter = diagnosticSourceFilter;
        this.isEnabledFilter = isEnabledFilter;
        this.logUnknownException = logUnknownException;
    }

    public DiagnosticSourceSubscriber(HttpHandlerDiagnosticListener httpHandlerDiagnosticListener, Func<string, object, object, bool> isEnabledNet7OrGreater, Action<string, string, Exception> unknownErrorProcessingEvent)
    {
        _httpHandlerDiagnosticListener = httpHandlerDiagnosticListener;
        _isEnabledNet7OrGreater = isEnabledNet7OrGreater;
        _unknownErrorProcessingEvent = unknownErrorProcessingEvent;
    }

    public void Subscribe()
    {
        if (this.allSourcesSubscription == null)
        {
            this.allSourcesSubscription = DiagnosticListener.AllListeners.Subscribe(this);
        }
    }

    public void OnNext(DiagnosticListener value)
    {
        if ((Interlocked.Read(ref this.disposed) == 0) && this.diagnosticSourceFilter != null && this._handlerFactory != null && this.listenerSubscriptions != null && this.diagnosticSourceFilter(value))
        {
            var handler = this._handlerFactory(value.Name);
            var listener = new DiagnosticSourceListener(handler, this.logUnknownException);
            var subscription = this.isEnabledFilter == null ?
                value.Subscribe(listener) :
                value.Subscribe(listener, this.isEnabledFilter);

            lock (this.listenerSubscriptions)
            {
                this.listenerSubscriptions.Add(subscription);
            }
        }
    }

    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (Interlocked.CompareExchange(ref this.disposed, 1, 0) == 1)
        {
            return;
        }

        if (this.listenerSubscriptions != null)
        {
            lock (this.listenerSubscriptions)
            {
                foreach (var listenerSubscription in this.listenerSubscriptions)
                {
                    listenerSubscription?.Dispose();
                }

                this.listenerSubscriptions.Clear();
            }
        }
        this.allSourcesSubscription?.Dispose();
        this.allSourcesSubscription = null;
    }
}
#pragma warning restore SA1636
