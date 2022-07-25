using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class PolicyAssignmentIdentityTests
    {
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
        public void TestDeserializeThenSerializeWithIdentity()
        {
            string json = "{\"identity\":{\"type\":\"SystemAssigned\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            PolicyAssignmentData data = PolicyAssignmentData.DeserializePolicyAssignmentData(element);
            Assert.AreEqual(SystemAssignedServiceIdentityType.SystemAssigned, data.Identity.SystemAssignedServiceIdentityType);

            data.Identity.SystemAssignedServiceIdentityType = SystemAssignedServiceIdentityType.None;
            string expectedNone = "{\"identity\":{\"type\":\"None\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            JsonAsserts.AssertSerialization(expectedNone, data);
        }

        [TestCase]
        public void TestDeserializeThenSerializeWithManagedIdentity()
        {
            string json = "{\"identity\":{\"type\":\"SystemAssigned\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            JsonElement element = JsonDocument.Parse(json).RootElement;
            PolicyAssignmentData data = PolicyAssignmentData.DeserializePolicyAssignmentData(element);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, data.ManagedIdentity.ManagedServiceIdentityType);

            data.ManagedIdentity.ManagedServiceIdentityType = ManagedServiceIdentityType.None;
            string expectedNone = "{\"identity\":{\"type\":\"None\"},\"properties\":{\"displayName\":\"Test My PolicyAssignment\",\"policyDefinitionId\":\"/providers/Microsoft.Authorization/policyDefinitions/06a78e20-9358-41c9-923c-fb736d382a4d\"}}";
            JsonAsserts.AssertSerialization(expectedNone, data);
        }
    }
}
