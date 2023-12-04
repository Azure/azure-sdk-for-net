// <copyright file="AspNetCoreInstrumentationEventSource.cs" company="OpenTelemetry Authors">
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
using System.Diagnostics.Tracing;
using OpenTelemetry.Internal;

namespace OpenTelemetry.Instrumentation.AspNetCore.Implementation;

/// <summary>
/// EventSource events emitted from the project.
/// </summary>
[EventSource(Name = "OpenTelemetry-Instrumentation-AspNetCore")]
internal sealed class AspNetCoreInstrumentationEventSource : EventSource
{
    public static AspNetCoreInstrumentationEventSource Log = new();

    [NonEvent]
    public void RequestFilterException(string handlerName, string eventName, string operationName, Exception ex)
    {
        if (this.IsEnabled(EventLevel.Error, EventKeywords.All))
        {
            this.RequestFilterException(handlerName, eventName, operationName, ex.ToInvariantString());
        }
    }

    [NonEvent]
    public void EnrichmentException(string handlerName, string eventName, string operationName, Exception ex)
    {
        if (this.IsEnabled(EventLevel.Error, EventKeywords.All))
        {
            this.EnrichmentException(handlerName, eventName, operationName, ex.ToInvariantString());
        }
    }

    [NonEvent]
    public void UnknownErrorProcessingEvent(string handlerName, string eventName, Exception ex)
    {
        if (this.IsEnabled(EventLevel.Error, EventKeywords.All))
        {
            this.UnknownErrorProcessingEvent(handlerName, eventName, ex.ToInvariantString());
        }
    }

    [Event(1, Message = "Payload is NULL, span will not be recorded. HandlerName: '{0}', EventName: '{1}', OperationName: '{2}'.", Level = EventLevel.Warning)]
    public void NullPayload(string handlerName, string eventName, string operationName)
    {
        this.WriteEvent(1, handlerName, eventName, operationName);
    }

    [Event(2, Message = "Request is filtered out. HandlerName: '{0}', EventName: '{1}', OperationName: '{2}'.", Level = EventLevel.Verbose)]
    public void RequestIsFilteredOut(string handlerName, string eventName, string operationName)
    {
        this.WriteEvent(2, handlerName, eventName, operationName);
    }

#if NET6_0_OR_GREATER
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Parameters to this method are primitive and are trimmer safe.")]
#endif
    [Event(3, Message = "Filter threw exception, request will not be collected. HandlerName: '{0}', EventName: '{1}', OperationName: '{2}', Exception: {3}.", Level = EventLevel.Error)]
    public void RequestFilterException(string handlerName, string eventName, string operationName, string exception)
    {
        this.WriteEvent(3, handlerName, eventName, operationName, exception);
    }

#if NET6_0_OR_GREATER
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Parameters to this method are primitive and are trimmer safe.")]
#endif
    [Event(4, Message = "Enrich threw exception. HandlerName: '{0}', EventName: '{1}', OperationName: '{2}', Exception: {3}.", Level = EventLevel.Warning)]
    public void EnrichmentException(string handlerName, string eventName, string operationName, string exception)
    {
        this.WriteEvent(4, handlerName, eventName, operationName, exception);
    }

    [Event(5, Message = "Unknown error processing event '{1}' from handler '{0}', Exception: {2}", Level = EventLevel.Error)]
    public void UnknownErrorProcessingEvent(string handlerName, string eventName, string ex)
    {
        this.WriteEvent(5, handlerName, eventName, ex);
    }
}
