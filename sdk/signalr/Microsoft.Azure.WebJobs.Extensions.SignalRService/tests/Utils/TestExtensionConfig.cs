// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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