// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="TableServiceClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class TableServiceLiveTestsBase : RecordedTestBase<TablesTestEnvironment>
    {

        public TableServiceLiveTestsBase(bool isAsync, RecordedTestMode recordedTestMode) : base(isAsync, recordedTestMode)
        {
            Sanitizer = new TablesRecordedTestSanitizer();
        }

        public TableServiceLiveTestsBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new TablesRecordedTestSanitizer();
        }

        protected TableServiceClient service { get; private set; }
        protected TableClient client { get; private set; }
        protected string tableName { get; private set; }
        protected const string PartitionKeyValue = "somPartition";
        protected const string PartitionKeyValue2 = "somPartition2";
        protected const string StringTypePropertyName = "SomeStringProperty";
        protected const string DateTypePropertyName = "SomeDateProperty";
        protected const string GuidTypePropertyName = "SomeGuidProperty";
        protected const string BinaryTypePropertyName = "SomeBinaryProperty";
        protected const string Int64TypePropertyName = "SomeInt64Property";
        protected const string DoubleTypePropertyName = "SomeDoubleProperty0";
        protected const string DoubleDecimalTypePropertyName = "SomeDoubleProperty1";
        protected const string IntTypePropertyName = "SomeIntProperty";

        /// <summary>
        /// Creates a <see cref="TableServiceClient" /> with the endpoint and API key provided via environment
        /// variables and instruments it to make use of the Azure Core Test Framework functionalities.
        /// </summary>
        [SetUp]
        public async Task TablesTestSetup()
        {
            service = InstrumentClient(new TableServiceClient(new Uri(TestEnvironment.StorageUri),
                                                              new TableSharedKeyCredential(TestEnvironment.AccountName, TestEnvironment.PrimaryStorageAccountKey),
                                                              Recording.InstrumentClientOptions(new TableClientOptions())));
            tableName = Recording.GenerateAlphaNumericId("testtable", useOnlyLowercase: true);
            await service.CreateTableAsync(tableName).ConfigureAwait(false);
            client = service.GetTableClient(tableName);
        }

        [TearDown]
        public async Task TablesTeardown()
        {
            try
            {
                await service.DeleteTableAsync(tableName);
            }
            catch { }
        }

        /// <summary>
        /// Creates a list of table entities.
        /// </summary>
        /// <param name="partitionKeyValue">The partition key to create for the entity.</param>
        /// <param name="count">The number of entities to create</param>
        /// <returns></returns>
        protected static List<Dictionary<string, object>> CreateTableEntities(string partitionKeyValue, int count)
        {

            // Create some entities.
            return Enumerable.Range(1, count).Select(n =>
            {
                string number = n.ToString();
                return new Dictionary<string, object>
                    {
                        {"PartitionKey", partitionKeyValue},
                        {"RowKey", n.ToString("D2")},
                        {StringTypePropertyName, $"This is table entity number {n:D2}"},
                        {DateTypePropertyName, new DateTime(2020, 1,1,1,1,0,DateTimeKind.Utc).AddMinutes(n) },
                        {GuidTypePropertyName, new Guid($"0d391d16-97f1-4b9a-be68-4cc871f9{n:D4}")},
                        {BinaryTypePropertyName, new byte[]{ 0x01, 0x02, 0x03, 0x04, 0x05 }},
                        {Int64TypePropertyName, long.Parse(number)},
                        {DoubleTypePropertyName, (double)n},
                        {DoubleDecimalTypePropertyName, n + 0.1},
                        {IntTypePropertyName, n},
                    };
            }).ToList();
        }

        /// <summary>
        /// Creates a list of strongly typed table entities.
        /// </summary>
        /// <param name="partitionKeyValue">The partition key to create for the entity.</param>
        /// <param name="count">The number of entities to create</param>
        /// <returns></returns>
        protected static List<TestEntity> CreateCustomTableEntities(string partitionKeyValue, int count)
        {

            // Create some entities.
            return Enumerable.Range(1, count).Select(n =>
            {
                string number = n.ToString();
                return new TestEntity
                {
                    PartitionKey = partitionKeyValue,
                    RowKey = n.ToString("D2"),
                    StringTypeProperty = $"This is table entity number {n:D2}",
                    DatetimeTypeProperty = new DateTime(2020, 1, 1, 1, 1, 0, DateTimeKind.Utc).AddMinutes(n),
                    DatetimeOffsetTypeProperty = new DateTime(2020, 1, 1, 1, 1, 0, DateTimeKind.Utc).AddMinutes(n),
                    GuidTypeProperty = new Guid($"0d391d16-97f1-4b9a-be68-4cc871f9{n:D4}"),
                    BinaryTypeProperty = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 },
                    Int64TypeProperty = long.Parse(number),
                    DoubleTypeProperty = (double)n,
                    IntTypeProperty = n,
                };
            }).ToList();
        }

        /// <summary>
        /// Creates a list of strongly typed table entities.
        /// </summary>
        /// <param name="partitionKeyValue">The partition key to create for the entity.</param>
        /// <param name="count">The number of entities to create</param>
        /// <returns></returns>
        protected static List<ComplexEntity> CreateComplexTableEntities(string partitionKeyValue, int count)
        {

            // Create some entities.
            return Enumerable.Range(1, count).Select(n =>
            {
                return new ComplexEntity(partitionKeyValue, string.Format("{0:0000}", n))
                {
                    String = string.Format("{0:0000}", n),
                    Binary = new byte[] { 0x01, 0x02, (byte)n },
                    BinaryPrimitive = new byte[] { 0x01, 0x02, (byte)n },
                    Bool = n % 2 == 0,
                    BoolPrimitive = n % 2 == 0,
                    DateTime = new DateTime(2020, 1, 1, 1, 1, 0, DateTimeKind.Utc).AddMinutes(n),
                    DateTimeOffset = new DateTime(2020, 1, 1, 1, 1, 0, DateTimeKind.Utc).AddMinutes(n),
                    DateTimeAsString = new DateTime(2020, 1, 1, 1, 1, 0, DateTimeKind.Utc).AddMinutes(n).ToString("o"),
                    DateTimeN = new DateTime(2020, 1, 1, 1, 1, 0, DateTimeKind.Utc).AddMinutes(n),
                    DateTimeOffsetN = new DateTime(2020, 1, 1, 1, 1, 0, DateTimeKind.Utc).AddMinutes(n),
                    Double = n + ((double)n / 100),
                    DoubleInteger = (double)n,
                    DoubleN = n + ((double)n / 100),
                    DoublePrimitive = n + ((double)n / 100),
                    DoublePrimitiveN = n + ((double)n / 100),
                    Guid = new Guid($"0d391d16-97f1-4b9a-be68-4cc871f9{n:D4}"),
                    GuidN = new Guid($"0d391d16-97f1-4b9a-be68-4cc871f9{n:D4}"),
                    Int32 = n,
                    Int32N = n,
                    IntegerPrimitive = n,
                    IntegerPrimitiveN = n,
                    Int64 = (long)int.MaxValue + n,
                    LongPrimitive = (long)int.MaxValue + n,
                    LongPrimitiveN = (long)int.MaxValue + n,
                };
            }).ToList();
        }

        protected async Task CreateTestEntities<T>(List<T> entitiesToCreate) where T : TableEntity, new()
        {
            foreach (var entity in entitiesToCreate)
            {
                await client.CreateEntityAsync(entity).ConfigureAwait(false);
            }
        }

        protected async Task CreateTestEntities(List<Dictionary<string,object>> entitiesToCreate)
        {
            foreach (var entity in entitiesToCreate)
            {
                await client.CreateEntityAsync(entity).ConfigureAwait(false);
            }
        }

        public class TestEntity : TableEntity
        {
            public string StringTypeProperty { get; set; }

            public DateTime DatetimeTypeProperty { get; set; }

            public DateTimeOffset DatetimeOffsetTypeProperty { get; set; }

            public Guid GuidTypeProperty { get; set; }

            public byte[] BinaryTypeProperty { get; set; }

            public long Int64TypeProperty { get; set; }

            public double DoubleTypeProperty { get; set; }

            public int IntTypeProperty { get; set; }
        }

        public class SimpleTestEntity : TableEntity
        {
            public string StringTypeProperty { get; set; }
        }

        public class ComplexEntity : TableEntity
        {
            public const int NumberOfNonNullProperties = 28;

            public ComplexEntity()
                : base()
            {
            }

            public ComplexEntity(string pk, string rk)
                : base(pk, rk)
            {
            }

            private DateTimeOffset? dateTimeOffsetNull = null;
            public DateTimeOffset? DateTimeOffsetNull
            {
                get { return dateTimeOffsetNull; }
                set { dateTimeOffsetNull = value; }
            }

            private DateTimeOffset? dateTimeOffsetN = DateTimeOffset.Now;
            public DateTimeOffset? DateTimeOffsetN
            {
                get { return dateTimeOffsetN; }
                set { dateTimeOffsetN = value; }
            }

            private DateTimeOffset dateTimeOffset = DateTimeOffset.Now;
            public DateTimeOffset DateTimeOffset
            {
                get { return dateTimeOffset; }
                set { dateTimeOffset = value; }
            }

            public DateTime? DateTimeNull { get; set; } = null;

            public DateTime? DateTimeN { get; set; } = DateTime.UtcNow;

            public DateTime DateTime { get; set; } = DateTime.UtcNow;

            public string DateTimeAsString { get; set; } = DateTime.UtcNow.ToString("o");

            public Boolean? BoolNull { get; set; } = null;

            public Boolean? BoolN { get; set; } = false;

            public Boolean Bool { get; set; } = false;

            public bool? BoolPrimitiveNull { get; set; } = null;

            public bool? BoolPrimitiveN { get; set; } = false;

            public bool BoolPrimitive { get; set; } = false;

            public Byte[] Binary { get; set; } = new Byte[] { 1, 2, 3, 4 };

            public Byte[] BinaryNull { get; set; } = null;

            public byte[] BinaryPrimitive { get; set; } = new byte[] { 1, 2, 3, 4 };

            public double? DoublePrimitiveNull { get; set; } = null;

            public double? DoublePrimitiveN { get; set; } = (double)1234.1234;

            public double DoublePrimitive { get; set; } = (double)1234.1234;

            public Double? DoubleNull { get; set; } = null;

            public Double? DoubleN { get; set; } = (Double)1234.1234;

            public Double Double { get; set; } = (Double)1234.1234;

            public Double DoubleInteger { get; set; } = (Double)1234;

            private Guid? guidNull = null;
            public Guid? GuidNull
            {
                get { return guidNull; }
                set { guidNull = value; }
            }

            private Guid? guidN = Guid.NewGuid();
            public Guid? GuidN
            {
                get { return guidN; }
                set { guidN = value; }
            }

            private Guid guid = Guid.NewGuid();
            public Guid Guid
            {
                get { return guid; }
                set { guid = value; }
            }

            public int? IntegerPrimitiveNull { get; set; } = null;

            public int? IntegerPrimitiveN { get; set; } = 1234;

            public int IntegerPrimitive { get; set; } = 1234;

            public Int32? Int32Null { get; set; } = null;

            public Int32? Int32N { get; set; } = 1234;

            public Int32 Int32 { get; set; } = 1234;

            public long? LongPrimitiveNull { get; set; } = null;

            public long? LongPrimitiveN { get; set; } = 123456789012;

            public long LongPrimitive { get; set; } = 123456789012;

            public Int64? Int64Null { get; set; } = null;

            public Int64? Int64N { get; set; } = 123456789012;

            public Int64 Int64 { get; set; } = 123456789012;

            public string String { get; set; } = "test";

            public static void AssertEquality(ComplexEntity a, ComplexEntity b)
            {
                Assert.AreEqual(a.String, b.String);
                Assert.AreEqual(a.Int64, b.Int64);
                Assert.AreEqual(a.Int64N, b.Int64N);
                Assert.AreEqual(a.Int64Null, b.Int64Null);
                Assert.AreEqual(a.LongPrimitive, b.LongPrimitive);
                Assert.AreEqual(a.LongPrimitiveN, b.LongPrimitiveN);
                Assert.AreEqual(a.LongPrimitiveNull, b.LongPrimitiveNull);
                Assert.AreEqual(a.Int32, b.Int32);
                Assert.AreEqual(a.Int32N, b.Int32N);
                Assert.AreEqual(a.Int32Null, b.Int32Null);
                Assert.AreEqual(a.IntegerPrimitive, b.IntegerPrimitive);
                Assert.AreEqual(a.IntegerPrimitiveN, b.IntegerPrimitiveN);
                Assert.AreEqual(a.IntegerPrimitiveNull, b.IntegerPrimitiveNull);
                Assert.AreEqual(a.Guid, b.Guid);
                Assert.AreEqual(a.GuidN, b.GuidN);
                Assert.AreEqual(a.GuidNull, b.GuidNull);
                Assert.AreEqual(a.Double, b.Double);
                Assert.AreEqual(a.DoubleN, b.DoubleN);
                Assert.AreEqual(a.DoubleNull, b.DoubleNull);
                Assert.AreEqual(a.DoublePrimitive, b.DoublePrimitive);
                Assert.AreEqual(a.DoublePrimitiveN, b.DoublePrimitiveN);
                Assert.AreEqual(a.DoublePrimitiveNull, b.DoublePrimitiveNull);
                Assert.AreEqual(a.BinaryPrimitive.GetValue(0), b.BinaryPrimitive.GetValue(0));
                Assert.AreEqual(a.BinaryPrimitive.GetValue(1), b.BinaryPrimitive.GetValue(1));
                Assert.AreEqual(a.BinaryPrimitive.GetValue(2), b.BinaryPrimitive.GetValue(2));
                Assert.AreEqual(a.Binary.GetValue(0), b.Binary.GetValue(0));
                Assert.AreEqual(a.Binary.GetValue(1), b.Binary.GetValue(1));
                Assert.AreEqual(a.Binary.GetValue(2), b.Binary.GetValue(2));
                Assert.AreEqual(a.BoolPrimitive, b.BoolPrimitive);
                Assert.AreEqual(a.BoolPrimitiveN, b.BoolPrimitiveN);
                Assert.AreEqual(a.BoolPrimitiveNull, b.BoolPrimitiveNull);
                Assert.AreEqual(a.Bool, b.Bool);
                Assert.AreEqual(a.BoolN, b.BoolN);
                Assert.AreEqual(a.BoolNull, b.BoolNull);
                Assert.AreEqual(a.DateTimeOffsetN, b.DateTimeOffsetN);
                Assert.AreEqual(a.DateTimeOffset, b.DateTimeOffset);
                Assert.AreEqual(a.DateTimeOffsetNull, b.DateTimeOffsetNull);
                Assert.AreEqual(a.DateTime, b.DateTime);
                Assert.AreEqual(a.DateTimeN, b.DateTimeN);
                Assert.AreEqual(a.DateTimeNull, b.DateTimeNull);
            }
        }
    }
}
