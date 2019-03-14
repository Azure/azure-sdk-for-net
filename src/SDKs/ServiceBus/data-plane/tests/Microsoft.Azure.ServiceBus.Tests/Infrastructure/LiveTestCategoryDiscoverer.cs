// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System.Collections.Generic;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    /// <summary>
    ///   Allows the XUnit framework to identify the decorated reference as having a "Live" test category
    ///   trait.
    ///   
    /// </summary
    /// 
    /// <remarks>
    ///   Based on the XUnit Sample:
    ///   https://github.com/xunit/samples.xunit/tree/master/TraitExtensibility
    /// </remarks>
    /// 
    public class LiveTestCategoryDiscoverer : ITraitDiscoverer
    {
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            yield return new KeyValuePair<string, string>("TestCategory", "Live");
        }
    }
}
