// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using NUnit.Framework;

namespace TestProjects.Local.Tests
{
    [TestFixture]
    public class RawRequestUriBuilderExtensionsTests
    {
        [TestCase("http://localhost", "param1", "value1", "http://localhost/?param1=value1")]
        [TestCase("http://localhost?existing=old", "param1", "value1", "http://localhost/?existing=old&param1=value1")]
        [TestCase("http://localhost?param1=old", "param1", "new", "http://localhost/?param1=new")]
        [TestCase("http://localhost?param1=old&param2=value2", "param1", "new", "http://localhost/?param1=new&param2=value2")]
        [TestCase("http://localhost?param2=value2&param1=old", "param1", "new", "http://localhost/?param2=value2&param1=new")]
        [TestCase("http://localhost?param2=value2&param1=old&param3=value3", "param1", "new", "http://localhost/?param2=value2&param1=new&param3=value3")]
        [TestCase("http://localhost?fooparam1=value2&param1=old", "param1", "new", "http://localhost/?fooparam1=value2&param1=new")]
        [TestCase("http://localhost?param1prefix=value2&param1=old", "param1", "new", "http://localhost/?param1prefix=value2&param1=new")]
        public void UpdateQuery(string endpoint, string name, string value, string expected)
        {
            var builder = new RawRequestUriBuilder();
            builder.Reset(new Uri(endpoint));

            BasicTypeSpec.RawRequestUriBuilderExtensions.UpdateQuery(builder, name, value);

            Assert.AreEqual(expected, builder.ToUri().ToString());
        }
    }
}