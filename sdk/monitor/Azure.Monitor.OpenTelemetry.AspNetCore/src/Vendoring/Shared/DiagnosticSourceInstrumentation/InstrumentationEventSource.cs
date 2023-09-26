// <copyright file="InstrumentationEventSource.cs" company="OpenTelemetry Authors">
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
using System.Diagnostics.Tracing;
using OpenTelemetry.Internal;
#pragma warning restore IDE0005

namespace OpenTelemetry.Instrumentation;

/// <summary>
/// EventSource events emitted from the project.
/// </summary>
[EventSource(Name = "OpenTelemetry-Instrumentation")]
internal sealed class InstrumentationEventSource : EventSource
{
    public static InstrumentationEventSource Log = new();

    [Event(1, Message = "Current Activity is NULL in the '{0}' callback. Activity will not be recorded.", Level = EventLevel.Warning)]
    public void NullActivity(string eventName)
    {
        this.WriteEvent(1, eventName);
    }

    [NonEvent]
    public void UnknownErrorProcessingEvent(string handlerName, string eventName, Exception ex)
    {
        if (this.IsEnabled(EventLevel.Error, EventKeywords.All))
        {
            this.UnknownErrorProcessingEvent(handlerName, eventName, ex.ToInvariantString());
        }
    }

    [Event(2, Message = "Unknown error processing event '{1}' from handler '{0}', Exception: {2}", Level = EventLevel.Error)]
    public void UnknownErrorProcessingEvent(string handlerName, string eventName, string ex)
    {
        this.WriteEvent(2, handlerName, eventName, ex);
    }
}
