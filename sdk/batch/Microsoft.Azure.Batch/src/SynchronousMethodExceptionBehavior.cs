// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
