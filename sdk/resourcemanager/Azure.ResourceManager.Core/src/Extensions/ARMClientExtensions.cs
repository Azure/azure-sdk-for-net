// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class of extensions for the ARM Client.
    /// </summary>
    public static class ARMClientExtensions
    {
        /// <summary>
        /// Get the operations for an specif resource.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="id">The ID of the resource to retrieve.</param>
        /// <returns></returns>
        public static GenericResourceOperations GetGenericResourceOperations(this ArmClient client, string id)
        {
            return new GenericResourceOperations(client.DefaultSubscription, id);
        }
    }
}
