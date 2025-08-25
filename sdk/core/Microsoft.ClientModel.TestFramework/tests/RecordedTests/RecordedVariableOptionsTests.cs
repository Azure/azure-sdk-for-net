// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class RecordedVariableOptionsTests
{
    #region IsSecret Method - Fluent Interface

    [Test]
    public void IsSecretWithCustomStringReturnsOptionsInstance()
    {
        var options = new RecordedVariableOptions();
        var customValue = "SANITIZED_CUSTOM_VALUE";

        var result = options.IsSecret(customValue);

        Assert.That(result, Is.SameAs(options));
    }

    [Test]
    public void IsSecretCanBeChained()
    {
        var options = new RecordedVariableOptions();
        var result = options.IsSecret().IsSecret(SanitizedValue.Base64);
        Assert.That(result, Is.SameAs(options));
    }

    [Test]
    public void IsSecretWithNullCustomValueThrowsArgumentNullException()
    {
        var options = new RecordedVariableOptions();

        Assert.Throws<ArgumentNullException>(() => options.IsSecret((string)null));
    }

    #endregion

    #region Apply Method - Without Secrets

    [Test]
    public void ApplyWithoutIsSecretReturnsOriginalValue()
    {
        var options = new RecordedVariableOptions();
        var originalValue = "original-secret-value";
        var result = options.Apply(originalValue);
        Assert.That(result, Is.EqualTo(originalValue));
    }

    #endregion

    #region Apply Method - With Sanitization

    [Test]
    public void ApplyWithDefaultSanitizationReturnsSanitizedValue()
    {
        var options = new RecordedVariableOptions();
        options.IsSecret();
        var originalValue = "secret-value";
        var result = options.Apply(originalValue);
        Assert.That(result, Is.Not.EqualTo(originalValue));
        Assert.That(result, Is.EqualTo("Sanitized"));
    }

    [Test]
    public void ApplyWithBase64SanitizationReturnsBase64Value()
    {
        var options = new RecordedVariableOptions();
        options.IsSecret(SanitizedValue.Base64);
        var originalValue = "secret-value";
        var result = options.Apply(originalValue);
        Assert.That(result, Is.EqualTo("Kg=="));
    }

    [Test]
    public void ApplyWithCustomSanitizationReturnsCustomValue()
    {
        var options = new RecordedVariableOptions();
        var customSanitizedValue = "CUSTOM_SANITIZED";
        options.IsSecret(customSanitizedValue);
        var originalValue = "secret-value";
        var result = options.Apply(originalValue);
        Assert.That(result, Is.EqualTo(customSanitizedValue));
    }

    [Test]
    public void ApplyLastCallWins()
    {
        var options = new RecordedVariableOptions();
        var customValue = "FINAL_VALUE";
        options.IsSecret(SanitizedValue.Base64).IsSecret(customValue);
        var result = options.Apply("original");
        Assert.That(result, Is.EqualTo(customValue));
    }

    #endregion

    #region Apply Method - Edge Cases

    [TestCase(null, "SANITIZED", "SANITIZED")]
    [TestCase("", "SANITIZED", "SANITIZED")]
    [TestCase("original", "SANITIZED", "SANITIZED")]
    public void ApplyWithVariousOriginalValuesHandlesGracefully(string originalValue, string sanitizedValue, string expectedResult)
    {
        var options = new RecordedVariableOptions();
        options.IsSecret(sanitizedValue);
        var result = options.Apply(originalValue);
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ApplyWithEmptyCustomSanitizationReturnsEmpty()
    {
        var options = new RecordedVariableOptions();
        options.IsSecret("");
        var originalValue = "secret";

        var result = options.Apply(originalValue);

        Assert.That(result, Is.EqualTo(""));
    }

    #endregion

    #region SanitizedValue Enum Behavior

    [Test]
    public void SanitizedValueDefaultMapsToCorrectValue()
    {
        var options = new RecordedVariableOptions();
        options.IsSecret(SanitizedValue.Default);
        var result = options.Apply("original");
        Assert.That(result, Is.EqualTo("Sanitized")); // Use the actual default sanitized value constant
    }

    #endregion

    #region Integration and Usage Patterns

    [Test]
    public void MultipleOptionsCanBeUsedIndependently()
    {
        var options1 = new RecordedVariableOptions().IsSecret("VALUE1");
        var options2 = new RecordedVariableOptions().IsSecret("VALUE2");
        var result1 = options1.Apply("original");
        var result2 = options2.Apply("original");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result1, Is.EqualTo("VALUE1"));
            Assert.That(result2, Is.EqualTo("VALUE2"));
        }
    }

    [Test]
    public void FluentInterfaceWorksCorrectly()
    {
        var originalValue = "secret-data";
        var result = new RecordedVariableOptions()
            .IsSecret("MASKED")
            .Apply(originalValue);
        Assert.That(result, Is.EqualTo("MASKED"));
    }

    #endregion
}
