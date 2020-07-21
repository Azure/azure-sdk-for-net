// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs.Host.TestCommon;

namespace FakeStorage
{
    // Provide an accessor for getting to private fields. 
    internal class Wrapper
    {
        private readonly object _value;

        public Wrapper(object value)
        {
            _value = value;
        }
        public Wrapper GetField(string name)
        {
            var t = _value.GetType();
            var prop = t.GetField(name,
              BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            var next = prop.GetValue(_value);
            return new Wrapper(next);
        }

        public void SetInternalField(string name, object value)
        {
            _value.SetInternalProperty(name, value);
        }
    }

    internal static class MoreStorageExtensions
    {
        public static string DownloadText(this ICloudBlob blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException("blob");
            }

            using (Stream stream = blob.OpenReadAsync(null, null, null).GetAwaiter().GetResult())
            using (TextReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        public static async Task UploadEmptyPageAsync(this CloudPageBlob blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException("blob");
            }

            using (CloudBlobStream stream = await blob.OpenWriteAsync(512))
            {
                await stream.CommitAsync();
            }
        }
    }
}
