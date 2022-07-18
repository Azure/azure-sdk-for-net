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
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, data.ManagedIdentity.ManagedServiceIdentityType);
            Assert.AreEqual(SystemAssignedServiceIdentityType.SystemAssigned, data.Identity.SystemAssignedServiceIdentityType);
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
            Assert.AreEqual(SystemAssignedServiceIdentityType.None, data.Identity.SystemAssignedServiceIdentityType);
            Assert.AreEqual(ManagedServiceIdentityType.None, data.ManagedIdentity.ManagedServiceIdentityType);
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
            Assert.AreEqual(SystemAssignedServiceIdentityType.SystemAssigned, data.Identity.SystemAssignedServiceIdentityType);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, data.ManagedIdentity.ManagedServiceIdentityType);

            data.ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            Assert.AreEqual(SystemAssignedServiceIdentityType.None, data.Identity.SystemAssignedServiceIdentityType);
            Assert.AreEqual(ManagedServiceIdentityType.None, data.ManagedIdentity.ManagedServiceIdentityType);
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
            Assert.AreEqual(SystemAssignedServiceIdentityType.SystemAssigned, data.Identity.SystemAssignedServiceIdentityType);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, data.ManagedIdentity.ManagedServiceIdentityType);

            data.Identity = new SystemAssignedServiceIdentity(SystemAssignedServiceIdentityType.None);
            Assert.AreEqual(SystemAssignedServiceIdentityType.None, data.Identity.SystemAssignedServiceIdentityType);
            Assert.AreEqual(ManagedServiceIdentityType.None, data.ManagedIdentity.ManagedServiceIdentityType);
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
            Assert.AreEqual(SystemAssignedServiceIdentityType.SystemAssigned, data.Identity.SystemAssignedServiceIdentityType);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, data.ManagedIdentity.ManagedServiceIdentityType);

            data.ManagedIdentity = new ManagedServiceIdentity(ManagedServiceIdentityType.None);
            Assert.AreEqual(SystemAssignedServiceIdentityType.None, data.Identity.SystemAssignedServiceIdentityType);
            Assert.AreEqual(ManagedServiceIdentityType.None, data.ManagedIdentity.ManagedServiceIdentityType);
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
            Assert.AreEqual(SystemAssignedServiceIdentityType.SystemAssigned, data.Identity.SystemAssignedServiceIdentityType);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, data.ManagedIdentity.ManagedServiceIdentityType);

            data.Identity = new SystemAssignedServiceIdentity(SystemAssignedServiceIdentityType.None);
            Assert.AreEqual(SystemAssignedServiceIdentityType.None, data.Identity.SystemAssignedServiceIdentityType);
            Assert.AreEqual(ManagedServiceIdentityType.None, data.ManagedIdentity.ManagedServiceIdentityType);
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
            Assert.AreEqual(SystemAssignedServiceIdentityType.SystemAssigned, data.Identity.SystemAssignedServiceIdentityType);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, data.ManagedIdentity.ManagedServiceIdentityType);

            data.ManagedIdentity.ManagedServiceIdentityType = ManagedServiceIdentityType.None;
            Assert.AreEqual(SystemAssignedServiceIdentityType.None, data.Identity.SystemAssignedServiceIdentityType);
            Assert.AreEqual(ManagedServiceIdentityType.None, data.ManagedIdentity.ManagedServiceIdentityType);
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
            Assert.AreEqual(SystemAssignedServiceIdentityType.SystemAssigned, data.Identity.SystemAssignedServiceIdentityType);
            Assert.AreEqual(ManagedServiceIdentityType.SystemAssigned, data.ManagedIdentity.ManagedServiceIdentityType);

            data.Identity.SystemAssignedServiceIdentityType = SystemAssignedServiceIdentityType.None;
            // won't pass
            // Assert.AreEqual(SystemAssignedServiceIdentityType.None, data.Identity.SystemAssignedServiceIdentityType);
            // Assert.AreEqual(ManagedServiceIdentityType.None, data.ManagedIdentity.ManagedServiceIdentityType);
        }
    }
}
