// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;

namespace Azure.Iot.ModelsRepository.Fetchers
{
    internal class LocalModelFetcher : IModelFetcher
    {
        private readonly bool _tryExpanded;

        public LocalModelFetcher(ResolverClientOptions clientOptions)
        {
            _tryExpanded = clientOptions.DependencyResolution == DependencyResolutionOption.TryFromExpanded;
        }

        public Task<FetchResult> FetchAsync(string dtmi, Uri repositoryUri, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Fetch(dtmi, repositoryUri, cancellationToken));
        }

        public FetchResult Fetch(string dtmi, Uri repositoryUri, CancellationToken cancellationToken = default)
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
                string tryContentPath = work.Dequeue();
                ResolverEventSource.Shared.FetchingModelContent(tryContentPath);

                if (File.Exists(tryContentPath))
                {
                    return new FetchResult()
                    {
                        Definition = File.ReadAllText(tryContentPath, Encoding.UTF8),
                        Path = tryContentPath
                    };
                }

                ResolverEventSource.Shared.ErrorFetchingModelContent(tryContentPath);
                fnfError = string.Format(CultureInfo.CurrentCulture, StandardStrings.ErrorFetchingModelContent, tryContentPath);
            }

            throw new FileNotFoundException(fnfError);
        }

        private static string GetPath(string dtmi, Uri repositoryUri, bool expanded = false)
        {
            string registryPath = repositoryUri.AbsolutePath;
            return DtmiConventions.DtmiToQualifiedPath(dtmi, registryPath, expanded);
        }
    }
}
