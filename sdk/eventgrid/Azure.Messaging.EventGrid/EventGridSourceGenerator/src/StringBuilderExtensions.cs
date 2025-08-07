// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace Azure.EventGrid.Messaging.SourceGeneration
{
    internal static class StringBuilderExtensions
    {
        public static void AppendIndentedLine(this StringBuilder sb, int indentLevel, string text)
        {
            sb.Append(' ', indentLevel * 4);
            sb.AppendLine(text);
        }
    }
}
