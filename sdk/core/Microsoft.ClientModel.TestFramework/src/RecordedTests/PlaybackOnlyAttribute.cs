// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// Attribute on test assemblies, classes, or methods that run only against playback resources.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
public class PlaybackOnlyAttribute : NUnitAttribute, IApplyToTest
{
    private readonly string _reason;

    /// <summary>
    /// Constructs the attribute giving a reason the associated tests is playback only.
    /// </summary>
    public PlaybackOnlyAttribute(string reason)
    {
        _reason = reason;
    }

    /// <summary>
    /// Modifies the <paramref name="test"/> by adding categories to it and changing the run state as needed.
    /// </summary>
    /// <param name="test">The <see cref="Test"/> to modify.</param>
    public void ApplyToTest(Test test)
    {
        if (test.RunState != RunState.NotRunnable)
        {
            RecordedTestMode mode = TestEnvironment.GlobalTestMode;
            if (mode != RecordedTestMode.Playback)
            {
                test.RunState = RunState.Ignored;
                test.Properties.Set("_SKIPREASON", $"Playback tests will not run when CLIENTMODEL_TEST_MODE is {mode}.  This test was skipped for the following reason: {_reason}");
            }
        }
    }
}
