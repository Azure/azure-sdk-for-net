// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Help methods for ServiceResponse.
    /// </summary>
    public static class ServiceResponseExtensions
    {
        /// <summary>
        /// Set connection states.
        /// </summary>
        /// <param name="response"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetState(this ServiceResponse response, string key, object value)
        {
            // value exists.
            if (response.States.TryGetValue(key, out var value1))
            {
                response.States[key] = value;
            }
            // value new.
            else
            {
                response.States.Add(key, value);
            }
        }

        /// <summary>
        /// Clear all states.
        /// </summary>
        /// <param name="response"></param>
        public static void ClearStates(this ServiceResponse response)
        {
            response.States = null;
        }
    }
}
