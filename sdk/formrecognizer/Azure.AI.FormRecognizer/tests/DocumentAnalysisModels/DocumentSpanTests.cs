// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.FormRecognizer.DocumentAnalysis.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="DocumentSpan"/> class.
    /// </summary>
    internal class DocumentSpanTests
    {
        public void EqualsObjectReturnsFalseIfObjectIsNull()
        {
            var span = new DocumentSpan(10, 20);

            Assert.False(span.Equals(null));
        }

        [Test]
        public void EqualsObjectReturnsFalseIfObjectOfDifferentType()
        {
            var span = new DocumentSpan(10, 20);
            var tuple = (10, 20);

            Assert.False(span.Equals(tuple));
        }

        [Test]
        public void EqualsObjectReturnsFalseIfIndexDiffers()
        {
            var span = new DocumentSpan(10, 20);
            object objSpan = new DocumentSpan(11, 20);

            Assert.False(span.Equals(objSpan));
        }

        [Test]
        public void EqualsObjectReturnsFalseIfLengthDiffers()
        {
            var span = new DocumentSpan(10, 20);
            object objSpan = new DocumentSpan(10, 21);

            Assert.False(span.Equals(objSpan));
        }

        [Test]
        public void EqualsObjectReturnsTrueIfEqual()
        {
            var span = new DocumentSpan(10, 20);
            object objSpan = new DocumentSpan(10, 20);

            Assert.True(span.Equals(objSpan));
        }

        [Test]
        public void EqualsReturnsFalseIfIndexDiffers()
        {
            var span1 = new DocumentSpan(10, 20);
            var span2 = new DocumentSpan(11, 20);

            Assert.False(span1.Equals(span2));
        }

        [Test]
        public void EqualsReturnsFalseIfLengthDiffers()
        {
            var span1 = new DocumentSpan(10, 20);
            var span2 = new DocumentSpan(10, 21);

            Assert.False(span1.Equals(span2));
        }

        [Test]
        public void EqualsReturnsTrueIfEqual()
        {
            var span1 = new DocumentSpan(10, 20);
            var span2 = new DocumentSpan(10, 20);

            Assert.True(span1.Equals(span2));
        }

        [Test]
        public void GetHashCodeReturnsDifferentHashCodeIfIndexDiffers()
        {
            var span1 = new DocumentSpan(10, 20);
            var span2 = new DocumentSpan(11, 20);

            Assert.AreNotEqual(span1.GetHashCode(), span2.GetHashCode());
        }

        [Test]
        public void GetHashCodeReturnsDifferentHashCodeIfLengthDiffers()
        {
            var span1 = new DocumentSpan(10, 20);
            var span2 = new DocumentSpan(10, 21);

            Assert.AreNotEqual(span1.GetHashCode(), span2.GetHashCode());
        }

        [Test]
        public void GetHashCodeReturnsSameHashCodeIfEqual()
        {
            var span1 = new DocumentSpan(10, 20);
            var span2 = new DocumentSpan(10, 20);

            Assert.AreEqual(span1.GetHashCode(), span2.GetHashCode());
        }

        [Test]
        public void ToStringConvertsToExpectedFormat()
        {
            var span = new DocumentSpan(10, 20);

            Assert.AreEqual("Index: 10, Length: 20", span.ToString());
        }
    }
}
