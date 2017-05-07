// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the context for a request to the Batch service and provides additional information about its execution.
    /// </summary>
    public sealed class OperationContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationContext"/> class.
        /// </summary>
        public OperationContext()
        {
            this.RequestResults = new List<RequestResult>();
        }

        /// <summary>
        /// Gets or sets the list of request results for the current operation.  Each <see cref="RequestResult"/> corresponds to one
        /// request sent to the server.  There may be more than one item in this list in the case of retries.
        /// </summary>
        /// <value>An <see cref="System.Collections.IList"/> object that contains <see cref="RequestResult"/> objects that represent the request results created by the current operation.</value>
        public IList<RequestResult> RequestResults //TODO: Should this be a readonly list?
        {
            get;
            internal set;
        }
    }
}
