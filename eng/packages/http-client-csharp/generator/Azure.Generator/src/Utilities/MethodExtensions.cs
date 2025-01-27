// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Generator.Utilities
{
    internal static class MethodExtensions
    {
        /// <summary>
        /// Return true if this operation is a list method. Also returns the itemType of what this operation is listing of.
        /// This function will return true in the following circumstances:
        /// 1. This operation is a paging method.
        /// 2. This operation is not a paging method, but the return value is a collection type (IReadOnlyList)
        /// </summary>
        /// <param name="method"></param>
        /// <param name="itemType">The type of the item in the collection</param>
        /// <returns></returns>
        public static bool IsListMethod(this MethodProvider method, [MaybeNullWhen(false)] out CSharpType itemType)
        {
            itemType = null;
            var returnType = method.Signature.ReturnType;
            if (returnType == null)
                return false;
            if (returnType.IsFrameworkType && returnType.IsList)
            {
                itemType = returnType.Arguments[0];
                return true;
            }
            return itemType != null;
        }
    }
}
