// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Iot.ModelsRepository.Fetchers
{
    internal interface IModelFetcher
    {
        Task<FetchResult> FetchAsync(string dtmi, Uri repositoryUri, CancellationToken cancellationToken = default);

        FetchResult Fetch(string dtmi, Uri repositoryUri, CancellationToken cancellationToken = default);
    }
}
