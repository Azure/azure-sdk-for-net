// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Extension class for resource manager.
    /// </summary>
    public static class ResourceManagerExtensions
    {
        /// <summary>
        /// Gets the correlation id from x-ms-correlation-id.
        /// </summary>
        public static string GetCorrelationId(this Response response)
        {
            response.Headers.TryGetValue("x-ms-correlation-request-id", out string correlationId);
            return correlationId;
        }
    }
}
