using System;
using System.IO;
using System.Text.Json;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [TestFixture]
    public class TestNullTypeFix
    {
        [Test]
        public void TestNullTypeDoesNotThrow()
        {
            // This test demonstrates the issue when type property value is explicitly null
            string json = @"{
                ""principalId"": ""22fddec1-8a9f-49dc-bd72-ddaf8f215577"",
                ""tenantId"": ""72f988bf-86f1-41af-91ab-2d7cd011db47"",
                ""type"": null,
                ""userAssignedIdentities"": {}
            }";
            
            using JsonDocument document = JsonDocument.Parse(json);
            
            // This should not throw ArgumentNullException
            Assert.DoesNotThrow(() =>
            {
                var result = ManagedServiceIdentity.DeserializeManagedServiceIdentity(document.RootElement);
                // Should return default value for ManagedServiceIdentityType
                Assert.AreEqual(default(ManagedServiceIdentityType), result.ManagedServiceIdentityType);
            });
        }

        [Test]
        public void TestMissingTypeProperty()
        {
            // Test when type property is completely missing
            string json = @"{
                ""principalId"": ""22fddec1-8a9f-49dc-bd72-ddaf8f215577"",
                ""tenantId"": ""72f988bf-86f1-41af-91ab-2d7cd011db47"",
                ""userAssignedIdentities"": {}
            }";
            
            using JsonDocument document = JsonDocument.Parse(json);
            
            // This should also work fine and return default
            var result = ManagedServiceIdentity.DeserializeManagedServiceIdentity(document.RootElement);
            Assert.AreEqual(default(ManagedServiceIdentityType), result.ManagedServiceIdentityType);
        }
    }
}
