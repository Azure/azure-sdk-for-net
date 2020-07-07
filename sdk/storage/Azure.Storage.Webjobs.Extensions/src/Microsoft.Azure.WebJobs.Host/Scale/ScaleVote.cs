// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Scale
{
    /// <summary>
    /// Represents a scale decision made by an <see cref="IScaleMonitor"/>.
    /// </summary>
    public enum ScaleVote
    {
        None = 0,
        ScaleOut = 1,
        ScaleIn = -1
    }
}
