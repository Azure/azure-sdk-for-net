﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management;
using Microsoft.Azure.Management.Fluent.Batch;
using Microsoft.Azure.Management.V2.Compute;
using Microsoft.Azure.Management.V2.Network;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Fluent.Tests
{
    public class TestHelper
    {
        private static string authFilePath = @"C:\my2.azureauth";

        public static IAzure CreateRollupClient()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return Azure.Configure()
            .Authenticate(credentials)
            .WithSubscription(credentials.DefaultSubscriptionId);
        }

        public static INetworkManager CreateNetworkManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return NetworkManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        public static IComputeManager CreateComputeManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return ComputeManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        public static IResourceManager CreateResourceManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            IResourceManager resourceManager = ResourceManager2.Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
            return resourceManager;
        }

        public static IBatchManager CreateBatchManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return BatchManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

    }
}