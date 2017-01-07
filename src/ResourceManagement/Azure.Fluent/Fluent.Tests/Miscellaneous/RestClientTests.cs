// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace Fluent.Tests.Miscellaneous
{
    public class RestClientTests
    {
        [Fact]
        public void CanSetMultipleDelegateHandlers()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                string rgName = TestUtilities.GenerateName("rg");
                string stgName = TestUtilities.GenerateName("stg");

                IAzure azure = null;
                // Sets the intercepter so that logging and user agent in log can be asserted.
                var logAndUserAgentInterceptor = new LogAndUserAgentInterceptor();
                ServiceClientTracing.AddTracingInterceptor(logAndUserAgentInterceptor);
                ServiceClientTracing.IsEnabled = true;
                try
                {
                    AzureCredentials credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));
                    credentials.WithDefaultSubscription(null); // Clearing subscriptionId loaded from the auth
                                                               // file so that below WithDefaultSubscription()
                                                               // will force listing subscriptions and fetching
                                                               // the first.
                    azure = Microsoft.Azure.Management.Fluent.Azure
                        .Configure()
                        .WithUserAgent("azure-fluent-test", "1.0.0-prelease")
                        .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                        .WithDelegatingHandlers(TestHelper.GetHandlers())
                        .Authenticate(credentials)
                        .WithDefaultSubscription();

                    IStorageAccount storageAccount = azure.StorageAccounts
                       .Define(stgName)
                       .WithRegion(Region.US_EAST)
                       .WithNewResourceGroup(rgName)
                       .Create();

                    Assert.True(string.Equals(storageAccount.ResourceGroupName, rgName));
                }
                finally
                {
                    ServiceClientTracing.RemoveTracingInterceptor(logAndUserAgentInterceptor);
                    ServiceClientTracing.IsEnabled = false;
                    if (azure != null)
                    {
                        azure.ResourceGroups.DeleteByName(rgName);
                    }
                }
                Assert.True(logAndUserAgentInterceptor.FoundUserAgentInLog);
            }
        }

        private class LogAndUserAgentInterceptor : IServiceClientTracingInterceptor
        {
            public bool FoundUserAgentInLog { get; private set; }

            public void Configuration(string source, string name, string value)
            {
            }

            public void EnterMethod(string invocationId, object instance, string method, IDictionary<string, object> parameters)
            {
            }

            public void ExitMethod(string invocationId, object returnValue)
            {
            }

            public void Information(string message)
            {
                if (message != null)
                {
                    if (message.ToLower().Contains("User-Agent :".ToLower()))
                    {
                        if (message.ToLower().Contains("azure-fluent-test/1.0.0-prelease".ToLower()))
                        {
                            this.FoundUserAgentInLog = true;
                        }
                    }
                }
            }

            public void ReceiveResponse(string invocationId, HttpResponseMessage response)
            {
            }

            public void SendRequest(string invocationId, HttpRequestMessage request)
            {
            }

            public void TraceError(string invocationId, Exception exception)
            {
            }
        }
    }
}