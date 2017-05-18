// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System;
    using Microsoft.Azure.Batch.Protocol;
    using Protocol.Models;

    /// <summary>
    /// Class which provides easy access to the <see cref="IBatchRequest.Timeout"/> property and the <see cref="Protocol.Models.ITimeoutOptions.Timeout"/> property.
    /// </summary>
    public class BatchRequestTimeout : Protocol.RequestInterceptor
    {
        /// <summary>
        /// Gets or sets the server timeout to be applied to each request issued to the Batch service.
        /// </summary>
        public TimeSpan? ServerTimeout { get; set; }

        /// <summary>
        /// Gets or sets the client timeout to be applied to each request issued to the Batch service.
        /// </summary>
        public TimeSpan? ClientTimeout { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchRequestTimeout"/> class.
        /// </summary>
        /// <param name="serverTimeout">The server timeout to be applied to each request.</param>
        /// <param name="clientTimeout">The client timeout to be applied to each request.</param>
        public BatchRequestTimeout(TimeSpan? serverTimeout = null, TimeSpan? clientTimeout = null)
        {
            this.ServerTimeout = serverTimeout;
            this.ClientTimeout = clientTimeout;

            base.ModificationInterceptHandler = this.SetTimeoutInterceptor;
        }

        private void SetTimeoutInterceptor(Protocol.IBatchRequest request)
        {
            if (this.ClientTimeout.HasValue)
            {
                request.Timeout = this.ClientTimeout.Value;
            }
            ITimeoutOptions timeoutOptions = request.Options as ITimeoutOptions;
            if (this.ServerTimeout.HasValue && timeoutOptions != null)
            {
                //TODO: It would be nice if the Parameters.ServerTimeout property were a TimeSpan not an int
                timeoutOptions.Timeout = (int)this.ServerTimeout.Value.TotalSeconds;
            }
        }
    }
}
