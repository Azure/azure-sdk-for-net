// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.ApplicationInsights;
using Azure.Provisioning.OperationalInsights;
using Azure.Provisioning.ResourceManager;

namespace Azure.Provisioning.Tests
{
    public class TestAppInsightsConstruct : Construct
    {
        public TestAppInsightsConstruct(IConstruct scope) : base(scope, nameof(TestAppInsightsConstruct))
        {
            if (ResourceGroup is null)
            {
                ResourceGroup = new ResourceGroup(scope, "rg");
            }

            var workspace = new OperationalInsightsWorkspace(scope);
            var workspaceId = workspace.AddOutput("workspaceId", data => data.Id);

            var appInsights = new ApplicationInsightsComponent(scope);
            appInsights.AssignProperty(data => data.WorkspaceResourceId, new Parameter(workspaceId));
        }
    }
}
