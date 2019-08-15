// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information

namespace Microsoft.Azure.EventHubs.Tests
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
