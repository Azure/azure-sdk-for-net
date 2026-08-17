// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Gets an existing External Key Manager (EKM) proxy private endpoint. This operation requires <c>ekm/read</c> permission.
        /// Only available with service version <see cref="KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview"/> and newer.
        /// </summary>
        /// <param name="peName">The name of the private endpoint to get.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="peName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="peName"/> is an empty string.</exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual Response<KeyVaultEkmPrivateEndpoint> GetEkmPrivateEndpoint(string peName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peName, nameof(peName));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(GetEkmPrivateEndpoint)}");
            scope.Start();
            try
            {
                Response result = GetEkmPrivateEndpoint(peName, cancellationToken.ToRequestContext());
                return Response.FromValue((KeyVaultEkmPrivateEndpoint)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Gets an existing External Key Manager (EKM) proxy private endpoint. This operation requires <c>ekm/read</c> permission.
        /// Only available with service version <see cref="KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview"/> and newer.
        /// </summary>
        /// <param name="peName">The name of the private endpoint to get.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="peName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="peName"/> is an empty string.</exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual async Task<Response<KeyVaultEkmPrivateEndpoint>> GetEkmPrivateEndpointAsync(string peName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peName, nameof(peName));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(GetEkmPrivateEndpoint)}");
            scope.Start();
            try
            {
                Response result = await GetEkmPrivateEndpointAsync(peName, cancellationToken.ToRequestContext()).ConfigureAwait(false);
                return Response.FromValue((KeyVaultEkmPrivateEndpoint)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Lists all External Key Manager (EKM) proxy private endpoints on the pool. This operation requires <c>ekm/read</c> permission.
        /// Only available with service version <see cref="KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview"/> and newer.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual Response<IReadOnlyList<KeyVaultEkmPrivateEndpoint>> GetEkmPrivateEndpoints(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(GetEkmPrivateEndpoints)}");
            scope.Start();
            try
            {
                Response result = GetEkmPrivateEndpoints(cancellationToken.ToRequestContext());
                return Response.FromValue(((EkmPrivateEndpointListResult)result).Value, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Lists all External Key Manager (EKM) proxy private endpoints on the pool. This operation requires <c>ekm/read</c> permission.
        /// Only available with service version <see cref="KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview"/> and newer.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual async Task<Response<IReadOnlyList<KeyVaultEkmPrivateEndpoint>>> GetEkmPrivateEndpointsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(GetEkmPrivateEndpoints)}");
            scope.Start();
            try
            {
                Response result = await GetEkmPrivateEndpointsAsync(cancellationToken.ToRequestContext()).ConfigureAwait(false);
                return Response.FromValue(((EkmPrivateEndpointListResult)result).Value, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Creates an External Key Manager (EKM) proxy private endpoint. A pool may have up to two private endpoints. This operation requires <c>ekm/write</c> permission.
        /// Only available with service version <see cref="KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview"/> and newer.
        /// </summary>
        /// <param name="waitUntil"><see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation.</param>
        /// <param name="peName">The name of the private endpoint. Must be 1-24 characters, start and end with an alphanumeric character, and contain only alphanumeric characters and hyphens.</param>
        /// <param name="privateLinkServiceId">Alias of the Private Link Service that the private endpoint connects to.</param>
        /// <param name="requestMessage">An optional message shown to the Private Link Service owner when approving the private endpoint connection.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="peName"/> or <paramref name="privateLinkServiceId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="peName"/> or <paramref name="privateLinkServiceId"/> is an empty string.</exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual Operation<KeyVaultEkmPrivateEndpointOperation> CreateEkmPrivateEndpoint(WaitUntil waitUntil, string peName, string privateLinkServiceId, string requestMessage = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peName, nameof(peName));
            Argument.AssertNotNullOrEmpty(privateLinkServiceId, nameof(privateLinkServiceId));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(CreateEkmPrivateEndpoint)}");
            scope.Start();
            try
            {
                EkmPrivateEndpointCreateParameters parameters = new EkmPrivateEndpointCreateParameters(privateLinkServiceId) { RequestMessage = requestMessage };
                return CreateEkmPrivateEndpoint(waitUntil, peName, parameters, cancellationToken);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Creates an External Key Manager (EKM) proxy private endpoint. A pool may have up to two private endpoints. This operation requires <c>ekm/write</c> permission.
        /// Only available with service version <see cref="KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview"/> and newer.
        /// </summary>
        /// <param name="waitUntil"><see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation.</param>
        /// <param name="peName">The name of the private endpoint. Must be 1-24 characters, start and end with an alphanumeric character, and contain only alphanumeric characters and hyphens.</param>
        /// <param name="privateLinkServiceId">Alias of the Private Link Service that the private endpoint connects to.</param>
        /// <param name="requestMessage">An optional message shown to the Private Link Service owner when approving the private endpoint connection.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="peName"/> or <paramref name="privateLinkServiceId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="peName"/> or <paramref name="privateLinkServiceId"/> is an empty string.</exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual async Task<Operation<KeyVaultEkmPrivateEndpointOperation>> CreateEkmPrivateEndpointAsync(WaitUntil waitUntil, string peName, string privateLinkServiceId, string requestMessage = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peName, nameof(peName));
            Argument.AssertNotNullOrEmpty(privateLinkServiceId, nameof(privateLinkServiceId));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(CreateEkmPrivateEndpoint)}");
            scope.Start();
            try
            {
                EkmPrivateEndpointCreateParameters parameters = new EkmPrivateEndpointCreateParameters(privateLinkServiceId) { RequestMessage = requestMessage };
                return await CreateEkmPrivateEndpointAsync(waitUntil, peName, parameters, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Deletes an existing External Key Manager (EKM) proxy private endpoint. The operation is rejected while an EKM connection still references the private endpoint. This operation requires <c>ekm/write</c> permission.
        /// Only available with service version <see cref="KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview"/> and newer.
        /// </summary>
        /// <param name="waitUntil"><see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation.</param>
        /// <param name="peName">The name of the private endpoint to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="peName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="peName"/> is an empty string.</exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual Operation<KeyVaultEkmPrivateEndpointOperation> DeleteEkmPrivateEndpoint(WaitUntil waitUntil, string peName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peName, nameof(peName));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(DeleteEkmPrivateEndpoint)}");
            scope.Start();
            try
            {
                Operation<BinaryData> result = DeleteEkmPrivateEndpoint(waitUntil, peName, cancellationToken.ToRequestContext());
                return ProtocolOperationHelpers.Convert(result, response => (KeyVaultEkmPrivateEndpointOperation)response, ClientDiagnostics, $"{nameof(KeyVaultEkmClient)}.{nameof(DeleteEkmPrivateEndpoint)}");
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Deletes an existing External Key Manager (EKM) proxy private endpoint. The operation is rejected while an EKM connection still references the private endpoint. This operation requires <c>ekm/write</c> permission.
        /// Only available with service version <see cref="KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview"/> and newer.
        /// </summary>
        /// <param name="waitUntil"><see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation.</param>
        /// <param name="peName">The name of the private endpoint to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="peName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="peName"/> is an empty string.</exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual async Task<Operation<KeyVaultEkmPrivateEndpointOperation>> DeleteEkmPrivateEndpointAsync(WaitUntil waitUntil, string peName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(peName, nameof(peName));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(DeleteEkmPrivateEndpoint)}");
            scope.Start();
            try
            {
                Operation<BinaryData> result = await DeleteEkmPrivateEndpointAsync(waitUntil, peName, cancellationToken.ToRequestContext()).ConfigureAwait(false);
                return ProtocolOperationHelpers.Convert(result, response => (KeyVaultEkmPrivateEndpointOperation)response, ClientDiagnostics, $"{nameof(KeyVaultEkmClient)}.{nameof(DeleteEkmPrivateEndpoint)}");
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Gets the status of an External Key Manager (EKM) proxy private endpoint create or delete operation. This operation requires <c>ekm/read</c> permission.
        /// Only available with service version <see cref="KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview"/> and newer.
        /// </summary>
        /// <param name="jobId">The identifier of the private endpoint operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="jobId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="jobId"/> is an empty string.</exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual Response<KeyVaultEkmPrivateEndpointOperation> GetEkmPrivateEndpointOperationStatus(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(GetEkmPrivateEndpointOperationStatus)}");
            scope.Start();
            try
            {
                Response result = GetEkmPrivateEndpointOperationStatus(jobId, cancellationToken.ToRequestContext());
                return Response.FromValue((KeyVaultEkmPrivateEndpointOperation)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }

        /// <summary>
        /// Gets the status of an External Key Manager (EKM) proxy private endpoint create or delete operation. This operation requires <c>ekm/read</c> permission.
        /// Only available with service version <see cref="KeyVaultAdministrationClientOptions.ServiceVersion.V2026_07_01_Preview"/> and newer.
        /// </summary>
        /// <param name="jobId">The identifier of the private endpoint operation.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="ArgumentNullException"><paramref name="jobId"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="jobId"/> is an empty string.</exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code.</exception>
        public virtual async Task<Response<KeyVaultEkmPrivateEndpointOperation>> GetEkmPrivateEndpointOperationStatusAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(jobId, nameof(jobId));
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(KeyVaultEkmClient)}.{nameof(GetEkmPrivateEndpointOperationStatus)}");
            scope.Start();
            try
            {
                Response result = await GetEkmPrivateEndpointOperationStatusAsync(jobId, cancellationToken.ToRequestContext()).ConfigureAwait(false);
                return Response.FromValue((KeyVaultEkmPrivateEndpointOperation)result, result);
            }
            catch (Exception ex) { scope.Failed(ex); throw; }
        }
    }
}
