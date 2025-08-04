// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;

namespace Microsoft.ClientModel.TestFramework.Tests.RecordedTests;

[TestFixture]
public class RecordedVariableOptionsTests
{
    [Test]
    public void Constructor_CreatesValidInstance()
    {
        var options = new RecordedVariableOptions();
        
        Assert.IsNotNull(options);
    }

    [Test]
    public void IsSecret_WithDefaultSanitizedValue_ReturnsOptionsInstance()
    {
        var options = new RecordedVariableOptions();
        
        var result = options.IsSecret();
        
        Assert.AreSame(options, result);
    }

    [Test]
    public void IsSecret_WithSpecificSanitizedValue_ReturnsOptionsInstance()
    {
        var options = new RecordedVariableOptions();
        
        var result = options.IsSecret(SanitizedValue.Base64);
        
        Assert.AreSame(options, result);
    }

    [Test]
    public void IsSecret_WithCustomString_ReturnsOptionsInstance()
    {
        var options = new RecordedVariableOptions();
        var customValue = "SANITIZED_CUSTOM_VALUE";
        
        var result = options.IsSecret(customValue);
        
        Assert.AreSame(options, result);
    }

    [Test]
    public void Apply_WithoutIsSecret_ReturnsOriginalValue()
    {
        var options = new RecordedVariableOptions();
        var originalValue = "original-secret-value";
        
        var result = options.Apply(originalValue);
        
        Assert.AreEqual(originalValue, result);
    }

    [Test]
    public void Apply_WithDefaultSanitization_ReturnsSanitizedValue()
    {
        var options = new RecordedVariableOptions();
        options.IsSecret();
        var originalValue = "secret-value";
        
        var result = options.Apply(originalValue);
        
        Assert.AreNotEqual(originalValue, result);
        Assert.AreEqual("Sanitized", result); // Assuming RecordedTestBase.SanitizeValue is "Sanitized"
    }

    [Test]
    public void Apply_WithBase64Sanitization_ReturnsBase64Value()
    {
        var options = new RecordedVariableOptions();
        options.IsSecret(SanitizedValue.Base64);
        var originalValue = "secret-value";
        
        var result = options.Apply(originalValue);
        
        Assert.AreEqual("Kg==", result);
    }

    [Test]
    public void Apply_WithCustomSanitization_ReturnsCustomValue()
    {
        var options = new RecordedVariableOptions();
        var customSanitizedValue = "CUSTOM_SANITIZED";
        options.IsSecret(customSanitizedValue);
        var originalValue = "secret-value";
        
        var result = options.Apply(originalValue);
        
        Assert.AreEqual(customSanitizedValue, result);
    }

    [Test]
    public void IsSecret_CanBeChained()
    {
        var options = new RecordedVariableOptions();
        
        var result = options.IsSecret().IsSecret(SanitizedValue.Base64);
        
        Assert.AreSame(options, result);
    }

    [Test]
    public void IsSecret_LastCallWins()
    {
        var options = new RecordedVariableOptions();
        var customValue = "FINAL_VALUE";
        
        options.IsSecret(SanitizedValue.Base64).IsSecret(customValue);
        var result = options.Apply("original");
        
        Assert.AreEqual(customValue, result);
    }

    [Test]
    public void IsSecret_WithNullCustomValue_AllowsNull()
    {
        var options = new RecordedVariableOptions();
        
        Assert.DoesNotThrow(() => options.IsSecret((string)null));
    }

    [Test]
    public void Apply_WithNullSanitizedValue_ReturnsNull()
    {
        var options = new RecordedVariableOptions();
        options.IsSecret((string)null);
        var originalValue = "original";
        
        var result = options.Apply(originalValue);
        
        Assert.IsNull(result);
    }

    [Test]
    public void Apply_WithEmptyCustomSanitization_ReturnsEmpty()
    {
        var options = new RecordedVariableOptions();
        options.IsSecret("");
        var originalValue = "secret";
        
        var result = options.Apply(originalValue);
        
        Assert.AreEqual("", result);
    }

    [Test]
    public void Apply_WithNullOriginalValue_HandlesGracefully()
    {
        var options = new RecordedVariableOptions();
        options.IsSecret("SANITIZED");
        
        var result = options.Apply(null);
        
        Assert.AreEqual("SANITIZED", result);
    }

    [Test]
    public void Apply_WithEmptyOriginalValue_HandlesGracefully()
    {
        var options = new RecordedVariableOptions();
        options.IsSecret("SANITIZED");
        
        var result = options.Apply("");
        
        Assert.AreEqual("SANITIZED", result);
    }

    [Test]
    public void MultipleOptions_CanBeUsedIndependently()
    {
        var options1 = new RecordedVariableOptions().IsSecret("VALUE1");
        var options2 = new RecordedVariableOptions().IsSecret("VALUE2");
        
        var result1 = options1.Apply("original");
        var result2 = options2.Apply("original");
        
        Assert.AreEqual("VALUE1", result1);
        Assert.AreEqual("VALUE2", result2);
    }

    [Test]
    public void SanitizedValue_Default_MapsToCorrectValue()
    {
        var options = new RecordedVariableOptions();
        options.IsSecret(SanitizedValue.Default);
        
        var result = options.Apply("original");
        
        // Should use RecordedTestBase.SanitizeValue for default
        Assert.AreEqual("Sanitized", result); // Assuming this is the default sanitized value
    }

    [Test]
    public void FluentInterface_WorksCorrectly()
    {
        var originalValue = "secret-data";
        
        var result = new RecordedVariableOptions()
            .IsSecret("MASKED")
            .Apply(originalValue);
        
        Assert.AreEqual("MASKED", result);
    }
}
