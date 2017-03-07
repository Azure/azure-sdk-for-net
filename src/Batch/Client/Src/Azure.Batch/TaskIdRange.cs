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