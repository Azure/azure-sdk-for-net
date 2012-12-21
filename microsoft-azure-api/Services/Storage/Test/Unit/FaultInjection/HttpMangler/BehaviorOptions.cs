// -----------------------------------------------------------------------------------------
// <copyright file="BehaviorOptions.cs" company="Microsoft">
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
// <copyright file="BehaviorOptions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <summary>
//     The BehaviorOptions class controls how many sessions a behavior will apply to, and for how long it should be applied.
// </summary>
//-----------------------------------------------------------------------
namespace Microsoft.WindowsAzure.Test.Network
{
    using System;
    using System.Threading;

    /// <summary>
    /// The BehaviorOptions class controls how many sessions a behavior will apply to, and for how long it should be applied.
    /// </summary>
    public class BehaviorOptions
    {
        /// <summary>
        /// The time at which the behavior should expire.
        /// </summary>
        private readonly DateTime expiry;

        /// <summary>
        /// The number of sessions in which the related behavior has been selected.
        /// </summary>
        private long remainingSessions;

        /// <summary>
        /// Initializes a new instance of the BehaviorOptions class.
        /// </summary>
        public BehaviorOptions()
            : this(expiry: DateTime.MaxValue)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BehaviorOptions class with a specified number 
        /// of sessions to which the behavior should be applied.
        /// </summary>
        /// <param name="maximumRemainingSessions">The number of sessions to apply this behavior to.</param>
        public BehaviorOptions(long maximumRemainingSessions)
            : this(expiry: DateTime.MaxValue, maximumRemainingSessions: maximumRemainingSessions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BehaviorOptions class with with an expiry time and 
        /// a maximum number of sessions to which the behavior should be applied.
        /// </summary>
        /// <param name="expiry">The time at which the behavior should no longer be applied.</param>
        /// <param name="maximumRemainingSessions">The maximum number of sessions the behavior should be applied.</param>
        public BehaviorOptions(DateTime expiry, long maximumRemainingSessions = long.MaxValue)
        {
            this.remainingSessions = maximumRemainingSessions;
            this.expiry = expiry;
        }

        /// <summary>
        /// Gets the DateTime at which this behavior should no longer be applied.
        /// </summary>
        public DateTime Expiry
        {
            get { return this.expiry; } 
        }

        /// <summary>
        /// Gets the number of sessions before this behavior will no longer be applied.
        /// </summary>
        public long RemainingSessions
        {
            get { return this.remainingSessions; }
        }

        /// <summary>
        /// DecrementSessionCount notes that this behavior has been applied.
        /// </summary>
        public void DecrementSessionCount()
        {
            Interlocked.Decrement(ref this.remainingSessions);
        }
    }
}
