// Copyright (c) Microsoft Corporation
// All rights reserved.
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.

namespace Microsoft.Hadoop.Avro.Tests
{
    using System;
    using System.IO;
    using System.Text;

    using Microsoft.Hadoop.Avro.Tools;

    internal sealed class MockExecutionContext : IExecutionContext
    {
        public static string ErrorMessage { get; set; }

        public static string OutMessage { get; private set; }

        public static string FileToRead { get; private set; }

        public static string FileToReadContent { get; set; }

        public static string FileToWrite { get; private set; }

        public static string FileToWriteContent { get; private set; }

        public static string DirectoryToSet { get; set; }

        public static Exception OnReadException { get; set; }

        public static Exception OnWriteException { get; set; }

        public static Exception OnSetDirectoryException { get; set; }

        public static void Initialize()
        {
            ErrorMessage = null;
            OutMessage = null;
            FileToRead = null;
            FileToReadContent = null;
            FileToWrite = null;
            FileToWriteContent = null;
            DirectoryToSet = null;
            OnReadException = null;
            OnWriteException = null;
            OnSetDirectoryException = null;
        }

        public void Error(string message)
        {
            ErrorMessage += message;
        }

        public void Out(string message)
        {
            OutMessage += message;
        }

        public string ReadFile(string filePath)
        {
            FileToRead = filePath;
            if (OnReadException != null)
            {
                throw OnReadException;
            }
            return FileToReadContent;
        }

        public void WriteFile(string filePath, Stream stream)
        {
            FileToWrite = filePath;
            stream.Seek(0, SeekOrigin.Begin);
            FileToWriteContent = new StreamReader(stream, Encoding.Unicode).ReadToEnd();
            if (OnWriteException != null)
            {
                throw OnWriteException;
            }
        }

        public void SetOutputDirectory(string directoryPath)
        {
            DirectoryToSet = directoryPath;
            if (OnSetDirectoryException != null)
            {
                throw OnSetDirectoryException;
            }
        }
    }
}
