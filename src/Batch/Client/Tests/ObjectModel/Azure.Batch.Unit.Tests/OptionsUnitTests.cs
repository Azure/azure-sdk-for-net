// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
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

            IEnumerable<Type> optionsTypes = selectedModelType.GetTypeInfo().Assembly.GetTypes().Where(t =>
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
