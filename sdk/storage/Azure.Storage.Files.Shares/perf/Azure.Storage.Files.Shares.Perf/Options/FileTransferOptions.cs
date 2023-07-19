// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Storage.Files.Shares.Perf.Options
{
    public class FileTransferOptions : SizeOptions, IShareClientOptionsProvider
    {
        ShareClientOptions IShareClientOptionsProvider.ClientOptions
        {
            get
            {
                return new ShareClientOptions
                {
                };
            }
        }
    }
}