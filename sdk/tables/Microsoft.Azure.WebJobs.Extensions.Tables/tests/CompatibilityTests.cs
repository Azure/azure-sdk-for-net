// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias T1;

using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.TestFramework;
using Azure.Data.Tables;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    // Can't record V4
    [LiveOnly]
    public class CompatibilityTests: TablesLiveTestBase
    {
        private static DateTimeOffset DateTimeOffsetValue = DateTimeOffset.Parse("07-08-1997", null,  DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        private static DateTime DateTimeValue = DateTime.Parse("07-08-1997", null,  DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);

        public CompatibilityTests(bool isAsync, bool useCosmos) : base(isAsync, useCosmos)
        {
        }

        [Test]
        [TestCaseSource(nameof(SdkExtensionPermutations))]
        public async Task CanSavePocoAndLoadITableEntityWithNullables(ITablesClient writer, ITablesClient reader)
        {
            var testEntity = new TestITableEntity()
            {
                PartitionKey = PartitionKey,
                RowKey = RowKey,
                // SDK can't handle overflow in longs
                UInt64TypeProperty = long.MaxValue,
                Int64TypeProperty = long.MaxValue,
            };

            await writer.Write(this, testEntity);
            var output = await reader.Read<TestITableEntity>(this);

            AssertAreEqual(testEntity, output);
        }

        [Test]
        [TestCaseSource(nameof(SdkExtensionPermutations))]
        public async Task CanSavePocoAndLoadITableEntityWithNullablesSet(ITablesClient writer, ITablesClient reader)
        {
            var testEntity = new TestITableEntity(true)
            {
                PartitionKey = PartitionKey,
                RowKey = RowKey,
                // SDK can't handle overflow in longs
                UInt64TypeProperty = long.MaxValue,
                Int64TypeProperty = long.MaxValue,
                NullableUInt64TypeProperty = long.MaxValue,
                NullableInt64TypeProperty = long.MaxValue,
            };

            await writer.Write(this, testEntity);
            var output = await reader.Read<TestITableEntity>(this);

            AssertAreEqual(testEntity, output);
        }

        [Test]
        [TestCaseSource(nameof(T1T2ExtensionPermutations))]
        public async Task CanSavePocoAndLoadPoco(ITablesClient writer, ITablesClient reader)
        {
            var testEntity = new TestEntity()
            {
                PartitionKey = PartitionKey,
                RowKey = RowKey,
                // SDK can't handle overflow in longs
                UInt64TypeProperty = long.MaxValue,
                Int64TypeProperty = long.MaxValue,
            };

            await writer.Write(this, testEntity);
            var output = await reader.Read<TestEntity>(this);

            AssertAreEqual(testEntity, output);
        }

        [Test]
        [TestCaseSource(nameof(T1T2ExtensionPermutations))]
        public async Task CanSavePocoAndLoadPocoWithNullablesSet(ITablesClient writer, ITablesClient reader)
        {
            var testEntity = new TestEntity(true)
            {
                PartitionKey = PartitionKey,
                RowKey = RowKey
            };

            await writer.Write(this, testEntity);
            var output = await reader.Read<TestEntity>(this);

            AssertAreEqual(testEntity, output);
        }

        [Test]
        [TestCaseSource(nameof(T1T2ExtensionPermutations))]
        public async Task CanSavePocoAndLoadPocoWithInnerPoco(ITablesClient writer, ITablesClient reader)
        {
            var testEntity = new TestEntity(true)
            {
                PartitionKey = PartitionKey,
                RowKey = RowKey,
                NestedEntity = new TestEntity(true)
            };

            await writer.Write(this, testEntity);
            var output = await reader.Read<TestEntity>(this);

            AssertAreEqual(testEntity, output);
            AssertAreEqual(testEntity.NestedEntity, output.NestedEntity);
        }

        [Test]
        [TestCaseSource(nameof(T1T2ExtensionPermutations))]
        public async Task CanSavePocoAndLoadJObject(ITablesClient writer, ITablesClient reader)
        {
            if (UseCosmos && writer is Extension && reader is ExtensionT1)
            {
                Assert.Ignore("https://github.com/Azure/azure-webjobs-sdk/issues/2813");
            }
            var testEntity = new TestEntity()
            {
                PartitionKey = PartitionKey,
                RowKey = RowKey,
                // V4 can't handle longs in JObject
                UInt64TypeProperty = int.MaxValue,
                Int64TypeProperty = int.MaxValue,
                NullableUInt64TypeProperty = int.MaxValue,
                NullableInt64TypeProperty = int.MaxValue,
            };

            await writer.Write(this, testEntity);

            var outputA = await writer.Read<JObject>(this);
            var outputB = await reader.Read<JObject>(this);

            AssertAreEqual(outputA, outputB);
        }

        [Test]
        [TestCaseSource(nameof(T1T2ExtensionPermutations))]
        public async Task CanSavePocoAndLoadJObjectWithNullablesSet(ITablesClient writer, ITablesClient reader)
        {
            if (UseCosmos && writer is Extension && reader is ExtensionT1)
            {
                Assert.Ignore("https://github.com/Azure/azure-webjobs-sdk/issues/2813");
            }
            var testEntity = new TestEntity(true)
            {
                PartitionKey = PartitionKey,
                RowKey = RowKey,
                // V4 can't handle longs in JObject
                UInt64TypeProperty = int.MaxValue,
                Int64TypeProperty = int.MaxValue,
                NullableUInt64TypeProperty = int.MaxValue,
                NullableInt64TypeProperty = int.MaxValue,
            };

            await writer.Write(this, testEntity);

            var outputA = await writer.Read<JObject>(this);
            var outputB = await reader.Read<JObject>(this);

            AssertAreEqual(outputA, outputB);
        }

        [Test]
        [TestCaseSource(nameof(T1T2ExtensionPermutations))]
        public async Task CanSavePocoAndLoadJObjectWithInnerPoco(ITablesClient writer, ITablesClient reader)
        {
            if (UseCosmos && writer is Extension && reader is ExtensionT1)
            {
                Assert.Ignore("https://github.com/Azure/azure-webjobs-sdk/issues/2813");
            }
            var testEntity = new TestEntity(true)
            {
                PartitionKey = PartitionKey,
                RowKey = RowKey,
                NestedEntity = new TestEntity(true),
                // V4 can't handle longs in JObject
                UInt64TypeProperty = int.MaxValue,
                Int64TypeProperty = int.MaxValue,
                NullableUInt64TypeProperty = int.MaxValue,
                NullableInt64TypeProperty = int.MaxValue,
            };

            await writer.Write(this, testEntity);
            var outputA = await writer.Read<JObject>(this);
            var outputB = await reader.Read<JObject>(this);

            AssertAreEqual(outputA, outputB);
        }

        [Test]
        [TestCaseSource(nameof(T1T2ExtensionPermutations))]
        public async Task CanSaveJObjectAndLoadJObject(ITablesClient writer, ITablesClient reader)
        {
            if (UseCosmos && writer is Extension && reader is ExtensionT1)
            {
                Assert.Ignore("https://github.com/Azure/azure-webjobs-sdk/issues/2813");
            }
            var testEntity = FormatJObject(new TestEntity()
            {
                PartitionKey = PartitionKey,
                RowKey = RowKey,
                // V4 can't handle longs in JObject
                UInt64TypeProperty = int.MaxValue,
                Int64TypeProperty = int.MaxValue,
                NullableUInt64TypeProperty = int.MaxValue,
                NullableInt64TypeProperty = int.MaxValue,
            });

            await writer.Write(this, testEntity);

            var outputA = await writer.Read<JObject>(this);
            var outputB = await reader.Read<JObject>(this);

            AssertAreEqual(outputA, outputB);
        }

        [Test]
        [TestCaseSource(nameof(T1T2ExtensionPermutations))]
        public async Task CanSaveJObjectAndLoadJObjectWithNullablesSet(ITablesClient writer, ITablesClient reader)
        {
            if (UseCosmos && writer is Extension && reader is ExtensionT1)
            {
                Assert.Ignore("https://github.com/Azure/azure-webjobs-sdk/issues/2813");
            }
            var testEntity = FormatJObject(new TestEntity(true)
            {
                PartitionKey = PartitionKey,
                RowKey = RowKey,
                // V4 can't handle longs in JObject
                UInt64TypeProperty = int.MaxValue,
                Int64TypeProperty = int.MaxValue,
                NullableUInt64TypeProperty = int.MaxValue,
                NullableInt64TypeProperty = int.MaxValue,
            });

            await writer.Write(this, testEntity);

            var outputA = await writer.Read<JObject>(this);
            var outputB = await reader.Read<JObject>(this);

            AssertAreEqual(outputA, outputB);
        }

        [Test]
        [TestCaseSource(nameof(T1T2ExtensionPermutations))]
        public async Task CanSaveJObjectAndLoadJObjectWithInnerPoco(ITablesClient writer, ITablesClient reader)
        {
            if (UseCosmos && writer is Extension && reader is ExtensionT1)
            {
                Assert.Ignore("https://github.com/Azure/azure-webjobs-sdk/issues/2813");
            }
            var testEntity = FormatJObject(new TestEntity(true)
            {
                PartitionKey = PartitionKey,
                RowKey = RowKey,
                NestedEntity = new TestEntity(true),
                // V4 can't handle longs in JObject
                UInt64TypeProperty = int.MaxValue,
                Int64TypeProperty = int.MaxValue,
                NullableUInt64TypeProperty = int.MaxValue,
                NullableInt64TypeProperty = int.MaxValue,
            });

            await writer.Write(this, testEntity);
            var outputA = await writer.Read<JObject>(this);
            var outputB = await reader.Read<JObject>(this);

            AssertAreEqual(outputA, outputB);
        }

        public static object[] SdkExtensionPermutations { get; } = {
            new object[] { Sdk.Instance, Extension.Instance },
            new object[] { Extension.Instance, Sdk.Instance },
            new object[] { Sdk.Instance, Sdk.Instance },
            new object[] { Extension.Instance, Extension.Instance }
        };

        public static object[] T1T2ExtensionPermutations { get; } = {
            new object[] { ExtensionT1.Instance, Extension.Instance },
            new object[] { Extension.Instance, ExtensionT1.Instance },
            new object[] { ExtensionT1.Instance, ExtensionT1.Instance },
            new object[] { Extension.Instance, Extension.Instance }
        };

        private JObject FormatJObject(object o)
        {
            var jo = JObject.FromObject(o);
            // remove readonly properties
            jo.Remove("Timestamp");
            jo.Remove("ETag");
            return jo;
        }

        private void AssertAreEqual(JObject a, JObject b)
        {
            JObject Sort(JObject o)
            {
                return new JObject(o.Properties().OrderByDescending(p => p.Name));
            }

            string NormalizeDates(string s)
            {
                return s.Replace("+00:00", "Z");
            }

            Assert.AreEqual(
                NormalizeDates(Sort(a).ToString()),
                NormalizeDates(Sort(b).ToString()));
        }

        private void AssertAreEqual(object a, object b)
        {
            Assert.AreEqual(a.GetType(), b.GetType());
            foreach (var property in a.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.Name is nameof(ITableEntity.Timestamp) or nameof(ITableEntity.ETag) or nameof(TestEntity.NestedEntity)) continue;

                var av = property.GetValue(a);
                var bv = property.GetValue(b);
                Assert.AreEqual(av, bv, property.Name);
            }
        }

        public class TestITableEntity : ITableEntity
        {
            public TestITableEntity() : this(false)
            {
            }

            public TestITableEntity(bool setNullables)
            {
                DatetimeOffsetTypeProperty = DateTimeOffsetValue;
                DatetimeTypeProperty = DateTimeValue;

                StringTypeProperty = "hello";
                GuidTypeProperty = Guid.Parse("ca761232-ed42-11ce-bacd-00aa0057b223");
                BinaryTypeProperty = new byte[] {1, 2, 3};

                Int64TypeProperty = long.MaxValue;
                UInt64TypeProperty = ulong.MaxValue;
                DoubleTypeProperty = double.MaxValue;
                IntTypeProperty = int.MaxValue;
                EnumProperty = ConsoleColor.Blue;

                if (setNullables)
                {
                    NullableDatetimeTypeProperty = DateTimeValue;
                    NullableDatetimeOffsetTypeProperty = DateTimeOffsetValue;
                    NullableGuidTypeProperty = Guid.Parse("ca761232-ed42-11ce-bacd-00aa0057b223");
                    NullableInt64TypeProperty = long.MaxValue;
                    NullableUInt64TypeProperty = ulong.MaxValue;
                    NullableDoubleTypeProperty = double.MaxValue;
                    NullableIntTypeProperty = int.MaxValue;
                    NullableEnumProperty = ConsoleColor.Blue;
                }
            }

            public string StringTypeProperty { get; set; }
            public DateTime DatetimeTypeProperty { get; set; }
            public DateTimeOffset DatetimeOffsetTypeProperty { get; set; }
            public Guid GuidTypeProperty { get; set; }
            public byte[] BinaryTypeProperty { get; set; }
            public long Int64TypeProperty { get; set; }
            public ulong UInt64TypeProperty { get; set; }
            public double DoubleTypeProperty { get; set; }
            public int IntTypeProperty { get; set; }
            public ConsoleColor EnumProperty { get; set; }

            public DateTime? NullableDatetimeTypeProperty { get; set; }
            public DateTimeOffset? NullableDatetimeOffsetTypeProperty { get; set; }
            public Guid? NullableGuidTypeProperty { get; set; }
            public long? NullableInt64TypeProperty { get; set; }
            public ulong? NullableUInt64TypeProperty { get; set; }
            public double? NullableDoubleTypeProperty { get; set; }
            public int? NullableIntTypeProperty { get; set; }
            public ConsoleColor? NullableEnumProperty { get; set; }

            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset? Timestamp { get; set; }
            public ETag ETag { get; set; }
        }

        public class TestEntity
        {
            public TestEntity() : this(false)
            {
            }

            public TestEntity(bool setNullables)
            {
                DatetimeOffsetTypeProperty = DateTimeOffsetValue;
                DatetimeTypeProperty = DateTimeValue;

                StringTypeProperty = "hello";
                GuidTypeProperty = Guid.Parse("ca761232-ed42-11ce-bacd-00aa0057b223");
                BinaryTypeProperty = new byte[] {1, 2, 3};

                Int64TypeProperty = long.MaxValue;
                UInt64TypeProperty = ulong.MaxValue;
                DoubleTypeProperty = double.MaxValue;
                IntTypeProperty = int.MaxValue;
                EnumProperty = ConsoleColor.Blue;
                ArrayProperty = new[] { "this", "works" };

                if (setNullables)
                {
                    NullableDatetimeTypeProperty = DateTimeValue;
                    NullableDatetimeOffsetTypeProperty = DateTimeOffsetValue;
                    NullableGuidTypeProperty = Guid.Parse("ca761232-ed42-11ce-bacd-00aa0057b223");
                    NullableInt64TypeProperty = long.MaxValue;
                    NullableUInt64TypeProperty = ulong.MaxValue;
                    NullableDoubleTypeProperty = double.MaxValue;
                    NullableIntTypeProperty = int.MaxValue;
                    NullableEnumProperty = ConsoleColor.Blue;
                }
            }

            public string StringTypeProperty { get; set; }
            public DateTime DatetimeTypeProperty { get; set; }
            public DateTimeOffset DatetimeOffsetTypeProperty { get; set; }
            public Guid GuidTypeProperty { get; set; }
            public byte[] BinaryTypeProperty { get; set; }
            public long Int64TypeProperty { get; set; }
            public ulong UInt64TypeProperty { get; set; }
            public double DoubleTypeProperty { get; set; }
            public int IntTypeProperty { get; set; }
            public ConsoleColor EnumProperty { get; set; }
            public string[] ArrayProperty { get; set; }

            public DateTime? NullableDatetimeTypeProperty { get; set; }
            public DateTimeOffset? NullableDatetimeOffsetTypeProperty { get; set; }
            public Guid? NullableGuidTypeProperty { get; set; }
            public long? NullableInt64TypeProperty { get; set; }
            public ulong? NullableUInt64TypeProperty { get; set; }
            public double? NullableDoubleTypeProperty { get; set; }
            public int? NullableIntTypeProperty { get; set; }
            public ConsoleColor NullableEnumProperty { get; set; }

            public string PartitionKey { get; set; }
            public string RowKey { get; set; }
            public DateTimeOffset Timestamp { get; set; }
            public string ETag { get; set; }
            public TestEntity NestedEntity { get; set; }
        }

        public interface ITablesClient
        {
            ValueTask<T> Read<T>(CompatibilityTests test);
            ValueTask Write<T>(CompatibilityTests test, T entity);
        }

        private class Sdk: ITablesClient
        {
            public static Sdk Instance = new();
            public async ValueTask<T> Read<T>(CompatibilityTests test)
            {
                return await (Task<Response<T>>)typeof(TableClient)
                    .GetMethod("GetEntityAsync", BindingFlags.Public | BindingFlags.Instance)
                    .MakeGenericMethod(typeof(T))
                    .Invoke(test.TableClient, new object[] { PartitionKey, RowKey, null, default(CancellationToken) });
            }

            public async ValueTask Write<T>(CompatibilityTests test, T entity)
            {
                await (Task)typeof(TableClient)
                    .GetMethod("AddEntityAsync", BindingFlags.Public | BindingFlags.Instance)
                    .MakeGenericMethod(typeof(T))
                    .Invoke(test.TableClient, new object[] { entity, default(CancellationToken) });
            }

            public override string ToString() => "SDK";
        }

        private class Extension : ITablesClient
        {
            public static Extension Instance = new();
            public async ValueTask<T> Read<T>(CompatibilityTests test)
            {
                var result = await test.CallAsync<GetEntityProgram<T>>();
                return result.Entity;
            }

            public async ValueTask Write<T>(CompatibilityTests test, T entity)
            {
                await test.CallAsync<AddEntityProgram<T>>(arguments: new { entity });
            }

            public override string ToString() => "Extension";

            private class AddEntityProgram<T>
            {
                [return: Table(TableNameExpression)]
                public T Call(T entity) => entity;
            }

            private class GetEntityProgram<T>
            {
                public void Call([Table(TableNameExpression, PartitionKey, RowKey)] T entity)
                {
                    Entity = entity;
                }

                public T Entity { get; set; }
            }
        }

        private class ExtensionT1 : ITablesClient
        {
            public static ExtensionT1 Instance = new();
            public async ValueTask<T> Read<T>(CompatibilityTests test)
            {
                var result = await test.CallAsync<GetEntityProgramT1<T>>(configure: builder => Configure(builder, test));
                return result.Entity;
            }

            public async ValueTask Write<T>(CompatibilityTests test,T entity)
            {
                await test.CallAsync<AddEntityProgramT1<T>>(arguments: new { entity }, configure: builder => Configure(builder, test));
            }

            private void Configure(HostBuilder builder, CompatibilityTests test)
            {
                test.DefaultConfigure(builder);
                builder.ConfigureWebJobs(jobsBuilder =>
                {
                    T1::Microsoft.Extensions.Hosting.StorageWebJobsBuilderExtensions.AddAzureStorage(jobsBuilder);
                });
            }

            public override string ToString() => "ExtensionT1";

            private class AddEntityProgramT1<T>
            {
                [return: T1::Microsoft.Azure.WebJobs.Table(TableNameExpression)]
                public T Call(T entity) => entity;
            }

            private class GetEntityProgramT1<T>
            {
                public void Call([T1::Microsoft.Azure.WebJobs.TableAttribute(TableNameExpression, PartitionKey, RowKey)] T entity)
                {
                    Entity = entity;
                }

                public T Entity { get; set; }
            }
        }
    }
}