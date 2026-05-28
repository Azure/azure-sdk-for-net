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

﻿using FsCheck;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files.UnitTests.Generators
{
    public static class BatchIdGenerator
    {
        private static readonly IEnumerable<char> IdChars =
            Enumerable.Range((int)'A', 26).Concat(
            Enumerable.Range((int)'a', 26)).Concat(
            Enumerable.Range((int)'0', 10)).Concat(
            new int[] { '-', '_', ':' })
            .Select(i => (char)i)  // Need to use Select because Cast<char> fails with InvalidCastException
            .ToList().AsReadOnly();

        private static readonly IEnumerable<char> ContainerNameChars =
            Enumerable.Range((int)'a', 26).Concat(
            Enumerable.Range((int)'0', 10)).Concat(
            new int[] { '-' })
            .Select(i => (char)i)  // Need to use Select because Cast<char> fails with InvalidCastException
            .ToList().AsReadOnly();

        private static readonly IEnumerable<char> ContainerNameTerminalChars =
            Enumerable.Range((int)'a', 26).Concat(
            Enumerable.Range((int)'0', 10))
            .Select(i => (char)i)  // Need to use Select because Cast<char> fails with InvalidCastException
            .ToList().AsReadOnly();

        public static Arbitrary<BatchId> BatchId => Arb.From(BatchIdGen, BatchIdShrink);
        public static Arbitrary<BatchIdThatIsValidContainerName> BatchIdThatIsValidContainerName => Arb.From(BatchIdThatIsValidContainerNameGen, BatchIdThatIsValidContainerNameShrink);

        private static readonly Gen<BatchId> BatchIdGen =
            from len in Gen.Choose(1, 64)
            from chars in Gen.ArrayOf(len, Gen.Elements(IdChars))
            select new BatchId(new string(chars));

        private static IEnumerable<BatchId> BatchIdShrink(BatchId batchId)
        {
            var id = batchId.ToString();
            return (id == null || id.Length <= 1) ?
                Enumerable.Empty<BatchId>() :
                Enumerable.Range(0, id.Length - 1).Select(index => new BatchId(id.Remove(index, 1)));
        }

        private static string ConcatChars(char startChar, char[] midChars, char endChar)
        {
            return startChar + new string(midChars) + endChar;
        }

        private static readonly Gen<BatchIdThatIsValidContainerName> BatchIdThatIsValidContainerNameGen =
            from len in Gen.Choose(1, 57)  // need to allow for "job-" prefix and non-dash leading and trailing chars: 63 = 4 + 1 + 57 + 1
            from startChar in Gen.Elements(ContainerNameTerminalChars)
            from midChars in Gen.ArrayOf(len, Gen.Elements(ContainerNameChars))
            from endChar in Gen.Elements(ContainerNameTerminalChars)
            let str = ConcatChars(startChar, midChars, endChar)
            where !str.Contains("--")
            select new BatchIdThatIsValidContainerName(str);

        private static IEnumerable<BatchIdThatIsValidContainerName> BatchIdThatIsValidContainerNameShrink(BatchIdThatIsValidContainerName batchId)
        {
            var id = batchId.ToString();
            return (id == null || id.Length <= 3) ?
                Enumerable.Empty<BatchIdThatIsValidContainerName>() :
                Enumerable.Range(0, id.Length - 1)
                          .Select(index => id.Remove(index, 1))
                          .Where(s => !s.Contains("--"))
                          .Select(s => new BatchIdThatIsValidContainerName(s));
        }
    }

    public struct BatchId
    {
        private readonly string _id;

        public BatchId(string id)
        {
            _id = id;
        }

        public override string ToString()
        {
            return _id;
        }
    }

    public struct BatchIdThatIsValidContainerName
    {
        private readonly string _id;

        public BatchIdThatIsValidContainerName(string id)
        {
            _id = id;
        }

        public override string ToString()
        {
            return _id;
        }
    }
}
