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
namespace Microsoft.Hadoop.Avro.Tools
{
    using System;
    using System.Globalization;
    using System.IO;

    using Microsoft.Hadoop.Avro.Tools.Properties;

    internal sealed class ExecutionContext : IExecutionContext
    {
        public void Error(string message)
        {
            Console.Error.WriteLine(message);
        }

        public void Out(string message)
        {
            Console.Out.WriteLine(message);
        }

        public string ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.ErrorPathDoesNotExist, filePath));
            }

            try
            {
                return File.ReadAllText(filePath);
            }
            catch (IOException)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.ErrorCouldNotReadPath, filePath));
            }
        }

        public void WriteFile(string filePath, Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            using (var file = File.Create(filePath))
            {
                stream.CopyTo(file);
            }
        }

        public void SetOutputDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
