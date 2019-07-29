// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity
{
    /// <summary>
    /// Details of the device code to present to a user to allow them to authenticate through the device code authentication flow.
    /// </summary>
    public struct DeviceCodeInfo
    {
        internal DeviceCodeInfo(DeviceCodeResult deviceCode)
        {
            UserCode = deviceCode.UserCode;
            DeviceCode = deviceCode.DeviceCode;
            VerificationUrl = deviceCode.VerificationUrl;
            ExpiresOn = deviceCode.ExpiresOn;
            Interval = deviceCode.Interval;
            Message = deviceCode.Message;
            ClientId = deviceCode.ClientId;
            Scopes = deviceCode.Scopes;
        }

        /// <summary>
        /// User code returned by the service
        /// </summary>
        public string UserCode { get; private set; }

        /// <summary>
        /// Device code returned by the service
        /// </summary>
        public string DeviceCode { get; private set; }

#pragma warning disable CA1056 // Uri properties should not be strings
        
        /// <summary>
        /// Verification URL where the user must navigate to authenticate using the device code and credentials.
        /// </summary>
        public string VerificationUrl { get; private set; }

#pragma warning restore CA1056 // Uri properties should not be strings

        /// <summary>
        /// Time when the device code will expire.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; private set; }

        /// <summary>
        /// Polling interval time to check for completion of authentication flow.
        /// </summary>
        public long Interval { get; private set; }

        /// <summary>
        /// User friendly text response that can be used for display purpose.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Identifier of the client requesting device code.
        /// </summary>
        public string ClientId { get; private set; }

        /// <summary>
        /// List of the scopes that would be held by token.
        /// </summary>
        public IReadOnlyCollection<string> Scopes { get; private set; }
    }
}
