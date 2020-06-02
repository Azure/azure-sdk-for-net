// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly DateTime _someDateTime = DateTime.UtcNow;
        private readonly DateTimeOffset _someDateTimeOffset = DateTimeOffset.UtcNow;
        private readonly Guid _someGuid = Guid.NewGuid();
        private readonly byte[] _someBinary = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };

        [OneTimeSetUp]
        public void TestSetup()
        {
            var service = new TableServiceClient(new Uri("https://example.com"));
            client = service.GetTableClient(TableName);
        }

        [Test]
        public void QueryNE()
        {
            var expectedFilter = $"(PartitionKey eq '{Partition}') and (RowKey ne '{Row}')";

            var filter = client.CreateFilter<ComplexEntity>(x => x.PartitionKey == Partition && x.RowKey != Row);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryGT()
        {
            var expectedFilter = $"(PartitionKey eq '{Partition}') and (RowKey gt '{Row}')";

            var filter = client.CreateFilter<ComplexEntity>(x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) > 0);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryGE()
        {
            var expectedFilter = $"(PartitionKey eq '{Partition}') and (RowKey ge '{Row}')";

            var filter = client.CreateFilter<ComplexEntity>(x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) >= 0);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryLT()
        {
            var expectedFilter = $"(PartitionKey eq '{Partition}') and (RowKey lt '{Row}')";

            var filter = client.CreateFilter<ComplexEntity>(x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) < 0);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryLE()
        {
            var expectedFilter = $"(PartitionKey eq '{Partition}') and (RowKey le '{Row}')";

            var filter = client.CreateFilter<ComplexEntity>(x => x.PartitionKey == Partition && x.RowKey.CompareTo(Row) <= 0);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryOr()
        {
            var expectedFilter = $"(PartitionKey eq '{Partition}') or (RowKey eq '{Row}')";

            var filter = client.CreateFilter<ComplexEntity>(x => x.PartitionKey == Partition || x.RowKey == Row);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryStringType()
        {
            var expectedFilter = $"String ge '{SomeString}'";

            // Query on string
            var filter = client.CreateFilter<ComplexEntity>(ent => ent.String.CompareTo(SomeString) >= 0);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryGuidType()
        {
            var expectedFilter = $"Guid eq guid'{_someGuid}'";

            // Filter on Guid
            var filter = client.CreateFilter<ComplexEntity>(ent => ent.Guid == _someGuid);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryInt64Type()
        {
            var expectedFilter = $"Int64 ge {SomeInt64}L";

            // Filter on Long
            var filter = client.CreateFilter<ComplexEntity>(ent => ent.Int64 >= SomeInt64);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryDoubleType()
        {
            var expectedFilter = $"Double ge {SomeDouble}";

            // Filter on Double
            var filter = client.CreateFilter<ComplexEntity>(ent => ent.Double >= SomeDouble);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryIntType()
        {
            var expectedFilter = $"Int32 ge {SomeInt}";

            // Filter on Integer
            var filter = client.CreateFilter<ComplexEntity>(ent => ent.Int32 >= SomeInt);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryDateTimeOffsetType()
        {
            var expectedFilter = $"DateTimeOffset ge datetime'{XmlConvert.ToString(_someDateTimeOffset.UtcDateTime, XmlDateTimeSerializationMode.RoundtripKind)}'";

            // Filter on Date
            var filter = client.CreateFilter<ComplexEntity>(ent => ent.DateTimeOffset >= _someDateTimeOffset);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryDateTimeType()
        {
            var expectedFilter = $"DateTime lt datetime'{XmlConvert.ToString(_someDateTime, XmlDateTimeSerializationMode.RoundtripKind)}'";

            var filter = client.CreateFilter<ComplexEntity>(ent => ent.DateTime < _someDateTime);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryBoolType()
        {
            // Filter on true Boolean
            var filter = client.CreateFilter<ComplexEntity>(ent => ent.Bool == SomeTrueBool);

            Assert.That(filter, Is.EqualTo($"Bool eq true"));

            // Filter on false Boolean
            filter = client.CreateFilter<ComplexEntity>(ent => ent.Bool == SomeFalseBool);

            Assert.That(filter, Is.EqualTo($"Bool eq false"));
        }

        [Test]
        public void QueryBinaryType()
        {
            var expectedFilter = $"Binary eq X'{string.Join(string.Empty, _someBinary.Select(b => b.ToString("D2")))}'";

            // Filter on Binary
            var filter = client.CreateFilter<ComplexEntity>(ent => ent.Binary == _someBinary);

            Assert.That(filter, Is.EqualTo(expectedFilter));
        }

        [Test]
        public void QueryComplex()
        {
            var expectedFilter = $"(((String ge '{SomeString}') and (Int64 ge {SomeInt64}L)) and (Int32 ge {SomeInt})) and (DateTime ge datetime'{XmlConvert.ToString(_someDateTime, XmlDateTimeSerializationMode.RoundtripKind)}')";

            var filter = client.CreateFilter<ComplexEntity>(ent => ent.String.CompareTo(SomeString) >= 0 &&
                     ent.Int64 >= SomeInt64 &&
                     ent.Int32 >= SomeInt &&
                     ent.DateTime >= _someDateTime);

            Assert.That(filter, Is.EqualTo(expectedFilter));

        }
    }
}
