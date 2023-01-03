// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Azure.Messaging;
using System.Linq;
using System.Collections.Concurrent;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Call Automation's EventHandler for incoming events for ease of use.
    /// </summary>
    public class CallAutomationEventHandler
    {
        private TimeSpan _exceptionTimeout;
        private EventBacklog _eventBacklog;
        private ConcurrentDictionary<(Type, string), EventHandler<CallAutomationEventArgs>> _ongoingEvents;
        private event EventHandler<CallAutomationEventArgs> _eventReceived;

        internal CallAutomationEventHandler(TimeSpan defaultTimeout = default)
        {
            _exceptionTimeout = defaultTimeout;
            _eventBacklog = new EventBacklog();
            _ongoingEvents = new ConcurrentDictionary<(Type, string), EventHandler<CallAutomationEventArgs>>();
        }

        /// <summary>
        /// Process incoming events. Pass incoming events to get it processed to have other method like WaitForEvent to function.
        /// </summary>
        /// <param name="events">Incoming CloudEvent object.</param>
        public void ProcessEvents(IEnumerable<CloudEvent> events)
        {
            var recievedEvent = CallAutomationEventParser.ParseMany(events.ToArray());
            ProcessEvents(recievedEvent);
        }

        /// <summary>
        /// Process incoming events. Pass incoming events to get it processed to have other method like WaitForEvent to function.
        /// </summary>
        /// <param name="events">Incoming CallAutomationEventBase object.</param>
        public void ProcessEvents(IEnumerable<CallAutomationEventBase> events)
        {
            CallAutomationEventBase recievedEvent = events.FirstOrDefault();

            if (recievedEvent != null)
            {
                string internalEventId = Guid.NewGuid().ToString();
                _ = _eventBacklog.AddEvent(internalEventId, recievedEvent);

                var handlers = Interlocked.CompareExchange(ref _eventReceived, null, null);
                if (handlers != null)
                {
                    // Invoke all handlers registered to Event Handler
                    var args = new CallAutomationEventArgs
                    {
                        eventArgsId = internalEventId,
                        callAutomationEvent = recievedEvent
                    };
                    handlers(this, args);
                }
            }
        }

        /// <summary>
        /// Wait for incoming event. Returns event once event arrives in ProcessEvent method.
        /// </summary>
        /// <param name="eventTypesToWaitFor">List of events type to wait for.</param>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        /// <param name="operationContext">(Optional) Optional operationContext of the method call.</param>
        /// <returns>Returns CallAutomationEvent once matching event arrives.</returns>
        public async Task<CallAutomationEventBase> WaitForEvent(IEnumerable<Type> eventTypesToWaitFor, string callConnectionId, string operationContext = null)
        {
            // initialize awaiter and get event handler of it
            var awaiter = new EventAwaiter(eventTypesToWaitFor, callConnectionId, operationContext, _exceptionTimeout);
            EventHandler<CallAutomationEventArgs> handler = (o, arg) => awaiter.OnEventRecieved(o, arg);

            try
            {
                // register event handler
                _eventReceived += handler;

                // see if events have arrived earlier and saved in backlog
                if (_eventBacklog.GetAndRemoveEvent(eventTypesToWaitFor, callConnectionId, operationContext, out var backlogEvent))
                {
                    awaiter.Dispose();
                    return backlogEvent.Value;
                }
                else
                {
                    // wait for incoming event until timeout exception is arised from awaiter.
                    var matchingEvent = await awaiter.taskSource.Task.ConfigureAwait(false);

                    // matching event found. Remove from EventHandler & Backlogs.
                    _eventReceived -= handler;
                    _eventBacklog.RemoveEvent(matchingEvent.eventArgsId);

                    return matchingEvent.callAutomationEvent;
                }
            }
            catch (Exception)
            {
                _eventReceived -= handler;
                awaiter.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Set Ongoing EventHandler for specific event.
        /// </summary>
        /// <typeparam name="TEvent">Call Automation Event Type.</typeparam>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        /// <param name="eventHandler">EventHandler to be fired when the specified event arrives.</param>
        /// <returns></returns>
        public bool SetOngoingEventHandler<TEvent>(string callConnectionId, Action<TEvent> eventHandler) where TEvent : CallAutomationEventBase
        {
            var ongoingAwaiter = new EventAwaiterOngoing<TEvent>(callConnectionId, eventHandler);
            EventHandler<CallAutomationEventArgs> handler = (o, arg) => ongoingAwaiter.OnEventRecieved(o, arg);

            if (_ongoingEvents.TryAdd((typeof(TEvent), callConnectionId), handler))
            {
                _eventReceived += handler;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Unset Ongoing EventHandler for specific event.
        /// </summary>
        /// <typeparam name="TEvent">Call Automation Event Type.</typeparam>
        /// <param name="callConnectionId">CallConnectionId of the call.</param>
        /// <returns></returns>
        public bool UnsetOngoingEventHandler<TEvent>(string callConnectionId) where TEvent : CallAutomationEventBase
        {
            if (_ongoingEvents.TryRemove((typeof(TEvent), callConnectionId), out var handler))
            {
                _eventReceived += handler;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
