// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Xunit;
    using Xunit.Abstractions;

    public class PropertyCollectionUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public PropertyCollectionUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        private class DummyPropertyCollection : PropertyCollection
        {
            public readonly PropertyAccessor<int> DummyProperty;

            public DummyPropertyCollection(BindingState bindingState, BindingAccess access) : base(bindingState)
            {
                this.DummyProperty = this.CreatePropertyAccessor<int>(string.Empty, access);
            }
        }
        
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CanReadBindingState()
        {
            var collection = new DummyPropertyCollection(BindingState.Bound, BindingAccess.Read | BindingAccess.Write);

            Assert.Equal(BindingState.Bound, collection.BindingState);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ReadOnlyPropagates()
        {
            var collection = new DummyPropertyCollection(BindingState.Bound, BindingAccess.Read | BindingAccess.Write);

            collection.IsReadOnly = true;
            Assert.True(collection.IsReadOnly);
            Assert.True(collection.DummyProperty.IsReadOnly);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void HasBeenModifiedAggregates()
        {
            var collection = new DummyPropertyCollection(BindingState.Bound, BindingAccess.Read | BindingAccess.Write);

            collection.DummyProperty.Value = 5;
            Assert.True(collection.HasBeenModified);
        }

    }
}
