// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Education.Tests.Scenario
{
    public class GrantDetailsResourceTests : EducationManagementTestBase
    {
        public GrantDetailsResourceTests(bool isAsync)
            : base(isAsync)
        {
        }

        // Grants are tenant-scoped under a billing account/profile; verify the generated
        // resource identifier composes correctly and the ArmClient hands back a resource
        // client bound to that id (no service call required).
        [RecordedTest]
        public void GetGrantDetailsResource_ComposesTenantScopedId()
        {
            ResourceIdentifier id = GrantDetailsResource.CreateResourceIdentifier("myBillingAccount", "myBillingProfile");

            GrantDetailsResource resource = Client.GetGrantDetailsResource(id);

            Assert.That(resource.Id, Is.EqualTo(id));
            Assert.That(resource.Id.ResourceType.ToString(), Is.EqualTo("Microsoft.Education/grants"));
        }
    }
}
