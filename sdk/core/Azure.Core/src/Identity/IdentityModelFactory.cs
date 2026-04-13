// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Azure.Identity
{
    /// <summary>
    /// Model factory that enables mocking for the Azure Identity library.
    /// </summary>
#pragma warning disable AZC0034 // Type moved from Azure.Identity to Azure.Core; name conflict with NuGet Azure.Identity is expected
    [TypeForwardedFrom("Azure.Identity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=92742159e12e44c8")]
    public static class IdentityModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationRecord"/> class for mocking purposes.
        /// </summary>
        /// <param name="username">Sets the <see cref="AuthenticationRecord.Username"/>.</param>
        /// <param name="authority">Sets the <see cref="AuthenticationRecord.Authority"/>.</param>
        /// <param name="homeAccountId">Sets the <see cref="AuthenticationRecord.HomeAccountId"/>.</param>
        /// <param name="tenantId">Sets the <see cref="AuthenticationRecord.TenantId"/>.</param>
        /// <param name="clientId">Sets the <see cref="AuthenticationRecord.ClientId"/>.</param>
        /// <returns>A new instance of the <see cref="AuthenticationRecord"/> for mocking purposes.</returns>
        public static AuthenticationRecord AuthenticationRecord(string username, string authority, string homeAccountId, string tenantId, string clientId)
            => new AuthenticationRecord(username, authority, homeAccountId, tenantId, clientId);

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceCodeInfo"/> class for mocking purposes.
        /// </summary>
        /// <param name="userCode">Sets the <see cref="DeviceCodeInfo.UserCode"/>.</param>
        /// <param name="deviceCode">Sets the <see cref="DeviceCodeInfo.DeviceCode"/>.</param>
        /// <param name="verificationUri">Sets the <see cref="DeviceCodeInfo.VerificationUri"/>.</param>
        /// <param name="expiresOn">Sets the <see cref="DeviceCodeInfo.ExpiresOn"/>.</param>
        /// <param name="message">Sets the <see cref="DeviceCodeInfo.Message"/>.</param>
        /// <param name="clientId">Sets the <see cref="DeviceCodeInfo.ClientId"/>.</param>
        /// <param name="scopes">Sets the <see cref="DeviceCodeInfo.Scopes"/>.</param>
        /// <returns>A new instance of the <see cref="DeviceCodeInfo"/> for mocking purposes.</returns>
        public static DeviceCodeInfo DeviceCodeInfo(string userCode, string deviceCode, Uri verificationUri, DateTimeOffset expiresOn, string message, string clientId, IReadOnlyCollection<string> scopes)
            => new DeviceCodeInfo(userCode, deviceCode, verificationUri, expiresOn, message, clientId, scopes);
    }
#pragma warning restore AZC0034
}
