// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class TupleStringIgnoreCasesComparer : IEqualityComparer<(string Item1, string Item2, string Item3)>
    {
        public static readonly TupleStringIgnoreCasesComparer Instance = new TupleStringIgnoreCasesComparer();

        public bool Equals((string Item1, string Item2, string Item3) x, (string Item1, string Item2, string Item3) y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(x.Item1, y.Item1) &&
                   StringComparer.InvariantCultureIgnoreCase.Equals(x.Item2, y.Item2) &&
                   StringComparer.InvariantCultureIgnoreCase.Equals(x.Item3, y.Item3);
        }

        public int GetHashCode((string Item1, string Item2, string Item3) obj)
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Item1) ^
                   StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Item2) ^
                   StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Item3);
        }
    }
}