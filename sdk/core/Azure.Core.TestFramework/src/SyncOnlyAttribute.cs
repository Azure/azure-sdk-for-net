// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    /// <summary>
    /// Marks that a test should only be executed synchronously (in a test
    /// fixture derived from <see cref="ClientTestBase"/>).
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
    public class SyncOnlyAttribute : NUnitAttribute
    {
    }
}
