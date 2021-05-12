// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="ids">A list of the IDs of the resources to retrieve.</param>
        /// <returns></returns>
        public static List<GenericResourceOperations> GetGenericResourceOperations(this ArmClient client, List<string> ids)
        {
            if (ids == null || !ids.Any())
            {
                throw new ArgumentNullException(nameof(ids));
            }

            var genericRespirceOperations = new List<GenericResourceOperations>();
            foreach (string id in ids)
            {
                genericRespirceOperations.Add(new GenericResourceOperations(client.DefaultSubscription, id));
            }
            return genericRespirceOperations;
        }
    }
}
