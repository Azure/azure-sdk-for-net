using Azure.Core;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Azure.ResourceManager.Core.Tests
{
    [Parallelizable]
    public class SystemAssignedIdentityTests
    {
        private static readonly string TestAssetPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "Unit", "TestAssets", "SystemAssignedIdentity");

        [TestCase(0, null, null, null, null)]
        [TestCase(0, "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98", "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98")]

        [TestCase(1, "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98", null, null)]
        [TestCase(1, "72f988bf-86f1-41af-91ab-2d7cd011db48", "de29bab1-49e1-4705-819b-4dfddceaaa98", "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98")]
        [TestCase(1, "72f988bf-86f1-41af-91ab-2d7cd011db48", "de29bab1-49e1-4705-819b-4dfddceaaa97", "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98")]
        [TestCase(1, "72f988bf-86f1-41af-91ab-2d7cd011db48", "de29bab1-49e1-4705-819b-4dfddceaaa99", "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98")]
        [TestCase(1, "72f988bf-86f1-41af-91ab-2d7cd011eb47", "de29bab1-49e1-4705-819b-4dfddceaaa98", "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98")]

        [TestCase(-1, null, null, "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98")]
        [TestCase(-1, "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98", "72f988bf-86f1-41af-91ab-2d7cd011db48", "de29bab1-49e1-4705-819b-4dfddceaaa98")]
        [TestCase(-1, "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98", "72f988bf-86f1-41af-91ab-2d7cd011db48", "de29bab1-49e1-4705-819b-4dfddceaaa99")]
        [TestCase(-1, "72f988bf-86f1-41af-91ab-2d7cd011db46", "de29bab1-49e1-4705-819b-4dfddceaaa98", "72f988bf-86f1-41af-91ab-2d7cd011db48", "de29bab1-49e1-4705-819b-4dfddceaaa97")]
        [TestCase(-1, "72f988bf-86f1-41af-91ab-2d7cd011db46", "de29bab1-49e1-4705-819b-4dfdbceaaa98", "72f988bf-86f1-41af-91ab-2d7cd011db46", "de29bab1-49e1-4705-819b-4dfddceaaa99")]
        public void CompareTo(int answer, string tenantId1, string principalId1, string tenantId2, string principalId2)
        {
            SystemAssignedIdentity identity1;
            SystemAssignedIdentity identity2;
            if (tenantId1 == null)
            {
                identity1 = new SystemAssignedIdentity();
            }
            else
            {
                identity1 = new SystemAssignedIdentity(new Guid(tenantId1), new Guid(principalId1));
            }

            if (tenantId2 == null)
            {
                identity2 = new SystemAssignedIdentity();
            }
            else
            {
                identity2 = new SystemAssignedIdentity(new Guid(tenantId2), new Guid(principalId2));
            }

            Assert.AreEqual(answer, identity1.CompareTo(identity2));
            Assert.AreEqual(answer * -1, identity2.CompareTo(identity1));
        }

        [TestCase(null, null, null, null)]
        [TestCase("72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98", "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98")]
        public void EqualsMethodTrue(string tenantId1, string principalId1, string tenantId2, string principalId2)
        {
            SystemAssignedIdentity identity1;
            SystemAssignedIdentity identity2;
            if (tenantId1 == null)
            {
                identity1 = new SystemAssignedIdentity();
            }
            else
            {
                identity1 = new SystemAssignedIdentity(new Guid(tenantId1), new Guid(principalId1));
            }

            if (tenantId2 == null)
            {
                identity2 = new SystemAssignedIdentity();
            }
            else
            {
                identity2 = new SystemAssignedIdentity(new Guid(tenantId2), new Guid(principalId2));
            }

            Assert.IsTrue(identity1.Equals(identity2));
        }

        [TestCase(null, null, "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98")]
        [TestCase("72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98", null, null)]
        [TestCase("72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa98", "72f988bf-86f1-41af-91ab-2d7cd011db44", "de29bab1-49e1-4705-819b-4dfddceaaa94")]        
        [TestCase("72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa93", "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa91")]
        [TestCase("72f988bf-86f1-41af-91ab-2d7cd011db49", "de29bab1-49e1-4705-819b-4dfddceaaa91", "72f988bf-86f1-41af-91ab-2d7cd011db47", "de29bab1-49e1-4705-819b-4dfddceaaa91")]
        public void EqualsMethodFalse(string tenantId1, string principalId1, string tenantId2, string principalId2)
        {
            SystemAssignedIdentity identity1;
            SystemAssignedIdentity identity2;
            if (tenantId1 == null)
            {
                identity1 = new SystemAssignedIdentity();
            }
            else
            {
                identity1 = new SystemAssignedIdentity(new Guid(tenantId1), new Guid(principalId1));
            }

            if (tenantId2 == null)
            {
                identity2 = new SystemAssignedIdentity();
            }
            else
            {
                identity2 = new SystemAssignedIdentity(new Guid(tenantId2), new Guid(principalId2));
            }

            Assert.IsFalse(identity1.Equals(identity2));
        }

        [TestCase]
        public void EqualsMethodBothIdentitiesEmpty()
        {
            SystemAssignedIdentity identity1 = new SystemAssignedIdentity();
            SystemAssignedIdentity identity2 = new SystemAssignedIdentity();
            Assert.IsTrue(identity1.Equals(identity2));
        }

        [TestCase]
        public void EqualsMethodOneIdentityNull()
        {
            SystemAssignedIdentity identity1 = new SystemAssignedIdentity();
            SystemAssignedIdentity identity2 = null;
            Assert.IsFalse(identity1.Equals(identity2));
        }        

        [TestCase]
        public void CompareToMethodBothIdentitiesEmpty()
        {
            SystemAssignedIdentity identity1 = new SystemAssignedIdentity();
            SystemAssignedIdentity identity2 = new SystemAssignedIdentity();
            Assert.AreEqual(0, identity1.CompareTo(identity2));
        }

        [TestCase]
        public void CompareToMethodOneIdentityNull()
        {
            SystemAssignedIdentity identity1 = new SystemAssignedIdentity();
            SystemAssignedIdentity identity2 = null;
            Assert.AreEqual(1, identity1.CompareTo(identity2));
        }

        public JsonProperty DeserializerHelper(string filename)
        {
            string json = GetFileText(filename);
            JsonDocument document = JsonDocument.Parse(json);
            JsonElement rootElement = document.RootElement;
            return rootElement.EnumerateObject().First();
        }

        private static string GetFileText(string filename)
        {
            return File.ReadAllText(Path.Combine(TestAssetPath, filename));
        }

        [TestCase]
        public void TestDeserializerDefaultJson()
        {
            JsonElement invalid = default(JsonElement);
            Assert.Throws<ArgumentException>(delegate { SystemAssignedIdentity.DeserializeSystemAssignedIdentity(invalid); });
        }

        [TestCase]
        public void TestDeserializerValid()
        {
            var identityJsonProperty = DeserializerHelper("SystemAssignedValid.json");
            var systemProperties = identityJsonProperty.Value.EnumerateObject().ElementAt(0);
            SystemAssignedIdentity back = SystemAssignedIdentity.DeserializeSystemAssignedIdentity(systemProperties.Value);
            Assert.IsTrue("de29bab1-49e1-4705-819b-4dfddceaaa98".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988bf-86f1-41af-91ab-2d7cd011db47".Equals(back.TenantId.ToString()));
        }

        [TestCase]
        public void TestDeserializerValidExtraField()
        {
            var json = GetFileText("SystemAssignedValidExtraField.json");
            JsonDocument document = JsonDocument.Parse(json);
            JsonElement rootElement = document.RootElement;
            var identityJsonProperty = rootElement.EnumerateObject().ElementAt(1);
            var systemProperties = identityJsonProperty.Value.EnumerateObject().ElementAt(0);
            SystemAssignedIdentity back = SystemAssignedIdentity.DeserializeSystemAssignedIdentity(systemProperties.Value);
            Assert.IsTrue("de29bab1-49e1-4705-819b-4dfddceaaa98".Equals(back.PrincipalId.ToString()));
            Assert.IsTrue("72f988bf-86f1-41af-91ab-2d7cd011db47".Equals(back.TenantId.ToString()));
        }

        [TestCase]
        public void TestDeserializerBothValuesNull()
        {
            var identityJsonProperty = DeserializerHelper("SystemAssignedBothValuesNull.json");
            var systemProperties = identityJsonProperty.Value.EnumerateObject().ElementAt(0);
            var back = SystemAssignedIdentity.DeserializeSystemAssignedIdentity(systemProperties.Value);
            Assert.IsNull(back);
        }

        [TestCase]
        public void TestDeserializerBothEmptyString()
        {
            var identityJsonProperty = DeserializerHelper("SystemAssignedBothEmptyString.json");
            var systemProperties = identityJsonProperty.Value.EnumerateObject().ElementAt(0);
            Assert.Throws<FormatException>(delegate { SystemAssignedIdentity.DeserializeSystemAssignedIdentity(systemProperties.Value); });
        }

        [TestCase]
        public void TestDeserializerOneEmptyString()
        {
            var identityJsonProperty = DeserializerHelper("SystemAssignedOneEmptyString.json");
            var systemProperties = identityJsonProperty.Value.EnumerateObject().ElementAt(0);
            Assert.Throws<FormatException>(delegate { SystemAssignedIdentity.DeserializeSystemAssignedIdentity(systemProperties.Value); });
        }

        [TestCase]
        public void TestDeserializerTenantIdValueNull()
        {
            var identityJsonProperty = DeserializerHelper("SystemAssignedOneValueNull.json");
            var systemProperties = identityJsonProperty.Value.EnumerateObject().ElementAt(0);
            Assert.Throws<InvalidOperationException>(delegate { SystemAssignedIdentity.DeserializeSystemAssignedIdentity(systemProperties.Value); });
        }

        [TestCase]
        public void TestDeserializerPrincipalIdValueNull()
        {
            var identityJsonProperty = DeserializerHelper("SystemAssignedOneOtherValueNull.json");
            var systemProperties = identityJsonProperty.Value.EnumerateObject().ElementAt(0);
            Assert.Throws<InvalidOperationException>(delegate { SystemAssignedIdentity.DeserializeSystemAssignedIdentity(systemProperties.Value); });
        }

        [TestCase]
        public void TestDeserializerTenantIdInvalid()
        {
            var identityJsonProperty = DeserializerHelper("SystemAssignedInvalid.json");
            var systemProperties = identityJsonProperty.Value.EnumerateObject().ElementAt(0);
            Assert.Throws<InvalidOperationException>(delegate { SystemAssignedIdentity.DeserializeSystemAssignedIdentity(systemProperties.Value); });
        }

        [TestCase]
        public void TestSerializerValidIdentity()
        {
            SystemAssignedIdentity systemAssignedIdentity = new SystemAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"));
            string expected = "{\"principalId\":\"de29bab1-49e1-4705-819b-4dfddceaaa98\",\"tenantId\":\"72f988bf-86f1-41af-91ab-2d7cd011db47\"}";
            JsonAsserts.AssertSerialization(expected, systemAssignedIdentity);
        }

        [TestCase]
        public void TestSerializerEmptyIdentity()
        {
            SystemAssignedIdentity systemAssignedIdentity = new SystemAssignedIdentity();
            JsonAsserts.AssertSerialization("{}", systemAssignedIdentity);
        }

        [TestCase]
        public void TestSerializerNullIdentity()
        {
            SystemAssignedIdentity systemAssignedIdentity = null;
            Assert.Throws<NullReferenceException>(delegate { JsonAsserts.AssertSerializes(systemAssignedIdentity); });
        }

        [TestCase]
        public void TestSerializerNullWriter()
        {
            SystemAssignedIdentity systemAssignedIdentity = new SystemAssignedIdentity();
            var serializable = systemAssignedIdentity as IUtf8JsonSerializable;
            Assert.Throws<NullReferenceException>(delegate { serializable.Write(null); });
        }

        [TestCase]
        public void TestEqualsBothIdentitiesNull()
        {
            SystemAssignedIdentity identity1 = null;
            SystemAssignedIdentity identity2 = null;
            Assert.IsTrue(SystemAssignedIdentity.Equals(identity1, identity2));
        }

        [TestCase]
        public void TestEqualsOneIdentityNull()
        {
            SystemAssignedIdentity identity1 = null;
            SystemAssignedIdentity identity2 = new SystemAssignedIdentity();
            Assert.IsFalse(SystemAssignedIdentity.Equals(identity1, identity2));
        }

        [TestCase]
        public void TestEqualsOtherIdentityNull()
        {
            SystemAssignedIdentity identity1 = new SystemAssignedIdentity();
            SystemAssignedIdentity identity2 = null;
            Assert.IsFalse(SystemAssignedIdentity.Equals(identity1, identity2));
        }

        [TestCase]
        public void TestEqualsReference()
        {
            SystemAssignedIdentity identity1 = new SystemAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"));
            SystemAssignedIdentity identity2 = identity1;
            Assert.IsTrue(SystemAssignedIdentity.Equals(identity1, identity2));
        }

        [TestCase]
        public void TestEqualsTrue()
        {
            SystemAssignedIdentity identity1 = new SystemAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"));
            SystemAssignedIdentity identity2 = new SystemAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"));
            Assert.IsTrue(SystemAssignedIdentity.Equals(identity1, identity2));
        }

        [TestCase]
        public void TestEqualsFalse()
        {
            SystemAssignedIdentity identity1 = new SystemAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db47"), new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"));
            SystemAssignedIdentity identity2 = new SystemAssignedIdentity(new Guid("72f988bf-86f1-41af-91ab-2d7cd011db42"), new Guid("de29bab1-49e1-4705-819b-4dfddceaaa98"));
            Assert.IsFalse(SystemAssignedIdentity.Equals(identity1, identity2));
        }
    }
}
