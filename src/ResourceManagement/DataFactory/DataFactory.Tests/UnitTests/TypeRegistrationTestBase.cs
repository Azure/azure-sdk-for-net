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
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.Management.DataFactories.Conversion;
using Microsoft.Azure.Management.DataFactories.Models;
using Xunit;

namespace DataFactory.Tests.UnitTests
{
    public abstract class TypeRegistrationTestBase<TRegistered, TGenericTypeProperties> : UnitTestBase
        where TRegistered : TypeProperties
        where TGenericTypeProperties : TRegistered, IGenericTypeProperties, new()
    {
        protected void TestCanRegisterTypeWithReservedName<T>() where T : TypeProperties
        {
            // This is a bit of a hack to make the tests work if any reserved types are abstract
            if (typeof(T) == typeof(TGenericTypeProperties))
            {
                return;
            }

            // Ensure the reserved type was registered already
            Assert.True(this.Client.TypeIsRegistered<T>());

            this.Client.RegisterType<T>(force: true);
            Assert.True(this.Client.TypeIsRegistered<T>());
        }

        protected void RegisteringTypeTwiceWithoutForceThrowsException<T>() where T : TypeProperties
        {
            this.Client.RegisterType<T>(true);

            InvalidOperationException ex =
                Assert.Throws<InvalidOperationException>(() => this.Client.RegisterType<T>());
            Assert.True(ex.Message.Contains("is already registered"));
        }

        protected void TestCanRegisterType<T>() where T : TRegistered
        {
            this.Client.RegisterType<T>(true);

            Assert.True(
                this.Client.TypeIsRegistered<T>(),
                string.Format(
                    CultureInfo.InvariantCulture,
                    "Type '{0}' was not successfully registered.",
                    typeof(T).Name));
        }

        protected void TestReservedTypeIsRegistered<T>() where T : TRegistered
        {
            Assert.True(
                this.Client.TypeIsRegistered<T>(),
                string.Format(CultureInfo.InvariantCulture, "Reserved type '{0}' is not registered.", typeof(T).Name));
        }

        protected void TestRegisteringTypeTwiceThrowsExceptionCaseInsensitive
            <TUserRegistered, TUserRegisteredDifferentCase>()
            where TUserRegistered : TRegistered
            where TUserRegisteredDifferentCase : TRegistered
        {
            AdfTypeNameAttribute attribute = typeof(TUserRegistered).GetCustomAttribute<AdfTypeNameAttribute>(true);
            Assert.NotNull(attribute);

            AdfTypeNameAttribute attribute2 =
                typeof(TUserRegisteredDifferentCase).GetCustomAttribute<AdfTypeNameAttribute>(true);
            Assert.NotNull(attribute);

            // Ensure the type names are the same when comparing case-insensitively 
            Assert.Equal(attribute.TypeName, attribute2.TypeName, StringComparer.OrdinalIgnoreCase);
            Assert.NotEqual(attribute.TypeName, attribute2.TypeName, StringComparer.Ordinal);

            this.Client.RegisterType<TUserRegistered>(true);

            // Validate that trying to register a type with
            // the same name but different casing is not allowed
            Assert.Throws<InvalidOperationException>(() => this.Client.RegisterType<TUserRegisteredDifferentCase>());
        }

        internal void TestCanGetRegisteredTypeCaseInsensitive
            <TCore, TWrapper>(
            CoreTypeConverter<TCore, TWrapper, TRegistered, TGenericTypeProperties> converter,
            Type objectType)
        {
            if (objectType == typeof(TGenericTypeProperties) || objectType == typeof(CustomActivity))
            {
                return;
            }

            string typeName;
            RegistrationTestUtilities.TestCanGetRegisteredLinkedServiceCaseInsensitive(objectType, out typeName);

            Type type;
            Assert.True(converter.TryGetRegisteredType(typeName, out type));
            Assert.Equal(objectType, type);
        }

        protected static readonly Lazy<IEnumerable<object[]>> ReservedTypesList =
            new Lazy<IEnumerable<object[]>>(GetReservedTypes);

        private static IEnumerable<object[]> GetReservedTypes()
        {
            // If any type are abstract, initialize an instance of TGenericTypeProperties 
            // and ignore in any tests that need a real type.
            Type rootType = typeof(TRegistered);
            return rootType.Assembly.GetTypes()
                    .Where(t => t != rootType && rootType.IsAssignableFrom(t))
                    .Select(type => !type.IsAbstract
                            ? new object[] { type, Activator.CreateInstance(type) }
                            : new object[] { type, new TGenericTypeProperties() }); 
        }
    }
}
