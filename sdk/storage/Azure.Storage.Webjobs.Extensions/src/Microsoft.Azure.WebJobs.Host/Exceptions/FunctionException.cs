// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Exception that is tied to a specific job method
    /// </summary>
    [Serializable]
    public class FunctionException : RecoverableException
    {
        /// <inheritdoc/>
        public FunctionException() : base()
        {
        }

        /// <inheritdoc/>
        public FunctionException(string message) : base(message)
        {
        }

        /// <inheritdoc/>
        public FunctionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="methodName">The name of the method in error.</param>
        /// <param name="innerException">The inner exception.</param>
        public FunctionException(string message, string methodName, Exception innerException)
            : base(message, innerException)
        {
            MethodName = methodName;
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/>.</param>
        /// <param name="context">The <see cref="StreamingContext"/>.</param>
        protected FunctionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            MethodName = info.GetString("MethodName");
        }

        /// <summary>
        /// The name of the method in error.
        /// </summary>
        public string MethodName { get; private set; }

        /// <inheritdoc/>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("MethodName", this.MethodName);

            base.GetObjectData(info, context);
        }
    }
}
