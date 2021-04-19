// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Common.Timers
{
    internal struct TaskSeriesCommandResult
    {
        private readonly Task _wait;

        public TaskSeriesCommandResult(Task wait)
        {
            _wait = wait;
        }

        /// <summary>
        /// Wait for this task to complete before calling <see cref="ITaskSeriesCommand.ExecuteAsync"/> again.
        /// </summary>
        public Task Wait
        {
            get { return _wait; }
        }
    }
}
