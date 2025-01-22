// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Core;
using Azure.Compute.Batch.Custom;
using System.Threading.Tasks;
using static Azure.Core.HttpPipelineExtensions;
using System.Threading;
using System.Security.Cryptography;
using System.Globalization;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// Utilities for working with tasks in the Azure Batch service.
    /// </summary>
    public class BatchTaskUtilities
    {
        private readonly BatchClient _client;
        private int _hasRun; //Have to use an int because CompareExchange doesn't support bool

        private const int HasNotRun = 0;
        private const int HasRun = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchTaskUtilities"/> class.
        /// </summary>
        /// <param name="client">The <see cref="BatchClient"/> to use for operations.</param>
        public BatchTaskUtilities(BatchClient client)
        {
            _client = client;
        }

        /// <summary> Adds a collection of Tasks to the specified Job. </summary>
        /// <param name="jobId"> The ID of the Job to which the Task collection is to be added. </param>
        /// <param name="tasks"> The Tasks to be added. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="threads"> Number of threads to use in parallel when adding tasks. If specified and greater than 0, will start additional threads to submit requests and wait for them to finish. Otherwise will submit add_collection requests sequentially on main thread.  Default value: 0 </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="tasks"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// Note that each Task must have a unique ID. The Batch service may not return the
        /// results for each Task in the same order the Tasks were submitted in this
        /// request. If the server times out or the connection is closed during the
        /// request, the request may have been partially or fully processed, or not at all.
        /// In such cases, the user should re-issue the request. Note that it is up to the
        /// user to correctly handle failures when re-issuing a request. For example, you
        /// should use the same Task IDs during a retry so that if the prior operation
        /// succeeded, the retry will not create extra Tasks unexpectedly. If the response
        /// contains any Tasks which failed to add, a client can retry the request. In a
        /// retry, it is most efficient to resubmit only Tasks that failed to add, and to
        /// omit Tasks that were successfully added on the first attempt. The maximum
        /// lifetime of a Task from addition to completion is 180 days. If a Task has not
        /// completed within 180 days of being added it will be terminated by the Batch
        /// service and left in whatever state it was in at that time.
        /// </remarks>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task CreateBulkTaskCollectionAsync(string jobId, IEnumerable<BatchTaskCreateContent> tasks, int? timeOutInSeconds = null, int? threads = 0,  DateTimeOffset? ocpdate = null, CancellationToken cancellationToken = default)
        {
            //Ensure that this object has not already been used
            int original = Interlocked.CompareExchange(ref this._hasRun, HasRun, HasNotRun);

            if (original != HasNotRun)
            {
               throw new RunOnceException(string.Format(CultureInfo.InvariantCulture, BatchErrorMessages.CanOnlyBeRunOnceFailure, this.GetType().Name));
            }

            Argument.AssertNotNull(tasks, nameof(tasks));

            //var taskGroup = new BatchBulkTaskGroup(tasks);

             await _client.CreateTaskCollectionAsync(jobId, null, timeOutInSeconds, ocpdate, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Adds a collection of Tasks to the specified Job. </summary>
        /// <param name="jobId"> The ID of the Job to which the Task collection is to be added. </param>
        /// <param name="tasks"> The Tasks to be added. </param>
        /// <param name="timeOutInSeconds"> The maximum time that the server can spend processing the request, in seconds. The default is 30 seconds. If the value is larger than 30, the default will be used instead.". </param>
        /// <param name="threads"> Number of threads to use in parallel when adding tasks. If specified and greater than 0, will start additional threads to submit requests and wait for them to finish. Otherwise will submit add_collection requests sequentially on main thread.  Default value: 0 </param>
        /// <param name="ocpdate">
        /// The time the request was issued. Client libraries typically set this to the
        /// current system clock time; set it explicitly if you are calling the REST API
        /// directly.
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="jobId"/> or <paramref name="tasks"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="jobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <remarks>
        /// Note that each Task must have a unique ID. The Batch service may not return the
        /// results for each Task in the same order the Tasks were submitted in this
        /// request. If the server times out or the connection is closed during the
        /// request, the request may have been partially or fully processed, or not at all.
        /// In such cases, the user should re-issue the request. Note that it is up to the
        /// user to correctly handle failures when re-issuing a request. For example, you
        /// should use the same Task IDs during a retry so that if the prior operation
        /// succeeded, the retry will not create extra Tasks unexpectedly. If the response
        /// contains any Tasks which failed to add, a client can retry the request. In a
        /// retry, it is most efficient to resubmit only Tasks that failed to add, and to
        /// omit Tasks that were successfully added on the first attempt. The maximum
        /// lifetime of a Task from addition to completion is 180 days. If a Task has not
        /// completed within 180 days of being added it will be terminated by the Batch
        /// service and left in whatever state it was in at that time.
        /// </remarks>
        public void CreateBulkTaskCollection(string jobId, IEnumerable<BatchTaskCreateContent> tasks, int? timeOutInSeconds = null, int? threads = 0, DateTimeOffset? ocpdate = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tasks, nameof(tasks));

            //var taskGroup = new BatchBulkTaskGroup(tasks);

            //_client.AddTasks(taskGroup, cancellationToken);
        }
    }
}
