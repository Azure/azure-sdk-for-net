// -----------------------------------------------------------------------------------------
// <copyright file="BlobTestBase.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;

#if RTMD
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace Microsoft.WindowsAzure.Storage.Blob
{
    public partial class BlobTestBase : TestBase
    {
        public static string GetRandomContainerName()
        {
            return string.Concat("testc", Guid.NewGuid().ToString("N"));
        }

        public static CloudBlobContainer GetRandomContainerReference()
        {
            CloudBlobClient blobClient = GenerateCloudBlobClient();

            string name = GetRandomContainerName();
            CloudBlobContainer container = blobClient.GetContainerReference(name);

            return container;
        }

        public static List<string> GetBlockIdList(int count)
        {
            List<string> blocks = new List<string>();
            for (int i = 0; i < count; i++)
            {
                blocks.Add(Convert.ToBase64String(Guid.NewGuid().ToByteArray()));
            }
            return blocks;
        }

        public static byte[] GetRandomBuffer(int size)
        {
            byte[] buffer = new byte[size];
            Random random = new Random();
            random.NextBytes(buffer);
            return buffer;
        }

        public static void SeekRandomly(Stream stream, long offset)
        {
            Random random = new Random();
            int randomOrigin = random.Next(3);
            SeekOrigin origin = SeekOrigin.Begin;
            switch (randomOrigin)
            {
                case 1:
                    origin = SeekOrigin.Current;
                    offset = offset - stream.Position;
                    break;

                case 2:
                    origin = SeekOrigin.End;
                    offset = offset - stream.Length;
                    break;
            }
            stream.Seek(offset, origin);
        }

        public static void AssertAreEqual(ICloudBlob blob1, ICloudBlob blob2)
        {
            if (blob1 == null)
            {
                Assert.IsNull(blob2);
            }
            else
            {
                Assert.IsNotNull(blob2);
                Assert.AreEqual(blob1.BlobType, blob2.BlobType);
                Assert.AreEqual(blob1.Uri, blob2.Uri);
                Assert.AreEqual(blob1.SnapshotTime, blob2.SnapshotTime);
                AssertAreEqual(blob1.Properties, blob2.Properties);
                AssertAreEqual(blob1.CopyState, blob2.CopyState);
            }
        }

        public static void AssertAreEqual(BlobProperties prop1, BlobProperties prop2)
        {
            if (prop1 == null)
            {
                Assert.IsNull(prop2);
            }
            else
            {
                Assert.IsNotNull(prop2);
                Assert.AreEqual(prop1.CacheControl, prop2.CacheControl);
                Assert.AreEqual(prop1.ContentEncoding, prop2.ContentEncoding);
                Assert.AreEqual(prop1.ContentLanguage, prop2.ContentLanguage);
                Assert.AreEqual(prop1.ContentMD5, prop2.ContentMD5);
                Assert.AreEqual(prop1.ContentType, prop2.ContentType);
                Assert.AreEqual(prop1.ETag, prop2.ETag);
                Assert.AreEqual(prop1.LastModified, prop2.LastModified);
                Assert.AreEqual(prop1.Length, prop2.Length);
            }
        }

        public static void AssertAreEqual(CopyState copy1, CopyState copy2)
        {
            if (copy1 == null)
            {
                Assert.IsNull(copy2);
            }
            else
            {
                Assert.IsNotNull(copy2);
                Assert.AreEqual(copy1.BytesCopied, copy2.BytesCopied);
                Assert.AreEqual(copy1.CompletionTime, copy2.CompletionTime);
                Assert.AreEqual(copy1.CopyId, copy2.CopyId);
                Assert.AreEqual(copy1.Source, copy2.Source);
                Assert.AreEqual(copy1.Status, copy2.Status);
                Assert.AreEqual(copy1.TotalBytes, copy2.TotalBytes);
            }
        }
    }
}
