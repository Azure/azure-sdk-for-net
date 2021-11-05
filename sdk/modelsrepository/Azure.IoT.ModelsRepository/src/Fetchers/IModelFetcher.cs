// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.IoT.ModelsRepository.Fetchers
{
    /// <summary>
    /// The IModelFetcher is an abstraction that supports fetching
    /// repository metadata or model content via a particular protocol or mechanism of interaction.
    /// </summary>
    internal interface IModelFetcher
    {
        Task<FetchModelResult> FetchModelAsync(string dtmi, Uri repositoryUri, bool tryFromExpanded, CancellationToken cancellationToken = default);

        FetchModelResult FetchModel(string dtmi, Uri repositoryUri, bool tryFromExpanded, CancellationToken cancellationToken = default);

        Task<ModelsRepositoryMetadata> FetchMetadataAsync(Uri repositoryUri, CancellationToken cancellationToken = default);

        ModelsRepositoryMetadata FetchMetadata(Uri repositoryUri, CancellationToken cancellationToken = default);
    }
}
