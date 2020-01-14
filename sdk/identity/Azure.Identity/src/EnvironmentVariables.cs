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
        public static string SdkAuthLocation => Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION");

        public static string MsiEndpoint => Environment.GetEnvironmentVariable("MSI_ENDPOINT");
        public static string MsiSecret => Environment.GetEnvironmentVariable("MSI_SECRET");
    }
}
