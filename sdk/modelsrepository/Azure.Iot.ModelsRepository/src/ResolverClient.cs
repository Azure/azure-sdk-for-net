// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Iot.ModelsRepository
{
    /// <summary>
    /// The <c>ResolverClient</c> class supports DTDL model resolution providing functionality to
    /// resolve models by retrieving model definitions and their dependencies.
    /// </summary>
    public class ResolverClient
    {
        private readonly RepositoryHandler _repositoryHandler;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes the <c>ResolverClient</c> with default client options while pointing to
        /// the Azure IoT Plug and Play Model repository https://devicemodels.azure.com for resolution.
        /// </summary>
        public ResolverClient() : this(new Uri(DefaultModelsRepository), new ResolverClientOptions()) { }

        /// <summary>
        /// Initializes the <c>ResolverClient</c> with default client options while pointing to
        /// a custom <paramref name="repositoryUri"/> for resolution.
        /// </summary>
        /// <param name="repositoryUri">
        /// The model repository <c>Uri</c> value. This can be a remote endpoint or local directory.
        /// </param>
        public ResolverClient(Uri repositoryUri) : this(repositoryUri, new ResolverClientOptions()) { }

        /// <summary>
        /// Initializes the <c>ResolverClient</c> with custom client <paramref name="options"/> while pointing to
        /// the Azure IoT Plug and Play Model repository https://devicemodels.azure.com for resolution.
        /// </summary>
        /// <param name="options">
        /// <c>ResolverClientOptions</c> to configure resolution and client behavior.
        /// </param>
        public ResolverClient(ResolverClientOptions options) : this(new Uri(DefaultModelsRepository), options) { }

        /// <summary>
        /// Initializes the <c>ResolverClient</c> with default client options while pointing to
        /// a custom <paramref name="repositoryUriStr"/> for resolution.
        /// </summary>
        /// <param name="repositoryUriStr">
        /// The model repository <c>Uri</c> in string format. This can be a remote endpoint or local directory.
        /// </param>
        public ResolverClient(string repositoryUriStr) : this(repositoryUriStr, new ResolverClientOptions()) { }

        /// <summary>
        /// Initializes the <c>ResolverClient</c> with custom client <paramref name="options"/> while pointing to
        /// a custom <paramref name="repositoryUriStr"/> for resolution.
        /// </summary>
        /// <param name="repositoryUriStr">
        /// The model repository <c>Uri</c> in string format. This can be a remote endpoint or local directory.
        /// </param>
        /// <param name="options">
        /// <c>ResolverClientOptions</c> to configure resolution and client behavior.
        /// </param>
        public ResolverClient(string repositoryUriStr, ResolverClientOptions options)
            : this(new Uri(repositoryUriStr), options) { }

        /// <summary>
        /// Initializes the <c>ResolverClient</c> with custom client <paramref name="options"/> while pointing to
        /// a custom <paramref name="repositoryUri"/> for resolution.
        /// </summary>
        /// <param name="repositoryUri">
        /// The model repository <c>Uri</c>. This can be a remote endpoint or local directory.
        /// </param>
        /// <param name="options">
        /// <c>ResolverClientOptions</c> to configure resolution and client behavior.
        /// </param>
        public ResolverClient(Uri repositoryUri, ResolverClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));

            _clientDiagnostics = new ClientDiagnostics(options);
            _repositoryHandler = new RepositoryHandler(repositoryUri, _clientDiagnostics, options);
        }

        /// <summary>
        /// Resolves a model definition identified by <paramref name="dtmi"/> and optionally its dependencies.
        /// </summary>
        /// <returns>
        /// An <c>IDictionary</c> containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="ResolverException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmi">A well-formed DTDL model Id. For example 'dtmi:com:example:Thermostat;1'.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage(
            "Usage",
            "AZC0015:Unexpected client method return type.",
            Justification = "<Pending>")]
        public virtual async Task<IDictionary<string, string>> ResolveAsync(string dtmi, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ResolverClient)}.{nameof(Resolve)}");
            scope.Start();
            try
            {
                return await _repositoryHandler.ProcessAsync(dtmi, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Resolves a model definition identified by <paramref name="dtmi"/> and optionally its dependencies.
        /// </summary>
        /// <returns>
        /// An <c>IDictionary</c> containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="ResolverException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmi">A well-formed DTDL model Id. For example 'dtmi:com:example:Thermostat;1'.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage(
            "Usage",
            "AZC0015:Unexpected client method return type.",
            Justification = "<Pending>")]
        public virtual IDictionary<string, string> Resolve(string dtmi, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ResolverClient)}.{nameof(Resolve)}");
            scope.Start();

            try
            {
                return _repositoryHandler.Process(dtmi, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Resolves a collection of model definitions identified by <paramref name="dtmis"/> and optionally their dependencies.
        /// </summary>
        /// <returns>
        /// An <c>IDictionary</c> containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="ResolverException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmis">A collection of well-formed DTDL model Ids.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "<Pending>")]
        public virtual async Task<IDictionary<string, string>> ResolveAsync(IEnumerable<string> dtmis, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ResolverClient)}.{nameof(Resolve)}");
            scope.Start();

            try
            {
                return await _repositoryHandler.ProcessAsync(dtmis, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Resolves a collection of model definitions identified by <paramref name="dtmis"/> and optionally their dependencies.
        /// </summary>
        /// <returns>
        /// An <c>IDictionary</c> containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="ResolverException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmis">A collection of well-formed DTDL model Ids.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "<Pending>")]
        public virtual IDictionary<string, string> Resolve(IEnumerable<string> dtmis, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ResolverClient)}.{nameof(Resolve)}");
            scope.Start();

            try
            {
                return _repositoryHandler.Process(dtmis, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Evaluates whether an input <paramref name="dtmi"/> is valid.
        /// </summary>
        public static bool IsValidDtmi(string dtmi) => DtmiConventions.IsDtmi(dtmi);

        /// <summary>
        /// Gets the <c>Uri</c> associated with the ResolverClient instance.
        /// </summary>
        public Uri RepositoryUri => _repositoryHandler.RepositoryUri;

        /// <summary>
        /// Gets the <c>ResolverClientOptions</c> associated with the ResolverClient instance.
        /// </summary>
        public ResolverClientOptions ClientOptions => _repositoryHandler.ClientOptions;

        /// <summary>
        /// Azure Device Models Repository used by default.
        /// </summary>
        public static string DefaultModelsRepository => ModelRepositoryConstants.DefaultModelsRepository;
    }
}
