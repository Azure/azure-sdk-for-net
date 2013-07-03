// -----------------------------------------------------------------------------------------
// <copyright file="IgnoreBehaviors.cs" company="Microsoft">
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
    using Fiddler;
    using System;

    /// <summary>
    /// IgnoreBehaviors contains a set of behaviors which allow sessions to be ignored.
    /// </summary>
    public static class IgnoreBehaviors
    {
        /// <summary>
        /// IgnoreAllRequests returns a behavior ignoring all requests.
        /// </summary>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior IgnoreAllRequests(BehaviorOptions options = null)
        {
            return new IgnoreRequestBehavior(null, options);
        }

        /// <summary>
        /// IgnoreAllRequestsIf returns a behavior ignoring requests which meet some criterion.
        /// </summary>
        /// <param name="selector">The predicate controlling when to ignore the request.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior IgnoreAllRequestsIf(Func<Session, bool> selector, BehaviorOptions options = null)
        {
            return new IgnoreRequestBehavior(selector, options);
        }

        /// <summary>
        /// IgnoreAllRequestsUntil returns a behavior ignoring requests until some DateTime is reached.
        /// </summary>
        /// <param name="expiry">The DateTime at which to stop ignoring requests.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior IgnoreAllRequestsUntil(DateTime expiry)
        {
            return new IgnoreRequestBehavior(expiry);
        }

        /// <summary>
        /// IgnoreAllRequestsUntilIf returns a behavior ignoring requests until some DateTime is reached.
        /// </summary>
        /// <param name="expiry">The DateTime at which to stop ignoring requests.</param>
        /// <param name="selector">The predicate controlling when to ignore the request.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior IgnoreAllRequestsUntilIf(DateTime expiry, Func<Session, bool> selector)
        {
            return new IgnoreRequestBehavior(expiry, selector);
        }

        /// <summary>
        /// IgnoreNRequests returns a behavior ignoring requests until some maximum session count is reached.
        /// </summary>
        /// <param name="n">The maximum number of sessions which should be ignored.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior IgnoreNRequests(int n)
        {
            return new IgnoreRequestBehavior(n);
        }

        /// <summary>
        /// IgnoreNRequestsIf returns a behavior ignoring requests until some maximum session count is reached.
        /// </summary>
        /// <param name="n">The maximum number of sessions which should be ignored.</param>
        /// <param name="selector">The predicate controlling when to ignore the request.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior IgnoreNRequestsIf(int n, Func<Session, bool> selector)
        {
            return new IgnoreRequestBehavior(n, selector);
        }

        /// <summary>
        /// IgnoreAllResponses returns a behavior which ignores all responses.
        /// </summary>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior IgnoreAllResponses(BehaviorOptions options = null)
        {
            return new IgnoreResponseBehavior(null, options);
        }

        /// <summary>
        /// IgnoreAllResponsesIf returns a behavior which ignores responses which meet some criterion.
        /// </summary>
        /// <param name="selector">The predicate controlling when to ignore the response.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior IgnoreAllResponsesIf(Func<Session, bool> selector, BehaviorOptions options = null)
        {
            return new IgnoreResponseBehavior(selector, options);
        }

        /// <summary>
        /// IgnoreAllResponsesUntil returns a behavior which ignores responses until some DateTime is reached.
        /// </summary>
        /// <param name="expiry">The DateTime at which to stop ignoring responses.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior IgnoreAllResponsesUntil(DateTime expiry)
        {
            return new IgnoreResponseBehavior(expiry);
        }

        /// <summary>
        /// IgnoreAllResponsesUntilIf returns a behavior which ignores responses until some DateTime is reached.
        /// </summary>
        /// <param name="expiry">The DateTime at which to stop ignoring responses.</param>
        /// <param name="selector">The predicate controlling when to ignore the response.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior IgnoreAllResponsesUntilIf(DateTime expiry, Func<Session, bool> selector)
        {
            return new IgnoreResponseBehavior(expiry, selector);
        }

        /// <summary>
        /// IgnoreNResponses returns a behavior which ignores responses until some maximum session count is reached.
        /// </summary>
        /// <param name="n">The maximum number of sessions to ignore.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior IgnoreNResponses(int n)
        {
            return new IgnoreResponseBehavior(n);
        }

        /// <summary>
        /// IgnoreNResponsesIf returns a behavior which ignores responses until some maximum session count is reached.
        /// </summary>
        /// <param name="n">The maximum number of sessions to ignore.</param>
        /// <param name="selector">The predicate controlling when to ignore the response.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior IgnoreNResponsesIf(int n, Func<Session, bool> selector)
        {
            return new IgnoreResponseBehavior(n, selector);
        }

        /// <summary>
        /// IgnoreRequest ignores the outgoing request.
        /// </summary>
        /// <param name="relevantSession">The session whose request should be failed.</param>
        private static void IgnoreRequest(Session relevantSession)
        {
            relevantSession["x-breakrequest"] = "breaking for abort";
            relevantSession.Abort();          
        }

        /// <summary>
        /// IgnoreResponse ignores the incoming response.
        /// </summary>
        /// <param name="relevantSession">The session whose response should be failed.</param>
        private static void IgnoreResponse(Session relevantSession)
        {
            relevantSession.LoadResponseFromFile(StockResponses.NoContent204);
        }

        /// <summary>
        /// IgnoreRequestBehavior is a helper class for ignoring requests (outgoing).
        /// </summary>
        private class IgnoreRequestBehavior : ProxyBehavior
        {
            /// <summary>
            /// Initializes a new instance of the IgnoreRequestBehavior class.
            /// </summary>
            /// <param name="selector">The predicate controlling when to ignore the request.</param>
            /// <param name="options">The options controlling the behavior.</param>
            public IgnoreRequestBehavior(Func<Session, bool> selector = null, BehaviorOptions options = null)
                : base(IgnoreRequest, selector, options, TriggerType.BeforeRequest)
            {
            }

            /// <summary>
            /// Initializes a new instance of the IgnoreRequestBehavior class.
            /// </summary>
            /// <param name="n">The maximum number of sessions to ignore.</param>
            /// <param name="selector">The predicate controlling when to ignore the request.</param>
            public IgnoreRequestBehavior(int n, Func<Session, bool> selector = null)
                : this(selector, new BehaviorOptions(maximumRemainingSessions: n))
            {
            }

            /// <summary>
            /// Initializes a new instance of the IgnoreRequestBehavior class.
            /// </summary>
            /// <param name="expiry">The DateTime at which to stop ignoring requests.</param>
            /// <param name="selector">The predicate controlling when to ignore the request.</param>
            public IgnoreRequestBehavior(DateTime expiry, Func<Session, bool> selector = null)
                : this(selector, new BehaviorOptions(expiry))
            {
            }
        }

        /// <summary>
        /// IgnoreResponseBehavior is a helper class for ignoring responses (incoming).
        /// </summary>
        private class IgnoreResponseBehavior : ProxyBehavior
        {
            /// <summary>
            /// Initializes a new instance of the IgnoreResponseBehavior class.
            /// </summary>
            /// <param name="selector">The predicate controlling when to ignore the response.</param>
            /// <param name="options">The options controlling the behavior.</param>
            public IgnoreResponseBehavior(Func<Session, bool> selector = null, BehaviorOptions options = null)
                : base(IgnoreResponse, selector, options, TriggerType.BeforeResponse)
            {
            }

            /// <summary>
            /// Initializes a new instance of the IgnoreResponseBehavior class.
            /// </summary>
            /// <param name="n">The maximum number of sessions to ignore.</param>
            /// <param name="selector">The predicate controlling when to ignore the response.</param>
            public IgnoreResponseBehavior(int n, Func<Session, bool> selector = null)
                : this(selector, new BehaviorOptions(maximumRemainingSessions: n))
            {
            }

            /// <summary>
            /// Initializes a new instance of the IgnoreResponseBehavior class.
            /// </summary>
            /// <param name="expiry">The DateTime at which to stop ignoring responses.</param>
            /// <param name="selector">The predicate controlling when to ignore the response.</param>
            public IgnoreResponseBehavior(DateTime expiry, Func<Session, bool> selector = null)
                : this(selector, new BehaviorOptions(expiry))
            {
            }
        }
    }
}
