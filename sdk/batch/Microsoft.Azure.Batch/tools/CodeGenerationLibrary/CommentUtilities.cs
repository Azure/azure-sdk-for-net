// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace CodeGenerationLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommentUtilities
    {
        private const string CommentPrefix = "/// ";

        public static class Indentation
        {
            public const int TabSizeInSpaces = 4;
            public const int TypeLevel = TabSizeInSpaces * 1;
            public const int TypeMemberLevel = TabSizeInSpaces * 2;
        }

        /// <summary>
        /// Generates /// comments for the given <paramref name="commentString"/>.
        /// </summary>
        /// <param name="commentString">The comment string.</param>
        /// <param name="indentationSpaces">The number of spaces to indent.</param>
        /// <param name="indentAndCommentFirstLine">True if the first line should be indented, false otherwise.</param>
        /// <returns>A formatted comment string beginning with /// that is correctly indented.</returns>
        public static string FormatTripleSlashComment(string commentString, int indentationSpaces, bool indentAndCommentFirstLine = true)
        {
            //TODO: Consider line breaks on <para>
            const int maxLineLength = 120;
            int allowedCommentLineLength = maxLineLength - (indentationSpaces + CommentPrefix.Length);

            IEnumerable<string> lines = SplitIntoLines(commentString, allowedCommentLineLength).Select((line, index) =>
                AddLinePrefix(line, index, indentationSpaces, indentAndCommentFirstLine));

            return JoinCommentLines(lines);
        }

        private static string JoinCommentLines(IEnumerable<string> commentLines)
        {
            return string.Join(Environment.NewLine, commentLines);
        }

        private static string AddLinePrefix(string line, int index, int indentationSpaces, bool indentAndCommentFirstLine)
        {
            string prefix = new string(' ', indentationSpaces) + CommentPrefix;

            return index == 0 && !indentAndCommentFirstLine ? line : prefix + line;
        }

        private static IEnumerable<string> SplitIntoLines(string commentString, int maxLineLength)
        {
            IEnumerable<string> tokens = Tokenize(commentString);

            StringBuilder lineBuilder = new StringBuilder();
            foreach (string token in tokens)
            {
                if (lineBuilder.Length > maxLineLength)
                {
                    yield return lineBuilder.ToString();
                    lineBuilder.Clear();
                }

                lineBuilder.Append(token);
            }

            if (lineBuilder.Length > 0)
            {
                yield return lineBuilder.ToString();
            }
        }

        //TODO: This is a bit hacky but it works so...
        private static IEnumerable<string> Tokenize(string str)
        {
            bool inXml = false;
            bool processingToken = false;
            int tokenStart = 0;

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                inXml = !processingToken && c == '<';
                if (!processingToken)
                {
                    tokenStart = i;
                    processingToken = true;
                }

                if (inXml && c == '>' || string.IsNullOrWhiteSpace(c.ToString()))
                {
                    processingToken = false;
                    inXml = false;
                    yield return str.Substring(tokenStart, i - tokenStart + 1);
                }
            }
            if (processingToken)
            {
                yield return str.Substring(tokenStart, str.Length - tokenStart);
            }
        }
    }
}
