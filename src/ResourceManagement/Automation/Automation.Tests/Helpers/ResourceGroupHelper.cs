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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net.Http;

namespace Microsoft.Azure.Management.Automation.Testing
{
    public static class ResourceGroupHelper
    {

        public static AutomationManagementClient GetAutomationClient(HyakMockContext context, RecordedDelegatingHandler handler)
        {
            return context.GetServiceClient<AutomationManagementClient>();
        }

        public static ResourceManagementClient GetResourcesClient(HyakMockContext context, RecordedDelegatingHandler handler)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment(), false, new DelegatingHandler[] { handler });
        }
    }
}
