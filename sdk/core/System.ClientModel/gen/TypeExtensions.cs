// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace System.ClientModel.SourceGeneration
{
    internal static class TypeExtensions
    {
        public static void WriteFullyQualifiedName(this Type type, StringBuilder builder)
        {
            builder.Append("global::");
            builder.Append(type.Namespace);
            builder.Append('.');
            int length = type.Name.Length;
            if (type.IsGenericType)
            {
                length -= 2;
            }
            builder.Append(type.Name, 0, length);
        }
    }
}
