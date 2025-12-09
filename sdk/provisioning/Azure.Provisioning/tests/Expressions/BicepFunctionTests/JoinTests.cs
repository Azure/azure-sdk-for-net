// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions.BicepFunctions;

public class JoinTests
{
    [Test]
    public void Join_WithLiteralArray_ReturnsCorrectFormat()
    {
        // Arrange
        var array = new BicepList<string> { "one", "two", "three" };
        var delimiter = new BicepValue<string>(",");

        // Act
        var result = BicepFunction.Join(array, delimiter);

        // Assert
        TestHelpers.AssertExpression("join([\n  'one'\n  'two'\n  'three'\n], ',')", result);
    }

    [Test]
    public void Join_WithArrayVariable_ReturnsCorrectFormat()
    {
        // Arrange
        var arrayVariable = new ProvisioningVariable("myArray", typeof(string[]));
        BicepList<string> arrayValue = arrayVariable;
        var delimiter = new BicepValue<string>("-");

        // Act
        var result = BicepFunction.Join(arrayValue, delimiter);

        // Assert
        TestHelpers.AssertExpression("join(myArray, '-')", result);
    }

    [Test]
    public void Join_WithDelimiterVariable_ReturnsCorrectFormat()
    {
        // Arrange
        var array = new BicepList<string> { "a", "b", "c" };
        var delimiterVariable = new ProvisioningVariable("delimiter", typeof(string));
        var delimiter = new BicepValue<string>(new IdentifierExpression("delimiter"));

        // Act
        var result = BicepFunction.Join(array, delimiter);

        // Assert
        TestHelpers.AssertExpression("join([\n  'a'\n  'b'\n  'c'\n], delimiter)", result);
    }

    [Test]
    public void Join_WithBothVariables_ReturnsCorrectFormat()
    {
        // Arrange
        var itemsVariable = new ProvisioningVariable("items", typeof(string[]));
        BicepList<string> arrayValue = itemsVariable;
        var separatorVariable = new ProvisioningVariable("separator", typeof(string));
        BicepValue<string> delimiter = separatorVariable;

        // Act
        var result = BicepFunction.Join(arrayValue, delimiter);

        // Assert
        TestHelpers.AssertExpression("join(items, separator)", result);
    }

    [Test]
    public void Join_WithEmptyDelimiter_ReturnsCorrectFormat()
    {
        // Arrange
        var array = new BicepList<string> { "Hello", "World" };
        var delimiter = new BicepValue<string>("");

        // Act
        var result = BicepFunction.Join(array, delimiter);

        // Assert
        TestHelpers.AssertExpression("join([\n  'Hello'\n  'World'\n], '')", result);
    }

    [Test]
    public void Join_WithMultiCharDelimiter_ReturnsCorrectFormat()
    {
        // Arrange
        var array = new BicepList<string> { "part1", "part2", "part3" };
        var delimiter = new BicepValue<string>("::");

        // Act
        var result = BicepFunction.Join(array, delimiter);

        // Assert
        TestHelpers.AssertExpression("join([\n  'part1'\n  'part2'\n  'part3'\n], '::')", result);
    }

    [Test]
    public void Join_WithSingleElementArray_ReturnsCorrectFormat()
    {
        // Arrange
        var array = new BicepList<string> { "onlyOne" };
        var delimiter = new BicepValue<string>(",");

        // Act
        var result = BicepFunction.Join(array, delimiter);

        // Assert
        TestHelpers.AssertExpression("join([\n  'onlyOne'\n], ',')", result);
    }
}
