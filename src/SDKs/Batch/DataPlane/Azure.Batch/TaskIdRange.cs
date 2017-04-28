// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Batch
{
    using System;

    public partial class TaskIdRange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskIdRange"/> class.
        /// </summary>
        /// <param name="start">The first task id in the range.</param>
        /// <param name="end">The last task id in the range.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="start"/> or <paramref name="end"/> is negative.</exception>
        /// <exception cref="ArgumentException"><paramref name="end"/> is less than <paramref name="start"/>.</exception>
        /// <remarks>
        /// Ranges are inclusive. For example, if a task depends on a range with Start 8 and End 10, then tasks "8", "9" and "10"
        /// must complete before the task can be scheduled.
        /// </remarks>
        public TaskIdRange(int start, int end)
        {
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException("start", BatchErrorMessages.TaskIdRangeCannotHaveNegativeStart);
            }

            if (end < 0)
            {
                throw new ArgumentOutOfRangeException("end", BatchErrorMessages.TaskIdRangeCannotHaveNegativeEnd);
            }

            if (start > end)
            {
                throw new ArgumentException(BatchErrorMessages.TaskIdRangeCannotHaveEndLessThanStart);
            }
 
            this.start = start;
            this.end = end;
        }
    }
}