// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Core.TestFramework
{
    public class LiveParallelizableAttribute : ParallelizableAttribute
    {
        public LiveParallelizableAttribute(ParallelScope scope) : base(GetParallelScope(scope))
        {
        }

        private static ParallelScope GetParallelScope(ParallelScope scope)
        {
            RecordedTestMode mode = RecordedTestUtilities.GetModeFromEnvironment();
            return mode == RecordedTestMode.Live ? scope : ParallelScope.None;
        }
    }
}
