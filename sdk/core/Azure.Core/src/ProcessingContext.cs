// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Contains information related to the processing of the <see cref="HttpMessage"/>.
    /// </summary>
    public class ProcessingContext
    {
        /// <summary>
        /// The start time of the operation.
        /// </summary>
        public DateTimeOffset OperationStartTime
        {
            get
            {
                if (_message != null)
                {
                    return _message.OperationStartTime;
                }

                return _operationStartTime;
            }
            set
            {
                if (_message != null)
                {
                    _message.OperationStartTime = value;
                    return;
                }
                _operationStartTime = value;
            }
        }
        private DateTimeOffset _operationStartTime;

        /// <summary>
        /// The retry number for the request. For the initial request, the value is 0.
        /// </summary>
        public int RetryNumber
        {
            get
            {
                if (_message != null)
                {
                    return _message.RetryNumber;
                }

                return _retryNumber;
            }
            set
            {
                if (_message != null)
                {
                    _message.RetryNumber = value;
                    return;
                }

                _retryNumber = value;
            }
        }
        private int _retryNumber;

        /// <summary>
        /// The exception that occurred on the previous attempt, if any.
        /// </summary>
        public Exception? LastException
        {
            get
            {
                if (_message != null)
                {
                    return _message.LastException;
                }

                return _lastException;
            }
            set
            {
                if (_message != null)
                {
                    _message.LastException = value;
                    return;
                }

                _lastException = value;
            }
        }
        private Exception? _lastException;

        private readonly HttpMessage? _message;

        /// <summary>
        /// Initializes a new instance of the processing context. This constructor is intended to be used by customers who override the <see cref="RetryPolicy.Process"/>
        /// method, or who set their own <see cref="HttpPipelinePolicy"/> implementation in the <see cref="ClientOptions.RetryPolicy"/> property.
        /// </summary>
        public ProcessingContext()
        {
        }

        /// <summary>
        /// Internal constructor for use by library. The public constructor can be used by customers who override the <see cref="RetryPolicy.Process"/>
        /// method, or who set their own <see cref="HttpPipelinePolicy"/> implementation in the <see cref="ClientOptions.RetryPolicy"/> property.
        /// </summary>
        /// <param name="message">The message that the context is attached to.</param>
        internal ProcessingContext(HttpMessage message)
        {
            _message = message;
        }
    }
}