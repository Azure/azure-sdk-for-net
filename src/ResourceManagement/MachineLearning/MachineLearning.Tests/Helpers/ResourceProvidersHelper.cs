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
using System.Linq;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;

namespace MachineLearning.Tests.Helpers
{
    public static class ResourceProvidersHelper
    {
        public static string GetRPApiVersion(ResourceManagementClient resourcesClient, string providerNamespace, string resourceTypeName)
        {
            Provider resourceProvider = resourcesClient.Providers.Get(providerNamespace);
            ProviderResourceType resourceType = resourceProvider.ResourceTypes.First(type => string.Equals(type.ResourceType, resourceTypeName, StringComparison.OrdinalIgnoreCase));
            return resourceType.ApiVersions.Last();
        }
    }
}
