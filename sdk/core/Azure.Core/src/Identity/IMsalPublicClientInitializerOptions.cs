// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Microsoft.Identity.Client;

namespace Azure.Identity
{
    [Friend("Azure.Identity.Broker")]
    internal interface IMsalPublicClientInitializerOptions
    {
        Action<PublicClientApplicationBuilder> BeforeBuildClient { get; }

        bool UseDefaultBrokerAccount { get; set; }
    }

    [Friend("Azure.Identity.Broker")]
    internal interface IMsalSettablePublicClientInitializerOptions
    {
        Action<PublicClientApplicationBuilder> BeforeBuildClient { get; set; }

        bool UseDefaultBrokerAccount { get; set; }
    }

    /// <summary>
    /// Implemented by <see cref="TokenCredentialOptions"/>-derived types that need to customize the
    /// <see cref="AcquireTokenForManagedIdentityParameterBuilder"/> immediately before the token is acquired.
    /// This is used, for example, by the Azure.Identity.Broker package to attach
    /// <c>WithAttestationSupport()</c> (from the Microsoft.Identity.Client.KeyAttestation package)
    /// without forcing Azure.Identity itself to take a dependency on that package.
    /// </summary>
    [Friend("Azure.Identity.Broker")]
    internal interface IMsalManagedIdentityInitializerOptions
    {
        /// <summary>
        /// Invoked on the <see cref="AcquireTokenForManagedIdentityParameterBuilder"/> after
        /// the default Azure.Identity configuration (including <c>WithMtlsProofOfPossession()</c>
        /// when token binding is available) has been applied and before <c>ExecuteAsync</c> is called.
        /// </summary>
        Action<AcquireTokenForManagedIdentityParameterBuilder> BeforeTokenAcquisition { get; }
    }
}
