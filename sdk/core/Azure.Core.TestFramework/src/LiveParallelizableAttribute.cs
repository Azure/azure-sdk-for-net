// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    /// <summary>
    /// Attribute on test assemblies, classes, or methods that defines parallelization behavior when tests are run in <see cref="RecordedTestMode.Live"/> mode.
    /// In other modes it will enforce no parallelization.
    /// </summary>
    public class LiveParallelizableAttribute : ParallelizableAttribute
    {
        public LiveParallelizableAttribute(ParallelScope scope) : base(ApplyModeToParallelScope(scope))
        {
        }

        private static ParallelScope ApplyModeToParallelScope(ParallelScope scope)
        {
            RecordedTestMode mode = RecordedTestUtilities.GetModeFromEnvironment();
            return mode == RecordedTestMode.Live ? scope : ParallelScope.None;
        }
    }
}
