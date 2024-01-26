// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Azure.Core.Serialization;

namespace Azure.ResourceManager.AppService
{
    internal static class StringBuilderExtensions
    {
        internal static void AppendChildObject(this StringBuilder sb, IModelSerializable<object> childObject, ModelSerializerOptions options, bool indentFirstLine = false, int spaces = 2)
        {
            string indent = new string(' ', spaces);
            BinaryData properties = ModelSerializer.Serialize(childObject, options);
            string[] lines = properties.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < lines.Length; i++)
            {
                string indentToUse = !indentFirstLine && i == 0 ? string.Empty : indent;
                sb.AppendLine($"{indentToUse}{lines[i]}");
            }
        }
    }
}
