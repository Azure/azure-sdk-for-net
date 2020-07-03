// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Tests;
using NUnit.Framework;
using KeyFieldAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Azure.Search.Documents.Samples.Tests
{
    public class FieldBuilderTests
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

        public static IEnumerable<TestCaseData> TestModelTypeTestData =>
            from type in TestModelTypes
            select new TestCaseData(type);

        public static IEnumerable<TestCaseData> PrimitiveTypeTestData
        {
            get
            {
                (SearchFieldDataType dataType, string fieldName)[] primitiveSubFieldTestData = new[]
                {
                    (SearchFieldDataType.String, nameof(ReflectableComplexObject.Name)),
                    (SearchFieldDataType.Int32, nameof(ReflectableComplexObject.Rating)),
                    (SearchFieldDataType.String, nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City)),
                    (SearchFieldDataType.String, nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country))
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

                IEnumerable<(SearchFieldDataType dataType, string)> allSubFieldTestData =
                    from topLevelFieldName in complexFields
                    from typeAndField in primitiveSubFieldTestData
                    select (typeAndField.dataType, topLevelFieldName + "/" + typeAndField.fieldName);

                (SearchFieldDataType, string)[] primitiveFieldTestData = new[]
                {
                    (SearchFieldDataType.String, nameof(ReflectableModel.Text)),
                    (SearchFieldDataType.Int32, nameof(ReflectableModel.Id)),
                    (SearchFieldDataType.Int64, nameof(ReflectableModel.BigNumber)),
                    (SearchFieldDataType.Double, nameof(ReflectableModel.Double)),
                    (SearchFieldDataType.Boolean, nameof(ReflectableModel.Flag)),
                    (SearchFieldDataType.DateTimeOffset, nameof(ReflectableModel.Time)),
                    (SearchFieldDataType.DateTimeOffset, nameof(ReflectableModel.TimeWithoutOffset)),
                    (SearchFieldDataType.GeographyPoint, nameof(ReflectableModel.GeographyPoint))
                };

                (SearchFieldDataType, string)[] primitivePropertyTestData =
                    primitiveFieldTestData.Concat(allSubFieldTestData).ToArray();

                foreach ((Type type, SearchFieldDataType dataType, string fieldName) in CombineTestData(TestModelTypes, primitiveFieldTestData))
                {
                    yield return new TestCaseData(type, dataType, fieldName);
                }
            }
        }

        public static IEnumerable<TestCaseData> CollectionTypeTestData
        {
            get
            {
                (SearchFieldDataType, string)[] collectionPropertyTestData = new[]
                {
                    (SearchFieldDataType.String, nameof(ReflectableModel.StringArray)),
                    (SearchFieldDataType.String, nameof(ReflectableModel.StringIList)),
                    (SearchFieldDataType.String, nameof(ReflectableModel.StringIEnumerable)),
                    (SearchFieldDataType.String, nameof(ReflectableModel.StringList)),
                    (SearchFieldDataType.String, nameof(ReflectableModel.StringICollection)),
                    (SearchFieldDataType.Int32, nameof(ReflectableModel.IntArray)),
                    (SearchFieldDataType.Int32, nameof(ReflectableModel.IntIList)),
                    (SearchFieldDataType.Int32, nameof(ReflectableModel.IntIEnumerable)),
                    (SearchFieldDataType.Int32, nameof(ReflectableModel.IntList)),
                    (SearchFieldDataType.Int32, nameof(ReflectableModel.IntICollection)),
                    (SearchFieldDataType.Int64, nameof(ReflectableModel.LongArray)),
                    (SearchFieldDataType.Int64, nameof(ReflectableModel.LongIList)),
                    (SearchFieldDataType.Int64, nameof(ReflectableModel.LongIEnumerable)),
                    (SearchFieldDataType.Int64, nameof(ReflectableModel.LongList)),
                    (SearchFieldDataType.Int64, nameof(ReflectableModel.LongICollection)),
                    (SearchFieldDataType.Double, nameof(ReflectableModel.DoubleArray)),
                    (SearchFieldDataType.Double, nameof(ReflectableModel.DoubleIList)),
                    (SearchFieldDataType.Double, nameof(ReflectableModel.DoubleIEnumerable)),
                    (SearchFieldDataType.Double, nameof(ReflectableModel.DoubleList)),
                    (SearchFieldDataType.Double, nameof(ReflectableModel.DoubleICollection)),
                    (SearchFieldDataType.Boolean, nameof(ReflectableModel.BoolArray)),
                    (SearchFieldDataType.Boolean, nameof(ReflectableModel.BoolIList)),
                    (SearchFieldDataType.Boolean, nameof(ReflectableModel.BoolIEnumerable)),
                    (SearchFieldDataType.Boolean, nameof(ReflectableModel.BoolList)),
                    (SearchFieldDataType.Boolean, nameof(ReflectableModel.BoolICollection)),
                    (SearchFieldDataType.DateTimeOffset, nameof(ReflectableModel.DateTimeArray)),
                    (SearchFieldDataType.DateTimeOffset, nameof(ReflectableModel.DateTimeIList)),
                    (SearchFieldDataType.DateTimeOffset, nameof(ReflectableModel.DateTimeIEnumerable)),
                    (SearchFieldDataType.DateTimeOffset, nameof(ReflectableModel.DateTimeList)),
                    (SearchFieldDataType.DateTimeOffset, nameof(ReflectableModel.DateTimeICollection)),
                    (SearchFieldDataType.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetArray)),
                    (SearchFieldDataType.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetIList)),
                    (SearchFieldDataType.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetIEnumerable)),
                    (SearchFieldDataType.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetList)),
                    (SearchFieldDataType.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetICollection)),
                    (SearchFieldDataType.GeographyPoint, nameof(ReflectableModel.GeographyPointArray)),
                    (SearchFieldDataType.GeographyPoint, nameof(ReflectableModel.GeographyPointIList)),
                    (SearchFieldDataType.GeographyPoint, nameof(ReflectableModel.GeographyPointIEnumerable)),
                    (SearchFieldDataType.GeographyPoint, nameof(ReflectableModel.GeographyPointList)),
                    (SearchFieldDataType.GeographyPoint, nameof(ReflectableModel.GeographyPointICollection)),
                    (SearchFieldDataType.Complex, nameof(ReflectableModel.ComplexArray)),
                    (SearchFieldDataType.Complex, nameof(ReflectableModel.ComplexIList)),
                    (SearchFieldDataType.Complex, nameof(ReflectableModel.ComplexIEnumerable)),
                    (SearchFieldDataType.Complex, nameof(ReflectableModel.ComplexList)),
                    (SearchFieldDataType.Complex, nameof(ReflectableModel.ComplexICollection))
                };

                foreach ((Type type, SearchFieldDataType dataType, string fieldName) in CombineTestData(TestModelTypes, collectionPropertyTestData))
                {
                    yield return new TestCaseData(type, dataType, fieldName);
                }
            }
        }

        public static IEnumerable<TestCaseData> ComplexTypeTestData
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

                return from type in TestModelTypes
                       from fieldPath in complexPropertyTestData
                       select new TestCaseData(type, fieldPath);
            }
        }

        [TestCaseSource(nameof(PrimitiveTypeTestData))]
        public void ReportsPrimitiveTypedProperties(
            Type modelType,
            SearchFieldDataType expectedDataType,
            string fieldName)
        {
            var fields = new FieldMap(BuildForType(modelType));
            Assert.AreEqual(expectedDataType, fields[fieldName].Type);
        }

        [TestCaseSource(nameof(ComplexTypeTestData))]
        public void ReportsComplexTypedProperties(Type modelType, string fieldName)
        {
            var fields = new FieldMap(BuildForType(modelType));
            Assert.AreEqual(SearchFieldDataType.Complex, fields[fieldName].Type);
        }

        [TestCaseSource(nameof(TestModelTypeTestData))]
        public void ReportsNullableInt32Properties(Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType));
            Assert.AreEqual(SearchFieldDataType.Int32, fields[nameof(ReflectableModel.NullableInt)].Type);
        }

        [TestCaseSource(nameof(CollectionTypeTestData))]
        public void ReportsCollectionProperties(
            Type modelType,
            SearchFieldDataType expectedElementDataType,
            string fieldName)
        {
            var fields = new FieldMap(BuildForType(modelType));
            Assert.AreEqual(SearchFieldDataType.Collection(expectedElementDataType), fields[fieldName].Type);
        }

        [TestCaseSource(nameof(TestModelTypeTestData))]
        public void ReportsKeyOnlyOnPropertyWithKeyAttribute(Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType));
            fields.OnlyTrueFor(field => field.IsKey.GetValueOrDefault(false), nameof(ReflectableModel.Id));
        }

        [TestCaseSource(nameof(TestModelTypeTestData))]
        public void ReportsIsSearchableOnlyOnPropertiesWithIsSearchableAttribute(Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType));
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

        [TestCaseSource(nameof(TestModelTypeTestData))]
        public void IsFilterableOnlyOnPropertiesWithIsFilterableAttribute(Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType));
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

        [TestCaseSource(nameof(TestModelTypeTestData))]
        public void IsSortableOnlyOnPropertiesWithIsSortableAttribute(Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType));
            fields.OnlyTrueFor(field => field.IsSortable.GetValueOrDefault(false), nameof(ReflectableModel.SortableText));
        }

        [TestCaseSource(nameof(TestModelTypeTestData))]
        public void IsFacetableOnlyOnPropertiesWithIsFacetableAttribute(Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType));
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

        [TestCaseSource(nameof(TestModelTypeTestData))]
        public void NotIsHiddenOnAllPropertiesExceptOnesWithIsRetrievableAttributeSetToFalse(
            Type modelType)
        {
            // Was IsRetrievableOnAllPropertiesExceptOnesWithIsRetrievableAttributeSetToFalse
            var fields = new FieldMap(BuildForType(modelType));
            fields.OnlyTrueFor(
                field => field.IsHidden.GetValueOrDefault(false),
                nameof(ReflectableModel.IrretrievableText));
        }

        [TestCaseSource(nameof(TestModelTypeTestData))]
        public void AnalyzerSetOnlyOnPropertiesWithAnalyzerAttribute(Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType));
            fields.OnlyTrueFor(
                field => field.AnalyzerName == LexicalAnalyzerName.EnMicrosoft,
                nameof(ReflectableModel.TextWithAnalyzer),
                nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexICollection) + "/" + nameof(ReflectableComplexObject.Name));
        }

        [TestCaseSource(nameof(TestModelTypeTestData))]
        public void SearchAnalyzerSetOnlyOnPropertiesWithSearchAnalyzerAttribute(Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType));
            fields.OnlyTrueFor(
                field => field.SearchAnalyzerName == LexicalAnalyzerName.EsLucene,
                nameof(ReflectableModel.TextWithSearchAnalyzer));
        }

        [TestCaseSource(nameof(TestModelTypeTestData))]
        public void IndexAnalyzerSetOnlyOnPropertiesWithIndexAnalyzerAttribute(Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType));
            fields.OnlyTrueFor(
                field => field.IndexAnalyzerName == LexicalAnalyzerName.Whitespace,
                nameof(ReflectableModel.TextWithIndexAnalyzer));
        }

        [TestCaseSource(nameof(TestModelTypeTestData))]
        public void SynonymMapsSetOnlyOnPropertiesWithSynonymMapsAttribute(Type modelType)
        {
            var fields = new FieldMap(BuildForType(modelType));
            fields.OnlyTrueFor(field => field.SynonymMapNames?.Contains("myMap") ?? false, nameof(ReflectableModel.Text));
        }

        [TestCase(typeof(ReflectableCamelCaseModel))]
        [TestCase(typeof(ReflectableStructCamelCaseModel))]
        public void HonoursSerializePropertyNamesAsCamelCaseAttribute(Type modelType)
        {
            var fieldMap = new FieldMap(BuildForType(modelType));

            Assert.IsTrue(fieldMap.ContainsKey("id"));
            Assert.IsTrue(fieldMap.ContainsKey("myProperty"));
            Assert.IsTrue(fieldMap.ContainsKey("inner"));
            Assert.IsTrue(fieldMap.ContainsKey("inner/name"));
            Assert.IsTrue(fieldMap.ContainsKey("innerCollection"));
            Assert.IsTrue(fieldMap.ContainsKey("innerCollection/name"));
        }

        [Test]
        public void RecursivePropertiesAreIgnored()
        {
            var fieldMap = new FieldMap(BuildForType(typeof(RecursiveModel)));

            Assert.IsTrue(fieldMap.ContainsKey(nameof(RecursiveModel.Data)));
            Assert.IsTrue(fieldMap.ContainsKey(nameof(RecursiveModel.Next)));
            Assert.IsTrue(fieldMap.ContainsKey(nameof(RecursiveModel.Next) + "/" + nameof(OtherRecursiveModel.Data)));
            Assert.IsFalse(fieldMap.ContainsKey(nameof(RecursiveModel.Next) + "/" + nameof(OtherRecursiveModel.RecursiveReference)));
        }

        [Test]
        public void NestedKeyAttributesAreIgnored()
        {
            var expectedFields = new SearchField[]
            {
                new SearchField(nameof(ModelWithNestedKey.ID), SearchFieldDataType.String) { IsKey = true },
                new SearchField(nameof(ModelWithNestedKey.Inner), SearchFieldDataType.Complex)
                {
                    Fields =
                    {
                        new SearchField(nameof(InnerModelWithKey.InnerID), SearchFieldDataType.String),
                        new SearchField(nameof(InnerModelWithKey.OtherField), SearchFieldDataType.Int32) { IsFilterable = true }
                    }
                }
            };

            IList<SearchField> actualFields = BuildForType(typeof(ModelWithNestedKey));

            Assert.That(actualFields, Is.EqualTo(expectedFields).Using(SearchFieldComparer.Shared));
        }

        [Test]
        public void PropertiesMarkedAsIgnoredAreIgnored()
        {
            var expectedFields = new SearchField[]
            {
                new SearchField(nameof(ModelWithNestedKey.ID), SearchFieldDataType.String) { IsKey = true },
                new SearchField(nameof(ModelWithNestedKey.Inner), SearchFieldDataType.Collection(SearchFieldDataType.Complex))
                {
                    Fields =
                    {
                        new SearchField(nameof(InnerModelWithIgnoredProperties.OtherField), SearchFieldDataType.Int32) { IsFilterable = true }
                    }
                }
            };

            IList<SearchField> actualFields = BuildForType(typeof(ModelWithIgnoredProperties));

            Assert.That(actualFields, Is.EqualTo(expectedFields).Using(SearchFieldComparer.Shared));
        }

        [TestCase(typeof(ModelWithEnum), nameof(ModelWithEnum.Direction))]
        [TestCase(typeof(ModelWithUnsupportedPrimitiveType), nameof(ModelWithUnsupportedPrimitiveType.Price))]
        [TestCase(typeof(ModelWithUnsupportedEnumerableType), nameof(ModelWithUnsupportedEnumerableType.Buffer))]
        [TestCase(typeof(ModelWithUnsupportedCollectionType), nameof(ModelWithUnsupportedCollectionType.Buffer))]
        public void FieldBuilderFailsWithHelpfulErrorMessageOnUnsupportedPropertyTypes(Type modelType, string invalidPropertyName)
        {
            ArgumentException e = Assert.Throws<ArgumentException>(() => FieldBuilder.BuildForType(modelType));

            string expectedErrorMessage =
                $"Property '{invalidPropertyName}' is of type '{modelType.GetProperty(invalidPropertyName).PropertyType}', " +
                "which does not map to an Azure Search data type. Please use a supported data type or mark the property with " +
                "[JsonIgnore] or [FieldBuilderIgnore] and define the field by creating a SearchField object." +
                $"{Environment.NewLine}Parameter name: {nameof(modelType)}";

            Assert.AreEqual(nameof(modelType), e.ParamName);
            Assert.AreEqual(expectedErrorMessage, e.Message);
        }

        [TestCase(typeof(int))]
        [TestCase(typeof(string))]
        [TestCase(typeof(DateTimeOffset))]
        [TestCase(typeof(Direction))]
        [TestCase(typeof(object))]
        [TestCase(typeof(int[]))]
        [TestCase(typeof(IEnumerable<ReflectableModel>))]
        [TestCase(typeof(IList<ReflectableStructModel>))]
        [TestCase(typeof(List<string>))]
        [TestCase(typeof(ICollection<decimal>))]
        public void FieldBuilderFailsWithHelpfulErrorMessageOnUnsupportedTypes(Type modelType)
        {
            ArgumentException e = Assert.Throws<ArgumentException>(() => FieldBuilder.BuildForType(modelType));

            string expectedErrorMessage =
                $"Type '{modelType}' does not have properties which map to fields of an Azure Search index. Please use a " +
                $"class or struct with public properties.{Environment.NewLine}Parameter name: {nameof(modelType)}";

            Assert.AreEqual(nameof(modelType), e.ParamName);
            Assert.AreEqual(expectedErrorMessage, e.Message);
        }

        private static IEnumerable<(Type, SearchFieldDataType, string)> CombineTestData(
            IEnumerable<Type> modelTypes,
            IEnumerable<(SearchFieldDataType dataType, string fieldName)> testData) =>
            from type in modelTypes
            from tuple in testData
            select (type, tuple.dataType, tuple.fieldName);

        private static IList<SearchField> BuildForType(Type modelType) => FieldBuilder.BuildForType(modelType);

        private enum Direction
        {
            Up,
            Down
        }

        private class FieldMap
        {
            private readonly IReadOnlyDictionary<string, SearchField> _map;

            public FieldMap(IList<SearchField> fields)
            {
                static IEnumerable<KeyValuePair<string, SearchField>> GetSelfAndDescendants(SearchField topLevelField)
                {
                    static IEnumerable<KeyValuePair<string, SearchField>> GetSelfAndDescendantsRecursive(SearchField field, string parentFieldPath)
                    {
                        string currentFieldPath =
                            string.IsNullOrEmpty(parentFieldPath) ? field.Name : parentFieldPath + "/" + field.Name;

                        yield return new KeyValuePair<string, SearchField>(currentFieldPath, field);

                        foreach (SearchField subField in field.Fields ?? Enumerable.Empty<SearchField>())
                        {
                            foreach (KeyValuePair<string, SearchField> result in GetSelfAndDescendantsRecursive(subField, currentFieldPath))
                            {
                                yield return result;
                            }
                        }
                    }

                    return GetSelfAndDescendantsRecursive(topLevelField, string.Empty);
                }

                _map = fields.SelectMany(f => GetSelfAndDescendants(f)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }

            public SearchField this[string fieldName] => _map[fieldName];

            public bool ContainsKey(string fieldName) => _map.ContainsKey(fieldName);

            public void OnlyTrueFor(Func<SearchField, bool> check, params string[] expectedFieldNames)
            {
                foreach (string fieldNameFromModel in _map.Keys)
                {
                    SearchField field = _map[fieldNameFromModel];
                    bool result = check(field);

                    if (expectedFieldNames.Contains(fieldNameFromModel))
                    {
                        Assert.IsTrue(result, $"Expected true for field {fieldNameFromModel}.");
                    }
                    else
                    {
                        Assert.IsFalse(result, $"Expected false for field {fieldNameFromModel}.");
                    }
                }
            }

            public void OnlyFalseFor(Func<SearchField, bool> check, params string[] expectedFieldNames) =>
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
