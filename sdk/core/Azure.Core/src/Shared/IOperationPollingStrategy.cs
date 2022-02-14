// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Polling strategy of <see cref="OperationInternalBase"/>.
    /// </summary>
    internal interface IOperationPollingStrategy
    {
        /// <summary>
        /// Gets interval for current iteration of polling.
        /// </summary>
        /// <remarks>Note that the value could change per call.</remarks>
        public TimeSpan PollingInterval { get; }
    }
}
