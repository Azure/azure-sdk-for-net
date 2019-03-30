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
                    (DataType.GeographyPoint, nameof(ReflectableModel.GeographyPoint))
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
                    (DataType.String, nameof(ReflectableModel.StringList))
                };

                return new TheoryData<Type, DataType, string>().PopulateFrom(CombineTestData(TestModelTypes, collectionPropertyTestData));
            }
        }

        [Theory]
        [MemberData(nameof(PrimitiveTypeTestData))]
        public void ReportsPrimitiveTypedProperties(Type modelType, DataType expectedDataType, string fieldName)
        {
            Test(modelType, fields => Assert.Equal(expectedDataType, fields[fieldName].Type));
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
                nameof(ReflectableModel.MoreText));
        }

        [Theory]
        [MemberData(nameof(TestModelTypeTestData))]
        public void IsFilterableOnlyOnPropertiesWithIsFilterableAttribute(Type modelType)
        {
            OnlyTrueFor(
                modelType,
                field => field.IsFilterable.GetValueOrDefault(false),
                nameof(ReflectableModel.FilterableText));
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
                nameof(ReflectableModel.FacetableText));
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
                nameof(ReflectableModel.TextWithAnalyzer));
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
            }

            TestForFields(RunTest, FieldBuilder.BuildForType(modelType));
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
            var fieldMap = fields.ToDictionary(f => f.Name);
            run(fieldMap);
        }
    }
}
