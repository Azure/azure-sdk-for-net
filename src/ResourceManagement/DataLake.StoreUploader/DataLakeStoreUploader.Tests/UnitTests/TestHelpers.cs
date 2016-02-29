// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestHelpers.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Reusable code throughout the test cases.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Azure.Management.DataLake.StoreUploader.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*")]
    internal static class TestHelpers
    {
        /// <summary>
        /// Generates some random data and writes it out to a temp file and to an in-memory array
        /// </summary>
        /// <param name="contents">The array to write random data to (the length of this array will be the size of the file).</param>
        /// <param name="filePath">This will contain the path of the file that will be created.</param>
        internal static void GenerateFileData(byte[] contents, out string filePath)
        {
            filePath = Path.GetTempFileName();

            var rnd = new Random(0);
            rnd.NextBytes(contents);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            File.WriteAllBytes(filePath, contents);
        }

        /// <summary>
        /// Generates some random data and writes it out to a temp file and to an in-memory array
        /// </summary>
        /// <param name="contents">The array to write random data to (the length of this array will be the size of the file).</param>
        /// <param name="filePath">This will contain the path of the file that will be created.</param>
        internal static void GenerateTextFileData(byte[] contents, int minRecordLength, int maxRecordLength, out string filePath)
        {
            filePath = Path.GetTempFileName();

            var rnd = new Random(0);

            int offset = 0;
            while (offset < contents.Length)
            {
                int recordLength = rnd.Next(minRecordLength, maxRecordLength);
                recordLength = Math.Min(recordLength, contents.Length - offset - 2);
                
                int recordEndPos = offset + recordLength;
                while (offset < recordEndPos)
                {
                    contents[offset] = (byte)rnd.Next((int)'a', (int)'z');
                    offset++;
                }
                contents[offset++] = (byte)'\r';
                contents[offset++] = (byte)'\n';
            }
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            File.WriteAllBytes(filePath, contents);
        }
    }
}
