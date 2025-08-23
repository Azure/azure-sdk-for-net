// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    public class BicepFunctionTests
    {
        [Test]
        public void Interpolate_WithLiteralText_ReturnsCorrectFormat()
        {
            // Act - test literal interpolated string (cast to FormattableString to resolve ambiguity)
            var result = BicepFunction.Interpolate($"Hello, World!");

            // Assert
            Assert.AreEqual("'Hello, World!'", result.ToString());
        }

        [Test]
        public void Interpolate_WithSingleVariable_ReturnsCorrectFormat()
        {
            // Arrange
            var variable = new ProvisioningVariable("myVar", typeof(string));

            // Act
            var result = BicepFunction.Interpolate($"Value: {variable}");

            // Assert
            Assert.AreEqual("'Value: ${myVar}'", result.ToString());
        }

        [Test]
        public void Interpolate_WithMultipleVariables_ReturnsCorrectFormat()
        {
            // Arrange
            var nameVar = new ProvisioningVariable("name", typeof(string));
            var valueVar = new ProvisioningVariable("value", typeof(string));

            // Act
            var result = BicepFunction.Interpolate($"Name: {nameVar}, Value: {valueVar}");

            // Assert
            Assert.AreEqual("'Name: ${name}, Value: ${value}'", result.ToString());
        }

        [Test]
        public void Interpolate_WithBicepExpression_ReturnsCorrectFormat()
        {
            // Arrange
            var expression = new IdentifierExpression("resourceGroup");

            // Act
            var result = BicepFunction.Interpolate($"Resource Group: {expression}");

            // Assert
            Assert.AreEqual("'Resource Group: ${resourceGroup}'", result.ToString());
        }

        [Test]
        public void Interpolate_WithBicepValue_ReturnsCorrectFormat()
        {
            // Arrange - BicepValue with literal strings are compiled as string literals in interpolation
            var bicepValue = new BicepValue<string>("test-value");

            // Act
            var result = BicepFunction.Interpolate($"Static: {bicepValue}");

            // Assert - Literal BicepValues get compiled as string literals, not expressions
            Assert.AreEqual("'Static: test-value'", result.ToString());
        }

        [Test]
        public void Interpolate_WithMixedContent_ReturnsCorrectFormat()
        {
            // Arrange
            var variable = new ProvisioningVariable("location", typeof(string));
            var expression = new IdentifierExpression("resourceGroup");
            var bicepValue = new BicepValue<string>("suffix");

            // Act
            var result = BicepFunction.Interpolate($"Prefix-{variable}-{expression}-{bicepValue}");

            // Assert - Literal BicepValues get compiled as string literals, not expressions
            Assert.AreEqual("'Prefix-${location}-${resourceGroup}-suffix'", result.ToString());
        }

        [Test]
        public void Interpolate_WithNestedFormattableString_ReturnsCorrectFormat()
        {
            // Arrange
            var variable = new ProvisioningVariable("name", typeof(string));
            FormattableString nested = $"nested-{variable}";

            // Act
            var result = BicepFunction.Interpolate($"Outer: {nested}");

            // Assert
            Assert.AreEqual("'Outer: nested-${name}'", result.ToString());
        }

        [Test]
        public void Interpolate_WithNullValue_HandlesGracefully()
        {
            // Arrange
            string? nullValue = null;

            // Act
            var result = BicepFunction.Interpolate($"Value: {nullValue}");

            // Assert
            Assert.AreEqual("'Value: '", result.ToString());
        }

        [Test]
        public void Interpolate_WithComplexExpression_ReturnsCorrectFormat()
        {
            // Arrange
            var indexExpression = new IndexExpression(
                new IdentifierExpression("properties"),
                new StringLiteralExpression("endpoint")
            );

            // Act
            var result = BicepFunction.Interpolate($"Endpoint: {indexExpression}");

            // Assert
            Assert.AreEqual("'Endpoint: ${properties['endpoint']}'", result.ToString());
        }

        [Test]
        public void Interpolate_FormattableStringOverload_WithLiteralText_ReturnsCorrectFormat()
        {
            // Arrange
            FormattableString formattable = $"Hello, World!";

            // Act - explicitly call the FormattableString overload
            var result = BicepFunction.Interpolate(formattable);

            // Assert
            Assert.AreEqual("'Hello, World!'", result.ToString());
        }

        [Test]
        public void Interpolate_FormattableStringOverload_WithVariable_ReturnsCorrectFormat()
        {
            // Arrange
            var variable = new ProvisioningVariable("testVar", typeof(string));
            FormattableString formattable = $"Variable: {variable}";

            // Act - explicitly call the FormattableString overload
            var result = BicepFunction.Interpolate(formattable);

            // Assert
            Assert.AreEqual("'Variable: ${testVar}'", result.ToString());
        }

        [Test]
        public void Interpolate_EmptyString_ReturnsCorrectFormat()
        {
            // Act - cast to FormattableString to resolve ambiguity
            var result = BicepFunction.Interpolate((FormattableString)$"");

            // Assert
            Assert.AreEqual("''", result.ToString());
        }

        [Test]
        public void Interpolate_OnlyVariables_ReturnsCorrectFormat()
        {
            // Arrange
            var variable = new ProvisioningVariable("onlyVar", typeof(string));

            // Act
            var result = BicepFunction.Interpolate($"{variable}");

            // Assert
            Assert.AreEqual("'${onlyVar}'", result.ToString());
        }

        [Test]
        public void Interpolate_WithSpecialCharacters_EscapesCorrectly()
        {
            // Arrange
            var variable = new ProvisioningVariable("path", typeof(string));

            // Act
            var result = BicepFunction.Interpolate($"Path: {variable}\\folder\\file.txt");

            // Assert
            Assert.AreEqual("'Path: ${path}\\\\folder\\\\file.txt'", result.ToString());
        }

        [Test]
        public void Interpolate_WithQuotes_EscapesCorrectly()
        {
            // Arrange
            var variable = new ProvisioningVariable("message", typeof(string));

            // Act
            var result = BicepFunction.Interpolate($"Message: '{variable}' is quoted");

            // Assert
            Assert.AreEqual("'Message: \\'${message}\\' is quoted'", result.ToString());
        }

        [Test]
        public void Interpolate_WithCSharpExpressions_ReturnsCorrectFormat()
        {
            // Arrange
            var variable = new ProvisioningVariable("count", typeof(int));
            int multiplier = 2;

            // Act
            var result = BicepFunction.Interpolate($"Count: {variable} x {multiplier}");

            // Assert
            Assert.AreEqual("'Count: ${count} x 2'", result.ToString());
        }

        [Test]
        public void Interpolate_FormattableStringWithComplexArguments_ReturnsCorrectFormat()
        {
            // Arrange
            var resourceGroup = new ProvisioningVariable("rgName", typeof(string));
            var location = new ProvisioningVariable("location", typeof(string));

            // Create a more complex FormattableString
            FormattableString formattable = $"RG: {resourceGroup} in {location}";

            // Act
            var result = BicepFunction.Interpolate(formattable);

            // Assert
            Assert.AreEqual("'RG: ${rgName} in ${location}'", result.ToString());
        }

        [Test]
        public void Interpolate_WithBicepValueExpression_ReturnsCorrectFormat()
        {
            // Arrange - test BicepValue created from expression rather than literal
            var bicepValue = new BicepValue<string>(new IdentifierExpression("dynamicValue"));

            // Act
            var result = BicepFunction.Interpolate($"Dynamic: {bicepValue}");

            // Assert
            Assert.AreEqual("'Dynamic: ${dynamicValue}'", result.ToString());
        }

        [Test]
        public void Interpolate_WithSimpleInterpolation_ReturnsCorrectFormat()
        {
            // Arrange - test the specific use case from the user's request
            var myVariable = new ProvisioningVariable("myVariable", typeof(string));

            // Act - use natural interpolated string syntax
            var result = BicepFunction.Interpolate($"Hello {myVariable}!");

            // Assert
            Assert.AreEqual("'Hello ${myVariable}!'", result.ToString());
        }

        [Test]
        public void Interpolate_WithMultipleInterpolatedValues_ReturnsCorrectFormat()
        {
            // Arrange
            var prefix = new ProvisioningVariable("prefix", typeof(string));
            var suffix = new ProvisioningVariable("suffix", typeof(string));

            // Act
            var result = BicepFunction.Interpolate($"{prefix}-{suffix}");

            // Assert
            Assert.AreEqual("'${prefix}-${suffix}'", result.ToString());
        }

        [Test]
        public void Interpolate_WithResourceReferences_ReturnsCorrectFormat()
        {
            // Arrange
            var resourceName = new ProvisioningVariable("resourceName", typeof(string));
            var location = new ProvisioningVariable("location", typeof(string));

            // Act - test a more realistic scenario
            var result = BicepFunction.Interpolate($"Creating resource '{resourceName}' in location '{location}'");

            // Assert
            Assert.AreEqual("'Creating resource \\'${resourceName}\\' in location \\'${location}\\''", result.ToString());
        }

        [Test]
        public void Interpolate_WithNumericInterpolation_ReturnsCorrectFormat()
        {
            // Arrange
            var port = new ProvisioningVariable("port", typeof(int));
            var timeout = 30;

            // Act
            var result = BicepFunction.Interpolate($"Server running on port {port} with timeout {timeout}s");

            // Assert
            Assert.AreEqual("'Server running on port ${port} with timeout 30s'", result.ToString());
        }

        [Test]
        public void Interpolate_WithConditionalExpression_ReturnsCorrectFormat()
        {
            // Arrange
            var condition = new IdentifierExpression("isDevelopment");
            var prodValue = new IdentifierExpression("prodConfig");
            var devValue = new IdentifierExpression("devConfig");
            var conditionalExpr = new ConditionalExpression(condition, devValue, prodValue);

            // Act
            var result = BicepFunction.Interpolate($"Config: {conditionalExpr}");

            // Assert
            Assert.AreEqual("'Config: ${isDevelopment ? devConfig : prodConfig}'", result.ToString());
        }

        [Test]
        public void Interpolate_WithNestedFormattableInLiteralInterpolation_ReturnsCorrectFormat()
        {
            // Arrange - test case 1: literal interpolated string with FormattableString as argument
            var outerVar = new ProvisioningVariable("outerVar", typeof(string));
            var innerVar = new ProvisioningVariable("innerVar", typeof(string));
            var middleVar = new ProvisioningVariable("middleVar", typeof(string));

            // Create nested FormattableString
            FormattableString innerFormattable = $"inner[{innerVar}]";
            FormattableString middleFormattable = $"middle({middleVar}|{innerFormattable})";

            // Act - Use literal interpolated string with nested FormattableString
            var result = BicepFunction.Interpolate($"Outer: {outerVar} -> {middleFormattable}");

            // Assert
            Assert.AreEqual("'Outer: ${outerVar} -> middle(${middleVar}|inner[${innerVar}])'", result.ToString());
        }

        [Test]
        public void Interpolate_WithFormattableStringContainingNestedFormattable_ReturnsCorrectFormat()
        {
            // Arrange - test case 2: FormattableString as argument with nested FormattableString
            var level1Var = new ProvisioningVariable("level1", typeof(string));
            var level2Var = new ProvisioningVariable("level2", typeof(string));
            var level3Var = new ProvisioningVariable("level3", typeof(string));

            // Create deeply nested FormattableStrings
            FormattableString level3Formattable = $"L3:{level3Var}";
            FormattableString level2Formattable = $"L2:{level2Var}->{level3Formattable}";
            FormattableString level1Formattable = $"L1:{level1Var}->{level2Formattable}";

            // Act - Pass FormattableString containing nested FormattableStrings to Interpolate
            var result = BicepFunction.Interpolate(level1Formattable);

            // Assert
            Assert.AreEqual("'L1:${level1}->L2:${level2}->L3:${level3}'", result.ToString());
        }
    }
}
