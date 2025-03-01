// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Compute.Batch
{
    /// <summary>
    /// The result of creating a list of tasks using the CreateTasks operation.
    /// </summary>
    public class CreateTasksResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTasksResult"/> class.
        /// </summary>
        /// <param name="batchTaskAddResults"></param>
        public CreateTasksResult(List<BatchTaskAddResult> batchTaskAddResults)
        {
            BatchTaskAddResults = batchTaskAddResults;
        }

        /// <summary> The results of the CreateTasks operation. </summary>
        public List<BatchTaskAddResult> BatchTaskAddResults { get; }

        /// <summary> Gets or sets the number of successful tasks. </summary>
        public int Pass { get; set; }

        /// <summary> Gets or sets the number of failed tasks. </summary>
        public int Fail { get; set; }
    }
}
