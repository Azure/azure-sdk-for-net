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

        private static readonly List<Tuple<string, int, int>> TestData = new List<Tuple<string, int, int>>
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

        [Fact]
        public void StringExtensions_FindNewLine()
        {
            foreach (var t in TestData)
            {
                var exactBuffer = Encoding.UTF8.GetBytes(t.Item1);
                var largerBuffer = new byte[exactBuffer.Length + 100];
                Array.Copy(exactBuffer, largerBuffer, exactBuffer.Length);

                int forwardInExactBuffer =  StringExtensions.FindNewline(exactBuffer, 0, exactBuffer.Length, false);
                Assert.Equal(t.Item2, forwardInExactBuffer);

                int forwardInLargeBuffer = StringExtensions.FindNewline(largerBuffer, 0, exactBuffer.Length, false);
                Assert.Equal(t.Item2, forwardInLargeBuffer);

                int reverseInExactBuffer = StringExtensions.FindNewline(exactBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true);
                Assert.Equal(t.Item3, reverseInExactBuffer);

                int reverseInLargeBuffer = StringExtensions.FindNewline(largerBuffer, Math.Max(0, exactBuffer.Length - 1), exactBuffer.Length, true);
                Assert.Equal(t.Item3, reverseInLargeBuffer);
            }
        }
    }
}
