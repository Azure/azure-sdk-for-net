// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batch.Tests.ScenarioTests
{
    public class BatchScenarioTestBase : TestBase
    {
        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public BatchManagementClient BatchManagementClient { get; private set; }

        public string Location { get; private set; }

        protected MockContext StartMockContextAndInitializeClients(string className,
            // Automatically populates the methodName parameter with the calling method, which
            // gets used to generate recorder file names.
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = "")
        {
            MockContext context = MockContext.Start(className, methodName);
            Initialize(context);

            return context;
        }

        private void Initialize(MockContext context)
        {
            this.ResourceManagementClient = context.GetServiceClient<ResourceManagementClient>();
            this.BatchManagementClient = context.GetServiceClient<BatchManagementClient>();

            Provider provider = this.ResourceManagementClient.Providers.Get("Microsoft.Batch");
            IList<string> locations = provider.ResourceTypes.Where((resType) => resType.ResourceType == "batchAccounts").First().Locations;
            this.Location = locations.DefaultIfEmpty("westus").First();
        }
    }
}
