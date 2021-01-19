// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Xunit;
using KeyFieldAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using Index = Microsoft.Azure.Search.Models.Index;

namespace Microsoft.Azure.Search.Tests
{
    public class FieldBuilderTests : SearchTestBase<IndexFixture>
    {
        private static IEnumerable<Type> TestModelTypes
        {
            get
            {
                // MAINTENANCE NOTE: These two types and the types of their properties must be identical,
                // other than that one is a group of classes and one is a group of structs.
                yield return typeof(ReflectableModel);
                yield return typeof(ReflectableStructModel);
            }
        }

        public static TheoryData<bool, Type> TestModelTypeTestData =>
            new TheoryData<bool, Type>()
            .PopulateFrom(
                from useCustomResolver in new[] { true, false }
                from type in TestModelTypes
                select (useCustomResolver, type));

        public static TheoryData<bool, Type, DataType, string> PrimitiveTypeTestData
        {
            get
            {
                (DataType dataType, string fieldName)[] primitiveSubFieldTestData = new[]
                {
                    (DataType.String, nameof(ReflectableComplexObject.Name)),
                    (DataType.Int32, nameof(ReflectableComplexObject.Rating)),
                    (DataType.String, nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City)),
                    (DataType.String, nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country))
                };

                var complexFields = new[]
                {
                    nameof(ReflectableModel.Complex),
                    nameof(ReflectableModel.ComplexArray),
                    nameof(ReflectableModel.ComplexIList),
                    nameof(ReflectableModel.ComplexList),
                    nameof(ReflectableModel.ComplexIEnumerable),
                    nameof(ReflectableModel.ComplexICollection)
                };

                var allSubFieldTestData =
                    from topLevelFieldName in complexFields
                    from typeAndField in primitiveSubFieldTestData
                    select (typeAndField.dataType, topLevelFieldName + "/" + typeAndField.fieldName);

                (DataType, string)[] primitiveFieldTestData = new[]
                {
                    (DataType.String, nameof(ReflectableModel.Text)),
                    (DataType.Int32, nameof(ReflectableModel.Id)),
                    (DataType.Int64, nameof(ReflectableModel.BigNumber)),
                    (DataType.Double, nameof(ReflectableModel.Double)),
                    (DataType.Boolean, nameof(ReflectableModel.Flag)),
                    (DataType.DateTimeOffset, nameof(ReflectableModel.Time)),
                    (DataType.DateTimeOffset, nameof(ReflectableModel.TimeWithoutOffset)),
                    (DataType.GeographyPoint, nameof(ReflectableModel.GeographyPoint))
                };

                (DataType, string)[] primitivePropertyTestData =
                    primitiveFieldTestData.Concat(allSubFieldTestData).ToArray();

                return
                    new TheoryData<bool, Type, DataType, string>()
                    .PopulateFrom(CombineTestData(TestModelTypes, primitivePropertyTestData));
            }
        }

        public static TheoryData<bool, Type, DataType, string> CollectionTypeTestData
        {
            get
            {
                (DataType, string)[] collectionPropertyTestData = new[]
                {
                    (DataType.String, nameof(ReflectableModel.StringArray)),
                    (DataType.String, nameof(ReflectableModel.StringIList)),
                    (DataType.String, nameof(ReflectableModel.StringIEnumerable)),
                    (DataType.String, nameof(ReflectableModel.StringList)),
                    (DataType.String, nameof(ReflectableModel.StringICollection)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.IntArray)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.IntIList)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.IntIEnumerable)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.IntList)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.IntICollection)),
                    (DataType.AsString.Int64, nameof(ReflectableModel.LongArray)),
                    (DataType.AsString.Int64, nameof(ReflectableModel.LongIList)),
                    (DataType.AsString.Int64, nameof(ReflectableModel.LongIEnumerable)),
                    (DataType.AsString.Int64, nameof(ReflectableModel.LongList)),
                    (DataType.AsString.Int64, nameof(ReflectableModel.LongICollection)),
                    (DataType.AsString.Double, nameof(ReflectableModel.DoubleArray)),
                    (DataType.AsString.Double, nameof(ReflectableModel.DoubleIList)),
                    (DataType.AsString.Double, nameof(ReflectableModel.DoubleIEnumerable)),
                    (DataType.AsString.Double, nameof(ReflectableModel.DoubleList)),
                    (DataType.AsString.Double, nameof(ReflectableModel.DoubleICollection)),
                    (DataType.AsString.Boolean, nameof(ReflectableModel.BoolArray)),
                    (DataType.AsString.Boolean, nameof(ReflectableModel.BoolIList)),
                    (DataType.AsString.Boolean, nameof(ReflectableModel.BoolIEnumerable)),
                    (DataType.AsString.Boolean, nameof(ReflectableModel.BoolList)),
                    (DataType.AsString.Boolean, nameof(ReflectableModel.BoolICollection)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeArray)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeIList)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeIEnumerable)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeList)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeICollection)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetArray)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetIList)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetIEnumerable)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetList)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetICollection)),
                    (DataType.AsString.GeographyPoint, nameof(ReflectableModel.GeographyPointArray)),
                    (DataType.AsString.GeographyPoint, nameof(ReflectableModel.GeographyPointIList)),
                    (DataType.AsString.GeographyPoint, nameof(ReflectableModel.GeographyPointIEnumerable)),
                    (DataType.AsString.GeographyPoint, nameof(ReflectableModel.GeographyPointList)),
                    (DataType.AsString.GeographyPoint, nameof(ReflectableModel.GeographyPointICollection)),
                    (DataType.AsString.Complex, nameof(ReflectableModel.ComplexArray)),
                    (DataType.AsString.Complex, nameof(ReflectableModel.ComplexIList)),
                    (DataType.AsString.Complex, nameof(ReflectableModel.ComplexIEnumerable)),
                    (DataType.AsString.Complex, nameof(ReflectableModel.ComplexList)),
                    (DataType.AsString.Complex, nameof(ReflectableModel.ComplexICollection))
                };

                return
                    new TheoryData<bool, Type, DataType, string>()
                    .PopulateFrom(CombineTestData(TestModelTypes, collectionPropertyTestData));
            }
        }

        public static TheoryData<bool, Type, string> ComplexTypeTestData
        {
            get
            {
                var complexPropertyTestData = new[]
                {
                    nameof(ReflectableModel.Complex),
                    nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Address),
                    nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Address),
                    nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Address),
                    nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Address),
                    nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Address),
                    nameof(ReflectableModel.ComplexICollection) + "/" + nameof(ReflectableComplexObject.Address)
                };

                return new TheoryData<bool, Type, string>().PopulateFrom(
                    from useCustomResolver in new[] { true, false }
                    from type in TestModelTypes
                    from fieldPath in complexPropertyTestData
                    select (useCustomResolver, type, fieldPath));
            }
        }

        [Theory]
        [MemberData(nameof(PrimitiveTypeTestData))]
        public void ReportsPrimitiveTypedProperties(
            bool useCustomResolver,
            Type modelType,
            DataType expectedDataType,
            string fieldName)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            Assert.Equal(expectedDataType, fields[fieldName].Type);
        }

        [Theory]
        [MemberData(nameof(ComplexTypeTestData))]
        public void ReportsComplexTypedProperties(bool useCustomResolver, Type modelType, string fieldName)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            Assert.Equal(DataType.Complex, fields[fieldName].Type);
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void ReportsNullableInt32Properties(bool useCustomResolver, Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            Assert.Equal(DataType.Int32, fields[nameof(ReflectableModel.NullableInt)].Type);
        }

        [Theory]
        [MemberData(nameof(CollectionTypeTestData))]
        public void ReportsCollectionProperties(
            bool useCustomResolver,
            Type modelType,
            DataType expectedElementDataType,
            string fieldName)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            Assert.Equal(DataType.Collection(expectedElementDataType), fields[fieldName].Type);
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void ReportsKeyOnlyOnPropertyWithKeyAttribute(bool useCustomResolver, Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            fields.OnlyTrueFor(field => field.IsKey.GetValueOrDefault(false), nameof(ReflectableModel.Id));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void ReportsIsSearchableOnlyOnPropertiesWithIsSearchableAttribute(bool useCustomResolver, Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            fields.OnlyTrueFor(
                field => field.IsSearchable.GetValueOrDefault(false),
                nameof(ReflectableModel.Text),
                nameof(ReflectableModel.MoreText),
                nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City),
                nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City),
                nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City),
                nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City),
                nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City),
                nameof(ReflectableModel.ComplexICollection) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexICollection) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void IsFilterableOnlyOnPropertiesWithIsFilterableAttribute(bool useCustomResolver, Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            fields.OnlyTrueFor(
                field => field.IsFilterable.GetValueOrDefault(false),
                nameof(ReflectableModel.FilterableText),
                nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Rating),
                nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Rating),
                nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Rating),
                nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Rating),
                nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Rating),
                nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexICollection) + "/" + nameof(ReflectableComplexObject.Rating),
                nameof(ReflectableModel.ComplexICollection) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void IsSortableOnlyOnPropertiesWithIsSortableAttribute(bool useCustomResolver, Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            fields.OnlyTrueFor(field => field.IsSortable.GetValueOrDefault(false), nameof(ReflectableModel.SortableText));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void IsFacetableOnlyOnPropertiesWithIsFacetableAttribute(bool useCustomResolver, Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            fields.OnlyTrueFor(
                field => field.IsFacetable.GetValueOrDefault(false),
                nameof(ReflectableModel.FacetableText),
                nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexICollection) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void IsRetrievableOnAllPropertiesExceptOnesWithIsRetrievableAttributeSetToFalse(
            bool useCustomResolver,
            Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            fields.OnlyFalseFor(
                field => field.IsRetrievable.GetValueOrDefault(true),
                nameof(ReflectableModel.IrretrievableText));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void AnalyzerSetOnlyOnPropertiesWithAnalyzerAttribute(bool useCustomResolver, Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            fields.OnlyTrueFor(
                field => field.Analyzer == AnalyzerName.EnMicrosoft,
                nameof(ReflectableModel.TextWithAnalyzer),
                nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexICollection) + "/" + nameof(ReflectableComplexObject.Name));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void SearchAnalyzerSetOnlyOnPropertiesWithSearchAnalyzerAttribute(bool useCustomResolver, Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            fields.OnlyTrueFor(
                field => field.SearchAnalyzer == AnalyzerName.EsLucene,
                nameof(ReflectableModel.TextWithSearchAnalyzer));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void IndexAnalyzerSetOnlyOnPropertiesWithIndexAnalyzerAttribute(bool useCustomResolver, Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            fields.OnlyTrueFor(
                field => field.IndexAnalyzer == AnalyzerName.Whitespace,
                nameof(ReflectableModel.TextWithIndexAnalyzer));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void SynonymMapsSetOnlyOnPropertiesWithSynonymMapsAttribute(bool useCustomResolver, Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType, useCustomResolver));
            fields.OnlyTrueFor(field => field.SynonymMaps?.Contains("myMap") ?? false, nameof(ReflectableModel.Text));
        }

        [Theory]
        [InlineData(typeof(ReflectableCamelCaseModel))]
        [InlineData(typeof(ReflectableStructCamelCaseModel))]
        public void HonoursSerializePropertyNamesAsCamelCaseAttribute(Type modelType)
        {
            var fieldMap = new FieldMap(BuildForType(modelType, useCustomResolver: false));

            Assert.True(fieldMap.ContainsKey("id"));
            Assert.True(fieldMap.ContainsKey("myProperty"));
            Assert.True(fieldMap.ContainsKey("inner"));
            Assert.True(fieldMap.ContainsKey("inner/name"));
            Assert.True(fieldMap.ContainsKey("innerCollection"));
            Assert.True(fieldMap.ContainsKey("innerCollection/name"));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RecursivePropertiesAreIgnored(bool useCustomResolver)
        {
            var fieldMap = new FieldMap(BuildForType(typeof(RecursiveModel), useCustomResolver));

            Assert.True(fieldMap.ContainsKey(nameof(RecursiveModel.Data)));
            Assert.True(fieldMap.ContainsKey(nameof(RecursiveModel.Next)));
            Assert.True(fieldMap.ContainsKey(nameof(RecursiveModel.Next) + "/" + nameof(OtherRecursiveModel.Data)));
            Assert.False(fieldMap.ContainsKey(nameof(RecursiveModel.Next) + "/" + nameof(OtherRecursiveModel.RecursiveReference)));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NestedKeyAttributesAreIgnored(bool useCustomResolver)
        {
            var expectedFields = new[]
            {
                Field.New(nameof(ModelWithNestedKey.ID), DataType.String, isKey: true),
                Field.NewComplex(nameof(ModelWithNestedKey.Inner), isCollection: false, fields: new[]
                {
                    Field.New(nameof(InnerModelWithKey.InnerID), DataType.String, isKey: false),
                    Field.New(nameof(InnerModelWithKey.OtherField), DataType.Int32, isFilterable: true)
                })
            };

            IList<Field> actualFields = BuildForType(typeof(ModelWithNestedKey), useCustomResolver);

            Assert.Equal(expectedFields, actualFields, new DataPlaneModelComparer<Field>());
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PropertiesMarkedAsIgnoredAreIgnored(bool useCustomResolver)
        {
            var expectedFields = new[]
            {
                Field.New(nameof(ModelWithIgnoredProperties.ID), DataType.String, isKey: true),
                Field.NewComplex(nameof(ModelWithIgnoredProperties.Inner), isCollection: true, fields: new[]
                {
                    Field.New(nameof(InnerModelWithIgnoredProperties.OtherField), DataType.Int32, isFilterable: true)
                })
            };

            IList<Field> actualFields = BuildForType(typeof(ModelWithIgnoredProperties), useCustomResolver);

            Assert.Equal(expectedFields, actualFields, new DataPlaneModelComparer<Field>());
        }

        [Theory]
        [InlineData(typeof(ModelWithEnum), nameof(ModelWithEnum.Direction))]
        [InlineData(typeof(ModelWithUnsupportedPrimitiveType), nameof(ModelWithUnsupportedPrimitiveType.Price))]
        [InlineData(typeof(ModelWithUnsupportedEnumerableType), nameof(ModelWithUnsupportedEnumerableType.Buffer))]
        [InlineData(typeof(ModelWithUnsupportedCollectionType), nameof(ModelWithUnsupportedCollectionType.Buffer))]
        public void FieldBuilderFailsWithHelpfulErrorMessageOnUnsupportedPropertyTypes(Type modelType, string invalidPropertyName)
        {
            var e = Assert.Throws<ArgumentException>(() => FieldBuilder.BuildForType(modelType));

            string expectedErrorMessage =
                $"Property '{invalidPropertyName}' is of type '{modelType.GetProperty(invalidPropertyName).PropertyType}', " +
                "which does not map to an Azure Search data type. Please use a supported data type or mark the property with " +
                "[JsonIgnore] or [FieldBuilderIgnore] and define the field by creating a Field object.";

            Assert.Equal(nameof(modelType), e.ParamName);
            Assert.StartsWith(expectedErrorMessage, e.Message);
        }

        [Theory]
        [InlineData(typeof(int))]
        [InlineData(typeof(string))]
        [InlineData(typeof(DateTimeOffset))]
        [InlineData(typeof(Direction))]
        [InlineData(typeof(object))]
        [InlineData(typeof(int[]))]
        [InlineData(typeof(IEnumerable<ReflectableModel>))]
        [InlineData(typeof(IList<ReflectableStructModel>))]
        [InlineData(typeof(List<string>))]
        [InlineData(typeof(ICollection<decimal>))]
        public void FieldBuilderFailsWithHelpfulErrorMessageOnUnsupportedTypes(Type modelType)
        {
            var e = Assert.Throws<ArgumentException>(() => FieldBuilder.BuildForType(modelType));

            string expectedErrorMessage =
                $"Type '{modelType}' does not have properties which map to fields of an Azure Search index. Please use a " +
                $"class or struct with public properties.";

            Assert.Equal(nameof(modelType), e.ParamName);
            Assert.StartsWith(expectedErrorMessage, e.Message);
        }

        [Fact]
        public void FieldBuilderCreatesIndexEquivalentToManuallyDefinedIndex()
        {
            Run(() =>
            {
                SearchServiceClient serviceClient = Data.GetSearchServiceClient();
                Index expectedIndex = serviceClient.Indexes.Get(Data.IndexName);

                string otherIndexName = SearchTestUtilities.GenerateName();
                var actualIndex = new Index()
                {
                    Name = otherIndexName,
                    Fields = FieldBuilder.BuildForType<Hotel>()
                };

                // Round-trip the auto-built index definition before comparing.
                serviceClient.Indexes.Create(actualIndex);
                actualIndex = serviceClient.Indexes.Get(otherIndexName);

                Assert.Equal(expectedIndex.Fields, actualIndex.Fields, new DataPlaneModelComparer<IList<Field>>());
            });
        }

        private static IEnumerable<(bool, Type, DataType, string)> CombineTestData(
            IEnumerable<Type> modelTypes,
            IEnumerable<(DataType dataType, string fieldName)> testData) =>
            from useCustomResolver in new[] { true, false }
            from type in modelTypes
            from tuple in testData
            select (useCustomResolver, type, tuple.dataType, tuple.fieldName);

        private static IList<Field> BuildForType(Type modelType, bool useCustomResolver) =>
            useCustomResolver ?
                FieldBuilder.BuildForType(modelType, new ReadOnlyJsonContractResolver()) :
                FieldBuilder.BuildForType(modelType);

        private enum Direction
        {
            Up,
            Down
        }

        private class FieldMap
        {
            private readonly IReadOnlyDictionary<string, Field> _map;

            public FieldMap(IList<Field> fields)
            {
                IEnumerable<KeyValuePair<string, Field>> GetSelfAndDescendants(Field topLevelField)
                {
                    IEnumerable<KeyValuePair<string, Field>> GetSelfAndDescendantsRecursive(Field field, string parentFieldPath)
                    {
                        string currentFieldPath =
                            string.IsNullOrEmpty(parentFieldPath) ? field.Name : parentFieldPath + "/" + field.Name;

                        yield return new KeyValuePair<string, Field>(currentFieldPath, field);

                        foreach (Field subField in field.Fields ?? Enumerable.Empty<Field>())
                        {
                            foreach (var result in GetSelfAndDescendantsRecursive(subField, currentFieldPath))
                            {
                                yield return result;
                            }
                        }
                    }

                    return GetSelfAndDescendantsRecursive(topLevelField, string.Empty);
                }

                _map = fields.SelectMany(f => GetSelfAndDescendants(f)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }

            public Field this[string fieldName] => _map[fieldName];

            public bool ContainsKey(string fieldName) => _map.ContainsKey(fieldName);

            public void OnlyTrueFor(Func<Field, bool> check, params string[] expectedFieldNames)
            {
                foreach (string fieldNameFromModel in _map.Keys)
                {
                    Field field = _map[fieldNameFromModel];
                    bool result = check(field);

                    if (expectedFieldNames.Contains(fieldNameFromModel))
                    {
                        Assert.True(result, $"Expected true for field {fieldNameFromModel}.");
                    }
                    else
                    {
                        Assert.False(result, $"Expected false for field {fieldNameFromModel}.");
                    }
                }
            }

            public void OnlyFalseFor(Func<Field, bool> check, params string[] expectedFieldNames) =>
                OnlyTrueFor(f => !check(f), expectedFieldNames);
        }

        private class ModelWithEnum
        {
            [KeyField]
            public string ID { get; set; }

            [IsFilterable, IsSearchable, IsSortable, IsFacetable]
            public Direction Direction { get; set; }
        }

        private class ModelWithUnsupportedPrimitiveType
        {
            [KeyField]
            public string ID { get; set; }

            [IsFilterable]
            public decimal Price { get; set; }
        }

        private class ModelWithUnsupportedEnumerableType
        {
            [KeyField]
            public string ID { get; set; }

            [IsFilterable]
            public IEnumerable<byte> Buffer { get; set; }
        }

        private class ModelWithUnsupportedCollectionType
        {
            [KeyField]
            public string ID { get; set; }

            [IsFilterable]
            public ICollection<char> Buffer { get; set; }
        }

        private class InnerModelWithKey
        {
            [KeyField]
            public string InnerID { get; set; }

            [IsFilterable]
            public int OtherField { get; set; }
        }

        private class ModelWithNestedKey
        {
            [KeyField]
            public string ID { get; set; }

            public InnerModelWithKey Inner { get; set; }
        }

        private class InnerModelWithIgnoredProperties
        {
            [IsFilterable]
            public int OtherField { get; set; }

            [JsonIgnore]
            public string JsonIgnored { get; set; }

            [FieldBuilderIgnore]
            [JsonIgnore]
            public DateTimeOffset[] FieldBuilderIgnored { get; set; }
        }

        private class ModelWithIgnoredProperties
        {
            [KeyField]
            public string ID { get; set; }

            [JsonIgnore]
            public int[] JsonIgnored { get; set; }

            [FieldBuilderIgnore]
            public Direction FieldBuilderIgnored { get; set; }

            public InnerModelWithIgnoredProperties[] Inner { get; set; }
        }
    }
}
