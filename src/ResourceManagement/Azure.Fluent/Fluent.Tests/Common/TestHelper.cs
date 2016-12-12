// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Batch.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using Xunit.Abstractions;
using Microsoft.Azure.Management.Sql.Fluent;

namespace Fluent.Tests.Common
{
    public static class TestHelper
    {
        public static ITestOutputHelper TestLogger { get; set; }

        private static string authFilePath = @"C:\my2.azureauth";

        public static void WriteLine(string format, params string[] parameters)
        {
            TestHelper.WriteLine(string.Format(format, parameters));
        }

        public static void WriteLine(string message)
        {
            if(TestHelper.TestLogger != null)
            {
                TestHelper.TestLogger.WriteLine(message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }

        public static IAzure CreateRollupClient()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return Microsoft.Azure.Management.Fluent.Azure.Configure()
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
        }

        public static INetworkManager CreateNetworkManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return NetworkManager
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        public static IComputeManager CreateComputeManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return ComputeManager
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        public static IResourceManager CreateResourceManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            IResourceManager resourceManager = Microsoft.Azure.Management.Resource.Fluent.ResourceManager.Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
            return resourceManager;
        }

        public static IBatchManager CreateBatchManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);
            return BatchManager
                .Configure()
                .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        public static ISqlManager CreateSqlManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(authFilePath);

            RestClient restClient = RestClient.Configure()
                    .WithBaseUri(AzureEnvironment.AzureGlobalCloud.ResourceManagerEndpoint)
                    .WithCredentials(credentials)
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                    .Build();
            
            return SqlManager.Authenticate(restClient, credentials.DefaultSubscriptionId);
        }
    }
}