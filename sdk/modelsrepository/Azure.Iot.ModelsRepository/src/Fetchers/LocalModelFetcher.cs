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
    internal class LocalModelFetcher : IModelFetcher
    {
        private readonly bool _tryExpanded;
        private readonly ClientDiagnostics _clientDiagnostics;

        public LocalModelFetcher(ClientDiagnostics clientDiagnostics, ResolverClientOptions clientOptions)
        {
            _clientDiagnostics = clientDiagnostics;
            _tryExpanded = clientOptions.DependencyResolution == DependencyResolutionOption.TryFromExpanded;
        }

        public Task<FetchResult> FetchAsync(string dtmi, Uri repositoryUri, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Fetch(dtmi, repositoryUri, cancellationToken));
        }

        public FetchResult Fetch(string dtmi, Uri repositoryUri, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("LocalModelFetcher.Fetch");
            scope.Start();

            try
            {
                var work = new Queue<string>();

                if (_tryExpanded)
                {
                    work.Enqueue(GetPath(dtmi, repositoryUri, true));
                }

                work.Enqueue(GetPath(dtmi, repositoryUri, false));

                string fnfError = string.Empty;
                while (work.Count != 0 && !cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    string tryContentPath = work.Dequeue();
                    ResolverEventSource.Instance.FetchingModelContent(tryContentPath);

                    if (File.Exists(tryContentPath))
                    {
                        return new FetchResult
                        {
                            Definition = File.ReadAllText(tryContentPath, Encoding.UTF8),
                            Path = tryContentPath
                        };
                    }

                    ResolverEventSource.Instance.ErrorFetchingModelContent(tryContentPath);
                    fnfError = string.Format(CultureInfo.CurrentCulture, ServiceStrings.ErrorFetchingModelContent, tryContentPath);
                }

                throw new RequestFailedException(fnfError, new FileNotFoundException(fnfError));
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
