// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Collections.Generic;

namespace Xunit
{
    public static class TheoryDataExtensions
    {
        public static TheoryData<T> PopulateFrom<T>(this TheoryData<T> testData, IEnumerable<T> source)
        {
            foreach (var t in source)
            {
                testData.Add(t);
            }

            return testData;
        }

        public static TheoryData<T1, T2> PopulateFrom<T1, T2>(this TheoryData<T1, T2> testData, IEnumerable<(T1, T2)> source)
        {
            foreach (var (t1, t2) in source)
            {
                testData.Add(t1, t2);
            }

            return testData;
        }

        public static TheoryData<T1, T2, T3> PopulateFrom<T1, T2, T3>(
            this TheoryData<T1, T2, T3> testData, 
            IEnumerable<(T1, T2, T3)> source)
        {
            foreach (var (t1, t2, t3) in source)
            {
                testData.Add(t1, t2, t3);
            }

            return testData;
        }

        public static TheoryData<T1, T2, T3, T4> PopulateFrom<T1, T2, T3, T4>(
            this TheoryData<T1, T2, T3, T4> testData,
            IEnumerable<(T1, T2, T3, T4)> source)
        {
            foreach (var (t1, t2, t3, t4) in source)
            {
                testData.Add(t1, t2, t3, t4);
            }

            return testData;
        }
    }
}
