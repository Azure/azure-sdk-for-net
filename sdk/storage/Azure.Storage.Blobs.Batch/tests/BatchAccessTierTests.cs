// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Batch.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Batch.Tests
{
    public class BatchAccessTierTests
    {
        #region Static Properties and ToString
        [TestCase("P4")]
        [TestCase("P6")]
        [TestCase("P10")]
        [TestCase("P15")]
        [TestCase("P20")]
        [TestCase("P30")]
        [TestCase("P40")]
        [TestCase("P50")]
        [TestCase("P60")]
        [TestCase("P70")]
        [TestCase("P80")]
        [TestCase("Hot")]
        [TestCase("Cool")]
        [TestCase("Archive")]
        [TestCase("Premium")]
        [TestCase("Cold")]
        [TestCase("Smart")]
        public void KnownTier_RoundTrips(string value)
        {
            var tier = new BatchAccessTier(value);
            Assert.AreEqual(value, tier.ToString());
        }

        [Test]
        public void Constructor_CustomValue()
        {
            var tier = new BatchAccessTier("Custom");
            Assert.AreEqual("Custom", tier.ToString());
        }
        #endregion

        #region Equality
        [Test]
        public void Equals_SameValue_ReturnsTrue()
        {
            Assert.IsTrue(BatchAccessTier.Hot.Equals(new BatchAccessTier("Hot")));
        }

        [Test]
        public void Equals_CaseInsensitive_ReturnsTrue()
        {
            Assert.IsTrue(new BatchAccessTier("hot").Equals(new BatchAccessTier("HOT")));
        }

        [Test]
        public void Equals_DifferentValue_ReturnsFalse()
        {
            Assert.IsFalse(BatchAccessTier.Hot.Equals(BatchAccessTier.Cool));
        }

        [Test]
        public void Equals_Object_SameValue_ReturnsTrue()
        {
            object obj = new BatchAccessTier("Hot");
            Assert.IsTrue(BatchAccessTier.Hot.Equals(obj));
        }

        [Test]
        public void Equals_Object_WrongType_ReturnsFalse()
        {
            Assert.IsFalse(BatchAccessTier.Hot.Equals((object)42));
        }
        #endregion

        #region Operators
        [Test]
        public void EqualityOperator_SameValue_ReturnsTrue()
        {
            Assert.IsTrue(BatchAccessTier.Hot == new BatchAccessTier("Hot"));
        }

        [Test]
        public void InequalityOperator_DifferentValue_ReturnsTrue()
        {
            Assert.IsTrue(BatchAccessTier.Hot != BatchAccessTier.Cool);
        }

        [Test]
        public void InequalityOperator_SameValue_ReturnsFalse()
        {
            Assert.IsFalse(BatchAccessTier.Hot != new BatchAccessTier("Hot"));
        }
        #endregion

        #region Implicit Conversion
        [Test]
        public void ImplicitConversion_FromString()
        {
            BatchAccessTier tier = "Archive";
            Assert.AreEqual(BatchAccessTier.Archive, tier);
        }

        [Test]
        public void ImplicitConversion_FromString_ToNullable()
        {
            BatchAccessTier? tier = "Cool";
            Assert.IsNotNull(tier);
            Assert.AreEqual(BatchAccessTier.Cool, tier.Value);
        }

        [Test]
        public void ImplicitConversion_FromNull_ToNullable()
        {
            BatchAccessTier? tier = (string)null;
            Assert.IsTrue(tier.HasValue);
            Assert.IsNull(tier.Value.ToString());
        }
        #endregion

        #region GetHashCode
        [Test]
        public void GetHashCode_SameValue_SameHash()
        {
            Assert.AreEqual(BatchAccessTier.Hot.GetHashCode(), new BatchAccessTier("Hot").GetHashCode());
        }

        [Test]
        public void GetHashCode_CaseInsensitive_SameHash()
        {
            Assert.AreEqual(
                new BatchAccessTier("hot").GetHashCode(),
                new BatchAccessTier("HOT").GetHashCode());
        }

        [Test]
        public void GetHashCode_NullValue_ReturnsZero()
        {
            var tier = new BatchAccessTier(null);
            Assert.AreEqual(0, tier.GetHashCode());
        }
        #endregion
    }
}
