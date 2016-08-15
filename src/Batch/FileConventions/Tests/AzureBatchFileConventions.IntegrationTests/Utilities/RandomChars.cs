// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities
{
    internal static class RandomChars
    {
        private static readonly Random _random = new Random();

        private static readonly char[] CharsForRandomId =
            Enumerable.Range((int)'a', 26).Concat(Enumerable.Range((int)'0', 10))
                      .Select(i => (char)i)
                      .ToArray();

        internal static string RandomString(int count)
        {
            return new string(RandomChar(count).ToArray());
        }

        private static IEnumerable<char> RandomChar(int count)
        {
            return Enumerable.Range(0, count).Select(_ => RandomChar());
        }

        private static char RandomChar()
        {
            return CharsForRandomId[_random.Next(CharsForRandomId.Length - 1)];
        }
    }
}
