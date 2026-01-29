// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Attribute on test assemblies, classes, or methods that defines parallelization behavior when tests are run in <see cref="RecordedTestMode.Live"/> mode.
/// In other modes it will enforce no parallelization.
/// </summary>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class LiveParallelizableAttribute : ParallelizableAttribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LiveParallelizableAttribute"/> class.
    /// The parallelization scope is applied only when tests are running in Live mode; otherwise, no parallelization is used.
    /// </summary>
    /// <param name="scope">The scope of parallelization to apply when in Live mode.</param>
    public LiveParallelizableAttribute(ParallelScope scope) : base(ApplyModeToParallelScope(scope))
    {
    }

    private static ParallelScope ApplyModeToParallelScope(ParallelScope scope)
    {
        return TestEnvironment.GlobalTestMode == RecordedTestMode.Live ? scope : ParallelScope.None;
    }
}
