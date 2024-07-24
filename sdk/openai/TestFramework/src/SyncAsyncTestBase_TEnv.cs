// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI.TestFramework.Utils;

namespace OpenAI.TestFramework;

/// <summary>
/// Base class for test cases. This provides support for writing only a test that uses the Async version of methods,
/// and automatically creating a test that uses the equivalent Sync version of a method. Please note that this will
/// only work for public virtual methods. In order for this to work, you should write a test that uses the async
/// version of a method.
/// </summary>
/// <typeparam name="TEnv">The type of the environment.</typeparam>
public abstract class SyncAsyncTestBase<TEnv> : SyncAsyncTestBase where TEnv : TestEnvironment
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SyncAsyncTestBase{TEnvironment}"/> class.
    /// </summary>
    /// <param name="isAsync">True to run the async version of a test, false to run the sync version of a test.</param>
    /// <param name="createEnv">(Optional) A function to create the environment instance. If not set will try to use
    /// the parameterless constructor</param>
    public SyncAsyncTestBase(bool isAsync, Func<TEnv>? createEnv = null) : base(isAsync)
    {
        Environment = (createEnv ?? Helpers.CreateWithParameterlessConstructor<TEnv>())();
    }

    /// <summary>
    /// Gets the environment instance.
    /// </summary>
    public TEnv Environment { get; }
}
