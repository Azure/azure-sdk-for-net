// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Web;

using NUnit.Framework;

namespace Azure.Template.LLC.Tests
{
    public class TemplateServiceTests
    {
        // Add unit tests here

        [Test]
        public void GetResourceTest()
        {
            var client = typeof(TemplateServiceClient);
            var method = client.GetMethod("Get");
            var parameters = method.GetParameters();

            Assert.AreEqual(2, parameters.Length);
            Assert.AreEqual(parameters[0].ParameterType, typeof(string));
            Assert.AreEqual(parameters[0].IsOptional, false);
            Assert.AreEqual(parameters[1].ParameterType, typeof(RequestContext));
            Assert.AreEqual(parameters[1].IsOptional, true);
        }
    }
}
