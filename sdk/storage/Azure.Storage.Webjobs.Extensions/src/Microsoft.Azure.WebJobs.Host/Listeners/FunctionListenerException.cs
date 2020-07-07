// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Azure.WebJobs.Host.Listeners
{
    /// <summary>
    /// Exception that occurs when the <see cref="JobHost"/> encounters errors when trying
    /// to index job methods on startup.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors")]
    [Serializable]
    public class FunctionListenerException : FunctionException
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="methodName">The name of the method in error.</param>
        /// <param name="innerException">The inner exception.</param>
        public FunctionListenerException(string methodName, Exception innerException)
            : base($"The listener for function '{methodName}' was unable to start.", methodName, innerException)
        {
        }
    }
}
