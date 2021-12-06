// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Extensions.Storage;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Hosting;

[assembly: WebJobsStartup(typeof(AzureStorageWebJobsStartup))]

namespace Microsoft.Azure.WebJobs.Extensions.Storage
{
    public class AzureStorageWebJobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddAzureStorage();
        }
    }
}