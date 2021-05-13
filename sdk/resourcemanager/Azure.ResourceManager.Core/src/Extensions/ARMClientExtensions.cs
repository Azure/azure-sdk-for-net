// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class of extensions for the ARM Client.
    /// </summary>
    public static class ArmClientExtensions
    {
        /// <summary>
        /// Get the operations for a list of specific resources.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="ids">A list of the IDs of the resources to retrieve.</param>
        /// <returns></returns>
        public static IList<GenericResourceOperations> GetGenericResourceOperations(this ArmClient client, IEnumerable<string> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            IList<GenericResourceOperations> genericRespirceOperations = new List<GenericResourceOperations>();
            foreach (string id in ids)
            {
                genericRespirceOperations.Add(new GenericResourceOperations(client.DefaultSubscription, id));
            }
            return genericRespirceOperations;
        }

        /// <summary>
        /// Get the operations for an specific resource.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="id">The ID of the resource to retrieve.</param>
        /// <returns></returns>
        public static GenericResourceOperations GetGenericResourceOperations(this ArmClient client, string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return new GenericResourceOperations(client.DefaultSubscription, id);
        }
    }
}
