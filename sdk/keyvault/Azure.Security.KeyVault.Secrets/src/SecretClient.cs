// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Secrets.Models;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// The SecretClient provides synchronous and asynchronous methods to manage <see cref="KeyVaultSecret"/> in the Azure Key Vault. The client
    /// supports creating, retrieving, updating, deleting, purging, backing up, restoring, and listing <see cref="KeyVaultSecret"/>.
    /// The client also supports listing <see cref="DeletedSecret"/> for a soft-delete enabled Azure Key Vault.
    /// </summary>
    /// <remarks>
    /// Internally, all transport — request building, response parsing, paging, model
    /// (de)serialization, and LRO polling — is delegated to the TypeSpec-generated
    /// <c>KeyVaultSecretsClient</c> (internal). Public method signatures, return
    /// types, exception contracts and recorded HTTP traffic match every previously
    /// shipped version of this package, so adopting this build is a no-op for
    /// existing consumers. The legacy hand-written transport (KeyVaultPipeline,
    /// SecretBackup, JSON read/write methods on the model classes) is no longer
    /// invoked.
    /// </remarks>
    [CallerShouldAudit("https://aka.ms/azsdk/callershouldaudit/security-keyvault-secrets")]
    public class SecretClient
    {
        private const string OTelSecretNameKey    = "az.keyvault.secret.name";
        private const string OTelSecretVersionKey = "az.keyvault.secret.version";

        private readonly Uri _vaultUri;
        private readonly KeyVaultSecretsClient _generated;
        private readonly ClientDiagnostics _diagnostics;

        /// <summary>For mocking.</summary>
        protected SecretClient() { }

        /// <summary>Initializes a new instance of the <see cref="SecretClient"/> class.</summary>
        public SecretClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null) { }

        /// <summary>Initializes a new instance of the <see cref="SecretClient"/> class.</summary>
        public SecretClient(Uri vaultUri, TokenCredential credential, SecretClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new SecretClientOptions();
            _vaultUri    = vaultUri;
            _diagnostics = new ClientDiagnostics(options);

            // Build the HttpPipeline directly from the customer's SecretClientOptions
            // (which extends ClientOptions). This is the legacy SecretClient construction
            // path. Doing it this way picks up *everything* the customer configured —
            // AddPolicy entries (per-call + per-retry), custom RetryPolicy / RetryOptions,
            // Transport, Diagnostics.LoggedHeaderNames + LoggedQueryParameters,
            // ApplicationId — automatically. None of those need explicit copy code, and
            // future fields added to ClientOptions are picked up for free.
            //
            // The challenge-based auth policy is the same one the legacy SecretClient
            // used so recordings remain byte-identical.
            var authPolicy = new ChallengeBasedAuthenticationPolicy(
                credential, options.DisableChallengeResourceVerification);

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, authPolicy);

            _generated = new KeyVaultSecretsClient(
                vaultUri,
                MapApiVersion(options.Version),
                pipeline,
                _diagnostics);
        }

        /// <summary>Initializes a new instance of the <see cref="SecretClient"/> class from settings.</summary>
        [Experimental("SCME0002")]
        public SecretClient(SecretClientSettings settings)
            : this(
                (settings ?? throw new ArgumentNullException(nameof(settings))).VaultUri,
                settings.CredentialProvider as TokenCredential,
                settings.Options) { }

        /// <summary>The vault URI used to construct this client.</summary>
        public virtual Uri VaultUri => _vaultUri;

#pragma warning disable AZC0002 // Client method should have Optional CancellationToken.
        /// <summary>
        /// Get a specified secret from a given key vault.
        /// </summary>
        /// <remarks>
        /// The get operation is applicable to any secret stored in Azure Key Vault.
        /// This operation requires the secrets/get permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="version">The version of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<KeyVaultSecret>> GetSecretAsync(string name, string version, CancellationToken cancellationToken) =>
            await GetSecretAsync(name, version, null, cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0002

        /// <summary>
        /// Get a specified secret from a given key vault.
        /// </summary>
        /// <remarks>
        /// The get operation is applicable to any secret stored in Azure Key Vault.
        /// This operation requires the secrets/get permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="version">The version of the secret.</param>
        /// <param name="outContentType">The content type in which the certificate will be returned. If a supported format is specified, the certificate content is converted to the requested format.
        /// Currently, only PFX to PEM conversion is supported. If an unsupported format is specified, the request is rejected. If not specified, the certificate is returned in its original
        /// format without conversion.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultSecret>> GetSecretAsync(string name, string version = null, SecretContentType? outContentType = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(GetSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.AddAttribute(OTelSecretVersionKey, version);
            scope.Start();
            try
            {
                Response raw = await _generated.GetSecretAsync(name, version, outContentType?.ToString(),
                    new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(DeserializeKeyVaultSecret(raw), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

#pragma warning disable AZC0002 // Client method should have an optional CancellationToken.
        /// <summary>
        /// Get a specified secret from a given key vault.
        /// </summary>
        /// <remarks>
        /// The get operation is applicable to any secret stored in Azure Key Vault.
        /// This operation requires the secrets/get permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="version">The version of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<KeyVaultSecret> GetSecret(string name, string version, CancellationToken cancellationToken) =>
            GetSecret(name, version, null, cancellationToken);
#pragma warning restore AZC0002

        /// <summary>
        /// Get a specified secret from a given key vault.
        /// </summary>
        /// <remarks>
        /// The get operation is applicable to any secret stored in Azure Key Vault.
        /// This operation requires the secrets/get permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="version">The version of the secret.</param>
        /// <param name="outContentType">The content type in which the certificate will be returned. If a supported format is specified, the certificate content is converted to the requested format.
        /// Currently, only PFX to PEM conversion is supported. If an unsupported format is specified, the request is rejected. If not specified, the certificate is returned in its original
        /// format without conversion.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultSecret> GetSecret(string name, string version = null, SecretContentType? outContentType = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(GetSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.AddAttribute(OTelSecretVersionKey, version);
            scope.Start();
            try
            {
                Response raw = _generated.GetSecret(name, version, outContentType?.ToString(),
                    new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(DeserializeKeyVaultSecret(raw), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Lists the properties of all enabled and disabled versions of the specified secret. You can use the returned <see cref="SecretProperties.Name"/> and <see cref="SecretProperties.Version"/> in subsequent calls to <see cref="GetSecretAsync(string, string, SecretContentType?, CancellationToken)"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The full secret identifier and attributes are provided in the response. No
        /// values are returned for the secrets. This operations requires the
        /// secrets/list permission.
        /// </para>
        /// <para>
        /// Managed secrets may also be listed. They contain the certificate and private key for certificates stored in Key Vault.
        /// </para>
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<SecretProperties> GetPropertiesOfSecretVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return MapAsyncPageable(
                _generated.GetSecretVersionsAsync(name, maxresults: default, cancellationToken: cancellationToken),
                SecretMapper.ToSecretProperties,
                $"{nameof(SecretClient)}.{nameof(GetPropertiesOfSecretVersions)}");
        }

        /// <summary>
        /// Lists the properties of all enabled and disabled versions of the specified secret. You can use the returned <see cref="SecretProperties.Name"/> and <see cref="SecretProperties.Version"/> in subsequent calls to <see cref="GetSecret(string, string, SecretContentType?, CancellationToken)"/>.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The full secret identifier and attributes are provided in the response. No
        /// values are returned for the secrets. This operations requires the
        /// secrets/list permission.
        /// </para>
        /// <para>
        /// Managed secrets may also be listed. They contain the certificate and private key for certificates stored in Key Vault.
        /// </para>
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<SecretProperties> GetPropertiesOfSecretVersions(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            return MapPageable(
                _generated.GetSecretVersions(name, maxresults: default, cancellationToken: cancellationToken),
                SecretMapper.ToSecretProperties,
                $"{nameof(SecretClient)}.{nameof(GetPropertiesOfSecretVersions)}");
        }

        /// <summary>
        /// Lists the properties of all enabled and disabled secrets in the specified vault. You can use the returned <see cref="SecretProperties.Name"/> in subsequent calls to <see cref="GetSecretAsync(string, string, SecretContentType?, CancellationToken)"/>.
        /// </summary>
        /// <remarks>
        /// The Get Secrets operation is applicable to the entire vault. However, only
        /// the base secret identifier and its attributes are provided in the response.
        /// Individual secret versions are not listed in the response. This operation
        /// requires the secrets/list permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<SecretProperties> GetPropertiesOfSecretsAsync(CancellationToken cancellationToken = default)
            => MapAsyncPageable(
                _generated.GetSecretsAsync(maxresults: default, cancellationToken: cancellationToken),
                SecretMapper.ToSecretProperties,
                $"{nameof(SecretClient)}.{nameof(GetPropertiesOfSecrets)}");

        /// <summary>
        /// Lists the properties of all enabled and disabled secrets in the specified vault. You can use the returned <see cref="SecretProperties.Name"/> in subsequent calls to <see cref="GetSecret(string, string, SecretContentType?, CancellationToken)"/>.
        /// </summary>
        /// <remarks>
        /// The Get Secrets operation is applicable to the entire vault. However, only
        /// the base secret identifier and its attributes are provided in the response.
        /// Individual secret versions are not listed in the response. This operation
        /// requires the secrets/list permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<SecretProperties> GetPropertiesOfSecrets(CancellationToken cancellationToken = default)
            => MapPageable(
                _generated.GetSecrets(maxresults: default, cancellationToken: cancellationToken),
                SecretMapper.ToSecretProperties,
                $"{nameof(SecretClient)}.{nameof(GetPropertiesOfSecrets)}");

        /// <summary>
        /// Updates the attributes associated with a specified secret.
        /// </summary>
        /// <remarks>
        /// The update operation changes specified attributes of an existing stored
        /// secret. Attributes that are not specified in the request are left
        /// unchanged. The value of a secret itself cannot be changed. This operation
        /// requires the secrets/set permission.
        /// </remarks>
        /// <param name="properties">The secret object with updated properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="properties"/> or <see cref="SecretProperties.Version"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SecretProperties>> UpdateSecretPropertiesAsync(SecretProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            // Match the legacy behavior: a SecretProperties without a Version (e.g. one
            // constructed via the (string name) ctor instead of received from the server)
            // surfaces the same ArgumentNullException the hand-written pipeline used to
            // produce when AppendPath(null) ran. Legacy ParamName was "Version", not
            // "properties.Version" — preserve the exact contract.
            Argument.AssertNotNull(properties.Version, nameof(properties.Version));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(UpdateSecretProperties)}");
            scope.AddAttribute(OTelSecretNameKey, properties.Name);
            scope.AddAttribute(OTelSecretVersionKey, properties.Version);
            scope.Start();
            try
            {
                using RequestContent content = RequestContent.Create(SecretMapper.WriteUpdateBody(properties));
                Response raw = await _generated.UpdateSecretAsync(properties.Name, content, properties.Version,
                    new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(DeserializeSecretProperties(raw), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Updates the attributes associated with a specified secret.
        /// </summary>
        /// <remarks>
        /// The update operation changes specified attributes of an existing stored
        /// secret. Attributes that are not specified in the request are left
        /// unchanged. The value of a secret itself cannot be changed. This operation
        /// requires the secrets/set permission.
        /// </remarks>
        /// <param name="properties">The secret object with updated properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="properties"/> or <see cref="SecretProperties.Version"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<SecretProperties> UpdateSecretProperties(SecretProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));
            Argument.AssertNotNull(properties.Version, nameof(properties.Version));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(UpdateSecretProperties)}");
            scope.AddAttribute(OTelSecretNameKey, properties.Name);
            scope.AddAttribute(OTelSecretVersionKey, properties.Version);
            scope.Start();
            try
            {
                using RequestContent content = RequestContent.Create(SecretMapper.WriteUpdateBody(properties));
                Response raw = _generated.UpdateSecret(properties.Name, content, properties.Version,
                    new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(DeserializeSecretProperties(raw), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Sets a secret in a specified key vault.
        /// </summary>
        /// <remarks>
        /// The set operation adds a secret to the Azure Key Vault. If the named secret
        /// already exists, Azure Key Vault creates a new version of that secret. This
        /// operation requires the secrets/set permission.
        /// </remarks>
        /// <param name="secret">The Secret object containing information about the secret and its properties. The properties secret.Name and secret.Value must be non null.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="secret"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultSecret>> SetSecretAsync(KeyVaultSecret secret, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(secret, nameof(secret));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(SetSecret)}");
            scope.AddAttribute(OTelSecretNameKey, secret.Name);
            scope.Start();
            try
            {
                Response<SecretBundle> raw = await _generated.SetSecretAsync(
                    secret.Name, SecretMapper.ToSetParameters(secret), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(SecretMapper.ToKeyVaultSecret(raw.Value), raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Sets a secret in a specified key vault.
        /// </summary>
        /// <remarks>
        /// The set operation adds a secret to the Azure Key Vault. If the named secret
        /// already exists, Azure Key Vault creates a new version of that secret. This
        /// operation requires the secrets/set permission.
        /// </remarks>
        /// <param name="secret">The Secret object containing information about the secret and its properties. The properties secret.Name and secret.Value must be non null.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="secret"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultSecret> SetSecret(KeyVaultSecret secret, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(secret, nameof(secret));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(SetSecret)}");
            scope.AddAttribute(OTelSecretNameKey, secret.Name);
            scope.Start();
            try
            {
                Response<SecretBundle> raw = _generated.SetSecret(
                    secret.Name, SecretMapper.ToSetParameters(secret), cancellationToken);
                return Response.FromValue(SecretMapper.ToKeyVaultSecret(raw.Value), raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Sets a secret in a specified key vault.
        /// </summary>
        /// <remarks>
        /// The set operation adds a secret to the Azure Key Vault. If the named secret
        /// already exists, Azure Key Vault creates a new version of that secret. This
        /// operation requires the secrets/set permission.
        /// </remarks>
        /// <param name="name">The name of the secret. It must not be null.</param>
        /// <param name="value">The value of the secret. It must not be null.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<KeyVaultSecret>> SetSecretAsync(string name, string value, CancellationToken cancellationToken = default)
            => await SetSecretAsync(new KeyVaultSecret(name, value), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Sets a secret in a specified key vault.
        /// </summary>
        /// <remarks>
        /// The set operation adds a secret to the Azure Key Vault. If the named secret
        /// already exists, Azure Key Vault creates a new version of that secret. This
        /// operation requires the secrets/set permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="value">The value of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<KeyVaultSecret> SetSecret(string name, string value, CancellationToken cancellationToken = default)
            => SetSecret(new KeyVaultSecret(name, value), cancellationToken);

        /// <summary>
        /// Deletes a secret from a specified key vault.
        /// </summary>
        /// <remarks>
        /// The delete operation applies to any secret stored in Azure Key Vault.
        /// Delete cannot be applied to an individual version of a secret. This
        /// operation requires the secrets/delete permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="DeleteSecretOperation"/> to wait on this long-running operation.
        /// If the Key Vault is soft delete-enabled, you only need to wait for the operation to complete if you need to recover or purge the secret;
        /// otherwise, the secret is deleted automatically on the <see cref="DeletedSecret.ScheduledPurgeDate"/>.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<DeleteSecretOperation> StartDeleteSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(StartDeleteSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<DeletedSecretBundle> raw = await _generated.DeleteSecretAsync(name, cancellationToken).ConfigureAwait(false);
                Response<DeletedSecret> response = Response.FromValue(SecretMapper.ToDeletedSecret(raw.Value), raw.GetRawResponse());
                return new DeleteSecretOperation(_generated, _diagnostics, response);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Deletes a secret from a specified key vault.
        /// </summary>
        /// <remarks>
        /// The delete operation applies to any secret stored in Azure Key Vault.
        /// Delete cannot be applied to an individual version of a secret. This
        /// operation requires the secrets/delete permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="DeleteSecretOperation"/> to wait on this long-running operation.
        /// If the Key Vault is soft delete-enabled, you only need to wait for the operation to complete if you need to recover or purge the secret;
        /// otherwise, the secret is deleted automatically on the <see cref="DeletedSecret.ScheduledPurgeDate"/>.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual DeleteSecretOperation StartDeleteSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(StartDeleteSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<DeletedSecretBundle> raw = _generated.DeleteSecret(name, cancellationToken);
                Response<DeletedSecret> response = Response.FromValue(SecretMapper.ToDeletedSecret(raw.Value), raw.GetRawResponse());
                return new DeleteSecretOperation(_generated, _diagnostics, response);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Gets the specified deleted secret.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Secret operation returns the specified deleted secret along
        /// with its attributes. This operation requires the secrets/get permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<DeletedSecret>> GetDeletedSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(GetDeletedSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<DeletedSecretBundle> raw = await _generated.GetDeletedSecretAsync(name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(SecretMapper.ToDeletedSecret(raw.Value), raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Gets the specified deleted secret.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Secret operation returns the specified deleted secret along
        /// with its attributes. This operation requires the secrets/get permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<DeletedSecret> GetDeletedSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(GetDeletedSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<DeletedSecretBundle> raw = _generated.GetDeletedSecret(name, cancellationToken);
                return Response.FromValue(SecretMapper.ToDeletedSecret(raw.Value), raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Lists deleted secrets for the specified vault.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Secrets operation returns the secrets that have been
        /// deleted for a vault enabled for soft-delete. This operation requires the
        /// secrets/list permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual AsyncPageable<DeletedSecret> GetDeletedSecretsAsync(CancellationToken cancellationToken = default)
            => MapAsyncPageable(
                _generated.GetDeletedSecretsAsync(maxresults: default, cancellationToken: cancellationToken),
                SecretMapper.ToDeletedSecret,
                $"{nameof(SecretClient)}.{nameof(GetDeletedSecrets)}");

        /// <summary>
        /// Lists deleted secrets for the specified vault.
        /// </summary>
        /// <remarks>
        /// The Get Deleted Secrets operation returns the secrets that have been
        /// deleted for a vault enabled for soft-delete. This operation requires the
        /// secrets/list permission.
        /// </remarks>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Pageable<DeletedSecret> GetDeletedSecrets(CancellationToken cancellationToken = default)
            => MapPageable(
                _generated.GetDeletedSecrets(maxresults: default, cancellationToken: cancellationToken),
                SecretMapper.ToDeletedSecret,
                $"{nameof(SecretClient)}.{nameof(GetDeletedSecrets)}");

        /// <summary>
        /// Recovers the deleted secret to the latest version.
        /// </summary>
        /// <remarks>
        /// Recovers the deleted secret in the specified vault. This operation can only
        /// be performed on a soft-delete enabled vault. This operation requires the
        /// secrets/recover permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecoverDeletedSecretOperation"/> to wait on this long-running operation.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<RecoverDeletedSecretOperation> StartRecoverDeletedSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(StartRecoverDeletedSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<SecretBundle> raw = await _generated.RecoverDeletedSecretAsync(name, cancellationToken).ConfigureAwait(false);
                Response<SecretProperties> response = Response.FromValue(SecretMapper.ToKeyVaultSecret(raw.Value).Properties, raw.GetRawResponse());
                return new RecoverDeletedSecretOperation(_generated, _diagnostics, response);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Recovers the deleted secret to the latest version.
        /// </summary>
        /// <remarks>
        /// Recovers the deleted secret in the specified vault. This operation can only
        /// be performed on a soft-delete enabled vault. This operation requires the
        /// secrets/recover permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecoverDeletedSecretOperation"/> to wait on this long-running operation.</returns>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual RecoverDeletedSecretOperation StartRecoverDeletedSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(StartRecoverDeletedSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<SecretBundle> raw = _generated.RecoverDeletedSecret(name, cancellationToken);
                Response<SecretProperties> response = Response.FromValue(SecretMapper.ToKeyVaultSecret(raw.Value).Properties, raw.GetRawResponse());
                return new RecoverDeletedSecretOperation(_generated, _diagnostics, response);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Permanently deletes the specified secret.
        /// </summary>
        /// <remarks>
        /// The purge deleted secret operation removes the secret permanently, without
        /// the possibility of recovery. This operation can only be enabled on a
        /// soft-delete enabled vault. This operation requires the secrets/purge
        /// permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response> PurgeDeletedSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(PurgeDeletedSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try { return await _generated.PurgeDeletedSecretAsync(name, cancellationToken).ConfigureAwait(false); }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Permanently deletes the specified secret.
        /// </summary>
        /// <remarks>
        /// The purge deleted secret operation removes the secret permanently, without
        /// the possibility of recovery. This operation can only be enabled on a
        /// soft-delete enabled vault. This operation requires the secrets/purge
        /// permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response PurgeDeletedSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(PurgeDeletedSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try { return _generated.PurgeDeletedSecret(name, cancellationToken); }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Backs up the specified secret.
        /// </summary>
        /// <remarks>
        /// Requests that a backup of the specified secret be downloaded to the client.
        /// All versions of the secret will be downloaded. This operation requires the
        /// secrets/backup permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<byte[]>> BackupSecretAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(BackupSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<BackupSecretResult> raw = await _generated.BackupSecretAsync(name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(SecretMapper.ToBackupBytes(raw.Value), raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Backs up the specified secret.
        /// </summary>
        /// <remarks>
        /// Requests that a backup of the specified secret be downloaded to the client.
        /// All versions of the secret will be downloaded. This operation requires the
        /// secrets/backup permission.
        /// </remarks>
        /// <param name="name">The name of the secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<byte[]> BackupSecret(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(BackupSecret)}");
            scope.AddAttribute(OTelSecretNameKey, name);
            scope.Start();
            try
            {
                Response<BackupSecretResult> raw = _generated.BackupSecret(name, cancellationToken);
                return Response.FromValue(SecretMapper.ToBackupBytes(raw.Value), raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Restores a backed up secret to a vault.
        /// </summary>
        /// <remarks>
        /// Restores a backed up secret, and all its versions, to a vault. This
        /// operation requires the secrets/restore permission.
        /// </remarks>
        /// <param name="backup">The backup blob associated with a secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="backup"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual async Task<Response<SecretProperties>> RestoreSecretBackupAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(RestoreSecretBackup)}");
            scope.Start();
            try
            {
                Response<SecretBundle> raw = await _generated.RestoreSecretAsync(SecretMapper.ToRestoreParameters(backup), cancellationToken).ConfigureAwait(false);
                return Response.FromValue(SecretMapper.ToKeyVaultSecret(raw.Value).Properties, raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Restores a backed up secret to a vault.
        /// </summary>
        /// <remarks>
        /// Restores a backed up secret, and all its versions, to a vault. This
        /// operation requires the secrets/restore permission.
        /// </remarks>
        /// <param name="backup">The backup blob associated with a secret.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="backup"/> is null.</exception>
        /// <exception cref="RequestFailedException">The server returned an error. See <see cref="Exception.Message"/> for details returned from the server.</exception>
        public virtual Response<SecretProperties> RestoreSecretBackup(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(SecretClient)}.{nameof(RestoreSecretBackup)}");
            scope.Start();
            try
            {
                Response<SecretBundle> raw = _generated.RestoreSecret(SecretMapper.ToRestoreParameters(backup), cancellationToken);
                return Response.FromValue(SecretMapper.ToKeyVaultSecret(raw.Value).Properties, raw.GetRawResponse());
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        // ---- plumbing ----

        // Maps the customer-facing SecretClientOptions.ServiceVersion enum to the
        // api-version string the wire client should send. The TypeSpec spec dropped
        // the pre-7.5 service versions, so any caller still parameterized over
        // V7_0..V7_4 is mapped down to V7_5 for the operations this client supports
        // (those older versions only differ from 7.5 in operations we don't expose).
        // No exception is thrown — that would silently break customers who pinned
        // an older enum value. The mapping is observable: callers that care can
        // probe the wire api-version header.
        private static string MapApiVersion(SecretClientOptions.ServiceVersion version) => version switch
        {
            SecretClientOptions.ServiceVersion.V7_0 => "7.0",
            SecretClientOptions.ServiceVersion.V7_1 => "7.1",
            SecretClientOptions.ServiceVersion.V7_2 => "7.2",
            SecretClientOptions.ServiceVersion.V7_3 => "7.3",
            SecretClientOptions.ServiceVersion.V7_4 => "7.4",
            SecretClientOptions.ServiceVersion.V7_5        => "7.5",
            SecretClientOptions.ServiceVersion.V7_6        => "7.6",
            SecretClientOptions.ServiceVersion.V2025_07_01 => "2025-07-01",
            _ => throw new ArgumentOutOfRangeException(
                nameof(version),
                version,
                "Unknown SecretClientOptions.ServiceVersion. Add a mapping in SecretClient.MapApiVersion."),
        };

        private static KeyVaultSecret DeserializeKeyVaultSecret(Response raw)
        {
            SecretBundle bundle = ModelReaderWriter.Read<SecretBundle>(
                raw.Content, ModelReaderWriterOptions.Json, AzureSecurityKeyVaultSecretsContext.Default);
            return SecretMapper.ToKeyVaultSecret(bundle);
        }

        private static SecretProperties DeserializeSecretProperties(Response raw)
        {
            SecretBundle bundle = ModelReaderWriter.Read<SecretBundle>(
                raw.Content, ModelReaderWriterOptions.Json, AzureSecurityKeyVaultSecretsContext.Default);
            return SecretMapper.ToKeyVaultSecret(bundle).Properties;
        }

        // Forwarders to the generated client. We wrap each PAGE FETCH in a
        // SecretClient.<op>-named DiagnosticScope so distributed-tracing span
        // names match the legacy hand-written client exactly. The scope opens
        // and closes around each page-boundary call only; partial enumeration
        // ("break" after the first page) cannot leak a scope because the
        // try/finally is entirely inside the loop body.
        private Pageable<TOut> MapPageable<TIn, TOut>(Pageable<TIn> source, Func<TIn, TOut> map, string scopeName)
            => new MappedPageable<TIn, TOut>(source, map, _diagnostics, scopeName);

        private AsyncPageable<TOut> MapAsyncPageable<TIn, TOut>(AsyncPageable<TIn> source, Func<TIn, TOut> map, string scopeName)
            => new MappedAsyncPageable<TIn, TOut>(source, map, _diagnostics, scopeName);

        private sealed class MappedPageable<TIn, TOut> : Pageable<TOut>
        {
            private readonly Pageable<TIn> _source;
            private readonly Func<TIn, TOut> _map;
            private readonly ClientDiagnostics _diagnostics;
            private readonly string _scopeName;
            public MappedPageable(Pageable<TIn> source, Func<TIn, TOut> map, ClientDiagnostics diagnostics, string scopeName)
            { _source = source; _map = map; _diagnostics = diagnostics; _scopeName = scopeName; }
            public override System.Collections.Generic.IEnumerable<Page<TOut>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                using System.Collections.Generic.IEnumerator<Page<TIn>> e = _source.AsPages(continuationToken, pageSizeHint).GetEnumerator();
                while (true)
                {
                    Page<TIn> page;
                    DiagnosticScope scope = _diagnostics.CreateScope(_scopeName);
                    scope.Start();
                    try
                    {
                        if (!e.MoveNext()) { scope.Dispose(); yield break; }
                        page = e.Current;
                    }
                    catch (Exception ex) { scope.Failed(ex); scope.Dispose(); throw; }
                    scope.Dispose();
                    var values = new System.Collections.Generic.List<TOut>(page.Values.Count);
                    foreach (TIn v in page.Values) values.Add(_map(v));
                    yield return Page<TOut>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class MappedAsyncPageable<TIn, TOut> : AsyncPageable<TOut>
        {
            private readonly AsyncPageable<TIn> _source;
            private readonly Func<TIn, TOut> _map;
            private readonly ClientDiagnostics _diagnostics;
            private readonly string _scopeName;
            public MappedAsyncPageable(AsyncPageable<TIn> source, Func<TIn, TOut> map, ClientDiagnostics diagnostics, string scopeName)
            { _source = source; _map = map; _diagnostics = diagnostics; _scopeName = scopeName; }
            public override async System.Collections.Generic.IAsyncEnumerable<Page<TOut>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                System.Collections.Generic.IAsyncEnumerator<Page<TIn>> e = _source.AsPages(continuationToken, pageSizeHint).GetAsyncEnumerator();
                try
                {
                    while (true)
                    {
                        Page<TIn> page;
                        DiagnosticScope scope = _diagnostics.CreateScope(_scopeName);
                        scope.Start();
                        try
                        {
                            if (!await e.MoveNextAsync().ConfigureAwait(false)) { scope.Dispose(); yield break; }
                            page = e.Current;
                        }
                        catch (Exception ex) { scope.Failed(ex); scope.Dispose(); throw; }
                        scope.Dispose();
                        var values = new System.Collections.Generic.List<TOut>(page.Values.Count);
                        foreach (TIn v in page.Values) values.Add(_map(v));
                        yield return Page<TOut>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                    }
                }
                finally
                {
                    await e.DisposeAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
