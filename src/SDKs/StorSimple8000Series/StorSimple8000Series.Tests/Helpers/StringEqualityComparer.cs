// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;

namespace StorSimple8000Series.Tests
{
    class StringIgnoreCaseEqualityComparer : EqualityComparer<string>
    {
        public override bool Equals(string x, string y)
        {
            return (string.Equals(x, y, StringComparison.OrdinalIgnoreCase));
        }

        public override int GetHashCode(string x)
        {
            return x.GetHashCode();
        }
    }
}