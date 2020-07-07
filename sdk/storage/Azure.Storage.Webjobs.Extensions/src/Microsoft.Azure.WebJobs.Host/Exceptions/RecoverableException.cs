// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Runtime.Serialization;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// A recoverable exception, i.e. can be handled.
    /// </summary>
    [Serializable]
    public class RecoverableException : Exception
    {
        /// <inheritdoc/>
        public RecoverableException() : base()
        {
        }

        /// <inheritdoc/>
        public RecoverableException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public RecoverableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="info">The <see cref="SerializationInfo"/>.</param>
        /// <param name="context">The <see cref="StreamingContext"/>.</param>
        protected RecoverableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            Handled = bool.Parse(info.GetString("Handled"));
        }

        /// <summary>
        /// Gets or sets a value indicating whether the exception should be treated
        /// as handled.
        /// </summary>
        public bool Handled { get; set; }

        /// <inheritdoc/>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("Handled", this.Handled);

            base.GetObjectData(info, context);
        }

        /// <summary>
        /// Tries to recover by propagating exception through trace pipeline.
        /// Recovers if exception is handled by trace pipeline, else throws.
        /// </summary>
        /// <param name="logger"></param>
        internal void TryRecover(ILogger logger)
        {
            logger.LogError(0, this, Message);

            if (!Handled)
            {
                throw this;
            }
        }
    }
}
