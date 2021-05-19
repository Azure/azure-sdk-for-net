// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class IdentityTestEnvironment : TestEnvironment
    {
        public string IdentityTenantId => GetRecordedVariable("AZURE_IDENTITY_TEST_TENANTID");
        public string Username => GetRecordedVariable("AZURE_IDENTITY_TEST_USERNAME");
        public string Password => GetVariable("AZURE_IDENTITY_TEST_PASSWORD");
        public string IdentityClientId => GetVariable("AZURE_IDENTITY_TEST_CLIENT_ID");
        public string IdentityClientSecret => GetOptionalVariable("AZURE_IDENTITY_TEST_CLIENT_SECRET") ?? "SANITIZED";
        public string IMDSEnable => GetRecordedOptionalVariable("IDENTITYTEST_IMDSTEST_ENABLE");
        public string IMDSClientId => GetRecordedOptionalVariable("IDENTITYTEST_IMDSTEST_CLIENTID");
        public string ArcEnable => GetRecordedOptionalVariable("IDENTITYTEST_ARCTEST_ENABLE");
        public string SFEnable => GetRecordedOptionalVariable("IDENTITYTEST_SFTEST_ENABLE");
        public string IdentityEndpoint => GetRecordedOptionalVariable("IDENTITY_ENDPOINT");
        public string ImdsEndpoint => GetRecordedOptionalVariable("IMDS_ENDPOINT");
        public string MsiEndpoint => GetRecordedOptionalVariable("MSI_ENDPOINT");
        public string MsiSecret => GetRecordedOptionalVariable("MSI_SECRET");
        public string IdentityHeader => GetRecordedOptionalVariable("IDENTITY_HEADER");
        public string IdentityServerThumbprint => GetRecordedOptionalVariable("IDENTITY_SERVER_THUMBPRINT");

        public string SystemAssignedVault => GetRecordedOptionalVariable("IDENTITYTEST_IMDSTEST_SYSTEMASSIGNEDVAULT");
        public string UserAssignedVault => GetRecordedOptionalVariable("IDENTITYTEST_IMDSTEST_USERASSIGNEDVAULT");

        public string TestPassword => GetOptionalVariable("AZURE_IDENTITY_TEST_PASSWORD") ?? "SANITIZED";
        public string TestTenantId => GetRecordedOptionalVariable("TENANT_ID") ?? GetRecordedVariable("AZURE_IDENTITY_TEST_TENANTID");

        public string ServicePrincipalClientId => GetRecordedVariable("IDENTITY_SP_CLIENT_ID");
        public string ServicePrincipalTenantId => GetRecordedVariable("IDENTITY_SP_TENANT_ID");
        public string ServicePrincipalClientSecret => GetOptionalVariable("IDENTITY_SP_CLIENT_SECRET") ?? "SANITIZED";
        public string ServicePrincipalCertificatePfxPath => GetOptionalVariable("IDENTITY_SP_CERT_PFX") ?? Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
        public string ServicePrincipalCertificatePemPath => GetOptionalVariable("IDENTITY_SP_CERT_PEM") ?? Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pem");
        public string ServicePrincipalSniCertificatePath => GetOptionalVariable("IDENTITY_SP_CERT_SNI") ?? Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "cert.pfx");
    }
}
