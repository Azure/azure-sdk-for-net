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
using System.Text.Json;

namespace Azure.IoT.ModelsRepository.Fetchers
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

        public Task<FetchModelResult> FetchModelAsync(string dtmi, Uri repositoryUri, bool tryFromExpanded, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(FetchModel(dtmi, repositoryUri, tryFromExpanded, cancellationToken));
        }

        public FetchModelResult FetchModel(string dtmi, Uri repositoryUri, bool tryFromExpanded, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(FileModelFetcher)}.{nameof(FetchModel)}");
            scope.Start();

            try
            {
                var work = new Queue<string>();

                if (tryFromExpanded)
                {
                    work.Enqueue(DtmiConventions.GetModelUri(dtmi, repositoryUri, true).LocalPath);
                }

                work.Enqueue(DtmiConventions.GetModelUri(dtmi, repositoryUri, false).LocalPath);

                string fnfError = string.Empty;
                while (work.Count != 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    string tryContentPath = work.Dequeue();
                    ModelsRepositoryEventSource.Instance.FetchingModelContent(tryContentPath);

                    if (File.Exists(tryContentPath))
                    {
                        return new FetchModelResult
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

        public Task<ModelsRepositoryMetadata> FetchMetadataAsync(Uri repositoryUri, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(FetchMetadata(repositoryUri, cancellationToken));
        }

        public ModelsRepositoryMetadata FetchMetadata(Uri repositoryUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(FileModelFetcher)}.{nameof(FetchMetadata)}");
            scope.Start();

            string metadataPath = DtmiConventions.GetMetadataUri(repositoryUri).LocalPath;

            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                if (File.Exists(metadataPath))
                {
                    string content = File.ReadAllText(metadataPath, Encoding.UTF8);
                    return JsonSerializer.Deserialize<ModelsRepositoryMetadata>(content);
                }
            }
            catch (OperationCanceledException ex)
            {
                scope.Failed(ex);
                throw;
            }
            catch (Exception ex)
            {
                // Exceptions thrown from fetching Repository Metadata should not be terminal.
                scope.Failed(ex);
            }

            ModelsRepositoryEventSource.Instance.FailureProcessingRepositoryMetadata(metadataPath);
            return null;
        }
    }
}
