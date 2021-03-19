// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Runtime.Serialization;
using Azure.Core;

#nullable enable

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing exceptions thrown by Azure ARM services.
    /// </summary>
    [Serializable]
    public class ArmException : RequestFailedException
    {
        /// <summary>
        /// Gets and set the Code of the ARM exception.
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Gets and set the Target of the ARM exception.
        /// </summary>
        public string Target { get; private set; }

        /// <summary>
        /// Gets and set the Details of the ARM exception.
        /// </summary>
        public ArmException[]? Details { get; private set; }

        /// <summary>
        /// Gets and set the AdditionalInfo of the ARM exception.
        /// </summary>
        public IDictionary AdditionalInfo => Data;

        /// <summary>Initializes a new instance of the <see cref="ArmException"></see> class with a specified error message.</summary>
        /// <param name="message">The message that describes the error.</param>
        public ArmException(string message) 
            : this(0, message, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ArmException"></see> class with a specified error message, HTTP status code and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ArmException(string message, Exception? innerException)
            : this(0, message, innerException)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ArmException"></see> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="statusCode">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public ArmException(int statusCode, string message, Exception? innerException)
            : this(statusCode, message, innerException, string.Empty, string.Empty, null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ArmException"></see> class with a specified error message and a reference to the inner exception that is the cause of this exception.</summary>
        /// <param name="statusCode">The HTTP status code, or <c>0</c> if not available.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        /// <param name="code">The error code in the ARM error response.</param>
        /// <param name="target">The target in the ARM error response.</param>
        /// <param name="details">The details in the ARM error response.</param>
        public ArmException(
            int statusCode,
            string message,
            Exception? innerException,
            string code,
            string target,
            ArmException[]? details)
            : base(statusCode, message, innerException)
        {
            Code = code;
            Target = target;
            Details = details;
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Argument.AssertNotNull(info, nameof(info));

            info.AddValue(nameof(Code), Code);
            info.AddValue(nameof(Target), Target);
            info.AddValue(nameof(Details), Details);

            base.GetObjectData(info, context);
        }

        /// <inheritdoc />
        protected ArmException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            Code = info.GetString(nameof(Code));
            Target = info.GetString(nameof(Target));
            Details = (ArmException[])(info.GetValue(nameof(Details), typeof(ArmException[])));
        }
    }
}
