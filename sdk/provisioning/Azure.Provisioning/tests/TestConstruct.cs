// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning.Tests
{
    public class TestConstruct : Construct
    {
        public TestConstruct(IConstruct scope) : base(scope, nameof(TestConstruct))
        {
            if (ResourceGroup is null)
            {
                ResourceGroup = new ResourceGroup(scope, "rg");
            }
        }
    }
}
