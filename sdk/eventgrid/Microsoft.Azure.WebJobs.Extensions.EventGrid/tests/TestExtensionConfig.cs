// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests
{
    public class TestExtensionConfig : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<BindingDataAttribute>().
                BindToInput<string>(attr => attr.ToBeAutoResolve);
        }
    }
}
