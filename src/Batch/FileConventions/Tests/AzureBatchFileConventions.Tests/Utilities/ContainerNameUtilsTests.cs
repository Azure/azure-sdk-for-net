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
using FsCheck.Xunit;
using Microsoft.Azure.Batch.Conventions.Files.UnitTests.Generators;
using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Batch.Conventions.Files.UnitTests.Utilities
{
    [Arbitrary(typeof(BatchIdGenerator))]
    public class ContainerNameUtilsTests
    {
        // Verify generated container names against the Azure blob container naming rules
        // from https://msdn.microsoft.com/en-us/library/azure/dd135715.aspx

        [Property]
        public void ContainerNamesMustStartWithALetterOrNumber(BatchId jobId)
        {
            var containerName = ContainerNameUtils.GetSafeContainerName(jobId.ToString());
            Assert.True(Char.IsLetterOrDigit(containerName[0]));
        }

        [Property]
        public void ContainerNamesCanContainOnlyLettersNumbersAndDashes(BatchId jobId)
        {
            var containerName = ContainerNameUtils.GetSafeContainerName(jobId.ToString());
            Assert.All(containerName,
                ch => Assert.True(Char.IsLetterOrDigit(ch) || ch == '-'));
        }

        private static IEnumerable<int> IndexesOf(string str, char ch)
        {
            return Enumerable.Range(0, str.Length)
                             .Where(i => str[i] == ch);
        }

        [Property]
        public void EveryDashInAContainerNameMustBeImmediatelyPrecededAndFollowedByALetterOrNumber(BatchId jobId)
        {
            var containerName = ContainerNameUtils.GetSafeContainerName(jobId.ToString());

            var dashIndexesInContainerName = IndexesOf(containerName, '-');

            Assert.All(dashIndexesInContainerName,
                i => Assert.True(Char.IsLetterOrDigit(containerName[i - 1]) && Char.IsLetterOrDigit(containerName[i + 1])));
        }

        [Property]
        public void ConsecutiveDashesAreNotPermittedInContainerNames(BatchId jobId)
        {
            var containerName = ContainerNameUtils.GetSafeContainerName(jobId.ToString());
            Assert.DoesNotContain("--", containerName);
        }

        [Property]
        public void AllLettersInAContainerNameMustBeLowercase(BatchId jobId)
        {
            var containerName = ContainerNameUtils.GetSafeContainerName(jobId.ToString());
            Assert.All(containerName,
                ch => Assert.True(!Char.IsLetter(ch) || Char.IsLower(ch)));
        }

        [Property]
        public void ContainerNamesMustBeFrom3Through63CharactersLong(BatchId jobId)
        {
            var containerName = ContainerNameUtils.GetSafeContainerName(jobId.ToString());
            Assert.InRange(containerName.Length, 3, 63);
        }

        [Property]
        public void ValidContainerNamesAreNotMunged(BatchIdThatIsValidContainerName jobId)
        {
            var containerName = ContainerNameUtils.GetSafeContainerName(jobId.ToString());
            Assert.Equal("job-" + jobId.ToString(), containerName);
        }

        [Theory]
        [InlineData("job-15", "job-job-15")]
        [InlineData("MyTerrificJob", "job-myterrificjob")]
        [InlineData("J", "job-j")]
        [InlineData("j", "job-j")]
        public void ContainerNameSafeJobIdGeneratesSimpleContainerName(string jobId, string expectedContainerName)
        {
            Assert.Equal(expectedContainerName, ContainerNameUtils.GetSafeContainerName(jobId));
        }

        [Theory]
        [InlineData("my_job-bob", "job-my-job-bob-e04620bc2add214df74e158ba60d24273a0e0927")]
        [InlineData("-my_job-sam--", "job-my-job-sam-47f54d840815af2592a12213db05f8a8277a098d")]
        [InlineData("my-_EVEN_MORE_-terrific-job", "job-my-even-more-te-68b05a7d8aa6aa65b9a6892c667a6c406a16ad65")]
        [InlineData("---", "job-job-58b63e273b964039d6ef432a415df3f177c818e5")]
        [InlineData("-_-", "job-job-6fe16b401f95cfcf3aba78023b0a14ef782813e1")]
        [InlineData("-", "job-job-3bc15c8aae3e4124dd409035f32ea2fd6835efc9")]
        [InlineData("_", "job-job-53a0acfad59379b3e050338bf9f23cfc172ee787")]
        [InlineData("myverylongjobnameallinonewordreallystartingtogetreallysillynow", "job-myverylongjobna-a8700e4947d0c8c621e53b24246aa0349d830e41")]
        public void ContainerNameUnsafeJobIdGeneratesTransformedContainerName(string jobId, string expectedContainerName)
        {
            Assert.Equal(expectedContainerName, ContainerNameUtils.GetSafeContainerName(jobId));
        }
    }
}
