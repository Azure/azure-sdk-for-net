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
using System.Globalization;
using DataFactory.Tests.Framework;
using DataFactory.Tests.UnitTests.TestClasses;
using Microsoft.Azure.Management.DataFactories.Models;
using Xunit;

namespace DataFactory.Tests.UnitTests
{
    public class LinkedServiceTypeRegistrationTests : UnitTestBase
    {
        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void CanRegisterLinkedServiceType()
        {
            this.Client.RegisterType<MyLinkedServiceType>(true);

            Assert.True(
                this.Client.TypeIsRegistered<MyLinkedServiceType>(),
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Type '{0}' was not successfully registered.",
                    typeof(MyLinkedServiceType).Name));
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void RegisteringLinkedServiceTypeWithReservedNameThrowsException()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => this.Client.RegisterType<AzureSqlDatabaseLinkedService>());
            Assert.True(ex.Message.Contains("cannot be locally registered because it has the same name"));
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void RegisteringLinkedServiceTypeTwiceWithoutForceThrowsException()
        {
            this.Client.RegisterType<MyLinkedServiceType>(true);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => this.Client.RegisterType<MyLinkedServiceType>());
            Assert.True(ex.Message.Contains("is already registered"));
        }
    }
}
