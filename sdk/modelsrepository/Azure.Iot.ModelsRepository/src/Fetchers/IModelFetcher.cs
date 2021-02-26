// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Iot.ModelsRepository.Fetchers
{
    /// <summary>
    /// The IModelFetcher is an abstraction that supports fetching
    /// model content via a particular protocol or mechanism of interaction.
    /// </summary>
    internal interface IModelFetcher
    {
        Task<FetchResult> FetchAsync(string dtmi, Uri repositoryUri, DependencyResolutionOption? resolutionOption, CancellationToken cancellationToken = default);

        FetchResult Fetch(string dtmi, Uri repositoryUri, DependencyResolutionOption? resolutionOption, CancellationToken cancellationToken = default);
    }
}
