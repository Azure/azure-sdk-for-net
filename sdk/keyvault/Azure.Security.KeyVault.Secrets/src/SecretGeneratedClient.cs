// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Secrets.Models;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// A drop-in alternative to <see cref="SecretClient"/> whose entire HTTP
    /// transport — request building, response parsing, paging, model
    /// (de)serialization — is generated from the Key Vault TypeSpec contract
    /// rather than hand-written. The public method signatures, return types,
    /// LRO shapes and recorded HTTP traffic match <see cref="SecretClient"/> so
    /// existing applications (and existing recordings) can switch by changing
    /// only the type name at construction.
    /// </summary>
    /// <remarks>
    /// This client follows the same "thin wrapper over a generated low-level
    /// client" pattern used by Java's <c>SecretAsyncClient</c> /
    /// <c>secrets.implementation.SecretClientImpl</c>, Python's
    /// <c>SecretClient</c> over <c>_generated.SecretsClient</c>, and Go's
    /// <c>azsecrets.Client</c>. The low-level generated type
    /// (<c>KeyVaultSecretsClient</c>) is kept <c>internal</c>; customers see
    /// only <see cref="SecretGeneratedClient"/>.
    /// </remarks>
    [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/security-keyvault-secrets")]
    public class SecretGeneratedClient
    {
        private const string OTelSecretNameKey    = "az.keyvault.secret.name";
        private const string OTelSecretVersionKey = "az.keyvault.secret.version";

        private readonly KeyVaultSecretsClient _generated;
        private readonly ClientDiagnostics _diagnostics;
        private readonly Uri _vaultUri;

        /// <summary>For mocking.</summary>
        protected SecretGeneratedClient() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretGeneratedClient"/> class.
        /// </summary>
        public SecretGeneratedClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, options: null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecretGeneratedClient"/> class.
        /// </summary>
        public SecretGeneratedClient(Uri vaultUri, TokenCredential credential, SecretGeneratedClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new SecretGeneratedClientOptions();
            _vaultUri = vaultUri;
            _diagnostics = new ClientDiagnostics(options);

            // Match the legacy SecretClient pipeline so recordings work
            // identically and Key Vault's CAE-style auth-resource discovery
            // is preserved.
            var authPolicy = new ChallengeBasedAuthenticationPolicy(credential, options.DisableChallengeResourceVerification);

            // The generated client wants its own KeyVaultSecretsClientOptions
            // (internal). We translate the user's options.Version into the
            // matching internal enum and pass our auth policy via the
            // generated client's internal ctor overload.
            var genOptions = MapOptions(options);
            _generated = new KeyVaultSecretsClient(authPolicy, vaultUri, genOptions);
        }

        /// <summary>The vault URI used to construct this client.</summary>
        public virtual Uri VaultUri => _vaultUri;

        // ======================================================================
        // GET / READ
        // ======================================================================

        /// <summary>Get a specified secret from a given key vault.</summary>
        public virtual Response<KeyVaultSecret> GetSecret(string name, string version = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(GetSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.AddAttribute(OTelSecretVersionKey, version);
            scope.Start();
            try
            {
                SecretBundle bundle;
                Response raw;
                if (string.IsNullOrEmpty(version))
                {
                    raw = _generated.GetSecret(name, secretVersion: default, outContentType: default, context: new RequestContext { CancellationToken = cancellationToken });
                    bundle = ModelReaderWriter.Read<SecretBundle>(raw.Content, ModelReaderWriterOptions.Json, AzureSecurityKeyVaultSecretsContext.Default);
                }
                else
                {
                    Response<SecretBundle> typed = _generated.GetSecret(name, version, outContentType: default, cancellationToken: cancellationToken);
                    bundle = typed.Value;
                    raw = typed.GetRawResponse();
                }
                return Response.FromValue(SecretMapper.ToKeyVaultSecret(bundle), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Get a specified secret from a given key vault.</summary>
        public virtual async Task<Response<KeyVaultSecret>> GetSecretAsync(string name, string version = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(GetSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.AddAttribute(OTelSecretVersionKey, version);
            scope.Start();
            try
            {
                SecretBundle bundle;
                Response raw;
                if (string.IsNullOrEmpty(version))
                {
                    raw = await _generated.GetSecretAsync(name, secretVersion: default, outContentType: default, context: new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                    bundle = ModelReaderWriter.Read<SecretBundle>(raw.Content, ModelReaderWriterOptions.Json, AzureSecurityKeyVaultSecretsContext.Default);
                }
                else
                {
                    Response<SecretBundle> typed = await _generated.GetSecretAsync(name, version, outContentType: default, cancellationToken: cancellationToken).ConfigureAwait(false);
                    bundle = typed.Value;
                    raw = typed.GetRawResponse();
                }
                return Response.FromValue(SecretMapper.ToKeyVaultSecret(bundle), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Lists all versions of a specific secret.</summary>
        [ForwardsClientCalls]
        public virtual Pageable<SecretProperties> GetPropertiesOfSecretVersions(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return MapPageable(_generated.GetSecretVersions(name, maxresults: default, cancellationToken: cancellationToken), SecretMapper.ToSecretProperties);
        }

        /// <summary>Lists all versions of a specific secret.</summary>
        [ForwardsClientCalls]
        public virtual AsyncPageable<SecretProperties> GetPropertiesOfSecretVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return MapAsyncPageable(_generated.GetSecretVersionsAsync(name, maxresults: default, cancellationToken: cancellationToken), SecretMapper.ToSecretProperties);
        }

        /// <summary>Lists secrets in the vault.</summary>
        [ForwardsClientCalls]
        public virtual Pageable<SecretProperties> GetPropertiesOfSecrets(CancellationToken cancellationToken = default)
            => MapPageable(_generated.GetSecrets(maxresults: default, cancellationToken: cancellationToken), SecretMapper.ToSecretProperties);

        /// <summary>Lists secrets in the vault.</summary>
        [ForwardsClientCalls]
        public virtual AsyncPageable<SecretProperties> GetPropertiesOfSecretsAsync(CancellationToken cancellationToken = default)
            => MapAsyncPageable(_generated.GetSecretsAsync(maxresults: default, cancellationToken: cancellationToken), SecretMapper.ToSecretProperties);

        /// <summary>Gets the specified deleted secret. Requires soft-delete enabled.</summary>
        public virtual Response<DeletedSecret> GetDeletedSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(GetDeletedSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<DeletedSecretBundle> raw = _generated.GetDeletedSecret(name, cancellationToken);
                return Response.FromValue(SecretMapper.ToDeletedSecret(raw.Value), raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Gets the specified deleted secret. Requires soft-delete enabled.</summary>
        public virtual async Task<Response<DeletedSecret>> GetDeletedSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(GetDeletedSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<DeletedSecretBundle> raw = await _generated.GetDeletedSecretAsync(name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(SecretMapper.ToDeletedSecret(raw.Value), raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Lists deleted secrets. Requires soft-delete enabled.</summary>
        [ForwardsClientCalls]
        public virtual Pageable<DeletedSecret> GetDeletedSecrets(CancellationToken cancellationToken = default)
            => MapPageable(_generated.GetDeletedSecrets(maxresults: default, cancellationToken: cancellationToken), SecretMapper.ToDeletedSecret);

        /// <summary>Lists deleted secrets. Requires soft-delete enabled.</summary>
        [ForwardsClientCalls]
        public virtual AsyncPageable<DeletedSecret> GetDeletedSecretsAsync(CancellationToken cancellationToken = default)
            => MapAsyncPageable(_generated.GetDeletedSecretsAsync(maxresults: default, cancellationToken: cancellationToken), SecretMapper.ToDeletedSecret);

        // ======================================================================
        // SET / UPDATE
        // ======================================================================

        /// <summary>Sets a secret in the vault.</summary>
        public virtual Response<KeyVaultSecret> SetSecret(KeyVaultSecret secret, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(secret, nameof(secret));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(SetSecret)}");
            scope.AddAttribute(OTelSecretNameKey, secret.Name);
            scope.Start();
            try
            {
                SecretSetParameters payload = SecretMapper.ToSetParameters(secret);
                Response<SecretBundle> raw = _generated.SetSecret(secret.Name, payload, cancellationToken);
                return Response.FromValue(SecretMapper.ToKeyVaultSecret(raw.Value), raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Sets a secret in the vault.</summary>
        public virtual async Task<Response<KeyVaultSecret>> SetSecretAsync(KeyVaultSecret secret, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(secret, nameof(secret));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(SetSecret)}");
            scope.AddAttribute(OTelSecretNameKey, secret.Name);
            scope.Start();
            try
            {
                SecretSetParameters payload = SecretMapper.ToSetParameters(secret);
                Response<SecretBundle> raw = await _generated.SetSecretAsync(secret.Name, payload, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(SecretMapper.ToKeyVaultSecret(raw.Value), raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Sets a secret in the vault. Convenience overload.</summary>
        public virtual Response<KeyVaultSecret> SetSecret(string name, string value, CancellationToken cancellationToken = default)
            => SetSecret(new KeyVaultSecret(name, value), cancellationToken);

        /// <summary>Sets a secret in the vault. Convenience overload.</summary>
        public virtual Task<Response<KeyVaultSecret>> SetSecretAsync(string name, string value, CancellationToken cancellationToken = default)
            => SetSecretAsync(new KeyVaultSecret(name, value), cancellationToken);

        /// <summary>Updates attributes/tags of an existing secret.</summary>
        public virtual Response<SecretProperties> UpdateSecretProperties(SecretProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(UpdateSecretProperties)}");
            scope.AddAttribute(OTelSecretNameKey, properties.Name);
            scope.AddAttribute(OTelSecretVersionKey, properties.Version);
            scope.Start();
            try
            {
                using var content = RequestContent.Create(SecretMapper.WriteUpdateBody(properties));
                Response raw = _generated.UpdateSecret(properties.Name, content, properties.Version ?? string.Empty, new RequestContext { CancellationToken = cancellationToken });
                var bundle = ModelReaderWriter.Read<SecretBundle>(raw.Content, ModelReaderWriterOptions.Json, AzureSecurityKeyVaultSecretsContext.Default);
                return Response.FromValue(SecretMapper.ToKeyVaultSecret(bundle).Properties, raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Updates attributes/tags of an existing secret.</summary>
        public virtual async Task<Response<SecretProperties>> UpdateSecretPropertiesAsync(SecretProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(UpdateSecretProperties)}");
            scope.AddAttribute(OTelSecretNameKey, properties.Name);
            scope.AddAttribute(OTelSecretVersionKey, properties.Version);
            scope.Start();
            try
            {
                using var content = RequestContent.Create(SecretMapper.WriteUpdateBody(properties));
                Response raw = await _generated.UpdateSecretAsync(properties.Name, content, properties.Version ?? string.Empty, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                var bundle = ModelReaderWriter.Read<SecretBundle>(raw.Content, ModelReaderWriterOptions.Json, AzureSecurityKeyVaultSecretsContext.Default);
                return Response.FromValue(SecretMapper.ToKeyVaultSecret(bundle).Properties, raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        // ======================================================================
        // DELETE / PURGE / RECOVER
        // ======================================================================

        /// <summary>Starts the delete operation. Returns when the service has accepted the request.</summary>
        [ForwardsClientCalls]
        public virtual DeleteSecretOperation StartDeleteSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.StartDeleteSecret");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<DeletedSecretBundle> raw = _generated.DeleteSecret(name, cancellationToken);
                Response<DeletedSecret> wrapped = Response.FromValue(SecretMapper.ToDeletedSecret(raw.Value), raw.GetRawResponse());
                return new DeleteSecretOperation(_generated, _diagnostics, wrapped);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Starts the delete operation. Returns when the service has accepted the request.</summary>
        [ForwardsClientCalls]
        public virtual async Task<DeleteSecretOperation> StartDeleteSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.StartDeleteSecret");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<DeletedSecretBundle> raw = await _generated.DeleteSecretAsync(name, cancellationToken).ConfigureAwait(false);
                Response<DeletedSecret> wrapped = Response.FromValue(SecretMapper.ToDeletedSecret(raw.Value), raw.GetRawResponse());
                return new DeleteSecretOperation(_generated, _diagnostics, wrapped);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Permanently removes a soft-deleted secret.</summary>
        public virtual Response PurgeDeletedSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(PurgeDeletedSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try { return _generated.PurgeDeletedSecret(name, cancellationToken); }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Permanently removes a soft-deleted secret.</summary>
        public virtual async Task<Response> PurgeDeletedSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(PurgeDeletedSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try { return await _generated.PurgeDeletedSecretAsync(name, cancellationToken).ConfigureAwait(false); }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Starts the recover operation for a previously deleted secret.</summary>
        [ForwardsClientCalls]
        public virtual RecoverDeletedSecretOperation StartRecoverDeletedSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.StartRecoverDeletedSecret");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<SecretBundle> raw = _generated.RecoverDeletedSecret(name, cancellationToken);
                Response<SecretProperties> wrapped = Response.FromValue(SecretMapper.ToKeyVaultSecret(raw.Value).Properties, raw.GetRawResponse());
                return new RecoverDeletedSecretOperation(_generated, _diagnostics, wrapped);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Starts the recover operation for a previously deleted secret.</summary>
        [ForwardsClientCalls]
        public virtual async Task<RecoverDeletedSecretOperation> StartRecoverDeletedSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.StartRecoverDeletedSecret");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<SecretBundle> raw = await _generated.RecoverDeletedSecretAsync(name, cancellationToken).ConfigureAwait(false);
                Response<SecretProperties> wrapped = Response.FromValue(SecretMapper.ToKeyVaultSecret(raw.Value).Properties, raw.GetRawResponse());
                return new RecoverDeletedSecretOperation(_generated, _diagnostics, wrapped);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        // ======================================================================
        // BACKUP / RESTORE
        // ======================================================================

        /// <summary>Backs up a secret to a portable blob.</summary>
        public virtual Response<byte[]> BackupSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(BackupSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<BackupSecretResult> raw = _generated.BackupSecret(name, cancellationToken);
                return Response.FromValue(SecretMapper.ToBackupBytes(raw.Value), raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Backs up a secret to a portable blob.</summary>
        public virtual async Task<Response<byte[]>> BackupSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(BackupSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<BackupSecretResult> raw = await _generated.BackupSecretAsync(name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(SecretMapper.ToBackupBytes(raw.Value), raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Restores a secret previously backed up.</summary>
        public virtual Response<SecretProperties> RestoreSecretBackup(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(RestoreSecretBackup)}");
            scope.Start();
            try
            {
                Response<SecretBundle> raw = _generated.RestoreSecret(SecretMapper.ToRestoreParameters(backup), cancellationToken);
                return Response.FromValue(SecretMapper.ToKeyVaultSecret(raw.Value).Properties, raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>Restores a secret previously backed up.</summary>
        public virtual async Task<Response<SecretProperties>> RestoreSecretBackupAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretGeneratedClient)}.{nameof(RestoreSecretBackup)}");
            scope.Start();
            try
            {
                Response<SecretBundle> raw = await _generated.RestoreSecretAsync(SecretMapper.ToRestoreParameters(backup), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(SecretMapper.ToKeyVaultSecret(raw.Value).Properties, raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        // ======================================================================
        // helpers
        // ======================================================================

        private static KeyVaultSecretsClientOptions MapOptions(SecretGeneratedClientOptions options)
        {
            var version = options.Version switch
            {
                SecretGeneratedClientOptions.ServiceVersion.V7_5        => KeyVaultSecretsClientOptions.ServiceVersion.V7_5,
                SecretGeneratedClientOptions.ServiceVersion.V7_6        => KeyVaultSecretsClientOptions.ServiceVersion.V7_6,
                SecretGeneratedClientOptions.ServiceVersion.V2025_07_01 => KeyVaultSecretsClientOptions.ServiceVersion.V2025_07_01,
                _ => throw new ArgumentException("Unsupported service version: " + options.Version, nameof(options)),
            };
            var genOptions = new KeyVaultSecretsClientOptions(version);

            // Carry across the cross-cutting policy configuration so retries,
            // diagnostics, transport overrides etc. behave the same as
            // SecretClient (which builds its pipeline from the user-supplied
            // SecretClientOptions). We only copy fields exposed by Azure.Core's
            // ClientOptions; everything else is left at its default.
            options.Diagnostics.IsLoggingEnabled               = options.Diagnostics.IsLoggingEnabled;
            options.Diagnostics.IsTelemetryEnabled             = options.Diagnostics.IsTelemetryEnabled;
            options.Diagnostics.IsDistributedTracingEnabled    = options.Diagnostics.IsDistributedTracingEnabled;

            CopyDiagnostics(options.Diagnostics, genOptions.Diagnostics);
            CopyRetryOptions(options.Retry, genOptions.Retry);
            if (options.Transport != null) genOptions.Transport = options.Transport;
            return genOptions;
        }

        private static void CopyDiagnostics(DiagnosticsOptions source, DiagnosticsOptions dest)
        {
            dest.ApplicationId               = source.ApplicationId;
            dest.IsDistributedTracingEnabled = source.IsDistributedTracingEnabled;
            dest.IsLoggingContentEnabled     = source.IsLoggingContentEnabled;
            dest.IsLoggingEnabled            = source.IsLoggingEnabled;
            dest.IsTelemetryEnabled          = source.IsTelemetryEnabled;
            dest.LoggedContentSizeLimit      = source.LoggedContentSizeLimit;
        }

        private static void CopyRetryOptions(RetryOptions source, RetryOptions dest)
        {
            dest.Delay        = source.Delay;
            dest.MaxDelay     = source.MaxDelay;
            dest.MaxRetries   = source.MaxRetries;
            dest.Mode         = source.Mode;
            dest.NetworkTimeout = source.NetworkTimeout;
        }

        // Lightweight Pageable<T> / AsyncPageable<T> mapper. Azure.Core does
        // not expose a public Map helper, so we project pages on demand and
        // forward the continuation token.
        private static Pageable<TOut> MapPageable<TIn, TOut>(Pageable<TIn> source, Func<TIn, TOut> map)
            => new MappedPageable<TIn, TOut>(source, map);

        private static AsyncPageable<TOut> MapAsyncPageable<TIn, TOut>(AsyncPageable<TIn> source, Func<TIn, TOut> map)
            => new MappedAsyncPageable<TIn, TOut>(source, map);

        private sealed class MappedPageable<TIn, TOut> : Pageable<TOut>
        {
            private readonly Pageable<TIn> _source;
            private readonly Func<TIn, TOut> _map;
            public MappedPageable(Pageable<TIn> source, Func<TIn, TOut> map) { _source = source; _map = map; }
            public override IEnumerable<Page<TOut>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (Page<TIn> page in _source.AsPages(continuationToken, pageSizeHint))
                {
                    var projected = new List<TOut>(page.Values.Count);
                    foreach (var v in page.Values) projected.Add(_map(v));
                    yield return Page<TOut>.FromValues(projected, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class MappedAsyncPageable<TIn, TOut> : AsyncPageable<TOut>
        {
            private readonly AsyncPageable<TIn> _source;
            private readonly Func<TIn, TOut> _map;
            public MappedAsyncPageable(AsyncPageable<TIn> source, Func<TIn, TOut> map) { _source = source; _map = map; }
            public override async System.Collections.Generic.IAsyncEnumerable<Page<TOut>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (Page<TIn> page in _source.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    var projected = new List<TOut>(page.Values.Count);
                    foreach (var v in page.Values) projected.Add(_map(v));
                    yield return Page<TOut>.FromValues(projected, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }
    }
}
