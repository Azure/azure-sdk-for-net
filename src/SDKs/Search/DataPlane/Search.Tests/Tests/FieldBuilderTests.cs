// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Rest.Serialization;
    using Xunit;

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

        public static TheoryData<Type> TestModelTypeTestData => new TheoryData<Type>().PopulateFrom(TestModelTypes);

        public static TheoryData<Type, DataType, string> PrimitiveTypeTestData
        {
            get
            {
                (DataType, string)[] primitivePropertyTestData = new[]
                {
                    (DataType.String, nameof(ReflectableModel.Text)),
                    (DataType.Int32, nameof(ReflectableModel.Id)),
                    (DataType.Int64, nameof(ReflectableModel.BigNumber)),
                    (DataType.Double, nameof(ReflectableModel.Double)),
                    (DataType.Boolean, nameof(ReflectableModel.Flag)),
                    (DataType.DateTimeOffset, nameof(ReflectableModel.Time)),
                    (DataType.DateTimeOffset, nameof(ReflectableModel.TimeWithoutOffset)),
                    (DataType.GeographyPoint, nameof(ReflectableModel.GeographyPoint)),
                    (DataType.AsString.String, nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Name)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Rating)),
                    (DataType.AsString.String, nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City)),
                    (DataType.AsString.String, nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country)),
                    (DataType.AsString.String, nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Name)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Rating)),
                    (DataType.AsString.String, nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City)),
                    (DataType.AsString.String, nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country)),
                    (DataType.AsString.String, nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Name)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Rating)),
                    (DataType.AsString.String, nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City)),
                    (DataType.AsString.String, nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country)),
                    (DataType.AsString.String, nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Name)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Rating)),
                    (DataType.AsString.String, nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City)),
                    (DataType.AsString.String, nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country)),
                    (DataType.AsString.String, nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Name)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Rating)),
                    (DataType.AsString.String, nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City)),
                    (DataType.AsString.String, nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country))
                };

                return new TheoryData<Type, DataType, string>().PopulateFrom(CombineTestData(TestModelTypes, primitivePropertyTestData));
            }
        }

        public static TheoryData<Type, DataType, string> CollectionTypeTestData
        {
            get
            {
                (DataType, string)[] collectionPropertyTestData = new[]
                {
                    (DataType.String, nameof(ReflectableModel.StringArray)),
                    (DataType.String, nameof(ReflectableModel.StringIList)),
                    (DataType.String, nameof(ReflectableModel.StringIEnumerable)),
                    (DataType.String, nameof(ReflectableModel.StringList)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.IntArray)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.IntIList)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.IntIEnumerable)),
                    (DataType.AsString.Int32, nameof(ReflectableModel.IntList)),
                    (DataType.AsString.Int64, nameof(ReflectableModel.LongArray)),
                    (DataType.AsString.Int64, nameof(ReflectableModel.LongIList)),
                    (DataType.AsString.Int64, nameof(ReflectableModel.LongIEnumerable)),
                    (DataType.AsString.Int64, nameof(ReflectableModel.LongList)),
                    (DataType.AsString.Double, nameof(ReflectableModel.DoubleArray)),
                    (DataType.AsString.Double, nameof(ReflectableModel.DoubleIList)),
                    (DataType.AsString.Double, nameof(ReflectableModel.DoubleIEnumerable)),
                    (DataType.AsString.Double, nameof(ReflectableModel.DoubleList)),
                    (DataType.AsString.Boolean, nameof(ReflectableModel.BoolArray)),
                    (DataType.AsString.Boolean, nameof(ReflectableModel.BoolIList)),
                    (DataType.AsString.Boolean, nameof(ReflectableModel.BoolIEnumerable)),
                    (DataType.AsString.Boolean, nameof(ReflectableModel.BoolList)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeArray)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeIList)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeIEnumerable)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeList)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetArray)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetIList)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetIEnumerable)),
                    (DataType.AsString.DateTimeOffset, nameof(ReflectableModel.DateTimeOffsetList)),
                    (DataType.AsString.GeographyPoint, nameof(ReflectableModel.GeographyPointArray)),
                    (DataType.AsString.GeographyPoint, nameof(ReflectableModel.GeographyPointIList)),
                    (DataType.AsString.GeographyPoint, nameof(ReflectableModel.GeographyPointIEnumerable)),
                    (DataType.AsString.GeographyPoint, nameof(ReflectableModel.GeographyPointList)),
                    (DataType.AsString.Complex, nameof(ReflectableModel.ComplexArray)),
                    (DataType.AsString.Complex, nameof(ReflectableModel.ComplexIList)),
                    (DataType.AsString.Complex, nameof(ReflectableModel.ComplexIEnumerable)),
                    (DataType.AsString.Complex, nameof(ReflectableModel.ComplexList))
                };

                return new TheoryData<Type, DataType, string>().PopulateFrom(CombineTestData(TestModelTypes, collectionPropertyTestData));
            }
        }

        public static TheoryData<Type, string> ComplexTypeTestData
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
                    nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Address)
                };

                return new TheoryData<Type, string>().PopulateFrom(
                    from type in TestModelTypes
                    from fieldPath in complexPropertyTestData
                    select (type, fieldPath));
            }
        }

        [Theory]
        [MemberData(nameof(PrimitiveTypeTestData))]
        public void ReportsPrimitiveTypedProperties(Type modelType, DataType expectedDataType, string fieldName)
        {
            Test(modelType, fields => Assert.Equal(expectedDataType, fields[fieldName].Type));
        }

        [Theory]
        [MemberData(nameof(ComplexTypeTestData))]
        public void ReportsComplexTypedProperties(Type modelType, string fieldName)
        {
            Test(modelType, fields => Assert.Equal(DataType.Complex, fields[fieldName].Type));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void ReportsNullableInt32Properties(Type modelType)
        {
            Test(modelType, fields => Assert.Equal(DataType.Int32, fields[nameof(ReflectableModel.NullableInt)].Type));
        }

        [Theory]
        [MemberData(nameof(CollectionTypeTestData))]
        public void ReportsCollectionProperties(Type modelType, DataType expectedElementDataType, string fieldName)
        {
            Test(modelType, fields => Assert.Equal(DataType.Collection(expectedElementDataType), fields[fieldName].Type));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void ReportsKeyOnlyOnPropertyWithKeyAttribute(Type modelType)
        {
            OnlyTrueFor(modelType, field => field.IsKey.GetValueOrDefault(false), nameof(ReflectableModel.Id));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void ReportsIsSearchableOnlyOnPropertiesWithIsSearchableAttribute(Type modelType)
        {
            OnlyTrueFor(
                modelType,
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
                nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.City));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void IsFilterableOnlyOnPropertiesWithIsFilterableAttribute(Type modelType)
        {
            OnlyTrueFor(
                modelType,
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
                nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void IsSortableOnlyOnPropertiesWithIsSortableAttribute(Type modelType)
        {
            OnlyTrueFor(modelType, field => field.IsSortable.GetValueOrDefault(false), nameof(ReflectableModel.SortableText));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void IsFacetableOnlyOnPropertiesWithIsFacetableAttribute(Type modelType)
        {
            OnlyTrueFor(
                modelType,
                field => field.IsFacetable.GetValueOrDefault(false),
                nameof(ReflectableModel.FacetableText),
                nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country),
                nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Address) + "/" + nameof(ReflectableAddress.Country));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void IsRetrievableOnAllPropertiesExceptOnesWithIsRetrievableAttributeSetToFalse(Type modelType)
        {
            OnlyFalseFor(modelType, field => field.IsRetrievable.GetValueOrDefault(true), nameof(ReflectableModel.IrretrievableText));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void AnalyzerSetOnlyOnPropertiesWithAnalyzerAttribute(Type modelType)
        {
            OnlyTrueFor(
                modelType,
                field => field.Analyzer == AnalyzerName.EnMicrosoft,
                nameof(ReflectableModel.TextWithAnalyzer),
                nameof(ReflectableModel.Complex) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexArray) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexIList) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexList) + "/" + nameof(ReflectableComplexObject.Name),
                nameof(ReflectableModel.ComplexIEnumerable) + "/" + nameof(ReflectableComplexObject.Name));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void SearchAnalyzerSetOnlyOnPropertiesWithSearchAnalyzerAttribute(Type modelType)
        {
            OnlyTrueFor(modelType, field => field.SearchAnalyzer == AnalyzerName.EsLucene, nameof(ReflectableModel.TextWithSearchAnalyzer));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void IndexAnalyzerSetOnlyOnPropertiesWithIndexAnalyzerAttribute(Type modelType)
        {
            OnlyTrueFor(modelType, field => field.IndexAnalyzer == AnalyzerName.Whitespace, nameof(ReflectableModel.TextWithIndexAnalyzer));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void SynonymMapsSetOnlyOnPropertiesWithSynonymMapsAttribute(Type modelType)
        {
            OnlyTrueFor(modelType, field => field.SynonymMaps?.Contains("myMap") ?? false, nameof(ReflectableModel.Text));
        }

        [Theory]
        [InlineData(typeof(ReflectableCamelCaseModel))]
        [InlineData(typeof(ReflectableStructCamelCaseModel))]
        public void HonoursSerializePropertyNamesAsCamelCaseAttribute(Type modelType)
        {
            void RunTest(Dictionary<string, Field> fieldMap)
            {
                Assert.True(fieldMap.ContainsKey("id"));
                Assert.True(fieldMap.ContainsKey("myProperty"));
                Assert.True(fieldMap.ContainsKey("inner"));
                Assert.True(fieldMap.ContainsKey("inner/name"));
                Assert.True(fieldMap.ContainsKey("innerCollection"));
                Assert.True(fieldMap.ContainsKey("innerCollection/name"));
            }

            TestForFields(RunTest, FieldBuilder.BuildForType(modelType));
        }

        [Fact]
        public void RecursivePropertiesAreIgnored()
        {
            void RunTest(Dictionary<string, Field> fieldMap)
            {
                Assert.True(fieldMap.ContainsKey(nameof(RecursiveModel.Data)));
                Assert.True(fieldMap.ContainsKey(nameof(RecursiveModel.Next)));
                Assert.True(fieldMap.ContainsKey(nameof(RecursiveModel.Next) + "/" + nameof(OtherRecursiveModel.Data)));
                Assert.False(fieldMap.ContainsKey(nameof(RecursiveModel.Next) + "/" + nameof(OtherRecursiveModel.RecursiveReference)));
            }

            Test(typeof(RecursiveModel), RunTest);
        }

        private static IEnumerable<(Type, DataType, string)> CombineTestData(
            IEnumerable<Type> modelTypes,
            IEnumerable<(DataType, string)> testData) =>
            from type in modelTypes
            from tuple in testData
            select (type, tuple.Item1, tuple.Item2);

        private void OnlyTrueFor(Type modelType, Func<Field, bool> check, params string[] expectedFieldNames)
        {
            Test(
                modelType,
                fields =>
                {
                    foreach ((string fieldNameFromModel, Field field) in fields)
                    {
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
                });
        }

        private void OnlyFalseFor(Type modelType, Func<Field, bool> check, params string[] expectedFieldNames) =>
            OnlyTrueFor(modelType, f => !check(f), expectedFieldNames);

        private void Test(Type modelType, Action<Dictionary<string, Field>> run)
        {
            // Test with both with and without bring-your-own-resolver.
            TestForFields(run, FieldBuilder.BuildForType(modelType, new ReadOnlyJsonContractResolver()));
            TestForFields(run, FieldBuilder.BuildForType(modelType));
        }

        private void TestForFields(Action<Dictionary<string, Field>> run, IList<Field> fields)
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

            var fieldMap = fields.SelectMany(f => GetSelfAndDescendants(f)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            run(fieldMap);
        }
    }
}
