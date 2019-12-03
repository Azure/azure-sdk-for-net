// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.Azure.Search;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Spatial;
    using Newtonsoft.Json;

    public struct ReflectableAddressStruct
    {
        [IsSearchable]
        public string City { get; set; }

        [IsFilterable, IsFacetable]
        public string Country { get; set; }
    }

    public struct ReflectableComplexStruct
    {
        [IsSearchable]
        [Analyzer(AnalyzerName.AsString.EnMicrosoft)]
        public string Name { get; set; }

        [IsFilterable]
        public int Rating { get; set; }

        // Ensure that leaf-field-specific attributes are ignored by FieldBuilder on complex fields.
        [IsSearchable]
        [IsFilterable]
        [IsSortable]
        [IsFacetable]
        [IsRetrievable(false)]
        [Analyzer(AnalyzerName.AsString.ZhHantLucene)]
        [IndexAnalyzer(AnalyzerName.AsString.ZhHantLucene)]
        [SearchAnalyzer(AnalyzerName.AsString.ZhHantLucene)]
        [SynonymMaps("myMap")]
        public ReflectableAddressStruct Address { get; set; }
    }

    public struct ReflectableStructModel
    {
        [Key]
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

        [Analyzer(AnalyzerName.AsString.EnMicrosoft)]
        public string TextWithAnalyzer { get; set; }

        [SearchAnalyzer(AnalyzerName.AsString.EsLucene)]
        public string TextWithSearchAnalyzer { get; set; }

        [IndexAnalyzer(AnalyzerName.AsString.Whitespace)]
        public string TextWithIndexAnalyzer { get; set; }

        public string[] StringArray { get; set; }

        public IList<string> StringIList { get; set; }

        public List<string> StringList { get; set; }

        public IEnumerable<string> StringIEnumerable { get; set; }

        public ICollection<string> StringICollection { get; set; }

        public int? NullableInt { get; set; }

        public GeographyPoint GeographyPoint { get; set; }

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

        public GeographyPoint[] GeographyPointArray { get; set; }

        public IList<GeographyPoint> GeographyPointIList { get; set; }

        public List<GeographyPoint> GeographyPointList { get; set; }

        public IEnumerable<GeographyPoint> GeographyPointIEnumerable { get; set; }

        public ICollection<GeographyPoint> GeographyPointICollection { get; set; }

        public ReflectableComplexStruct? Complex { get; set; }

        public ReflectableComplexStruct[] ComplexArray { get; set; }

        public IList<ReflectableComplexStruct> ComplexIList { get; set; }

        public List<ReflectableComplexStruct> ComplexList { get; set; }

        public IEnumerable<ReflectableComplexStruct> ComplexIEnumerable { get; set; }

        public ICollection<ReflectableComplexStruct> ComplexICollection { get; set; }

        [JsonIgnore]
        [IsRetrievable(false)]
#pragma warning disable IDE1006 // Naming Styles
        public RecordEnum recordEnum { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
