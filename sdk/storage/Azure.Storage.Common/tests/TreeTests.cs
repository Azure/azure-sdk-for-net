// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    /// <summary>
    /// <see cref="Tree{T}"/> is a test utility data structure.
    /// Complex enough to warrant its own tests.
    /// </summary>
    internal class TreeTests
    {
        [Test]
        public void EqualityIgnoresChildren_Equal()
        {
            // Given tree nodes with the same value
            const string value = "Hello, World!";
            Tree<string> left = new()
            {
                Value = value
            };
            Tree<string> right = new()
            {
                Value = value
            };

            // And with different child nodes
            Random r = new();
            foreach (Tree<string> tree in new Tree<string>[] { left, right })
            {
                for (int i = 0; i < r.Next(2, 10); i++)
                {
                    tree.Add(new() { Value = r.NextString(10) });
                }
            }

            // Assert they are equal as child nodes
            Tree<string> parent = new();
            Assert.That(parent.Comparer.Equals(left, right), Is.True);

            Assert.That(parent, Is.Empty);
            parent.Add(left);
            Assert.That(parent, Has.Count.EqualTo(1));
            parent.Add(right);
            Assert.That(parent, Has.Count.EqualTo(1));
        }

        [Test]
        public void EqualityIgnoresChildren_NotEqual()
        {
            // Given tree nodes with differing value
            Tree<string> left = new()
            {
                Value = "foo"
            };
            Tree<string> right = new()
            {
                Value = "bar"
            };

            // And the same child nodes
            Random r = new();
            for (int i = 0; i < r.Next(2, 10); i++)
            {
                Tree<string> child = new() { Value = r.NextString(10) };
                left.Add(child);
                right.Add(child);
            }

            // Assert they are not equal as child nodes
            Tree<string> parent = new();
            Assert.That(parent.Comparer.Equals(left, right), Is.False);

            Assert.That(parent, Is.Empty);
            parent.Add(left);
            Assert.That(parent, Has.Count.EqualTo(1));
            parent.Add(right);
            Assert.That(parent, Has.Count.EqualTo(2));
        }

        [Test]
        public void EqualityUsesProvidedComparer([Values(true, false)] bool areEqual)
        {
            const string leftValue = "foo";
            const string rightValue = "bar";

            // Given an IEqualityComparer
            Mock<IEqualityComparer<string>> comparer = new();
            comparer.Setup(c => c.Equals(It.IsAny<string>(), It.IsAny<string>())).Returns(areEqual);

            // And Tree nodes using this comparer
            Tree<string> left = new(comparer.Object)
            {
                Value = leftValue
            };
            Tree<string> right = new(comparer.Object)
            {
                Value = rightValue
            };

            // Assert correct usage
            Tree<string> parent = new(comparer.Object);
            Assert.That(parent.Comparer.Equals(left, right), Is.EqualTo(areEqual)); // first comparison

            Assert.That(parent, Is.Empty);
            parent.Add(left);
            Assert.That(parent, Has.Count.EqualTo(1));
            parent.Add(right); // second comparison (and a hashcode for each)
            Assert.That(parent, Has.Count.EqualTo(areEqual ? 1 : 2));

            comparer.Verify(c => c.Equals(leftValue, rightValue), Times.Exactly(2));
            comparer.Verify(c => c.GetHashCode(leftValue), Times.Once);
            comparer.Verify(c => c.GetHashCode(rightValue), Times.Once);
            comparer.VerifyNoOtherCalls();
        }
    }
}
