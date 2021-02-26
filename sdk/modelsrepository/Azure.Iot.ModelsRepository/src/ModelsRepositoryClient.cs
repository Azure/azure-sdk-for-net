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
    /// conventions of the Azure IoT Models Repository.
    /// </summary>
    public class ModelsRepositoryClient
    {
        private readonly RepositoryHandler _repositoryHandler;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly ModelsRepositoryClientOptions _clientOptions;

        /// <summary>
        /// Initializes the ModelsRepositoryClient to point to the
        /// <see href="https://devicemodels.azure.com">Azure IoT Models Repository</see> service
        /// with the model dependency resolution option of TryFromExpanded.
        /// </summary>
        public ModelsRepositoryClient() : this(DefaultModelsRepository,
            new ModelsRepositoryClientOptions(resolutionOption: DependencyResolutionOption.TryFromExpanded)) { }

        /// <summary>
        /// Initializes the ModelsRepositoryClient with custom client <paramref name="options"/> while pointing to
        /// the <see href="https://devicemodels.azure.com">Azure IoT Models Repository</see> service.
        /// </summary>
        /// <param name="options">
        /// ModelsRepositoryClientOptions to configure resolution and client behavior.
        /// </param>
        public ModelsRepositoryClient(ModelsRepositoryClientOptions options) : this(DefaultModelsRepository, options) { }

        /// <summary>
        /// Initializes the ModelsRepositoryClient with custom client <paramref name="options"/> while pointing to
        /// a custom <paramref name="repositoryUri"/>.
        /// </summary>
        /// <param name="repositoryUri">
        /// The models repository Uri. This can be a remote endpoint or local directory.
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
        /// Gets a model definition identified by <paramref name="dtmi"/> and optionally its dependencies.
        /// </summary>
        /// <returns>
        /// An IDictionary containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="RequestFailedException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmi">A well-formed DTDL model Id. For example 'dtmi:com:example:Thermostat;1'.</param>
        /// <param name="resolutionOption">A DependencyResolutionOption value to force model resolution behavior.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage(
            "Usage",
            "AZC0015:Unexpected client method return type.",
            Justification = "Item lookup is optimized with a dictionary type, we do not expect any more than ~20 items to be returned. TODO: azabbasi: discuss this issue with the review board.")]
        public virtual async Task<IDictionary<string, string>> GetModelsAsync(
            string dtmi, DependencyResolutionOption? resolutionOption = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepositoryClient)}.{nameof(GetModels)}");
            scope.Start();
            try
            {
                return await _repositoryHandler.ProcessAsync(dtmi, resolutionOption, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a model definition identified by <paramref name="dtmi"/> and optionally its dependencies.
        /// </summary>
        /// <returns>
        /// An IDictionary containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="RequestFailedException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmi">A well-formed DTDL model Id. For example 'dtmi:com:example:Thermostat;1'.</param>
        /// <param name="resolutionOption">A DependencyResolutionOption value to force model resolution behavior.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage(
            "Usage",
            "AZC0015:Unexpected client method return type.",
            Justification = "Item lookup is optimized with a dictionary type, we do not expect any more than ~20 items to be returned. TODO: azabbasi: discuss this issue with the review board.")]
        public virtual IDictionary<string, string> GetModels(
            string dtmi, DependencyResolutionOption? resolutionOption = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepositoryClient)}.{nameof(GetModels)}");
            scope.Start();

            try
            {
                return _repositoryHandler.Process(dtmi, resolutionOption, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a collection of model definitions identified by <paramref name="dtmis"/> and optionally their dependencies.
        /// </summary>
        /// <returns>
        /// An IDictionary containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="RequestFailedException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmis">A collection of well-formed DTDL model Ids.</param>
        /// <param name="resolutionOption">A DependencyResolutionOption value to force model resolution behavior.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage(
            "Usage",
            "AZC0015:Unexpected client method return type.",
            Justification = "Item lookup is optimized with a dictionary type, we do not expect any more than ~20 items to be returned. TODO: azabbasi: discuss this issue with the review board.")]
        public virtual async Task<IDictionary<string, string>> GetModelsAsync(
            IEnumerable<string> dtmis, DependencyResolutionOption? resolutionOption = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepositoryClient)}.{nameof(GetModels)}");
            scope.Start();

            try
            {
                return await _repositoryHandler.ProcessAsync(dtmis, resolutionOption, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets a collection of model definitions identified by <paramref name="dtmis"/> and optionally their dependencies.
        /// </summary>
        /// <returns>
        /// An IDictionary containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="RequestFailedException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmis">A collection of well-formed DTDL model Ids.</param>
        /// <param name="resolutionOption">A DependencyResolutionOption value to force model resolution behavior.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage(
            "Usage",
            "AZC0015:Unexpected client method return type.",
            Justification = "Item lookup is optimized with a dictionary type, we do not expect any more than ~20 items to be returned. TODO: azabbasi: discuss this issue with the review board.")]
        public virtual IDictionary<string, string> GetModels(
            IEnumerable<string> dtmis, DependencyResolutionOption? resolutionOption = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepositoryClient)}.{nameof(GetModels)}");
            scope.Start();

            try
            {
                return _repositoryHandler.Process(dtmis, resolutionOption, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the Uri associated with the ModelsRepositoryClient instance.
        /// </summary>
        public Uri RepositoryUri { get; }

        /// <summary>
        /// The global Azure IoT Models Repository service endpoint used by default.
        /// </summary>
        public static Uri DefaultModelsRepository => new Uri(ModelsRepositoryConstants.DefaultModelsRepository);
    }
}
