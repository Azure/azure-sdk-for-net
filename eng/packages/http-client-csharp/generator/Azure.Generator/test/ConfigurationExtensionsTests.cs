// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Azure.Generator.Extensions;

namespace Azure.Generator.Tests
{
    public class ConfigurationExtensionsTests
    {
        [TestCase(null, false)] // no value = default false
        [TestCase("true", true)]
        [TestCase("false", false)]
        [TestCase("invalid", false)] // unparsable = fallback to false
        public void UseModelNamespaceIsSetCorrectly(string? value, bool expected)
        {
            var options = value is null
                ? new Dictionary<string, BinaryData>()
                : new Dictionary<string, BinaryData> { ["model-namespace"] = new BinaryData(value) };

            var result = ConfigurationExtensions.UseModelNamespace(options);

            Assert.AreEqual(expected, result);
        }
    }
}