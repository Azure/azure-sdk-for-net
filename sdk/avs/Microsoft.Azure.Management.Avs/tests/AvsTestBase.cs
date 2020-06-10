// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.Avs;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Avs.Tests
{
    class AvsTestBase : TestBase, IDisposable
    {
        public AvsClient AvsClient { get; private set; }

        public AvsTestBase(MockContext context)
        {
            this.AvsClient = context.GetServiceClient<AvsClient>();
        }

        public void Dispose()
        {
            this.AvsClient.Dispose();
        }
    }
}
