// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.Hub.Service.Authentication
{
    /// <summary>
    /// The token provider interface for shared access signature based authentication.
    /// </summary>
    internal interface ISasTokenProvider
    {
        /// <summary>
        /// Retrieve the shared access signature to be used.
        /// </summary>
        /// <returns>The shared access signature to be used for authenticating HTTP requests to the service. It is called once per HTTP request.</returns>
        public string GetSasToken();
    }
}
