// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace SignalRServiceExtension.Tests.Utils
{
    public class TestExtensionConfig : IExtensionConfigProvider
    {
        // todo: what's this
        [Binding]
        public class BindingDataAttribute : Attribute
        {
            public BindingDataAttribute(string toBeAutoResolve)
            {
                ToBeAutoResolve = toBeAutoResolve;
            }

            [AutoResolve]
            public string ToBeAutoResolve { get; set; }
        }

        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<BindingDataAttribute>().
                BindToInput<string>(attr => attr.ToBeAutoResolve);
        }
    }
}