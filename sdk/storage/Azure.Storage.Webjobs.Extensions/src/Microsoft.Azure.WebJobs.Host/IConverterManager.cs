// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs
{
    /// <summary>
    /// General service for converting between types for parameter bindings.  
    /// Parameter bindings call this to convert from user parameter types to underlying binding types. 
    /// Converters can be added via extension configuration rules on <see cref="FluentConverterRules"/>.
    /// </summary>
    public interface IConverterManager
    {
        /// <summary>
        /// Get a conversion function to converter from the source to the destination type. 
        /// This will either return a converter directly supplied by AddConverter or a composition of converters:
        /// 1. Exact Match: If there is a TSource-->TDestination converter, return that. 
        /// 2. Catch-all: If there is an object-->TDestination converter, return that. 
        /// 3. Inheritance : if TSource is assignable to TDestination (such as inheritance or if the types are the same), do the automatic conversion. 
        /// 4. byte[]:  if there is a Byte[] --> string, and String--> TDestination, compose them to do Byte[]-->String
        /// 5. Poco with Json: if TSource is a poco, serialize it to a string and use string-->TDestination. 
        /// </summary>
        /// <typeparam name="TAttribute">Attribute on the binding. </typeparam>
        /// <returns>a converter function; or null if no converter is available.</returns>
        FuncAsyncConverter GetConverter<TAttribute>(Type typeSource, Type typeDest)
            where TAttribute : Attribute;
    }

    /// <summary>
    /// Convenience methods for <see cref="IConverterManager"/>
    /// </summary>
    public static class IConverterManagerExtensions
    {
        // Provide a strong typed wrapper. 
        public static FuncAsyncConverter<TSource, TDestination> GetConverter<TSource, TDestination, TAttribute>(this IConverterManager converterManager)
            where TAttribute : Attribute
        {
            var func = converterManager.GetConverter<TAttribute>(typeof(TSource), typeof(TDestination));
            return func.AsTyped<TSource, TDestination>();
        }

        internal static FuncAsyncConverter<TSource, TDestination> AsTyped<TSource, TDestination>(this FuncAsyncConverter func)
        {
            if (func == null)
            {
                return null;
            }

            return async (src, attr, ctx) =>
            {
                var result = await func((TSource)src, attr, ctx);
                return (TDestination)result;
            };
        }

        // Check if a conversion exists. 
        internal static bool HasConverter<TAttribute>(this IConverterManager converterManager, Type typeSource, Type typeDest)
            where TAttribute : Attribute
        {
            try
            {
                var converter = converterManager.GetConverter<TAttribute>(typeSource, typeDest);
                return converter != null;
            }
            catch (InvalidOperationException)
            {
                // OpenType match could have thrown. 
                return false;
            }            
        }
    }
}