// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core
{
    /// <summary>
    /// Metadata describing the flow of the HttpMessage through the pipeline
    /// in a given invocation.
    /// </summary>
    public class PipelineContext
    {
        internal PipelineContext(DateTimeOffset createdOn)
        {
            CreatedOn = createdOn;
        }

        /// <summary>
        /// The time this HttpMessage was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; }

        private int? _retryAttempt;

        /// <summary>
        /// The number indicating which retry attempt is currently in progress.
        /// </summary>
        public int RetryAttempt
        {
            get
            {
                if (_retryAttempt == null)
                {
                    throw new InvalidOperationException("Tried to read RetryAttempt when it did not have a value. " +
                        "This can happen because you've accessed RetryAttempt before the RetryPolicy in the pipeline, " +
                        "or because a custom RetryPolicy failed to set RetryAttempt.");
                }

                return _retryAttempt.Value;
            }

            set { _retryAttempt = value; }
        }
    }
}
