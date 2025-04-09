// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.Filtering
{
    using System.Collections.Generic;
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering;
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
    using Xunit;

    public class FilterConjunctionGroupTests
    {
        [Fact]
        public void FilterConjunctionGroupPassesWhenAllFiltersPass()
        {
            // ARRANGE
            CollectionConfigurationError[] errors;
            var filterGroupInfo = new FilterConjunctionGroupInfo(new List<FilterInfo>() {
                                        new FilterInfo("StringField", PredicateType.Contains, "apple"),
                                        new FilterInfo("StringField", PredicateType.Contains, "dog"),
                                        new FilterInfo("StringField", PredicateType.Contains, "red")
                                      });
            var filterGroup = new FilterConjunctionGroup<DocumentMock>(filterGroupInfo, out errors);
            var telemetry = new DocumentMock() { StringField = "This string contains all valuable words: 'apple', 'dog', and 'red'." };

            // ACT
            CollectionConfigurationError[] runtimeErrors;
            bool filtersPassed = filterGroup.CheckFilters(telemetry, out runtimeErrors);

            // ASSERT
            Assert.True(filtersPassed);
            Assert.Empty(errors);
            Assert.Empty(runtimeErrors);
        }

        [Fact]
        public void FilterConjunctionGroupFailsWhenOneFilterFails()
        {
            // ARRANGE
            CollectionConfigurationError[] errors;
            var filterGroupInfo = new FilterConjunctionGroupInfo(new List<FilterInfo>() {
                                        new FilterInfo("StringField", PredicateType.Contains, "apple"),
                                        new FilterInfo("StringField", PredicateType.Contains, "dog"),
                                        new FilterInfo("StringField", PredicateType.Contains, "red")
                                      });
            var filterGroup = new FilterConjunctionGroup<DocumentMock>(filterGroupInfo, out errors);
            var telemetry = new DocumentMock()
                                {
                                    StringField =
                                        "This string contains some of the valuable words: 'apple', 'red', but doesn't mention the man's best friend..."
                                };

            // ACT
            CollectionConfigurationError[] runtimeErrors;
            bool filtersPassed = filterGroup.CheckFilters(telemetry, out runtimeErrors);

            // ASSERT
            Assert.False(filtersPassed);
            Assert.Empty(errors);
            Assert.Empty(runtimeErrors);
        }

        [Fact]
        public void FilterConjunctionGroupPassesWhenNoFilters()
        {
            // ARRANGE
            CollectionConfigurationError[] errors;
            var filterGroupInfo = new FilterConjunctionGroupInfo( new FilterInfo[0] );
            var filterGroup = new FilterConjunctionGroup<DocumentMock>(filterGroupInfo, out errors);
            var telemetry = new DocumentMock();

            // ACT
            CollectionConfigurationError[] runtimeErrors;
            bool filtersPassed = filterGroup.CheckFilters(telemetry, out runtimeErrors);

            // ASSERT
            Assert.True(filtersPassed);
            Assert.Empty(errors);
            Assert.Empty(runtimeErrors);
        }

        [Fact]
        public void FilterConjunctionGroupReportsErrorsWhenIncorrectFiltersArePresent()
        {
            // ARRANGE
            CollectionConfigurationError[] errors;
            var filterGroupInfo = new FilterConjunctionGroupInfo(new List<FilterInfo>() {
                                    new FilterInfo("NonExistentField", PredicateType.Contains, "apple"),
                                    new FilterInfo("BooleanField", PredicateType.Contains, "dog"),
                                    new FilterInfo("StringField", PredicateType.Contains, "red")
                                    });
            var filterGroup = new FilterConjunctionGroup<DocumentMock>(filterGroupInfo, out errors);
            var telemetry = new DocumentMock() { StringField = "red" };

            // ACT
            CollectionConfigurationError[] runtimeErrors;
            bool filtersPassed = filterGroup.CheckFilters(telemetry, out runtimeErrors);

            // ASSERT
            Assert.True(filtersPassed);

            Assert.Equal(2, errors.Length);

            Assert.Equal(CollectionConfigurationErrorType.FilterFailureToCreateUnexpected, errors[0].CollectionConfigurationErrorType);
            Assert.Equal(
                "Failed to create a filter NonExistentField Contains apple.",
                errors[0].Message);
            Assert.Contains($"Error finding property NonExistentField in the type {typeof(DocumentMock).FullName}", errors[0].FullException);
            Assert.Equal(3, errors[0].Data.Count);
            Assert.Equal("NonExistentField", errors[0].Data.GetValue("FilterFieldName"));
            Assert.Equal(Predicate.Contains.ToString(), errors[0].Data.GetValue("FilterPredicate"));
            Assert.Equal("apple", errors[0].Data.GetValue("FilterComparand"));

            Assert.Equal(CollectionConfigurationErrorType.FilterFailureToCreateUnexpected, errors[1].CollectionConfigurationErrorType);
            Assert.Equal(
                "Failed to create a filter BooleanField Contains dog.",
                errors[1].Message);
            Assert.Contains("Could not construct the filter.", errors[1].FullException);
            Assert.Equal(3, errors[1].Data.Count);
            Assert.Equal("BooleanField", errors[1].Data.GetValue("FilterFieldName"));
            Assert.Equal(Predicate.Contains.ToString(), errors[1].Data.GetValue("FilterPredicate"));
            Assert.Equal("dog", errors[1].Data.GetValue("FilterComparand"));

            Assert.Empty(runtimeErrors);
        }
    }
}
