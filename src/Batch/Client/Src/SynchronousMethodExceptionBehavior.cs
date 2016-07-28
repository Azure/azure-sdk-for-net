// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// A <see cref="BatchClientBehavior"/> which specifies how exceptions should be thrown from
    /// synchronous methods. 
    /// </summary>
    /// <remarks>
    /// By default, synchronous methods throw the same exceptions as asynchronous ones.  For compatability with versions 
    /// of the Azure.Batch client prior to 4.0, you can specify the <see cref="ThrowAggregateException"/> behavior to wrap exceptions 
    /// thrown from synchronous methods in an <see cref="AggregateException"/>.
    /// </remarks>
    public class SynchronousMethodExceptionBehavior : BatchClientBehavior
    {
        /// <summary>
        /// This behavior causes synchronous methods to throw <see cref="AggregateException"/> on failure.
        /// </summary>
        /// <remarks>
        /// This was the default <see cref="SynchronousMethodExceptionBehavior"/> used by Azure.Batch versions prior to 4.0.
        /// </remarks>
        public static readonly SynchronousMethodExceptionBehavior ThrowAggregateException = new SynchronousMethodExceptionBehavior();

        internal void Wait(Task task)
        {
            task.Wait();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SynchronousMethodExceptionBehavior"/> class.
        /// </summary>
        private SynchronousMethodExceptionBehavior()
        {

        }
    }
}
