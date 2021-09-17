// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Helper methods for ServiceResponse.
    /// </summary>
    public static class ServiceResponseExtensions
    {
        /// <summary>
        /// Set connection states.
        /// </summary>
        /// <param name="response">User's <see cref="ServiceResponse"/></param>
        /// <param name="key">State key.</param>
        /// <param name="value">State value.</param>
        public static void SetState(this ServiceResponse response, string key, object value)
        {
            // In case user cleared states.
            if (response.States == null)
            {
                response.States = new Dictionary<string, object>();
            }
            response.States[key] = value;
        }

        /// <summary>
        /// Clear all states.
        /// </summary>
        /// <param name="response">User's <see cref="ServiceResponse"/></param>
        public static void ClearStates(this ServiceResponse response)
        {
            response.States = null;
        }
    }
}
