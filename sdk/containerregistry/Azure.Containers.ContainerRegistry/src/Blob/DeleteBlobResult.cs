// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Containers.ContainerRegistry.Specialized
{
    /// <summary>
    /// </summary>
    public class DeleteBlobResult
    {
        /// <summary>
        /// </summary>
        /// <param name="digest"></param>
        internal DeleteBlobResult(string digest)
        {
            Digest = digest;
        }

        /// <summary>
        /// </summary>
        public string Digest { get; }
    }
}
