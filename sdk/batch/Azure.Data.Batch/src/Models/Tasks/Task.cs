// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Data.Batch.Models
{
    public partial class Task
    {
        public Task(string taskId) : this()
        {
            Id = taskId;
        }
    }
}
