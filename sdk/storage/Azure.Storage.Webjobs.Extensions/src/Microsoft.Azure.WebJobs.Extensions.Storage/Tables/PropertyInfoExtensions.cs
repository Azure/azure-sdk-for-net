// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace Microsoft.Azure.WebJobs.Host.Tables
{
    internal static class PropertyInfoExtensions
    {
        public static bool HasPublicGetMethod(this PropertyInfo property)
        {
            if (property == null)
            {
                throw new ArgumentNullException("property");
            }

            return property.GetGetMethod() != null;
        }

        public static bool HasPublicSetMethod(this PropertyInfo property)
        {
            if (property == null)
            {
                throw new ArgumentNullException("property");
            }

            return property.GetSetMethod() != null;
        }
    }
}
