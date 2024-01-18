// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Communication.PhoneNumbers.Tests
{
    public class PhoneNumberSearchResultErrorTests
    {
        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenValueIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ErrorMessage(null));
        }

        [TestCase("NoError")]
        [TestCase("UnknownErrorCode")]
        [TestCase("OutOfStock")]
        [TestCase("AuthorizationDenied")]
        [TestCase("MissingAddress")]
        [TestCase("InvalidAddress")]
        [TestCase("InvalidOfferModel")]
        [TestCase("NotEnoughLicenses")]
        [TestCase("NoWallet")]
        [TestCase("NotEnoughCredit")]
        [TestCase("NumbersPartiallyAcquired")]
        [TestCase("AllNumbersNotAcquired")]
        [TestCase("ReservationExpired")]
        [TestCase("PurchaseFailed")]
        [TestCase("BillingUnavailable")]
        [TestCase("ProvisioningFailed")]
        [TestCase("UnknownSearchError")]
        public void Constructor_SetsValue_WhenValueIsNotNull(string value)
        {
            var error = new ErrorMessage(value);
            Assert.AreEqual(value, error.ToString());
        }

        [Test]
        public void OperatorEquals_ReturnsTrue_WhenValuesAreEqual()
        {
            var error1 = new ErrorMessage("NoError");
            var error2 = new ErrorMessage("NoError");

            Assert.IsTrue(error1 == error2);
        }

        [Test]
        public void OperatorNotEquals_ReturnsTrue_WhenValuesAreNotEqual()
        {
            var error1 = new ErrorMessage("NoError");
            var error2 = new ErrorMessage("UnknownErrorCode");

            Assert.IsTrue(error1 != error2);
        }

        [Test]
        public void ImplicitConversion_ReturnsCorrectError()
        {
            ErrorMessage error = "NoError";
            Assert.AreEqual("NoError", error.ToString());
        }

        [Test]
        public void Equals_ReturnsTrue_WhenValuesAreEqual()
        {
            var error1 = new ErrorMessage("NoError");
            var error2 = new ErrorMessage("NoError");

            Assert.IsTrue(error1.Equals(error2));
        }

        [Test]
        public void Equals_ReturnsFalse_WhenValuesAreNotEqual()
        {
            var error1 = new ErrorMessage("NoError");
            var error2 = new ErrorMessage("UnknownErrorCode");

            Assert.IsFalse(error1.Equals(error2));
        }

        [Test]
        public void GetHashCode_ReturnsEqualHashCodes_WhenValuesAreEqual()
        {
            var error1 = new ErrorMessage("NoError");
            var error2 = new ErrorMessage("NoError");

            Assert.AreEqual(error1.GetHashCode(), error2.GetHashCode());
        }

        [Test]
        public void ToString_ReturnsCorrectValue()
        {
            var error = new ErrorMessage("NoError");
            Assert.AreEqual("NoError", error.ToString());
        }
    }
}
