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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Xunit;
    using Protocol=Microsoft.Azure.Batch.Protocol;

    public class OptionsUnitTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestOptionsDontMissODataParameters()
        {
            Type selectedModelType = typeof (Protocol.Models.CertificateAddOptions);

            IEnumerable<Type> optionsTypes = selectedModelType.Assembly.GetTypes().Where(t =>
                t.Namespace == selectedModelType.Namespace &&
                t.Name.EndsWith("Options") && 
                !t.Name.Equals("ExitOptions"));

            Assert.NotEmpty(optionsTypes);

            int filterCount = 0;
            int selectCount = 0;
            int expandCount = 0;
            int timeoutCount = 0;

            foreach (Type optionsType in optionsTypes)
            {
                Assert.True(typeof(Protocol.Models.IOptions).IsAssignableFrom(optionsType), string.Format("type {0} missing IOptions", optionsType));

                if (optionsType.GetProperty("Filter") != null)
                {
                    ++filterCount;
                    Assert.True(typeof(Protocol.Models.IODataFilter).IsAssignableFrom(optionsType), string.Format("type {0} missing filter", optionsType));
                }
                if (optionsType.GetProperty("Select") != null)
                {
                    ++selectCount;
                    Assert.True(typeof(Protocol.Models.IODataSelect).IsAssignableFrom(optionsType), string.Format("type {0} missing select", optionsType));
                }
                if (optionsType.GetProperty("Expand") != null)
                {
                    ++expandCount;
                    Assert.True(typeof(Protocol.Models.IODataExpand).IsAssignableFrom(optionsType), string.Format("type {0} missing expand", optionsType));
                }
                if (optionsType.GetProperty("Timeout") != null)
                {
                    ++timeoutCount;
                    Assert.True(typeof(Protocol.Models.ITimeoutOptions).IsAssignableFrom(optionsType), string.Format("type {0} missing timeout", optionsType));
                }
            }

            Assert.NotEqual(0, filterCount);
            Assert.NotEqual(0, selectCount);
            Assert.NotEqual(0, expandCount);
            Assert.NotEqual(0, timeoutCount);
        }
    }
}
