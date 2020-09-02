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
        private const string TableName = "someTableName";
        private const string Partition = "partition";
        private const string Row = "row";
        private const int SomeInt = 10;
        private const double SomeDouble = 10.10;
        private const long SomeInt64 = long.MaxValue;
        private const string SomeString = "someString";
        private const bool SomeTrueBool = true;
        private const bool SomeFalseBool = false;
        private static readonly DateTime s_someDateTime = DateTime.Parse("2020-07-23T21:20:41.6667782Z", null, System.Globalization.DateTimeStyles.RoundtripKind);
        private static readonly DateTimeOffset s_someDateTimeOffset = DateTimeOffset.Parse("2020-07-23T21:20:41.6667782Z");
        private static string s_someDateTimeOffsetRoundtrip = XmlConvert.ToString(s_someDateTimeOffset.UtcDateTime, XmlDateTimeSerializationMode.RoundtripKind);
        private static readonly Guid s_someGuid = new Guid("66cf3753-1cc9-44c4-b857-4546f744901b");
        private static readonly string s_someGuidString = "66cf3753-1cc9-44c4-b857-4546f744901b";
        private static readonly byte[] s_someBinary = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };
        private static readonly Expression<Func<ComplexEntity, bool>> s_ne = x => x.PartitionKey == Partition && x.RowKey != Row;
        private static readonly Expression<Func<TableEntity, bool>> s_neDE = x => x.PartitionKey == Partition && x.RowKey != Row;
        private static readonly Expression<Func<ComplexEntity, bool>> s_gt = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) > 0;
        private static readonly Expression<Func<TableEntity, bool>> s_gtDE = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) > 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_ge = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) >= 0;
        private static readonly Expression<Func<TableEntity, bool>> s_geDE = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) >= 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_lt = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) < 0;
        private static readonly Expression<Func<TableEntity, bool>> s_ltDE = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) < 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_le = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) <= 0;
        private static readonly Expression<Func<TableEntity, bool>> s_leDE = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) <= 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_or = x => x.PartitionKey == Partition || x.RowKey == Row;
        private static readonly Expression<Func<TableEntity, bool>> s_orDE = x => x.PartitionKey == Partition || x.RowKey == Row;
        private static readonly Expression<Func<ComplexEntity, bool>> s_compareToExp = ent => ent.String.CompareTo(SomeString) >= 0;
        private static readonly Expression<Func<TableEntity, bool>> s_compareToExpDE = ent => ent.GetString("String").CompareTo(SomeString) >= 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_guidExp = ent => ent.Guid == s_someGuid;
        private static readonly Expression<Func<TableEntity, bool>> s_guidExpDE = ent => ent.GetGuid("Guid") == s_someGuid;
        private static readonly Expression<Func<ComplexEntity, bool>> s_int64Exp = ent => ent.Int64 >= SomeInt64;
        private static readonly Expression<Func<TableEntity, bool>> s_int64ExpDE = ent => ent.GetInt64("Int64") >= SomeInt64;
        private static readonly Expression<Func<ComplexEntity, bool>> s_doubleExp = ent => ent.Double >= SomeDouble;
        private static readonly Expression<Func<TableEntity, bool>> s_doubleExpDE = ent => ent.GetDouble("Double") >= SomeDouble;
        private static readonly Expression<Func<ComplexEntity, bool>> s_intExp = ent => ent.Int32 >= SomeInt;
        private static readonly Expression<Func<TableEntity, bool>> s_intExpDE = ent => ent.GetInt32("Int32") >= SomeInt;
        private static readonly Expression<Func<ComplexEntity, bool>> s_dtoExp = ent => ent.DateTimeOffset >= s_someDateTimeOffset;
        private static readonly Expression<Func<TableEntity, bool>> s_dtoExpDE = ent => ent.GetDateTime("DateTimeOffset") >= s_someDateTimeOffset;
        private static readonly Expression<Func<ComplexEntity, bool>> s_dtExp = ent => ent.DateTime < s_someDateTime;
        private static readonly Expression<Func<TableEntity, bool>> s_dtExpDE = ent => ent.GetDateTime("DateTime") < s_someDateTime;
        private static readonly Expression<Func<ComplexEntity, bool>> s_boolTrueExp = ent => ent.Bool == SomeTrueBool;
        private static readonly Expression<Func<TableEntity, bool>> s_boolTrueExpDE = ent => ent.GetBoolean("Bool") == SomeTrueBool;
        private static readonly Expression<Func<ComplexEntity, bool>> s_boolFalseExp = ent => ent.Bool == SomeFalseBool;
        private static readonly Expression<Func<TableEntity, bool>> s_boolFalseExpDE = ent => ent.GetBoolean("Bool") == SomeFalseBool;
        private static readonly Expression<Func<ComplexEntity, bool>> s_binaryExp = ent => ent.Binary == s_someBinary;
        private static readonly Expression<Func<TableEntity, bool>> s_binaryExpDE = ent => ent.GetBinary("Binary") == s_someBinary;
        private static readonly Expression<Func<ComplexEntity, bool>> s_complexExp = ent => ent.String.CompareTo(SomeString) >= 0 && ent.Int64 >= SomeInt64 && ent.Int32 >= SomeInt && ent.DateTime >= s_someDateTime;
        private static readonly Expression<Func<TableEntity, bool>> s_complexExpDE = ent => ent.GetString("String").CompareTo(SomeString) >= 0 && ent.GetInt64("Int64") >= SomeInt64 && ent.GetInt32("Int32") >= SomeInt && ent.GetDateTime("DateTime") >= s_someDateTime;

        public static object[] ExpressionTestCases =
        {
            new object[] { $"(PartitionKey eq '{Partition}') and (RowKey ne '{Row}')", s_ne },
            new object[] { $"(PartitionKey eq '{Partition}') and (RowKey gt '{Row}')", s_gt },
            new object[] { $"(PartitionKey eq '{Partition}') and (RowKey ge '{Row}')", s_ge },
            new object[] { $"(PartitionKey eq '{Partition}') and (RowKey lt '{Row}')", s_lt },
            new object[] { $"(PartitionKey eq '{Partition}') and (RowKey le '{Row}')", s_le },
            new object[] { $"(PartitionKey eq '{Partition}') or (RowKey eq '{Row}')", s_or },
            new object[] { $"String ge '{SomeString}'", s_compareToExp },
            new object[] { $"Guid eq guid'{s_someGuidString}'", s_guidExp },
            new object[] { $"Int64 ge {SomeInt64}L", s_int64Exp },
            new object[] { $"Double ge {SomeDouble}", s_doubleExp },
            new object[] { $"Int32 ge {SomeInt}", s_intExp },
            new object[] { $"DateTimeOffset ge datetime'{s_someDateTimeOffsetRoundtrip}'", s_dtoExp },
            new object[] { $"DateTime lt datetime'{s_someDateTimeOffsetRoundtrip}'", s_dtExp },
            new object[] { $"Bool eq true", s_boolTrueExp },
            new object[] { $"Bool eq false", s_boolFalseExp },
            new object[] { $"Binary eq X'{string.Join(string.Empty, s_someBinary.Select(b => b.ToString("D2")))}'", s_binaryExp },
            new object[] { $"(((String ge '{SomeString}') and (Int64 ge {SomeInt64}L)) and (Int32 ge {SomeInt})) and (DateTime ge datetime'{s_someDateTimeOffsetRoundtrip}')", s_complexExp },
        };

        public static object[] DictionaryTableEntityExpressionTestCases =
        {
            new object[] { $"(PartitionKey eq '{Partition}') and (RowKey ne '{Row}')", s_neDE },
            new object[] { $"(PartitionKey eq '{Partition}') and (RowKey gt '{Row}')", s_gtDE },
            new object[] { $"(PartitionKey eq '{Partition}') and (RowKey ge '{Row}')", s_geDE },
            new object[] { $"(PartitionKey eq '{Partition}') and (RowKey lt '{Row}')", s_ltDE },
            new object[] { $"(PartitionKey eq '{Partition}') and (RowKey le '{Row}')", s_leDE },
            new object[] { $"(PartitionKey eq '{Partition}') or (RowKey eq '{Row}')", s_orDE },
            new object[] { $"String ge '{SomeString}'", s_compareToExpDE },
            new object[] { $"Guid eq guid'{s_someGuidString}'", s_guidExpDE },
            new object[] { $"Int64 ge {SomeInt64}L", s_int64ExpDE },
            new object[] { $"Double ge {SomeDouble}", s_doubleExpDE },
            new object[] { $"Int32 ge {SomeInt}", s_intExpDE },
            new object[] { $"DateTimeOffset ge datetime'{s_someDateTimeOffsetRoundtrip}'", s_dtoExpDE },
            new object[] { $"DateTime lt datetime'{s_someDateTimeOffsetRoundtrip}'", s_dtExpDE },
            new object[] { $"Bool eq true", s_boolTrueExpDE },
            new object[] { $"Bool eq false", s_boolFalseExpDE },
            new object[] { $"Binary eq X'{string.Join(string.Empty, s_someBinary.Select(b => b.ToString("D2")))}'", s_binaryExpDE },
            new object[] { $"(((String ge '{SomeString}') and (Int64 ge {SomeInt64}L)) and (Int32 ge {SomeInt})) and (DateTime ge datetime'{s_someDateTimeOffsetRoundtrip}')", s_complexExpDE },
        };

        [TestCaseSource(nameof(ExpressionTestCases))]
        [Test]
        public void TestPOCOFilterExpressions(string expectedFilter, Expression<Func<ComplexEntity, bool>> expression)
        {
            var filter = TableClient.CreateQueryFilter(expression);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [TestCaseSource(nameof(DictionaryTableEntityExpressionTestCases))]
        [Test]
        public void TestDictionaryTableEntityFilterExpressions(string expectedFilter, Expression<Func<TableEntity, bool>> expression)
        {
            var filter = TableClient.CreateQueryFilter(expression);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }
    }
}
