// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if NET6_0_OR_GREATER
using Microsoft.Azure.ServiceBus.Grpc;
using Microsoft.Azure.WebJobs.Extensions.ServiceBus.Grpc;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.ServiceBus.UnitTests.Grpc
{
    public class SettlementPropertiesTests
    {
        // [Test]
        // public void CanGetStringValue()
        // {
        //     var properties = new SettlementProperties
        //     {
        //         StringValue = "foo"
        //     };
        //     Assert.AreEqual("foo", properties.GetPropertyValue());
        // }
        //
        // [Test]
        // public void CanGetIntValue()
        // {
        //     var properties = new SettlementProperties
        //     {
        //         IntValue = 42
        //     };
        //     Assert.AreEqual(42, properties.GetPropertyValue());
        // }
        //
        // [Test]
        // public void CanGetUintValue()
        // {
        //     var properties = new SettlementProperties
        //     {
        //         UintValue = 42
        //     };
        //     Assert.AreEqual(42, properties.GetPropertyValue());
        // }
        //
        // [Test]
        // public void CanGetLongValue()
        // {
        //     var properties = new SettlementProperties
        //     {
        //         LongValue = 42
        //     };
        //     Assert.AreEqual(42, properties.GetPropertyValue());
        // }
        //
        // [Test]
        // public void CanGetUlongValue()
        // {
        //     var properties = new SettlementProperties
        //     {
        //         UlongValue = 42
        //     };
        //     Assert.AreEqual(42, properties.GetPropertyValue());
        // }
        //
        // [Test]
        // public void CanGetFloatValue()
        // {
        //     var properties = new SettlementProperties
        //     {
        //         FloatValue = 42.0f
        //     };
        //     Assert.AreEqual(42.0, properties.GetPropertyValue());
        // }
        //
        // [Test]
        // public void CanGetDoubleValue()
        // {
        //     var properties = new SettlementProperties
        //     {
        //         DoubleValue = 42.0
        //     };
        //     Assert.AreEqual(42.0, properties.GetPropertyValue());
        // }
        //
        // [Test]
        // public void CanGetBoolValue()
        // {
        //     var properties = new SettlementProperties
        //     {
        //         BoolValue = true
        //     };
        //     Assert.IsTrue((bool)properties.GetPropertyValue());
        // }
    }
}
#endif