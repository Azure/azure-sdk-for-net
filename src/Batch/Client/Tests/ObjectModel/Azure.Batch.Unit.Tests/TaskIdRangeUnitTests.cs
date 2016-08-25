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

﻿namespace Azure.Batch.Unit.Tests
{
    using Microsoft.Azure.Batch;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Xunit;

    public class TaskIdRangeUnitTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TaskIdRangePropertiesAreValuesPassedToConstructor()
        {
            var range = new TaskIdRange(123, 456);
            Assert.Equal(123, range.Start);
            Assert.Equal(456, range.End);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void StartAndEndCanBeTheSame()
        {
            var range = new TaskIdRange(8, 8);
            Assert.Equal(8, range.Start);
            Assert.Equal(8, range.End);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void NegativeStartIsNotAllowed()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new TaskIdRange(-1, 5));
            Assert.Equal("start", ex.ParamName);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void NegativeEndIsNotAllowed()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new TaskIdRange(0, -1));
            Assert.Equal("end", ex.ParamName);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void EndCannotBeLessThanStart()
        {
            Assert.Throws<ArgumentException>(() => new TaskIdRange(5, 1));
        }
    }
}
