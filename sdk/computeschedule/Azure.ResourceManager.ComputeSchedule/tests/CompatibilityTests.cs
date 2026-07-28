// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.ResourceManager.ComputeSchedule.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ComputeSchedule.Tests
{
    public class CompatibilityTests
    {
        [Test]
        public void OptionalFactoryCallUsesGeneratedOverload()
        {
            Func<ResourceOperationDetails> factoryCall = () => ArmComputeScheduleModelFactory.ResourceOperationDetails();
            Func<ResourceOperationDetails> namedFactoryCall = () =>
                ArmComputeScheduleModelFactory.ResourceOperationDetails(operationId: "operation");

            Assert.That(factoryCall(), Is.Not.Null);
            Assert.That(namedFactoryCall(), Is.Not.Null);
        }

        [Test]
        public void LegacyFactoryOverloadRetainsBinarySignatureWithoutAmbiguousDefaults()
        {
            var legacyMethod = typeof(ArmComputeScheduleModelFactory).GetMethods()
                .Single(method => method.Name == nameof(ArmComputeScheduleModelFactory.ResourceOperationDetails) &&
                    method.GetParameters().Length == 12);

            Assert.That(legacyMethod.GetParameters().Take(11).All(parameter => !parameter.IsOptional), Is.True);
            Assert.That(legacyMethod.GetParameters()[11].IsOptional, Is.True);
        }
    }
}
