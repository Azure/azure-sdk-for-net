// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using Microsoft.Azure.Search.Models;
    using Microsoft.Azure.Search.Tests.Utilities;
    using Microsoft.Rest;
    using Xunit;

    public class FieldTests
    {
        private readonly Field subField = new Field("subfield", DataType.Double);

        [Fact]
        public void CanBuildLeafViaConstructor()
        {
            var field = new Field("test", DataType.Double);
            AssertIsLeaf(field, "test", DataType.Double);
        }

        [Fact]
        public void CanBuildLeafViaFactoryMethod()
        {
            var field = Field.New("test", DataType.Double);
            AssertIsLeaf(field, "test", DataType.Double);
        }

        [Fact]
        public void LeafFactoryMethodSetsAllProperties()
        {
            var expectedField =
                new Field("test", DataType.String)
                {
                    IsKey = true,
                    IsRetrievable = true,
                    IsSearchable = true,
                    IsFilterable = true,
                    IsSortable = true,
                    IsFacetable = true,
                    Analyzer = null,
                    SearchAnalyzer = AnalyzerName.StandardLucene,
                    IndexAnalyzer = AnalyzerName.StandardLucene,
                    SynonymMaps = new[] { "map" }
                };

            var actualField =
                Field.New(
                    name: expectedField.Name,
                    dataType: expectedField.Type,
                    isKey: expectedField.IsKey.Value,
                    isRetrievable: expectedField.IsRetrievable.Value,
                    isSearchable: expectedField.IsSearchable.Value,
                    isFilterable: expectedField.IsFilterable.Value,
                    isSortable: expectedField.IsSortable.Value,
                    isFacetable: expectedField.IsFacetable.Value,
                    analyzerName: expectedField.Analyzer,
                    searchAnalyzerName: expectedField.SearchAnalyzer,
                    indexAnalyzerName: expectedField.IndexAnalyzer,
                    synonymMaps: expectedField.SynonymMaps);

            Assert.Equal(expectedField, actualField, new DataPlaneModelComparer<Field>());
        }

        [Theory]
        [InlineData(DataType.AsString.Complex, false)]
        [InlineData(DataType.AsString.Complex, true)]
        public void LeafConstructorThrowsOnComplexTypes(string dataTypeString, bool isCollection)
        {
            DataType type = MakeType(dataTypeString, isCollection);
            Assert.Throws<ArgumentException>(() => new Field("test", type));
        }

        [Theory]
        [InlineData(DataType.AsString.Complex, false)]
        [InlineData(DataType.AsString.Complex, true)]
        public void LeafFactoryMethodThrowsOnComplexTypes(string dataTypeString, bool isCollection)
        {
            DataType type = MakeType(dataTypeString, isCollection);
            Assert.Throws<ArgumentException>(() => Field.New("test", type));
        }

        [Fact]
        public void CanBuildComplexFieldViaConstructor()
        {
            var field = new Field("test", DataType.Complex, new[] { subField });

            AssertIsComplex(field, "test", DataType.Complex);
            Assert.Collection(field.Fields, f => Assert.Same(subField, f));
        }

        [Fact]
        public void CanBuildComplexFieldViaFactoryMethod()
        {
            var field = Field.NewComplex("test", isCollection: true, fields: new[] { subField });

            AssertIsComplex(field, "test", DataType.Collection(DataType.Complex));
            Assert.Collection(field.Fields, f => Assert.Same(subField, f));
        }

        [Fact]
        public void ComplexFieldConstructorThrowsOnNoSubfields()
        {
            Assert.Throws<ArgumentNullException>(() => new Field("test", DataType.Complex, fields: null));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Field("test", DataType.Collection(DataType.Complex), fields: new Field[0]));
        }

        [Fact]
        public void ComplexFieldFactoryMethodThrowsOnNoSubfields()
        {
            Assert.Throws<ArgumentNullException>(() => Field.NewComplex("test", isCollection: true, fields: null));
            Assert.Throws<ArgumentOutOfRangeException>(() => Field.NewComplex("test", isCollection: false, fields: new Field[0]));
        }

        [Theory]
        [InlineData(DataType.AsString.String, false)]
        [InlineData(DataType.AsString.String, true)]
        [InlineData(DataType.AsString.Int32, false)]
        [InlineData(DataType.AsString.Int32, true)]
        [InlineData(DataType.AsString.DateTimeOffset, false)]
        [InlineData(DataType.AsString.DateTimeOffset, true)]
        [InlineData(DataType.AsString.GeographyPoint, false)]
        [InlineData(DataType.AsString.GeographyPoint, true)]
        public void ComplexFieldConstructorThrowsOnNonComplexTypes(string dataTypeString, bool isCollection)
        {
            DataType type = MakeType(dataTypeString, isCollection);
            Assert.Throws<ArgumentException>(() => new Field("test", type, fields: new[] { subField }));
        }

        [Fact]
        public void CanBuildSearchableStringFieldViaConstructor()
        {
            var field = new Field("test", AnalyzerName.FrMicrosoft);
            AssertIsLeaf(field, "test", DataType.String, AnalyzerName.FrMicrosoft);
        }

        [Fact]
        public void CanBuildSearchableStringFieldViaFactoryMethod()
        {
            var field = Field.NewSearchableString("test", AnalyzerName.EnLucene);
            AssertIsLeaf(field, "test", DataType.String, AnalyzerName.EnLucene);
        }

        [Fact]
        public void SearchableStringFactoryMethodSetsAllProperties()
        {
            var expectedField =
                new Field("test", DataType.String)
                {
                    IsKey = true,
                    IsRetrievable = true,
                    IsSearchable = true,
                    IsFilterable = true,
                    IsSortable = true,
                    IsFacetable = true,
                    Analyzer = AnalyzerName.StandardAsciiFoldingLucene,
                    SearchAnalyzer = null,
                    IndexAnalyzer = null,
                    SynonymMaps = new[] { "map" }
                };

            var actualField =
                Field.NewSearchableString(
                    name: expectedField.Name,
                    analyzerName: expectedField.Analyzer.Value,
                    isKey: expectedField.IsKey.Value,
                    isRetrievable: expectedField.IsRetrievable.Value,
                    isFilterable: expectedField.IsFilterable.Value,
                    isSortable: expectedField.IsSortable.Value,
                    isFacetable: expectedField.IsFacetable.Value,
                    synonymMaps: expectedField.SynonymMaps);

            Assert.Equal(expectedField, actualField, new DataPlaneModelComparer<Field>());
        }

        [Fact]
        public void CanBuildSearchableCollectionFieldViaConstructor()
        {
            var field = new Field("test", DataType.Collection(DataType.String), AnalyzerName.DeMicrosoft);
            AssertIsLeaf(field, "test", DataType.Collection(DataType.String), AnalyzerName.DeMicrosoft);
        }

        [Fact]
        public void CanBuildSearchableCollectionFieldViaFactoryMethod()
        {
            var field = Field.NewSearchableCollection("test", AnalyzerName.ZhHantLucene);
            AssertIsLeaf(field, "test", DataType.Collection(DataType.String), AnalyzerName.ZhHantLucene);
        }

        [Fact]
        public void SearchableCollectionFactoryMethodSetsAllProperties()
        {
            var expectedField =
                new Field("test", DataType.Collection(DataType.String))
                {
                    IsKey = true,
                    IsRetrievable = true,
                    IsSearchable = true,
                    IsFilterable = true,
                    IsSortable = false,
                    IsFacetable = true,
                    Analyzer = AnalyzerName.StandardAsciiFoldingLucene,
                    SearchAnalyzer = null,
                    IndexAnalyzer = null,
                    SynonymMaps = new[] { "map" }
                };

            var actualField =
                Field.NewSearchableCollection(
                    name: expectedField.Name,
                    analyzerName: expectedField.Analyzer.Value,
                    isKey: expectedField.IsKey.Value,
                    isRetrievable: expectedField.IsRetrievable.Value,
                    isFilterable: expectedField.IsFilterable.Value,
                    isFacetable: expectedField.IsFacetable.Value,
                    synonymMaps: expectedField.SynonymMaps);

            Assert.Equal(expectedField, actualField, new DataPlaneModelComparer<Field>());
        }

        [Theory]
        [InlineData(DataType.AsString.Complex, false)]
        [InlineData(DataType.AsString.Complex, true)]
        public void SearchableConstructorFailsOnComplexTypes(string dataTypeString, bool isCollection)
        {
            DataType type = MakeType(dataTypeString, isCollection);
            Assert.Throws<ArgumentException>(() => new Field("test", type, AnalyzerName.ThMicrosoft));
        }

        [Theory]
        [InlineData(DataType.AsString.Double, false)]
        [InlineData(DataType.AsString.Double, true)]
        [InlineData(DataType.AsString.Int32, false)]
        [InlineData(DataType.AsString.Int32, true)]
        [InlineData(DataType.AsString.DateTimeOffset, false)]
        [InlineData(DataType.AsString.DateTimeOffset, true)]
        [InlineData(DataType.AsString.GeographyPoint, false)]
        [InlineData(DataType.AsString.GeographyPoint, true)]
        public void SearchableConstructorDoesNotFailOnNonSearchablePrimitiveTypes(string dataTypeString, bool isCollection)
        {
            // This is a pinning tests for a behavior that is permissive in the SDK, but strict in the REST API.
            DataType type = MakeType(dataTypeString, isCollection);
            var field = new Field("test", type, AnalyzerName.CsLucene);
            AssertIsLeaf(field, "test", type, AnalyzerName.CsLucene);
        }

        [Fact]
        public void FieldWithNullNameThrowsAtValidationTime()
        {
            var field = Field.NewComplex("parent", isCollection: true, fields: new[] { new Field(null, DataType.Int64) });
            Assert.Throws<ValidationException>(() => field.Validate());
        }

        private static DataType MakeType(string dataTypeString, bool isCollection) =>
            isCollection ? DataType.Collection(dataTypeString) : dataTypeString;

        private static void AssertIsLeaf(
            Field actualField, 
            string expectedName, 
            DataType expectedDataType, 
            AnalyzerName? expectedAnalyzer = null)
        {
            Assert.Equal(expectedName, actualField.Name);
            Assert.Equal(expectedDataType, actualField.Type);

            Assert.Equal(expectedAnalyzer, actualField.Analyzer);
            Assert.Null(actualField.Fields);
            Assert.Null(actualField.IndexAnalyzer);
            Assert.False(actualField.IsFacetable);
            Assert.False(actualField.IsFilterable);
            Assert.False(actualField.IsKey);
            Assert.True(actualField.IsRetrievable);
            Assert.Equal(expectedAnalyzer != null, actualField.IsSearchable);
            Assert.False(actualField.IsSortable);
            Assert.Null(actualField.SearchAnalyzer);
            Assert.Null(actualField.SynonymMaps);

            actualField.Validate(); // Verify that Validate() doesn't throw.
        }

        private static void AssertIsComplex(Field actualField, string expectedName, DataType expectedDataType)
        {
            Assert.Equal(expectedName, actualField.Name);
            Assert.Equal(expectedDataType, actualField.Type);

            Assert.Null(actualField.Analyzer);
            Assert.NotNull(actualField.Fields);
            Assert.Null(actualField.IndexAnalyzer);
            Assert.Null(actualField.IsFacetable);
            Assert.Null(actualField.IsFilterable);
            Assert.Null(actualField.IsKey);
            Assert.Null(actualField.IsRetrievable);
            Assert.Null(actualField.IsSearchable);
            Assert.Null(actualField.IsSortable);
            Assert.Null(actualField.SearchAnalyzer);
            Assert.Null(actualField.SynonymMaps);

            actualField.Validate(); // Verify that Validate() doesn't throw.
        }
    }
}
