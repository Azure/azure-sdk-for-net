// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.UnitTests
{
    using System;
    using Xunit.Sdk;

    [TraitDiscoverer("Xunit.Sdk.TraitDiscoverer", "xunit.core")]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class LiveTestAttribute : Attribute, ITraitAttribute
    {
        public LiveTestAttribute(string name = "TestCategory", string value = "Live") { }
    }
}
