// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    internal class TupleStringIgnoreCasesComparer : IEqualityComparer<(string, string, string)>
    {
        public static readonly TupleStringIgnoreCasesComparer Instance = new TupleStringIgnoreCasesComparer();

        public bool Equals((string, string, string) x, (string, string, string) y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(x.Item1, y.Item1) &&
                   StringComparer.InvariantCultureIgnoreCase.Equals(x.Item2, y.Item2) &&
                   StringComparer.InvariantCultureIgnoreCase.Equals(x.Item3, y.Item3);
        }

        public int GetHashCode((string, string, string) obj)
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Item1) ^
                   StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Item2) ^
                   StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Item3);
        }
    }
}