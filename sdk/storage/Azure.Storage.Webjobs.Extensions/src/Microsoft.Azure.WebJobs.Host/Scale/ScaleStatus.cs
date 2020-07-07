// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Scale
{
    /// <summary>
    /// Represents the current scale status for an <see cref="IScaleMonitor"/>.
    /// </summary>
    public class ScaleStatus
    {
        /// <summary>
        /// Gets or sets the current scale decision.
        /// </summary>
        public ScaleVote Vote { get; set; }
    }
}
