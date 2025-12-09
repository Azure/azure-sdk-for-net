// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.Storage;
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
        TestHelpers.AssertExpression(
            """
            join([
              'one'
              'two'
              'three'
            ], ',')
            """, result);
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
        TestHelpers.AssertExpression(
            """
            join([
              'a'
              'b'
              'c'
            ], delimiter)
            """, result);
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
        TestHelpers.AssertExpression(
            """
            join([
              'Hello'
              'World'
            ], '')
            """, result);
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
        TestHelpers.AssertExpression(
            """
            join([
              'part1'
              'part2'
              'part3'
            ], '::')
            """, result);
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
        TestHelpers.AssertExpression(
            """
            join([
              'onlyOne'
            ], ',')
            """, result);
    }

    [Test]
    public void Join_WithResourceModelProperty_ReturnsCorrectFormat()
    {
        // Arrange - Create a simple inline model with a Tags property that has a BicepList
        var filter = new BlobInventoryPolicyFilter
        {
            IncludePrefix = new BicepList<string> { "container1/", "container2/" }
        };

        // Access the IncludePrefix property
        var result = BicepFunction.Join(filter.IncludePrefix, "/");

        // Assert - The expression compiles to the join function with the array
        TestHelpers.AssertExpression(
            """
            join([
              'container1/'
              'container2/'
            ], '/')
            """, result);
    }
}
