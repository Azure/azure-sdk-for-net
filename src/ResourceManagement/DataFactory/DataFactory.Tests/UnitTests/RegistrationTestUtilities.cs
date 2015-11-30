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
using System.Reflection;
using Microsoft.Azure.Management.DataFactories.Models;
using Xunit;

namespace DataFactory.Tests.UnitTests
{
    internal static class RegistrationTestUtilities
    {
        public static void TestCanGetRegisteredLinkedServiceCaseInsensitive(Type type, out string typeName)
        {
            AdfTypeNameAttribute att = type.GetCustomAttribute<AdfTypeNameAttribute>(true);
            if (att == null)
            {
                typeName = type.Name;
                return;
            }

            Assert.NotNull(att);

            // Get the type named used for de/ser
            typeName = att.TypeName;
            Assert.NotNull(typeName);
            Assert.NotEmpty(typeName);

            // Ensure that the type name is not already all lowercase
            string typeNameLower = typeName.ToLowerInvariant();
            Assert.NotEqual(typeName, typeNameLower, StringComparer.Ordinal);
        }

        public static void TestCanGetRegisteredLinkedServiceCaseInsensitive<T>(out string typeName)
            where T : TypeProperties
        {
            TestCanGetRegisteredLinkedServiceCaseInsensitive(typeof(T), out typeName);
        }
    }
}
