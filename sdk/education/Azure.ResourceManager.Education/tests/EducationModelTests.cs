// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.ResourceManager.Education.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Education.Tests
{
    public class EducationModelTests
    {
        [Test]
        public void Amount_ModelFactory_RoundTrips()
        {
            Amount amount = ArmEducationModelFactory.Amount(currency: "USD", value: 100f);

            BinaryData data = ModelReaderWriter.Write(amount);
            Amount roundTripped = ModelReaderWriter.Read<Amount>(data);

            Assert.That(roundTripped, Is.Not.Null);
            Assert.That(roundTripped.Currency, Is.EqualTo("USD"));
            Assert.That(roundTripped.Value, Is.EqualTo(100f));
        }

        [Test]
        public void LabDetailsData_FlattenedBudgetAccessors_AreNullWhenPropertiesUnset()
        {
            // Guards the Customized/Models/LabProperties.cs flatten workaround (see issue 60644):
            // the two Amount envelopes surface here as distinct null-safe accessors.
            LabDetailsData data = new LabDetailsData();

            Assert.That(data.TotalBudgetCurrency, Is.Null);
            Assert.That(data.TotalBudgetValue, Is.Null);
            Assert.That(data.TotalAllocatedBudgetCurrency, Is.Null);
            Assert.That(data.TotalAllocatedBudgetValue, Is.Null);
        }
    }
}
