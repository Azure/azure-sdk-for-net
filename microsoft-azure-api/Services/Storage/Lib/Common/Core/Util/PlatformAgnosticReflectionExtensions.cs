//-----------------------------------------------------------------------
// <copyright file="PlatformAgnosticReflectionExtensions.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;
        
    /// <summary>
    /// Represents a canonicalized string used in authenticating a request against the azure service.
    /// </summary>
    internal static class PlatformAgnosticReflectionExtensions
    {
        public static IEnumerable<MethodInfo> FindStaticMethods(this Type type, string name)
        {
#if WINDOWS_RT
            return type.GetRuntimeMethods();
#else
            // Note currently this looks for nonpublic statics and instance methods, may need to be updated in future to accomodate publics
            return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).Where((m) => m.Name == name);
#endif
        }

        public static IEnumerable<MethodInfo> FindMethods(this Type type)
        {
#if WINDOWS_RT
            return type.GetRuntimeMethods();
#else
            return type.GetMethods();
#endif
        }

        public static MethodInfo FindMethod(this Type type, string name, Type[] parameters)
        {
#if WINDOWS_RT
            return type.GetRuntimeMethod(name, parameters);
#else
            return type.GetMethod(name, parameters);
#endif
        }

        public static PropertyInfo FindProperty(this Type type, string name)
        {
#if WINDOWS_RT
            return type.GetRuntimeProperty(name);
#else
            // Currently this looks for instance public / non publics, may need to be updated to support wider selection
            return type.GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
#endif
        }

        public static MethodInfo FindGetProp(this PropertyInfo property)
        {
#if WINDOWS_RT
            return property.GetMethod;
#else
            return property.GetGetMethod();
#endif
        }

        public static MethodInfo FindSetProp(this PropertyInfo property)
        {
#if WINDOWS_RT
            return property.SetMethod;
#else
            return property.GetSetMethod();
#endif
        }
    }
}
