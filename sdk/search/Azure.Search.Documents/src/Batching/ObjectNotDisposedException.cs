// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// An exception thrown and immediately caught by finalizers with pending
    /// work or resources that were not properly disposed.  This exception only
    /// exists to notify users of incorrect usage while debugging with first
    /// chance exceptions.
    /// </summary>
    internal class ObjectNotDisposedException : InvalidOperationException
    {
        /// <summary>
        /// Creates a new instance of an ObjectNotDisposedException.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public ObjectNotDisposedException(string message) : base(message)
        {
        }
    }
}
