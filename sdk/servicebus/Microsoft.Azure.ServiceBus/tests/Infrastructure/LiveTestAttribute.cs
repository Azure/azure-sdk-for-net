// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information

using System;
using Xunit.Sdk;

namespace Microsoft.Azure.ServiceBus.UnitTests.Infrastructure
{
	[TraitDiscoverer("Xunit.Sdk.TraitDiscoverer", "xunit.core")]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class LiveTestAttribute : Attribute, ITraitAttribute
    {
    }
}
