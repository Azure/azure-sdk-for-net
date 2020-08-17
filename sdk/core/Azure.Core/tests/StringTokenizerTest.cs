// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using NUnit.Framework;

namespace Microsoft.Extensions.Primitives
{
    public class StringTokenizerTest
    {
        [Test]
        public void TokenizerReturnsEmptySequenceForNullValues()
        {
            // Arrange
            var stringTokenizer = new StringTokenizer();
            var enumerator = stringTokenizer.GetEnumerator();

            // Act
            var next = enumerator.MoveNext();

            // Assert
            Assert.False(next);
        }

        [Test]
        [TestCase("", new[] { "" })]
        [TestCase("a", new[] { "a" })]
        [TestCase("abc", new[] { "abc" })]
        [TestCase("a,b", new[] { "a", "b" })]
        [TestCase("a,,b", new[] { "a", "", "b" })]
        [TestCase(",a,b", new[] { "", "a", "b" })]
        [TestCase(",,a,b", new[] { "", "", "a", "b" })]
        [TestCase("a,b,", new[] { "a", "b", "" })]
        [TestCase("a,b,,", new[] { "a", "b", "", "" })]
        [TestCase("ab,cde,efgh", new[] { "ab", "cde", "efgh" })]
        public void Tokenizer_ReturnsSequenceOfValues(string value, string[] expected)
        {
            // Arrange
            var tokenizer = new StringTokenizer(value, new[] { ',' });

            // Act
            var result = tokenizer.Select(t => t.Value).ToArray();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase("", new[] { "" })]
        [TestCase("a", new[] { "a" })]
        [TestCase("abc", new[] { "abc" })]
        [TestCase("a.b", new[] { "a", "b" })]
        [TestCase("a,b", new[] { "a", "b" })]
        [TestCase("a.b,c", new[] { "a", "b", "c" })]
        [TestCase("a,b.c", new[] { "a", "b", "c" })]
        [TestCase("ab.cd,ef", new[] { "ab", "cd", "ef" })]
        [TestCase("ab,cd.ef", new[] { "ab", "cd", "ef" })]
        [TestCase(",a.b", new[] { "", "a", "b" })]
        [TestCase(".a,b", new[] { "", "a", "b" })]
        [TestCase(".,a.b", new[] { "", "", "a", "b" })]
        [TestCase(",.a,b", new[] { "", "", "a", "b" })]
        [TestCase("a.b,", new[] { "a", "b", "" })]
        [TestCase("a,b.", new[] { "a", "b", "" })]
        [TestCase("a.b,.", new[] { "a", "b", "", "" })]
        [TestCase("a,b.,", new[] { "a", "b", "", "" })]
        public void Tokenizer_SupportsMultipleSeparators(string value, string[] expected)
        {
            // Arrange
            var tokenizer = new StringTokenizer(value, new[] { '.', ',' });

            // Act
            var result = tokenizer.Select(t => t.Value).ToArray();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
