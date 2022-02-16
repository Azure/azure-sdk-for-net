using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Tests
{
    [Parallelizable]
    public class ManagedServiceIdentityTests
    {
        private static readonly string TestAssetPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Unit", "TestAssets", "Identity");

        public JsonProperty DeserializerHelper(string filename)
        {
            var json = File.ReadAllText(Path.Combine(TestAssetPath, filename));
            JsonDocument document = JsonDocument.Parse(json);
            JsonElement rootElement = document.RootElement;
            return rootElement.EnumerateObject().First();
        }

        [TestCase]
        public void TestDeserializerValidSystemAndUserAssigned()
        {
            // var identityJsonProperty = DeserializerHelper("SystemAndUserAssignedValid.json");
            // ManagedServiceIdentity back = ManagedServiceIdentity.DeserializeManagedServiceIdentity(identityJsonProperty.Value);
            var identityJson = File.ReadAllText(Path.Combine(TestAssetPath, "SystemAndUserAssignedValid.json"));
            ManagedServiceIdentity back = JsonSerializer.Deserialize<ManagedServiceIdentity>(identityJson);
            Assert.IsTrue("22fdaec1-8b9f-49dc-bd72-ddaf8f215577".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988af-86f1-41af-91ab-2d7cd011db47".Equals(back.TenantId.ToString()));
            var user = back.UserAssignedIdentities;
            Assert.AreEqual("/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity", user.Keys.First().ToString());
            Assert.AreEqual("9a9eaa6a-b49c-4c63-afb5-3b72e3e65422", user.Values.First().ClientId.ToString());
            Assert.AreEqual("77563a98-c9d9-407b-a7af-592d21fa2153", user.Values.First().PrincipalId.ToString());
            Assert.AreEqual("SystemAssigned, UserAssigned", back.Type.ToString());
        }

        [TestCase]
        public void TestDeserializerValidSystemAndUserAssignedV3()
        {
            var identityJson = File.ReadAllText(Path.Combine(TestAssetPath, "SystemAndUserAssignedValidV3.json"));

            var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
            ManagedServiceIdentity back = JsonSerializer.Deserialize<ManagedServiceIdentity>(identityJson, serializeOptions);
            Assert.IsTrue("22fdaec1-8b9f-49dc-bd72-ddaf8f215577".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988af-86f1-41af-91ab-2d7cd011db47".Equals(back.TenantId.ToString()));
            var user = back.UserAssignedIdentities;
            Assert.AreEqual("/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity", user.Keys.First().ToString());
            Assert.AreEqual("9a9eaa6a-b49c-4c63-afb5-3b72e3e65422", user.Values.First().ClientId.ToString());
            Assert.AreEqual("77563a98-c9d9-407b-a7af-592d21fa2153", user.Values.First().PrincipalId.ToString());
            Assert.IsTrue(identityJson.Contains("SystemAssigned,UserAssigned"));
            Assert.AreEqual("SystemAssigned, UserAssigned", back.Type.ToString());
        }

        [TestCase]
        public void TestSerializerValidSystemAndUser()
        {
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"));
            var dict1 = new Dictionary<string, UserAssignedIdentity>();
            dict1["/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport"] = userAssignedIdentity;
            ManagedServiceIdentity identity = new ManagedServiceIdentity(new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"), new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), ManagedServiceIdentityType.SystemAssignedUserAssigned, dict1);
            string user = "{}";
            string expected = "{" +
                "\"type\":\"SystemAssigned, UserAssigned\"," +
                "\"userAssignedIdentities\":" +
                "{" + "\"/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport\":" +
                user + "}}";

            JsonAsserts.AssertConverterSerialization(expected, identity);
        }

        [TestCase]
        public void TestSerializerValidSystemAndUserV3()
        {
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"));
            var dict1 = new Dictionary<string, UserAssignedIdentity>();
            dict1["/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport"] = userAssignedIdentity;
            ManagedServiceIdentity identity = new ManagedServiceIdentity(new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"), new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), ManagedServiceIdentityType.SystemAssignedUserAssigned, dict1);
            string user = "{}";
            string expected = "{" +
                "\"type\":\"SystemAssigned,UserAssigned\"," +
                "\"userAssignedIdentities\":" +
                "{" + "\"/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport\":" +
                user + "}}";
            var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
            JsonAsserts.AssertConverterSerialization(expected, identity, serializeOptions);
        }

        [TestCase]
        public void TestSerializerNullUserAssignedIdentity()
        {
            var dict1 = new Dictionary<string, UserAssignedIdentity>();
            dict1["/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport"] = null;
            ManagedServiceIdentity identity = new ManagedServiceIdentity(new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"), new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), ManagedServiceIdentityType.SystemAssignedUserAssigned, dict1);
            string user = "null";
            string expected = "{" +
                "\"type\":\"SystemAssigned, UserAssigned\"," +
                "\"userAssignedIdentities\":" +
                "{" + "\"/subscriptions/6b085460-5f21-477e-ba44-1035046e9101/resourceGroups/nbhatia_test/providers/Microsoft.Web/sites/autoreport\":" +
                user + "}}";

            JsonAsserts.AssertConverterSerialization(expected, identity);
        }
    }
}
