// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// The default implementation of <see cref="TaskResultHandler"/> for adding tasks to a Batch job.
    /// </summary>
    public class DefaultCreateTaskResultHandler
        : TaskResultHandler
    {
        /// <summary>
        /// This handler treats success and 'TaskExists' errors as successful, retries server errors (HTTP 5xx), and throws
        /// <see cref="AddTaskCollectionTerminatedException"/> on client error (HTTP 4xx).
        /// </summary>
        /// <param name="taskResult">The result of a single Add Task operation.</param>
        /// <param name="cancellationToken">The cancellation token associated with the AddTaskCollection operation.</param>
        /// <returns>An <see cref="CreateTaskResultStatus"/> which indicates whether the <paramref name="taskResult"/>
        /// is classified as a success or as requiring a retry.</returns>
        public override CreateTaskResultStatus HandleTaskResult(CreateTaskResult taskResult, CancellationToken cancellationToken)
        {
            if (taskResult == null)
            {
                throw new ArgumentNullException("taskResult");
            }

            CreateTaskResultStatus status = CreateTaskResultStatus.Success;
            if (taskResult.BatchTaskResult.Error != null)
            {
                //Check status code
                if (taskResult.BatchTaskResult.Status == BatchTaskAddStatus.ServerError)
                {
                    status = CreateTaskResultStatus.Retry;
                }
                else if (taskResult.BatchTaskResult.Status == BatchTaskAddStatus.ClientError && taskResult.BatchTaskResult.Error.Code == BatchErrorCode.TaskExists)
                {
                    status = CreateTaskResultStatus.Success; //Count TaskExists as a success always
                }
                else
                {
                    //Anything else is a failure -- abort the work flow
                    throw new AddTaskCollectionTerminatedException(taskResult);
                }
            }
            return status;
        }
    }
}
