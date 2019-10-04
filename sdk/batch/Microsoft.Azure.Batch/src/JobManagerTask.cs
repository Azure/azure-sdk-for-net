// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System;

    public partial class JobManagerTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobManagerTask"/> class.
        /// </summary>
        public JobManagerTask() : this(id: null, commandLine: null)
        {
        }
    }
}
