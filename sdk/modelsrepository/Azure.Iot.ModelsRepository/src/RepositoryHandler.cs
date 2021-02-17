// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Iot.ModelsRepository.Fetchers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Iot.ModelsRepository
{
    internal class RepositoryHandler
    {
        private readonly IModelFetcher _modelFetcher;
        private readonly Guid _clientId;
        private readonly ClientDiagnostics _clientDiagnostics;

        public Uri RepositoryUri { get; }
        public ResolverClientOptions ClientOptions { get; }

        public RepositoryHandler(Uri repositoryUri, ClientDiagnostics clientdiagnostics, ResolverClientOptions options = null)
        {
            ClientOptions = options ?? new ResolverClientOptions();
            RepositoryUri = repositoryUri;
            _clientDiagnostics = clientdiagnostics;
            _modelFetcher = repositoryUri.Scheme == "file"
                ? _modelFetcher = new LocalModelFetcher(_clientDiagnostics, ClientOptions)
                : _modelFetcher = new RemoteModelFetcher(_clientDiagnostics, ClientOptions);
            _clientId = Guid.NewGuid();
            ResolverEventSource.Instance.InitFetcher(_clientId, repositoryUri.Scheme);
        }

        public async Task<IDictionary<string, string>> ProcessAsync(string dtmi, CancellationToken cancellationToken)
        {
            return await ProcessAsync(new List<string>() { dtmi }, cancellationToken).ConfigureAwait(false);
        }

        public IDictionary<string, string> Process(string dtmi, CancellationToken cancellationToken)
        {
            return Process(new List<string>() { dtmi }, cancellationToken);
        }

        public IDictionary<string, string> Process(IEnumerable<string> dtmis, CancellationToken cancellationToken)
        {
            Dictionary<string, string> processedModels = new Dictionary<string, string>();
            Queue<string> toProcessModels = PrepareWork(dtmis);

            while (toProcessModels.Count != 0)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string targetDtmi = toProcessModels.Dequeue();
                if (processedModels.ContainsKey(targetDtmi))
                {
                    ResolverEventSource.Instance.SkippingPreprocessedDtmi(targetDtmi);
                    continue;
                }

                ResolverEventSource.Instance.ProcessingDtmi(targetDtmi);

                FetchResult result = Fetch(targetDtmi, cancellationToken);

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

                ModelMetadata metadata = new ModelQuery(result.Definition).GetMetadata();

                if (ClientOptions.DependencyResolution >= DependencyResolutionOption.Enabled)
                {
                    IList<string> dependencies = metadata.Dependencies;

                    if (dependencies.Count > 0)
                    {
                        ResolverEventSource.Instance.DiscoveredDependencies(string.Join("\", \"", dependencies));
                    }

                    foreach (string dep in dependencies)
                    {
                        toProcessModels.Enqueue(dep);
                    }
                }

                string parsedDtmi = metadata.Id;
                if (!parsedDtmi.Equals(targetDtmi, StringComparison.Ordinal))
                {
                    ResolverEventSource.Instance.IncorrectDtmiCasing(targetDtmi, parsedDtmi);
                    string formatErrorMsg = string.Format(CultureInfo.CurrentCulture, ServiceStrings.IncorrectDtmiCasing, targetDtmi, parsedDtmi);
                    throw new ResolverException(targetDtmi, formatErrorMsg, new FormatException(formatErrorMsg));
                }

                processedModels.Add(targetDtmi, result.Definition);
            }

            return processedModels;
        }

        public async Task<IDictionary<string, string>> ProcessAsync(IEnumerable<string> dtmis, CancellationToken cancellationToken)
        {
            Dictionary<string, string> processedModels = new Dictionary<string, string>();
            Queue<string> toProcessModels = PrepareWork(dtmis);

            while (toProcessModels.Count != 0)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string targetDtmi = toProcessModels.Dequeue();
                if (processedModels.ContainsKey(targetDtmi))
                {
                    ResolverEventSource.Instance.SkippingPreprocessedDtmi(targetDtmi);
                    continue;
                }

                ResolverEventSource.Instance.ProcessingDtmi(targetDtmi);

                FetchResult result = await FetchAsync(targetDtmi, cancellationToken).ConfigureAwait(false);

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

                ModelMetadata metadata = new ModelQuery(result.Definition).GetMetadata();

                if (ClientOptions.DependencyResolution >= DependencyResolutionOption.Enabled)
                {
                    IList<string> dependencies = metadata.Dependencies;

                    if (dependencies.Count > 0)
                    {
                        ResolverEventSource.Instance.DiscoveredDependencies(string.Join("\", \"", dependencies));
                    }

                    foreach (string dep in dependencies)
                    {
                        toProcessModels.Enqueue(dep);
                    }
                }

                string parsedDtmi = metadata.Id;
                if (!parsedDtmi.Equals(targetDtmi, StringComparison.Ordinal))
                {
                    ResolverEventSource.Instance.IncorrectDtmiCasing(targetDtmi, parsedDtmi);
                    string formatErrorMsg = string.Format(CultureInfo.CurrentCulture, ServiceStrings.IncorrectDtmiCasing, targetDtmi, parsedDtmi);
                    throw new ResolverException(targetDtmi, formatErrorMsg, new FormatException(formatErrorMsg));
                }

                processedModels.Add(targetDtmi, result.Definition);
            }

            return processedModels;
        }

        private async Task<FetchResult> FetchAsync(string dtmi, CancellationToken cancellationToken)
        {
            try
            {
                return await _modelFetcher.FetchAsync(dtmi, RepositoryUri, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new ResolverException(dtmi, ex.Message, ex);
            }
        }

        private FetchResult Fetch(string dtmi, CancellationToken cancellationToken)
        {
            try
            {
                return _modelFetcher.Fetch(dtmi, RepositoryUri, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new ResolverException(dtmi, ex.Message, ex);
            }
        }

        private static Queue<string> PrepareWork(IEnumerable<string> dtmis)
        {
            Queue<string> toProcessModels = new Queue<string>();
            foreach (string dtmi in dtmis)
            {
                if (!DtmiConventions.IsDtmi(dtmi))
                {
                    ResolverEventSource.Instance.InvalidDtmiInput(dtmi);
                    string invalidArgMsg = string.Format(CultureInfo.CurrentCulture, ServiceStrings.InvalidDtmiFormat, dtmi);
                    throw new ResolverException(dtmi, invalidArgMsg, new ArgumentException(invalidArgMsg));
                }

                toProcessModels.Enqueue(dtmi);
            }

            return toProcessModels;
        }
    }
}
