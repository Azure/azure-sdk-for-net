// <copyright file="SqlClientInstrumentationEventSource.cs" company="OpenTelemetry Authors">
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

using System.Diagnostics.Tracing;
using OpenTelemetry.Internal;

namespace OpenTelemetry.Instrumentation.SqlClient.Implementation;

/// <summary>
/// EventSource events emitted from the project.
/// </summary>
[EventSource(Name = "OpenTelemetry-Instrumentation-SqlClient")]
internal sealed class SqlClientInstrumentationEventSource : EventSource
{
    public static SqlClientInstrumentationEventSource Log = new();

    [NonEvent]
    public void UnknownErrorProcessingEvent(string handlerName, string eventName, Exception ex)
    {
        if (this.IsEnabled(EventLevel.Error, EventKeywords.All))
        {
            this.UnknownErrorProcessingEvent(handlerName, eventName, ex.ToInvariantString());
        }
    }

    [Event(1, Message = "Unknown error processing event '{1}' from handler '{0}', Exception: {2}", Level = EventLevel.Error)]
    public void UnknownErrorProcessingEvent(string handlerName, string eventName, string ex)
    {
        this.WriteEvent(1, handlerName, eventName, ex);
    }

    [Event(2, Message = "Current Activity is NULL in the '{0}' callback. Span will not be recorded.", Level = EventLevel.Warning)]
    public void NullActivity(string eventName)
    {
        this.WriteEvent(2, eventName);
    }

    [Event(3, Message = "Payload is NULL in event '{1}' from handler '{0}', span will not be recorded.", Level = EventLevel.Warning)]
    public void NullPayload(string handlerName, string eventName)
    {
        this.WriteEvent(3, handlerName, eventName);
    }

    [Event(4, Message = "Payload is invalid in event '{1}' from handler '{0}', span will not be recorded.", Level = EventLevel.Warning)]
    public void InvalidPayload(string handlerName, string eventName)
    {
        this.WriteEvent(4, handlerName, eventName);
    }

    [NonEvent]
    public void EnrichmentException(Exception ex)
    {
        if (this.IsEnabled(EventLevel.Error, EventKeywords.All))
        {
            this.EnrichmentException(ex.ToInvariantString());
        }
    }

    [Event(5, Message = "Enrichment threw exception. Exception {0}.", Level = EventLevel.Error)]
    public void EnrichmentException(string exception)
    {
        this.WriteEvent(5, exception);
    }

    [Event(6, Message = "Command is filtered out. Activity {0}", Level = EventLevel.Verbose)]
    public void CommandIsFilteredOut(string activityName)
    {
        this.WriteEvent(6, activityName);
    }

    [NonEvent]
    public void CommandFilterException(Exception ex)
    {
        if (this.IsEnabled(EventLevel.Error, EventKeywords.All))
        {
            this.CommandFilterException(ex.ToInvariantString());
        }
    }

    [Event(7, Message = "Command filter threw exception. Command will not be collected. Exception {0}.", Level = EventLevel.Error)]
    public void CommandFilterException(string exception)
    {
        this.WriteEvent(7, exception);
    }
}
