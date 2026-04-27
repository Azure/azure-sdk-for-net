// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class LabelValueTests
    {
        [Test]
        public void LabelValueAcceptsNull()
        {
            var labelValue = new RouterValue(null);
            Assert.That(labelValue, Is.Not.Null);
            var testValue1 = new RouterValue(null);
            Assert.That(testValue1, Is.EqualTo(labelValue));
            var testValue2 = new RouterValue(null);
            Assert.That(testValue2, Is.EqualTo(labelValue));
        }

        [Test]
        public void LabelValueAcceptsInt16()
        {
            short input = 1;
            var labelValue = new RouterValue(input);
            Assert.That(labelValue, Is.Not.Null);
            var testValue = new RouterValue(input);
            Assert.That(testValue, Is.EqualTo(labelValue));
        }

        [Test]
        public void LabelValueAcceptsInt32()
        {
            int input = 1;
            var labelValue = new RouterValue(input);
            Assert.That(labelValue, Is.Not.Null);
            var testValue = new RouterValue(input);
            Assert.That(testValue, Is.EqualTo(labelValue));
        }

        [Test]
        public void LabelValueAcceptsInt64()
        {
            long input = 1;
            var labelValue = new RouterValue(input);
            Assert.That(labelValue, Is.Not.Null);
            var testValue = new RouterValue(input);
            Assert.That(testValue, Is.EqualTo(labelValue));
        }

        [Test]
        public void LabelValueAcceptsFloat()
        {
            float input = 1;
            var labelValue = new RouterValue(input);
            Assert.That(labelValue, Is.Not.Null);
            var testValue = new RouterValue(input);
            Assert.That(testValue, Is.EqualTo(labelValue));
        }

        [Test]
        public void LabelValueAcceptsDouble()
        {
            double input = 1;
            var labelValue = new RouterValue(input);
            Assert.That(labelValue, Is.Not.Null);
            var testValue = new RouterValue(input);
            Assert.That(testValue, Is.EqualTo(labelValue));
        }

        [Test]
        public void LabelValueAcceptsDecimal()
        {
            decimal input = 1;
            var labelValue = new RouterValue(input);
            Assert.That(labelValue, Is.Not.Null);
            var testValue = new RouterValue(input);
            Assert.That(testValue, Is.EqualTo(labelValue));
        }

        [Test]
        public void LabelValueAcceptsString()
        {
            string input = "1";
            var labelValue = new RouterValue(input);
            Assert.That(labelValue, Is.Not.Null);
            var testValue = new RouterValue(input);
            Assert.That(testValue, Is.EqualTo(labelValue));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void LabelValueAcceptsBoolean(bool input)
        {
            var labelValue = new RouterValue(input);
            Assert.That(labelValue, Is.Not.Null);
            var testValue = new RouterValue(input);
            Assert.That(testValue, Is.EqualTo(labelValue));
        }

        [Test]
        public void LabelValueOverrideToString()
        {
            string input = "1";
            var labelValue = new RouterValue(input);
            Assert.That(labelValue.Value.ToString(), Is.EqualTo(labelValue.ToString()));
        }
    }
}
