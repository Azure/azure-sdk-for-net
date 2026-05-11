// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Security.KeyVault.Administration.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The rest client for the KeyVault External Key Manager (EKM) service.
    /// </summary>
    [CodeGenType("KeyVaultEkmRestClient")]
    [CodeGenSuppress(nameof(GetEkmConnection), typeof(CancellationToken))]
    [CodeGenSuppress(nameof(GetEkmConnectionAsync), typeof(CancellationToken))]
    [CodeGenSuppress(nameof(GetEkmCertificate), typeof(CancellationToken))]
    [CodeGenSuppress(nameof(GetEkmCertificateAsync), typeof(CancellationToken))]
    [CodeGenSuppress(nameof(CheckEkmConnection), typeof(CancellationToken))]
    [CodeGenSuppress(nameof(CheckEkmConnectionAsync), typeof(CancellationToken))]
    [CodeGenSuppress(nameof(CreateEkmConnection), typeof(KeyVaultEkmConnection), typeof(CancellationToken))]
    [CodeGenSuppress(nameof(CreateEkmConnectionAsync), typeof(KeyVaultEkmConnection), typeof(CancellationToken))]
    [CodeGenSuppress(nameof(DeleteEkmConnection), typeof(CancellationToken))]
    [CodeGenSuppress(nameof(DeleteEkmConnectionAsync), typeof(CancellationToken))]
    public partial class KeyVaultEkmClient
    {
        /// <summary>
        /// Gets the vault URI.
        /// </summary>
        /// <value>The vault URI.</value>
        public virtual Uri VaultUri => _endpoint;

        /// <summary> Initializes a new instance of <see cref="KeyVaultEkmClient"/>. </summary>
        /// <param name="vaultUri"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultUri"/> or <paramref name="credential"/> is null. </exception>
        public KeyVaultEkmClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, new KeyVaultAdministrationClientOptions())
        {
        }

        /// <summary> Initializes a new instance of <see cref="KeyVaultEkmClient"/>. </summary>
        /// <param name="vaultUri"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="vaultUri"/> or <paramref name="credential"/> is null. </exception>
        public KeyVaultEkmClient(Uri vaultUri, TokenCredential credential, KeyVaultAdministrationClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new KeyVaultAdministrationClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            Pipeline = HttpPipelineBuilder.Build(
                options,
                new ChallengeBasedAuthenticationPolicy(credential, options.DisableChallengeResourceVerification));
            _endpoint = vaultUri;
            _apiVersion = options.GetVersionString();
        }

        /// <summary> Initializes a new instance of <see cref="KeyVaultEkmClient"/>. </summary>
        /// <param name="authenticationPolicy"> The authentication policy to use for pipeline creation. </param>
        /// <param name="vaultUri"> Service endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        internal KeyVaultEkmClient(HttpPipelinePolicy authenticationPolicy, Uri vaultUri, KeyVaultAdministrationClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));

            options ??= new KeyVaultAdministrationClientOptions();

            _endpoint = vaultUri;
            Pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { authenticationPolicy });
            _apiVersion = options.GetVersionString();
            ClientDiagnostics = new ClientDiagnostics(options, true);
        }

        /// <summary>
        /// The External Key Manager (EKM) Get operation returns the EKM connection. This operation requires <c>ekm/read</c> permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual Response<KeyVaultEkmConnection> GetEkmConnection(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(GetEkmConnection)}");
            scope.Start();
            try
            {
                Response result = GetEkmConnection(cancellationToken.ToRequestContext());
                return Response.FromValue((KeyVaultEkmConnection)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// The External Key Manager (EKM) Get operation returns the EKM connection. This operation requires <c>ekm/read</c> permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual async Task<Response<KeyVaultEkmConnection>> GetEkmConnectionAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(GetEkmConnection)}");
            scope.Start();
            try
            {
                Response result = await GetEkmConnectionAsync(cancellationToken.ToRequestContext()).ConfigureAwait(false);
                return Response.FromValue((KeyVaultEkmConnection)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// The External Key Manager (EKM) Certificate Get operation returns the proxy client certificate. This operation requires <c>ekm/read</c> permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual Response<EkmProxyClientCertificateInfo> GetEkmCertificate(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(GetEkmCertificate)}");
            scope.Start();
            try
            {
                Response result = GetEkmCertificate(cancellationToken.ToRequestContext());
                return Response.FromValue((EkmProxyClientCertificateInfo)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// The External Key Manager (EKM) Certificate Get operation returns the proxy client certificate. This operation requires <c>ekm/read</c> permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual async Task<Response<EkmProxyClientCertificateInfo>> GetEkmCertificateAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(GetEkmCertificate)}");
            scope.Start();
            try
            {
                Response result = await GetEkmCertificateAsync(cancellationToken.ToRequestContext()).ConfigureAwait(false);
                return Response.FromValue((EkmProxyClientCertificateInfo)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// The External Key Manager (EKM) Check operation verifies connectivity and authentication with the EKM proxy. This operation requires <c>ekm/read</c> permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual Response<EkmProxyInfo> CheckEkmConnection(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(CheckEkmConnection)}");
            scope.Start();
            try
            {
                Response result = CheckEkmConnection(cancellationToken.ToRequestContext());
                return Response.FromValue((EkmProxyInfo)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// The External Key Manager (EKM) Check operation verifies connectivity and authentication with the EKM proxy. This operation requires <c>ekm/read</c> permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual async Task<Response<EkmProxyInfo>> CheckEkmConnectionAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(CheckEkmConnection)}");
            scope.Start();
            try
            {
                Response result = await CheckEkmConnectionAsync(cancellationToken.ToRequestContext()).ConfigureAwait(false);
                return Response.FromValue((EkmProxyInfo)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Sets up the External Key Manager (EKM) connection. If the EKM connection already exists, this operation fails. This operation requires <c>ekm/write</c> permission.
        /// </summary>
        /// <param name="ekmConnection">The EKM connection to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ekmConnection"/> is null.</exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual Response<KeyVaultEkmConnection> CreateEkmConnection(KeyVaultEkmConnection ekmConnection, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ekmConnection, nameof(ekmConnection));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(CreateEkmConnection)}");
            scope.Start();
            try
            {
                Response result = CreateEkmConnection(ekmConnection, cancellationToken.ToRequestContext());
                return Response.FromValue((KeyVaultEkmConnection)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Sets up the External Key Manager (EKM) connection. If the EKM connection already exists, this operation fails. This operation requires <c>ekm/write</c> permission.
        /// </summary>
        /// <param name="ekmConnection">The EKM connection to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ekmConnection"/> is null.</exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual async Task<Response<KeyVaultEkmConnection>> CreateEkmConnectionAsync(KeyVaultEkmConnection ekmConnection, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ekmConnection, nameof(ekmConnection));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(CreateEkmConnection)}");
            scope.Start();
            try
            {
                Response result = await CreateEkmConnectionAsync(ekmConnection, cancellationToken.ToRequestContext()).ConfigureAwait(false);
                return Response.FromValue((KeyVaultEkmConnection)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Updates the existing External Key Manager (EKM) connection. If the EKM connection does not exist, this operation fails. This operation requires <c>ekm/write</c> permission.
        /// </summary>
        /// <param name="ekmConnection">The EKM connection to update.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ekmConnection"/> is null.</exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual Response<KeyVaultEkmConnection> UpdateEkmConnection(KeyVaultEkmConnection ekmConnection, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ekmConnection, nameof(ekmConnection));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(UpdateEkmConnection)}");
            scope.Start();
            try
            {
                Response result = UpdateEkmConnection(ekmConnection, cancellationToken.ToRequestContext());
                return Response.FromValue((KeyVaultEkmConnection)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Updates the existing External Key Manager (EKM) connection. If the EKM connection does not exist, this operation fails. This operation requires <c>ekm/write</c> permission.
        /// </summary>
        /// <param name="ekmConnection">The EKM connection to update.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="ekmConnection"/> is null.</exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual async Task<Response<KeyVaultEkmConnection>> UpdateEkmConnectionAsync(KeyVaultEkmConnection ekmConnection, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(ekmConnection, nameof(ekmConnection));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(UpdateEkmConnection)}");
            scope.Start();
            try
            {
                Response result = await UpdateEkmConnectionAsync(ekmConnection, cancellationToken.ToRequestContext()).ConfigureAwait(false);
                return Response.FromValue((KeyVaultEkmConnection)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Deletes the existing External Key Manager (EKM) connection. If the EKM connection does not exist, this operation fails. This operation requires <c>ekm/delete</c> permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual Response<KeyVaultEkmConnection> DeleteEkmConnection(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(DeleteEkmConnection)}");
            scope.Start();
            try
            {
                Response result = DeleteEkmConnection(cancellationToken.ToRequestContext());
                return Response.FromValue((KeyVaultEkmConnection)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Deletes the existing External Key Manager (EKM) connection. If the EKM connection does not exist, this operation fails. This operation requires <c>ekm/delete</c> permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual async Task<Response<KeyVaultEkmConnection>> DeleteEkmConnectionAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(DeleteEkmConnection)}");
            scope.Start();
            try
            {
                Response result = await DeleteEkmConnectionAsync(cancellationToken.ToRequestContext()).ConfigureAwait(false);
                return Response.FromValue((KeyVaultEkmConnection)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }
    }
}
