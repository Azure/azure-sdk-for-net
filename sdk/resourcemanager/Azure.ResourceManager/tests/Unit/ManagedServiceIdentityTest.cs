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
            using JsonDocument document = JsonDocument.Parse(json);
            JsonElement rootElement = document.RootElement.Clone();
            return rootElement.EnumerateObject().First();
        }

        [TestCase]
        public void TestDeserializerInvalidDefaultJson()
        {
            JsonElement invalid = default(JsonElement);
            Assert.Throws<InvalidOperationException>(delegate { ManagedServiceIdentity.DeserializeManagedServiceIdentity(invalid); });
        }

        [TestCase]
        public void TestDeserializerInvalidNullType()
        {
            var identityJsonProperty = DeserializerHelper("InvalidTypeIsNull.json");
            Assert.AreEqual(default(ManagedServiceIdentityType), ManagedServiceIdentity.DeserializeManagedServiceIdentity(identityJsonProperty.Value).ManagedServiceIdentityType);
        }

        [TestCase]
        public void TestDeserializerInvalidType()
        {
            var identityJsonProperty = DeserializerHelper("InvalidType.json");
            ManagedServiceIdentity back = ManagedServiceIdentity.DeserializeManagedServiceIdentity(identityJsonProperty.Value);
            var user = back.UserAssignedIdentities;
            Assert.AreEqual("/subscriptions/d96407f5-db8f-4325-b582-84ad21310bd8/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity", user.Keys.First().ToString());
            Assert.AreEqual("9a2eaa6a-b49c-4a63-afb5-3b72e3e65422", user.Values.First().ClientId.ToString());
            Assert.AreEqual("77563a98-c9d9-4f7b-a7af-592d21fa2153", user.Values.First().PrincipalId.ToString());
        }

        [TestCase]
        public void TestDeserializerNoneWithEmptyStringIds()
        {
            var identityJsonProperty = DeserializerHelper("NoneEmptyStringIds.json");
            var msi = ManagedServiceIdentity.DeserializeManagedServiceIdentity(identityJsonProperty.Value);
            Assert.IsNull(msi.PrincipalId);
            Assert.IsNull(msi.TenantId);
        }

        [TestCase]
        public void TestDeserializerValidInnerExtraField()
        {
            var identityJsonProperty = DeserializerHelper("SystemAndUserAssignedInnerExtraField.json");
            ManagedServiceIdentity back = ManagedServiceIdentity.DeserializeManagedServiceIdentity(identityJsonProperty.Value);
            Assert.IsTrue("22fddec1-8b9f-49dc-bd72-ddaf8f215577".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988bf-86f1-41af-91ab-2d7cd011db47".Equals(back.TenantId.ToString()));
            var user = back.UserAssignedIdentities;
            Assert.AreEqual("/subscriptions/db1ab6f0-4769-4b27-9dde-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity", user.Keys.First().ToString());
            Assert.AreEqual("9a9eaa6a-b49c-4c63-afb5-3b72e3e65422", user.Values.First().ClientId.ToString());
            Assert.AreEqual("77563a98-c9d9-407b-a7af-592d21fa2153", user.Values.First().PrincipalId.ToString());
        }

        [TestCase]
        public void TestDeserializerValidMiddleExtraField()
        {
            var identityJsonProperty = DeserializerHelper("SystemAndUserAssignedMiddleExtraField.json");
            ManagedServiceIdentity back = ManagedServiceIdentity.DeserializeManagedServiceIdentity(identityJsonProperty.Value);
            Assert.IsTrue("22fddec1-8b9f-49dc-bd72-ddaf8f215577".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988bf-86f1-41af-91ab-2d7cd011db47".Equals(back.TenantId.ToString()));
            var user = back.UserAssignedIdentities;
            Assert.AreEqual("/subscriptions/db1ab6f0-4769-4b27-9dde-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity", user.Keys.First().ToString());
            Assert.AreEqual("9a9eaa6a-b49c-4c63-afb5-3b72e3e65422", user.Values.First().ClientId.ToString());
            Assert.AreEqual("77563a98-c9d9-407b-a7af-592d21fa2153", user.Values.First().PrincipalId.ToString());
        }

        [TestCase]
        public void TestDeserializerValidOuterExtraField()
        {
            var json = File.ReadAllText(Path.Combine(TestAssetPath, "SystemAndUserAssignedOuterExtraField.json"));
            using JsonDocument document = JsonDocument.Parse(json);
            JsonElement rootElement = document.RootElement;
            var identityJsonProperty = rootElement.EnumerateObject().ElementAt(1);
            ManagedServiceIdentity back = ManagedServiceIdentity.DeserializeManagedServiceIdentity(identityJsonProperty.Value);
            Assert.IsTrue("22fddec1-8b9f-49dc-bd72-ddaf8f215577".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988bf-86f1-41af-91ab-2d7cd011db47".Equals(back.TenantId.ToString()));
            var user = back.UserAssignedIdentities;
            Assert.AreEqual("/subscriptions/db1ab6f0-3466-4b27-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity", user.Keys.First().ToString());
            Assert.AreEqual("9a2eaa6b-b49c-4c63-afb5-3b72e3e65422", user.Values.First().ClientId.ToString());
            Assert.AreEqual("7756fa98-c9d9-477b-a7af-592d21fa2153", user.Values.First().PrincipalId.ToString());
        }

        [TestCase]
        public void TestDeserializerValidSystemAndMultUser()
        {
            var identityJsonProperty = DeserializerHelper("SystemAndUserAssignedValidMultIdentities.json");
            ManagedServiceIdentity back = ManagedServiceIdentity.DeserializeManagedServiceIdentity(identityJsonProperty.Value);
            Assert.IsTrue("22fddec1-8b9f-49dc-bd72-ddaf8f215570".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988bf-86f1-41af-91ab-2d7cd011db40".Equals(back.TenantId.ToString()));
            var user = back.UserAssignedIdentities;
            Assert.AreEqual("/subscriptions/1ab27dfb-d2ee-4283-b1e3-550deaebb8e4/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity0", user.Keys.First().ToString());
            Assert.AreEqual("9a2eaa6a-b49c-4c63-afb5-3b72e3e65422", user.Values.First().ClientId.ToString());
            Assert.AreEqual("77563a98-c9d9-477b-a7af-592d21fa2153", user.Values.First().PrincipalId.ToString());
            Assert.AreEqual("/subscriptions/d96407f5-db8f-4325-b582-84ad21310bd8/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity1", user.Keys.ElementAt(1).ToString());
            Assert.AreEqual("9a2eaa6a-b49c-4c63-afb5-3b72e3c65420", user.Values.ElementAt(1).ClientId.ToString());
            Assert.AreEqual("77563a98-c9d9-477b-a7af-592d2bfa2150", user.Values.ElementAt(1).PrincipalId.ToString());
        }

        [TestCase]
        public void TestDeserializerValidSystemAssigned()
        {
            var identityJsonProperty = DeserializerHelper("SystemAssigned.json");
            ManagedServiceIdentity back = ManagedServiceIdentity.DeserializeManagedServiceIdentity(identityJsonProperty.Value);
            Assert.IsTrue("22fddec1-8b9f-49dc-bd72-ddaf8f215577".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988bf-86f1-41af-91ab-2d7cd011db47".Equals(back.TenantId.ToString()));
            Assert.IsTrue(back.UserAssignedIdentities.Count == 0);
        }

        [TestCase]
        public void TestDeserializerValidUserAssigned()
        {
            var identityJsonProperty = DeserializerHelper("UserAssigned.json");
            ManagedServiceIdentity back = ManagedServiceIdentity.DeserializeManagedServiceIdentity(identityJsonProperty.Value);
            Assert.IsNull(back.PrincipalId);
            Assert.IsNull(back.TenantId);
            var user = back.UserAssignedIdentities;
            Assert.AreEqual("/subscriptions/db1ab6f0-4769-4b2e-930e-01e2ef9c123c/resourceGroups/tester-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity", user.Keys.First().ToString());
            Assert.AreEqual("9a2eaa6a-b49c-4c63-afb5-3b72e3e65422", user.Values.First().ClientId.ToString());
            Assert.AreEqual("77563a98-c9d9-477b-a7af-592d21fa2153", user.Values.First().PrincipalId.ToString());
        }

        [TestCase]
        public void TestDeserializerValidSystemAndUserAssigned()
        {
            var identityJsonProperty = DeserializerHelper("SystemAndUserAssignedValid.json");
            ManagedServiceIdentity back = ManagedServiceIdentity.DeserializeManagedServiceIdentity(identityJsonProperty.Value);
            //ManagedServiceIdentity back = JsonSerializer.Deserialize<ManagedServiceIdentity>(identityJsonProperty.Value.ToString());
            Assert.IsTrue("22fdaec1-8b9f-49dc-bd72-ddaf8f215577".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988af-86f1-41af-91ab-2d7cd011db47".Equals(back.TenantId.ToString()));
            var user = back.UserAssignedIdentities;
            Assert.AreEqual("/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity", user.Keys.First().ToString());
            Assert.AreEqual("9a9eaa6a-b49c-4c63-afb5-3b72e3e65422", user.Values.First().ClientId.ToString());
            Assert.AreEqual("77563a98-c9d9-407b-a7af-592d21fa2153", user.Values.First().PrincipalId.ToString());
            Assert.AreEqual("SystemAssigned, UserAssigned", back.ManagedServiceIdentityType.ToString());
        }

        [TestCase]
        public void TestDeserializerValidSystemAndUserAssignedV3()
        {
            var identityJsonProperty = DeserializerHelper("SystemAndUserAssignedValidV3.json");
            var identityJson = identityJsonProperty.Value.ToString();
            var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
            ManagedServiceIdentity back = JsonSerializer.Deserialize<ManagedServiceIdentity>(identityJson, serializeOptions);
            Assert.IsTrue("22fdaec1-8b9f-49dc-bd72-ddaf8f215577".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988af-86f1-41af-91ab-2d7cd011db47".Equals(back.TenantId.ToString()));
            var user = back.UserAssignedIdentities;
            Assert.AreEqual("/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity", user.Keys.First().ToString());
            Assert.AreEqual("9a9eaa6a-b49c-4c63-afb5-3b72e3e65422", user.Values.First().ClientId.ToString());
            Assert.AreEqual("77563a98-c9d9-407b-a7af-592d21fa2153", user.Values.First().PrincipalId.ToString());
            Assert.IsTrue(identityJson.Contains("SystemAssigned,UserAssigned"));
            Assert.AreEqual("SystemAssigned, UserAssigned", back.ManagedServiceIdentityType.ToString());
        }

        [TestCase]
        public void TestSerializerValidSystemAndUser()
        {
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"));
            var dict1 = new Dictionary<ResourceIdentifier, UserAssignedIdentity>();
            dict1[new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity")] = userAssignedIdentity;
            ManagedServiceIdentity identity = new ManagedServiceIdentity(new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"), new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), ManagedServiceIdentityType.SystemAssignedUserAssigned, dict1);
            string user = "{}";
            string expected = "{" +
                "\"type\":\"SystemAssigned, UserAssigned\"," +
                "\"userAssignedIdentities\":" +
                "{" + "\"/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity\":" +
                user + "}}";

            JsonAsserts.AssertConverterSerialization(expected, identity);
        }

        [TestCase]
        public void TestSerializerValidSystemAndUserV3()
        {
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"));
            var dict1 = new Dictionary<ResourceIdentifier, UserAssignedIdentity>();
            dict1[new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity")] = userAssignedIdentity;
            ManagedServiceIdentity identity = new ManagedServiceIdentity(new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"), new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), ManagedServiceIdentityType.SystemAssignedUserAssigned, dict1);
            string user = "{}";
            string expected = "{" +
                "\"type\":\"SystemAssigned,UserAssigned\"," +
                "\"userAssignedIdentities\":" +
                "{" + "\"/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity\":" +
                user + "}}";
            var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
            JsonAsserts.AssertConverterSerialization(expected, identity, serializeOptions);
        }

        [TestCase]
        public void TestDeserializeFromV4AndSerializeToV3SystemAndUser()
        {
            //Deserialize from v4
            var identityJsonProperty = DeserializerHelper("SystemAndUserAssignedValid.json");
            var identityJsonV4 = identityJsonProperty.Value.ToString();
            Assert.IsTrue(identityJsonV4.Contains("SystemAssigned, UserAssigned"));
            ManagedServiceIdentity back = JsonSerializer.Deserialize<ManagedServiceIdentity>(identityJsonV4);
            var userIdentities = back.UserAssignedIdentities;
            Assert.IsTrue("22fdaec1-8b9f-49dc-bd72-ddaf8f215577".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988af-86f1-41af-91ab-2d7cd011db47".Equals(back.TenantId.ToString()));
            Assert.AreEqual("/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity", userIdentities.Keys.First().ToString());
            Assert.AreEqual("9a9eaa6a-b49c-4c63-afb5-3b72e3e65422", userIdentities.Values.First().ClientId.ToString());
            Assert.AreEqual("77563a98-c9d9-407b-a7af-592d21fa2153", userIdentities.Values.First().PrincipalId.ToString());
            Assert.AreEqual("SystemAssigned, UserAssigned", back.ManagedServiceIdentityType.ToString());
            //Serialize to v3
            string user = "{}";
            string expectedV3 = "{" +
                "\"type\":\"SystemAssigned,UserAssigned\"," +
                "\"userAssignedIdentities\":" +
                "{" + "\"/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity\":" +
                user + "}}";
            var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
            JsonAsserts.AssertConverterSerialization(expectedV3, back, serializeOptions);
        }

        [TestCase]
        public void TestDeserializeFromV3AndSerializeToV4SystemAndUser()
        {
            //Deserialize from v3
            var identityJsonProperty = DeserializerHelper("SystemAndUserAssignedValidV3.json");
            var identityJsonV3 = identityJsonProperty.Value.ToString();
            Assert.IsTrue(identityJsonV3.Contains("SystemAssigned,UserAssigned"));
            var serializeOptions = new JsonSerializerOptions { Converters = { new ManagedServiceIdentityTypeV3Converter() } };
            ManagedServiceIdentity back = JsonSerializer.Deserialize<ManagedServiceIdentity>(identityJsonV3, serializeOptions);
            var userIdentities = back.UserAssignedIdentities;
            Assert.IsTrue("22fdaec1-8b9f-49dc-bd72-ddaf8f215577".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988af-86f1-41af-91ab-2d7cd011db47".Equals(back.TenantId.ToString()));
            Assert.AreEqual("/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity", userIdentities.Keys.First().ToString());
            Assert.AreEqual("9a9eaa6a-b49c-4c63-afb5-3b72e3e65422", userIdentities.Values.First().ClientId.ToString());
            Assert.AreEqual("77563a98-c9d9-407b-a7af-592d21fa2153", userIdentities.Values.First().PrincipalId.ToString());
            Assert.AreEqual("SystemAssigned, UserAssigned", back.ManagedServiceIdentityType.ToString());
            //Serialize to v4
            string user = "{}";
            string expectedV4 = "{" +
                "\"type\":\"SystemAssigned, UserAssigned\"," +
                "\"userAssignedIdentities\":" +
                "{" + "\"/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity\":" +
                user + "}}";
            JsonAsserts.AssertConverterSerialization(expectedV4, back);
        }

        [TestCase]
        public void TestSerializerNullUserAssignedIdentity()
        {
            var dict1 = new Dictionary<ResourceIdentifier, UserAssignedIdentity>();
            dict1[new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity")] = null;
            ManagedServiceIdentity identity = new ManagedServiceIdentity(new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"), new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), ManagedServiceIdentityType.SystemAssignedUserAssigned, dict1);
            string user = "null";
            string expected = "{" +
                "\"type\":\"SystemAssigned, UserAssigned\"," +
                "\"userAssignedIdentities\":" +
                "{" + "\"/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity\":" +
                user + "}}";

            JsonAsserts.AssertConverterSerialization(expected, identity);
        }

        [TestCase]
        public void TestSerializerValidSystemAndMultUser()
        {
            UserAssignedIdentity userAssignedIdentity1 = new UserAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"));
            UserAssignedIdentity userAssignedIdentity2 = new UserAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011cb47"), new Guid("de29bab1-49e1-4705-819b-4dfddcebaa98"));
            var dict1 = new Dictionary<ResourceIdentifier, UserAssignedIdentity>();
            dict1[new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity1")] = userAssignedIdentity1;
            dict1[new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity2")] = userAssignedIdentity2;
            ManagedServiceIdentity identity = new ManagedServiceIdentity(new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"), new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), ManagedServiceIdentityType.SystemAssignedUserAssigned, dict1);
            string emptyUser = "{}";
            string expected = "{" +
                "\"type\":\"SystemAssigned, UserAssigned\"," +
                "\"userAssignedIdentities\":" +
                "{" + "\"/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity1\":" +
                emptyUser + "," +
                "\"/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity2\":" +
                emptyUser + "}}";

            JsonAsserts.AssertConverterSerialization(expected, identity);
        }

        [TestCase]
        public void TestSerializerValidSystemOnly()
        {
            ManagedServiceIdentity identity = new ManagedServiceIdentity(new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"), new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), ManagedServiceIdentityType.SystemAssigned, new ChangeTrackingDictionary<ResourceIdentifier, UserAssignedIdentity>());
            //string system = "\"principalId\":\"de29bab1-49e1-4705-819b-4dfddceaaa98\",\"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"";
            string expected = "{\"type\":\"SystemAssigned\"}";

            JsonAsserts.AssertConverterSerialization(expected, identity);
        }

        [TestCase]
        public void TestSerializerValidUserNullSystem()
        {
            UserAssignedIdentity userAssignedIdentity = new UserAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"));
            var dict1 = new Dictionary<ResourceIdentifier, UserAssignedIdentity>();
            dict1[new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity")] = userAssignedIdentity;
            ManagedServiceIdentity identity = new ManagedServiceIdentity(null, null, ManagedServiceIdentityType.UserAssigned, dict1);
            string user = "{}";
            string expected = "{\"type\":\"UserAssigned\"," +
                "\"userAssignedIdentities\":" +
                "{" + "\"/subscriptions/db1ab6f0-4769-4aa7-930e-01e2ef9c123c/resourceGroups/tester/providers/Microsoft.ManagedIdentity/userAssignedIdentities/testidentity\":" +
                user + "}}";

            JsonAsserts.AssertConverterSerialization(expected, identity);
        }
    }
}
