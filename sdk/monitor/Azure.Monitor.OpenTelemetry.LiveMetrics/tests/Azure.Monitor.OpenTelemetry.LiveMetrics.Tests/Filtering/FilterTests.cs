namespace Microsoft.ApplicationInsights.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using Microsoft.ApplicationInsights.DataContracts;
    using Microsoft.ApplicationInsights.Extensibility.Filtering;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Filter tests.
    /// </summary>
    [TestClass]
    public class FilterTests
    {
        #region Input validation
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterThrowsWhenComparandIsNull()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.Equal, Comparand = null };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterThrowsWhenFieldNameIsEmpty()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = string.Empty, Predicate = Predicate.Equal, Comparand = "abc" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterThrowsWhenFieldNameDoesNotExistInType()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NonExistentFieldName", Predicate = Predicate.Equal, Comparand = "abc" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }
        #endregion

        #region Filtering

        #region Boolean

        [TestMethod]
        public void FilterBooleanEqual()
        {
            // ARRANGE
            var equalsTrue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.Equal, Comparand = "true" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { BooleanField = true });
            bool result2 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { BooleanField = false });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterBooleanNotEqual()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.NotEqual, Comparand = "true" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(notEqualTrue).Check(new TelemetryMock() { BooleanField = true });
            bool result2 = new Filter<TelemetryMock>(notEqualTrue).Check(new TelemetryMock() { BooleanField = false });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.GreaterThan, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.LessThan, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.LessThanOrEqual, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.Contains, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.DoesNotContain, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterBooleanGarbageComparand()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo() { FieldName = "BooleanField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(notEqualTrue);

            // ASSERT
        }

        #endregion

        #region Nullable<Boolean>

        [TestMethod]
        public void FilterNullableBooleanEqual()
        {
            // ARRANGE
            var equalsTrue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.Equal, Comparand = "true" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { NullableBooleanField = true });
            bool result2 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { NullableBooleanField = false });
            bool result3 = new Filter<TelemetryMock>(equalsTrue).Check(new TelemetryMock() { NullableBooleanField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterNullableBooleanNotEqual()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.NotEqual, Comparand = "true" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(notEqualTrue).Check(new TelemetryMock() { NullableBooleanField = true });
            bool result2 = new Filter<TelemetryMock>(notEqualTrue).Check(new TelemetryMock() { NullableBooleanField = false });
            bool result3 = new Filter<TelemetryMock>(notEqualTrue).Check(new TelemetryMock() { NullableBooleanField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.GreaterThan, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.LessThan, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.LessThanOrEqual, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.Contains, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.DoesNotContain, Comparand = "true" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableBooleanGarbageComparand()
        {
            // ARRANGE
            var notEqualTrue = new FilterInfo() { FieldName = "NullableBooleanField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(notEqualTrue);

            // ASSERT
        }
        #endregion

        #region Int

        [TestMethod]
        public void FilterIntEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.Equal, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 123 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 124 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterIntNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.NotEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 123 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 124 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void FilterIntGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.GreaterThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 122 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 123 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterIntLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.LessThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 122 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 123 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterIntGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 122 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 123 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterIntLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.LessThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 122 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 123 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterIntContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.Contains, Comparand = "2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 152 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 160 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterIntDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.DoesNotContain, Comparand = "2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 152 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { IntField = 160 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterIntGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "IntField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        #endregion

        #region Nullable<Int>

        [TestMethod]
        public void FilterNullableIntEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableIntField", Predicate = Predicate.Equal, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 123 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterNullableIntNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableIntField", Predicate = Predicate.NotEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 123 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterNullableIntGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableIntField", Predicate = Predicate.GreaterThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 122 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 123 });
            bool result4 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterNullableIntLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableIntField", Predicate = Predicate.LessThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 122 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 123 });
            bool result4 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterNullableIntGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableIntField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 122 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 123 });
            bool result4 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterNullableIntLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableIntField", Predicate = Predicate.LessThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 122 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 123 });
            bool result4 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterNullableIntContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableIntField", Predicate = Predicate.Contains, Comparand = "2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 152 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 160 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterNullableIntDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableIntField", Predicate = Predicate.DoesNotContain, Comparand = "2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 152 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = 160 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableIntField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableIntGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableIntField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        #endregion

        #region Double

        [TestMethod]
        public void FilterDoubleEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.Equal, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 124 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterDoubleNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.NotEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 124 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void FilterDoubleGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.GreaterThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 122.5 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123.5 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterDoubleLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.LessThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 122.5 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123.5 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterDoubleGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 122.5 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123.5 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterDoubleLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.LessThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 122.5 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123.5 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 123 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterDoubleContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.Contains, Comparand = "2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 157.2 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 160 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterDoubleDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.DoesNotContain, Comparand = "2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 157.2 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { DoubleField = 160 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterDoubleGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        #endregion

        #region Nullable<Double>

        [TestMethod]
        public void FilterNullableNullableDoubleEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableDoubleField", Predicate = Predicate.Equal, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 123 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterNullableDoubleNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableDoubleField", Predicate = Predicate.NotEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 123 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 124 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterNullableDoubleGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableDoubleField", Predicate = Predicate.GreaterThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 122.5 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 123.5 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 123 });
            bool result4 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterNullableDoubleLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableDoubleField", Predicate = Predicate.LessThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 122.5 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 123.5 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 123 });
            bool result4 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterNullableDoubleGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableDoubleField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 122.5 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 123.5 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 123 });
            bool result4 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterNullableDoubleLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableDoubleField", Predicate = Predicate.LessThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 122.5 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 123.5 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 123 });
            bool result4 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterNullableDoubleContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableDoubleField", Predicate = Predicate.Contains, Comparand = "2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 157.2 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 160 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterNullableDoubleDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableDoubleField", Predicate = Predicate.DoesNotContain, Comparand = "2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 157.2 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = 160 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableDoubleField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterNullableDoubleGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableDoubleField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        #endregion

        #region TimeSpan

        [TestMethod]
        public void FilterTimeSpanEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.Equal, Comparand = "123" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123", CultureInfo.InvariantCulture) });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("124", CultureInfo.InvariantCulture) });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterTimeSpanNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.NotEqual, Comparand = "123" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123", CultureInfo.InvariantCulture) });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("124", CultureInfo.InvariantCulture) });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void FilterTimeSpanGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.GreaterThan, Comparand = "123" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("122.05:00", CultureInfo.InvariantCulture) });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123.05:00", CultureInfo.InvariantCulture) });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123", CultureInfo.InvariantCulture) });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterTimeSpanLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.LessThan, Comparand = "123" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("122.05:00", CultureInfo.InvariantCulture) });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123.05:00", CultureInfo.InvariantCulture) });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123", CultureInfo.InvariantCulture) });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterTimeSpanGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "123" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("122.05:00", CultureInfo.InvariantCulture) });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123.05:00", CultureInfo.InvariantCulture) });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123", CultureInfo.InvariantCulture) });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterTimeSpanLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.LessThanOrEqual, Comparand = "123" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("122.05:00", CultureInfo.InvariantCulture) });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123.05:00", CultureInfo.InvariantCulture) });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { TimeSpanField = TimeSpan.Parse("123", CultureInfo.InvariantCulture) });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterTimeSpanContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.Contains, Comparand = "2" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterTimeSpanDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "TimeSpanField", Predicate = Predicate.DoesNotContain, Comparand = "2" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterTimeSpanGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "DoubleField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        #endregion

        #region String

        [TestMethod]
        public void FilterStringEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.Equal, Comparand = "abc" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "abc" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "aBc" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "abc1" });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterStringNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.NotEqual, Comparand = "abc" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "abc" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "aBc" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "abc1" });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterStringGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.GreaterThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "122.5" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123.5" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123" });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterStringLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.LessThan, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "122.5" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123.5" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123" });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterStringGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "122.5" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123.5" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123" });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterStringLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.LessThanOrEqual, Comparand = "123.0" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "122.5" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123.5" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123" });
            
            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterStringContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.Contains, Comparand = "abc" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "1abc2" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "1aBc2" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123" });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterStringDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.DoesNotContain, Comparand = "abc" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "1abc2" });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "1aBc2" });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "123" });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterStringGarbageFieldValue()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.LessThan, Comparand = "123.0" };

            // ACT
            bool result = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { StringField = "Not at all a number" });

            // ASSERT
            Assert.IsFalse(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterStringGarbageComparandValue()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "StringField", Predicate = Predicate.LessThan, Comparand = "Not a number at all" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        #endregion

        #region Uri

        [TestMethod]
        public void FilterUriEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "UriField", Predicate = Predicate.Equal, Comparand = "http://microsoft.com/a" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://microsoft.com/a") });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://micrOSOft.com/a") });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://microsoft.com/a/b") });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterUriNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "UriField", Predicate = Predicate.NotEqual, Comparand = "http://microsoft.com/a" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://microsoft.com/a") });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://micrOSOft.com/a") });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://microsoft.com/a/b") });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterUriGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "UriField", Predicate = Predicate.GreaterThan, Comparand = "http://microsoft.com/a" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterUriLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "UriField", Predicate = Predicate.LessThan, Comparand = "http://microsoft.com/a" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterUriLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "UriField", Predicate = Predicate.LessThanOrEqual, Comparand = "http://microsoft.com/a" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterUriGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "UriField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "http://microsoft.com/a" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        [TestMethod]
        public void FilterUriContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "UriField", Predicate = Predicate.Contains, Comparand = "microsoft" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://microsoft.com/a") });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://micrOSOft.com/a") });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://a.com") });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterUriDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "UriField", Predicate = Predicate.DoesNotContain, Comparand = "microsoft" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://microsoft.com/a") });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://micrOSOft.com/a") });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://a.com") });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterUriGarbageFieldValue()
        {
            // ARRANGE
            var doesNotContainValue = new FilterInfo() { FieldName = "UriField", Predicate = Predicate.Contains, Comparand = "microsoft" };
            var containsValue = new FilterInfo() { FieldName = "UriField", Predicate = Predicate.Contains, Comparand = string.Empty };

            // ACT
            bool result1 = new Filter<TelemetryMock>(doesNotContainValue).Check(new TelemetryMock() { UriField = null });
            bool result2 = new Filter<TelemetryMock>(containsValue).Check(new TelemetryMock() { UriField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void FilterUriGarbageComparandValue()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "UriField", Predicate = Predicate.Contains, Comparand = "Not at all a URI" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { UriField = new Uri("http://microsoft.com/a") });
            
            // ASSERT
            Assert.IsFalse(result1);
        }

        #endregion

        #region Enum

        [TestMethod]
        public void FilterEnumEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "EnumField", Predicate = Predicate.Equal, Comparand = "Value1" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value2 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }
        
        [TestMethod]
        public void FilterEnumNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "EnumField", Predicate = Predicate.NotEqual, Comparand = "Value1" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value2 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void FilterEnumGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "EnumField", Predicate = Predicate.GreaterThan, Comparand = "Value2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value2 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value3 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterEnumLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "EnumField", Predicate = Predicate.LessThan, Comparand = "Value2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value2 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value3 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterEnumGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "EnumField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "Value2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value2 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value3 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterEnumLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "EnumField", Predicate = Predicate.LessThanOrEqual, Comparand = "Value2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value2 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value3 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterEnumContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "EnumField", Predicate = Predicate.Contains, Comparand = "1" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value2 });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void FilterEnumDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "EnumField", Predicate = Predicate.DoesNotContain, Comparand = "1" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { EnumField = TelemetryMock.EnumType.Value2 });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void FilterEnumGarbageComparand()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "EnumField", Predicate = Predicate.Equal, Comparand = "garbage" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);

            // ASSERT
        }

        #endregion

        #region Nullable<Enum>

        [TestMethod]
        public void FilterNullableEnumEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableEnumField", Predicate = Predicate.Equal, Comparand = "Value1" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value2 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterNullableEnumNotEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableEnumField", Predicate = Predicate.NotEqual, Comparand = "Value1" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value2 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        public void FilterNullableEnumGreaterThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableEnumField", Predicate = Predicate.GreaterThan, Comparand = "Value2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value2 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value3 });
            bool result4 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterNullableEnumLessThan()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableEnumField", Predicate = Predicate.LessThan, Comparand = "Value2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value2 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value3 });
            bool result4 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterNullableEnumGreaterThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableEnumField", Predicate = Predicate.GreaterThanOrEqual, Comparand = "Value2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value2 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value3 });
            bool result4 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterNullableEnumLessThanOrEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableEnumField", Predicate = Predicate.LessThanOrEqual, Comparand = "Value2" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value2 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value3 });
            bool result4 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterNullableEnumContains()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableEnumField", Predicate = Predicate.Contains, Comparand = "1" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value2 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = null });

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterNullableEnumDoesNotContain()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "NullableEnumField", Predicate = Predicate.DoesNotContain, Comparand = "1" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value1 });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = TelemetryMock.EnumType.Value2 });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { NullableEnumField = null });

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }

        #endregion

        #region Train wreck fields

        [TestMethod]
        public void FilterTrainEqual()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "Context.Operation.Name", Predicate = Predicate.Equal, Comparand = "ImportantOperation" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock());
            bool result2 =
                new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { Context = { Operation = { Name = "ImportantOperation" } } });
            bool result3 =
                new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { Context = { Operation = { Name = "ImportantOperation1" } } });
            
            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterTrainNonExistentCar()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "Context.NonExistentField.Name", Predicate = Predicate.Equal, Comparand = "ImportantOperation" };

            // ACT
            new Filter<TelemetryMock>(equalsValue);
            
            // ASSERT
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FilterTrainWreckRuntimeNull()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "ContextMock.Operation.Name", Predicate = Predicate.Equal, Comparand = "ImportantOperation" };

            // ACT
            new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { ContextMock = null });
           
            // ASSERT
        }
        #endregion

        #region Custom dimensions
        [TestMethod]
        public void FilterCustomDimensions()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "CustomDimensions.Dimension.1", Predicate = Predicate.Equal, Comparand = "abc" };
            
            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { Properties = { ["Dimension.1"] = "abc" } });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { Properties = { ["Dimension.1"] = "abcd" } });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock());
            
            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterCustomMetrics()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "CustomMetrics.Metric.1", Predicate = Predicate.Equal, Comparand = "1.5" };

            // ACT
            bool result1 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { Metrics = { ["Metric.1"] = 1.5d } });
            bool result2 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock() { Metrics = { ["Metric.1"] = 1.6d } });
            bool result3 = new Filter<TelemetryMock>(equalsValue).Check(new TelemetryMock());

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }
        #endregion

        #region Asterisk
        [TestMethod]
        public void FilterAsteriskLimitsAcceptablePredicateValues()
        {
            // ARRANGE
            var acceptedPredicates = new List<Predicate>();

            // ACT
            foreach (Predicate predicate in Enum.GetValues(typeof(Predicate)))
            {
                try
                {
                    new Filter<TelemetryMock>(new FilterInfo() { FieldName = "*", Predicate = predicate, Comparand = "123" });

                    acceptedPredicates.Add(predicate);
                }
                catch (ArgumentOutOfRangeException)
                {
                }
            }

            // ASSERT
            Assert.AreEqual(2, acceptedPredicates.Count);
            Assert.AreEqual(Predicate.Contains, acceptedPredicates[0]);
            Assert.AreEqual(Predicate.DoesNotContain, acceptedPredicates[1]);
        }

        [TestMethod]
        public void FilterAsteriskPropertyContains()
        {
            // ARRANGE
            var filterInfo = new FilterInfo() { FieldName = "*", Predicate = Predicate.Contains, Comparand = "123" };
            Filter<TelemetryMock> filter = new Filter<TelemetryMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new TelemetryMock() { IntField = 1234 });
            bool result2 = filter.Check(new TelemetryMock() { DoubleField = 1234 });
            bool result3 = filter.Check(new TelemetryMock() { StringField = "1234" });
            bool result4 = filter.Check(new TelemetryMock() { UriField = new Uri("http://microsoft.com/123") });

            bool result5 = filter.Check(new TelemetryMock() { IntField = 12234 });
            bool result6 = filter.Check(new TelemetryMock() { DoubleField = 12234 });
            bool result7 = filter.Check(new TelemetryMock() { StringField = "12234" });
            bool result8 = filter.Check(new TelemetryMock() { UriField = new Uri("http://microsoft.com/1223") });

            bool result9 = filter.Check(new TelemetryMock());

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(result4);

            Assert.IsFalse(result5);
            Assert.IsFalse(result6);
            Assert.IsFalse(result7);
            Assert.IsFalse(result8);

            Assert.IsFalse(result9);
        }

        [TestMethod]
        public void FilterAsteriskPropertyDoesNotContain()
        {
            // ARRANGE
            var filterInfo = new FilterInfo() { FieldName = "*", Predicate = Predicate.DoesNotContain, Comparand = "123" };
            Filter<TelemetryMock> filter = new Filter<TelemetryMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new TelemetryMock() { IntField = 1234 });
            bool result2 = filter.Check(new TelemetryMock() { DoubleField = 1234 });
            bool result3 = filter.Check(new TelemetryMock() { StringField = "1234" });
            bool result4 = filter.Check(new TelemetryMock() { UriField = new Uri("http://microsoft.com/123") });

            bool result5 = filter.Check(new TelemetryMock() { IntField = 12234 });
            bool result6 = filter.Check(new TelemetryMock() { DoubleField = 12234 });
            bool result7 = filter.Check(new TelemetryMock() { StringField = "12234" });
            bool result8 = filter.Check(new TelemetryMock() { UriField = new Uri("http://microsoft.com/1223") });

            bool result9 = filter.Check(new TelemetryMock());

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);

            Assert.IsTrue(result5);
            Assert.IsTrue(result6);
            Assert.IsTrue(result7);
            Assert.IsTrue(result8);

            Assert.IsTrue(result9);
        }

        [TestMethod]
        public void FilterAsteriskCustomDimensionContains()
        {
            // ARRANGE
            var filterInfo = new FilterInfo() { FieldName = "*", Predicate = Predicate.Contains, Comparand = "123" };
            Filter<TelemetryMock> filter = new Filter<TelemetryMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new TelemetryMock() { Properties = { { "Prop1", "1234" } } });
            bool result2 = filter.Check(new TelemetryMock() { Properties = { { "Prop1", "12234" } } });
            bool result3 = filter.Check(new TelemetryMock() { Properties = { { "Prop1", null } } });
            bool result4 = filter.Check(new TelemetryMock());

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
            Assert.IsFalse(result4);
        }

        [TestMethod]
        public void FilterAsteriskCustomMetricsContains()
        {
            // ARRANGE
            var filterInfo = new FilterInfo() { FieldName = "*", Predicate = Predicate.Contains, Comparand = "123" };
            Filter<TelemetryMock> filter = new Filter<TelemetryMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new TelemetryMock() { Metrics = { { "Metric1", 1234 } } });
            bool result2 = filter.Check(new TelemetryMock() { Metrics = { { "Metric1", 12234 } } });
            bool result3 = filter.Check(new TelemetryMock());

            // ASSERT
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void FilterAsteriskCustomDimensionDoesNotContain()
        {
            // ARRANGE
            var filterInfo = new FilterInfo() { FieldName = "*", Predicate = Predicate.DoesNotContain, Comparand = "123" };
            Filter<TelemetryMock> filter = new Filter<TelemetryMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new TelemetryMock() { Properties = { { "Prop1", "1234" } } });
            bool result2 = filter.Check(new TelemetryMock() { Properties = { { "Prop1", "12234" } } });
            bool result3 = filter.Check(new TelemetryMock() { Properties = { { "Prop1", null } } });
            bool result4 = filter.Check(new TelemetryMock());

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(result4);
        }

        [TestMethod]
        public void FilterAsteriskCustomMetricsDoesNotContain()
        {
            // ARRANGE
            var filterInfo = new FilterInfo() { FieldName = "*", Predicate = Predicate.DoesNotContain, Comparand = "123" };
            Filter<TelemetryMock> filter = new Filter<TelemetryMock>(filterInfo);

            // ACT
            bool result1 = filter.Check(new TelemetryMock() { Metrics = { { "Metric1", 1234 } } });
            bool result2 = filter.Check(new TelemetryMock() { Metrics = { { "Metric1", 12234 } } });
            bool result3 = filter.Check(new TelemetryMock());

            // ASSERT
            Assert.IsFalse(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
        }
        #endregion

        #endregion

        #region Support for actual telemetry types

        ////!!! enumerate real telemetry type's properties through reflection and explicitly state which ones we don't support
        [TestMethod]
        public void FilterSupportsRequestTelemetry()
        {
            // ARRANGE
            var equalsValue = new FilterInfo() { FieldName = "Name", Predicate = Predicate.Equal, Comparand = "request name" };

            // ACT
            bool result = new Filter<RequestTelemetry>(equalsValue).Check(new RequestTelemetry() { Name = "request name" });

            // ASSERT
            Assert.IsTrue(result);
        }

        #endregion
    }
}