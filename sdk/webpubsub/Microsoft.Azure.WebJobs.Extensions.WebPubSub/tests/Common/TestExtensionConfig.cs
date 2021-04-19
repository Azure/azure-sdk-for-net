// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class TestExtensionConfig : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<BindingDataAttribute>().
                BindToInput(attr => attr.ToBeAutoResolve);
        }

        [Binding]
        private sealed class BindingDataAttribute : Attribute
        {
            public BindingDataAttribute(string toBeAutoResolve)
            {
                ToBeAutoResolve = toBeAutoResolve;
            }

            [AutoResolve]
            public string ToBeAutoResolve { get; set; }
        }
    }
}
