// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.AVS;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace AVS.Tests
{
    class AvsTestBase : TestBase, IDisposable
    {
        public AzureVMwareSolutionAPIClient AvsClient { get; private set; }

        public AvsTestBase(MockContext context)
        {
            this.AvsClient = context.GetServiceClient<AzureVMwareSolutionAPIClient>();
        }

        public void Dispose()
        {
            this.AzureVMwareSolutionAPIClient.Dispose();
        }
    }
}
