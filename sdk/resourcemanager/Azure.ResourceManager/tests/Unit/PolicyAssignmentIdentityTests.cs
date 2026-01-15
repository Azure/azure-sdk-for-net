using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
#pragma warning disable CS0618 // This type is obsolete and will be removed in a future release.
    [Parallelizable]
    public class PolicyAssignmentIdentityTests
    {
        [TestCase]
        public void TestSetManagedIdentityWhenNull()
        {
            PolicyAssignmentData data = new PolicyAssignmentData
            {
                DisplayName = $"Test My PolicyAssignment",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d",
            };
            Assert.IsNull(data.ManagedIdentity);
            Assert.IsNull(data.Identity);

            data.ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.SystemAssigned));

            data.ManagedIdentity = null;
            Assert.IsNull(data.Identity);
            Assert.IsNull(data.ManagedIdentity);
        }

        [TestCase]
        public void TestSetIdentityWhenNull()
        {
            PolicyAssignmentData data = new PolicyAssignmentData
            {
                DisplayName = $"Test My PolicyAssignment",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d",
            };
            Assert.IsNull(data.ManagedIdentity);
            Assert.IsNull(data.Identity);

            data.Identity = new SystemAssignedServiceIdentity(SystemAssignedServiceIdentityType.None);
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.None));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));

            data.Identity = null;
            Assert.IsNull(data.Identity);
            Assert.IsNull(data.ManagedIdentity);
        }

        [TestCase]
        public void TestSetManagedIdentityWhenManagedIdentitySet()
        {
            PolicyAssignmentData data = new PolicyAssignmentData
            {
                DisplayName = $"Test My PolicyAssignment",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d",
                ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.SystemAssigned));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));

            data.ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.None));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
        }

        [TestCase]
        public void TestSetIdentityWhenIdentitySet()
        {
            PolicyAssignmentData data = new PolicyAssignmentData
            {
                DisplayName = $"Test My PolicyAssignment",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d",
                Identity = new SystemAssignedServiceIdentity(SystemAssignedServiceIdentityType.SystemAssigned)
            };
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.SystemAssigned));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));

            data.Identity = new SystemAssignedServiceIdentity(SystemAssignedServiceIdentityType.None);
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.None));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
        }

        [TestCase]
        public void TestSetManagedIdentityWhenIdentitySet()
        {
            PolicyAssignmentData data = new PolicyAssignmentData
            {
                DisplayName = $"Test My PolicyAssignment",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d",
                Identity = new SystemAssignedServiceIdentity(SystemAssignedServiceIdentityType.SystemAssigned)
            };
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.SystemAssigned));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));

            data.ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.None));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
        }

        [TestCase]
        public void TestSetIdentityWhenManagedIdentitySet()
        {
            PolicyAssignmentData data = new PolicyAssignmentData
            {
                DisplayName = $"Test My PolicyAssignment",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d",
                ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.SystemAssigned));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));

            data.Identity = new SystemAssignedServiceIdentity(SystemAssignedServiceIdentityType.None);
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.None));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
        }

        [TestCase]
        public void TestSetManagedIdentityByType()
        {
            PolicyAssignmentData data = new PolicyAssignmentData
            {
                DisplayName = $"Test My PolicyAssignment",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d",
                ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.SystemAssigned));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));

            data.ManagedIdentity.ManagedServiceIdentityType = ManagedServiceIdentityType.None;
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.None));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
        }

        [TestCase]
        public void TestSetIdentityByType()
        {
            PolicyAssignmentData data = new PolicyAssignmentData
            {
                DisplayName = $"Test My PolicyAssignment",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d",
                ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.SystemAssigned));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));

            data.Identity.SystemAssignedServiceIdentityType = SystemAssignedServiceIdentityType.None;
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.None));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.None));
        }

        [TestCase]
        public void TestSerializeWithNullIdentity()
        {
            PolicyAssignmentData data = new PolicyAssignmentData
            {
                DisplayName = $"Test My PolicyAssignment",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d",
            };

            string expected = "{\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            JsonAsserts.AssertSerialization(expected, data);
        }

        [TestCase]
        public void TestSerializeWithIdentity()
        {
            PolicyAssignmentData data = new PolicyAssignmentData
            {
                DisplayName = $"Test My PolicyAssignment",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d",
                Identity = new SystemAssignedServiceIdentity(SystemAssignedServiceIdentityType.SystemAssigned)
            };

            string expectedSystemAssigned = "{\"identity\":{\"type\":\"SystemAssigned\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            JsonAsserts.AssertSerialization(expectedSystemAssigned, data);

            data.Identity = new SystemAssignedServiceIdentity(SystemAssignedServiceIdentityType.None);
            string expectedNone = "{\"identity\":{\"type\":\"None\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            JsonAsserts.AssertSerialization(expectedNone, data);

            data.Identity.SystemAssignedServiceIdentityType = SystemAssignedServiceIdentityType.SystemAssigned;
            JsonAsserts.AssertSerialization(expectedSystemAssigned, data);
        }

        [TestCase]
        public void TestSerializeWithManagedIdentity()
        {
            PolicyAssignmentData data = new PolicyAssignmentData
            {
                DisplayName = $"Test My PolicyAssignment",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d",
                ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned)
            };

            string expectedSystemAssigned = "{\"identity\":{\"type\":\"SystemAssigned\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            JsonAsserts.AssertSerialization(expectedSystemAssigned, data);

            data.ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            string expectedNone = "{\"identity\":{\"type\":\"None\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            JsonAsserts.AssertSerialization(expectedNone, data);

            data.ManagedIdentity.ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned;
            JsonAsserts.AssertSerialization(expectedSystemAssigned, data);
        }

        [TestCase]
        public void TestSerializeWithMixedIdentity()
        {
            string expectedNoIdentity = "{\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            string expectedNone = "{\"identity\":{\"type\":\"None\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            string expectedSystemAssigned = "{\"identity\":{\"type\":\"SystemAssigned\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";

            PolicyAssignmentData data = new PolicyAssignmentData
            {
                DisplayName = $"Test My PolicyAssignment",
                PolicyDefinitionId = "/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d",
            };
            JsonAsserts.AssertSerialization(expectedNoIdentity, data);

            data.Identity = new SystemAssignedServiceIdentity(SystemAssignedServiceIdentityType.SystemAssigned);
            data.ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            JsonAsserts.AssertSerialization(expectedNone, data);

            data.ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned);
            data.Identity = new SystemAssignedServiceIdentity(SystemAssignedServiceIdentityType.None);
            JsonAsserts.AssertSerialization(expectedNone, data);

            data.Identity.SystemAssignedServiceIdentityType = SystemAssignedServiceIdentityType.None;
            data.ManagedIdentity.ManagedServiceIdentityType = ManagedServiceIdentityType.SystemAssigned;
            JsonAsserts.AssertSerialization(expectedSystemAssigned, data);

            data.ManagedIdentity.ManagedServiceIdentityType = ManagedServiceIdentityType.None;
            data.Identity.SystemAssignedServiceIdentityType = SystemAssignedServiceIdentityType.SystemAssigned;
            JsonAsserts.AssertSerialization(expectedSystemAssigned, data);
        }

        [TestCase]
        public void TestDeserializeThenSerializeWithIdentity()
        {
            string json = "{\"identity\":{\"principalId\":\"22fdaec1-8b9f-49dc-bd72-ddaf8f215577\",\"tenantId\":\"72f988af-86f1-41af-91ab-2d7cd011db47\",\"type\":\"SystemAssigned\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            using var jsonDocument = JsonDocument.Parse(json);
            JsonElement element = jsonDocument.RootElement;
            PolicyAssignmentData data = PolicyAssignmentData.DeserializePolicyAssignmentData(element);
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.SystemAssigned));
            Assert.That(data.Identity.PrincipalId.ToString(), Is.EqualTo("22fdaec1-8b9f-49dc-bd72-ddaf8f215577"));
            Assert.That(data.Identity.TenantId.ToString(), Is.EqualTo("72f988af-86f1-41af-91ab-2d7cd011db47"));
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(data.ManagedIdentity.PrincipalId.ToString(), Is.EqualTo("22fdaec1-8b9f-49dc-bd72-ddaf8f215577"));
            Assert.That(data.ManagedIdentity.TenantId.ToString(), Is.EqualTo("72f988af-86f1-41af-91ab-2d7cd011db47"));

            data.Identity.SystemAssignedServiceIdentityType = SystemAssignedServiceIdentityType.None;
            string expectedNone = "{\"identity\":{\"type\":\"None\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            JsonAsserts.AssertSerialization(expectedNone, data);
        }

        [TestCase]
        public void TestDeserializeThenSerializeWithManagedIdentity()
        {
            string json = "{\"identity\":{\"principalId\":\"22fdaec1-8b9f-49dc-bd72-ddaf8f215577\",\"tenantId\":\"72f988af-86f1-41af-91ab-2d7cd011db47\",\"type\":\"SystemAssigned\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            using var jsonDocument = JsonDocument.Parse(json);
            JsonElement element = jsonDocument.RootElement;
            PolicyAssignmentData data = PolicyAssignmentData.DeserializePolicyAssignmentData(element);
            Assert.That(data.ManagedIdentity.ManagedServiceIdentityType, Is.EqualTo(ManagedServiceIdentityType.SystemAssigned));
            Assert.That(data.ManagedIdentity.PrincipalId.ToString(), Is.EqualTo("22fdaec1-8b9f-49dc-bd72-ddaf8f215577"));
            Assert.That(data.ManagedIdentity.TenantId.ToString(), Is.EqualTo("72f988af-86f1-41af-91ab-2d7cd011db47"));
            Assert.That(data.Identity.SystemAssignedServiceIdentityType, Is.EqualTo(SystemAssignedServiceIdentityType.SystemAssigned));
            Assert.That(data.Identity.PrincipalId.ToString(), Is.EqualTo("22fdaec1-8b9f-49dc-bd72-ddaf8f215577"));
            Assert.That(data.Identity.TenantId.ToString(), Is.EqualTo("72f988af-86f1-41af-91ab-2d7cd011db47"));

            data.ManagedIdentity.ManagedServiceIdentityType = ManagedServiceIdentityType.None;
            string expectedNone = "{\"identity\":{\"type\":\"None\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            JsonAsserts.AssertSerialization(expectedNone, data);
        }
    }
#pragma warning restore CS0618 // This type is obsolete and will be removed in a future release.
}
