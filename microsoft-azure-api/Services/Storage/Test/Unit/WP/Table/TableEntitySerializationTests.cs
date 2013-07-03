// -----------------------------------------------------------------------------------------
// <copyright file="TableEntitySerializationTests.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Microsoft.WindowsAzure.Storage.Table.Entities;
using System;

namespace Microsoft.WindowsAzure.Storage.Table
{
    [TestClass]
    public class TableEntitySerializationTests : TableTestBase
    {
        readonly CloudTableClient DefaultTableClient = new CloudTableClient(new Uri(TestBase.TargetTenantConfig.TableServiceEndpoint), TestBase.StorageCredentials);

        #region Locals + Ctors
        public TableEntitySerializationTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        static CloudTable currentTable = null;

        #endregion

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        // public static async Task MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        // public static async Task MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            CloudTableClient tableClient = GenerateCloudTableClient();
            currentTable = tableClient.GetTableReference(GenerateRandomTableName());
            currentTable.CreateIfNotExistsAsync().Wait();
        }

        //
        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            currentTable.DeleteIfExistsAsync().Wait();
            currentTable = null;
        }

        #endregion

        [TestMethod]
        [Description("A test checks basic function Reflection Serializer")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void ReflectionBasedSerializationTest()
        {
            ComplexEntity ent = new ComplexEntity();
            ComplexEntity secondEnt = new ComplexEntity();
            secondEnt.ReadEntity(ent.WriteEntity(null), null);
            ComplexEntity.AssertEquality(ent, secondEnt);
        }

        [TestMethod]
        [Description("A test checks basic function Reflection Serializer")]
        [TestCategory(ComponentCategory.Table)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void EntityPropertyTests()
        {
            Random rand = new Random();

            // Binary
            byte[] bytes = new byte[1024];
            rand.NextBytes(bytes);

            // Ctor
            EntityProperty binProp = EntityProperty.GeneratePropertyForByteArray(bytes);
            Assert.AreEqual(binProp.BinaryValue, bytes);

            // Setter
            byte[] bytes2 = new byte[1024];
            rand.NextBytes(bytes2);
            binProp.BinaryValue = bytes2;
            Assert.AreEqual(binProp.BinaryValue, bytes2);

            // Null
            binProp.BinaryValue = null;
            Assert.AreEqual(binProp.BinaryValue, null);

            // bool
            bool boolVal = true;

            // Ctor
            EntityProperty boolProp = EntityProperty.GeneratePropertyForBool(boolVal);
            Assert.AreEqual(boolProp.BooleanValue, boolVal);

            // Setter
            bool boolVal2 = true;
            boolProp.BooleanValue = boolVal2;
            Assert.AreEqual(boolProp.BooleanValue, boolVal2);

            // DateTimeOffset
            DateTimeOffset dto = DateTimeOffset.Now;

            // Ctor
            EntityProperty dtoProp = EntityProperty.GeneratePropertyForDateTimeOffset(dto);
            Assert.AreEqual(dtoProp.DateTimeOffsetValue, dto);

            // Setter
            DateTimeOffset dto2 = DateTimeOffset.UtcNow;
            dtoProp.DateTimeOffsetValue = dto2;
            Assert.AreEqual(dtoProp.DateTimeOffsetValue, dto2);

            // Null
            DateTimeOffset? dto3 = (DateTimeOffset?)null;
            dtoProp.DateTimeOffsetValue = dto3;
            Assert.AreEqual(dtoProp.DateTimeOffsetValue, dto3);

            // double
            double doubleVal = 1234.4564;

            // Ctor
            EntityProperty doubleProp = EntityProperty.GeneratePropertyForDouble(doubleVal);
            Assert.AreEqual(doubleProp.DoubleValue, doubleVal);

            // Setter
            double doubleVal2 = 8979654.35454;
            doubleProp.DoubleValue = doubleVal2;
            Assert.AreEqual(doubleProp.DoubleValue, doubleVal2);

            // Guid
            Guid guidVal = new Guid();

            // Ctor
            EntityProperty guidProp = EntityProperty.GeneratePropertyForGuid(guidVal);
            Assert.AreEqual(guidProp.GuidValue, guidVal);

            // Setter
            Guid guidVal2 = new Guid();
            guidProp.GuidValue = guidVal2;
            Assert.AreEqual(guidProp.GuidValue, guidVal2);

            // int
            int intVal = 1234;

            // Ctor
            EntityProperty intProp = EntityProperty.GeneratePropertyForInt(intVal);
            Assert.AreEqual(intProp.Int32Value, intVal);

            // Setter
            int intVal2 = 8979654;
            intProp.Int32Value = intVal2;
            Assert.AreEqual(intProp.Int32Value, intVal2);

            // long
            long longVal = 123456789012;

            // Ctor
            EntityProperty longProp = EntityProperty.GeneratePropertyForLong(longVal);
            Assert.AreEqual(longProp.Int64Value, longVal);

            // Setter
            long longVal2 = 56789012345;
            longProp.Int64Value = longVal2;
            Assert.AreEqual(longProp.Int64Value, longVal2);

            // string
            string string1 = "abcdefghijklmnop";

            // Ctor
            EntityProperty stringProp = EntityProperty.GeneratePropertyForString(string1);
            Assert.AreEqual(stringProp.StringValue, string1);

            // Setter
            string string2 = "1234567890";
            stringProp.StringValue = string2;
            Assert.AreEqual(stringProp.StringValue, string2);

            // Null
            string string3 = null;
            stringProp.StringValue = string3;
            Assert.AreEqual(stringProp.StringValue, string3);
        }
    }
}
