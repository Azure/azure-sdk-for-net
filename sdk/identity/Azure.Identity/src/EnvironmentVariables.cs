// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Identity
{
    internal class EnvironmentVariables
    {
        public static string Username => Environment.GetEnvironmentVariable("AZURE_USERNAME");
        public static string Password => Environment.GetEnvironmentVariable("AZURE_PASSWORD");
        public static string TenantId => Environment.GetEnvironmentVariable("AZURE_TENANT_ID");
        public static string ClientId => Environment.GetEnvironmentVariable("AZURE_CLIENT_ID");
        public static string ClientSecret => Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET");
        public static string ClientCertificatePath => Environment.GetEnvironmentVariable("AZURE_CLIENT_CERTIFICATE_PATH");

        public static string IdentityEndpoint => Environment.GetEnvironmentVariable("IDENTITY_ENDPOINT");
        public static string IdentityHeader => Environment.GetEnvironmentVariable("IDENTITY_HEADER");
        public static string MsiEndpoint => Environment.GetEnvironmentVariable("MSI_ENDPOINT");
        public static string MsiSecret => Environment.GetEnvironmentVariable("MSI_SECRET");
        public static string ImdsEndpoint => Environment.GetEnvironmentVariable("IMDS_ENDPOINT");
        public static string IdentityServerThumbprint => Environment.GetEnvironmentVariable("IDENTITY_SERVER_THUMBPRINT");

        public static string Path => Environment.GetEnvironmentVariable("PATH");

        public static string ProgramFilesX86 => Environment.GetEnvironmentVariable("ProgramFiles(x86)");
        public static string ProgramFiles => Environment.GetEnvironmentVariable("ProgramFiles");
        public static string AuthorityHost => Environment.GetEnvironmentVariable("AZURE_AUTHORITY_HOST");
    }
}
