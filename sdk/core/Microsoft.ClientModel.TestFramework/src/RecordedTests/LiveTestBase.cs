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
    /// Initializes a new instance of the <see cref="LiveTestBase{TEnvironment}"/> class.
    /// Creates a new test environment instance and sets it to Live mode.
    /// </summary>
    protected LiveTestBase()
    {
        TestEnvironment = new TEnvironment()
        {
            Mode = RecordedTestMode.Live
        };
    }

    /// <summary>
    /// Gets the test environment instance configured for live testing.
    /// </summary>
    protected TEnvironment TestEnvironment { get; }

    /// <summary>
    /// Waits for the test environment to be ready for testing.
    /// This method is called once before any tests in the class are executed.
    /// </summary>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    [OneTimeSetUp]
    public async ValueTask WaitForEnvironment()
    {
        await TestEnvironment.WaitForEnvironmentAsync().ConfigureAwait(false);
    }
}
