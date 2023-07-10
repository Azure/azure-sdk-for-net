// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.JobRouter
{
    /// <summary>
    /// Base class for all supported matching modes.
    /// </summary>
    public abstract class JobMatchingMode
    {
        /// <summary>
        /// Discriminator.
        /// </summary>
        public abstract string Kind { get; }
    }
}
