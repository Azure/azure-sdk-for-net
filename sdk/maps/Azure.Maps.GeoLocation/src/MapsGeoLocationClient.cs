// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Maps.GeoLocation;

namespace Azure.Maps.GeoLocation
{
    /// <summary> The GeoLocation service client. </summary>
    public partial class MapsGeoLocationClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        private readonly HttpPipeline _pipeline;

        /// <summary> The restClient is used to access GeoLocation REST client. </summary>
        internal GeoLocationRestClient RestClient { get; }

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics _clientDiagnostics { get; }

        /// <summary> Initializes a new instance of GeoLocationClient. </summary>
        protected MapsGeoLocationClient()
        {
            _clientDiagnostics = null;
            _pipeline = null;
            RestClient = null;
        }

        /// <summary> Initializes a new instance of MapsGeoLocationClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps GeoLocation Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> is null. </exception>
        public MapsGeoLocationClient(AzureKeyCredential credential)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsGeoLocationClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            RestClient = new GeoLocationRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsGeoLocationClient. </summary>
        /// <param name="credential"> Shared key credential used to authenticate to an Azure Maps GeoLocation Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        public MapsGeoLocationClient(AzureKeyCredential credential, MapsGeoLocationClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = options.Endpoint;
            options ??= new MapsGeoLocationClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, "subscription-key"));
            RestClient = new GeoLocationRestClient(_clientDiagnostics, _pipeline, endpoint, null, options.Version);
        }

        /// <summary> Initializes a new instance of MapsGeoLocationClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps GeoLocation Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="clientId"/> is null. </exception>
        public MapsGeoLocationClient(TokenCredential credential, string clientId)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            var options = new MapsGeoLocationClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            RestClient = new GeoLocationRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary> Initializes a new instance of MapsGeoLocationClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Maps GeoLocation Service. </param>
        /// <param name="clientId"> Specifies which account is intended for usage in conjunction with the Azure AD security model.  It represents a unique ID for the Azure Maps account and can be retrieved from the Azure Maps management  plane Account API. To use Azure AD security in Azure Maps see the following <see href="https://aka.ms/amauthdetails">articles</see> for guidance. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="clientId"/> is null. </exception>
        public MapsGeoLocationClient(TokenCredential credential, string clientId, MapsGeoLocationClientOptions options)
        {
            Argument.AssertNotNull(credential, nameof(credential));

            var endpoint = new Uri("https://atlas.microsoft.com");
            options ??= new MapsGeoLocationClientOptions();
            _clientDiagnostics = new ClientDiagnostics(options);
            string[] scopes = { "https://atlas.microsoft.com/.default" };
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, scopes), new AzureKeyCredentialPolicy(new AzureKeyCredential(clientId), "x-ms-client-id"));
            RestClient = new GeoLocationRestClient(_clientDiagnostics, _pipeline, endpoint, clientId, options.Version);
        }

        /// <summary>
        /// This service will return the ISO country code for the provided IP address. Developers can use this information  to block or alter certain content based on geographical locations where the application is being viewed from.
        /// </summary>
        /// <param name="ipAddress"> The IP address. Both IPv4 and IPv6 are allowed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        public virtual async Task<Response<IpAddressToLocationResult>> GetLocationAsync(string ipAddress, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsGeoLocationClient.GetLocation");
            scope.Start();
            try
            {
                return await RestClient.GetLocationAsync(
                    ipAddress,
                    JsonFormat.Json,
                    cancellationToken
                ).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// This service will return the ISO country code for the provided IP address. Developers can use this information  to block or alter certain content based on geographical locations where the application is being viewed from.
        /// </summary>
        /// <param name="ipAddress"> The IP address. Both IPv4 and IPv6 are allowed. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. Details of the response body schema are in the Remarks section below. </returns>
        public virtual Response<IpAddressToLocationResult> GetLocation(string ipAddress, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("MapsGeoLocationClient.GetLocation");
            scope.Start();
            try
            {
                return RestClient.GetLocation(
                    ipAddress,
                    JsonFormat.Json,
                    cancellationToken
                );
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
