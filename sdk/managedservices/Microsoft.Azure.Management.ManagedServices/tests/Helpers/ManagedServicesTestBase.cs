// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ManagedServices.Tests.Helpers
{
    using System;    
    using Microsoft.Azure.Management.ManagedServices;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    public class ManagedServicesTestBase : TestBase, IDisposable
    {
        public ManagedServicesClient ManagedServicesClient { get; private set; }

        public ManagedServicesTestBase(MockContext context)
        {
            this.ManagedServicesClient = context.GetServiceClient<ManagedServicesClient>();
        }

        public void Dispose()
        {
            return;
        }
    }
}
