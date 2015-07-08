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
using System.Reflection;
using DataFactory.Tests.Framework;
using DataFactory.Tests.UnitTests.TestClasses;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Conversion;
using Microsoft.Azure.Management.DataFactories.Models;
using Xunit;

namespace DataFactory.Tests.UnitTests
{
    public class LinkedServiceTypeRegistrationTests : UnitTestBase
    {
        private LinkedServiceOperations Operations
        {
            get
            {
                return (LinkedServiceOperations)this.Client.LinkedServices;
            }
        }

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

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void RegisteringLinkedServiceTwiceThrowsExceptionCaseInsensitive()
        {
            AdfTypeNameAttribute attribute =
                typeof(MyLinkedServiceType).GetCustomAttribute<AdfTypeNameAttribute>(true);
            Assert.NotNull(attribute);

            AdfTypeNameAttribute attribute2 =
                typeof(MyLinkedServiceType2).GetCustomAttribute<AdfTypeNameAttribute>(true);
            Assert.NotNull(attribute);

            // Ensure the type names are the same when comparing case-insensitively 
            Assert.Equal(attribute.TypeName, attribute2.TypeName, StringComparer.OrdinalIgnoreCase);
            Assert.NotEqual(attribute.TypeName, attribute2.TypeName, StringComparer.Ordinal);

            this.Client.RegisterType<MyLinkedServiceType>(true);

            // Validate that trying to register a type with
            // the same name but different casing is not allowed
            Assert.Throws<InvalidOperationException>(() => this.Client.RegisterType<MyLinkedServiceType2>());
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void CanGetRegisteredLinkedServiceCaseInsensitive()
        {
            string typeName;
            RegistrationTestUtilities.TestCanGetRegisteredLinkedServiceCaseInsensitive<AzureSqlDatabaseLinkedService>(out typeName);

            Type type;
            Assert.True(this.Operations.Converter.TryGetRegisteredType(typeName, out type));
            Assert.Equal(typeof(AzureSqlDatabaseLinkedService), type);
        }

        [Fact]
        [Trait(TraitName.TestType, TestType.Unit)]
        [Trait(TraitName.Function, TestType.Registration)]
        public void CanGetUserRegisteredLinkedServiceCaseInsensitive()
        {
            this.Client.RegisterType<MyLinkedServiceType>(true);

            string typeName;
            RegistrationTestUtilities.TestCanGetRegisteredLinkedServiceCaseInsensitive<AzureSqlDatabaseLinkedService>(out typeName);

            Type type;
            Assert.True(this.Operations.Converter.TryGetRegisteredType(typeName, out type));
            Assert.Equal(typeof(AzureSqlDatabaseLinkedService), type);
        }

        private void TestCanGetRegisteredLinkedServiceCaseInsensitive<T>() where T : TypeProperties
        {
            string typeName;
            RegistrationTestUtilities.TestCanGetRegisteredLinkedServiceCaseInsensitive<T>(out typeName);

            Type type;
            Assert.True(this.Operations.Converter.TryGetRegisteredType(typeName, out type));
            Assert.Equal(typeof(T), type);
        }
    }
}
