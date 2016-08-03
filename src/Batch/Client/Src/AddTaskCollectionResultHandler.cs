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

﻿using System;
using System.Threading;
using Microsoft.Azure.Batch.Common;

namespace Microsoft.Azure.Batch
{
    // TODO: the original documentation stated that this is for controlling parallelism but it's not clear what
    // you would do here in order to do that - that seems to be more governed by the parallelOptions argument to
    // AddTaskAsync.

    /// <summary>
    /// A <see cref="BatchClientBehavior"/> which you can use to specify under what conditions an operation to
    /// add multiple tasks to a job should retry, terminate or be considered successful.
    /// </summary>
    /// <remarks>You do not need to specify this behavior explicitly; if you do not, a default behavior
    /// is used.  This behavior uses the <see cref="DefaultAddTaskCollectionResultHandler(AddTaskResult, CancellationToken)"/>
    /// criteria.</remarks>
    public class AddTaskCollectionResultHandler : BatchClientBehavior
    {
        /// <summary>
        /// Gets or sets the function that defines whether a particular Add Task operation is considered
        /// successful or unsuccessful, and whether it may be retried.
        /// </summary>
        public Func<AddTaskResult, CancellationToken, AddTaskResultStatus> ResultHandler { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddTaskCollectionResultHandler"/> class with the specified result handler function.
        /// </summary>
        /// <param name="resultHandler">A function that defines whether a particular Add Task operation is considered
        /// successful or unsuccessful, and whether it may be retried.</param>
        public AddTaskCollectionResultHandler(Func<AddTaskResult, CancellationToken, AddTaskResultStatus> resultHandler)
        {
            if (resultHandler == null)
            {
                throw new ArgumentNullException("resultHandler");
            }

            this.ResultHandler = resultHandler;
        }

        /// <summary>
        /// The default result handler for the <see cref="AddTaskCollectionResultHandler"/> behavior. This handler
        /// treats success and 'TaskExists' errors as successful, retries server errors (HTTP 5xx), and throws
        /// <see cref="AddTaskCollectionTerminatedException"/> on client error (HTTP 4xx).
        /// </summary>
        /// <param name="addTaskResult">The result of a single Add Task operation.</param>
        /// <param name="cancellationToken">The cancellation token associated with the AddTaskCollection operation.</param>
        /// <returns>An <see cref="AddTaskResultStatus"/> which indicates whether the <paramref name="addTaskResult"/>
        /// is classified as a success or as requiring a retry.</returns>
        public static AddTaskResultStatus DefaultAddTaskCollectionResultHandler(AddTaskResult addTaskResult, CancellationToken cancellationToken)
        {
            if (addTaskResult == null)
            {
                throw new ArgumentNullException("addTaskResult");
            }

            AddTaskResultStatus status = AddTaskResultStatus.Success;
            if (addTaskResult.Error != null)
            {
                //Check status code 
                if (addTaskResult.Status == AddTaskStatus.ServerError)
                {
                    status = AddTaskResultStatus.Retry;
                }
                else if (addTaskResult.Status == AddTaskStatus.ClientError && addTaskResult.Error.Code == BatchErrorCodeStrings.TaskExists)
                {
                    status = AddTaskResultStatus.Success; //Count TaskExists as a success always
                }
                else
                {
                    //Anything else is a failure -- abort the work flow
                    throw new AddTaskCollectionTerminatedException(addTaskResult);
                }
            }
            return status;
        }
    }
}
