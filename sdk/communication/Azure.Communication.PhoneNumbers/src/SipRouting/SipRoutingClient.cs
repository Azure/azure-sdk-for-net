// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers.SipRouting
{
    /// <summary>
    /// The Azure Communication Services SIP routing client.
    /// </summary>
    public class SipRoutingClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly SipRoutingRestClient _restClient;

        #region public constructors - all arguments need null check

        /// <summary>
        /// Initializes a new instance of <see cref="SipRoutingClient"/> with an Azure resource connection string.
        /// </summary>
        public SipRoutingClient(string connectionString)
            : this(
                ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))),
                new SipRoutingClientOptions())
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="SipRoutingClient"/> with an Azure resource connection string and client options.
        /// </summary>
        public SipRoutingClient(string connectionString, SipRoutingClientOptions options)
            : this(
                ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new SipRoutingClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="SipRoutingClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public SipRoutingClient(Uri endpoint, AzureKeyCredential keyCredential, SipRoutingClientOptions options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                AssertNotNull(keyCredential, nameof(keyCredential)),
                options ?? new SipRoutingClientOptions())
        { }

        /// <summary>
        /// Initializes a new instance of <see cref="SipRoutingClient"/> with a token credential.
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The <see cref="TokenCredential"/> used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        /// </summary>
        public SipRoutingClient(Uri endpoint, TokenCredential tokenCredential, SipRoutingClientOptions options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                AssertNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new SipRoutingClientOptions())
        { }

        #endregion

        #region private constructors

        private SipRoutingClient(ConnectionString connectionString, SipRoutingClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private SipRoutingClient(string endpoint, AzureKeyCredential keyCredential, SipRoutingClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private SipRoutingClient(string endpoint, TokenCredential tokenCredential, SipRoutingClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private SipRoutingClient(string endpoint, HttpPipeline httpPipeline, SipRoutingClientOptions options)
        {
            _clientDiagnostics = new ClientDiagnostics(options);
            _restClient = new SipRoutingRestClient(_clientDiagnostics, httpPipeline, endpoint, options.ApiVersion);
        }

        #endregion

        /// <summary>Initializes a new instance of <see cref="SipRoutingClient"/> for mocking.</summary>
        protected SipRoutingClient()
        {
            _clientDiagnostics = null!;
            _restClient = null!;
        }

        /// <summary>
        /// Get <see cref="SipTrunk"/> with provided FQDN.
        /// </summary>
        /// <param name="fqdn">SIP trunk FQDN.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>Trunk configuration.</returns>
        /// <exception cref="KeyNotFoundException">Route with specified name wasn't found.</exception>
        public virtual Response<SipTrunk> GetTrunk(
            string fqdn,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetTrunk)}");
            scope.Start();
            try
            {
                var response = _restClient.Get(cancellationToken);
                var trunk = response.Value.Trunks[fqdn];

                if (trunk == null)
                {
                    throw new KeyNotFoundException($"SIP trunk with FQDN: {fqdn} wasn't found");
                }
                return Response.FromValue(trunk, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get <see cref="SipTrunk"/> with provided FQDN.
        /// </summary>
        /// <param name="fqdn">SIP trunk FQDN.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>Trunk configuration.</returns>
        /// <exception cref="KeyNotFoundException">Route with specified name wasn't found.</exception>
        public async virtual Task<Response<SipTrunk>> GetTrunkAsync(
            string fqdn,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetTrunk)}");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(cancellationToken).ConfigureAwait(false);
                var trunk = response.Value.Trunks[fqdn];

                if (trunk == null)
                {
                    throw new KeyNotFoundException($"SIP trunk with FQDN: {fqdn} wasn't found");
                }
                return Response.FromValue(trunk, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Set <see cref="SipTrunk"/> for resource. Other configuration settings are not affected.
        /// </summary>
        /// <param name="trunk">SIP trunk configuration.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        public virtual Response SetTrunk(
            SipTrunk trunk,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfiguration(new Dictionary<string, SipTrunk> { { trunk.Fqdn, trunk } });

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(SetTrunk)}");
            scope.Start();
            try
            {
                var response = _restClient.Patch(config, cancellationToken);
                return response.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Set <see cref="SipTrunk"/> for resource. Other configuration settings are not affected.
        /// </summary>
        /// <param name="trunk">SIP trunk configuration.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        public virtual async Task<Response> SetTrunkAsync(
            SipTrunk trunk,
            CancellationToken cancellationToken = default)
        {
            var config = new SipConfiguration(new Dictionary<string, SipTrunk> { { trunk.Fqdn, trunk } });

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(SetTrunk)}");
            scope.Start();
            try
            {
                var response = await _restClient.PatchAsync(config, cancellationToken).ConfigureAwait(false);
                return response.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete <see cref="SipTrunk"/>.
        /// </summary>
        /// <param name="fqdn">FQDN of a <see cref="SipTrunk"/> to be deleted.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        public virtual Response DeleteTrunk(
            string fqdn,
            CancellationToken cancellationToken = default)
        {
            var removeConfig = new SipConfiguration(new Dictionary<string, SipTrunk> { { fqdn, null } });

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(DeleteTrunk)}");
            scope.Start();
            try
            {
                var response = _restClient.Patch(removeConfig, cancellationToken);
                return response.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Delete <see cref="SipTrunk"/>.
        /// </summary>
        /// <param name="fqdn">FQDN of a <see cref="SipTrunk"/> to be deleted.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        public virtual async Task<Response> DeleteTrunkAsync(
            string fqdn,
            CancellationToken cancellationToken = default)
        {
            var removeConfig = new SipConfiguration(new Dictionary<string, SipTrunk> { { fqdn, null } });

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(DeleteTrunk)}");
            scope.Start();
            try
            {
                var response = await _restClient.PatchAsync(removeConfig, cancellationToken).ConfigureAwait(false);
                return response.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get List of configured <see cref="SipTrunk"/>.
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>List of configured trunks.</returns>
        public virtual Response<IReadOnlyList<SipTrunk>> GetTrunks(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetTrunks)}");
            scope.Start();
            try
            {
                var response = _restClient.Get(cancellationToken);
                return Response.FromValue((IReadOnlyList<SipTrunk>)response.Value.Trunks.Values.ToList().AsReadOnly(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get List of configured <see cref="SipTrunk"/>.
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>List of configured trunks.</returns>
        public virtual async Task<Response<IReadOnlyList<SipTrunk>>> GetTrunksAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetTrunks)}");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue((IReadOnlyList<SipTrunk>)response.Value.Trunks.Values.ToList().AsReadOnly(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get List of configured <see cref="SipTrunkRoute"/>.
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>List of configured routes.</returns>
        public virtual Response<IReadOnlyList<SipTrunkRoute>> GetRoutes(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetRoutes)}");
            scope.Start();
            try
            {
                var response = _restClient.Get(cancellationToken);
                return Response.FromValue(response.Value.Routes, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get List of configured <see cref="SipTrunkRoute"/>.
        /// </summary>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>List of configured routes.</returns>
        public virtual async Task<Response<IReadOnlyList<SipTrunkRoute>>> GetRoutesAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetRoutes)}");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Routes, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Set SIP trunks configuration for resource. Other configuration settings are not affected.
        /// </summary>
        /// <param name="trunks">New collection of <see cref="SipTrunk"/>.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        public virtual Response SetTrunks(
            IEnumerable<SipTrunk> trunks,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(SetTrunks)}");
            scope.Start();
            try
            {
                var currentConfig = _restClient.Get(cancellationToken);
                var newTrunks = trunks.ToDictionary(x => x.Fqdn, x => x);

                if (currentConfig.Value.Trunks.Count > 0)
                {
                    var trunkFqdnsToRemove = currentConfig.Value.Trunks.Keys.Where(x => !newTrunks.ContainsKey(x));

                    foreach (var fqdn in trunkFqdnsToRemove)
                    {
                        newTrunks.Add(fqdn, null);
                    }
                }

                var response = _restClient.Patch(new SipConfiguration(newTrunks), cancellationToken);
                return response.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Set SIP trunks configuration for resource. Other configuration settings are not affected.
        /// </summary>
        /// <param name="trunks">New collection of <see cref="SipTrunk"/>.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        public virtual async Task<Response> SetTrunksAsync(
            IEnumerable<SipTrunk> trunks,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(SetTrunks)}");
            scope.Start();
            try
            {
                var currentConfig = await _restClient.GetAsync(cancellationToken).ConfigureAwait(false);
                var newTrunks = trunks.ToDictionary(x => x.Fqdn, x => x);

                if (currentConfig.Value.Trunks.Count > 0)
                {
                    var trunkFqdnsToRemove = currentConfig.Value.Trunks.Keys.Where(x => !newTrunks.ContainsKey(x));

                    foreach (var fqdn in trunkFqdnsToRemove)
                    {
                        newTrunks.Add(fqdn, null);
                    }
                }

                var response = await _restClient.PatchAsync(new SipConfiguration(newTrunks), cancellationToken).ConfigureAwait(false);
                return response.GetRawResponse();
            }
            catch (Exception ex) {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Set SIP routing configuration for resource. Other configuration settings are not affected.
        /// </summary>
        /// <param name="routes">New list of <see cref="SipTrunkRoute"/>.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        public virtual Response SetRoutes(
            IReadOnlyList<SipTrunkRoute> routes,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(SetRoutes)}");
            scope.Start();
            try
            {
                var config = new SipConfiguration(routes);
                var response = _restClient.Patch(config, cancellationToken);
                return response.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Set SIP routing configuration for resource. Other configuration settings are not affected.
        /// </summary>
        /// <param name="routes">New list of <see cref="SipTrunkRoute"/>.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        public virtual async Task<Response> SetRoutesAsync(
            IReadOnlyList<SipTrunkRoute> routes,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(SetRoutes)}");
            scope.Start();
            try
            {
                var config = new SipConfiguration(routes);
                var response = await _restClient.PatchAsync(config, cancellationToken).ConfigureAwait(false);
                return response.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get List of configured <see cref="SipDomain"/>.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of configured domains</returns>
        public virtual Response<IReadOnlyList<SipDomain>> GetDomains(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetDomains)}");
            scope.Start();
            try
            {
                var response = _restClient.Get(cancellationToken);
                return Response.FromValue((IReadOnlyList<SipDomain>)response.Value.Domains.Values.ToList().AsReadOnly(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Get List of configured <see cref="SipDomain"/>.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of configured domains</returns>
        public virtual async Task<Response<IReadOnlyList<SipDomain>>> GetDomainsAsync(
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(GetDomainsAsync)}");
            scope.Start();
            try
            {
                var response = await _restClient.GetAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue((IReadOnlyList<SipDomain>)response.Value.Domains.Values.ToList().AsReadOnly(), response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Set SIP domains configuration for resource. Other configuration settings are not affected.
        /// </summary>
        /// <param name="domains">New list of <see cref="SipDomain"/>.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response SetDomains(
            IEnumerable<SipDomain> domains,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(SetDomains)}");
            scope.Start();
            try
            {
                var currentConfig = _restClient.Get(cancellationToken);
                var newDomains = domains.ToDictionary(x => x.DomainType, x => x);

                if (currentConfig.Value.Domains.Count > 0)
                {
                    var trunkFqdnsToRemove = currentConfig.Value.Domains.Keys.Where(x => !newDomains.ContainsKey(x));

                    foreach (var fqdn in trunkFqdnsToRemove)
                    {
                        newDomains.Add(fqdn, null);
                    }
                }

                var response = _restClient.Patch(new SipConfiguration(newDomains), cancellationToken);
                return response.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Set SIP domains configuration for resource. Other configuration settings are not affected.
        /// </summary>
        /// <param name="domains">New list of <see cref="SipDomain"/>.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response> SetDomainsAsync(
            IEnumerable<SipDomain> domains,
            CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(SipRoutingClient)}.{nameof(SetDomainsAsync)}");
            scope.Start();
            try
            {
                var currentConfig = await _restClient.GetAsync(cancellationToken).ConfigureAwait(false);
                var newDomains = domains.ToDictionary(x => x.DomainType, x => x);

                if (currentConfig.Value.Domains.Count > 0)
                {
                    var domainsToRemove = currentConfig.Value.Domains.Keys.Where(x => !newDomains.ContainsKey(x));

                    foreach (var domain in domainsToRemove)
                    {
                        newDomains.Add(domain, null);
                    }
                }

                var response = await _restClient.PatchAsync(new SipConfiguration(newDomains), cancellationToken).ConfigureAwait(false);
                return response.GetRawResponse();
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static T AssertNotNull<T>(T argument, string argumentName)
            where T : class
        {
            Argument.AssertNotNull(argument, argumentName);
            return argument;
        }

        private static string AssertNotNullOrEmpty(string argument, string argumentName)
        {
            Argument.AssertNotNullOrEmpty(argument, argumentName);
            return argument;
        }
    }
}
