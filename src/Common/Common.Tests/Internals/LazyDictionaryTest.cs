//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Hyak.Common;
using Xunit;

namespace Microsoft.Azure.Common.Test.Internals
{
    public class LazyDictionaryTest
    {
        [Fact]
        public void LazyByDefaultTest()
        {
            // Arrange
            var lazyDictionary = new LazyDictionary<string, string>();

            // Act
            var initialized = lazyDictionary.IsInitialized;

            // Assert
            Assert.False(initialized);
        }

        [Fact]
        public void LazyAddTest()
        {
            // Arrange
            var lazyDictionary = new LazyDictionary<string, string>();

            // Act
            lazyDictionary.Add("key", "value");
            var initialized = lazyDictionary.IsInitialized;

            // Assert
            Assert.True(initialized);
        }

        [Fact]
        public void LazyKeyAddTest()
        {
            // Arrange
            var lazyDictionary = new LazyDictionary<string, string>();

            // Act
            lazyDictionary["key"] = "value";
            var initialized = lazyDictionary.IsInitialized;

            // Assert
            Assert.True(initialized);
        }
    }
}
