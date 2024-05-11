// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning.Batch
{
    /// <summary>
    /// Extension methods for <see cref="IConstruct"/>.
    /// </summary>
    public static class BatchExtensions
    {
        /// <summary>
        /// Adds a <see cref="BatchAccount"/> to the construct.
        /// </summary>
        /// <param name="construct">The construct.</param>
        /// <param name="resourceGroup">The parent.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static BatchAccount AddBatch(this IConstruct construct, ResourceGroup? resourceGroup = null, string name)
        {
            return new BatchAccount(construct, name: name, parent: resourceGroup);
        }
    }
}
