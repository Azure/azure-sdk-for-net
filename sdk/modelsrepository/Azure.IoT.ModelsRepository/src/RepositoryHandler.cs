﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            ModelsRepositoryEventSource.Instance.InitFetcher(_clientId, repositoryUri.Scheme);
        }

        public async Task<IDictionary<string, string>> ProcessAsync(string dtmi, ModelDependencyResolution dependencyResolution, CancellationToken cancellationToken)
        {
            return await ProcessAsync(new List<string> { dtmi }, true, dependencyResolution, cancellationToken).ConfigureAwait(false);
        }

        public IDictionary<string, string> Process(string dtmi, ModelDependencyResolution dependencyResolution, CancellationToken cancellationToken)
        {
            return ProcessAsync(new List<string> { dtmi }, false, dependencyResolution, cancellationToken).EnsureCompleted();
        }

        public Task<IDictionary<string, string>> ProcessAsync(IEnumerable<string> dtmis, ModelDependencyResolution dependencyResolution, CancellationToken cancellationToken)
        {
            return ProcessAsync(dtmis, true, dependencyResolution, cancellationToken);
        }

        public IDictionary<string, string> Process(IEnumerable<string> dtmis, ModelDependencyResolution dependencyResolution, CancellationToken cancellationToken)
        {
            return ProcessAsync(dtmis, false, dependencyResolution, cancellationToken).EnsureCompleted();
        }

        private async Task<IDictionary<string, string>> ProcessAsync(
            IEnumerable<string> dtmis, bool async, ModelDependencyResolution dependencyResolution, CancellationToken cancellationToken)
        {
            var processedModels = new Dictionary<string, string>();
            Queue<string> toProcessModels = PrepareWork(dtmis);
            bool tryFromExpanded = false;

            // If ModelDependencyResolution.Enabled is requested the client will first attempt to fetch
            // metadata.json content from the target repository. The metadata object includes supported features
            // of the repository.
            // If the metadata indicates expanded models are available. The client will try to fetch pre-computed model
            // dependencies using .expanded.json.
            // If the model expanded form does not exist fall back to computing model dependencies just-in-time.
            if (dependencyResolution == ModelDependencyResolution.Enabled)
            {
                ModelsRepositoryMetadata repositoryMetadata = async
                    ? await FetchMetadataAsync(cancellationToken).ConfigureAwait(false)
                    : FetchMetadata(cancellationToken);
                if (repositoryMetadata != null &&
                    repositoryMetadata.Features != null &&
                    repositoryMetadata.Features.Expanded)
                {
                    tryFromExpanded = true;
                }
            }

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
                    ModelsRepositoryEventSource.Instance.IncorrectDtmiCasing(targetDtmi, parsedDtmi);
                    string formatErrorMsg =
                        $"{string.Format(CultureInfo.InvariantCulture, StandardStrings.GenericGetModelsError, targetDtmi)} " +
                        string.Format(CultureInfo.InvariantCulture, StandardStrings.IncorrectDtmiCasing, targetDtmi, parsedDtmi);

                    throw new RequestFailedException(formatErrorMsg, new FormatException(formatErrorMsg));
                }

                processedModels.Add(targetDtmi, result.Definition);
            }

            return processedModels;
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

        private static Queue<string> PrepareWork(IEnumerable<string> dtmis)
        {
            var toProcessModels = new Queue<string>();
            foreach (string dtmi in dtmis)
            {
                if (!DtmiConventions.IsValidDtmi(dtmi))
                {
                    ModelsRepositoryEventSource.Instance.InvalidDtmiInput(dtmi);

                    string invalidArgMsg =
                        $"{string.Format(CultureInfo.InvariantCulture, StandardStrings.GenericGetModelsError, dtmi)} " +
                        string.Format(CultureInfo.InvariantCulture, StandardStrings.InvalidDtmiFormat, dtmi);

                    throw new ArgumentException(invalidArgMsg);
                }

                toProcessModels.Enqueue(dtmi);
            }

            return toProcessModels;
        }
    }
}
