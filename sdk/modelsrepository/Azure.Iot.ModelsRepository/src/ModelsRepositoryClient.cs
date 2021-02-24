// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Iot.ModelsRepository
{
    /// <summary>
    /// The ModelsRepositoryClient class supports operations against DTDL model repositories following the
    /// conventions of the Azure IoT Plug and Play Models repository.
    /// </summary>
    public class ModelsRepositoryClient
    {
        private readonly RepositoryHandler _repositoryHandler;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ModelsRepositoryClientOptions _clientOptions;

        /// <summary>
        /// Initializes the ModelsRepositoryClient with default client options while pointing to
        /// the Azure IoT Plug and Play Models repository https://devicemodels.azure.com for resolution.
        /// </summary>
        public ModelsRepositoryClient() : this(DefaultModelsRepository, new ModelsRepositoryClientOptions()) { }

        /// <summary>
        /// Initializes the ModelsRepositoryClient with custom client <paramref name="options"/> while pointing to
        /// the Azure IoT Plug and Play Model repository https://devicemodels.azure.com for resolution.
        /// </summary>
        /// <param name="options">
        /// ModelsRepositoryClientOptions to configure resolution and client behavior.
        /// </param>
        public ModelsRepositoryClient(ModelsRepositoryClientOptions options) : this(DefaultModelsRepository, options) { }

        /// <summary>
        /// Initializes the ModelsRepositoryClient with custom client <paramref name="options"/> while pointing to
        /// a custom <paramref name="repositoryUri"/> for resolution.
        /// </summary>
        /// <param name="repositoryUri">
        /// The model repository Uri. This can be a remote endpoint or local directory.
        /// </param>
        /// <param name="options">
        /// ModelsRepositoryClientOptions to configure resolution and client behavior.
        /// </param>
        public ModelsRepositoryClient(Uri repositoryUri, ModelsRepositoryClientOptions options = default)
        {
            if (options == null)
            {
                options = new ModelsRepositoryClientOptions();
            }

            RepositoryUri = repositoryUri;
            _clientOptions = options;
            _clientDiagnostics = new ClientDiagnostics(options);
            _repositoryHandler = new RepositoryHandler(RepositoryUri, _clientDiagnostics, _clientOptions);
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepositoryClient)}.{nameof(Resolve)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepositoryClient)}.{nameof(Resolve)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepositoryClient)}.{nameof(Resolve)}");
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
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepositoryClient)}.{nameof(Resolve)}");
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
        /// Gets the Uri associated with the ModelsRepositoryClient instance.
        /// </summary>
        public Uri RepositoryUri { get; }

        /// <summary>
        /// The global Azure IoT Models Repository endpoint used by default.
        /// </summary>
        public static Uri DefaultModelsRepository => new Uri(ModelRepositoryConstants.DefaultModelsRepository);
    }
}
