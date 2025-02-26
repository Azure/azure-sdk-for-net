// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System.Diagnostics.CodeAnalysis;

namespace Azure.Generator.Utilities
{
    internal static class MethodExtensions
    {
        /// <summary>
        /// Return true if this operation is a list method. Also returns the itemType of what this operation is listing of.
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
