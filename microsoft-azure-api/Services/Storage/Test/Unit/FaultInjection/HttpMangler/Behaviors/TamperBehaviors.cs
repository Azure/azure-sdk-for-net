// -----------------------------------------------------------------------------------------
// <copyright file="TamperBehaviors.cs" company="Microsoft">
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

//-----------------------------------------------------------------------
// <copyright file="TamperBehaviors.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <summary>
//     This set of behaviors modify the outgoing (request) and incoming (response) data streams.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Test.Network.Behaviors
{
    using System;
    using Fiddler;

    /// <summary>
    /// TamperBehaviors modify the outgoing (request) and incoming (response) data streams.
    /// </summary>
    public class TamperBehaviors
    {
        /// <summary>
        /// AddHeaderToRequest returns an action which adds an HTTP header to a request.
        /// </summary>
        /// <param name="headerName">The name of the header to be added.</param>
        /// <param name="headerValue">The value of the header to be added.</param>
        /// <returns>The relevant action.</returns>
        public static Action<Session> AddHeaderToRequest(string headerName, string headerValue)
        {
            return session => session.oRequest[headerName] = headerValue;
        }

        /// <summary>
        /// DeleteHeaderFromRequest removes the given header from the request.
        /// </summary>
        /// <param name="headerName">The name of the header to remove.</param>
        /// <returns>The relevant action.</returns>
        public static Action<Session> DeleteHeaderFromRequest(string headerName)
        {
            return session => session.oRequest.headers.Remove(headerName);
        }

        /// <summary>
        /// AddHeaderToResponse returns an action which adds an HTTP header to a response.
        /// </summary>
        /// <param name="headerName">The name of the header to be added.</param>
        /// <param name="headerValue">The value of the header to be added.</param>
        /// <returns>The relevant action.</returns>
        public static Action<Session> AddHeaderToResponse(string headerName, string headerValue)
        {
            return session => session.oResponse[headerName] = headerValue;
        }

        /// <summary>
        /// DeleteHeaderFromResponse removes the given header from the response.
        /// </summary>
        /// <param name="headerName">The name of the header to remove.</param>
        /// <returns>The relevant action.</returns>
        public static Action<Session> DeleteHeaderFromResponse(string headerName)
        {
            return session => session.oResponse.headers.Remove(headerName);
        }

        /// <summary>
        /// TamperAllRequests returns a behavior which tampers with all requests.
        /// </summary>
        /// <param name="tamperAction">An action specifying how to tamper with the request.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior TamperAllRequests(Action<Session> tamperAction, BehaviorOptions options = null)
        {
            return new TamperRequestBehavior(tamperAction, null, options);
        }

        /// <summary>
        /// TamperAllRequestsIf returns a behavior which tampers with all requests which meet a specified criterion.
        /// </summary>
        /// <param name="tamperAction">An action specifying how to tamper with the request.</param>
        /// <param name="selector">The predicate controlling when to tamper with the request.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior TamperAllRequestsIf(Action<Session> tamperAction, Func<Session, bool> selector, BehaviorOptions options = null)
        {
            return new TamperRequestBehavior(tamperAction, selector, options);
        }

        /// <summary>
        /// TamperRequestsUntil returns a behavior which tampers with all requests until a certain time.
        /// </summary>
        /// <param name="tamperAction">An action specifying how to tamper with the request.</param>
        /// <param name="expiry">The DateTime at which to stop tampering with requests.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior TamperRequestsUntil(Action<Session> tamperAction, DateTime expiry)
        {
            return new TamperRequestBehavior(tamperAction, expiry);
        }

        /// <summary>
        /// TamperRequestsUntilIf returns a behavior which tampers with requests until a certain time.
        /// </summary>
        /// <param name="tamperAction">An action specifying how to tamper with the request.</param>
        /// <param name="expiry">The DateTime at which to stop tampering with requests.</param>
        /// <param name="selector">The predicate controlling when to tamper with the request.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior TamperRequestsUntilIf(Action<Session> tamperAction, DateTime expiry, Func<Session, bool> selector)
        {
            return new TamperRequestBehavior(tamperAction, expiry, selector);
        }

        /// <summary>
        /// TamperNRequests returns a behavior which tampers with all requests until some maximum session count is reached.
        /// </summary>
        /// <param name="tamperAction">An action specifying how to tamper with the request.</param>
        /// <param name="n">The maximum number of sessions to tamper.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior TamperNRequests(Action<Session> tamperAction, int n)
        {
            return new TamperRequestBehavior(tamperAction, n);
        }

        /// <summary>
        /// TamperNRequestsIf returns a behavior which tampers with all requests until some maximum session count is reached.
        /// </summary>
        /// <param name="tamperAction">An action specifying how to tamper with the request.</param>
        /// <param name="n">The maximum number of sessions to tamper.</param>
        /// <param name="selector">The predicate controlling when to tamper with the request.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior TamperNRequestsIf(Action<Session> tamperAction, int n, Func<Session, bool> selector)
        {
            return new TamperRequestBehavior(tamperAction, n, selector);
        }

        /// <summary>
        /// TamperAllResponses returns a behavior which tampers with all responses.
        /// </summary>
        /// <param name="tamperAction">An action specifying how to tamper with the response.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior TamperAllResponses(Action<Session> tamperAction, BehaviorOptions options = null)
        {
            return new TamperResponseBehavior(tamperAction, null, options);
        }

        /// <summary>
        /// TamperAllResponsesIf returns a behavior which tampers with responses meeting the given criterion.
        /// </summary>
        /// <param name="tamperAction">An action specifying how to tamper with the response.</param>
        /// <param name="selector">The predicate controlling when to tamper with the response.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior TamperAllResponsesIf(Action<Session> tamperAction, Func<Session, bool> selector, BehaviorOptions options = null)
        {
            return new TamperResponseBehavior(tamperAction, selector, options);
        }

        /// <summary>
        /// TamperResponsesUntil returns a behavior which tampers with responses until a certain DateTime is reached.
        /// </summary>
        /// <param name="tamperAction">An action specifying how to tamper with the response.</param>
        /// <param name="expiry">The DateTime at which to stop tampering with responses.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior TamperResponsesUntil(Action<Session> tamperAction, DateTime expiry)
        {
            return new TamperResponseBehavior(tamperAction, expiry);
        }

        /// <summary>
        /// TamperResponsesUntilIf returns a behavior which tampers with responses meeting the given criterion,
        /// until a certain DateTime is reached.
        /// </summary>
        /// <param name="tamperAction">An action specifying how to tamper with the response.</param>
        /// <param name="expiry">The DateTime at which to stop tampering with responses.</param>
        /// <param name="selector">The predicate controlling when to tamper with the response.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior TamperResponsesUntilIf(Action<Session> tamperAction, DateTime expiry, Func<Session, bool> selector)
        {
            return new TamperResponseBehavior(tamperAction, expiry, selector);
        }

        /// <summary>
        /// TamperNResponsesIf returns a behavior which tampers with all until a maximum session count is reached.
        /// </summary>
        /// <param name="tamperAction">An action specifying how to tamper with the response.</param>
        /// <param name="n">The maximum number of sessions with which to tamper.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior TamperNResponses(Action<Session> tamperAction, int n)
        {
            return new TamperResponseBehavior(tamperAction, n);
        }

        /// <summary>
        /// TamperNResponsesIf returns a behavior which tampers with responses meeting the given criterion,
        /// until a maximum session count is reached.
        /// </summary>
        /// <param name="tamperAction">An action specifying how to tamper with the response.</param>
        /// <param name="n">The maximum number of sessions with which to tamper.</param>
        /// <param name="selector">The predicate controlling when to tamper with the response.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior TamperNResponsesIf(Action<Session> tamperAction, int n, Func<Session, bool> selector)
        {
            return new TamperResponseBehavior(tamperAction, n, selector);
        }

        /// <summary>
        /// Helper class for request (outgoing) tampering.
        /// </summary>
        private class TamperRequestBehavior : ProxyBehavior
        {
            /// <summary>
            /// Initializes a new instance of the TamperRequestBehavior class.
            /// </summary>
            /// <param name="tamperAction">An action specifying how to tamper with the response.</param>
            /// <param name="selector">The predicate controlling when to tamper with the request.</param>
            /// <param name="options">The options controlling the behavior.</param>
            public TamperRequestBehavior(Action<Session> tamperAction, Func<Session, bool> selector = null, BehaviorOptions options = null)
                : base(tamperAction, selector, options, TriggerType.BeforeRequest)
            {
            }

            /// <summary>
            /// Initializes a new instance of the TamperRequestBehavior class.
            /// </summary>
            /// <param name="tamperAction">An action specifying how to tamper with the response.</param>
            /// <param name="n">The maximum number of sessions which should be tampered with.</param>
            /// <param name="selector">The predicate controlling when to tamper with the request.</param>
            public TamperRequestBehavior(Action<Session> tamperAction, int n, Func<Session, bool> selector = null)
                : this(tamperAction, selector, new BehaviorOptions(maximumRemainingSessions: n))
            {
            }

            /// <summary>
            /// Initializes a new instance of the TamperRequestBehavior class.
            /// </summary>
            /// <param name="tamperAction">An action specifying how to tamper with the response.</param>
            /// <param name="expiry">The DateTime at which to no longer tamper with requests.</param>
            /// <param name="selector">The predicate controlling when to tamper with the request.</param>
            public TamperRequestBehavior(Action<Session> tamperAction, DateTime expiry, Func<Session, bool> selector = null)
                : this(tamperAction, selector, new BehaviorOptions(expiry))
            {
            }
        }

        /// <summary>
        /// Helper class for response (incoming) tampering.
        /// </summary>
        private class TamperResponseBehavior : ProxyBehavior
        {
            /// <summary>
            /// Initializes a new instance of the TamperResponseBehavior class.
            /// </summary>
            /// <param name="tamperAction">An action specifying how to tamper with the response.</param>
            /// <param name="selector">The predicate controlling when to tamper with the response.</param>
            /// <param name="options">The options controlling the behavior.</param>
            public TamperResponseBehavior(Action<Session> tamperAction, Func<Session, bool> selector = null, BehaviorOptions options = null)
                : base(tamperAction, selector, options, TriggerType.BeforeResponse)
            {
            }

            /// <summary>
            /// Initializes a new instance of the TamperResponseBehavior class.
            /// </summary>
            /// <param name="tamperAction">An action specifying how to tamper with the response.</param>
            /// <param name="n">The maximum number of sessions which should be tampered with.</param>
            /// <param name="selector">The predicate controlling when to tamper with the response.</param>
            public TamperResponseBehavior(Action<Session> tamperAction, int n, Func<Session, bool> selector = null)
                : this(tamperAction, selector, new BehaviorOptions(maximumRemainingSessions: n))
            {
            }

            /// <summary>
            /// Initializes a new instance of the TamperResponseBehavior class.
            /// </summary>
            /// <param name="tamperAction">An action specifying how to tamper with the response.</param>
            /// <param name="expiry">The DateTime at which to no longer tamper with responses.</param>
            /// <param name="selector">The predicate controlling when to tamper with the response.</param>
            public TamperResponseBehavior(Action<Session> tamperAction, DateTime expiry, Func<Session, bool> selector = null)
                : this(tamperAction, selector, new BehaviorOptions(expiry))
            {
            }
        }
    }
}
