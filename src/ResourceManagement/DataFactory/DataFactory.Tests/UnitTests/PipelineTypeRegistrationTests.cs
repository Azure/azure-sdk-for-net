// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Collections.Generic;
using DataFactory.Tests.Framework;
using DataFactory.Tests.UnitTests.TestClasses;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Xunit;
using Xunit.Extensions;

namespace DataFactory.Tests.UnitTests
{
    public class PipelineTypeRegistrationTests : TypeRegistrationTestBase<ActivityTypeProperties, GenericActivity>
    {
        private PipelineOperations Operations
        {
            get
            {
                return (PipelineOperations)this.Client.Pipelines;
            }
        }

        public static IEnumerable<object[]> ReservedTypes
        {
            get
            {
                return ReservedTypesList.Value;
            }
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void CanRegisterActivityTypeForPipeline()
        {
            this.TestCanRegisterType<MyActivityType>();
        }

        [Theory]
        [PropertyData("ReservedTypes")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void CanRegisterActivityTypeForPipelineWithReservedName<T>(Type type, T registeredType)
            where T : ActivityTypeProperties
        {
            this.TestCanRegisterTypeWithReservedName<T>();
        }

        [Theory]
        [PropertyData("ReservedTypes")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void ReservedActivityTypeIsRegisteredTest<T>(Type type, T registeredType)
            where T : ActivityTypeProperties
        {
            this.TestReservedTypeIsRegistered<T>();
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void RegisteringActivityTypeForPipelineTwiceThrowsException()
        {
            this.RegisteringTypeTwiceWithoutForceThrowsException<MyActivityType>();
        }

        [Theory]
        [PropertyData("ReservedTypes")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void CanGetRegisteredActivityCaseInsensitive<T>(Type type, T registeredType)
        {
            this.TestCanGetRegisteredTypeCaseInsensitive(this.Operations.Converter, type);
        }
    }
}
