// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Models
{
    public class FacetResultTests
    {
        [Test]
        public void ValueFacetsConvertNumericTypes()
        {
            FacetResult facet = ModelReaderWriter.Read<FacetResult>(BinaryData.FromString(@"{""count"":2,""value"":1}"));

            Assert.AreEqual(1, facet.AsValueFacetResult<int>().Value);
            Assert.AreEqual(1L, facet.AsValueFacetResult<long>().Value);
            Assert.AreEqual(1.0, facet.AsValueFacetResult<double>().Value);
            Assert.AreEqual(1L, facet.AsValueFacetResult<long?>().Value);
            Assert.AreEqual(2, facet.AsValueFacetResult<long>().Count);
        }

        [Test]
        public void ValueFacetsPreserveNonNumericTypes()
        {
            Assert.AreEqual("Luxury", CreateFacet("value", "Luxury").AsValueFacetResult<string>().Value);
            Assert.IsTrue(CreateFacet("value", true).AsValueFacetResult<bool>().Value);
            DateTimeOffset date = new DateTimeOffset(2026, 10, 1, 0, 0, 0, TimeSpan.Zero);
            Assert.AreEqual(date, CreateFacet("value", date).AsValueFacetResult<DateTimeOffset>().Value);
        }

        [Test]
        public void NullValueFacetsPreserveNull()
        {
            FacetResult facet = CreateFacet("value", null);
            Assert.IsNull(facet.AsValueFacetResult<string>().Value);
            Assert.IsNull(facet.AsValueFacetResult<long?>().Value);
        }

        [Test]
        public void NumericConversionDoesNotSuppressOverflow()
        {
            FacetResult facet = CreateFacet("value", long.MaxValue);
            Assert.Throws<OverflowException>(() => facet.AsValueFacetResult<int>());
        }

        [Test]
        public void RangeFacetsConvertNumbersAndPreserveOpenBounds()
        {
            FacetResult facet = ModelReaderWriter.Read<FacetResult>(BinaryData.FromString(@"{""count"":2,""from"":1,""to"":null}"));
            RangeFacetResult<long> range = facet.AsRangeFacetResult<long>();
            Assert.AreEqual(1L, range.From);
            Assert.IsNull(range.To);
            Assert.AreEqual(2, range.Count);
        }

        [Test]
        public void RangeFacetsPreserveDateTimeOffset()
        {
            DateTimeOffset date = new DateTimeOffset(2026, 10, 1, 0, 0, 0, TimeSpan.Zero);
            RangeFacetResult<DateTimeOffset> range = CreateFacet("from", date).AsRangeFacetResult<DateTimeOffset>();
            Assert.AreEqual(date, range.From);
            Assert.IsNull(range.To);
        }

        [Test]
        public void FacetConversionsRejectWrongFacetType()
        {
            Assert.Throws<InvalidCastException>(() => CreateFacet("value", 1).AsRangeFacetResult<long>());
            Assert.Throws<InvalidCastException>(() => CreateFacet("from", 1).AsValueFacetResult<long>());
        }

        private static FacetResult CreateFacet(string property, object value) =>
            SearchModelFactory.FacetResult(2, new Dictionary<string, object> { [property] = value });
    }
}
