// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Base class for tests that need to run live but are not recorded and don't need sync/async testing support of <see cref="ClientTestBase"/>
/// </summary>
/// <typeparam name="TEnvironment">The <see cref="TestEnvironment"/> implementation to use.</typeparam>
[LiveOnly]
public class LiveTestBase<TEnvironment> where TEnvironment : TestEnvironment, new()
{
    /// <summary>
    /// TODO.
    /// </summary>
    protected LiveTestBase()
    {
        TestEnvironment = new TEnvironment()
        {
            Mode = RecordedTestMode.Live
        };
    }

    /// <summary>
    /// TODO.
    /// </summary>
    protected TEnvironment TestEnvironment { get; }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <returns></returns>
    [OneTimeSetUp]
    public async ValueTask WaitForEnvironment()
    {
        await TestEnvironment.WaitForEnvironmentAsync().ConfigureAwait(false);
    }
}
