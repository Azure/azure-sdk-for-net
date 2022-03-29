// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.IoT.ModelsRepository
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
        /// <see href="https://devicemodels.azure.com">Azure IoT Models Repository</see> service global endpoint.
        /// </summary>
        public ModelsRepositoryClient() : this(new Uri(ModelsRepositoryConstants.DefaultModelsRepository),
            new ModelsRepositoryClientOptions())
        { }

        /// <summary>
        /// Initializes the ModelsRepositoryClient with custom client <paramref name="options"/> while pointing to
        /// the <see href="https://devicemodels.azure.com">Azure IoT Models Repository</see> service global endpoint.
        /// </summary>
        /// <param name="options">
        /// ModelsRepositoryClientOptions to configure client behavior.
        /// </param>
        public ModelsRepositoryClient(ModelsRepositoryClientOptions options) :
            this(new Uri(ModelsRepositoryConstants.DefaultModelsRepository), options)
        { }

        /// <summary>
        /// Initializes the ModelsRepositoryClient with custom client <paramref name="options"/> while pointing to
        /// a custom <paramref name="repositoryUri"/>.
        /// </summary>
        /// <param name="repositoryUri">
        /// The models repository Uri. This can be a remote endpoint or local directory.
        /// </param>
        /// <param name="options">
        /// ModelsRepositoryClientOptions to configure client behavior.
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
        /// A <see cref="ModelResult" /> containing the desired model content.
        /// </returns>
        /// <exception cref="RequestFailedException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmi">A well-formed DTDL model Id. For example 'dtmi:com:example:Thermostat;1'.</param>
        /// <param name="dependencyResolution">A ModelDependencyResolution value to control model resolution behavior.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage(
            "Usage",
            "AZC0015:Unexpected client method return type.",
            Justification = "Item lookup is optimized with a dictionary type, we do not expect any more than ~20 items to be returned.")]
        public virtual async Task<ModelResult> GetModelAsync(
            string dtmi, ModelDependencyResolution dependencyResolution = ModelDependencyResolution.Enabled, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepositoryClient)}.{nameof(GetModel)}");
            scope.Start();
            try
            {
                return await _repositoryHandler.ProcessAsync(dtmi, dependencyResolution, cancellationToken).ConfigureAwait(false);
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
        /// A <see cref="ModelResult" /> containing the desired model content.
        /// </returns>
        /// <exception cref="RequestFailedException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmi">A well-formed DTDL model Id. For example 'dtmi:com:example:Thermostat;1'.</param>
        /// <param name="dependencyResolution">A ModelDependencyResolution value to control model resolution behavior.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [SuppressMessage(
            "Usage",
            "AZC0015:Unexpected client method return type.",
            Justification = "Item lookup is optimized with a dictionary type, we do not expect any more than ~20 items to be returned.")]
        public virtual ModelResult GetModel(
            string dtmi, ModelDependencyResolution dependencyResolution = ModelDependencyResolution.Enabled, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ModelsRepositoryClient)}.{nameof(GetModel)}");
            scope.Start();

            try
            {
                return _repositoryHandler.Process(dtmi, dependencyResolution, cancellationToken);
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
    }
}
