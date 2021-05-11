// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Extension methods for Response class that apply to management use cases.
    /// </summary>
    public static class ArmResponseExtensions
    {
        /// <summary>
        /// Gets the correlation id from x-ms-correlation-id.
        /// </summary>
        public static string GetCorrelationId(this Response response)
        {
            string correlationId = null;
            response.Headers.TryGetValue("x-ms-correlation-id", out correlationId);
            return correlationId;
        }
    }
}
