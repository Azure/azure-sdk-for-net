//-----------------------------------------------------------------------
// <copyright file="TableServiceUtilities.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the TableServiceUtilities class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.Data.Services.Common;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Helper functions for table service.
    /// </summary>
    internal static class TableServiceUtilities
    {
        /// <summary>
        /// Determines whether the type is an entity type.
        /// </summary>
        /// <param name="t">The type to check.</param>
        /// <param name="contextType">Type of the context.</param>
        /// <returns>
        /// Returns <c>true</c> if the type is an entity type; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEntityType(Type t, Type contextType)
        {
            // ADO.NET data services convention: a type 't' is an entity if
            // 1) 't' has at least one key column
            // 2) there is a top level IQueryable<T> property in the context where T is 't' or a supertype of 't'
            // Non-primitive types that are not entity types become nested structures ("complex types" in EDM)
            if (!t.GetProperties().Any(p => IsKeyColumn(p)))
            {
                return false;
            }

            foreach (PropertyInfo pi in contextType.GetProperties())
            {
                if (typeof(IQueryable).IsAssignableFrom(pi.PropertyType))
                {
                    if (pi.PropertyType.GetGenericArguments()[0].IsAssignableFrom(t))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified property is a key column.
        /// </summary>
        /// <param name="pi">The property.</param>
        /// <returns>
        /// Returns <c>true</c> if the specified property is a key column; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsKeyColumn(PropertyInfo pi)
        {
            // Astoria convention:
            // 1) try the DataServiceKey attribute
            // 2) if not attribute, try <typename>ID
            // 3) finally, try just ID
            object[] attribs = pi.DeclaringType.GetCustomAttributes(typeof(DataServiceKeyAttribute), true);
            if (attribs != null && attribs.Length > 0)
            {
                Debug.Assert(attribs.Length == 1, "There must only be one attribute.");

                return ((DataServiceKeyAttribute)attribs[0]).KeyNames.Contains(pi.Name);
            }

            if (pi.Name.Equals(pi.DeclaringType.Name + "ID", System.StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            if (pi.Name == "ID")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Enumerates the entity set properties.
        /// </summary>
        /// <param name="contextType">Type of the context.</param>
        /// <returns>A list of the entity set properties.</returns>
        public static IEnumerable<PropertyInfo> EnumerateEntitySetProperties(Type contextType)
        {
            foreach (PropertyInfo prop in contextType.GetProperties())
            {
                if (typeof(IQueryable).IsAssignableFrom(prop.PropertyType) &&
                    prop.PropertyType.GetGenericArguments().Length > 0 &&
                    IsEntityType(prop.PropertyType.GetGenericArguments()[0], contextType))
                {
                    yield return prop;
                }
            }
        }

        /// <summary>
        /// Enumerates the entity set names.
        /// </summary>
        /// <param name="contextType">Type of the context.</param>
        /// <returns>A list of entity set names.</returns>
        public static IEnumerable<string> EnumerateEntitySetNames(Type contextType)
        {
            return EnumerateEntitySetProperties(contextType).Select(p => p.Name);
        }

        /// <summary>
        /// Checks the name of the table.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="argName">Name of the arg.</param>
        public static void CheckTableName(string tableName, string argName)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentException(String.Format(SR.TableNameInvalid, tableName), argName);
            }
        }        
    }
}
