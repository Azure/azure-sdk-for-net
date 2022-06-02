// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   Serves an marker for an exception occurring within developer-provided code, such as
    ///   event handlers.  Such exceptions are typically intended to be explicitly not handled by
    ///   the infrastructure of the various Event Hubs types.
    /// </summary>
    ///
    /// <seealso cref="System.Exception" />
    ///
    [SuppressMessage("Design", "CA1064:Exceptions should be public", Justification = "This exception is not visible to user code")]
    internal class DeveloperCodeException : Exception
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="DeveloperCodeException"/> class.
        /// </summary>
        ///
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        ///
        public DeveloperCodeException(Exception innerException) : base(Resources.DeveloperCodeError, innerException)
        {
        }
    }
}
