// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.BicepValues
{
    public class BicepValueToExpressionTests
    {
        [Test]
        public void ValidateLiteralValue()
        {
            var stringLiteral = new BicepValue<string>("literal");
            Assert.AreEqual("'literal'", stringLiteral.ToString());
            Assert.AreEqual("'literal'", stringLiteral.ToBicepExpression().ToString());

            var intLiteral = new BicepValue<int>(42);
            Assert.AreEqual("42", intLiteral.ToString());
            Assert.AreEqual("42", intLiteral.ToBicepExpression().ToString());

            var boolLiteral = new BicepValue<bool>(true);
            Assert.AreEqual("true", boolLiteral.ToString());
            Assert.AreEqual("true", boolLiteral.ToBicepExpression().ToString());

            var doubleLiteral = new BicepValue<double>(3.14);
            Assert.AreEqual("json('3.14')", doubleLiteral.ToString());
            Assert.AreEqual("json('3.14')", doubleLiteral.ToBicepExpression().ToString());
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
        public void ValidateModelListProperty_Empty()
        {
            var resource = new TestResource("test");
            Assert.AreEqual("[]", resource.Models.ToString());
            Assert.AreEqual("test.models", resource.Models.ToBicepExpression().ToString());

            resource.Models = new BicepList<TestModel>();
            Assert.AreEqual("[]", resource.Models.ToString());
            Assert.AreEqual("test.models", resource.Models.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateModelListProperty_WithValues()
        {
            var resource = new TestResource("test");
            resource.Models.Add(new TestModel() { Name = "model1" });
            resource.Models.Add(new TestModel() { Name = "model2" });
            Assert.AreEqual("""
            [
              {
                name: 'model1'
              }
              {
                name: 'model2'
              }
            ]
            """, resource.Models.ToString());
            Assert.AreEqual("test.models", resource.Models.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateModelListProperty_Indexer()
        {
            var resource = new TestResource("test");
            resource.Models.Add(new TestModel() { Name = "model1" });
            var validIndexer = resource.Models[0];
            Assert.AreEqual("""
            {
              name: 'model1'
            }
            """, validIndexer.ToString());
            TestModel? model = validIndexer.Value;
            Assert.IsNotNull(model);
            Assert.AreEqual("'model1'", model!.Name.ToString());
            Assert.AreEqual("test.models[0]", validIndexer.ToBicepExpression().ToString());

            // change the name
            model!.Name = "updatedModel1";
            Assert.AreEqual("""
            {
              name: 'updatedModel1'
            }
            """, validIndexer.ToString());

            var invalidIndexer = resource.Models[1]; // out-of-range
            var invalidModel = invalidIndexer.Value; // this does not throw but returns a null value
            Assert.IsNull(invalidModel);
            Assert.Throws<ArgumentOutOfRangeException>(() => invalidIndexer.ToString());
            Assert.AreEqual("test.models[1]", invalidIndexer.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateModelListProperty_ItemModelProperties()
        {
            var resource = new TestResource("test");
            resource.Models.Add(new TestModel() { Name = "model1" });
            var validIndexer = resource.Models[0];

            var item = validIndexer.Value!;
            Assert.IsNotNull(item);
            var name = item.Name;

            Assert.AreEqual("'model1'", name.ToString());
            Assert.AreEqual("test.models[0].name", name.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateOutputListProperty_Empty()
        {
            var resource = new TestResource("test");
            var outputList = resource.OutputList;
            Assert.AreEqual("[]", outputList.ToString()); // TODO -- should this throw? or just like right now we return an empty list?
            Assert.AreEqual("test.outputList", outputList.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateOutputListProperty_Indexer()
        {
            var resource = new TestResource("test");
            // add value to an output list will throw
            Assert.Throws<InvalidOperationException>(() => resource.OutputList.Add("outputItem1"));
            // call the setter of indexer will throw
            Assert.Throws<InvalidOperationException>(() => resource.OutputList[0] = "outputItem1");

            var validIndexer = resource.OutputList[0];
            Assert.Throws<ArgumentOutOfRangeException>(() => validIndexer.ToString());
            Assert.AreEqual("test.outputList[0]", validIndexer.ToBicepExpression().ToString());
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
        public void ValidateNestedOutputListProperty_Empty()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            var nestedOutputList = resource.Properties.OutputList;
            Assert.AreEqual("[]", nestedOutputList.ToString()); // TODO -- should this throw? or just like right now we return an empty list?
            Assert.AreEqual("test.properties.outputList", nestedOutputList.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateNestedOutputListProperty_Indexer()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            // add value to an output list will throw
            Assert.Throws<InvalidOperationException>(() => resource.Properties.OutputList.Add("outputItem1"));
            // call the setter of indexer will throw
            Assert.Throws<InvalidOperationException>(() => resource.Properties.OutputList[0] = "outputItem1");

            var validIndexer = resource.Properties.OutputList[0];
            Assert.Throws<ArgumentOutOfRangeException>(() => validIndexer.ToString());
            Assert.AreEqual("test.properties.outputList[0]", validIndexer.ToBicepExpression().ToString());
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
            Assert.Throws<KeyNotFoundException>(() => invalidIndexer.ToString());
            Assert.AreEqual("test.dictionary['missingKey']", invalidIndexer.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateOutputDictionaryProperty_Empty()
        {
            var resource = new TestResource("test");
            var outputDict = resource.OutputDictionary;
            Assert.AreEqual("{ }", outputDict.ToString()); // TODO -- should this throw? or just like right now we return an empty dictionary?
            Assert.AreEqual("test.outputDictionary", outputDict.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateOutputDictionaryProperty_Indexer()
        {
            var resource = new TestResource("test");
            // add value to an output dictionary will throw
            Assert.Throws<InvalidOperationException>(() => resource.OutputDictionary.Add("outputKey", "outputValue"));
            // call the setter of indexer will throw
            Assert.Throws<InvalidOperationException>(() => resource.OutputDictionary["outputKey"] = "outputValue");

            var validIndexer = resource.OutputDictionary["outputKey"];
            Assert.Throws<KeyNotFoundException>(() => validIndexer.ToString());
            Assert.AreEqual("test.outputDictionary['outputKey']", validIndexer.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateNestedDictionaryProperty_Empty()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            var nestedDict = resource.Properties.Dictionary;
            Assert.AreEqual("{ }", nestedDict.ToString());
            Assert.AreEqual("test.properties.dictionary", nestedDict.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateNestedDictionaryProperty_WithValues()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            resource.Properties.Dictionary["nestedKey1"] = "nestedValue1";
            resource.Properties.Dictionary["nestedKey2"] = "nestedValue2";
            Assert.AreEqual("""
            {
              nestedKey1: 'nestedValue1'
              nestedKey2: 'nestedValue2'
            }
            """, resource.Properties.Dictionary.ToString());
            Assert.AreEqual("test.properties.dictionary", resource.Properties.Dictionary.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateNestedDictionaryProperty_Indexer()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            resource.Properties.Dictionary["nestedKey1"] = "nestedValue1";
            var validIndexer = resource.Properties.Dictionary["nestedKey1"];
            Assert.AreEqual("'nestedValue1'", validIndexer.ToString());
            Assert.AreEqual("test.properties.dictionary['nestedKey1']", validIndexer.ToBicepExpression().ToString());
            var invalidIndexer = resource.Properties.Dictionary["missingNestedKey"];
            Assert.Throws<KeyNotFoundException>(() => invalidIndexer.ToString());
            Assert.AreEqual("test.properties.dictionary['missingNestedKey']", invalidIndexer.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateNestedOutputDictionaryProperty_Empty()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            var nestedOutputDict = resource.Properties.OutputDictionary;
            Assert.AreEqual("{ }", nestedOutputDict.ToString()); // TODO -- should this throw? or just like right now we return an empty dictionary?
            Assert.AreEqual("test.properties.outputDictionary", nestedOutputDict.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateNestedOutputDictionaryProperty_Indexer()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            // add value to an output dictionary will throw
            Assert.Throws<InvalidOperationException>(() => resource.Properties.OutputDictionary.Add("outputKey", "outputValue"));
            // call the setter of indexer will throw
            Assert.Throws<InvalidOperationException>(() => resource.Properties.OutputDictionary["outputKey"] = "outputValue");

            var validIndexer = resource.Properties.OutputDictionary["outputKey"];
            Assert.Throws<KeyNotFoundException>(() => validIndexer.ToString());
            Assert.AreEqual("test.properties.outputDictionary['outputKey']", validIndexer.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateFailsForPropertyOnUnnamedConstruct()
        {
            var properties = new TestProperties();
            properties.WithValue = "foo";
            var withValue = properties.WithValue;
            Assert.AreEqual("'foo'", withValue.ToString());
            Assert.Throws<InvalidOperationException>(() => withValue.ToBicepExpression().ToString());

            var withoutValue = properties.WithoutValue;
            Assert.Throws<InvalidOperationException>(() => withoutValue.ToString());
            Assert.Throws<InvalidOperationException>(() => withoutValue.ToBicepExpression().ToString());
        }

        [Test]
        public void ValidateBicepFunctionInterpolate_PlainValues()
        {
            var resource = new TestResource("test");
            resource.WithValue = "foo";

            var interpolated = BicepFunction.Interpolate($"with value: {resource.WithValue}, without value: {resource.WithoutValue}");

            Assert.AreEqual(interpolated.ToString(), "'with value: foo, without value: ${test.withoutValue}'");

            var interpolatedWithExpressions = BicepFunction.Interpolate($"with value: {resource.WithValue.ToBicepExpression()}, without value: {resource.WithoutValue.ToBicepExpression()}");

            Assert.AreEqual(interpolatedWithExpressions.ToString(), "'with value: ${test.withValue}, without value: ${test.withoutValue}'");
        }

        [Test]
        public void ValidateBicepFunctionInterpolate_ListValues()
        {
            var resource = new TestResource("test");
            resource.List.Add("item1");

            var interpolated = BicepFunction.Interpolate($"list item: {resource.List[0]}");
            Assert.AreEqual(interpolated.ToString(), "'list item: item1'");
            var interpolatedWithExpression = BicepFunction.Interpolate($"list item: {resource.List[0].ToBicepExpression()}");
            Assert.AreEqual(interpolatedWithExpression.ToString(), "'list item: ${test.list[0]}'");
            // this should throw because `resource.List[1]` is out of range
            Assert.Throws<ArgumentOutOfRangeException>(() => BicepFunction.Interpolate($"list item with valid index: {resource.List[0]}, list item with invalid index: {resource.List[1]}"));

            var interpolatedExpressionWithInvalidIndex = BicepFunction.Interpolate($"list item with valid index: {resource.List[0].ToBicepExpression()}, list item with invalid index: {resource.List[1].ToBicepExpression()}");
            Assert.AreEqual(interpolatedExpressionWithInvalidIndex.ToString(), "'list item with valid index: ${test.list[0]}, list item with invalid index: ${test.list[1]}'");
        }

        [Test]
        public void ValidateBicepFunctionInterpolate_DictionaryValues()
        {
            var resource = new TestResource("test");
            resource.Dictionary["key1"] = "value1";

            var interpolated = BicepFunction.Interpolate($"dictionary item: {resource.Dictionary["key1"]}");
            Assert.AreEqual(interpolated.ToString(), "'dictionary item: value1'");

            var interpolatedWithExpression = BicepFunction.Interpolate($"dictionary item: {resource.Dictionary["key1"].ToBicepExpression()}");
            Assert.AreEqual(interpolatedWithExpression.ToString(), "'dictionary item: ${test.dictionary[\'key1\']}'");

            // this should throw because `resource.Dictionary["missingKey"]` doesn't exist
            Assert.Throws<KeyNotFoundException>(() => BicepFunction.Interpolate($"dictionary item with valid key: {resource.Dictionary["key1"]}, dictionary item with missing key: {resource.Dictionary["missingKey"]}"));

            var interpolatedExpressionWithMissingKey = BicepFunction.Interpolate($"dictionary item with valid key: {resource.Dictionary["key1"].ToBicepExpression()}, dictionary item with missing key: {resource.Dictionary["missingKey"].ToBicepExpression()}");
            Assert.AreEqual(interpolatedExpressionWithMissingKey.ToString(), "'dictionary item with valid key: ${test.dictionary[\'key1\']}, dictionary item with missing key: ${test.dictionary[\'missingKey\']}'");
        }

        [Test]
        public void ValidateBicepFunctionInterpolate_NestedDictionaryValues()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            resource.Properties.Dictionary["nestedKey1"] = "nestedValue1";

            var interpolated = BicepFunction.Interpolate($"nested dictionary item: {resource.Properties.Dictionary["nestedKey1"]}");
            Assert.AreEqual(interpolated.ToString(), "'nested dictionary item: nestedValue1'");

            var interpolatedWithExpression = BicepFunction.Interpolate($"nested dictionary item: {resource.Properties.Dictionary["nestedKey1"].ToBicepExpression()}");
            Assert.AreEqual(interpolatedWithExpression.ToString(), "'nested dictionary item: ${test.properties.dictionary[\'nestedKey1\']}'");

            // this should throw because the missing key doesn't exist
            Assert.Throws<KeyNotFoundException>(() => BicepFunction.Interpolate($"nested dictionary item with valid key: {resource.Properties.Dictionary["nestedKey1"]}, nested dictionary item with missing key: {resource.Properties.Dictionary["missingNestedKey"]}"));

            var interpolatedExpressionWithMissingKey = BicepFunction.Interpolate($"nested dictionary item with valid key: {resource.Properties.Dictionary["nestedKey1"].ToBicepExpression()}, nested dictionary item with missing key: {resource.Properties.Dictionary["missingNestedKey"].ToBicepExpression()}");
            Assert.AreEqual(interpolatedExpressionWithMissingKey.ToString(), "'nested dictionary item with valid key: ${test.properties.dictionary[\'nestedKey1\']}, nested dictionary item with missing key: ${test.properties.dictionary[\'missingNestedKey\']}'");
        }

        [Test]
        public void ValidateBicepFunctionInterpolate_OutputDictionaryValues()
        {
            var resource = new TestResource("test");
            var outputDict = resource.OutputDictionary;

            // add value to an output dictionary will throw, so we can't populate it
            Assert.Throws<InvalidOperationException>(() => resource.OutputDictionary.Add("outputKey", "outputValue"));

            // test direct reference to output dictionary key (which should behave like expressions)
            var validIndexer = resource.OutputDictionary["outputKey"];
            Assert.Throws<KeyNotFoundException>(() => validIndexer.ToString());

            var interpolatedWithExpression = BicepFunction.Interpolate($"output dictionary item: {resource.OutputDictionary["outputKey"].ToBicepExpression()}");
            Assert.AreEqual(interpolatedWithExpression.ToString(), "'output dictionary item: ${test.outputDictionary[\'outputKey\']}'");
        }

        [Test]
        public void ValidateBicepFunctionInterpolate_MixedDictionaryAndListValues()
        {
            var resource = new TestResource("test");
            resource.Dictionary["config"] = "production";
            resource.List.Add("item1");

            var interpolated = BicepFunction.Interpolate($"Config: {resource.Dictionary["config"]}, First item: {resource.List[0]}");
            Assert.AreEqual(interpolated.ToString(), "'Config: production, First item: item1'");

            var interpolatedWithExpressions = BicepFunction.Interpolate($"Config: {resource.Dictionary["config"].ToBicepExpression()}, First item: {resource.List[0].ToBicepExpression()}");
            Assert.AreEqual(interpolatedWithExpressions.ToString(), "'Config: ${test.dictionary[\'config\']}, First item: ${test.list[0]}'");
        }

        [Test]
        public void ValidateBicepFunctionInterpolate_DictionaryWithSpecialCharacterKeys()
        {
            var resource = new TestResource("test");
            resource.Dictionary["my-key"] = "my-value";
            resource.Dictionary["key.with.dots"] = "dotted-value";
            resource.Dictionary["key with spaces"] = "spaced-value";

            var interpolated = BicepFunction.Interpolate($"Hyphenated: {resource.Dictionary["my-key"]}, Dotted: {resource.Dictionary["key.with.dots"]}, Spaced: {resource.Dictionary["key with spaces"]}");
            Assert.AreEqual(interpolated.ToString(), "'Hyphenated: my-value, Dotted: dotted-value, Spaced: spaced-value'");

            var interpolatedWithExpressions = BicepFunction.Interpolate($"Hyphenated: {resource.Dictionary["my-key"].ToBicepExpression()}, Dotted: {resource.Dictionary["key.with.dots"].ToBicepExpression()}, Spaced: {resource.Dictionary["key with spaces"].ToBicepExpression()}");
            Assert.AreEqual(interpolatedWithExpressions.ToString(), "'Hyphenated: ${test.dictionary[\'my-key\']}, Dotted: ${test.dictionary[\'key.with.dots\']}, Spaced: ${test.dictionary[\'key with spaces\']}'");
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

            private BicepList<string>? _outputList;
            public BicepList<string> OutputList
            {
                get { Initialize(); return _outputList!; }
            }

            private BicepDictionary<string>? _dictionary;
            public BicepDictionary<string> Dictionary
            {
                get { Initialize(); return _dictionary!; }
            }

            private BicepDictionary<string>? _outputDictionary;
            public BicepDictionary<string> OutputDictionary
            {
                get { Initialize(); return _outputDictionary!; }
            }

            private BicepList<TestModel>? _models;
            public BicepList<TestModel> Models
            {
                get { Initialize(); return _models!; }
                set { Initialize(); AssignOrReplace(ref _models, value); }
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
                _withValue = DefineProperty<string>("WithValue", ["withValue"]);
                _withoutValue = DefineProperty<string>("WithoutValue", ["withoutValue"]);
                _list = DefineListProperty<string>("List", ["list"]);
                _outputList = DefineListProperty<string>("OutputList", ["outputList"], isOutput: true);
                _models = DefineListProperty<TestModel>("Models", ["models"]);
                _dictionary = DefineDictionaryProperty<string>("Dictionary", ["dictionary"]);
                _outputDictionary = DefineDictionaryProperty<string>("OutputDictionary", ["outputDictionary"], isOutput: true);
                _properties = DefineModelProperty<TestProperties>("Properties", ["properties"]);
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

            private BicepList<string>? _outputList;
            public BicepList<string> OutputList
            {
                get { Initialize(); return _outputList!; }
            }

            private BicepDictionary<string>? _dictionary;
            public BicepDictionary<string> Dictionary
            {
                get { Initialize(); return _dictionary!; }
            }

            private BicepDictionary<string>? _outputDictionary;
            public BicepDictionary<string> OutputDictionary
            {
                get { Initialize(); return _outputDictionary!; }
            }

            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();
                _withValue = DefineProperty<string>("WithValue", ["withValue"]);
                _withoutValue = DefineProperty<string>("WithoutValue", ["withoutValue"]);
                _list = DefineListProperty<string>("List", ["list"]);
                _outputList = DefineListProperty<string>("OutputList", ["outputList"], isOutput: true);
                _dictionary = DefineDictionaryProperty<string>("Dictionary", ["dictionary"]);
                _outputDictionary = DefineDictionaryProperty<string>("OutputDictionary", ["outputDictionary"], isOutput: true);
            }
        }

        private class TestModel : ProvisionableConstruct
        {
            private BicepValue<string>? _name;
            public BicepValue<string> Name
            {
                get { Initialize(); return _name!; }
                set { Initialize(); _name!.Assign(value); }
            }
            protected override void DefineProvisionableProperties()
            {
                base.DefineProvisionableProperties();
                _name = DefineProperty<string>("Name", ["name"]);
            }
        }
    }
}
