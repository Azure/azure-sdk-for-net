// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.EventGrid.Tests
{
    internal class TestPayload
    {
        public TestPayload(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public TestPayload() { }

        public string Name { get; set; }
        public int Age { get; set; }
    }

#pragma warning disable SA1402 // File may only contain a single type
    internal class DerivedTestPayload: TestPayload
#pragma warning restore SA1402 // File may only contain a single type
    {
        public int? DerivedProperty { get; set; }
    }
}
