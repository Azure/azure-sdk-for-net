// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Tests
{
    /// <summary>
    /// Key Vault and Managed HSM test environment configuration.
    /// </summary>
    public class KeyVaultTestEnvironment : TestEnvironment
    {
        /// <summary>
        /// The name of the primary blob storage account key.
        /// </summary>
        public const string PrimaryKeyEnvironmentVariableName = "BLOB_PRIMARY_STORAGE_ACCOUNT_KEY";

        private const string StorageUriFormat = "https://{0}.blob.core.windows.net";

        /// <summary>
        /// Gets the default polling interval to use in tests.
        /// </summary>
        public static TimeSpan DefaultPollingInterval { get; } = TimeSpan.FromSeconds(5);

        /// <summary>
        /// Gets the URI to Key Vault.
        /// </summary>
        public string KeyVaultUrl => GetRecordedVariable("AZURE_KEYVAULT_URL");

        /// <summary>
        /// Gets a <see cref="Uri"/> to Key Vault.
        /// </summary>
        public Uri VaultUri => new(KeyVaultUrl, UriKind.Absolute);

        /// <summary>
        /// Gets the URI to Managed HSM.
        /// </summary>
        public string ManagedHsmUrl => GetRecordedOptionalVariable("AZURE_MANAGEDHSM_URL");

        /// <summary>
        /// Gets an OID for the client within the tenant.
        /// </summary>
        public string ClientObjectId => GetRecordedVariable("CLIENT_OBJECTID");

        /// <summary>
        /// Gets the primary blob storage account key.
        /// </summary>
        public string PrimaryStorageAccountKey => GetRecordedVariable(PrimaryKeyEnvironmentVariableName, options => options.IsSecret());

        /// <summary>
        /// Gets the blob storage account name.
        /// </summary>
        public string AccountName => GetRecordedVariable("BLOB_STORAGE_ACCOUNT_NAME");

        /// <summary>
        /// Gets the URI to the blob storage account.
        /// </summary>
        public string StorageUri => string.Format(StorageUriFormat, AccountName);

        /// <summary>
        /// Gets the blob container name.
        /// </summary>
        public string BlobContainerName => GetRecordedVariable("BLOB_CONTAINER_NAME");

        /// <summary>
        /// Gets the value of the "KEYVAULT_SKU" variable, or "premium" if not defined.
        /// </summary>
        /// <remarks>
        /// Test preparation was previously successfully creating premium SKUs (not available in every cloud), so assume premium.
        /// </remarks>
        public string Sku => GetOptionalVariable("SKU") ?? "premium";

        /// <summary>
        /// A value indicating whether EKM is enabled.
        /// </summary>
        public bool IsEkmEnabled =>
            !string.IsNullOrEmpty(GetOptionalVariable("EKM_PROXY_HOST")) &&
            !string.IsNullOrEmpty(GetOptionalVariable("EKM_SERVER_CA_CERTIFICATE"));

        /// <summary>
        /// EKM proxy FQDN. Recorded so playback works without the real proxy.
        /// </summary>
        public string EkmHost => GetRecordedOptionalVariable("EKM_PROXY_HOST", options => options.IsSecret("ekm.contoso.com"));

        /// <summary>
        /// EKM proxy path prefix. Defaults to "/api/v1" if not specified.
        /// </summary>
        public string EkmPathPrefix => GetRecordedOptionalVariable("EKM_PROXY_PATH_PREFIX") ?? "/api/v1";

        /// <summary>
        /// Base64-encoded DER bytes of the EKM server CA certificate.
        /// Not recorded — only read during Record/Live on the developer's machine.
        /// </summary>
        public string EkmServerCaCertBase64 => GetOptionalVariable("EKM_SERVER_CA_CERTIFICATE");

        /// <summary>
        /// Gets the value of the "AZURE_KEYVAULT_ATTESTATION_URL" variable.
        /// </summary>
        public Uri AttestationUri => Uri.TryCreate(GetRecordedOptionalVariable("AZURE_KEYVAULT_ATTESTATION_URL"), UriKind.Absolute, out Uri attestationUri)
            ? attestationUri
            : throw new IgnoreException("Required variable 'AZURE_KEYVAULT_ATTESTATION_URL' is not defined");

        /// <summary>
        /// Throws an <see cref="IgnoreException"/> if <see cref="ManagedHsmUrl"/> is not defined.
        /// This should cause a test method to be ignored instead of failing.
        /// </summary>
        public void AssertManagedHsm()
        {
            if (string.IsNullOrEmpty(ManagedHsmUrl))
            {
                throw new IgnoreException($"Required variable 'AZURE_MANAGEDHSM_URL' is not defined");
            }
        }

        /// <summary>
        /// Throws <see cref="IgnoreException"/> in Live/Record modes when EKM is not enabled.
        /// Playback always proceeds and uses recordings.
        /// </summary>
        public void AssertEkmEnabled()
        {
            if (Mode != RecordedTestMode.Playback && !IsEkmEnabled)
            {
                throw new IgnoreException(
                    "EKM live tests require AZURE_KEYVAULT_EKM_ENABLED=true and a provisioned EKM proxy.");
            }
        }

        /// <summary>
        /// Local-developer credential chain used when recording or running live tests.
        ///
        /// The base implementation in <see cref="TestEnvironment.CreateDeveloperCredential"/>
        /// uses <see cref="InteractiveBrowserCredential"/> configured with the WAM broker and
        /// <c>IntPtr.Zero</c> as the parent window handle. When tests run from
        /// <c>dotnet test</c> or Test Explorer there is no foreground window the broker can
        /// attach to, so it fails with:
        /// "A window handle must be configured. See https://aka.ms/msal-net-wam#parent-window-handles".
        ///
        /// This override prefers silent credentials already present on a dev box
        /// (<c>az login</c>, Visual Studio, VS Code, <c>Connect-AzAccount</c>) and falls back
        /// to a system-browser <see cref="InteractiveBrowserCredential"/> WITHOUT WAM,
        /// which does not require a parent window handle and works in headless test hosts.
        /// </summary>
        protected override TokenCredential CreateDeveloperCredential()
        {
            // Explicitly construct InteractiveBrowserCredentialOptions WITHOUT enabling the
            // WAM broker; this routes the sign-in through the default system browser using a
            // localhost redirect, which works in headless test hosts (dotnet test / Test
            // Explorer) where no parent window handle is available.
            InteractiveBrowserCredentialOptions browserOptions = new();

            return new ChainedTokenCredential(
                new AzureCliCredential(),
                new VisualStudioCredential(),
                new VisualStudioCodeCredential(),
                new AzurePowerShellCredential(),
                new InteractiveBrowserCredential(browserOptions));
        }
    }
}
