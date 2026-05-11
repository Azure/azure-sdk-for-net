// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using Azure.ResourceManager.ComputeSchedule.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ComputeSchedule.Tests
{
    public class ComputeScheduleZoneAllocationPolicyTests
    {
        [TestCase("{\"distributionStrategy\":null}", "null")]
        [TestCase("{}", "missing")]
        public void DeserializeThrowsFormatExceptionWhenDistributionStrategyIsInvalid(string json, string expectedCondition)
        {
            static ComputeScheduleZoneAllocationPolicy Deserialize(string value) =>
                ModelReaderWriter.Read<ComputeScheduleZoneAllocationPolicy>(BinaryData.FromString(value), ModelReaderWriterOptions.Json);

            FormatException exception = Assert.Throws<FormatException>(() => Deserialize(json));

            Assert.That(exception.Message, Is.EqualTo($"Required property 'distributionStrategy' was {expectedCondition} when deserializing {nameof(ComputeScheduleZoneAllocationPolicy)}."));
        }
    }
}
