// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.Core.TestFramework
{
    public static class TestTimeoutHelper
    {
        public static Action<IList<ITest>> ZeroTestsTimeoutProperty = tests =>
        {
            foreach (ITest testInstance in tests)
            {
                testInstance.Properties.Set(PropertyNames.Timeout, 0);
                if (testInstance.HasChildren)
                {
                    foreach (ITest child in testInstance.Tests)
                    {
                        child.Properties.Set(PropertyNames.Timeout, 0);
                    }
                }
            }
        };
    }
}
