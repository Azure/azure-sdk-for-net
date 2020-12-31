// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace Azure.Identity
{
    /// <summary>
    /// Details of the device code to present to a user to allow them to authenticate through the device code authentication flow.
    /// </summary>
    public struct DeviceCodeInfo
    {
        internal DeviceCodeInfo(DeviceCodeResult deviceCode)
            : this(deviceCode.UserCode, deviceCode.DeviceCode, new Uri(deviceCode.VerificationUrl), deviceCode.ExpiresOn, deviceCode.Message, deviceCode.ClientId, deviceCode.Scopes)
        {
        }

        internal DeviceCodeInfo(string userCode, string deviceCode, Uri verificationUri, DateTimeOffset expiresOn, string message, string clientId, IReadOnlyCollection<string> scopes)
        {
            UserCode = userCode;
            DeviceCode = deviceCode;
            VerificationUri = verificationUri;
            ExpiresOn = expiresOn;
            Message = message;
            ClientId = clientId;
            Scopes = scopes;
        }

        /// <summary>
        /// User code returned by the service
        /// </summary>
        public string UserCode { get; private set; }

        /// <summary>
        /// Device code returned by the service
        /// </summary>
        public string DeviceCode { get; private set; }

        /// <summary>
        /// Verification URL where the user must navigate to authenticate using the device code and credentials.
        /// </summary>
        public Uri VerificationUri { get; private set; }

        /// <summary>
        /// Time when the device code will expire.
        /// </summary>
        public DateTimeOffset ExpiresOn { get; private set; }

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
