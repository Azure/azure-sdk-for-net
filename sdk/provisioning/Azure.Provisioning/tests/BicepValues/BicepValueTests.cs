// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Primitives;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.BicepValues;

public class BicepValueTests
{
    [Test]
    public void ValidateLiteralBicepValue()
    {
        // string value
        AssertExpression("'test'", new BicepValue<string>("test"));

        // int value
        AssertExpression("42", new BicepValue<int>(42));
        AssertExpression("-42", new BicepValue<int>(-42));

        // long value
        AssertExpression("42", new BicepValue<long>(42L));
        AssertExpression("2147483647", new BicepValue<long>(2147483647L));
        AssertExpression("json('2147483648')", new BicepValue<long>(2147483648));
        AssertExpression("-2147483648", new BicepValue<long>(-2147483648L));
        AssertExpression("json('-2147483649')", new BicepValue<long>(-2147483649));
        AssertExpression("json('9223372036854775807')", new BicepValue<long>(9223372036854775807));

        // bool value
        AssertExpression("true", new BicepValue<bool>(true));
        AssertExpression("false", new BicepValue<bool>(false));

        // double value
        AssertExpression("json('3.14')", new BicepValue<double>(3.14));
        AssertExpression("json('-3.14')", new BicepValue<double>(-3.14));
        // double value with whole numbers
        AssertExpression("314", new BicepValue<double>(314d));
        AssertExpression("2147483647", new BicepValue<double>(2147483647d));
        AssertExpression("json('2147483648')", new BicepValue<double>(2147483648d));
        AssertExpression("-2147483647", new BicepValue<double>(-2147483647d));
        AssertExpression("-2147483648", new BicepValue<double>(-2147483648d));
        AssertExpression("json('-2147483649')", new BicepValue<double>(-2147483649d));
    }

    [Test]
    public void ValidateOutputArrayShouldBeIndexedSuccessfully()
    {
        var construct = new TestConstruct("test");
        var expression = construct.Properties.Ports[0];
        AssertExpression(
            "test.properties.ports[0]",
            expression
            );
    }

    [Test]
    public void ValidateOutputDictionaryShouldBeIndexedSuccessfully()
    {
        var construct = new TestConstruct("test")
        {
            Properties = new()
        };
        var expression = construct.Properties.Endpoints["reference"];
        AssertExpression(
            "test.properties.endpoints['reference']",
            expression
            );
    }

    // TODO -- add more test cases for settable list and dictionary.

    private class TestConstruct : ProvisionableResource
    {
        protected override void DefineProvisionableProperties()
        {
            _properties = DefineModelProperty<TestProperties>("Properties", ["properties"]);
        }

        public TestProperties Properties
        {
            get { Initialize(); return _properties!; }
            set { Initialize(); AssignOrReplace(ref _properties, value); }
        }
        private TestProperties? _properties;

        public TestConstruct(string bicepIdentifier, string? resourceVersion = null) : base(bicepIdentifier, "Microsoft.Tests/testResource", resourceVersion ?? "2025-05-27")
        {
        }
    }

    private class TestProperties : ProvisionableConstruct
    {
        protected override void DefineProvisionableProperties()
        {
            _ipAddresses = DefineListProperty<string>("IpAddresses", ["ipAddresses"]);
            _tags = DefineDictionaryProperty<string>("Tags", ["tags"]);
            _ports = DefineListProperty<string>("Ports", ["ports"], isOutput: true);
            _endpoints = DefineDictionaryProperty<string>("Endpoints", ["endpoints"], isOutput: true);
        }

        public BicepList<string> IpAddresses
        {
            get { Initialize(); return _ipAddresses!; }
            set { Initialize(); AssignOrReplace(ref _ipAddresses, value); }
        }
        private BicepList<string>? _ipAddresses;

        public BicepDictionary<string> Tags
        {
            get { Initialize(); return _tags!; }
            set { Initialize(); AssignOrReplace(ref _tags, value); }
        }
        private BicepDictionary<string>? _tags;

        public BicepList<string> Ports
        {
            get { Initialize(); return _ports!; }
        }
        private BicepList<string>? _ports;

        public BicepDictionary<string> Endpoints
        {
            get { Initialize(); return _endpoints!; }
        }
        private BicepDictionary<string>? _endpoints;
    }

    private static void AssertExpression(string expected, BicepValue bicepValue)
    {
        Assert.AreEqual(expected, bicepValue.ToString());
    }
}
