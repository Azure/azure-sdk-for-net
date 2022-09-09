// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.LoadTestService.Tests.Helpers
{
    public class LoadTestResourceHelper : LoadTestServiceManagementTestBase
    {
        private const string LoadTestResourceDescription = "sample description";

        private const string LoadTestResourceName = "loadtestsdk-resource-dotnet";

        public LoadTestResourceHelper (bool isAsync) : base(isAsync)
        {
        }

        public static string GetLoadTestResourceDescription()
        {
            return LoadTestResourceDescription;
        }

        public static ManagedServiceIdentity GetLoadTestResourceIdentity()
        {
            return new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
        }

        public static LoadTestResourceData GenerateLoadTestResourcedata(ResourceIdentifier id, string location)
        {
            return new LoadTestResourceData(id, LoadTestResourceName, LoadTestResource.ResourceType, null, new Dictionary<string, string> { }, location, GetLoadTestResourceIdentity(), GetLoadTestResourceDescription(), null, null, null);
        }
    }
}
