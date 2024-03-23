// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning.Tests
{
    public class TestWebSiteWithSqlBackEnd : Construct
    {
        public TestWebSiteWithSqlBackEnd(IConstruct scope)
            :base(scope, nameof(TestWebSiteWithSqlBackEnd))
        {
            if (ResourceGroup is null)
            {
                ResourceGroup = new ResourceGroup(scope, "rg");
            }

            this.AddFrontEndWebSite();
            this.AddCommonSqlDatabase();
            this.AddBackEndWebSite();
        }
    }
}
