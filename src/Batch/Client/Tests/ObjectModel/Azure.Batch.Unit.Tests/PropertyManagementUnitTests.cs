// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
