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
        Assert.IsTrue(headers.TryGetValue("Content-Type", out string contentType));
        Assert.AreEqual("application/json", contentType);
        Assert.IsTrue(headers.TryGetValue("X-Custom-Header", out string customHeader));
        Assert.AreEqual("CustomValue", customHeader);
    }

    [Test]
    public void SettingMultipleValuesResponseHeaders()
    {
        MockPipelineResponseHeaders headers = new();
        string[] setValues = [ "Value1", "Value2", "Value3" ];
        headers.SetHeader("X-Multiple-Values", setValues[0]);
        headers.SetHeader("X-Multiple-Values", setValues[1]);
        headers.SetHeader("X-Multiple-Values", setValues[2]);
        Assert.IsTrue(headers.TryGetValues("X-Multiple-Values", out var headerValues));
        foreach (var value in headerValues)
        {
            Assert.IsTrue(setValues.Contains(value));
        }

        headers.TryGetValue("X-Multiple-Values", out string singleValue);
        Assert.AreEqual("Value1,Value2,Value3", singleValue);
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
        Assert.AreEqual("Value1,Value2,Value3", singleValue);
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
                Assert.AreEqual("Value1,Value2,Value3", header.Value);
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

        Assert.IsTrue(headers.TryGetValue("Content-Type", out string contentType));
        Assert.AreEqual("application/json", contentType);
        Assert.IsTrue(headers.TryGetValue("X-Custom-Header", out string customHeader));
        Assert.AreEqual("CustomValue,CustomValue2", customHeader);
    }

    [Test]
    public void CanAddAndGetMultipleValueRequestHeaders()
    {
        MockPipelineRequestHeaders headers = new();
        string[] setValues = ["Value1", "Value2", "Value3"];
        headers.Add("X-Multiple-Values", setValues[0]);
        headers.Add("X-Multiple-Values", setValues[1]);
        headers.Add("X-Multiple-Values", setValues[2]);
        Assert.IsTrue(headers.TryGetValues("X-Multiple-Values", out var headerValues));
        foreach (var value in headerValues)
        {
            Assert.IsTrue(setValues.Contains(value));
        }
        headers.TryGetValue("X-Multiple-Values", out string singleValue);
        Assert.AreEqual("Value1,Value2,Value3", singleValue);
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
                Assert.AreEqual("Value1,Value2,Value3", header.Value);
            }
        }
    }

    [Test]
    public void CanSetRequestHeaders()
    {
        MockPipelineRequestHeaders headers = new();
        headers.Set("Content-Type", "application/json");
        headers.Set("X-Custom-Header", "CustomValue");
        Assert.IsTrue(headers.TryGetValue("Content-Type", out string contentType));
        Assert.AreEqual("application/json", contentType);
        Assert.IsTrue(headers.TryGetValue("X-Custom-Header", out string customHeader));
        Assert.AreEqual("CustomValue", customHeader);
        headers.Set("X-Custom-Header", "NewValue");
        Assert.IsTrue(headers.TryGetValue("X-Custom-Header", out customHeader));
        Assert.AreEqual("NewValue", customHeader);
    }
}