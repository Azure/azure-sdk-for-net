// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework;

/// <summary>
/// Attribute used to indicate that a test fixture should automatically be be run in both synchronous and asynchronous mode.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class AutoSyncAsyncTestFixtureAttribute : NUnitAttribute, IFixtureBuilder2
{
    /// <inheritdoc />
    public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo)
        => BuildFrom(typeInfo, null!);

    /// <inheritdoc />
    public IEnumerable<TestSuite> BuildFrom(ITypeInfo typeInfo, IPreFilter filter)
    {
        List<TestSuite> suites =
        [
            .. new TestFixtureAttribute([false]).BuildFrom(typeInfo, new AndPreFilter(filter, new SyncAsyncPreFilter(false))),
            .. new TestFixtureAttribute([true]).BuildFrom(typeInfo, new AndPreFilter(filter, new SyncAsyncPreFilter(true))),
        ];

        return suites;
    }
}
