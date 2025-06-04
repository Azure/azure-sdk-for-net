// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Azure.Core.GeoJson;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Microsoft.Spatial;
using KeyFieldAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

// TODO: Remove when https://github.com/Azure/azure-sdk-for-net/issues/11166 is completed.
namespace Azure.Search.Documents.Tests
{
    public struct ReflectableAddressStruct
    {
        [SearchableField]
        public string City { get; set; }

        [SimpleField(IsFilterable = true, IsFacetable = true)]
        public string Country { get; set; }
    }

    public struct ReflectableComplexStruct
    {
        [SearchableField(AnalyzerName = LexicalAnalyzerName.Values.EnMicrosoft)]
        public string Name { get; set; }

        [SimpleField(IsFilterable = true)]
        public int Rating { get; set; }

        // Ensure that leaf-field-specific attributes are ignored by FieldBuilder on complex fields.
        [SearchableField(
            IsFilterable = true,
            IsSortable = true,
            IsFacetable = true,
            IsHidden = true,
            AnalyzerName = LexicalAnalyzerName.Values.ZhHantLucene,
            SearchAnalyzerName = LexicalAnalyzerName.Values.ZhHantLucene,
            IndexAnalyzerName = LexicalAnalyzerName.Values.ZhHantLucene,
            SynonymMapNames = new[] { "myMap" })]
        public ReflectableAddressStruct Address { get; set; }
    }

    public struct ReflectableStructModel
    {
        [KeyField]
        public int Id { get; set; }

        public long BigNumber { get; set; }

        public double Double { get; set; }

        public sbyte SByte { get; set; }

        public byte Byte { get; set; }

        public short Short { get; set; }

        public bool Flag { get; set; }

        public DateTimeOffset Time { get; set; }

        public DateTime TimeWithoutOffset { get; set; }

        [SearchableField(SynonymMapNames = new[] { "myMap" })]
        public string Text { get; set; }

        public string UnsearchableText { get; set; }

        [SearchableField]
        public string MoreText { get; set; }

        [SimpleField(IsFilterable = true)]
        public string FilterableText { get; set; }

        [SimpleField(IsSortable = true)]
        public string SortableText { get; set; }

        [SimpleField(IsFacetable = true)]
        public string FacetableText { get; set; }

        [SimpleField(IsHidden = true)]
        public string IrretrievableText { get; set; }

        [SimpleField(IsHidden = false)]
        public string ExplicitlyRetrievableText { get; set; }

        [SearchableField(AnalyzerName = LexicalAnalyzerName.Values.EnMicrosoft)]
        public string TextWithAnalyzer { get; set; }

        [SearchableField(SearchAnalyzerName = LexicalAnalyzerName.Values.EsLucene)]
        public string TextWithSearchAnalyzer { get; set; }

        [SearchableField(IndexAnalyzerName = LexicalAnalyzerName.Values.Whitespace)]
        public string TextWithIndexAnalyzer { get; set; }

        public string[] StringArray { get; set; }

        public IList<string> StringIList { get; set; }

        public List<string> StringList { get; set; }

        public IEnumerable<string> StringIEnumerable { get; set; }

        public ICollection<string> StringICollection { get; set; }

        public int? NullableInt { get; set; }

        public GeoPoint GeoPoint { get; set; }

        public GeographyPoint GeographyPoint { get; set; }

        public sbyte[] SByteArray { get; set; }

        public IList<sbyte> SByteIList { get; set; }

        public List<sbyte> SByteList { get; set; }

        public IEnumerable<sbyte> SByteIEnumerable { get; set; }

        public ICollection<sbyte> SByteICollection { get; set; }

        public byte[] ByteArray { get; set; }

        public IList<byte> ByteIList { get; set; }

        public List<byte> ByteList { get; set; }

        public IEnumerable<byte> ByteIEnumerable { get; set; }

        public ICollection<byte> ByteICollection { get; set; }

        public short[] ShortArray { get; set; }

        public IList<short> ShortIList { get; set; }

        public List<short> ShortList { get; set; }

        public IEnumerable<short> ShortIEnumerable { get; set; }

        public ICollection<short> ShortICollection { get; set; }

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

        public GeoPoint[] GeoPointArray { get; set; }

        public IList<GeoPoint> GeoPointIList { get; set; }

        public List<GeoPoint> GeoPointList { get; set; }

        public IEnumerable<GeoPoint> GeoPointIEnumerable { get; set; }

        public ICollection<GeoPoint> GeoPointICollection { get; set; }

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
        [SimpleField(IsHidden = true)]
#pragma warning disable IDE1006 // Naming Styles
        public RecordEnum recordEnum { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
