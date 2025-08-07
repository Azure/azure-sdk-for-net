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
            Assert.IsNotNull(labelValue);
            var testValue1 = new RouterValue(null);
            Assert.AreEqual(labelValue, testValue1);
            var testValue2 = new RouterValue(null);
            Assert.AreEqual(labelValue, testValue2);
        }

        [Test]
        public void LabelValueAcceptsInt16()
        {
            short input = 1;
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void LabelValueAcceptsInt32()
        {
            int input = 1;
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void LabelValueAcceptsInt64()
        {
            long input = 1;
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void LabelValueAcceptsFloat()
        {
            float input = 1;
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void LabelValueAcceptsDouble()
        {
            double input = 1;
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void LabelValueAcceptsDecimal()
        {
            decimal input = 1;
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void LabelValueAcceptsString()
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
        public void LabelValueAcceptsBoolean(bool input)
        {
            var labelValue = new RouterValue(input);
            Assert.IsNotNull(labelValue);
            var testValue = new RouterValue(input);
            Assert.AreEqual(labelValue, testValue);
        }

        [Test]
        public void LabelValueOverrideToString()
        {
            string input = "1";
            var labelValue = new RouterValue(input);
            Assert.AreEqual(labelValue.ToString(), labelValue.Value.ToString());
        }
    }
}
