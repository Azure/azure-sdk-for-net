// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.IoT.ModelsRepository.Fetchers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.IoT.ModelsRepository
{
    internal class RepositoryHandler
    {
        private readonly IModelFetcher _modelFetcher;
        private readonly Guid _clientId;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Uri _repositoryUri;
        private readonly ModelsRepositoryClientOptions _clientOptions;
        private readonly MetadataScheduler _metadataScheduler;
        private bool _repositorySupportsExpanded;

        public RepositoryHandler(Uri repositoryUri, ClientDiagnostics clientDiagnostics, ModelsRepositoryClientOptions options)
        {
            Argument.AssertNotNull(options, nameof(options));

            _clientOptions = options;
            _clientDiagnostics = clientDiagnostics;
            _clientId = Guid.NewGuid();
            _repositoryUri = repositoryUri;
            _modelFetcher = _repositoryUri.Scheme == ModelsRepositoryConstants.UriFileSchema
                ? new FileModelFetcher(_clientDiagnostics)
                : new HttpModelFetcher(_clientDiagnostics, _clientOptions);
            _metadataScheduler = new MetadataScheduler(_clientOptions.RepositoryMetadata);
            ModelsRepositoryEventSource.Instance.InitFetcher(_clientId, repositoryUri.Scheme);
            _repositorySupportsExpanded = false;
        }

        public async Task<ModelResult> ProcessAsync(string dtmi, ModelDependencyResolution dependencyResolution, CancellationToken cancellationToken)
        {
            return await ProcessAsync(dtmi, true, dependencyResolution, cancellationToken).ConfigureAwait(false);
        }

        public ModelResult Process(string dtmi, ModelDependencyResolution dependencyResolution, CancellationToken cancellationToken)
        {
            return ProcessAsync(dtmi, false, dependencyResolution, cancellationToken).EnsureCompleted();
        }

        private async Task<ModelResult> ProcessAsync(
            string dtmi, bool async, ModelDependencyResolution dependencyResolution, CancellationToken cancellationToken)
        {
            Queue<string> toProcessModels = PrepareWork(dtmi);
            var processedModels = new Dictionary<string, string>();

            // If ModelDependencyResolution.Enabled is requested the client will first attempt to fetch
            // metadata.json content from the target repository. The metadata object includes supported features
            // of the repository.
            // If the metadata indicates expanded models are available. The client will try to fetch pre-computed model
            // dependencies using .expanded.json.
            // If the model expanded form does not exist fall back to computing model dependencies just-in-time.
            if (dependencyResolution == ModelDependencyResolution.Enabled && _metadataScheduler.ShouldFetchMetadata())
            {
                ModelsRepositoryMetadata repositoryMetadata = async
                    ? await FetchMetadataAsync(cancellationToken).ConfigureAwait(false)
                    : FetchMetadata(cancellationToken);
                if (repositoryMetadata != null &&
                    repositoryMetadata.Features != null &&
                    repositoryMetadata.Features.Expanded)
                {
                    _repositorySupportsExpanded = true;
                }
                else
                {
                    _repositorySupportsExpanded = false;
                }

                _metadataScheduler.MarkAsFetched();
            }

            // Covers case when the repository supports expanded but dependency resolution is disabled.
            bool tryFromExpanded = (dependencyResolution == ModelDependencyResolution.Enabled) && _repositorySupportsExpanded;

            while (toProcessModels.Count != 0)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string targetDtmi = toProcessModels.Dequeue();
                if (processedModels.ContainsKey(targetDtmi))
                {
                    ModelsRepositoryEventSource.Instance.SkippingPreprocessedDtmi(targetDtmi);
                    continue;
                }

                ModelsRepositoryEventSource.Instance.ProcessingDtmi(targetDtmi);

                FetchModelResult result = async
                    ? await FetchModelAsync(targetDtmi, tryFromExpanded, cancellationToken).ConfigureAwait(false)
                    : FetchModel(targetDtmi, tryFromExpanded, cancellationToken);

                if (result.FromExpanded)
                {
                    Dictionary<string, string> expanded = new ModelQuery(result.Definition).ListToDict();

                    foreach (KeyValuePair<string, string> kvp in expanded)
                    {
                        if (!processedModels.ContainsKey(kvp.Key))
                        {
                            processedModels.Add(kvp.Key, kvp.Value);
                        }
                    }

                    continue;
                }

                ModelMetadata metadata = new ModelQuery(result.Definition).ParseModel();

                if (dependencyResolution >= ModelDependencyResolution.Enabled)
                {
                    IList<string> dependencies = metadata.Dependencies;

                    if (dependencies.Count > 0)
                    {
                        ModelsRepositoryEventSource.Instance.DiscoveredDependencies(string.Join("\", \"", dependencies));
                    }

                    foreach (string dep in dependencies)
                    {
                        toProcessModels.Enqueue(dep);
                    }
                }

                string parsedDtmi = metadata.Id;
                if (!parsedDtmi.Equals(targetDtmi, StringComparison.Ordinal))
                {
                    ModelsRepositoryEventSource.Instance.IncorrectDtmi(targetDtmi, parsedDtmi);
                    string formatErrorMsg =
                        $"{string.Format(CultureInfo.InvariantCulture, StandardStrings.GenericGetModelsError, targetDtmi)} " +
                        string.Format(CultureInfo.InvariantCulture, StandardStrings.IncorrectDtmi, targetDtmi, parsedDtmi);

                    throw new RequestFailedException(formatErrorMsg, new FormatException(formatErrorMsg));
                }

                processedModels.Add(targetDtmi, result.Definition);
            }

            return new ModelResult(processedModels);
        }

        private Task<FetchModelResult> FetchModelAsync(string dtmi, bool tryFromExpanded, CancellationToken cancellationToken)
        {
            return _modelFetcher.FetchModelAsync(dtmi, _repositoryUri, tryFromExpanded, cancellationToken);
        }

        private FetchModelResult FetchModel(string dtmi, bool tryFromExpanded, CancellationToken cancellationToken)
        {
            return _modelFetcher.FetchModel(dtmi, _repositoryUri, tryFromExpanded, cancellationToken);
        }

        private Task<ModelsRepositoryMetadata> FetchMetadataAsync(CancellationToken cancellationToken)
        {
            return _modelFetcher.FetchMetadataAsync(_repositoryUri, cancellationToken);
        }

        private ModelsRepositoryMetadata FetchMetadata(CancellationToken cancellationToken)
        {
            return _modelFetcher.FetchMetadata(_repositoryUri, cancellationToken);
        }

        private static Queue<string> PrepareWork(string dtmi)
        {
            var toProcessModels = new Queue<string>();

            if (!DtmiConventions.IsValidDtmi(dtmi))
            {
                ModelsRepositoryEventSource.Instance.InvalidDtmiInput(dtmi);

                string invalidArgMsg =
                    $"{string.Format(CultureInfo.InvariantCulture, StandardStrings.GenericGetModelsError, dtmi)} " +
                    string.Format(CultureInfo.InvariantCulture, StandardStrings.InvalidDtmiFormat, dtmi);

                throw new ArgumentException(invalidArgMsg);
            }

            toProcessModels.Enqueue(dtmi);
            return toProcessModels;
        }
    }
}
