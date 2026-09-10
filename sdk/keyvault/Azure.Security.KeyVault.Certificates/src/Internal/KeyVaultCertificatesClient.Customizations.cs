// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Certificates
{
    // Customization partial for the generated KeyVaultCertificatesClient. Adds a
    // ctor that accepts a pre-built HttpPipeline (and matching diagnostics +
    // api-version), so the hand-written CertificateClient can pass through the
    // customer's full CertificateClientOptions configuration — AddPolicy entries,
    // custom Retry, Diagnostics allow-lists, custom Transport, etc. The
    // legacy hand-written CertificateClient built its pipeline directly from
    // ClientOptions in exactly this way; preserving that path is what makes
    // the transport swap a no-op for existing customers.
    internal partial class KeyVaultCertificatesClient
    {
        internal KeyVaultCertificatesClient(
            Uri endpoint,
            string apiVersion,
            HttpPipeline pipeline,
            ClientDiagnostics diagnostics)
        {
            Argument.AssertNotNull(endpoint,    nameof(endpoint));
            Argument.AssertNotNullOrEmpty(apiVersion, nameof(apiVersion));
            Argument.AssertNotNull(pipeline,    nameof(pipeline));
            Argument.AssertNotNull(diagnostics, nameof(diagnostics));

            _endpoint         = endpoint;
            _apiVersion       = apiVersion;
            Pipeline          = pipeline;
            ClientDiagnostics = diagnostics;
        }
    }
}
