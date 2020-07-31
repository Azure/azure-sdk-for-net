// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
#if EXPERIMENTAL_SPATIAL
using Azure.Core.Spatial;
#else
using Microsoft.Spatial;
#endif
using KeyFieldAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

// TODO: Remove when https://github.com/Azure/azure-sdk-for-net/issues/11166 is completed.
namespace Azure.Search.Documents.Samples.Tests
{
    public class ReflectableAddress
    {
        [IsSearchable]
        public string City { get; set; }

        [IsFilterable, IsFacetable]
        public string Country { get; set; }
    }

    public class ReflectableComplexObject
    {
        [IsSearchable]
        [Analyzer("en.microsoft")]
        public string Name { get; set; }

        [IsFilterable]
        public int Rating { get; set; }

        // Ensure that leaf-field-specific attributes are ignored by FieldBuilder on complex fields.
        [IsSearchable]
        [IsFilterable]
        [IsSortable]
        [IsFacetable]
        [IsRetrievable(false)]
        [Analyzer("zh-Hant.lucene")]
        [IndexAnalyzer("zh-Hant.lucene")]
        [SearchAnalyzer("zh-Hant.lucene")]
        [SynonymMaps("myMap")]
        public ReflectableAddress Address { get; set; }
    }

    public class ReflectableModel
    {
        [KeyField]
        public int Id { get; set; }

        public long BigNumber { get; set; }

        public double Double { get; set; }

        public bool Flag { get; set; }

        public DateTimeOffset Time { get; set; }

        public DateTime TimeWithoutOffset { get; set; }

        [IsSearchable]
        [SynonymMaps("myMap")]
        public string Text { get; set; }

        public string UnsearchableText { get; set; }

        [IsSearchable]
        public string MoreText { get; set; }

        [IsFilterable]
        public string FilterableText { get; set; }

        [IsSortable]
        public string SortableText { get; set; }

        [IsFacetable]
        public string FacetableText { get; set; }

        [IsRetrievable(false)]
        public string IrretrievableText { get; set; }

        [IsRetrievable(true)]
        public string ExplicitlyRetrievableText { get; set; }

        [Analyzer("en.microsoft")]
        public string TextWithAnalyzer { get; set; }

        [SearchAnalyzer("es.lucene")]
        public string TextWithSearchAnalyzer { get; set; }

        [IndexAnalyzer("whitespace")]
        public string TextWithIndexAnalyzer { get; set; }

        public string[] StringArray { get; set; }

        public IList<string> StringIList { get; set; }

        public List<string> StringList { get; set; }

        public IEnumerable<string> StringIEnumerable { get; set; }

        public ICollection<string> StringICollection { get; set; }

        public int? NullableInt { get; set; }

#if EXPERIMENTAL_SPATIAL
        public PointGeometry GeographyPoint { get; set; }
#else
        public GeographyPoint GeographyPoint { get; set; }
#endif

        public int[] IntArray { get; set; }

        public IList<int> IntIList { get; set; }

        public List<int> IntList { get; set; }

        public IEnumerable<int> IntIEnumerable { get; set; }

        public ICollection<int> IntICollection { get; set; }

        public long[] LongArray { get; set; }

        public IList<long> LongIList { get; set; }

        public List<long> LongList { get; set; }

        public IEnumerable<long> LongIEnumerable { get; set; }

        public ICollection<long> LongICollection { get; set; }

        public double[] DoubleArray { get; set; }

        public IList<double> DoubleIList { get; set; }

        public List<double> DoubleList { get; set; }

        public IEnumerable<double> DoubleIEnumerable { get; set; }

        public ICollection<double> DoubleICollection { get; set; }

        public bool[] BoolArray { get; set; }

        public IList<bool> BoolIList { get; set; }

        public List<bool> BoolList { get; set; }

        public IEnumerable<bool> BoolIEnumerable { get; set; }

        public ICollection<bool> BoolICollection { get; set; }

        public DateTime[] DateTimeArray { get; set; }

        public IList<DateTime> DateTimeIList { get; set; }

        public List<DateTime> DateTimeList { get; set; }

        public IEnumerable<DateTime> DateTimeIEnumerable { get; set; }

        public ICollection<DateTime> DateTimeICollection { get; set; }

        public DateTimeOffset[] DateTimeOffsetArray { get; set; }

        public IList<DateTimeOffset> DateTimeOffsetIList { get; set; }

        public List<DateTimeOffset> DateTimeOffsetList { get; set; }

        public IEnumerable<DateTimeOffset> DateTimeOffsetIEnumerable { get; set; }

        public ICollection<DateTimeOffset> DateTimeOffsetICollection { get; set; }

#if EXPERIMENTAL_SPATIAL
        public PointGeometry[] GeographyPointArray { get; set; }

        public IList<PointGeometry> GeographyPointIList { get; set; }

        public List<PointGeometry> GeographyPointList { get; set; }

        public IEnumerable<PointGeometry> GeographyPointIEnumerable { get; set; }

        public ICollection<PointGeometry> GeographyPointICollection { get; set; }
#else
        public GeographyPoint[] GeographyPointArray { get; set; }

        public IList<GeographyPoint> GeographyPointIList { get; set; }

        public List<GeographyPoint> GeographyPointList { get; set; }

        public IEnumerable<GeographyPoint> GeographyPointIEnumerable { get; set; }

        public ICollection<GeographyPoint> GeographyPointICollection { get; set; }
#endif

        public ReflectableComplexObject Complex { get; set; }

        public ReflectableComplexObject[] ComplexArray { get; set; }

        public IList<ReflectableComplexObject> ComplexIList { get; set; }

        public List<ReflectableComplexObject> ComplexList { get; set; }

        public IEnumerable<ReflectableComplexObject> ComplexIEnumerable { get; set; }

        public ICollection<ReflectableComplexObject> ComplexICollection { get; set; }

        [JsonIgnore]
        [IsRetrievable(false)]
#pragma warning disable IDE1006 // Naming Styles
        public RecordEnum recordEnum { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }

    public enum RecordEnum
    {
        Test1,
        Test2
    }
}
