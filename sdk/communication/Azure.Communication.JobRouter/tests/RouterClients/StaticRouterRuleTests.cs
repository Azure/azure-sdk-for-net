// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class StaticRouterRuleTests
    {
        [Test]
        [TestCase(1)]
        [TestCase(1f)]
        [TestCase(1d)]
        [TestCase("1d")]
        [TestCase(true)]
        [TestCase(null)]
        [Parallelizable(ParallelScope.All)]
        public void RouterRuleAcceptsValueInConstructor(object input)
        {
            Assert.DoesNotThrow(() =>
            {
                var rule = new StaticRouterRule(new Value(input));

                var inputType = input.GetType();
                var actualType = rule.Value.Type;

                Assert.AreEqual(input.GetType(), rule.Value.Type);
                Assert.AreEqual(input, rule.Value.As<object>());
            });
        }

        [Test]
        public void TestAzureValue()
        {
            var value = new Value(1);
            var type = value.Type;

            Console.WriteLine(type);
            Console.WriteLine(value);

            Console.WriteLine(value.As<int>());

            // var intValue = (object)2.0;
            var intValue = 2.0;
            var value2 = new Value(intValue);
            var type2 = value2.Type;
            Console.WriteLine(type2);
            Console.WriteLine(value2);
            // Console.WriteLine(JsonSerializer.Serialize(value2));

            Console.WriteLine(value2.As<double>());

            value2.TryGetValue<object>(out var val);

            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(val);

            Console.WriteLine(content);
        }

        [Test]
        public void TestAzureValue2()
        {
            var value = new Value((int?)null);

            Console.WriteLine(value.Type);

            var value2 = new Value(2);

            Console.WriteLine(value2.Type);

            value2 = new Value(3.0f);

            Console.WriteLine(value2.Type);
        }
    }
}
