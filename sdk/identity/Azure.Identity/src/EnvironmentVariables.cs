// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Azure.Identity
{
    internal class EnvironmentVariables
    {
        public static string Username => Environment.GetEnvironmentVariable("AZURE_USERNAME");
        public static string Password => Environment.GetEnvironmentVariable("AZURE_PASSWORD");
        public static string TenantId => Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
        public static List<string> AdditionallyAllowedTenants => (Environment.GetEnvironmentVariable("AZURE_ADDITIONALLY_ALLOWED_TENANTS") ?? string.Empty).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        public static string ClientId => Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
        public static string ClientSecret => Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");
        public static string ClientCertificatePath => Environment.GetEnvironmentVariable("AZURE_CLIENT_CERTIFICATE_PATH");
        public static string ClientCertificatePassword => Environment.GetEnvironmentVariable("AZURE_CLIENT_CERTIFICATE_PASSWORD");
        public static string ClientSendCertificateChain => Environment.GetEnvironmentVariable("AZURE_CLIENT_SEND_CERTIFICATE_CHAIN");

        public static string IdentityEndpoint => Environment.GetEnvironmentVariable("IDENTITY_ENDPOINT");
        public static string IdentityHeader => Environment.GetEnvironmentVariable("IDENTITY_HEADER");
        public static string MsiEndpoint => Environment.GetEnvironmentVariable("MSI_ENDPOINT");
        public static string MsiSecret => Environment.GetEnvironmentVariable("MSI_SECRET");
        public static string ImdsEndpoint => Environment.GetEnvironmentVariable("IMDS_ENDPOINT");
        public static string IdentityServerThumbprint => Environment.GetEnvironmentVariable("IDENTITY_SERVER_THUMBPRINT");
        public static string PodIdentityEndpoint => Environment.GetEnvironmentVariable("AZURE_POD_IDENTITY_AUTHORITY_HOST");

        public static string Path => Environment.GetEnvironmentVariable("PATH");

        public static string ProgramFilesX86 => Environment.GetEnvironmentVariable("ProgramFiles(x86)");
        public static string ProgramFiles => Environment.GetEnvironmentVariable("ProgramFiles");
        public static string AuthorityHost => Environment.GetEnvironmentVariable("AZURE_AUTHORITY_HOST");

        public static string AzureRegionalAuthorityName => Environment.GetEnvironmentVariable("AZURE_REGIONAL_AUTHORITY_NAME");

        public static string AzureFederatedTokenFile => Environment.GetEnvironmentVariable("AZURE_FEDERATED_TOKEN_FILE");
    }
}
