// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Perf.Options
{
    public interface IShareClientOptionsProvider
    {
        ShareClientOptions ClientOptions { get; }
    }
}
