// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The KeyVaultSettingsClient provides synchronous and asynchronous methods to get and update Managed HSM settings.
    /// </summary>
    public class KeyVaultSettingsClient
    {
        private readonly ClientDiagnostics _diagnostics;
        private readonly SettingsRestClient _restClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultSettingsClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal. You should validate that this URI references a valid Managed HSM resource. See <see href="https://aka.ms/azsdk/blog/vault-uri"/> for details.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public KeyVaultSettingsClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultSettingsClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal You should validate that this URI references a valid Managed HSM resource. See <see href="https://aka.ms/azsdk/blog/vault-uri"/> for details..</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="KeyVaultAdministrationClientOptions"/> that allow to configure the management of the request sent to Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public KeyVaultSettingsClient(Uri vaultUri, TokenCredential credential, KeyVaultAdministrationClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            VaultUri = vaultUri;

            options ??= new KeyVaultAdministrationClientOptions();
            string apiVersion = options.GetVersionString();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options,
                    new ChallengeBasedAuthenticationPolicy(credential, options.DisableChallengeResourceVerification));

            _diagnostics = new ClientDiagnostics(options);
            _restClient = new SettingsRestClient(_diagnostics, pipeline, apiVersion);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyVaultBackupClient"/> class for mocking.
        /// </summary>
        protected KeyVaultSettingsClient() { }

        /// <summary>
        /// The vault Uri.
        /// </summary>
        /// <value></value>
        public virtual Uri VaultUri { get; }

        /// <summary>
        /// Gets the specified account setting.
        /// </summary>
        /// <param name="name">The name of the account setting. Must be a valid settings option.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the specified account setting.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultSetting> GetSetting(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultSettingsClient)}.{nameof(GetSetting)}");
            scope.Start();
            try
            {
                return _restClient.GetSetting(VaultUri.AbsoluteUri, name, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified account setting.
        /// </summary>
        /// <param name="name">The name of the account setting. Must be a valid settings option.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the specified account setting.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultSetting>> GetSettingAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultSettingsClient)}.{nameof(GetSetting)}");
            scope.Start();
            try
            {
                return await _restClient.GetSettingAsync(VaultUri.AbsoluteUri, name, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets all account settings.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An array of all account settings.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<GetSettingsResult> GetSettings(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultSettingsClient)}.{nameof(GetSettings)}");
            scope.Start();
            try
            {
                return _restClient.GetSettings(VaultUri.AbsoluteUri, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets all account settings.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An array of all account settings.</returns>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<GetSettingsResult>> GetSettingsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultSettingsClient)}.{nameof(GetSettings)}");
            scope.Start();
            try
            {
                return await _restClient.GetSettingsAsync(VaultUri.AbsoluteUri, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates the named account setting.
        /// </summary>
        /// <param name="setting">A <see cref="KeyVaultSetting"/> to update. Must be a valid settings option.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        [CallerShouldAudit(KeyVaultAdministrationClientOptions.CallerShouldAuditReason)]
        public virtual Response<KeyVaultSetting> UpdateSetting(KeyVaultSetting setting, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultSettingsClient)}.{nameof(UpdateSetting)}");
            scope.Start();
            try
            {
                return _restClient.UpdateSetting(VaultUri.AbsoluteUri, setting.Name, setting.Value.ToString(), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Updates the named account setting.
        /// </summary>
        /// <param name="setting">A <see cref="KeyVaultSetting"/> to update. Must be a valid settings option.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns></returns>
        [CallerShouldAudit(KeyVaultAdministrationClientOptions.CallerShouldAuditReason)]
        public virtual async Task<Response<KeyVaultSetting>> UpdateSettingAsync(KeyVaultSetting setting, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(setting, nameof(setting));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(KeyVaultSettingsClient)}.{nameof(UpdateSetting)}");
            scope.Start();
            try
            {
                return await _restClient.UpdateSettingAsync(VaultUri.AbsoluteUri, setting.Name, setting.Value.ToString(), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
