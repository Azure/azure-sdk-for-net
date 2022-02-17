// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    /// <summary>
    /// Polling strategy of <see cref="OperationInternalBase"/>.
    /// </summary>
    internal abstract class OperationPollingStrategy
    {
        /// <summary>
        /// Get the interval of next polling iteration.
        /// </summary>
        /// <remarks>Note that the value could change per call.</remarks>
        /// <param name="response">Server response.</param>
        /// <returns>Polling interval of next iteration.</returns>
        public abstract TimeSpan GetNextWait(Response response);
    }
}
