// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;

namespace Microsoft.ClientModel.TestFramework.Tests.RecordedTests;

[TestFixture]
public class SanitizedValueTests
{
    [Test]
    public void SanitizedValue_HasCorrectValues()
    {
        var defaultValue = (int)SanitizedValue.Default;
        var base64Value = (int)SanitizedValue.Base64;
        
        Assert.AreEqual(0, defaultValue);
        Assert.AreEqual(1, base64Value);
    }

    [Test]
    public void SanitizedValue_AllValuesAreDefined()
    {
        var enumValues = Enum.GetValues(typeof(SanitizedValue));
        
        Assert.AreEqual(2, enumValues.Length);
        Assert.Contains(SanitizedValue.Default, enumValues);
        Assert.Contains(SanitizedValue.Base64, enumValues);
    }

    [Test]
    public void SanitizedValue_CanConvertToString()
    {
        Assert.AreEqual("Default", SanitizedValue.Default.ToString());
        Assert.AreEqual("Base64", SanitizedValue.Base64.ToString());
    }

    [Test]
    public void SanitizedValue_CanParseFromString()
    {
        Assert.AreEqual(SanitizedValue.Default, Enum.Parse<SanitizedValue>("Default"));
        Assert.AreEqual(SanitizedValue.Base64, Enum.Parse<SanitizedValue>("Base64"));
    }

    [Test]
    public void SanitizedValue_ParseIsCaseInsensitive()
    {
        Assert.AreEqual(SanitizedValue.Default, Enum.Parse<SanitizedValue>("default", ignoreCase: true));
        Assert.AreEqual(SanitizedValue.Base64, Enum.Parse<SanitizedValue>("BASE64", ignoreCase: true));
    }

    [Test]
    public void SanitizedValue_TryParseValidValues_ReturnsTrue()
    {
        Assert.IsTrue(Enum.TryParse<SanitizedValue>("Default", out var defaultValue));
        Assert.AreEqual(SanitizedValue.Default, defaultValue);
        
        Assert.IsTrue(Enum.TryParse<SanitizedValue>("Base64", out var base64Value));
        Assert.AreEqual(SanitizedValue.Base64, base64Value);
    }

    [Test]
    public void SanitizedValue_TryParseInvalidValue_ReturnsFalse()
    {
        Assert.IsFalse(Enum.TryParse<SanitizedValue>("Invalid", out var result));
        Assert.AreEqual(default(SanitizedValue), result);
    }

    [Test]
    public void SanitizedValue_CanUseInSwitchStatement()
    {
        string GetSanitizationType(SanitizedValue value)
        {
            return value switch
            {
                SanitizedValue.Default => "Default sanitization",
                SanitizedValue.Base64 => "Base64 encoding",
                _ => "Unknown sanitization"
            };
        }
        
        Assert.AreEqual("Default sanitization", GetSanitizationType(SanitizedValue.Default));
        Assert.AreEqual("Base64 encoding", GetSanitizationType(SanitizedValue.Base64));
    }

    [Test]
    public void SanitizedValue_CanCompareValues()
    {
        Assert.IsTrue(SanitizedValue.Default < SanitizedValue.Base64);
        Assert.IsTrue(SanitizedValue.Default != SanitizedValue.Base64);
        Assert.IsFalse(SanitizedValue.Default > SanitizedValue.Base64);
    }

    [Test]
    public void SanitizedValue_CanConvertToInt()
    {
        int defaultInt = (int)SanitizedValue.Default;
        int base64Int = (int)SanitizedValue.Base64;
        
        Assert.AreEqual(0, defaultInt);
        Assert.AreEqual(1, base64Int);
    }

    [Test]
    public void SanitizedValue_CanConvertFromInt()
    {
        var defaultValue = (SanitizedValue)0;
        var base64Value = (SanitizedValue)1;
        
        Assert.AreEqual(SanitizedValue.Default, defaultValue);
        Assert.AreEqual(SanitizedValue.Base64, base64Value);
    }

    [Test]
    public void SanitizedValue_HashCodeIsConsistent()
    {
        var default1 = SanitizedValue.Default;
        var default2 = SanitizedValue.Default;
        
        Assert.AreEqual(default1.GetHashCode(), default2.GetHashCode());
        Assert.AreNotEqual(SanitizedValue.Default.GetHashCode(), SanitizedValue.Base64.GetHashCode());
    }

    [Test]
    public void SanitizedValue_DefaultValue_IsDefault()
    {
        SanitizedValue defaultValue = default;
        
        Assert.AreEqual(SanitizedValue.Default, defaultValue);
    }

    [Test]
    public void SanitizedValue_EqualsMethod_WorksCorrectly()
    {
        Assert.IsTrue(SanitizedValue.Default.Equals(SanitizedValue.Default));
        Assert.IsFalse(SanitizedValue.Default.Equals(SanitizedValue.Base64));
        Assert.IsFalse(SanitizedValue.Default.Equals(null));
        Assert.IsFalse(SanitizedValue.Default.Equals("Default"));
    }
}
