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
    public class LinkedServiceTypeRegistrationTests : TypeRegistrationTestBase<LinkedServiceTypeProperties, GenericLinkedService>
    {
        private LinkedServiceOperations Operations
        {
            get
            {
                return (LinkedServiceOperations)this.Client.LinkedServices;
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
        public void CanRegisterLinkedServiceType()
        {
            this.TestCanRegisterType<MyLinkedServiceType>();
        }

        [Theory]
        [PropertyData("ReservedTypes")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void ReservedLinkedServiceTypeIsRegisteredTest<T>(Type type, T registeredType)
            where T : LinkedServiceTypeProperties
        {
            this.TestReservedTypeIsRegistered<T>();
        }

        [Theory]
        [PropertyData("ReservedTypes")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void CanRegisterLinkedServiceTypeWithReservedName<T>(Type type, T registeredType)
            where T : TypeProperties
        {
            this.TestCanRegisterTypeWithReservedName<T>();
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void RegisteringLinkedServiceTypeTwiceWithoutForceThrowsException()
        {
           this.RegisteringTypeTwiceWithoutForceThrowsException<MyLinkedServiceType>(); 
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void RegisteringLinkedServiceTwiceThrowsExceptionCaseInsensitive()
        {
            this.TestRegisteringTypeTwiceThrowsExceptionCaseInsensitive<MyLinkedServiceType, MyLinkedServiceType2>();
        }

        [Theory, PropertyData("ReservedTypes")]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void CanGetRegisteredLinkedServiceCaseInsensitive<T>(Type type, T registeredType)
        {
            this.TestCanGetRegisteredTypeCaseInsensitive(this.Operations.Converter, type);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void ClientsDoNotShareTypeMap()
        {
            var client = new DataFactoryManagementClient();
            Assert.False(client.TypeIsRegistered<MyLinkedServiceType>());

            client.RegisterType<MyLinkedServiceType>();
            Assert.True(client.TypeIsRegistered<MyLinkedServiceType>());

            // Ensure that the backing type map is not static/shared; 
            // MyLinkedServiceType should not be registered on a second client
            var client2 = new DataFactoryManagementClient();
            Assert.False(client2.TypeIsRegistered<MyLinkedServiceType>());
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void CanGetUserRegisteredLinkedServiceCaseInsensitive()
        {
            this.Client.RegisterType<MyLinkedServiceType>(true);

            string typeName;
            RegistrationTestUtilities.TestCanGetRegisteredLinkedServiceCaseInsensitive<MyLinkedServiceType>(out typeName);

            Type type;
            Assert.True(this.Operations.Converter.TryGetRegisteredType(typeName, out type));
            Assert.Equal(typeof(MyLinkedServiceType), type); 
        }
    }
}
