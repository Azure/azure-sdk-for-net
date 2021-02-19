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
    /// The ModelsRepoClient class supports operations against DTDL model repositories following the
    /// conventions of the Azure IoT Plug and Play Models repository.
    /// </summary>
    public class ModelsRepoClient
    {
        private readonly RepositoryHandler _repositoryHandler;
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes the ModelsRepoClient with default client options while pointing to
        /// the Azure IoT Plug and Play Models repository https://devicemodels.azure.com for resolution.
        /// </summary>
        public ModelsRepoClient() : this(new Uri(DefaultModelsRepository), new ModelsRepoClientOptions()) { }

        /// <summary>
        /// Initializes the ModelsRepoClient with default client options while pointing to
        /// a custom <paramref name="repositoryUri"/> for resolution.
        /// </summary>
        /// <param name="repositoryUri">
        /// The model repository Uri value. This can be a remote endpoint or local directory.
        /// </param>
        public ModelsRepoClient(Uri repositoryUri) : this(repositoryUri, new ModelsRepoClientOptions()) { }

        /// <summary>
        /// Initializes the ModelsRepoClient with custom client <paramref name="options"/> while pointing to
        /// the Azure IoT Plug and Play Model repository https://devicemodels.azure.com for resolution.
        /// </summary>
        /// <param name="options">
        /// ModelsRepoClientOptions to configure resolution and client behavior.
        /// </param>
        public ModelsRepoClient(ModelsRepoClientOptions options) : this(new Uri(DefaultModelsRepository), options) { }

        /// <summary>
        /// Initializes the ModelsRepoClient with default client options while pointing to
        /// a custom <paramref name="repositoryUriStr"/> for resolution.
        /// </summary>
        /// <param name="repositoryUriStr">
        /// The model repository Uri in string format. This can be a remote endpoint or local directory.
        /// </param>
        public ModelsRepoClient(string repositoryUriStr) : this(repositoryUriStr, new ModelsRepoClientOptions()) { }

        /// <summary>
        /// Initializes the ModelsRepoClient with custom client <paramref name="options"/> while pointing to
        /// a custom <paramref name="repositoryUriStr"/> for resolution.
        /// </summary>
        /// <param name="repositoryUriStr">
        /// The model repository Uri in string format. This can be a remote endpoint or local directory.
        /// </param>
        /// <param name="options">
        /// ModelsRepoClientOptions to configure resolution and client behavior.
        /// </param>
        public ModelsRepoClient(string repositoryUriStr, ModelsRepoClientOptions options)
            : this(new Uri(repositoryUriStr), options) { }

        /// <summary>
        /// Initializes the ModelsRepoClient with custom client <paramref name="options"/> while pointing to
        /// a custom <paramref name="repositoryUri"/> for resolution.
        /// </summary>
        /// <param name="repositoryUri">
        /// The model repository Uri. This can be a remote endpoint or local directory.
        /// </param>
        /// <param name="options">
        /// ModelsRepoClientOptions to configure resolution and client behavior.
        /// </param>
        public ModelsRepoClient(Uri repositoryUri, ModelsRepoClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));

            ClientOptions = options;
            RepositoryUri = repositoryUri;
            _clientDiagnostics = new ClientDiagnostics(options);
            _repositoryHandler = new RepositoryHandler(RepositoryUri, _clientDiagnostics, ClientOptions);
        }

        /// <summary>
        /// Resolves a model definition identified by <paramref name="dtmi"/> and optionally its dependencies.
        /// </summary>
        /// <returns>
        /// An IDictionary containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="RequestFailedException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmi">A well-formed DTDL model Id. For example 'dtmi:com:example:Thermostat;1'.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage(
            "Usage",
            "AZC0015:Unexpected client method return type.",
            Justification = "<Pending>")]
        public virtual async Task<IDictionary<string, string>> ResolveAsync(string dtmi, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepoClient)}.{nameof(Resolve)}");
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
        /// An IDictionary containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="RequestFailedException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmi">A well-formed DTDL model Id. For example 'dtmi:com:example:Thermostat;1'.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage(
            "Usage",
            "AZC0015:Unexpected client method return type.",
            Justification = "<Pending>")]
        public virtual IDictionary<string, string> Resolve(string dtmi, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepoClient)}.{nameof(Resolve)}");
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
        /// An IDictionary containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="RequestFailedException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmis">A collection of well-formed DTDL model Ids.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "<Pending>")]
        public virtual async Task<IDictionary<string, string>> ResolveAsync(IEnumerable<string> dtmis, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepoClient)}.{nameof(Resolve)}");
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
        /// An IDictionary containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="RequestFailedException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmis">A collection of well-formed DTDL model Ids.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "<Pending>")]
        public virtual IDictionary<string, string> Resolve(IEnumerable<string> dtmis, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepoClient)}.{nameof(Resolve)}");
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
        /// Gets the Uri associated with the ModelsRepoClient instance.
        /// </summary>
        public Uri RepositoryUri { get; }

        /// <summary>
        /// Gets the ModelsRepoClientOptions associated with the ModelsRepoClient instance.
        /// </summary>
        public ModelsRepoClientOptions ClientOptions { get; }

        /// <summary>
        /// The global Azure IoT Models Repository endpoint used by default.
        /// </summary>
        public static string DefaultModelsRepository => ModelRepositoryConstants.DefaultModelsRepository;
    }
}
