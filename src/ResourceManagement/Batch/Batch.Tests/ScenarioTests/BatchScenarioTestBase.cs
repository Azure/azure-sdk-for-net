//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

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
