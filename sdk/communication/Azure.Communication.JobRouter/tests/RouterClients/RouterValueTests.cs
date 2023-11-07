// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.RouterClients
{
    public class RouterValueTests
    {
        [Test]
        public void RouterValueAcceptsNull()
        {
            var labelValue = new RouterValue(null);
            Assert.IsNotNull(labelValue);
            var testValue1 = new RouterValue(null);
            Assert.AreEqual(labelValue, testValue1);
            var testValue2 = new RouterValue(null);
            Assert.AreEqual(labelValue, testValue2);
        }

        [Test]
        public void RouterValueAcceptsInt16()
        {
            short input = 1;
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void RouterValueAcceptsInt32()
        {
            int input = 1;
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void RouterValueAcceptsInt64()
        {
            long input = 1;
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void RouterValueAcceptsFloat()
        {
            float input = 1;
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void RouterValueAcceptsDouble()
        {
            double input = 1;
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void RouterValueAcceptsDecimal()
        {
            decimal input = 1;
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void RouterValueAcceptsString()
        {
            string input = "1";
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void RouterValueAcceptsBoolean(bool input)
        {
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void RouterValueOverrideToString()
        {
            string input = "1";
            var labelValue = new RouterValue(input);
            Assert.AreEqual(labelValue.ToString(), labelValue.Value.ToString());
        }
    }
}
