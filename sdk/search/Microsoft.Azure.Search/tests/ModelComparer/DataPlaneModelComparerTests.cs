// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class DataPlaneModelComparerTests
    {
        [Fact]
        public void NullEqualsDefault()
        {
            int? maybeZero = 0;
            int? maybeFive = 5;
            int? nullNumber = null;

            bool? maybeFalse = false;
            bool? maybeTrue = true;
            bool? nullBool = null;

            Assert.Equal(maybeZero, nullNumber, new DataPlaneModelComparer<int?>());
            Assert.Equal(nullNumber, maybeZero, new DataPlaneModelComparer<int?>());
            Assert.Equal(maybeFalse, nullBool, new DataPlaneModelComparer<bool?>());
            Assert.Equal(nullBool, maybeFalse, new DataPlaneModelComparer<bool?>());

            Assert.NotEqual(maybeFive, nullNumber, new DataPlaneModelComparer<int?>());
            Assert.NotEqual(nullNumber, maybeFive, new DataPlaneModelComparer<int?>());
            Assert.NotEqual(maybeTrue, nullBool, new DataPlaneModelComparer<bool?>());
            Assert.NotEqual(nullBool, maybeTrue, new DataPlaneModelComparer<bool?>());
        }

        [Fact]
        public void ComparisonIgnoresETags()
        {
            var model = new Model() { Name = "Magical Trevor", Age = 11, ETag = "1" };
            var sameModel = new Model(model) { ETag = "2" };

            Assert.Equal(model, sameModel, new DataPlaneModelComparer<Model>());
        }

        [Fact]
        public void NullEqualsEmptyCollection()
        {
            IEnumerable<int> nullCollection = null;
            var emptyArray = new int[0];
            var emptyList = new List<int>();

            var comparer = new DataPlaneModelComparer<IEnumerable<int>>();

            Assert.True(comparer.Equals(nullCollection, emptyArray));
            Assert.True(comparer.Equals(emptyArray, nullCollection));
            Assert.True(comparer.Equals(nullCollection, emptyList));
            Assert.True(comparer.Equals(emptyList, nullCollection));
        }

        private class Model : IResourceWithETag
        {
            public Model() { }

            public Model(Model other)
            {
                Name = other.Name;
                Age = other.Age;
                ETag = other.ETag;
            }

            public string Name { get; set; }

            public int Age { get; set; }

            public string ETag { get; set; }
        }
    }
}
