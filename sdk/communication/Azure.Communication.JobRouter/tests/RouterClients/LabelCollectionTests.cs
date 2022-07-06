// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class LabelCollectionTests
    {
        [Test]
        public void should_validate_value_type_on_add()
        {
            // arrange
            var subject = new LabelCollection();

            // act & assert
            Assert.DoesNotThrow(() => subject.Add("k1", new LabelValue("string")));
            Assert.DoesNotThrow(() => subject.Add("k2", new LabelValue(1)));
            Assert.DoesNotThrow(() => subject.Add("k3", new LabelValue(1.5)));
            Assert.DoesNotThrow(() => subject.Add("k4", new LabelValue(true)));
            Assert.Throws<ArgumentException>(() => subject.Add("k5", new LabelValue(new object())));
        }

        [Test]
        public void should_validate_value_type_on_init()
        {
            Assert.DoesNotThrow(() => new LabelCollection()
            {
                ["k1"] = new LabelValue("string")
            });
            Assert.DoesNotThrow(() => new LabelCollection()
            {
                ["k1"] = new LabelValue(1)
            });
            Assert.DoesNotThrow(() => new LabelCollection()
            {
                ["k1"] = new LabelValue(1.5)
            });
            Assert.DoesNotThrow(() => new LabelCollection()
            {
                ["k1"] = new LabelValue(true)
            });
            Assert.Throws<ArgumentException>(() => new LabelCollection()
            {
                ["k1"] = new LabelValue(new object())
            });
        }

        [Test]
        public void should_accept_any_value_from_server()
        {
            var rawValues = new Dictionary<string, object>
            {
                ["k1"] = "string",
                ["k2"] = 1,
                ["k3"] = 1.5,
                ["k4"] = true,
                ["k5"] = new int[] { 1, 2, 3 },
            };

            var labels = LabelCollection.BuildFromRawValues(rawValues);

            foreach (var item in rawValues)
            {
                Assert.AreEqual(item.Value, labels[item.Key].Value);
            }
        }
    }
}
