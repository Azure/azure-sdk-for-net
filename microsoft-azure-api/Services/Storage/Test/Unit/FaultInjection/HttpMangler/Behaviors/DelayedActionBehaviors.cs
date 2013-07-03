// -----------------------------------------------------------------------------------------
// <copyright file="DelayedActionBehaviors.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using Fiddler;
using System;
using System.Timers;

namespace Microsoft.WindowsAzure.Test.Network.Behaviors
{
    /// <summary>
    /// Factory for Behaviours to execute an action based on a time or network based delay
    /// </summary>
    public static class DelayedActionBehaviors
    {
        /// <summary>
        /// AbortSession returns an action which Aborts a Session
        /// </summary>
        /// <returns>The relevant action.</returns>
        public static Action<Session> AbortSession()
        {
            return session => session.Abort();
        }

        /// <summary>
        /// EndSessionWithTCPReset returns an action which ends a session by sending a tcp reset.
        /// </summary>
        /// <returns>The relevant action.</returns>
        public static Action<Session> EndSessionWithTCPReset()
        {
            return session => session.oRequest.pipeClient.EndWithRST();
        }

        /// <summary>
        /// Executes a given action after a given number of ms.
        /// </summary>
        /// <param name="action">The action to execute.</param>
        /// <param name="delayInMs">The delay in MS.</param>
        /// <param name="selector">The predicate controlling when to tamper with the request.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior ExecuteAfter(Action<Session> action, int delayInMs, Func<Session, bool> selector, BehaviorOptions options = null)
        {
            return new DelayedActionBehavior(action, delayInMs, null, selector, options);
        }

        /// <summary>
        /// Aborts an Session after a given number of ms.
        /// </summary>
        /// <param name="delayInMs">The delay in MS.</param>
        /// <param name="selector">The predicate controlling when to tamper with the request.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior AbortRequestAfter(int delayInMs, Func<Session, bool> selector, BehaviorOptions options = null)
        {
            return ExecuteAfter(AbortSession(), delayInMs, selector, options);
        }

        /// <summary>
        /// Sends a TCP reset after a given number of ms.
        /// </summary>
        /// <param name="delayInMs">The delay in MS.</param>
        /// <param name="selector">The predicate controlling when to tamper with the request.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior SendTCPResetAfter(int delayInMs, Func<Session, bool> selector, BehaviorOptions options = null)
        {
            return ExecuteAfter(EndSessionWithTCPReset(), delayInMs, selector, options);
        }

        /// <summary>
        /// Helper class for DelayedActions
        /// </summary>
        private class DelayedActionBehavior : ProxyBehavior
        {
            private const int POLLING_INTERVAL = 100;

            /// <summary>
            /// Initializes a new instance of the DelayedActionBehavior class.
            /// </summary>
            /// <param name="action"> The Action to execute after the delay</param>
            /// <param name="delayInMs">The time in milliseconds to delay the request.</param>
            /// <param name="pollingSelector">The interval in ms to poll. For single backoff delays this is the backoff in ms.</param>
            /// <param name="selector">The predicate controlling when to delay the request.</param>
            /// <param name="options">The options controlling the behavior.</param>
            public DelayedActionBehavior(Action<Session> action, int? delayInMs, Func<Session, bool> pollingSelector = null, Func<Session, bool> selector = null, BehaviorOptions options = null)
                : base((session) => DelayAction(session, action, delayInMs, pollingSelector), selector, options, TriggerType.BeforeRequest)
            {
            }

            private static void DelayAction(Session inSession, Action<Session> action, int? pollingInterval, Func<Session, bool> pollingSelector)
            {
                pollingSelector = pollingSelector ?? Selectors.Always();
                pollingInterval = pollingInterval ?? POLLING_INTERVAL;

                Timer delayTimer = new Timer()
                {
                    AutoReset = false,
                    Interval = pollingInterval.Value
                };

                delayTimer.Elapsed += (sender, obj) =>
                {
                    if (pollingSelector(inSession))
                    {
                        delayTimer.Stop();
                        delayTimer.Dispose();
                        action(inSession);
                    }
                    else
                    {
                        delayTimer.Start();
                    }
                };

                delayTimer.Start();
            }
        }
    }
}
