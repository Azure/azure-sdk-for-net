// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    public class BicepValueReferenceExtensionsTests
    {
        [Test]
        public void ValidateLiteralValue()
        {
            var literal = new BicepValue<string>("literal");
            Assert.AreEqual("'literal'", literal.ToString());
            Assert.AreEqual("'literal'", literal.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateExpressionValue()
        {
            var expression = BicepFunction.GetUniqueString("a");
            Assert.AreEqual("uniqueString('a')", expression.ToString());
            Assert.AreEqual("uniqueString('a')", expression.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateSimpleProperty()
        {
            var resource = new TestResource("test");
            resource.WithValue = "foo";
            var withValue = resource.WithValue;

            Assert.AreEqual("'foo'", withValue.ToString());
            Assert.AreEqual("test.withValue", withValue.ToBicepExpression().ToString());

            var withoutValue = resource.WithoutValue;
            Assert.AreEqual("test.withoutValue", withoutValue.ToString());
            Assert.AreEqual("test.withoutValue", withoutValue.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateNestedProperty()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
                {
                    WithValue = "nestedValue"
                }
            };

            var nested = resource.Properties.WithValue;

            Assert.AreEqual("'nestedValue'", nested.ToString());
            Assert.AreEqual("test.properties.withValue", nested.ToBicepExpression().ToString());

            var nestedWithoutValue = resource.Properties.WithoutValue;
            Assert.AreEqual("test.properties.withoutValue", nestedWithoutValue.ToString());
            Assert.AreEqual("test.properties.withoutValue", nestedWithoutValue.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateListProperty_Empty()
        {
            var resource = new TestResource("test");
            var list = resource.List;

            Assert.AreEqual("[]", list.ToString());
            Assert.AreEqual("test.list", list.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateListProperty_WithValues()
        {
            var resource = new TestResource("test");
            resource.List.Add("item1");
            resource.List.Add("item2");
            Assert.AreEqual("""
                [
                  'item1'
                  'item2'
                ]
                """, resource.List.ToString());
            Assert.AreEqual("test.list", resource.List.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateListProperty_Indexer()
        {
            var resource = new TestResource("test");
            resource.List.Add("item1");
            var validIndexer = resource.List[0];
            Assert.AreEqual("'item1'", validIndexer.ToString());
            Assert.AreEqual("test.list[0]", validIndexer.ToBicepExpression().ToString());

            var invalidIndexer = resource.List[1]; // this is an out-of-range index
            Assert.Throws<ArgumentOutOfRangeException>(() => invalidIndexer.ToString());
            Assert.AreEqual("test.list[1]", invalidIndexer.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateNestedListProperty_Empty()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            var nestedList = resource.Properties.List;
            Assert.AreEqual("[]", nestedList.ToString());
            Assert.AreEqual("test.properties.list", nestedList.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateNestedListProperty_WithValues()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            resource.Properties.List.Add("nestedItem1");
            resource.Properties.List.Add("nestedItem2");
            Assert.AreEqual("""
                [
                  'nestedItem1'
                  'nestedItem2'
                ]
                """, resource.Properties.List.ToString());
            Assert.AreEqual("test.properties.list", resource.Properties.List.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateNestedListProperty_Indexer()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            resource.Properties.List.Add("nestedItem1");
            var validIndexer = resource.Properties.List[0];
            Assert.AreEqual("'nestedItem1'", validIndexer.ToString());
            Assert.AreEqual("test.properties.list[0]", validIndexer.ToBicepExpression().ToString());

            var invalidIndexer = resource.Properties.List[1]; // out-of-range
            Assert.Throws<ArgumentOutOfRangeException>(() => invalidIndexer.ToString());
            Assert.AreEqual("test.properties.list[1]", invalidIndexer.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateDictionaryProperty_Empty()
        {
            var resource = new TestResource("test");
            var dict = resource.Dictionary;
            Assert.AreEqual("{ }", dict.ToString());
            Assert.AreEqual("test.dictionary", dict.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateDictionaryProperty_WithValues()
        {
            var resource = new TestResource("test");
            resource.Dictionary["key1"] = "value1";
            resource.Dictionary["key2"] = "value2";
            Assert.AreEqual("""
                {
                  key1: 'value1'
                  key2: 'value2'
                }
                """, resource.Dictionary.ToString());
            Assert.AreEqual("test.dictionary", resource.Dictionary.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateDictionaryProperty_Indexer()
        {
            var resource = new TestResource("test");
            resource.Dictionary["key1"] = "value1";
            var validIndexer = resource.Dictionary["key1"];
            Assert.AreEqual("'value1'", validIndexer.ToString());
            Assert.AreEqual("test.dictionary['key1']", validIndexer.ToBicepExpression().ToString());

            var invalidIndexer = resource.Dictionary["missingKey"];
            Assert.AreEqual("test.dictionary['missingKey']", invalidIndexer.ToBicepExpression().ToString());
        }

        private class TestResource : ProvisionableResource
        {
            public TestResource(string identifier) : base(identifier, "Microsoft.Tests/tests", "2025-11-09")
            {
            }

            private BicepValue<string>? _withValue;
            public BicepValue<string> WithValue
            {
                get { Initialize(); return _withValue!; }
                set { Initialize(); _withValue!.Assign(value); }
            }

            private BicepValue<string>? _withoutValue;
            public BicepValue<string> WithoutValue
            {
                get { Initialize(); return _withoutValue!; }
                set { Initialize(); _withoutValue = value; }
            }

            private BicepList<string>? _list;
            public BicepList<string> List
            {
                get { Initialize(); return _list!; }
            }

            private TestProperties? _properties;
            public TestProperties Properties
            {
                get { Initialize(); return _properties!; }
                set { Initialize(); AssignOrReplace(ref _properties, value); }
            }

            private BicepDictionary<string>? _dictionary;
            public BicepDictionary<string> Dictionary
            {
                get { Initialize(); return _dictionary!; }
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();
                _withValue = DefineProperty<string>("WithValue", ["withValue"]);
                _withoutValue = DefineProperty<string>("WithoutValue", ["withoutValue"]);
                _list = DefineListProperty<string>("List", ["list"]);
                _properties = DefineModelProperty<TestProperties>("Properties", ["properties"]);
                _dictionary = DefineDictionaryProperty<string>("Dictionary", ["dictionary"]);
            }
        }

        private class TestProperties : ProvisionableConstruct
        {
            private BicepValue<string>? _withValue;
            public BicepValue<string> WithValue
            {
                get { Initialize(); return _withValue!; }
                set { Initialize(); _withValue!.Assign(value); }
            }

            private BicepValue<string>? _withoutValue;
            public BicepValue<string> WithoutValue
            {
                get { Initialize(); return _withoutValue!; }
                set { Initialize(); _withoutValue = value; }
            }

            private BicepList<string>? _list;
            public BicepList<string> List
            {
                get { Initialize(); return _list!; }
            }

            private BicepDictionary<string>? _dictionary;
            public BicepDictionary<string> Dictionary
            {
                get { Initialize(); return _dictionary!; }
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();
                _withValue = DefineProperty<string>("WithValue", ["withValue"]);
                _withoutValue = DefineProperty<string>("WithoutValue", ["withoutValue"]);
                _list = DefineListProperty<string>("List", ["list"]);
                _dictionary = DefineDictionaryProperty<string>("Dictionary", ["dictionary"]);
            }
        }
    }
}
