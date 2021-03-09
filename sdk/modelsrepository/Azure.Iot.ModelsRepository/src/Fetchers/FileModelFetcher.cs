// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using Azure.Core.Pipeline;

namespace Azure.Iot.ModelsRepository.Fetchers
{
    /// <summary>
    /// The FileModelFetcher is an implementation of IModelFetcher
    /// for supporting local filesystem based model content fetching.
    /// </summary>
    internal class FileModelFetcher : IModelFetcher
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        public FileModelFetcher(ClientDiagnostics clientDiagnostics)
        {
            _clientDiagnostics = clientDiagnostics;
        }

        public Task<FetchResult> FetchAsync(string dtmi, Uri repositoryUri, ModelDependencyResolution dependencyResolution, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Fetch(dtmi, repositoryUri, dependencyResolution, cancellationToken));
        }

        public FetchResult Fetch(string dtmi, Uri repositoryUri, ModelDependencyResolution dependencyResolution, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("FileModelFetcher.Fetch");
            scope.Start();

            try
            {
                var work = new Queue<string>();
                if (dependencyResolution == ModelDependencyResolution.TryFromExpanded)
                {
                    work.Enqueue(GetPath(dtmi, repositoryUri, true));
                }

                work.Enqueue(GetPath(dtmi, repositoryUri, false));

                string fnfError = string.Empty;
                while (work.Count != 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    string tryContentPath = work.Dequeue();
                    ModelsRepositoryEventSource.Instance.FetchingModelContent(tryContentPath);

                    if (File.Exists(tryContentPath))
                    {
                        return new FetchResult
                        {
                            Definition = File.ReadAllText(tryContentPath, Encoding.UTF8),
                            Path = tryContentPath
                        };
                    }

                    ModelsRepositoryEventSource.Instance.ErrorFetchingModelContent(tryContentPath);
                    fnfError = string.Format(CultureInfo.InvariantCulture, StandardStrings.ErrorFetchingModelContent, tryContentPath);
                }

                throw new RequestFailedException(
                    $"{string.Format(CultureInfo.InvariantCulture, StandardStrings.GenericGetModelsError, dtmi)} {fnfError}",
                    new FileNotFoundException(fnfError));
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        private static string GetPath(string dtmi, Uri repositoryUri, bool expanded = false)
        {
            string registryPath = repositoryUri.AbsolutePath;
            return DtmiConventions.DtmiToQualifiedPath(dtmi, registryPath, expanded);
        }
    }
}
