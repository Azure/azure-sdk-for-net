// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.Serialization;
using Azure.Core;

namespace Azure
{
    /// <summary>
    /// An exception thrown when service request fails.
    /// </summary>
    [Serializable]
    public class OperationFailedException : RequestFailedException
    {
        /// <summary>
        /// Gets the Id of the related <see cref="Operation{T}"/>/>
        /// </summary>
        public string? OperationId { get; }

        /// <summary>Initializes a new instance of the <see cref="OperationFailedException"></see> class with a specified error message and operation id.</summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="operationId"> The Id of the <see cref="Operation{T}"/> related to this exception.</param>
        public OperationFailedException(string message, string operationId)
            : this(message, operationId, null)
        { }

        /// <summary>
        /// <summary>Initializes a new instance of the <see cref="OperationFailedException"></see> class with a specified error message, operation id, and inner exception.</summary>
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="operationId">The Id of the <see cref="Operation{T}"/> related to this exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public OperationFailedException(string message, string operationId, Exception? innerException) : base(message, innerException)
        {
            OperationId = operationId;
        }

        /// <inheritdoc />
        protected OperationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            OperationId = info.GetString(nameof(OperationId));
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Argument.AssertNotNull(info, nameof(info));

            info.AddValue(nameof(OperationId), OperationId);
            base.GetObjectData(info, context);
        }
    }
}
