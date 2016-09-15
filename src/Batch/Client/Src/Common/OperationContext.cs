// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

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
