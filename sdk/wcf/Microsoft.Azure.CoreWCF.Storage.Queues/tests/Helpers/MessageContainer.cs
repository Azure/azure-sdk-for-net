// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace CoreWCF.AzureQueueStorage.Tests.Helpers
{
    internal class MessageContainer
    {
        public static Stream GetTestMessage()
        {
             string currentDirectory = Environment.CurrentDirectory;
              string path = Path.Combine(currentDirectory, "Resources/aqsTestMessage.bin");
              return File.OpenRead(path);
        }

        public static Stream GetEmptyTestMessage()
        {
            string currentDirectory = Environment.CurrentDirectory;
            string path = Path.Combine(currentDirectory, "Resources/aqsEmptyTestMessage.bin");
            return File.OpenRead(path);
        }

        public static Stream GetBadTestMessage()
        {
            var bytes = new byte[] { 0, 1, 0, 1, 4, 2, 37, 110, };
            return new MemoryStream(bytes);
        }
    }
}
