// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
#if !EXPERIMENTAL_FIELDBUILDER
using Azure.Search.Documents.Samples;
#endif
#if EXPERIMENTAL_SPATIAL
using Azure.Core.Spatial;
#else
using Microsoft.Spatial;
#endif
using KeyFieldAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

// TODO: Remove when https://github.com/Azure/azure-sdk-for-net/issues/11166 is completed.
namespace Azure.Search.Documents.Tests
{
    public class ReflectableAddress
    {
#if EXPERIMENTAL_FIELDBUILDER
        [SearchableField]
#else
        [IsSearchable]
#endif
        public string City { get; set; }

#if EXPERIMENTAL_FIELDBUILDER
        [SimpleField(IsFilterable = true, IsFacetable = true)]
#else
        [IsFilterable, IsFacetable]
#endif
        public string Country { get; set; }
    }

    public class ReflectableComplexObject
    {
#if EXPERIMENTAL_FIELDBUILDER
        [SearchableField(AnalyzerName = LexicalAnalyzerName.Values.EnMicrosoft)]
#else
        [IsSearchable]
        [Analyzer("en.microsoft")]
#endif
        public string Name { get; set; }

#if EXPERIMENTAL_FIELDBUILDER
        [SimpleField(IsFilterable = true)]
#else
        [IsFilterable]
#endif
        public int Rating { get; set; }

        // Ensure that leaf-field-specific attributes are ignored by FieldBuilder on complex fields.
#if EXPERIMENTAL_FIELDBUILDER
        [SearchableField(
            IsFilterable = true,
            IsSortable = true,
            IsFacetable = true,
            IsHidden = true,
            AnalyzerName = LexicalAnalyzerName.Values.ZhHantLucene,
            SearchAnalyzerName = LexicalAnalyzerName.Values.ZhHantLucene,
            IndexAnalyzerName = LexicalAnalyzerName.Values.ZhHantLucene,
            SynonymMapNames = new[] { "myMap" })]
#else
        [IsSearchable]
        [IsFilterable]
        [IsSortable]
        [IsFacetable]
        [IsRetrievable(false)]
        [Analyzer("zh-Hant.lucene")]
        [IndexAnalyzer("zh-Hant.lucene")]
        [SearchAnalyzer("zh-Hant.lucene")]
        [SynonymMaps("myMap")]
#endif
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

#if EXPERIMENTAL_FIELDBUILDER
        [SearchableField(SynonymMapNames = new[] { "myMap" })]
#else
        [IsSearchable]
        [SynonymMaps("myMap")]
#endif
        public string Text { get; set; }

        public string UnsearchableText { get; set; }

#if EXPERIMENTAL_FIELDBUILDER
        [SearchableField]
#else
        [IsSearchable]
#endif
        public string MoreText { get; set; }

#if EXPERIMENTAL_FIELDBUILDER
        [SimpleField(IsFilterable = true)]
#else
        [IsFilterable]
#endif
        public string FilterableText { get; set; }

#if EXPERIMENTAL_FIELDBUILDER
        [SimpleField(IsSortable = true)]
#else
        [IsSortable]
#endif
        public string SortableText { get; set; }

#if EXPERIMENTAL_FIELDBUILDER
        [SimpleField(IsFacetable = true)]
#else
        [IsFacetable]
#endif
        public string FacetableText { get; set; }

#if EXPERIMENTAL_FIELDBUILDER
        [SimpleField(IsHidden = true)]
#else
        [IsRetrievable(false)]
#endif
        public string IrretrievableText { get; set; }

#if EXPERIMENTAL_FIELDBUILDER
        [SimpleField(IsHidden = false)]
#else
        [IsRetrievable(true)]
#endif
        public string ExplicitlyRetrievableText { get; set; }

#if EXPERIMENTAL_FIELDBUILDER
        [SearchableField(AnalyzerName = LexicalAnalyzerName.Values.EnMicrosoft)]
#else
        [IsSearchable]
        [Analyzer("en.microsoft")]
#endif
        public string TextWithAnalyzer { get; set; }

#if EXPERIMENTAL_FIELDBUILDER
        [SearchableField(SearchAnalyzerName = LexicalAnalyzerName.Values.EsLucene)]
#else
        [IsSearchable]
        [SearchAnalyzer("es.lucene")]
#endif
        public string TextWithSearchAnalyzer { get; set; }

#if EXPERIMENTAL_FIELDBUILDER
        [SearchableField(IndexAnalyzerName = LexicalAnalyzerName.Values.Whitespace)]
#else
        [IsSearchable]
        [IndexAnalyzer("whitespace")]
#endif
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
#if EXPERIMENTAL_FIELDBUILDER
        [SimpleField(IsHidden = true)]
#else
        [IsRetrievable(false)]
#endif
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
