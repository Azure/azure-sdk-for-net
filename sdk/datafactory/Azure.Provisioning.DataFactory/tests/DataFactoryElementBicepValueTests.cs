// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Expressions.DataFactory;
using NUnit.Framework;

namespace Azure.Provisioning.DataFactory.Tests;

/// <summary>
/// Tests that BicepValue can handle DataFactoryElement types via
/// the IPersistableModel JSON serialization fallback.
/// </summary>
public class DataFactoryElementBicepValueTests
{
    [Test]
    public void BicepValue_WithDataFactoryElementString_CompilesSuccessfully()
    {
        DataFactoryElement<string> element = DataFactoryElement<string>.FromLiteral("hello");
        var bicepValue = new BicepValue<DataFactoryElement<string>>(element);

        Assert.AreEqual("'hello'", bicepValue.Compile().ToString());
    }

    [Test]
    public void BicepValue_WithDataFactoryElementBool_CompilesSuccessfully()
    {
        DataFactoryElement<bool> element = DataFactoryElement<bool>.FromLiteral(true);
        var bicepValue = new BicepValue<DataFactoryElement<bool>>(element);

        Assert.AreEqual("true", bicepValue.Compile().ToString());
    }

    [Test]
    public void BicepValue_WithDataFactoryElementInt_CompilesSuccessfully()
    {
        DataFactoryElement<int> element = DataFactoryElement<int>.FromLiteral(42);
        var bicepValue = new BicepValue<DataFactoryElement<int>>(element);

        Assert.AreEqual("42", bicepValue.Compile().ToString());
    }

    [Test]
    public void BicepValue_WithDataFactoryElementExpression_CompilesSuccessfully()
    {
        DataFactoryElement<string> element = DataFactoryElement<string>.FromExpression("@pipeline().parameters.myParam");
        var bicepValue = new BicepValue<DataFactoryElement<string>>(element);

        // Expression-type DataFactoryElements serialize as {"type":"Expression","value":"..."}
        string result = bicepValue.Compile().ToString();
        Assert.That(result, Does.Contain("type: 'Expression'"));
        Assert.That(result, Does.Contain("value: '@pipeline().parameters.myParam'"));
    }
}
