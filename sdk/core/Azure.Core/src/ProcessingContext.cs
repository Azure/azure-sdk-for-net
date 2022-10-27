// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Contains information related to the processing of the <see cref="HttpMessage"/> as it traverses the pipeline.
    /// </summary>
    public readonly struct ProcessingContext
    {
        /// <summary>
        /// The time that the pipeline processing started for the message.
        /// </summary>
        public DateTimeOffset StartTime
        {
            get => _message.ProcessingStartTime;
            set => _message.ProcessingStartTime = value;
        }

        /// <summary>
        /// The retry number for the request. For the initial request, the value is 0.
        /// </summary>
        public int RetryNumber
        {
            get => _message.RetryNumber;
            set => _message.RetryNumber = value;
        }

        /// <summary>
        /// The exception that occurred on the previous attempt, if any.
        /// </summary>
        public Exception? LastException
        {
            get => _message.LastException;
            set => _message.LastException = value;
        }

        private readonly HttpMessage _message;

        /// <summary>
        /// Initializes a new instance of <see cref="ProcessingContext"/>.
        /// </summary>
        /// <param name="message">The message that the context is attached to.</param>
        internal ProcessingContext(HttpMessage message)
        {
            _message = message;
        }
    }
}