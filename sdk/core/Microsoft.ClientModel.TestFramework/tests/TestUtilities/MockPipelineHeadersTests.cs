// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using System;
using System.Linq;

namespace Microsoft.ClientModel.TestFramework.Tests;

public class MockPipelineHeadersTests
{
    [Test]
    public void CanSetAndGetResponseHeaders()
    {
        MockPipelineResponseHeaders headers = new();
        headers.SetHeader("Content-Type", "application/json");
        headers.SetHeader("X-Custom-Header", "CustomValue");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(headers.TryGetValue("Content-Type", out string contentType), Is.True);
            Assert.That(contentType, Is.EqualTo("application/json"));
            Assert.That(headers.TryGetValue("X-Custom-Header", out string customHeader), Is.True);
            Assert.That(customHeader, Is.EqualTo("CustomValue"));
        }
    }

    [Test]
    public void SettingMultipleValuesResponseHeaders()
    {
        MockPipelineResponseHeaders headers = new();
        string[] setValues = [ "Value1", "Value2", "Value3" ];

        headers.SetHeader("X-Multiple-Values", setValues[0]);
        headers.SetHeader("X-Multiple-Values", setValues[1]);
        headers.SetHeader("X-Multiple-Values", setValues[2]);

        Assert.That(headers.TryGetValues("X-Multiple-Values", out var headerValues), Is.True);

        foreach (var value in headerValues)
        {
            Assert.That(setValues.Contains(value), Is.True);
        }
        headers.TryGetValue("X-Multiple-Values", out string singleValue);

        Assert.That(singleValue, Is.EqualTo("Value1,Value2,Value3"));
    }

    [Test]
    public void ResponseHeadersJoinsMultipleValues()
    {
        MockPipelineResponseHeaders headers = new();
        string[] setValues = ["Value1", "Value2", "Value3"];

        headers.SetHeader("X-Multiple-Values", setValues[0]);
        headers.SetHeader("X-Multiple-Values", setValues[1]);
        headers.SetHeader("X-Multiple-Values", setValues[2]);
        headers.TryGetValue("X-Multiple-Values", out string singleValue);

        Assert.That(singleValue, Is.EqualTo("Value1,Value2,Value3"));
    }
    [Test]
    public void ResponseHeadersJoinsMultipleValuesGetEnumerator()
    {
        MockPipelineResponseHeaders headers = new();
        string[] setValues = ["Value1", "Value2", "Value3"];
        headers.SetHeader("X-Multiple-Values", setValues[0]);
        headers.SetHeader("X-Multiple-Values", setValues[1]);
        headers.SetHeader("X-Multiple-Values", setValues[2]);
        foreach (var header in headers)
        {
            if (header.Key == "X-Multiple-Values")
            {
                Assert.That(header.Value, Is.EqualTo("Value1,Value2,Value3"));
            }
        }
    }

    [Test]
    public void CanAddAndGetRequestHeaders()
    {
        MockPipelineRequestHeaders headers = new()
        {
            { "Content-Type", "application/json" },
            { "X-Custom-Header", "CustomValue" },
            { "X-Custom-Header", "CustomValue2" }
        };

        using (Assert.EnterMultipleScope())
        {
            Assert.That(headers.TryGetValue("Content-Type", out string contentType), Is.True);
            Assert.That(contentType, Is.EqualTo("application/json"));
            Assert.That(headers.TryGetValue("X-Custom-Header", out string customHeader), Is.True);
            Assert.That(customHeader, Is.EqualTo("CustomValue,CustomValue2"));
        }
    }

    [Test]
    public void CanAddAndGetMultipleValueRequestHeaders()
    {
        MockPipelineRequestHeaders headers = new();
        string[] setValues = ["Value1", "Value2", "Value3"];
        headers.Add("X-Multiple-Values", setValues[0]);
        headers.Add("X-Multiple-Values", setValues[1]);
        headers.Add("X-Multiple-Values", setValues[2]);

        Assert.That(headers.TryGetValues("X-Multiple-Values", out var headerValues), Is.True);

        foreach (var value in headerValues)
        {
            Assert.That(setValues.Contains(value), Is.True);
        }

        headers.TryGetValue("X-Multiple-Values", out string singleValue);
        Assert.That(singleValue, Is.EqualTo("Value1,Value2,Value3"));
    }
    [Test]
    public void RequestHeadersJoinsMultipleValues()
    {
        MockPipelineRequestHeaders headers = new();
        string[] setValues = ["Value1", "Value2", "Value3"];

        headers.Add("X-Multiple-Values", setValues[0]);
        headers.Add("X-Multiple-Values", setValues[1]);
        headers.Add("X-Multiple-Values", setValues[2]);

        foreach (var header in headers)
        {
            if (header.Key == "X-Multiple-Values")
            {
                Assert.That(header.Value, Is.EqualTo("Value1,Value2,Value3"));
            }
        }
    }

    [Test]
    public void CanSetRequestHeaders()
    {
        MockPipelineRequestHeaders headers = new();
        headers.Set("Content-Type", "application/json");
        headers.Set("X-Custom-Header", "CustomValue");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(headers.TryGetValue("Content-Type", out string contentType), Is.True);
            Assert.That(contentType, Is.EqualTo("application/json"));
            Assert.That(headers.TryGetValue("X-Custom-Header", out string customHeader), Is.True);
            Assert.That(customHeader, Is.EqualTo("CustomValue"));
        }

        headers.Set("X-Custom-Header", "NewValue");
        using (Assert.EnterMultipleScope())
        {
            Assert.That(headers.TryGetValue("X-Custom-Header", out string customHeader), Is.True);
            Assert.That(customHeader, Is.EqualTo("NewValue"));
        }
    }
}
