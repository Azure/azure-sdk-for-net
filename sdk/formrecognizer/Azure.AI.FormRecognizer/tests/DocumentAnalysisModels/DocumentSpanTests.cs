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

            Assert.That(span.Equals(null), Is.False);
        }

        [Test]
        public void EqualsObjectReturnsFalseIfObjectOfDifferentType()
        {
            var span = new DocumentSpan(10, 20);
            var tuple = (10, 20);

            Assert.That(span.Equals(tuple), Is.False);
        }

        [Test]
        public void EqualsObjectReturnsFalseIfIndexDiffers()
        {
            var span = new DocumentSpan(10, 20);
            object objSpan = new DocumentSpan(11, 20);

            Assert.That(span.Equals(objSpan), Is.False);
        }

        [Test]
        public void EqualsObjectReturnsFalseIfLengthDiffers()
        {
            var span = new DocumentSpan(10, 20);
            object objSpan = new DocumentSpan(10, 21);

            Assert.That(span.Equals(objSpan), Is.False);
        }

        [Test]
        public void EqualsObjectReturnsTrueIfEqual()
        {
            var span = new DocumentSpan(10, 20);
            object objSpan = new DocumentSpan(10, 20);

            Assert.That(span.Equals(objSpan), Is.True);
        }

        [Test]
        public void EqualsReturnsFalseIfIndexDiffers()
        {
            var span1 = new DocumentSpan(10, 20);
            var span2 = new DocumentSpan(11, 20);

            Assert.That(span1.Equals(span2), Is.False);
        }

        [Test]
        public void EqualsReturnsFalseIfLengthDiffers()
        {
            var span1 = new DocumentSpan(10, 20);
            var span2 = new DocumentSpan(10, 21);

            Assert.That(span1.Equals(span2), Is.False);
        }

        [Test]
        public void EqualsReturnsTrueIfEqual()
        {
            var span1 = new DocumentSpan(10, 20);
            var span2 = new DocumentSpan(10, 20);

            Assert.That(span1.Equals(span2), Is.True);
        }

        [Test]
        public void GetHashCodeReturnsDifferentHashCodeIfIndexDiffers()
        {
            var span1 = new DocumentSpan(10, 20);
            var span2 = new DocumentSpan(11, 20);

            Assert.That(span2.GetHashCode(), Is.Not.EqualTo(span1.GetHashCode()));
        }

        [Test]
        public void GetHashCodeReturnsDifferentHashCodeIfLengthDiffers()
        {
            var span1 = new DocumentSpan(10, 20);
            var span2 = new DocumentSpan(10, 21);

            Assert.That(span2.GetHashCode(), Is.Not.EqualTo(span1.GetHashCode()));
        }

        [Test]
        public void GetHashCodeReturnsSameHashCodeIfEqual()
        {
            var span1 = new DocumentSpan(10, 20);
            var span2 = new DocumentSpan(10, 20);

            Assert.That(span2.GetHashCode(), Is.EqualTo(span1.GetHashCode()));
        }

        [Test]
        public void ToStringConvertsToExpectedFormat()
        {
            var span = new DocumentSpan(10, 20);

            Assert.That(span.ToString(), Is.EqualTo("Index: 10, Length: 20"));
        }
    }
}
