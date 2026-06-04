// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.KeyAttestation;

namespace Azure.Identity.Broker
{
    /// <summary>
    /// Options to configure the <see cref="ManagedIdentityCredential"/> to opt in to Credential Guard
    /// key attestation support for managed identity mTLS Proof-of-Possession flows. When these options are
    /// passed to a <see cref="ManagedIdentityCredential"/>, <c>WithAttestationSupport()</c> (from the
    /// Microsoft.Identity.Client.KeyAttestation package) will be applied to each managed identity token request
    /// alongside the default <c>WithMtlsProofOfPossession()</c> configuration.
    /// </summary>
    public class ManagedIdentityCredentialAttestationOptions : ManagedIdentityCredentialOptions, IMsalManagedIdentityInitializerOptions
    {
        /// <summary>
        /// Creates a new instance of <see cref="ManagedIdentityCredentialAttestationOptions"/>.
        /// </summary>
        /// <param name="managedIdentityId">The <see cref="ManagedIdentityId"/> specifying which managed identity to use. By default, <see cref="ManagedIdentityId.SystemAssigned"/> will be configured.</param>
        public ManagedIdentityCredentialAttestationOptions(ManagedIdentityId managedIdentityId = null) : base(managedIdentityId)
        {
        }

        Action<AcquireTokenForManagedIdentityParameterBuilder> IMsalManagedIdentityInitializerOptions.BeforeTokenAcquisition => AddAttestationSupport;

        private static void AddAttestationSupport(AcquireTokenForManagedIdentityParameterBuilder builder)
        {
            builder.WithAttestationSupport();
        }
    }
}
