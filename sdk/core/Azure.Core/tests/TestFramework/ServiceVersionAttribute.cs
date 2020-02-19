// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Testing
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ServiceVersionAttribute : NUnitAttribute
    {
        public object Min { get; set; }
        public object Max { get; set; }
    }
}
