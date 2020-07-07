// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Timers
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
