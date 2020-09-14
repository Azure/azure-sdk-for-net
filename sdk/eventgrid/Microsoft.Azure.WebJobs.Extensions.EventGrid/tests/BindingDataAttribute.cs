// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Description;
using System;

namespace Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests
{
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
}
