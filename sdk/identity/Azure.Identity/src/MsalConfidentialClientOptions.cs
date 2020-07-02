// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    internal class MsalConfidentialClientOptions
    {
        public MsalConfidentialClientOptions(string tenantId, string clientId, string secret, TokenCredentialOptions options)
            : this(tenantId, clientId, options)
        {
            Secret = secret;
        }
        public MsalConfidentialClientOptions(string tenantId, string clientId, ClientCertificateCredential.IX509Certificate2Provider certificateProvider, TokenCredentialOptions options)
            : this(tenantId, clientId, options)
        {
            CertificateProvider = certificateProvider;
        }

        internal MsalConfidentialClientOptions(string tenantId, string clientId, TokenCredentialOptions options)
        {
            TenantId = tenantId;

            ClientId = clientId;

            AttachSharedCache = (options as ITokenCacheOptions)?.EnablePersistentCache ?? false;

            Pipeline = CredentialPipeline.GetInstance(options);

            AuthorityHost = options?.AuthorityHost ?? KnownAuthorityHosts.GetDefault();
        }

        public MsalConfidentialClientOptions(string tenantId, string clientId, string secret, CredentialPipeline pipeline)
            : this(tenantId, clientId, pipeline)
        {
            Secret = secret;
        }

        public MsalConfidentialClientOptions(string tenantId, string clientId, ClientCertificateCredential.IX509Certificate2Provider certificateProvider, CredentialPipeline pipeline)
            : this(tenantId, clientId, pipeline)
        {
            CertificateProvider = certificateProvider;
        }

        internal MsalConfidentialClientOptions(string tenantId, string clientId, CredentialPipeline pipeline)
        {
            TenantId = tenantId;

            ClientId = clientId;

            AttachSharedCache = false;

            Pipeline = pipeline;

            AuthorityHost = KnownAuthorityHosts.GetDefault();
        }

        public string TenantId { get; }

        public string ClientId { get; }

        public string Secret { get; }

        public ClientCertificateCredential.IX509Certificate2Provider CertificateProvider { get; }

        public CredentialPipeline Pipeline { get; }

        public Uri AuthorityHost { get; }

        public bool AttachSharedCache { get; }
    }
}
