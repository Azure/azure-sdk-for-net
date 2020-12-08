// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    internal static class TestExtensions
    {
        public static StorageAccount GetStorageAccount(this IHost host)
        {
            var provider = host.Services.GetRequiredService<StorageAccountProvider>(); // $$$ ok?
            return provider.GetHost();
        }
    }
}
