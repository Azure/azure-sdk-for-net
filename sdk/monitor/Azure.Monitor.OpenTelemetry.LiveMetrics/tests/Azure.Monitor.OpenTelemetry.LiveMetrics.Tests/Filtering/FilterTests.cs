// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;
    using Xunit;

    /// <summary>
    /// Filter tests.
    /// </summary>
    public class FilterTests
    {
        private const string EqualValue = "Equal";
        private const string NotEqualValue = "NotEqual";
        private const string LessThanValue = "LessThan";
        private const string GreaterThanValue = "GreaterThan";
        private const string LessThanOrEqualValue = "LessThanOrEqual";
        private const string GreaterThanOrEqualValue = "GreaterThanOrEqual";
        private const string ContainsValue = "Contains";
        private const string DoesNotContainValue = "DoesNotContain";

        #region Input validation
        [Fact]
        public void FilterThrowsWhenComparandIsNull()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("BooleanField", FilterInfoPredicate.Equal, null);

            // ACT, ASSERT
            Assert.Throws<ArgumentNullException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterThrowsWhenFieldNameIsEmpty()
        {
            // ARRANGE
            var equalsValue = new FilterInfo(string.Empty, FilterInfoPredicate.Equal, "abc");

            // ACT, ASSERT
            Assert.Throws<ArgumentNullException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterThrowsWhenFieldNameDoesNotExistInType()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NonExistentFieldName", FilterInfoPredicate.Equal, "abc");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }
        #endregion

        #region Filtering

        #region Boolean

        [Fact]
        public void FilterBooleanEqual()
        {
            // ARRANGE
            var equalsTrue = new FilterInfo("BooleanField", FilterInfoPredicate.Equal, "true");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsTrue).Check(new DocumentMock() { BooleanField = true });
            bool result2 = new Filter<DocumentMock>(equalsTrue).Check(new DocumentMock() { BooleanField = false });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void FilterBooleanNotEqual()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo("BooleanField", FilterInfoPredicate.NotEqual, "true");

            // ACT
            bool result1 = new Filter<DocumentMock>(notEqualTrue).Check(new DocumentMock() { BooleanField = true });
            bool result2 = new Filter<DocumentMock>(notEqualTrue).Check(new DocumentMock() { BooleanField = false });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
        }

        [Theory]
        [InlineData(GreaterThanValue)]
        [InlineData(LessThanValue)]
        [InlineData(GreaterThanOrEqualValue)]
        [InlineData(LessThanOrEqualValue)]
        [InlineData(ContainsValue)]
        [InlineData(DoesNotContainValue)]
        public void FilterBoolean_InvalidPredicates(string predicateString)
        {
            FilterInfoPredicate? predicate = new FilterInfoPredicate(predicateString);
            // ARRANGE
            var equalsValue = new FilterInfo("BooleanField", predicate, "true");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterBooleanGarbageComparand()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo("BooleanField", FilterInfoPredicate.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(notEqualTrue));
        }

        #endregion

        #region Nullable<Boolean>

        [Fact]
        public void FilterNullableBooleanEqual()
        {
            // ARRANGE
            var equalsTrue = new FilterInfo("NullableBooleanField", FilterInfoPredicate.Equal, "true");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsTrue).Check(new DocumentMock() { NullableBooleanField = true });
            bool result2 = new Filter<DocumentMock>(equalsTrue).Check(new DocumentMock() { NullableBooleanField = false });
            bool result3 = new Filter<DocumentMock>(equalsTrue).Check(new DocumentMock() { NullableBooleanField = null });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterNullableBooleanNotEqual()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo("NullableBooleanField", FilterInfoPredicate.NotEqual, "true");

            // ACT
            bool result1 = new Filter<DocumentMock>(notEqualTrue).Check(new DocumentMock() { NullableBooleanField = true });
            bool result2 = new Filter<DocumentMock>(notEqualTrue).Check(new DocumentMock() { NullableBooleanField = false });
            bool result3 = new Filter<DocumentMock>(notEqualTrue).Check(new DocumentMock() { NullableBooleanField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Theory]
        [InlineData(GreaterThanValue)]
        [InlineData(LessThanValue)]
        [InlineData(GreaterThanOrEqualValue)]
        [InlineData(LessThanOrEqualValue)]
        [InlineData(ContainsValue)]
        [InlineData(DoesNotContainValue)]
        public void FilterNullableBoolean_InvalidPredicates(string predicateString)
        {
            FilterInfoPredicate? predicate = new FilterInfoPredicate(predicateString);
            // ARRANGE
            var equalsValue = new FilterInfo("NullableBooleanField", predicate, "true");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterNullableBooleanGarbageComparand()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo("NullableBooleanField", FilterInfoPredicate.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(notEqualTrue));
        }
        #endregion

        #region Int

        [Fact]
        public void FilterIntEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("IntField", FilterInfoPredicate.Equal, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 123 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 124 });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void FilterIntNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("IntField", FilterInfoPredicate.NotEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 123 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 124 });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
        }

        [Fact]
        public void FilterIntGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("IntField", FilterInfoPredicate.GreaterThan, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 122 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 124 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 123 });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterIntLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("IntField", FilterInfoPredicate.LessThan, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 122 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 124 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 123 });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterIntGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("IntField", FilterInfoPredicate.GreaterThanOrEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 122 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 124 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 123 });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterIntLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("IntField", FilterInfoPredicate.LessThanOrEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 122 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 124 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 123 });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterIntContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("IntField", FilterInfoPredicate.Contains, "2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 152 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 160 });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void FilterIntDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("IntField", FilterInfoPredicate.DoesNotContain, "2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 152 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { IntField = 160 });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
        }

        [Fact]
        public void FilterIntGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("IntField", FilterInfoPredicate.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region Nullable<Int>

        [Fact]
        public void FilterNullableIntEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableIntField", FilterInfoPredicate.Equal, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 123 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 124 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = null });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterNullableIntNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableIntField", FilterInfoPredicate.NotEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 123 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 124 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterNullableIntGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableIntField", FilterInfoPredicate.GreaterThan, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 122 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 124 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 123 });
            bool result4 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.False(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterNullableIntLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableIntField", FilterInfoPredicate.LessThan, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 122 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 124 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 123 });
            bool result4 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = null });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterNullableIntGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableIntField", FilterInfoPredicate.GreaterThanOrEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 122 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 124 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 123 });
            bool result4 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterNullableIntLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableIntField", FilterInfoPredicate.LessThanOrEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 122 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 124 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 123 });
            bool result4 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = null });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.True(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterNullableIntContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableIntField", FilterInfoPredicate.Contains, "2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 152 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 160 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = null });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterNullableIntDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableIntField", FilterInfoPredicate.DoesNotContain, "2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 152 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = 160 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableIntField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterNullableIntGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableIntField", FilterInfoPredicate.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region Double

        [Fact]
        public void FilterDoubleEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("DoubleField", FilterInfoPredicate.Equal, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 123 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 124 });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void FilterDoubleNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("DoubleField", FilterInfoPredicate.NotEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 123 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 124 });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
        }

        [Fact]
        public void FilterDoubleGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("DoubleField", FilterInfoPredicate.GreaterThan, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 122.5 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 123.5 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 123 });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterDoubleLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("DoubleField", FilterInfoPredicate.LessThan, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 122.5 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 123.5 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 123 });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterDoubleGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("DoubleField", FilterInfoPredicate.GreaterThanOrEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 122.5 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 123.5 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 123 });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterDoubleLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("DoubleField", FilterInfoPredicate.LessThanOrEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 122.5 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 123.5 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 123 });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterDoubleContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("DoubleField", FilterInfoPredicate.Contains, "2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 157.2 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 160 });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void FilterDoubleDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("DoubleField", FilterInfoPredicate.DoesNotContain, "2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 157.2 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { DoubleField = 160 });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
        }

        [Fact]
        public void FilterDoubleGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("DoubleField", FilterInfoPredicate.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region Nullable<Double>

        [Fact]
        public void FilterNullableNullableDoubleEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableDoubleField", FilterInfoPredicate.Equal, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 123 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 124 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = null });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterNullableDoubleNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableDoubleField", FilterInfoPredicate.NotEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 123 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 124 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterNullableDoubleGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableDoubleField", FilterInfoPredicate.GreaterThan, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 122.5 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 123.5 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 123 });
            bool result4 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.False(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterNullableDoubleLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableDoubleField", FilterInfoPredicate.LessThan, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 122.5 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 123.5 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 123 });
            bool result4 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = null });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterNullableDoubleGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableDoubleField", FilterInfoPredicate.GreaterThanOrEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 122.5 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 123.5 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 123 });
            bool result4 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterNullableDoubleLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableDoubleField", FilterInfoPredicate.LessThanOrEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 122.5 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 123.5 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 123 });
            bool result4 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = null });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.True(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterNullableDoubleContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableDoubleField", FilterInfoPredicate.Contains, "2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 157.2 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 160 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = null });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterNullableDoubleDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableDoubleField", FilterInfoPredicate.DoesNotContain, "2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 157.2 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = 160 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableDoubleField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterNullableDoubleGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableDoubleField", FilterInfoPredicate.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region TimeSpan

        [Fact]
        public void FilterTimeSpanEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("TimeSpanField", FilterInfoPredicate.Equal, "123");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("123", CultureInfo.InvariantCulture) });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("124", CultureInfo.InvariantCulture) });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void FilterTimeSpanNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("TimeSpanField", FilterInfoPredicate.NotEqual, "123");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("123", CultureInfo.InvariantCulture) });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("124", CultureInfo.InvariantCulture) });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
        }

        [Fact]
        public void FilterTimeSpanGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("TimeSpanField", FilterInfoPredicate.GreaterThan, "123");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("122.05:00", CultureInfo.InvariantCulture) });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("123.05:00", CultureInfo.InvariantCulture) });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("123", CultureInfo.InvariantCulture) });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterTimeSpanLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("TimeSpanField", FilterInfoPredicate.LessThan, "123");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("122.05:00", CultureInfo.InvariantCulture) });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("123.05:00", CultureInfo.InvariantCulture) });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("123", CultureInfo.InvariantCulture) });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterTimeSpanGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("TimeSpanField", FilterInfoPredicate.GreaterThanOrEqual, "123");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("122.05:00", CultureInfo.InvariantCulture) });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("123.05:00", CultureInfo.InvariantCulture) });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("123", CultureInfo.InvariantCulture) });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterTimeSpanLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("TimeSpanField", FilterInfoPredicate.LessThanOrEqual, "123");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("122.05:00", CultureInfo.InvariantCulture) });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("123.05:00", CultureInfo.InvariantCulture) });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { TimeSpanField = TimeSpan.Parse("123", CultureInfo.InvariantCulture) });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterTimeSpanContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("TimeSpanField", FilterInfoPredicate.Contains, "2");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterTimeSpanDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("TimeSpanField", FilterInfoPredicate.DoesNotContain, "2");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterTimeSpanGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("DoubleField", FilterInfoPredicate.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region String

        [Fact]
        public void FilterStringEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("StringField", FilterInfoPredicate.Equal, "abc");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "abc" });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "aBc" });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "abc1" });

            // ASSERT
            Assert.True(result1);
            Assert.True(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterStringNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("StringField", FilterInfoPredicate.NotEqual, "abc");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "abc" });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "aBc" });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "abc1" });

            // ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterStringGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("StringField", FilterInfoPredicate.GreaterThan, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "122.5" });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "123.5" });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "123" });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterStringLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("StringField", FilterInfoPredicate.LessThan, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "122.5" });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "123.5" });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "123" });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterStringGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("StringField", FilterInfoPredicate.GreaterThanOrEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "122.5" });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "123.5" });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "123" });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterStringLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("StringField", FilterInfoPredicate.LessThanOrEqual, "123.0");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "122.5" });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "123.5" });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "123" });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterStringContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("StringField", FilterInfoPredicate.Contains, "abc");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "1abc2" });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "1aBc2" });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "123" });

            // ASSERT
            Assert.True(result1);
            Assert.True(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterStringDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("StringField", FilterInfoPredicate.DoesNotContain, "abc");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "1abc2" });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "1aBc2" });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "123" });

            // ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterStringGarbageFieldValue()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("StringField", FilterInfoPredicate.LessThan, "123.0");

            // ACT
            bool result = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "Not at all a number" });

            // ASSERT
            Assert.False(result);
        }

        [Fact]
        public void FilterStringGarbageComparandValue()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("StringField", FilterInfoPredicate.LessThan, "Not a number at all");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region Uri

        [Fact]
        public void FilterUriEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", FilterInfoPredicate.Equal, "http://microsoft.com/a");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://microsoft.com/a") });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://micrOSOft.com/a") });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://microsoft.com/a/b") });

            // ASSERT
            Assert.True(result1);
            Assert.True(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterUriNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", FilterInfoPredicate.NotEqual, "http://microsoft.com/a");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://microsoft.com/a") });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://micrOSOft.com/a") });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://microsoft.com/a/b") });

            // ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterUriGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", FilterInfoPredicate.GreaterThan, "http://microsoft.com/a");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterUriLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", FilterInfoPredicate.LessThan, "http://microsoft.com/a");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterUriLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", FilterInfoPredicate.LessThanOrEqual, "http://microsoft.com/a");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterUriGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", FilterInfoPredicate.GreaterThanOrEqual, "http://microsoft.com/a");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterUriContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", FilterInfoPredicate.Contains, "microsoft");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://microsoft.com/a") });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://micrOSOft.com/a") });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://a.com") });

            // ASSERT
            Assert.True(result1);
            Assert.True(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterUriDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", FilterInfoPredicate.DoesNotContain, "microsoft");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://microsoft.com/a") });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://micrOSOft.com/a") });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://a.com") });

            // ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterUriGarbageFieldValue()
        {
            // ARRANGE
            var doesNotContainValue = new FilterInfo("UriField", FilterInfoPredicate.Contains, "microsoft");
            var containsValue = new FilterInfo("UriField", FilterInfoPredicate.Contains, string.Empty);

            // ACT
            bool result1 = new Filter<DocumentMock>(doesNotContainValue).Check(new DocumentMock() { UriField = null });
            bool result2 = new Filter<DocumentMock>(containsValue).Check(new DocumentMock() { UriField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
        }

        [Fact]
        public void FilterUriGarbageComparandValue()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", FilterInfoPredicate.Contains, "Not at all a URI");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { UriField = new Uri("http://microsoft.com/a") });

            // ASSERT
            Assert.False(result1);
        }

        #endregion

        #region Enum

        [Fact]
        public void FilterEnumEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("EnumField", FilterInfoPredicate.Equal, "Value1");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value2 });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void FilterEnumNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("EnumField", FilterInfoPredicate.NotEqual, "Value1");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value2 });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
        }

        [Fact]
        public void FilterEnumGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("EnumField", FilterInfoPredicate.GreaterThan, "Value2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value2 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value3 });

            // ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterEnumLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("EnumField", FilterInfoPredicate.LessThan, "Value2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value2 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value3 });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterEnumGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("EnumField", FilterInfoPredicate.GreaterThanOrEqual, "Value2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value2 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value3 });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterEnumLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("EnumField", FilterInfoPredicate.LessThanOrEqual, "Value2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value2 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value3 });

            // ASSERT
            Assert.True(result1);
            Assert.True(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterEnumContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("EnumField", FilterInfoPredicate.Contains, "1");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value2 });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void FilterEnumDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("EnumField", FilterInfoPredicate.DoesNotContain, "1");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { EnumField = DocumentMock.EnumType.Value2 });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
        }

        [Fact]
        public void FilterEnumGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("EnumField", FilterInfoPredicate.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region Nullable<Enum>

        [Fact]
        public void FilterNullableEnumEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableEnumField", FilterInfoPredicate.Equal, "Value1");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value2 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = null });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterNullableEnumNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableEnumField", FilterInfoPredicate.NotEqual, "Value1");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value2 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        [Fact]
        public void FilterNullableEnumGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableEnumField", FilterInfoPredicate.GreaterThan, "Value2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value2 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value3 });
            bool result4 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = null });

            // ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.True(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterNullableEnumLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableEnumField", FilterInfoPredicate.LessThan, "Value2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value2 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value3 });
            bool result4 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = null });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterNullableEnumGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableEnumField", FilterInfoPredicate.GreaterThanOrEqual, "Value2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value2 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value3 });
            bool result4 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterNullableEnumLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableEnumField", FilterInfoPredicate.LessThanOrEqual, "Value2");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value2 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value3 });
            bool result4 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = null });

            // ASSERT
            Assert.True(result1);
            Assert.True(result2);
            Assert.False(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterNullableEnumContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableEnumField", FilterInfoPredicate.Contains, "1");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value2 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = null });

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterNullableEnumDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableEnumField", FilterInfoPredicate.DoesNotContain, "1");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value1 });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = DocumentMock.EnumType.Value2 });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { NullableEnumField = null });

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }

        #endregion

        //TODO: Removed TelemetryContext related tests. Confirm they are not needed.

        #region Custom dimensions
        [Fact(Skip = "CustomDimensions not working yet.")]
        public void FilterCustomDimensions()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("CustomDimensions.Dimension.1", FilterInfoPredicate.Equal, "abc");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Dimension.1", "abc") }));
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Dimension.1", "abcd") }));
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock());

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void FilterCustomMetrics()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("CustomMetrics.Metric.1", FilterInfoPredicate.Equal, "1.5");

            // ACT
            bool result1 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { Metrics = { ["Metric.1"] = 1.5d } });
            bool result2 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { Metrics = { ["Metric.1"] = 1.6d } });
            bool result3 = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock());

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }
        #endregion

        #region Asterisk
        [Fact]
        public void FilterAsteriskLimitsAcceptablePredicateValues()
        {
            // ARRANGE
            var acceptedPredicates = new List<Predicate>();

            // ACT
            foreach (Predicate predicate in Enum.GetValues(typeof(Predicate)))
            {
                try
                {
                    FilterInfoPredicate filterInfoPredicate = new FilterInfoPredicate(predicate.ToString());
                    new Filter<DocumentMock>(new FilterInfo("*", filterInfoPredicate, "123"));

                    acceptedPredicates.Add(predicate);
                }
                catch (ArgumentOutOfRangeException)
                {
                }
            }

            // ASSERT
            Assert.Equal(2, acceptedPredicates.Count);
            Assert.Equal(Predicate.Contains, acceptedPredicates[0]);
            Assert.Equal(Predicate.DoesNotContain, acceptedPredicates[1]);
        }

        [Fact]
        public void FilterAsteriskPropertyContains()
        {
            // ARRANGE
            var filterInfo = new FilterInfo("*", FilterInfoPredicate.Contains, "123");
            Filter<DocumentMock> filter = new Filter<DocumentMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new DocumentMock() { IntField = 1234 });
            bool result2 = filter.Check(new DocumentMock() { DoubleField = 1234 });
            bool result3 = filter.Check(new DocumentMock() { StringField = "1234" });
            bool result4 = filter.Check(new DocumentMock() { UriField = new Uri("http://microsoft.com/123") });

            bool result5 = filter.Check(new DocumentMock() { IntField = 12234 });
            bool result6 = filter.Check(new DocumentMock() { DoubleField = 12234 });
            bool result7 = filter.Check(new DocumentMock() { StringField = "12234" });
            bool result8 = filter.Check(new DocumentMock() { UriField = new Uri("http://microsoft.com/1223") });

            bool result9 = filter.Check(new DocumentMock());

            // ASSERT
            Assert.True(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.True(result4);

            Assert.False(result5);
            Assert.False(result6);
            Assert.False(result7);
            Assert.False(result8);

            Assert.False(result9);
        }

        [Fact]
        public void FilterAsteriskPropertyDoesNotContain()
        {
            // ARRANGE
            var filterInfo = new FilterInfo("*", FilterInfoPredicate.DoesNotContain, "123");
            Filter<DocumentMock> filter = new Filter<DocumentMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new DocumentMock() { IntField = 1234 });
            bool result2 = filter.Check(new DocumentMock() { DoubleField = 1234 });
            bool result3 = filter.Check(new DocumentMock() { StringField = "1234" });
            bool result4 = filter.Check(new DocumentMock() { UriField = new Uri("http://microsoft.com/123") });

            bool result5 = filter.Check(new DocumentMock() { IntField = 12234 });
            bool result6 = filter.Check(new DocumentMock() { DoubleField = 12234 });
            bool result7 = filter.Check(new DocumentMock() { StringField = "12234" });
            bool result8 = filter.Check(new DocumentMock() { UriField = new Uri("http://microsoft.com/1223") });

            bool result9 = filter.Check(new DocumentMock());

            // ASSERT
            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);

            Assert.True(result5);
            Assert.True(result6);
            Assert.True(result7);
            Assert.True(result8);

            Assert.True(result9);
        }

        [Fact(Skip = "Asterisk CustomDimensions not working yet.")]
        public void FilterAsteriskCustomDimensionContains()
        {
            // ARRANGE
            var filterInfo = new FilterInfo("*", FilterInfoPredicate.Contains, "123");
            Filter<DocumentMock> filter = new Filter<DocumentMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Prop1", "1234") }));
            bool result2 = filter.Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Prop1", "12234") }));
            bool result3 = filter.Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Prop1", null) }));
            bool result4 = filter.Check(new DocumentMock());

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterAsteriskCustomMetricsContains()
        {
            // ARRANGE
            var filterInfo = new FilterInfo("*", FilterInfoPredicate.Contains, "123");
            Filter<DocumentMock> filter = new Filter<DocumentMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new DocumentMock() { Metrics = { { "Metric1", 1234 } } });
            bool result2 = filter.Check(new DocumentMock() { Metrics = { { "Metric1", 12234 } } });
            bool result3 = filter.Check(new DocumentMock());

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact(Skip = "Asterisk CustomDimensions not working yet.")]
        public void FilterAsteriskCustomDimensionDoesNotContain()
        {
            // ARRANGE
            var filterInfo = new FilterInfo("*", FilterInfoPredicate.DoesNotContain, "123");
            Filter<DocumentMock> filter = new Filter<DocumentMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Prop1", "1234") }));
            bool result2 = filter.Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Prop1", "12234") }));
            bool result3 = filter.Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Prop1", null) }));
            bool result4 = filter.Check(new DocumentMock());

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
            Assert.True(result4);
        }

        [Fact]
        public void FilterAsteriskCustomMetricsDoesNotContain()
        {
            // ARRANGE
            var filterInfo = new FilterInfo("*", FilterInfoPredicate.DoesNotContain, "123");
            Filter<DocumentMock> filter = new Filter<DocumentMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new DocumentMock() { Metrics = { { "Metric1", 1234 } } });
            bool result2 = filter.Check(new DocumentMock() { Metrics = { { "Metric1", 12234 } } });
            bool result3 = filter.Check(new DocumentMock());

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            Assert.True(result3);
        }
        #endregion

        #endregion

        #region Support for actual telemetry types

        ////!!! enumerate real telemetry type's properties through reflection and explicitly state which ones we don't support
        [Fact]
        public void FilterSupportsRequestTelemetry()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("Name", FilterInfoPredicate.Equal, "request name");

            // ACT
            bool result = new Filter<Request>(equalsValue).Check(new Request() { Name = "request name" });

            // ASSERT
            Assert.True(result);
        }

        #endregion
    }
}
