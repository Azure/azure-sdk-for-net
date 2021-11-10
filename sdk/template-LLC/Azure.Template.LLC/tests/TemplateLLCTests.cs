// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Web;

using NUnit.Framework;

namespace Azure.Template.LLC.Tests
{
    public class TemplateLLCTests
    {
        // Add unit tests here

        [Test]
        public void NoRequestBodyResponseBody()
        {
            var client = typeof(TemplateLLCClient);
            var method = client.GetMethod("NoRequestBodyResponseBody");
            var parameters = method.GetParameters();

            Assert.AreEqual(5, parameters.Length);
            Assert.AreEqual(parameters[0].ParameterType, typeof(int));
            Assert.AreEqual(parameters[0].IsOptional, false);
            Assert.AreEqual(parameters[1].ParameterType, typeof(int?));
            Assert.AreEqual(parameters[1].IsOptional, true);
            Assert.AreEqual(parameters[2].ParameterType, typeof(int));
            Assert.AreEqual(parameters[2].IsOptional, true);
            Assert.AreEqual(parameters[3].ParameterType, typeof(string));
            Assert.AreEqual(parameters[3].IsOptional, true);
            Assert.AreEqual(parameters[4].ParameterType, typeof(RequestContext));
            Assert.AreEqual(parameters[4].IsOptional, true);
        }
    }
}
