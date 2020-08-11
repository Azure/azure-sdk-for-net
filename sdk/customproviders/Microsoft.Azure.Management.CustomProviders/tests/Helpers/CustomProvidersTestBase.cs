using System;
using System.Collections.Generic;
using System.Text;

namespace CustomProviders.Tests.Helpers
{
    using System;
    using Microsoft.CustomProviders;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

    class CustomProvidersTestBase : TestBase, IDisposable
    {
        public customprovidersClient customprovidersClient { get; private set; }

        public CustomProvidersTestBase(MockContext context)
        {
            this.customprovidersClient = context.GetServiceClient<customprovidersClient>();
        }

        public void Dispose()
        {
            return;
        }
    }
}
