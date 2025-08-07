// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering;
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
            Assert.Throws<ArgumentNullException>(() => new FilterInfo("BooleanField", PredicateType.Equal, null));
        }

        [Fact]
        public void FilterThrowsWhenFieldNameIsEmpty()
        {
            // ARRANGE
            var equalsValue = new FilterInfo(string.Empty, PredicateType.Equal, "abc");

            // ACT, ASSERT
            Assert.Throws<ArgumentNullException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterThrowsWhenFieldNameDoesNotExistInType()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NonExistentFieldName", PredicateType.Equal, "abc");

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
            var equalsTrue = new FilterInfo("BooleanField", PredicateType.Equal, "true");

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
            var notEqualTrue = new FilterInfo("BooleanField", PredicateType.NotEqual, "true");

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
            PredicateType predicate = new PredicateType(predicateString);
            // ARRANGE
            var equalsValue = new FilterInfo("BooleanField", predicate, "true");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterBooleanGarbageComparand()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo("BooleanField", PredicateType.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(notEqualTrue));
        }

        #endregion

        #region Nullable<Boolean>

        [Fact]
        public void FilterNullableBooleanEqual()
        {
            // ARRANGE
            var equalsTrue = new FilterInfo("NullableBooleanField", PredicateType.Equal, "true");

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
            var notEqualTrue = new FilterInfo("NullableBooleanField", PredicateType.NotEqual, "true");

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
            PredicateType predicate = new PredicateType(predicateString);
            // ARRANGE
            var equalsValue = new FilterInfo("NullableBooleanField", predicate, "true");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterNullableBooleanGarbageComparand()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo("NullableBooleanField", PredicateType.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(notEqualTrue));
        }
        #endregion

        #region Int

        [Fact]
        public void FilterIntEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("IntField", PredicateType.Equal, "123.0");

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
            var equalsValue = new FilterInfo("IntField", PredicateType.NotEqual, "123.0");

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
            var equalsValue = new FilterInfo("IntField", PredicateType.GreaterThan, "123.0");

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
            var equalsValue = new FilterInfo("IntField", PredicateType.LessThan, "123.0");

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
            var equalsValue = new FilterInfo("IntField", PredicateType.GreaterThanOrEqual, "123.0");

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
            var equalsValue = new FilterInfo("IntField", PredicateType.LessThanOrEqual, "123.0");

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
            var equalsValue = new FilterInfo("IntField", PredicateType.Contains, "2");

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
            var equalsValue = new FilterInfo("IntField", PredicateType.DoesNotContain, "2");

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
            var equalsValue = new FilterInfo("IntField", PredicateType.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region Nullable<Int>

        [Fact]
        public void FilterNullableIntEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableIntField", PredicateType.Equal, "123.0");

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
            var equalsValue = new FilterInfo("NullableIntField", PredicateType.NotEqual, "123.0");

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
            var equalsValue = new FilterInfo("NullableIntField", PredicateType.GreaterThan, "123.0");

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
            var equalsValue = new FilterInfo("NullableIntField", PredicateType.LessThan, "123.0");

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
            var equalsValue = new FilterInfo("NullableIntField", PredicateType.GreaterThanOrEqual, "123.0");

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
            var equalsValue = new FilterInfo("NullableIntField", PredicateType.LessThanOrEqual, "123.0");

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
            var equalsValue = new FilterInfo("NullableIntField", PredicateType.Contains, "2");

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
            var equalsValue = new FilterInfo("NullableIntField", PredicateType.DoesNotContain, "2");

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
            var equalsValue = new FilterInfo("NullableIntField", PredicateType.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region Double

        [Fact]
        public void FilterDoubleEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("DoubleField", PredicateType.Equal, "123.0");

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
            var equalsValue = new FilterInfo("DoubleField", PredicateType.NotEqual, "123.0");

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
            var equalsValue = new FilterInfo("DoubleField", PredicateType.GreaterThan, "123.0");

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
            var equalsValue = new FilterInfo("DoubleField", PredicateType.LessThan, "123.0");

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
            var equalsValue = new FilterInfo("DoubleField", PredicateType.GreaterThanOrEqual, "123.0");

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
            var equalsValue = new FilterInfo("DoubleField", PredicateType.LessThanOrEqual, "123.0");

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
            var equalsValue = new FilterInfo("DoubleField", PredicateType.Contains, "2");

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
            var equalsValue = new FilterInfo("DoubleField", PredicateType.DoesNotContain, "2");

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
            var equalsValue = new FilterInfo("DoubleField", PredicateType.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region Nullable<Double>

        [Fact]
        public void FilterNullableNullableDoubleEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableDoubleField", PredicateType.Equal, "123.0");

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
            var equalsValue = new FilterInfo("NullableDoubleField", PredicateType.NotEqual, "123.0");

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
            var equalsValue = new FilterInfo("NullableDoubleField", PredicateType.GreaterThan, "123.0");

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
            var equalsValue = new FilterInfo("NullableDoubleField", PredicateType.LessThan, "123.0");

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
            var equalsValue = new FilterInfo("NullableDoubleField", PredicateType.GreaterThanOrEqual, "123.0");

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
            var equalsValue = new FilterInfo("NullableDoubleField", PredicateType.LessThanOrEqual, "123.0");

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
            var equalsValue = new FilterInfo("NullableDoubleField", PredicateType.Contains, "2");

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
            var equalsValue = new FilterInfo("NullableDoubleField", PredicateType.DoesNotContain, "2");

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
            var equalsValue = new FilterInfo("NullableDoubleField", PredicateType.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region TimeSpan

        [Fact]
        public void FilterTimeSpanEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("TimeSpanField", PredicateType.Equal, "123");

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
            var equalsValue = new FilterInfo("TimeSpanField", PredicateType.NotEqual, "123");

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
            var equalsValue = new FilterInfo("TimeSpanField", PredicateType.GreaterThan, "123");

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
            var equalsValue = new FilterInfo("TimeSpanField", PredicateType.LessThan, "123");

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
            var equalsValue = new FilterInfo("TimeSpanField", PredicateType.GreaterThanOrEqual, "123");

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
            var equalsValue = new FilterInfo("TimeSpanField", PredicateType.LessThanOrEqual, "123");

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
            var equalsValue = new FilterInfo("TimeSpanField", PredicateType.Contains, "2");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterTimeSpanDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("TimeSpanField", PredicateType.DoesNotContain, "2");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterTimeSpanGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("DoubleField", PredicateType.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterDurationAsString()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("Duration", PredicateType.Equal, "123");

            // ACT
            bool result1 = new Filter<DocumentMockWithStringDuration>(equalsValue).Check(new DocumentMockWithStringDuration(TimeSpan.Parse("123", CultureInfo.InvariantCulture).ToString()));
            bool result2 = new Filter<DocumentMockWithStringDuration>(equalsValue).Check(new DocumentMockWithStringDuration(TimeSpan.Parse("124", CultureInfo.InvariantCulture).ToString()));

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
        }
        #endregion

        #region String

        [Fact]
        public void FilterStringEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("StringField", PredicateType.Equal, "abc");

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
            var equalsValue = new FilterInfo("StringField", PredicateType.NotEqual, "abc");

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
            var equalsValue = new FilterInfo("StringField", PredicateType.GreaterThan, "123.0");

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
            var equalsValue = new FilterInfo("StringField", PredicateType.LessThan, "123.0");

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
            var equalsValue = new FilterInfo("StringField", PredicateType.GreaterThanOrEqual, "123.0");

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
            var equalsValue = new FilterInfo("StringField", PredicateType.LessThanOrEqual, "123.0");

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
            var equalsValue = new FilterInfo("StringField", PredicateType.Contains, "abc");

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
            var equalsValue = new FilterInfo("StringField", PredicateType.DoesNotContain, "abc");

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
            var equalsValue = new FilterInfo("StringField", PredicateType.LessThan, "123.0");

            // ACT
            bool result = new Filter<DocumentMock>(equalsValue).Check(new DocumentMock() { StringField = "Not at all a number" });

            // ASSERT
            Assert.False(result);
        }

        [Fact]
        public void FilterStringGarbageComparandValue()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("StringField", PredicateType.LessThan, "Not a number at all");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region Uri

        [Fact]
        public void FilterUriEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", PredicateType.Equal, "http://microsoft.com/a");

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
            var equalsValue = new FilterInfo("UriField", PredicateType.NotEqual, "http://microsoft.com/a");

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
            var equalsValue = new FilterInfo("UriField", PredicateType.GreaterThan, "http://microsoft.com/a");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterUriLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", PredicateType.LessThan, "http://microsoft.com/a");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterUriLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", PredicateType.LessThanOrEqual, "http://microsoft.com/a");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterUriGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", PredicateType.GreaterThanOrEqual, "http://microsoft.com/a");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        [Fact]
        public void FilterUriContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("UriField", PredicateType.Contains, "microsoft");

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
            var equalsValue = new FilterInfo("UriField", PredicateType.DoesNotContain, "microsoft");

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
            var doesNotContainValue = new FilterInfo("UriField", PredicateType.Contains, "microsoft");
            var containsValue = new FilterInfo("UriField", PredicateType.Contains, string.Empty);

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
            var equalsValue = new FilterInfo("UriField", PredicateType.Contains, "Not at all a URI");

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
            var equalsValue = new FilterInfo("EnumField", PredicateType.Equal, "Value1");

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
            var equalsValue = new FilterInfo("EnumField", PredicateType.NotEqual, "Value1");

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
            var equalsValue = new FilterInfo("EnumField", PredicateType.GreaterThan, "Value2");

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
            var equalsValue = new FilterInfo("EnumField", PredicateType.LessThan, "Value2");

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
            var equalsValue = new FilterInfo("EnumField", PredicateType.GreaterThanOrEqual, "Value2");

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
            var equalsValue = new FilterInfo("EnumField", PredicateType.LessThanOrEqual, "Value2");

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
            var equalsValue = new FilterInfo("EnumField", PredicateType.Contains, "1");

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
            var equalsValue = new FilterInfo("EnumField", PredicateType.DoesNotContain, "1");

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
            var equalsValue = new FilterInfo("EnumField", PredicateType.Equal, "garbage");

            // ACT, ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new Filter<DocumentMock>(equalsValue));
        }

        #endregion

        #region Nullable<Enum>

        [Fact]
        public void FilterNullableEnumEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("NullableEnumField", PredicateType.Equal, "Value1");

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
            var equalsValue = new FilterInfo("NullableEnumField", PredicateType.NotEqual, "Value1");

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
            var equalsValue = new FilterInfo("NullableEnumField", PredicateType.GreaterThan, "Value2");

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
            var equalsValue = new FilterInfo("NullableEnumField", PredicateType.LessThan, "Value2");

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
            var equalsValue = new FilterInfo("NullableEnumField", PredicateType.GreaterThanOrEqual, "Value2");

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
            var equalsValue = new FilterInfo("NullableEnumField", PredicateType.LessThanOrEqual, "Value2");

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
            var equalsValue = new FilterInfo("NullableEnumField", PredicateType.Contains, "1");

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
            var equalsValue = new FilterInfo("NullableEnumField", PredicateType.DoesNotContain, "1");

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

        #region Custom dimensions
        [Fact]
        public void FilterCustomDimensions()
        {
            // ARRANGE
            var equalsValue = new FilterInfo("CustomDimensions.Dimension.1", PredicateType.Equal, "abc");

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
            var equalsValue = new FilterInfo("CustomMetrics.Metric.1", PredicateType.Equal, "1.5");

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
                    PredicateType PredicateType = new PredicateType(predicate.ToString());
                    new Filter<DocumentMock>(new FilterInfo("*", PredicateType, "123"));

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
            var filterInfo = new FilterInfo("*", PredicateType.Contains, "123");
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
            var filterInfo = new FilterInfo("*", PredicateType.DoesNotContain, "123");
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

        [Fact]
        public void FilterAsteriskCustomDimensionContains()
        {
            // ARRANGE
            var filterInfo = new FilterInfo("*", PredicateType.Contains, "123");
            Filter<DocumentMock> filter = new Filter<DocumentMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Prop1", "1234") }));
            bool result2 = filter.Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Prop1", "12234") }));
            // bool result3 = filter.Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Prop1", null) })); // null is not supported in the new models.
            bool result4 = filter.Check(new DocumentMock());

            // ASSERT
            Assert.True(result1);
            Assert.False(result2);
            //Assert.False(result3);
            Assert.False(result4);
        }

        [Fact]
        public void FilterAsteriskCustomMetricsContains()
        {
            // ARRANGE
            var filterInfo = new FilterInfo("*", PredicateType.Contains, "123");
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

        [Fact]
        public void FilterAsteriskCustomDimensionDoesNotContain()
        {
            // ARRANGE
            var filterInfo = new FilterInfo("*", PredicateType.DoesNotContain, "123");
            Filter<DocumentMock> filter = new Filter<DocumentMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Prop1", "1234") }));
            bool result2 = filter.Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Prop1", "12234") }));
            //bool result3 = filter.Check(new DocumentMock(new List<KeyValuePairString>() { new KeyValuePairString("Prop1", null) })); // null is not supported in the new models.
            bool result4 = filter.Check(new DocumentMock());

            // ASSERT
            Assert.False(result1);
            Assert.True(result2);
            //Assert.True(result3);
            Assert.True(result4);
        }

        [Fact]
        public void FilterAsteriskCustomMetricsDoesNotContain()
        {
            // ARRANGE
            var filterInfo = new FilterInfo("*", PredicateType.DoesNotContain, "123");
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
            var equalsValue = new FilterInfo("Name", PredicateType.Equal, "request name");

            // ACT
            bool result = new Filter<Request>(equalsValue).Check(new Request() { Name = "request name" });

            // ASSERT
            Assert.True(result);
        }

        #endregion

        [Fact]
        public void GetFieldType_CorrectlyDiscoversNestedType()
        {
            // ARRANGE
            string fieldName = "Parent.Child.GrandChild";

            // ACT
            Filter<DocumentMockWithNestedProperties>.FieldNameType fieldNameType;
            Type result = Filter<DocumentMockWithNestedProperties>.GetFieldType(fieldName, out fieldNameType);

            // ASSERT
            Assert.Equal(typeof(string), result);
            Assert.Equal(Filter<DocumentMockWithNestedProperties>.FieldNameType.FieldName, fieldNameType);
        }

        internal class DocumentMockWithNestedProperties : DocumentIngress
        {
            public ParentType Parent { get; set; } = new ParentType();

            public class ParentType
            {
                public ChildType Child { get; set; } = new ChildType();

                public class ChildType
                {
                    public string GrandChild { get; set; } = "TestValue";
                }
            }
        }
    }
}
