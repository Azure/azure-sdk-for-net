// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UploadMetadataGeneratorTests.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Unit tests for the UploadMetadataGenerator class.
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
    using Microsoft.Azure.Management.DataLake.StoreUploader;
    using Xunit;

    [SuppressMessage("StyleCop.CSharp.NamingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*")]
    public class UploadMetadataGeneratorTests
    {
        private const int MaxAppendLength = 4 * 1024 * 1024;
        private static readonly byte[] NewLine = Encoding.UTF8.GetBytes("\r\n");
        private static readonly List<double> FileLengthsMB = new List<double> { 2, 4, 10, 14.123456, 20.123456, 23.456789, 30.987654, 37.897643, 50.546213, 53.456789, 123.456789 };

        [Fact]
        public void UploadMetadataGenerator_AlignSegmentsToRecordBoundaries()
        {
            //We keep creating a file, by appending a number of bytes to it (taken from FileLengthsInMB). 
            //At each iteration, we append a new blob of data, and then run the whole test on the entire file
            var rnd = new Random(0);
            string folderPath = string.Format(@"{0}\uploadtest", Environment.CurrentDirectory);
            string filePath = Path.Combine(folderPath, "verifymetadata.txt");
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                foreach (var lengthMB in FileLengthsMB)
                {
                    var appendLength = (int) (lengthMB*1024*1024);
                    AppendToFile(filePath, appendLength, rnd, 0, MaxAppendLength);
                    string metadataFilePath = filePath + ".metadata.txt";

                    var up = new UploadParameters(filePath, filePath, null, isBinary: false,
                        maxSegmentLength: 4*1024*1024);
                    var mg = new UploadMetadataGenerator(up, MaxAppendLength);
                    var metadata = mg.CreateNewMetadata(metadataFilePath);

                    VerifySegmentsAreOnRecordBoundaries(metadata, filePath);
                }
            }
            finally
            {
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                }
            }
        }

        [Fact]
        public void UploadMetadataGenerator_AlignSegmentsToRecordBoundariesTooLargeRecord()
        {
            //We keep creating a file, by appending a number of bytes to it (taken from FileLengthsInMB). 
            //At each iteration, we append a new blob of data, and then run the whole test on the entire file
            var rnd = new Random(0);
            string folderPath = string.Format(@"{0}\uploadtest", Environment.CurrentDirectory);
            string filePath = Path.Combine(folderPath, "verifymetadata.txt");
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                foreach (var lengthMB in FileLengthsMB.Where(l => l > MaxAppendLength))
                {
                    var length = (int) (lengthMB*1024*1024);
                    AppendToFile(filePath, length, rnd, MaxAppendLength + 1, MaxAppendLength + 10);
                    string metadataFilePath = filePath + ".metadata.txt";

                    var up = new UploadParameters(filePath, filePath, null, isBinary: false,
                        maxSegmentLength: 4*1024*1024);
                    var mg = new UploadMetadataGenerator(up, MaxAppendLength);

                    Assert.Throws<Exception>(() => mg.CreateNewMetadata(metadataFilePath));
                }
            }
            finally
            {
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                }
            }
        }

        private void VerifySegmentsAreOnRecordBoundaries(UploadMetadata metadata, string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                foreach (var segment in metadata.Segments)
                {
                    if (segment.SegmentNumber > 0)
                    {
                        //verify that each segment starts with a non-newline and that the 2 previous characters before that offset are newline characters

                        //2 characters behind: newline
                        stream.Seek(segment.Offset - 2, SeekOrigin.Begin);
                        char c1 = (char)stream.ReadByte();
                        Assert.True(IsNewline(c1), string.Format("Expecting a newline at offset {0}", stream.Position - 1));

                        //1 character behind: newline
                        char c2 = (char)stream.ReadByte();
                        Assert.True(IsNewline(c2), string.Format("Expecting a newline at offset {0}", stream.Position - 1));

                        //by test design, we never have two consecutive newlines that are the same; we'd always have \r\n, but never \r\r or \r\n
                        var c3 = (char)stream.ReadByte();
                        Assert.NotEqual(c2, c3);
                    }
                }
            }
        }

        private bool IsNewline(char c)
        {
            return c == '\r' || c == '\n';
        }

        private string AppendToFile(string filePath, int length, Random random, int minRecordLength, int maxRecordLength)
        {
            using (var stream =  new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                int newLength = (int)stream.Length + length;
                while (true)
                {
                    var recordLength = minRecordLength + random.Next(maxRecordLength - minRecordLength);
                    if (stream.Position + recordLength + NewLine.Length > newLength)
                    {
                        recordLength = newLength - NewLine.Length - (int)stream.Position;
                        if (recordLength < 0)
                        {
                            stream.Write(NewLine, 0, NewLine.Length);
                            break;
                        }
                    }
                    WriteRecord(stream, recordLength);
                    stream.Write(NewLine, 0, NewLine.Length);
                }
            }

            return filePath;
        }

        private void WriteRecord(FileStream stream, int count)
        {
            byte[] record = new byte[count];
            for (int i = 0; i < count; i++)
            {
                record[i] = (byte)('a' + i % 25);
            }
            stream.Write(record, 0, record.Length);
        }
    }
}
