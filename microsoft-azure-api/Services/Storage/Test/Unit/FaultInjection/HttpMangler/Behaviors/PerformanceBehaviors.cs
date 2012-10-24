// -----------------------------------------------------------------------------------------
// <copyright file="PerformanceBehaviors.cs" company="Microsoft">
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
// <copyright file="PerformanceBehaviors.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <summary>
//     This set of behaviors both measure and influence the performance of the sessions to which they are applied.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Test.Network.Behaviors
{
    using System;
    using Fiddler;

    /// <summary>
    /// PerformanceBehaviors both measure and influence the performance of the sessions to which they are applied.
    /// </summary>
    public static class PerformanceBehaviors
    {
        /// <summary>
        /// InsertUpstreamNetworkDelay inserts a delay per KB uploaded.
        /// </summary>
        /// <param name="delayInMs">How much time, in milliseconds, to delay each KB.</param>
        /// <param name="selector">The predicate controlling when to insert upstream network delay.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior InsertUpstreamNetworkDelay(int delayInMs, Func<Session, bool> selector = null, BehaviorOptions options = null)
        {
            return new ProxyBehavior(session => session["request-trickle-delay"] = Convert.ToString(delayInMs), selector, options, TriggerType.BeforeRequest);
        }

        /// <summary>
        /// InsertDownstreamNetworkDelay inserts a delay per KB downloaded.
        /// </summary>
        /// <param name="delayInMs">How much time, in milliseconds, to delay each KB.</param>
        /// <param name="selector">The predicate controlling when to insert downstream network delay.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior InsertDownstreamNetworkDelay(int delayInMs, Func<Session, bool> selector = null, BehaviorOptions options = null)
        {
            return new ProxyBehavior(session => session["response-trickle-delay"] = Convert.ToString(delayInMs), selector, options, TriggerType.BeforeResponse);
        }

        /// <summary>
        /// LogSessionPerfData raises an event when the perf counter for the session is available.
        /// </summary>
        /// <param name="onTimerAvailablity">The action to perform when the session timers are available.</param>
        /// <param name="selector">The predicate controlling when to log performance data.</param>
        /// <param name="options">The options controlling the behavior.</param>
        /// <returns>The relevant behavior.</returns>
        public static ProxyBehavior LogSessionPerfData(Action<Session, SessionTimers> onTimerAvailablity, Func<Session, bool> selector = null, BehaviorOptions options = null)
        {
            return new ProxyBehavior(session => onTimerAvailablity(session, session.Timers), selector, options, TriggerType.AfterSessionComplete);
        }
    }
}
