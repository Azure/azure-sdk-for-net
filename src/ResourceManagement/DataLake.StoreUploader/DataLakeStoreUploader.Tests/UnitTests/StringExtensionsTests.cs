// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensionsTests.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Unit tests for the StringExtensions class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Azure.Management.DataLake.StoreUploader.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using Microsoft.Azure.Management.DataLake.StoreUploader;
    using Xunit;
    
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*")]
    public class StringExtensionsTests
    {

        private static readonly List<Tuple<string, int, int>> TestDataUTF8 = new List<Tuple<string, int, int>>
        {
            Tuple.Create("", -1, -1),
            Tuple.Create("a", -1, -1),
            Tuple.Create("a b", -1, -1),
            Tuple.Create("\r", 0, 0),
            Tuple.Create("\n", 0, 0),
            Tuple.Create("\r\n", 1, 1),
            Tuple.Create("\n\r", 1, 1),
            Tuple.Create("\r\nabcde", 1, 1),
            Tuple.Create("abcde\r", 5, 5),
            Tuple.Create("abcde\n", 5, 5),
            Tuple.Create("abcde\r\n", 6, 6),
            Tuple.Create("abcde\rabcde", 5, 5),
            Tuple.Create("abcde\nabcde", 5, 5),
            Tuple.Create("abcde\r\nabcde", 6, 6),
            Tuple.Create("a\rb\na\r\n", 1, 6),
            Tuple.Create("\rb\na\r\n", 0, 5),
        };

        private static readonly List<Tuple<string, int, int>> TestDataUTF16 = new List<Tuple<string, int, int>>
        {
            Tuple.Create("", -1, -1),
            Tuple.Create("a", -1, -1),
            Tuple.Create("a b", -1, -1),
            Tuple.Create("\r", 1, 1),
            Tuple.Create("\n", 1, 1),
            Tuple.Create("\r\n", 3, 3),
            Tuple.Create("\n\r", 3, 3),
            Tuple.Create("\r\nabcde", 3, 3),
            Tuple.Create("abcde\r", 11, 11),
            Tuple.Create("abcde\n", 11, 11),
            Tuple.Create("abcde\r\n", 13, 13),
            Tuple.Create("abcde\rabcde", 11, 11),
            Tuple.Create("abcde\nabcde", 11, 11),
            Tuple.Create("abcde\r\nabcde", 13, 13),
            Tuple.Create("a\rb\na\r\n", 3, 13),
            Tuple.Create("\rb\na\r\n", 1, 11),
        };

        private static readonly List<Tuple<string, int, int>> TestDataUTF32 = new List<Tuple<string, int, int>>
        {
            Tuple.Create("", -1, -1),
            Tuple.Create("a", -1, -1),
            Tuple.Create("a b", -1, -1),
            Tuple.Create("\r", 3, 3),
            Tuple.Create("\n", 3, 3),
            Tuple.Create("\r\n", 7, 7),
            Tuple.Create("\n\r", 7, 7),
            Tuple.Create("\r\nabcde", 7, 7),
            Tuple.Create("abcde\r", 23, 23),
            Tuple.Create("abcde\n", 23, 23),
            Tuple.Create("abcde\r\n", 27, 27),
            Tuple.Create("abcde\rabcde", 23, 23),
            Tuple.Create("abcde\nabcde", 23, 23),
            Tuple.Create("abcde\r\nabcde", 27, 27),
            Tuple.Create("a\rb\na\r\n", 7, 27),
            Tuple.Create("\rb\na\r\n", 3, 23),
        };

        [Fact]
        public void StringExtensions_FindNewLine_UTF8()
        {
            foreach (var t in TestDataUTF8)
            {
                var exactBuffer = Encoding.UTF8.GetBytes(t.Item1);
                var largerBuffer = new byte[exactBuffer.Length + 100];
                Array.Copy(exactBuffer, largerBuffer, exactBuffer.Length);

                int forwardInExactBuffer =  StringExtensions.FindNewline(exactBuffer, 0, exactBuffer.Length, false, Encoding.UTF8);
                Assert.Equal(t.Item2, forwardInExactBuffer);

                int forwardInLargeBuffer = StringExtensions.FindNewline(largerBuffer, 0, exactBuffer.Length, false, Encoding.UTF8);
                Assert.Equal(t.Item2, forwardInLargeBuffer);

                int reverseInExactBuffer = StringExtensions.FindNewline(exactBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true, Encoding.UTF8);
                Assert.Equal(t.Item3, reverseInExactBuffer);

                int reverseInLargeBuffer = StringExtensions.FindNewline(largerBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true, Encoding.UTF8);
                Assert.Equal(t.Item3, reverseInLargeBuffer);
            }
        }

        [Fact]
        public void StringExtensions_FindNewLine_UTF16()
        {
            foreach (var t in TestDataUTF16)
            {
                var exactBuffer = Encoding.Unicode.GetBytes(t.Item1);
                var largerBuffer = new byte[exactBuffer.Length + 100];
                Array.Copy(exactBuffer, largerBuffer, exactBuffer.Length);

                int forwardInExactBuffer = StringExtensions.FindNewline(exactBuffer, 0, exactBuffer.Length, false, Encoding.Unicode);
                Assert.Equal(t.Item2, forwardInExactBuffer);

                int forwardInLargeBuffer = StringExtensions.FindNewline(largerBuffer, 0, exactBuffer.Length, false, Encoding.Unicode);
                Assert.Equal(t.Item2, forwardInLargeBuffer);

                int reverseInExactBuffer = StringExtensions.FindNewline(exactBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true, Encoding.Unicode);
                Assert.Equal(t.Item3, reverseInExactBuffer);

                int reverseInLargeBuffer = StringExtensions.FindNewline(largerBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true, Encoding.Unicode);
                Assert.Equal(t.Item3, reverseInLargeBuffer);
            }
        }

        [Fact]
        public void StringExtensions_FindNewLine_UTF16BigEndian()
        {
            foreach (var t in TestDataUTF16)
            {
                var exactBuffer = Encoding.BigEndianUnicode.GetBytes(t.Item1);
                var largerBuffer = new byte[exactBuffer.Length + 100];
                Array.Copy(exactBuffer, largerBuffer, exactBuffer.Length);

                int forwardInExactBuffer = StringExtensions.FindNewline(exactBuffer, 0, exactBuffer.Length, false, Encoding.BigEndianUnicode);
                Assert.Equal(t.Item2, forwardInExactBuffer);

                int forwardInLargeBuffer = StringExtensions.FindNewline(largerBuffer, 0, exactBuffer.Length, false, Encoding.BigEndianUnicode);
                Assert.Equal(t.Item2, forwardInLargeBuffer);

                int reverseInExactBuffer = StringExtensions.FindNewline(exactBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true, Encoding.BigEndianUnicode);
                Assert.Equal(t.Item3, reverseInExactBuffer);

                int reverseInLargeBuffer = StringExtensions.FindNewline(largerBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true, Encoding.BigEndianUnicode);
                Assert.Equal(t.Item3, reverseInLargeBuffer);
            }
        }

        [Fact]
        public void StringExtensions_FindNewLine_UTF32()
        {
            foreach (var t in TestDataUTF32)
            {
                var exactBuffer = Encoding.UTF32.GetBytes(t.Item1);
                var largerBuffer = new byte[exactBuffer.Length + 100];
                Array.Copy(exactBuffer, largerBuffer, exactBuffer.Length);

                int forwardInExactBuffer = StringExtensions.FindNewline(exactBuffer, 0, exactBuffer.Length, false, Encoding.UTF32);
                Assert.Equal(t.Item2, forwardInExactBuffer);

                int forwardInLargeBuffer = StringExtensions.FindNewline(largerBuffer, 0, exactBuffer.Length, false, Encoding.UTF32);
                Assert.Equal(t.Item2, forwardInLargeBuffer);

                int reverseInExactBuffer = StringExtensions.FindNewline(exactBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true, Encoding.UTF32);
                Assert.Equal(t.Item3, reverseInExactBuffer);

                int reverseInLargeBuffer = StringExtensions.FindNewline(largerBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true, Encoding.UTF32);
                Assert.Equal(t.Item3, reverseInLargeBuffer);
            }
        }

        [Fact]
        public void StringExtensions_FindNewLine_ASCII()
        {
            foreach (var t in TestDataUTF8)
            {
                var exactBuffer = Encoding.ASCII.GetBytes(t.Item1);
                var largerBuffer = new byte[exactBuffer.Length + 100];
                Array.Copy(exactBuffer, largerBuffer, exactBuffer.Length);

                int forwardInExactBuffer = StringExtensions.FindNewline(exactBuffer, 0, exactBuffer.Length, false, Encoding.ASCII);
                Assert.Equal(t.Item2, forwardInExactBuffer);

                int forwardInLargeBuffer = StringExtensions.FindNewline(largerBuffer, 0, exactBuffer.Length, false, Encoding.ASCII);
                Assert.Equal(t.Item2, forwardInLargeBuffer);

                int reverseInExactBuffer = StringExtensions.FindNewline(exactBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true, Encoding.ASCII);
                Assert.Equal(t.Item3, reverseInExactBuffer);

                int reverseInLargeBuffer = StringExtensions.FindNewline(largerBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true, Encoding.ASCII);
                Assert.Equal(t.Item3, reverseInLargeBuffer);
            }
        }

        [Fact]
        public void StringExtensions_FindNewLine_UTF7()
        {
            foreach (var t in TestDataUTF8)
            {
                var exactBuffer = Encoding.UTF7.GetBytes(t.Item1);
                var largerBuffer = new byte[exactBuffer.Length + 100];
                Array.Copy(exactBuffer, largerBuffer, exactBuffer.Length);

                int forwardInExactBuffer = StringExtensions.FindNewline(exactBuffer, 0, exactBuffer.Length, false, Encoding.UTF7);
                Assert.Equal(t.Item2, forwardInExactBuffer);

                int forwardInLargeBuffer = StringExtensions.FindNewline(largerBuffer, 0, exactBuffer.Length, false, Encoding.UTF7);
                Assert.Equal(t.Item2, forwardInLargeBuffer);

                int reverseInExactBuffer = StringExtensions.FindNewline(exactBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true, Encoding.UTF7);
                Assert.Equal(t.Item3, reverseInExactBuffer);

                int reverseInLargeBuffer = StringExtensions.FindNewline(largerBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true, Encoding.UTF7);
                Assert.Equal(t.Item3, reverseInLargeBuffer);
            }
        }
    }
}
