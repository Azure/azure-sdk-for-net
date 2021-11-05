// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.Automanage;
using Microsoft.Azure.Management.Automanage.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;
using System.IO;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Automanage.Tests.Helpers;

namespace Automanage.Tests.ScenarioTests
{
    public class TestBase
    {
        protected bool IsRecording { get; set; }

        protected ResourceManagementClient ResourceManagementClient { get; private set; }

        public TestBase()
        {
            //// Set the path to find the recorded session files (only works in VS locally for .net452)
            HttpMockServer.RecordsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SessionRecords");
            this.IsRecording = false;
        }

        protected AutomanageClient GetAutomanagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            AutomanageClient client;
            string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE", EnvironmentVariableTarget.User);
            if (string.Equals(testMode, "record", StringComparison.OrdinalIgnoreCase))
            {
                this.IsRecording = true;
                string connectionString = Environment.GetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", EnvironmentVariableTarget.User);

                TestEnvironment env = new TestEnvironment(connectionString: connectionString);
                client = context.GetServiceClient<AutomanageClient>(
                    currentEnvironment: env,
                    handlers: handler ?? new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = System.Net.HttpStatusCode.OK });

                this.SetResourceManagementClient(env: env, context: context, handler: handler);
            }
            else
            {
                client = context.GetServiceClient<AutomanageClient>(
                    handlers: handler ?? new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = System.Net.HttpStatusCode.OK });

                this.SetResourceManagementClient(env: null, context: context, handler: handler);
            }

            return client;
        }

        private void SetResourceManagementClient(TestEnvironment env, MockContext context, RecordedDelegatingHandler handler)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            if (env != null)
            {
                this.ResourceManagementClient = context.GetServiceClient<ResourceManagementClient>(
                    currentEnvironment: env,
                    handlers: handler ?? new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = System.Net.HttpStatusCode.OK });
            }
            else
            {
                this.ResourceManagementClient = context.GetServiceClient<ResourceManagementClient>(
                    handlers: handler ?? new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = System.Net.HttpStatusCode.OK });
            }
        }

        protected bool VerifyExistenceOrCreateResourceGroup(string resourceGroupName, string location)
        {
            if (this.ResourceManagementClient == null)
            {
                throw new NullReferenceException("ResourceManagementClient not created.");
            }

            if (this.ResourceManagementClient.ResourceGroups.CheckExistence(resourceGroupName: resourceGroupName))
            {
                return true;
            }

            ResourceGroup resourceGroup = new ResourceGroup
            {
                Location = location,
                Name = resourceGroupName
            };

            resourceGroup = this.ResourceManagementClient.ResourceGroups.CreateOrUpdate(resourceGroupName: resourceGroupName, parameters: resourceGroup);

            return true;
        }

        protected static void AreEqual(IList<string> exp, IList<string> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.Equal(exp[i], act[i]);
                }
            }
        }

        protected static void AreEqual(IList<int> exp, IList<int> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.Equal(exp[i], act[i]);
                }
            }
        }

        protected static void AreEqual(IDictionary<string, string> exp, IDictionary<string, string> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.Equal(exp.Count, act.Count);
                foreach (var key in exp.Keys)
                {
                    Assert.Equal(exp[key], act[key]);
                }
            }
        }
    }
}
