// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    public class BicepValueReferenceExtensionsTests
    {
        [Test]
        public void ValidateSimpleProperty()
        {
            var resource = new TestResource("test");
            resource.Foo = "foo";
            var foo = resource.Foo;

            Assert.AreEqual("'foo'", foo.ToString());
            Assert.AreEqual("test.foo", foo.ToBicepExpression().ToString());

            var fooWithoutValue = resource.FooWithoutValue;
            Assert.AreEqual("test.fooWithoutValue", fooWithoutValue.ToString());
            Assert.AreEqual("test.fooWithoutValue", fooWithoutValue.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateNestedProperty()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
                {
                    Nested = "nestedValue"
                }
            };

            var nested = resource.Properties.Nested;

            Assert.AreEqual("'nestedValue'", nested.ToString());
            Assert.AreEqual("test.properties.nested", nested.ToBicepExpression().ToString());

            var nestedWithoutValue = resource.Properties.NestedWithoutValue;
            Assert.AreEqual("test.properties.nestedWithoutValue", nestedWithoutValue.ToString());
            Assert.AreEqual("test.properties.nestedWithoutValue", nestedWithoutValue.ToBicepExpression().ToString());
        }

        private class TestResource : ProvisionableResource
        {
            public TestResource(string identifier) : base(identifier, "Microsoft.Tests/tests", "2025-11-09")
            {
            }

            private BicepValue<string>? _foo;
            public BicepValue<string> Foo
            {
                get { Initialize(); return _foo!; }
                set { Initialize(); _foo!.Assign(value); }
            }

            private BicepValue<string>? _fooWithoutValue;
            public BicepValue<string> FooWithoutValue
            {
                get { Initialize(); return _fooWithoutValue!; }
                set { Initialize(); _fooWithoutValue = value; }
            }

            private BicepList<string>? _bar;
            public BicepList<string> Bar
            {
                get { Initialize(); return _bar!; }
                //set { Initialize(); _bicep!.Assign(value); }
            }

            private TestProperties? _properties;
            public TestProperties Properties
            {
                get { Initialize(); return _properties!; }
                set { Initialize(); AssignOrReplace(ref _properties, value); }
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();
                _foo = DefineProperty<string>("Foo", ["foo"]);
                _fooWithoutValue = DefineProperty<string>("FooWithoutValue", ["fooWithoutValue"]);
                _bar = DefineListProperty<string>("Bar", ["bar"]);
                _properties = DefineModelProperty<TestProperties>("Properties", ["properties"]);
            }
        }

        private class TestProperties : ProvisionableConstruct
        {
            private BicepValue<string>? _nested;
            public BicepValue<string> Nested
            {
                get { Initialize(); return _nested!; }
                set { Initialize(); _nested!.Assign(value); }
            }

            private BicepValue<string>? _nestedWithoutValue;
            public BicepValue<string> NestedWithoutValue
            {
                get { Initialize(); return _nestedWithoutValue!; }
                set { Initialize(); _nestedWithoutValue = value; }
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();
                _nested = DefineProperty<string>("Nested", ["nested"]);
                _nestedWithoutValue = DefineProperty<string>("NestedWithoutValue", ["nestedWithoutValue"]);
            }
        }
    }
}
