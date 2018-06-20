// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.BotService
{
    /// <summary>
    /// Information received when provisioning a Microsoft App id and password
    /// </summary>
    internal class MsaAppIdInfo
    {
        /// <summary>
        /// Request Id
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Application Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// Application password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Application name
        /// </summary>
        public string Name { get; set; }
    }
}