// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Developer.Playwright.Interface
{
    internal interface IEntraLifecycle
    {
        Task FetchEntraIdAccessTokenAsync(CancellationToken cancellationToken);
        void FetchEntraIdAccessToken(CancellationToken cancellationToken);
        string? GetEntraIdAccessToken();
        bool DoesEntraIdAccessTokenRequireRotation();
    }
}
