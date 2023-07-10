﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Used to specify a match mode when no action is taken on a job.
    /// </summary>
    public class SuspendMode : JobMatchingMode
    {
        /// <inheritdoc />
        public override string Kind => nameof(SuspendMode);
    }
}
