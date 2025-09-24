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
            TestHelpers.AssertExpression("'literal'", stringLiteral);
            TestHelpers.AssertExpression("'literal'", stringLiteral.ToBicepExpression());

            var intLiteral = new BicepValue<int>(42);
            TestHelpers.AssertExpression("42", intLiteral);
            TestHelpers.AssertExpression("42", intLiteral.ToBicepExpression());

            var boolLiteral = new BicepValue<bool>(true);
            TestHelpers.AssertExpression("true", boolLiteral);
            TestHelpers.AssertExpression("true", boolLiteral.ToBicepExpression());

            var doubleLiteral = new BicepValue<double>(3.14);
            TestHelpers.AssertExpression("json('3.14')", doubleLiteral);
            TestHelpers.AssertExpression("json('3.14')", doubleLiteral.ToBicepExpression());
        }
        [Test]
        public void ValidateExpressionValue()
        {
            var expression = BicepFunction.GetUniqueString("a");
            TestHelpers.AssertExpression("uniqueString('a')", expression);
            TestHelpers.AssertExpression("uniqueString('a')", expression.ToBicepExpression());
        }

        [Test]
        public void ValidateSimpleProperty()
        {
            var resource = new TestResource("test");
            resource.WithValue = "foo";
            var withValue = resource.WithValue;

            TestHelpers.AssertExpression("'foo'", withValue);
            TestHelpers.AssertExpression("test.withValue", withValue.ToBicepExpression());

            var withoutValue = resource.WithoutValue;
            TestHelpers.AssertExpression("test.withoutValue", withoutValue);
            TestHelpers.AssertExpression("test.withoutValue", withoutValue.ToBicepExpression());
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

            TestHelpers.AssertExpression("'nestedValue'", nested);
            TestHelpers.AssertExpression("test.properties.withValue", nested.ToBicepExpression());

            var nestedWithoutValue = resource.Properties.WithoutValue;
            TestHelpers.AssertExpression("test.properties.withoutValue", nestedWithoutValue);
            TestHelpers.AssertExpression("test.properties.withoutValue", nestedWithoutValue.ToBicepExpression());
        }

        [Test]
        public void ValidateListProperty_Empty()
        {
            var resource = new TestResource("test");
            var list = resource.List;

            TestHelpers.AssertExpression("[]", list);
            TestHelpers.AssertExpression("test.list", list.ToBicepExpression());
        }

        [Test]
        public void ValidateListProperty_WithValues()
        {
            var resource = new TestResource("test");
            resource.List.Add("item1");
            resource.List.Add("item2");
            TestHelpers.AssertExpression("""
            [
              'item1'
              'item2'
            ]
            """, resource.List);
            TestHelpers.AssertExpression("test.list", resource.List.ToBicepExpression());
        }

        [Test]
        public void ValidateListProperty_Indexer()
        {
            var resource = new TestResource("test");
            resource.List.Add("item1");
            var validIndexer = resource.List[0];
            TestHelpers.AssertExpression("'item1'", validIndexer);
            TestHelpers.AssertExpression("test.list[0]", validIndexer.ToBicepExpression());

            var invalidIndexer = resource.List[1]; // this is an out-of-range index
            Assert.Throws<ArgumentOutOfRangeException>(() => invalidIndexer.ToString());
            TestHelpers.AssertExpression("test.list[1]", invalidIndexer.ToBicepExpression());
        }

        [Test]
        public void ValidateModelListProperty_Empty()
        {
            var resource = new TestResource("test");
            TestHelpers.AssertExpression("[]", resource.Models);
            TestHelpers.AssertExpression("test.models", resource.Models.ToBicepExpression());

            resource.Models = new BicepList<TestModel>();
            TestHelpers.AssertExpression("[]", resource.Models);
            TestHelpers.AssertExpression("test.models", resource.Models.ToBicepExpression());
        }

        [Test]
        public void ValidateModelListProperty_WithValues()
        {
            var resource = new TestResource("test");
            resource.Models.Add(new TestModel() { Name = "model1" });
            resource.Models.Add(new TestModel() { Name = "model2" });
            TestHelpers.AssertExpression("""
            [
              {
                name: 'model1'
              }
              {
                name: 'model2'
              }
            ]
            """, resource.Models);
            TestHelpers.AssertExpression("test.models", resource.Models.ToBicepExpression());
        }

        [Test]
        public void ValidateModelListProperty_Indexer()
        {
            var resource = new TestResource("test");
            resource.Models.Add(new TestModel() { Name = "model1" });
            var validIndexer = resource.Models[0];
            TestHelpers.AssertExpression("""
            {
              name: 'model1'
            }
            """, validIndexer);
            TestModel? model = validIndexer.Value;
            Assert.IsNotNull(model);
            TestHelpers.AssertExpression("'model1'", model!.Name);
            TestHelpers.AssertExpression("test.models[0]", validIndexer.ToBicepExpression());

            var name = model.Name;
            TestHelpers.AssertExpression("'model1'", name);
            TestHelpers.AssertExpression("test.models[0].name", name.ToBicepExpression());

            // change the name
            model!.Name = "updatedModel1";
            TestHelpers.AssertExpression("""
            {
              name: 'updatedModel1'
            }
            """, validIndexer);

            var invalidIndexer = resource.Models[1]; // out-of-range
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = invalidIndexer.Value);
            TestHelpers.AssertExpression("test.models[1]", invalidIndexer.ToBicepExpression());
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

            TestHelpers.AssertExpression("'model1'", name);
            TestHelpers.AssertExpression("test.models[0].name", name.ToBicepExpression());
        }

        [Test]
        public void ValidateOutputListProperty_Empty()
        {
            var resource = new TestResource("test");
            var outputList = resource.OutputList;
            TestHelpers.AssertExpression("[]", outputList); // TODO -- should this throw? or just like right now we return an empty list?
            TestHelpers.AssertExpression("test.outputList", outputList.ToBicepExpression());
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
            TestHelpers.AssertExpression("test.outputList[0]", validIndexer.ToBicepExpression());
        }
        [Test]
        public void ValidateNestedListProperty_Empty()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            var nestedList = resource.Properties.List;
            TestHelpers.AssertExpression("[]", nestedList);
            TestHelpers.AssertExpression("test.properties.list", nestedList.ToBicepExpression());
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
            TestHelpers.AssertExpression("""
            [
              'nestedItem1'
              'nestedItem2'
            ]
            """, resource.Properties.List);
            TestHelpers.AssertExpression("test.properties.list", resource.Properties.List.ToBicepExpression());
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
            TestHelpers.AssertExpression("'nestedItem1'", validIndexer);
            TestHelpers.AssertExpression("test.properties.list[0]", validIndexer.ToBicepExpression());

            var invalidIndexer = resource.Properties.List[1]; // out-of-range
            Assert.Throws<ArgumentOutOfRangeException>(() => invalidIndexer.ToString());
            TestHelpers.AssertExpression("test.properties.list[1]", invalidIndexer.ToBicepExpression());
        }

        [Test]
        public void ValidateNestedOutputListProperty_Empty()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            var nestedOutputList = resource.Properties.OutputList;
            TestHelpers.AssertExpression("[]", nestedOutputList); // TODO -- should this throw? or just like right now we return an empty list?
            TestHelpers.AssertExpression("test.properties.outputList", nestedOutputList.ToBicepExpression());
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
            TestHelpers.AssertExpression("test.properties.outputList[0]", validIndexer.ToBicepExpression());
        }

        [Test]
        public void ValidateDictionaryProperty_Empty()
        {
            var resource = new TestResource("test");
            var dict = resource.Dictionary;
            TestHelpers.AssertExpression("{ }", dict);
            TestHelpers.AssertExpression("test.dictionary", dict.ToBicepExpression());
        }

        [Test]
        public void ValidateDictionaryProperty_WithValues()
        {
            var resource = new TestResource("test");
            resource.Dictionary["key1"] = "value1";
            resource.Dictionary["key2"] = "value2";
            TestHelpers.AssertExpression("""
            {
              key1: 'value1'
              key2: 'value2'
            }
            """, resource.Dictionary);
            TestHelpers.AssertExpression("test.dictionary", resource.Dictionary.ToBicepExpression());
        }

        [Test]
        public void ValidateDictionaryProperty_Indexer()
        {
            var resource = new TestResource("test");
            resource.Dictionary["key1"] = "value1";
            var validIndexer = resource.Dictionary["key1"];
            TestHelpers.AssertExpression("'value1'", validIndexer);
            TestHelpers.AssertExpression("test.dictionary['key1']", validIndexer.ToBicepExpression());

            var invalidIndexer = resource.Dictionary["missingKey"];
            Assert.Throws<KeyNotFoundException>(() => invalidIndexer.ToString());
            TestHelpers.AssertExpression("test.dictionary['missingKey']", invalidIndexer.ToBicepExpression());
        }

        [Test]
        public void ValidateOutputDictionaryProperty_Empty()
        {
            var resource = new TestResource("test");
            var outputDict = resource.OutputDictionary;
            TestHelpers.AssertExpression("{ }", outputDict); // TODO -- should this throw? or just like right now we return an empty dictionary?
            TestHelpers.AssertExpression("test.outputDictionary", outputDict.ToBicepExpression());
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
            TestHelpers.AssertExpression("test.outputDictionary['outputKey']", validIndexer.ToBicepExpression());
        }

        [Test]
        public void ValidateNestedDictionaryProperty_Empty()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            var nestedDict = resource.Properties.Dictionary;
            TestHelpers.AssertExpression("{ }", nestedDict);
            TestHelpers.AssertExpression("test.properties.dictionary", nestedDict.ToBicepExpression());
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
            TestHelpers.AssertExpression("""
            {
              nestedKey1: 'nestedValue1'
              nestedKey2: 'nestedValue2'
            }
            """, resource.Properties.Dictionary);
            TestHelpers.AssertExpression("test.properties.dictionary", resource.Properties.Dictionary.ToBicepExpression());
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
            TestHelpers.AssertExpression("'nestedValue1'", validIndexer);
            TestHelpers.AssertExpression("test.properties.dictionary['nestedKey1']", validIndexer.ToBicepExpression());
            var invalidIndexer = resource.Properties.Dictionary["missingNestedKey"];
            Assert.Throws<KeyNotFoundException>(() => invalidIndexer.ToString());
            TestHelpers.AssertExpression("test.properties.dictionary['missingNestedKey']", invalidIndexer.ToBicepExpression());
        }

        [Test]
        public void ValidateNestedOutputDictionaryProperty_Empty()
        {
            var resource = new TestResource("test")
            {
                Properties = new TestProperties()
            };
            var nestedOutputDict = resource.Properties.OutputDictionary;
            TestHelpers.AssertExpression("{ }", nestedOutputDict); // TODO -- should this throw? or just like right now we return an empty dictionary?
            TestHelpers.AssertExpression("test.properties.outputDictionary", nestedOutputDict.ToBicepExpression());
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
            TestHelpers.AssertExpression("test.properties.outputDictionary['outputKey']", validIndexer.ToBicepExpression());
        }

        [Test]
        public void ValidateFailsForPropertyOnUnnamedConstruct()
        {
            var properties = new TestProperties();
            properties.WithValue = "foo";
            var withValue = properties.WithValue;
            TestHelpers.AssertExpression("'foo'", withValue);
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

            TestHelpers.AssertExpression("'with value: foo, without value: ${test.withoutValue}'", interpolated);

            var interpolatedWithExpressions = BicepFunction.Interpolate($"with value: {resource.WithValue.ToBicepExpression()}, without value: {resource.WithoutValue.ToBicepExpression()}");

            TestHelpers.AssertExpression("'with value: ${test.withValue}, without value: ${test.withoutValue}'", interpolatedWithExpressions);
        }

        [Test]
        public void ValidateBicepFunctionInterpolate_ListValues()
        {
            var resource = new TestResource("test");
            resource.List.Add("item1");

            var interpolated = BicepFunction.Interpolate($"list item: {resource.List[0]}");
            TestHelpers.AssertExpression("'list item: item1'", interpolated);
            var interpolatedWithExpression = BicepFunction.Interpolate($"list item: {resource.List[0].ToBicepExpression()}");
            TestHelpers.AssertExpression("'list item: ${test.list[0]}'", interpolatedWithExpression);
            // this should throw because `resource.List[1]` is out of range
            Assert.Throws<ArgumentOutOfRangeException>(() => BicepFunction.Interpolate($"list item with valid index: {resource.List[0]}, list item with invalid index: {resource.List[1]}"));

            var interpolatedExpressionWithInvalidIndex = BicepFunction.Interpolate($"list item with valid index: {resource.List[0].ToBicepExpression()}, list item with invalid index: {resource.List[1].ToBicepExpression()}");
            TestHelpers.AssertExpression("'list item with valid index: ${test.list[0]}, list item with invalid index: ${test.list[1]}'", interpolatedExpressionWithInvalidIndex);
        }

        [Test]
        public void ValidateBicepFunctionInterpolate_DictionaryValues()
        {
            var resource = new TestResource("test");
            resource.Dictionary["key1"] = "value1";

            var interpolated = BicepFunction.Interpolate($"dictionary item: {resource.Dictionary["key1"]}");
            TestHelpers.AssertExpression("'dictionary item: value1'", interpolated);

            var interpolatedWithExpression = BicepFunction.Interpolate($"dictionary item: {resource.Dictionary["key1"].ToBicepExpression()}");
            TestHelpers.AssertExpression("'dictionary item: ${test.dictionary[\'key1\']}'", interpolatedWithExpression);

            // this should throw because `resource.Dictionary["missingKey"]` doesn't exist
            Assert.Throws<KeyNotFoundException>(() => BicepFunction.Interpolate($"dictionary item with valid key: {resource.Dictionary["key1"]}, dictionary item with missing key: {resource.Dictionary["missingKey"]}"));

            var interpolatedExpressionWithMissingKey = BicepFunction.Interpolate($"dictionary item with valid key: {resource.Dictionary["key1"].ToBicepExpression()}, dictionary item with missing key: {resource.Dictionary["missingKey"].ToBicepExpression()}");
            TestHelpers.AssertExpression("'dictionary item with valid key: ${test.dictionary[\'key1\']}, dictionary item with missing key: ${test.dictionary[\'missingKey\']}'", interpolatedExpressionWithMissingKey);
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
            TestHelpers.AssertExpression("'nested dictionary item: nestedValue1'", interpolated);

            var interpolatedWithExpression = BicepFunction.Interpolate($"nested dictionary item: {resource.Properties.Dictionary["nestedKey1"].ToBicepExpression()}");
            TestHelpers.AssertExpression("'nested dictionary item: ${test.properties.dictionary[\'nestedKey1\']}'", interpolatedWithExpression);

            // this should throw because the missing key doesn't exist
            Assert.Throws<KeyNotFoundException>(() => BicepFunction.Interpolate($"nested dictionary item with valid key: {resource.Properties.Dictionary["nestedKey1"]}, nested dictionary item with missing key: {resource.Properties.Dictionary["missingNestedKey"]}"));

            var interpolatedExpressionWithMissingKey = BicepFunction.Interpolate($"nested dictionary item with valid key: {resource.Properties.Dictionary["nestedKey1"].ToBicepExpression()}, nested dictionary item with missing key: {resource.Properties.Dictionary["missingNestedKey"].ToBicepExpression()}");
            TestHelpers.AssertExpression("'nested dictionary item with valid key: ${test.properties.dictionary[\'nestedKey1\']}, nested dictionary item with missing key: ${test.properties.dictionary[\'missingNestedKey\']}'", interpolatedExpressionWithMissingKey);
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
            TestHelpers.AssertExpression("'output dictionary item: ${test.outputDictionary[\'outputKey\']}'", interpolatedWithExpression);
        }

        [Test]
        public void ValidateBicepFunctionInterpolate_MixedDictionaryAndListValues()
        {
            var resource = new TestResource("test");
            resource.Dictionary["config"] = "production";
            resource.List.Add("item1");

            var interpolated = BicepFunction.Interpolate($"Config: {resource.Dictionary["config"]}, First item: {resource.List[0]}");
            TestHelpers.AssertExpression("'Config: production, First item: item1'", interpolated);

            var interpolatedWithExpressions = BicepFunction.Interpolate($"Config: {resource.Dictionary["config"].ToBicepExpression()}, First item: {resource.List[0].ToBicepExpression()}");
            TestHelpers.AssertExpression("'Config: ${test.dictionary[\'config\']}, First item: ${test.list[0]}'", interpolatedWithExpressions);
        }

        [Test]
        public void ValidateBicepFunctionInterpolate_DictionaryWithSpecialCharacterKeys()
        {
            var resource = new TestResource("test");
            resource.Dictionary["my-key"] = "my-value";
            resource.Dictionary["key.with.dots"] = "dotted-value";
            resource.Dictionary["key with spaces"] = "spaced-value";

            var interpolated = BicepFunction.Interpolate($"Hyphenated: {resource.Dictionary["my-key"]}, Dotted: {resource.Dictionary["key.with.dots"]}, Spaced: {resource.Dictionary["key with spaces"]}");
            TestHelpers.AssertExpression("'Hyphenated: my-value, Dotted: dotted-value, Spaced: spaced-value'", interpolated);

            var interpolatedWithExpressions = BicepFunction.Interpolate($"Hyphenated: {resource.Dictionary["my-key"].ToBicepExpression()}, Dotted: {resource.Dictionary["key.with.dots"].ToBicepExpression()}, Spaced: {resource.Dictionary["key with spaces"].ToBicepExpression()}");
            TestHelpers.AssertExpression("'Hyphenated: ${test.dictionary[\'my-key\']}, Dotted: ${test.dictionary[\'key.with.dots\']}, Spaced: ${test.dictionary[\'key with spaces\']}'", interpolatedWithExpressions);
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
                set { Initialize(); _withoutValue!.Assign(value); }
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
