// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Queues;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    internal static class IWebJobsBuilderExtensions
    {
        public static IWebJobsBuilder UseQueueService(this IWebJobsBuilder builder, QueueServiceClient queueServiceClient)
        {
            builder.Services.Add(ServiceDescriptor.Singleton<QueueServiceClientProvider>(new FakeQueueServiceClientProvider(queueServiceClient)));
            return builder;
        }
    }
}
