// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Monitor.Slis.Models
{
    public readonly partial struct SliSamplingType
    {
        /// <summary> Obsolete alias for <see cref="Average"/>. </summary>
        [System.Obsolete("Use Average instead. This will be removed in a future release.", false)]
        public static SliSamplingType Avg => Average;
    }
}