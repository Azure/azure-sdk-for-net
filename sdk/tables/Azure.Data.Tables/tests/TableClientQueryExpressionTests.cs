// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Queryable;
using NUnit.Framework;
using static Azure.Data.Tables.Tests.TableServiceLiveTestsBase;

namespace Azure.Data.Tables.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="TableServiceClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class TableClientQueryExpressionTests
    {
        private TableClient client { get; set; }
        private const string TableName = "someTableName";
        private const string Partition = "partition";
        private const string Row = "row";
        private const int SomeInt = 10;
        private const double SomeDouble = 10.10;
        private const long SomeInt64 = long.MaxValue;
        private const string SomeString = "someString";
        private const bool SomeTrueBool = true;
        private const bool SomeFalseBool = false;
        private static readonly DateTime _someDateTime = DateTime.UtcNow;
        private static readonly DateTimeOffset _someDateTimeOffset = DateTimeOffset.UtcNow;
        private static readonly Guid _someGuid = Guid.NewGuid();
        private static readonly byte[] _someBinary = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };
        private static readonly Expression<Func<ComplexEntity, bool>> s_ne = x => x.PartitionKey == Partition && x.RowKey != Row;
        private static readonly Expression<Func<ComplexEntity, bool>> s_gt = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) > 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_ge = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) >= 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_lt = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) < 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_le = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) <= 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_or = x => x.PartitionKey == Partition || x.RowKey == Row;
        private static readonly Expression<Func<ComplexEntity, bool>> s_stringExp = ent => ent.String.CompareTo(SomeString) >= 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_guidExp = ent => ent.Guid == _someGuid;
        private static readonly Expression<Func<ComplexEntity, bool>> s_int64Exp = ent => ent.Int64 >= SomeInt64;
        private static readonly Expression<Func<ComplexEntity, bool>> s_doubleExp = ent => ent.Double >= SomeDouble;
        private static readonly Expression<Func<ComplexEntity, bool>> s_intExp = ent => ent.Int32 >= SomeInt;
        private static readonly Expression<Func<ComplexEntity, bool>> s_dtoExp = ent => ent.DateTimeOffset >= _someDateTimeOffset;
        private static readonly Expression<Func<ComplexEntity, bool>> s_dtExp = ent => ent.DateTime < _someDateTime;
        private static readonly Expression<Func<ComplexEntity, bool>> s_boolTrueExp = ent => ent.Bool == SomeTrueBool;
        private static readonly Expression<Func<ComplexEntity, bool>> s_boolFalseExp = ent => ent.Bool == SomeFalseBool;
        private static readonly Expression<Func<ComplexEntity, bool>> s_binaryExp = ent => ent.Binary == _someBinary;
        private static readonly Expression<Func<ComplexEntity, bool>> s_complexExp = ent => ent.String.CompareTo(SomeString) >= 0 && ent.Int64 >= SomeInt64 && ent.Int32 >= SomeInt && ent.DateTime >= _someDateTime;

        [OneTimeSetUp]
        public void TestSetup()
        {
            var service = new TableServiceClient(new Uri("https://example.com"));
            client = service.GetTableClient(TableName);
        }

        public static object[] ExpressionTestCases =
        {
            new object[] {$"(PartitionKey eq '{Partition}') and (RowKey ne '{Row}')", s_ne },
            new object[] {$"(PartitionKey eq '{Partition}') and (RowKey gt '{Row}')", s_gt },
            new object[] {$"(PartitionKey eq '{Partition}') and (RowKey ge '{Row}')", s_ge },
            new object[] {$"(PartitionKey eq '{Partition}') and (RowKey lt '{Row}')", s_lt },
            new object[] {$"(PartitionKey eq '{Partition}') and (RowKey le '{Row}')", s_le },
            new object[] {$"(PartitionKey eq '{Partition}') or (RowKey eq '{Row}')", s_or },
            new object[] {$"String ge '{SomeString}'", s_stringExp },
            new object[] {$"Guid eq guid'{_someGuid}'", s_guidExp },
            new object[] {$"Int64 ge {SomeInt64}L", s_int64Exp },
            new object[] { $"Double ge {SomeDouble}", s_doubleExp },
            new object[] { $"Int32 ge {SomeInt}", s_intExp },
            new object[] { $"DateTimeOffset ge datetime'{XmlConvert.ToString(_someDateTimeOffset.UtcDateTime, XmlDateTimeSerializationMode.RoundtripKind)}'", s_dtoExp },
            new object[] { $"DateTime lt datetime'{XmlConvert.ToString(_someDateTime, XmlDateTimeSerializationMode.RoundtripKind)}'", s_dtExp },
            new object[] { $"Bool eq true", s_boolTrueExp },
            new object[] { $"Bool eq false", s_boolFalseExp },
            new object[] { $"Binary eq X'{string.Join(string.Empty, _someBinary.Select(b => b.ToString("D2")))}'", s_binaryExp },
            new object[] { $"(((String ge '{SomeString}') and (Int64 ge {SomeInt64}L)) and (Int32 ge {SomeInt})) and (DateTime ge datetime'{XmlConvert.ToString(_someDateTime, XmlDateTimeSerializationMode.RoundtripKind)}')", s_complexExp },
        };

        [TestCaseSource(nameof(ExpressionTestCases))]
        [Test]
        public void TestFilterExpressions(string expectedFilter, Expression<Func<ComplexEntity, bool>> expression)
        {
            var filter = client.CreateFilter(expression);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }
    }
}
