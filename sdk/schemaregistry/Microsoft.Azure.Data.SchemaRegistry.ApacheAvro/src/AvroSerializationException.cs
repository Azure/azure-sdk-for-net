// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.Serialization;
using Azure.Core;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    /// <summary>
    /// Represents an exception that is thrown when Avro serialization or deserialization fails.
    /// </summary>
    [Serializable]
    public class AvroSerializationException : Exception
    {
        /// <summary>
        /// The Schema Registry schema Id related to the <see cref="AvroSerializationException"/>.
        /// </summary>
        public string SchemaId { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="AvroSerializationException"/>.
        /// </summary>
        public AvroSerializationException() : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AvroSerializationException"/>.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public AvroSerializationException(string message) : this(message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AvroSerializationException"/>.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public AvroSerializationException(string message, Exception innerException) : this(message, null, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="AvroSerializationException"/>.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="schemaId">The Schema Registry schema Id related to the <see cref="AvroSerializationException"/>.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public AvroSerializationException(string message, string schemaId, Exception innerException) : base(message, innerException)
        {
            SchemaId = schemaId;
        }

        /// <inheritdoc />
        protected AvroSerializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            SchemaId = info.GetString(nameof(SchemaId));
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Argument.AssertNotNull(info, nameof(info));

            info.AddValue(nameof(SchemaId), SchemaId);
            base.GetObjectData(info, context);
        }
    }
}