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
        [Fact]
        public void ReportsStringProperties()
        {
            Test(fields => Assert.Equal(DataType.String, fields["Text"].Type));
        }

        [Fact]
        public void ReportsInt32Properties()
        {
            Test(fields => Assert.Equal(DataType.Int32, fields["Id"].Type));
        }

        [Fact]
        public void ReportsNullableInt32Properties()
        {
            Test(fields => Assert.Equal(DataType.Int32, fields["NullableInt"].Type));
        }

        [Fact]
        public void ReportsInt64Properties()
        {
            Test(fields => Assert.Equal(DataType.Int64, fields["BigNumber"].Type));
        }

        [Fact]
        public void ReportsDoubleProperties()
        {
            Test(fields => Assert.Equal(DataType.Double, fields["Double"].Type));
        }

        [Fact]
        public void ReportsBooleanProperties()
        {
            Test(fields => Assert.Equal(DataType.Boolean, fields["Flag"].Type));
        }

        [Fact]
        public void ReportsDateTimeOffsetProperties()
        {
            Test(fields => Assert.Equal(DataType.DateTimeOffset, fields["Time"].Type));
        }

        [Fact]
        public void ReportsDateTimeProperties()
        {
            Test(fields => Assert.Equal(DataType.DateTimeOffset, fields["TimeWithoutOffset"].Type));
        }

        [Fact]
        public void ReportsGeographyPointProperties()
        {
            Test(fields => Assert.Equal(DataType.GeographyPoint, fields["GeographyPoint"].Type));
        }

        [Fact]
        public void ReportsStringArrayProperties()
        {
            Test(fields => Assert.Equal(DataType.Collection(DataType.String), fields["StringArray"].Type));
        }

        [Fact]
        public void ReportsStringIListProperties()
        {
            Test(fields => Assert.Equal(DataType.Collection(DataType.String), fields["StringIList"].Type));
        }

        [Fact]
        public void ReportsStringIEnumerableProperties()
        {
            Test(fields => Assert.Equal(DataType.Collection(DataType.String), fields["StringIEnumerable"].Type));
        }

        [Fact]
        public void ReportsStringListProperties()
        {
            Test(fields => Assert.Equal(DataType.Collection(DataType.String), fields["StringList"].Type));
        }

        [Fact]
        public void ReportsKeyOnlyOnPropertyWithKeyAttribute()
        {
            OnlyTrueFor(field => field.IsKey, nameof(ReflectableModel.Id));
        }

        [Fact]
        public void ReportsIsSearchableOnlyOnPropertiesWithIsSearchableAttribute()
        {
            OnlyTrueFor(field => field.IsSearchable, nameof(ReflectableModel.Text), nameof(ReflectableModel.MoreText));
        }

        [Fact]
        public void IsFilterableOnlyOnPropertiesWithIsFilterableAttribute()
        {
            OnlyTrueFor(field => field.IsFilterable, nameof(ReflectableModel.FilterableText));
        }

        [Fact]
        public void IsSortableOnlyOnPropertiesWithIsSortableAttribute()
        {
            OnlyTrueFor(field => field.IsSortable, nameof(ReflectableModel.SortableText));
        }

        [Fact]
        public void IsFacetableOnlyOnPropertiesWithIsFacetableAttribute()
        {
            OnlyTrueFor(field => field.IsFacetable, nameof(ReflectableModel.FacetableText));
        }

        [Fact]
        public void IsRetrievableOnAllPropertiesExceptOnesWithIsRetrievableAttributeSetToFalse()
        {
            OnlyFalseFor(field => field.IsRetrievable, nameof(ReflectableModel.IrretrievableText));
        }

        [Fact]
        public void AnalyzerSetOnlyOnPropertiesWithAnalyzerAttribute()
        {
            OnlyTrueFor(field => field.Analyzer == AnalyzerName.EnMicrosoft, nameof(ReflectableModel.TextWithAnalyzer));
        }

        [Fact]
        public void SearchAnalyzerSetOnlyOnPropertiesWithSearchAnalyzerAttribute()
        {
            OnlyTrueFor(field => field.SearchAnalyzer == AnalyzerName.EsLucene, nameof(ReflectableModel.TextWithSearchAnalyzer));
        }

        [Fact]
        public void IndexAnalyzerSetOnlyOnPropertiesWithIndexAnalyzerAttribute()
        {
            OnlyTrueFor(field => field.IndexAnalyzer == AnalyzerName.Whitespace, nameof(ReflectableModel.TextWithIndexAnalyzer));
        }

        [Fact]
        public void HonoursSerializePropertyNamesAsCamelCaseAttribute()
        {
            TestCamelCase(fieldMap =>
            {
                Assert.True(fieldMap.ContainsKey("id"));
                Assert.True(fieldMap.ContainsKey("myProperty"));
            });
        }

        private void OnlyTrueFor(Func<Field, bool?> check, params string[] ids)
        {
            Test(fields =>
            {
                foreach (var kv in fields)
                {
                    string id = kv.Key;
                    Field field = kv.Value;
                    bool? result = check(field);
                    Assert.True(result.HasValue);

                    if (ids.Contains(id))
                    {
                        Assert.True(result.Value, $"Expected true for field {id}.");
                    }
                    else
                    {
                        Assert.False(result.Value, $"Expected false for field {id}.");
                    }
                }
            });
        }

        private void OnlyFalseFor(Func<Field, bool?> check, params string[] ids) =>
            OnlyTrueFor(f => !check(f), ids);

        private void Test(Action<Dictionary<string, Field>> run)
        {
            // Test with both with and without bring-your-own-resolver, and with classes and structs.
            TestForFields(run, FieldBuilder.BuildForType<ReflectableModel>(new ReadOnlyJsonContractResolver()));
            TestForFields(run, FieldBuilder.BuildForType<ReflectableModel>());
            TestForFields(run, FieldBuilder.BuildForType<ReflectableStructModel>(new ReadOnlyJsonContractResolver()));
            TestForFields(run, FieldBuilder.BuildForType<ReflectableStructModel>());
        }

        private void TestCamelCase(Action<Dictionary<string, Field>> run)
        {
            // Test with both classes and structs.
            TestForFields(run, FieldBuilder.BuildForType<ReflectableCamelCaseModel>());
            TestForFields(run, FieldBuilder.BuildForType<ReflectableStructCamelCaseModel>());
        }

        private void TestForFields(Action<Dictionary<string, Field>> run, IList<Field> fields)
        {
            var fieldMap = fields.ToDictionary(f => f.Name);
            run(fieldMap);
        }
    }
}
