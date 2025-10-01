// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Xml;
using Azure.Core.TestFramework;
using Azure.Data.Tables.Models;
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
        private const string TableName2 = "otherTableName";
        private const string Partition = "partition";
        private const string MixedCasePK = "PartitionKey";
        private const string Row = "row";
        private const int SomeInt = 10;
        private const double SomeDouble = 10.10;
        private static readonly string SomeDoubleRoundtrip = XmlConvert.ToString(SomeDouble);
        private const long SomeInt64 = long.MaxValue;
        private const string SomeString = "someString";
        private const bool SomeTrueBool = true;
        private const bool SomeFalseBool = false;
        private static readonly DateTime s_someDateTime = DateTime.Parse("2020-07-23T21:20:41.6667782Z", null, System.Globalization.DateTimeStyles.RoundtripKind);
        private static readonly DateTimeOffset s_someDateTimeOffset = DateTimeOffset.Parse("2020-07-23T21:20:41.6667782Z");
        private static string s_someDateTimeOffsetRoundtrip = XmlConvert.ToString(s_someDateTimeOffset.UtcDateTime, XmlDateTimeSerializationMode.RoundtripKind);
        private static readonly Guid s_someGuid = new Guid("66cf3753-1cc9-44c4-b857-4546f744901b");
        private static readonly string s_someGuidString = "66cf3753-1cc9-44c4-b857-4546f744901b";
        private static readonly byte[] s_someBinary = new byte[] { 0x01, 0x02, 0x03, 0x04, 0xFF };
        private static readonly BinaryData s_someBinaryData = new BinaryData(new byte[] { 0x01, 0x02, 0x03, 0x04, 0xFF });
        private static readonly Expression<Func<ComplexEntity, bool>> s_rename = x => x.RenamableStringProperty == "someString";
        private static readonly Expression<Func<ComplexEntity, bool>> s_renameAndNonrename = x => x.RenamableStringProperty != "someString" && x.PartitionKey == Partition;
        private static readonly Expression<Func<ComplexEntity, bool>> s_nonRenameDataMember = x => x.DataMemberImplictNameProperty != "someString";
        private static readonly Expression<Func<TableItem, bool>> s_ne_TI = x => x.Name != TableName;
        private static readonly Expression<Func<ComplexEntity, bool>> s_ne = x => x.PartitionKey == Partition && x.RowKey != Row;
        private static readonly Expression<Func<TableEntity, bool>> s_neDE = x => x.PartitionKey == Partition && x.RowKey != Row;
        private static readonly Expression<Func<TableItem, bool>> s_gt_TI = x => x.Name.CompareTo(TableName) > 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_gt = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) > 0;
        private static readonly Expression<Func<TableEntity, bool>> s_gtDE = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) > 0;
        private static readonly Expression<Func<TableItem, bool>> s_ge_TI = x => x.Name.CompareTo(TableName) >= 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_ge = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) >= 0;
        private static readonly Expression<Func<TableEntity, bool>> s_geDE = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) >= 0;
        private static readonly Expression<Func<TableItem, bool>> s_le_TI = x => x.Name.CompareTo(TableName) <= 0;
        private static readonly Expression<Func<TableItem, bool>> s_lege_TI = x => x.Name.CompareTo(TableName) <= 0 && x.Name.CompareTo(TableName2) >= 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_le = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) <= 0;
        private static readonly Expression<Func<TableEntity, bool>> s_leDE = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) <= 0;
        private static readonly Expression<Func<TableItem, bool>> s_lt_TI = x => x.Name.CompareTo(TableName) < 0;
        private static readonly Expression<Func<ComplexEntity, bool>> s_lt = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) < 0;
        private static readonly Expression<Func<TableEntity, bool>> s_ltDE = x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) < 0;
        private static readonly Expression<Func<TableItem, bool>> s_or_TI = x => x.Name == TableName || x.Name == TableName2;
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
        private static readonly Expression<Func<ComplexEntity, bool>> s_dtoNewExp = ent => ent.DateTimeOffset >= new DateTimeOffset(s_someDateTimeOffset.UtcTicks, TimeSpan.Zero);
        private static readonly Expression<Func<TableEntity, bool>> s_dtoExpDE = ent => ent.GetDateTime("DateTimeOffset") >= s_someDateTimeOffset;
        private static readonly Expression<Func<ComplexEntity, bool>> s_dtExp = ent => ent.DateTime < s_someDateTime;
        private static readonly Expression<Func<ComplexEntity, bool>> s_dtNewExp = ent => ent.DateTime < new DateTime(s_someDateTime.Ticks, DateTimeKind.Utc);
        private static readonly Expression<Func<TableEntity, bool>> s_dtExpDE = ent => ent.GetDateTime("DateTime") < s_someDateTime;
        private static readonly Expression<Func<ComplexEntity, bool>> s_boolTrueExp = ent => ent.Bool == SomeTrueBool;
        private static readonly Expression<Func<TableEntity, bool>> s_boolTrueExpDE = ent => ent.GetBoolean("Bool") == SomeTrueBool;
        private static readonly Expression<Func<ComplexEntity, bool>> s_boolFalseExp = ent => ent.Bool == SomeFalseBool;
        private static readonly Expression<Func<TableEntity, bool>> s_boolFalseExpDE = ent => ent.GetBoolean("Bool") == SomeFalseBool;
        private static readonly Expression<Func<ComplexEntity, bool>> s_binaryExp = ent => ent.Binary == s_someBinaryData;
        private static readonly Expression<Func<TableEntity, bool>> s_binaryExpDE = ent => ent.GetBinaryData("Binary") == s_someBinaryData;
        private static readonly Expression<Func<ComplexEntity, bool>> s_complexExp = ent => ent.String.CompareTo(SomeString) >= 0 && ent.Int64 >= SomeInt64 && ent.Int32 >= SomeInt && ent.DateTime >= s_someDateTime;
        private static readonly Expression<Func<TableEntity, bool>> s_complexExpDE = ent => ent.GetString("String").CompareTo(SomeString) >= 0 && ent.GetInt64("Int64") >= SomeInt64 && ent.GetInt32("Int32") >= SomeInt && ent.GetDateTime("DateTime") >= s_someDateTime;
        private static readonly Expression<Func<ComplexEntity, bool>> s_veryComplexExp = ent => ent.String.CompareTo(SomeString) >= 0 && (ent.Int64 >= SomeInt64 || ent.Int32 >= SomeInt) && ent.DateTime >= s_someDateTime && !ent.Bool;
        private static readonly Expression<Func<ComplexEntity, bool>> s_complexExpImplicitBooleanCmp = ent => ent.Bool;
        private static readonly Expression<Func<ComplexEntity, bool>> s_complexExpImplicitNullableBooleanCmp = ent => ent.BoolN.Value;
        private static readonly Expression<Func<ComplexEntity, bool>> s_complexExpImplicitBooleanCmpNot = ent => !ent.Bool;
        private static readonly Expression<Func<ComplexEntity, bool>> s_complexExpImplicitCastedNullableBooleanCmp = ent => (bool)ent.BoolN;
        private static readonly Expression<Func<ComplexEntity, bool>> s_complexExpImplicitBooleanCmpAnd = ent => ent.Bool && ent.BoolN.Value;
        private static readonly Expression<Func<ComplexEntity, bool>> s_complexExpImplicitCastedBooleanCmpOr = ent => (bool)ent.Bool || (bool)(bool?)ent.BoolN;
        private static readonly Expression<Func<TableEntity, bool>> s_tableEntExpImplicitBooleanCmp = ent => ent.GetBoolean("Bool").Value;
        private static readonly Expression<Func<TableEntity, bool>> s_tableEntExpImplicitBooleanCmpCasted = ent => (bool)ent.GetBoolean("Bool");
        private static readonly Expression<Func<TableEntity, bool>> s_tableEntExpImplicitBooleanCmpOr = ent => ent.GetBoolean("Bool").Value || (bool)ent.GetBoolean("Bool");
        private static readonly Expression<Func<TableEntity, bool>> s_tableEntExpImplicitBooleanCmpNot = ent => !ent.GetBoolean("Bool").Value;
        private static readonly Expression<Func<TableEntity, bool>> s_tableEntExpEquals = ent => ent.PartitionKey.Equals(Partition);
        private static readonly Expression<Func<ComplexEntity, bool>> s_CEtableEntExpEquals = ent => ent.String.Equals(Partition);
        private static readonly Expression<Func<ComplexEntity, bool>> s_CEtableEntExpStaticEquals = ent => string.Equals(ent.String, Partition);
        private static readonly Expression<Func<TableEntity, bool>> s_TEequalsUnsupported = ent => ent.PartitionKey.Equals(Partition, StringComparison.OrdinalIgnoreCase);
        private static readonly Expression<Func<TableEntity, bool>> s_TEequalsToLowerUnsupported = ent => ent.PartitionKey.Equals(Partition.ToLower(), StringComparison.OrdinalIgnoreCase);
        private static readonly Expression<Func<TableEntity, bool>> s_TEequalsStaticUnsupported = ent => string.Equals(ent.PartitionKey, Partition, StringComparison.OrdinalIgnoreCase);
        private static readonly Expression<Func<TableEntity, bool>> s_TECompareStaticUnsupported = ent => string.Compare(ent.PartitionKey, Partition, StringComparison.OrdinalIgnoreCase) > 0;

        public static object[] TableEntityExpressionTestCases =
        {
            new object[] {$"SomeNewName eq 'someString'", s_rename},
            new object[] {$"SomeNewName ne 'someString' and PartitionKey eq '{Partition}'", s_renameAndNonrename},
            new object[] {$"DataMemberImplictNameProperty ne 'someString'", s_nonRenameDataMember },
            new object[] { $"PartitionKey eq '{Partition}' and RowKey ne '{Row}'", s_ne },
            new object[] { $"PartitionKey eq '{Partition}' and RowKey gt '{Row}'", s_gt },
            new object[] { $"PartitionKey eq '{Partition}' and RowKey ge '{Row}'", s_ge },
            new object[] { $"PartitionKey eq '{Partition}' and RowKey lt '{Row}'", s_lt },
            new object[] { $"PartitionKey eq '{Partition}' and RowKey le '{Row}'", s_le },
            new object[] { $"PartitionKey eq '{Partition}' or RowKey eq '{Row}'", s_or },
            new object[] { $"String ge '{SomeString}'", s_compareToExp },
            new object[] { $"Guid eq guid'{s_someGuidString}'", s_guidExp },
            new object[] { $"Int64 ge {SomeInt64}L", s_int64Exp },
            new object[] { $"Double ge {SomeDoubleRoundtrip}", s_doubleExp },
            new object[] { $"Int32 ge {SomeInt}", s_intExp },
            new object[] { $"DateTimeOffset ge datetime'{s_someDateTimeOffsetRoundtrip}'", s_dtoExp },
            new object[] { $"DateTimeOffset ge datetime'{s_someDateTimeOffsetRoundtrip}'", s_dtoNewExp },
            new object[] { $"DateTime lt datetime'{s_someDateTimeOffsetRoundtrip}'", s_dtExp },
            new object[] { $"DateTime lt datetime'{s_someDateTimeOffsetRoundtrip}'", s_dtNewExp },
            new object[] { $"Bool eq true", s_boolTrueExp },
            new object[] { $"Bool eq false", s_boolFalseExp },
            new object[] { $"Binary eq X'{string.Join(string.Empty, s_someBinary.Select(b => b.ToString("X2")))}'", s_binaryExp },
            new object[] { $"Binary eq X'{string.Join(string.Empty, s_someBinaryData.ToArray().Select(b => b.ToString("X2")))}'", s_binaryExp },
            new object[] { $"String ge '{SomeString}' and Int64 ge {SomeInt64}L and Int32 ge {SomeInt} and DateTime ge datetime'{s_someDateTimeOffsetRoundtrip}'", s_complexExp },
            new object[] { $"String ge '{SomeString}' and (Int64 ge {SomeInt64}L or Int32 ge {SomeInt}) and DateTime ge datetime'{s_someDateTimeOffsetRoundtrip}' and not (Bool eq true)", s_veryComplexExp },
            new object[] { $"Bool eq true", s_complexExpImplicitBooleanCmp },
            new object[] { $"BoolN eq true", s_complexExpImplicitNullableBooleanCmp },
            new object[] { $"not (Bool eq true)", s_complexExpImplicitBooleanCmpNot },
            new object[] { $"BoolN eq true", s_complexExpImplicitCastedNullableBooleanCmp },
            new object[] { $"Bool eq true and BoolN eq true", s_complexExpImplicitBooleanCmpAnd },
            new object[] { $"Bool eq true or BoolN eq true", s_complexExpImplicitCastedBooleanCmpOr },
            new object[] { $"String eq '{Partition}'", s_CEtableEntExpEquals },
            new object[] { $"String eq '{Partition}'", s_CEtableEntExpStaticEquals },
        };

        public static object[] TableItemExpressionTestCases =
        {
            new object[] { $"TableName ne '{TableName}'", s_ne_TI },
            new object[] { $"TableName gt '{TableName}'", s_gt_TI },
            new object[] { $"TableName ge '{TableName}'", s_ge_TI },
            new object[] { $"TableName le '{TableName}' and TableName ge '{TableName2}'", s_lege_TI },
            new object[] { $"TableName lt '{TableName}'", s_lt_TI },
            new object[] { $"TableName le '{TableName}'", s_le_TI },
            new object[] { $"TableName eq '{TableName}' or TableName eq '{TableName2}'", s_or_TI },
        };

        public static object[] DictionaryTableEntityExpressionTestCases =
        {
            new object[] { $"PartitionKey eq '{Partition}' and RowKey ne '{Row}'", s_neDE },
            new object[] { $"PartitionKey eq '{Partition}' and RowKey gt '{Row}'", s_gtDE },
            new object[] { $"PartitionKey eq '{Partition}' and RowKey ge '{Row}'", s_geDE },
            new object[] { $"PartitionKey eq '{Partition}' and RowKey lt '{Row}'", s_ltDE },
            new object[] { $"PartitionKey eq '{Partition}' and RowKey le '{Row}'", s_leDE },
            new object[] { $"PartitionKey eq '{Partition}' or RowKey eq '{Row}'", s_orDE },
            new object[] { $"String ge '{SomeString}'", s_compareToExpDE },
            new object[] { $"Guid eq guid'{s_someGuidString}'", s_guidExpDE },
            new object[] { $"Int64 ge {SomeInt64}L", s_int64ExpDE },
            new object[] { $"Double ge {SomeDoubleRoundtrip}", s_doubleExpDE },
            new object[] { $"Int32 ge {SomeInt}", s_intExpDE },
            new object[] { $"DateTimeOffset ge datetime'{s_someDateTimeOffsetRoundtrip}'", s_dtoExpDE },
            new object[] { $"DateTime lt datetime'{s_someDateTimeOffsetRoundtrip}'", s_dtExpDE },
            new object[] { $"Bool eq true", s_boolTrueExpDE },
            new object[] { $"Bool eq false", s_boolFalseExpDE },
            new object[] { $"Binary eq X'{string.Join(string.Empty, s_someBinary.Select(b => b.ToString("X2")))}'", s_binaryExpDE },
            new object[] { $"Binary eq X'{string.Join(string.Empty, s_someBinaryData.ToArray().Select(b => b.ToString("X2")))}'", s_binaryExpDE },
            new object[] { $"String ge '{SomeString}' and Int64 ge {SomeInt64}L and Int32 ge {SomeInt} and DateTime ge datetime'{s_someDateTimeOffsetRoundtrip}'", s_complexExpDE },
            new object[] { $"Bool eq true", s_tableEntExpImplicitBooleanCmp },
            new object[] { $"Bool eq true", s_tableEntExpImplicitBooleanCmpCasted },
            new object[] { $"Bool eq true or Bool eq true", s_tableEntExpImplicitBooleanCmpOr },
            new object[] { $"not (Bool eq true)", s_tableEntExpImplicitBooleanCmpNot },
            new object[] { $"PartitionKey eq '{Partition}'", s_tableEntExpEquals },
        };

        public static object[] UnsupportedTableItemExpressionTestCases =
        {
            new object[] { s_TEequalsUnsupported },
            new object[] { s_TEequalsStaticUnsupported },
            new object[] { s_TEequalsToLowerUnsupported },
            new object[] { s_TECompareStaticUnsupported },
        };

        [TestCaseSource(nameof(TableItemExpressionTestCases))]
        [Test]
        public void TestTableItemFilterExpressions(string expectedFilter, Expression<Func<TableItem, bool>> expression)
        {
            var filter = TableClient.CreateQueryFilter(expression);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [TestCaseSource(nameof(TableEntityExpressionTestCases))]
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

        [TestCaseSource(nameof(UnsupportedTableItemExpressionTestCases))]
        [Test]
        [NonParallelizable]
        public void TestTableItemFilterExpressionsUnsupported(Expression<Func<TableEntity, bool>> expression)
        {
            Assert.Throws<NotSupportedException>(() => TableClient.CreateQueryFilter(expression));
        }

        [TestCaseSource(nameof(UnsupportedTableItemExpressionTestCases))]
        [Test]
        [NonParallelizable]
        public void TestTableItemFilterExpressionsUnsupportedDoesNotThrowWithCompatSwitch(Expression<Func<TableEntity, bool>> expression)
        {
            if (expression == s_TEequalsStaticUnsupported)
            {
                Assert.Ignore("Ignore this expression because it was never supported.");
            }
            using var ctx = new TestAppContextSwitch(TableConstants.CompatSwitches.DisableThrowOnStringComparisonFilterSwitchName, true.ToString());
            TableClient.CreateQueryFilter(expression);
        }

        [TestCaseSource(nameof(UnsupportedTableItemExpressionTestCases))]
        [Test]
        [NonParallelizable]
        public void TestTableItemFilterExpressionsUnsupportedDoesNotThrowWithCompatSwitchEnv(Expression<Func<TableEntity, bool>> expression)
        {
            if (expression == s_TEequalsStaticUnsupported)
            {
                Assert.Ignore("Ignore this expression because it was never supported.");
            }
            using var env = new TestEnvVar(TableConstants.CompatSwitches.DisableThrowOnStringComparisonFilterEnvVar, true.ToString());
            TableClient.CreateQueryFilter(expression);
        }
    }
}
