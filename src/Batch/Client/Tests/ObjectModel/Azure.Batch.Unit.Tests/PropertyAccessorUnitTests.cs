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

    public class PropertyAccessorUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public PropertyAccessorUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        private class DummyComplexProperty : IPropertyMetadata
        {
            public bool HasBeenModified { get; set; }

            public bool IsReadOnly { get; set; }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void SimpleValueSet_ValueIsGettable()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var accessor = new PropertyAccessor<int>(controller, string.Empty, BindingAccess.Read | BindingAccess.Write);
            
            accessor.Value = 5;
            Assert.Equal(5, accessor.Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ComplexValueSet_ValueIsGettable()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var thing = new DummyComplexProperty();
            var accessor = new PropertyAccessor<DummyComplexProperty>(controller, string.Empty, BindingAccess.Read | BindingAccess.Write);

            accessor.Value = thing;
            Assert.Equal(thing, accessor.Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void SimpleValueSet_HasBeenModifiedChanges()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var accessor = new PropertyAccessor<int>(controller, string.Empty, BindingAccess.Read | BindingAccess.Write);

            Assert.False(accessor.HasBeenModified);
            accessor.Value = 5;
            Assert.True(accessor.HasBeenModified);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ComplexValueSet_HasBeenModifiedChanges()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var thing = new DummyComplexProperty();
            var accessor = new PropertyAccessor<DummyComplexProperty>(controller, string.Empty, BindingAccess.Read | BindingAccess.Write);
            
            Assert.False(accessor.HasBeenModified);
            accessor.Value = thing;
            Assert.True(accessor.HasBeenModified);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ComplexValueChanged_HasBeenModifiedChanges()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var thing = new DummyComplexProperty();
            var accessor = new PropertyAccessor<DummyComplexProperty>(thing, controller, string.Empty, BindingAccess.Read | BindingAccess.Write);

            Assert.False(accessor.HasBeenModified);
            thing.HasBeenModified = true; //Simulate a change to the complex value
            Assert.True(accessor.HasBeenModified);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void PropertyWithBindingAccessNone_ValueNotReadableOrWritable()
        {
            const string propertyName = "Foo";
            var controller = new PropertyAccessController(BindingState.Bound);
            var accessor = new PropertyAccessor<int>(controller, propertyName, BindingAccess.None);

            InvalidOperationException e = Assert.Throws<InvalidOperationException>(() => accessor.Value = 5);
            this.testOutputHelper.WriteLine(e.ToString());
            Assert.Contains(propertyName, e.Message);

            e = Assert.Throws<InvalidOperationException>(() => { int x = accessor.Value; });
            this.testOutputHelper.WriteLine(e.ToString());
            Assert.Contains(propertyName, e.Message);
            
            Assert.False(accessor.HasBeenModified);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void BindingAccessRead()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var accessor = new PropertyAccessor<int>(controller, string.Empty, BindingAccess.Read);

            Assert.Throws<InvalidOperationException>(() => accessor.Value = 5);
            Assert.False(accessor.HasBeenModified);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void HasBeenModifiedNotSetAfterConstruction()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var accessor = new PropertyAccessor<int>(7, controller, string.Empty, BindingAccess.Read);
            
            Assert.Equal(7, accessor.Value);
            Assert.False(accessor.HasBeenModified);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void SimplePropertyReadOnlySet_ObjectIsReadable()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var accessor = new PropertyAccessor<int>(8, controller, string.Empty, BindingAccess.Read | BindingAccess.Write);

            //Set readonly
            accessor.IsReadOnly = true;
            Assert.True(accessor.IsReadOnly);
            Assert.Equal(8, accessor.Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void SimplePropertyReadOnlySet_ObjectIsNotWritable()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var accessor = new PropertyAccessor<int>(8, controller, string.Empty, BindingAccess.Read | BindingAccess.Write);

            //Set readonly
            accessor.IsReadOnly = true;
            Assert.Throws<InvalidOperationException>(() => accessor.Value = 10);
            Assert.False(accessor.HasBeenModified);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void SimplePropertyReadOnlySetAndUnset_ObjectIsReadWritable()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var accessor = new PropertyAccessor<int>(8, controller, string.Empty, BindingAccess.Read | BindingAccess.Write);

            //Set readonly
            accessor.IsReadOnly = true;
            
            //Un-set readonly
            accessor.IsReadOnly = false;
            Assert.False(accessor.IsReadOnly);
            accessor.Value = 10;
            Assert.Equal(10, accessor.Value);
            Assert.True(accessor.HasBeenModified);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ComplexPropertyReadOnlySet_ObjectIsReadable()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var property = new DummyComplexProperty();
            var accessor = new PropertyAccessor<DummyComplexProperty>(property, controller, string.Empty, BindingAccess.Read | BindingAccess.Write);

            //Set readonly
            accessor.IsReadOnly = true;
            Assert.True(accessor.IsReadOnly);
            Assert.True(accessor.Value.IsReadOnly);
            Assert.Equal(property, accessor.Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ComplexPropertyReadOnlySet_ObjectIsNotWritable()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var property = new DummyComplexProperty();
            var accessor = new PropertyAccessor<DummyComplexProperty>(property, controller, string.Empty, BindingAccess.Read | BindingAccess.Write);

            //Set readonly
            accessor.IsReadOnly = true;
            Assert.Throws<InvalidOperationException>(() => accessor.Value = new DummyComplexProperty());
            Assert.False(accessor.HasBeenModified);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ComplexPropertyReadOnlySetAndUnset_ObjectIsReadWritable()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var property = new DummyComplexProperty();
            var accessor = new PropertyAccessor<DummyComplexProperty>(property, controller, string.Empty, BindingAccess.Read | BindingAccess.Write);

            //Set readonly
            accessor.IsReadOnly = true;

            //Un-set readonly
            accessor.IsReadOnly = false;
            Assert.False(accessor.Value.IsReadOnly);
            Assert.False(accessor.IsReadOnly);
            accessor.Value.HasBeenModified = true;
            Assert.True(accessor.HasBeenModified);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void OverrideReadOnly_CanSetValue()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var accessor = new PropertyAccessor<int>(controller, string.Empty, BindingAccess.Read | BindingAccess.Write);

            //Set readonly
            accessor.IsReadOnly = true;
            Assert.True(accessor.IsReadOnly);
            Assert.Equal(0, accessor.Value);

            accessor.SetValue(1, overrideReadOnly: true);
            Assert.True(accessor.HasBeenModified);
            Assert.Equal(1, accessor.Value);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void SetPropertyToExistingValueMarksItAsChanged()
        {
            var controller = new PropertyAccessController(BindingState.Bound);
            var accessor = new PropertyAccessor<int>(controller, string.Empty, BindingAccess.Read | BindingAccess.Write);

            var existingValue = accessor.Value;

            accessor.SetValue(existingValue);
            Assert.True(accessor.HasBeenModified);
        }

    }
}
