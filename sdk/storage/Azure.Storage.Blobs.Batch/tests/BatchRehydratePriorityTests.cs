// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Blobs.Batch.Models;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Batch.Tests
{
    public class BatchRehydratePriorityTests
    {
        #region Constructor and ToString
        [Test]
        public void Constructor_SetsValue()
        {
            var priority = new BatchRehydratePriority("Custom");
            Assert.AreEqual("Custom", priority.ToString());
        }

        [Test]
        public void High_ReturnsHighValue()
        {
            Assert.AreEqual("High", BatchRehydratePriority.High.ToString());
        }

        [Test]
        public void Standard_ReturnsStandardValue()
        {
            Assert.AreEqual("Standard", BatchRehydratePriority.Standard.ToString());
        }
        #endregion

        #region Equality
        [Test]
        public void Equals_SameValue_ReturnsTrue()
        {
            var a = new BatchRehydratePriority("High");
            var b = new BatchRehydratePriority("High");
            Assert.IsTrue(a.Equals(b));
        }

        [Test]
        public void Equals_CaseInsensitive_ReturnsTrue()
        {
            var a = new BatchRehydratePriority("high");
            var b = new BatchRehydratePriority("HIGH");
            Assert.IsTrue(a.Equals(b));
        }

        [Test]
        public void Equals_DifferentValue_ReturnsFalse()
        {
            Assert.IsFalse(BatchRehydratePriority.High.Equals(BatchRehydratePriority.Standard));
        }

        [Test]
        public void Equals_Object_SameValue_ReturnsTrue()
        {
            object obj = new BatchRehydratePriority("High");
            Assert.IsTrue(BatchRehydratePriority.High.Equals(obj));
        }

        [Test]
        public void Equals_Object_WrongType_ReturnsFalse()
        {
            Assert.IsFalse(BatchRehydratePriority.High.Equals((object)42));
        }
        #endregion

        #region Operators
        [Test]
        public void EqualityOperator_SameValue_ReturnsTrue()
        {
            Assert.IsTrue(BatchRehydratePriority.High == new BatchRehydratePriority("High"));
        }

        [Test]
        public void InequalityOperator_DifferentValue_ReturnsTrue()
        {
            Assert.IsTrue(BatchRehydratePriority.High != BatchRehydratePriority.Standard);
        }

        [Test]
        public void InequalityOperator_SameValue_ReturnsFalse()
        {
            Assert.IsFalse(BatchRehydratePriority.High != new BatchRehydratePriority("High"));
        }
        #endregion

        #region Implicit Conversion
        [Test]
        public void ImplicitConversion_FromString()
        {
            BatchRehydratePriority priority = "High";
            Assert.AreEqual(BatchRehydratePriority.High, priority);
        }

        [Test]
        public void ImplicitConversion_FromString_ToNullable()
        {
            BatchRehydratePriority? priority = "Standard";
            Assert.IsNotNull(priority);
            Assert.AreEqual(BatchRehydratePriority.Standard, priority.Value);
        }

        [Test]
        public void ImplicitConversion_FromNull_ToNullable()
        {
            BatchRehydratePriority? priority = (string)null;
            Assert.IsTrue(priority.HasValue);
            Assert.IsNull(priority.Value.ToString());
        }
        #endregion

        #region GetHashCode
        [Test]
        public void GetHashCode_SameValue_SameHash()
        {
            Assert.AreEqual(BatchRehydratePriority.High.GetHashCode(), new BatchRehydratePriority("High").GetHashCode());
        }

        [Test]
        public void GetHashCode_CaseInsensitive_SameHash()
        {
            Assert.AreEqual(
                new BatchRehydratePriority("high").GetHashCode(),
                new BatchRehydratePriority("HIGH").GetHashCode());
        }

        [Test]
        public void GetHashCode_NullValue_ReturnsZero()
        {
            var priority = new BatchRehydratePriority(null);
            Assert.AreEqual(0, priority.GetHashCode());
        }
        #endregion
    }
}
