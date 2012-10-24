// -----------------------------------------------------------------------------------------
// <copyright file="DelayBehaviors.cs" company="Microsoft">
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


namespace Microsoft.WindowsAzure.Test.Network.Behaviors
{
    using System;
    using System.Threading;
    using Fiddler;

    /// <summary>
    /// DelayBehaviors control whether the sessions should be delayed before being delivered to user code.
    /// </summary>
    public static class DelayBehaviors
    {
        /// <summary>
        /// DelayAllRequests returns a behavior that delays all requests the specified number of milliseconds.
        /// </summary>
        /// <param name="delayInMs">The time in milliseconds to delay the request.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DelayAllRequests(int delayInMs, BehaviorOptions options = null)
        {
            return new DelayRequestBehavior(delayInMs, null, options);
        }

        /// <summary>
        /// DelayAllRequestsIf returns a behavior that delays requests the specified number of milliseconds.
        /// </summary>
        /// <param name="delayInMs">The time in milliseconds to delay the request.</param>
        /// <param name="selector">The predicate controlling when to delay the request.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DelayAllRequestsIf(int delayInMs, Func<Session, bool> selector, BehaviorOptions options = null)
        {
            return new DelayRequestBehavior(delayInMs, selector, options);
        }

        /// <summary>
        /// DelayAllRequestsUntil returns a behavior that delays all requests the specified number of milliseconds.
        /// </summary>
        /// <param name="delayInMs">The time in milliseconds to delay the request.</param>
        /// <param name="expiry">The DateTime at which to stop delaying requests.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DelayAllRequestsUntil(int delayInMs, DateTime expiry)
        {
            return new DelayRequestBehavior(delayInMs, expiry);
        }

        /// <summary>
        /// DelayAllRequestsUntilIf returns a behavior that delays all requests the specified number of milliseconds.
        /// </summary>
        /// <param name="delayInMs">The time in milliseconds to delay the request.</param>
        /// <param name="expiry">The DateTime at which to stop delaying requests.</param>
        /// <param name="selector">The predicate controlling when to delay the request.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DelayAllRequestsUntilIf(int delayInMs, DateTime expiry, Func<Session, bool> selector)
        {
            return new DelayRequestBehavior(delayInMs, expiry, selector);
        }

        /// <summary>
        /// DelayNRequests returns a behavior that delays requests the specified number of milliseconds.
        /// </summary>
        /// <param name="delayInMs">The time in milliseconds to delay the request.</param>
        /// <param name="n">The maximum number of sessions which should be delayed.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DelayNRequests(int delayInMs, int n)
        {
            return new DelayRequestBehavior(delayInMs, n);
        }

        /// <summary>
        /// DelayNRequestsIf returns a behavior that delays requests the specified number of milliseconds.
        /// </summary>
        /// <param name="delayInMs">The time in milliseconds to delay the request.</param>
        /// <param name="n">The maximum number of sessions which should be delayed.</param>
        /// <param name="selector">The predicate controlling when to delay the request.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DelayNRequestsIf(int delayInMs, int n, Func<Session, bool> selector)
        {
            return new DelayRequestBehavior(delayInMs, n, selector);
        }

        /// <summary>
        /// DelayAllResponses returns a behavior that delays all responses the specified number of milliseconds.
        /// </summary>
        /// <param name="delayInMs">The time in milliseconds to delay the response.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DelayAllResponses(int delayInMs, BehaviorOptions options = null)
        {
            return new DelayResponseBehavior(delayInMs, null, options);
        }

        /// <summary>
        /// DelayAllResponsesIf returns a behavior that delays responses the specified number of milliseconds.
        /// </summary>
        /// <param name="delayInMs">The time in milliseconds to delay the response.</param>
        /// <param name="selector">The predicate controlling when to delay the response.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DelayAllResponsesIf(int delayInMs, Func<Session, bool> selector, BehaviorOptions options = null)
        {
            return new DelayResponseBehavior(delayInMs, selector, options);
        }

        /// <summary>
        /// DelayAllResponsesUntil returns a behavior that delays responses the specified number of milliseconds.
        /// </summary>
        /// <param name="delayInMs">The time in milliseconds to delay the response.</param>
        /// <param name="expiry">The DateTime at which to stop delaying responses.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DelayAllResponsesUntil(int delayInMs, DateTime expiry)
        {
            return new DelayResponseBehavior(delayInMs, expiry);
        }

        /// <summary>
        /// DelayAllResponsesUntilIf returns a behavior that delays responses the specified number of milliseconds.
        /// </summary>
        /// <param name="delayInMs">The time in milliseconds to delay the response.</param>
        /// <param name="expiry">The DateTime at which to stop delaying responses.</param>
        /// <param name="selector">The predicate controlling when to delay the response.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DelayAllResponsesUntilIf(int delayInMs, DateTime expiry, Func<Session, bool> selector)
        {
            return new DelayResponseBehavior(delayInMs, expiry, selector);
        }

        /// <summary>
        /// DelayNResponses returns a behavior that delays responses the specified number of milliseconds.
        /// </summary>
        /// <param name="delayInMs">The time in milliseconds to delay the response.</param>
        /// <param name="n">The maximum number of sessions which should be delayed.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DelayNResponses(int delayInMs, int n)
        {
            return new DelayResponseBehavior(delayInMs, n);
        }

        /// <summary>
        /// DelayNResponsesIf returns a behavior that delays responses the specified number of milliseconds.
        /// </summary>
        /// <param name="delayInMs">The time in milliseconds to delay the response.</param>
        /// <param name="n">The maximum number of sessions which should be delayed.</param>
        /// <param name="selector">The predicate controlling when to delay the response.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior DelayNResponsesIf(int delayInMs, int n, Func<Session, bool> selector)
        {
            return new DelayResponseBehavior(delayInMs, n, selector);
        }

        /// <summary>
        /// Helper class for request (outgoing) delays.
        /// </summary>
        private class DelayRequestBehavior : ProxyBehavior
        {
            /// <summary>
            /// Initializes a new instance of the DelayRequestBehavior class.
            /// </summary>
            /// <param name="delayInMs">The time in milliseconds to delay the request.</param>
            /// <param name="selector">The predicate controlling when to delay the request.</param>
            /// <param name="options">The options controlling the behavior.</param>
            public DelayRequestBehavior(int delayInMs, Func<Session, bool> selector = null, BehaviorOptions options = null)
                : base(session => session.oRequest.pipeClient.TransmitDelay = delayInMs, selector, options, TriggerType.BeforeRequest)
            {
            }

            /// <summary>
            /// Initializes a new instance of the DelayRequestBehavior class.
            /// </summary>
            /// <param name="delayInMs">The time in milliseconds to delay the request.</param>
            /// <param name="n">The maximum number of sessions which should be delayed.</param>
            /// <param name="selector">The predicate controlling when to delay the request.</param>
            public DelayRequestBehavior(int delayInMs, int n, Func<Session, bool> selector = null)
                : this(delayInMs, selector, new BehaviorOptions(maximumRemainingSessions: n))
            {
            }

            /// <summary>
            /// Initializes a new instance of the DelayRequestBehavior class.
            /// </summary>
            /// <param name="delayInMs">The time in milliseconds to delay the request.</param>
            /// <param name="expiry">The DateTime at which to no longer delay requests.</param>
            /// <param name="selector">The predicate controlling when to delay the request.</param>
            public DelayRequestBehavior(int delayInMs, DateTime expiry, Func<Session, bool> selector = null)
                : this(delayInMs, selector, new BehaviorOptions(expiry))
            {
            }
        }

        /// <summary>
        /// Helper class for response (incoming) delays.
        /// </summary>
        private class DelayResponseBehavior : ProxyBehavior
        {
            /// <summary>
            /// Initializes a new instance of the DelayResponseBehavior class.
            /// </summary>
            /// <param name="delayInMs">The time in milliseconds to delay the response.</param>
            /// <param name="selector">The predicate controlling when to delay the response.</param>
            /// <param name="options">The options controlling the behavior.</param>
            public DelayResponseBehavior(int delayInMs, Func<Session, bool> selector = null, BehaviorOptions options = null)
                : base(session => session.oResponse.pipeServer.TransmitDelay = delayInMs, selector, options, TriggerType.BeforeResponse)
            {
            }

            /// <summary>
            /// Initializes a new instance of the DelayResponseBehavior class.
            /// </summary>
            /// <param name="delayInMs">The time in milliseconds to delay the response.</param>
            /// <param name="n">The maximum number of sessions which should be delayed.</param>
            /// <param name="selector">The predicate controlling when to delay the response.</param>
            public DelayResponseBehavior(int delayInMs, int n, Func<Session, bool> selector = null)
                : this(delayInMs, selector, new BehaviorOptions(maximumRemainingSessions: n))
            {
            }

            /// <summary>
            /// Initializes a new instance of the DelayResponseBehavior class.
            /// </summary>
            /// <param name="delayInMs">The time in milliseconds to delay the response.</param>
            /// <param name="expiry">The DateTime at which to no longer delay responses.</param>
            /// <param name="selector">The predicate controlling when to delay the response.</param>
            public DelayResponseBehavior(int delayInMs, DateTime expiry, Func<Session, bool> selector = null)
                : this(delayInMs, selector, new BehaviorOptions(expiry))
            {
            }
        }
    }
}
