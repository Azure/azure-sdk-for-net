// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Listeners
{
    public class StorageAnalyticsLogParserTests
    {
        [TestCase(@"1.0;2014-09-08T18:49:25.5834856Z;CopyBlob;;;;;;;;blob;"""";""/storagesample/sample-container/Copy-sample-blob.txt"";;;;;;;;;;;;;;;;;", @"/storagesample/sample-container/Copy-sample-blob.txt")]
        [TestCase(@"1.0;2014-06-19T23:31:36.5780954Z;CopyBlob;Success;202;13;13;authenticated;storagesample;storagesample;blob;""https://storagesample.blob.core.windows.net/sample-container/Copy-sample-blob.txt"";""/storagesample/sample-container/Copy-sample-blob.txt"";505fc366-688f-4622-bbb1-20e8fc26cffd;0;192.100.0.102:4362;2014-02-14;538;0;261;0;0;;;""&quot;0x8D15A2DBF11553E&quot;"";Thursday, 19-Jun-14 23:31:36 GMT;;""WA-Storage/4.0.1 (.NET CLR 4.0.30319.34014; Win32NT 6.3.9600.0)"";;""dc00da87-5483-4524-b0dc-d1df025a6a9a""", @"/storagesample/sample-container/Copy-sample-blob.txt")]
        [TestCase(@"1.0;2014-06-19T23:31:36.5780954Z;CopyBlobSource;Success;202;13;13;authenticated;storagesample;storagesample;blob;""https://storagesample.blob.core.windows.net/sample-container/Copy-sample-blob.txt"";""https://storagesample.blob.core.windows.net/sample-container/sample-blob.txt"";505fc366-688f-4622-bbb1-20e8fc26cffd;1;192.100.0.102:4362;2014-02-14;538;0;261;0;0;;;;;;""WA-Storage/4.0.1 (.NET CLR 4.0.30319.34014; Win32NT 6.3.9600.0)"";;""dc00da87-5483-4524-b0dc-d1df025a6a9a""", @"https://storagesample.blob.core.windows.net/sample-container/sample-blob.txt")]
        [TestCase(@"1.0;2014-06-19T23:31:36.5780954Z;CopyBlobDestination;Success;202;13;13;authenticated;storagesample;storagesample;blob;""https://storagesample.blob.core.windows.net/sample-container/Copy-sample-blob.txt"";""/storagesample/sample-container/Copy-sample-blob.txt"";505fc366-688f-4622-bbb1-20e8fc26cffd;2;192.100.0.102:4362;2014-02-14;538;0;261;0;0;;;;;;""WA-Storage/4.0.1 (.NET CLR 4.0.30319.34014; Win32NT 6.3.9600.0)"";;""dc00da87-5483-4524-b0dc-d1df025a6a9a""", @"/storagesample/sample-container/Copy-sample-blob.txt")]
        [TestCase(@"1.0;2014-09-08T18:49:25.5834856Z;PutBlob;Success;201;7;7;authenticated;storagesample;storagesample;blob;""https://storagesample.blob.core.windows.net/input//&quot;;&quot;?timeout=90"";""/storagesample/input//&quot;;&quot;"";9e9c90bc-0001-0052-2acc-abdcc9000000;0;192.100.0.102:4362;2011-08-18;325;0;225;0;0;""1B2M2Y8AsgTpgAmY7PhCfg=="";""1B2M2Y8AsgTpgAmY7PhCfg=="";""&quot;0x8D199ACBF198B4E&quot;"";Monday, 08-Sep-14 18:49:25 GMT;;""WA-Storage/1.7.0"";;", @"/storagesample/input//"";""")]
        public void TryParseLogEntry_IfValidLogEnry_ReturnsEntryInstance(string line, string blobPath)
        {
            StorageAnalyticsLogParser parser = new StorageAnalyticsLogParser(NullLogger<BlobListener>.Instance);

            StorageAnalyticsLogEntry entry = parser.TryParseLogEntry(line);

            Assert.NotNull(entry);
            Assert.AreEqual(blobPath, entry.RequestedObjectKey);
        }

        [TestCase(@"1.0;2014-09-08T18:49:25.5834856Z;CopyBlob;Success;202;13;13;authenticated;storagesample;storagesample;blob;""https://storagesample.blob.core.windows.net/sample-container/Copy-sample-blob.txt"";""/storagesample/sample-container/Copy-sample-blob.txt"";4;5;6;7;8;9;0;1;2;3;4;5;6;7;8;9;0;1")]
        [TestCase(@"1.0;2014-09-08T18:49:25.5834856Z;CopyBlob;Success;202;13;13;authenticated;storagesample;storagesample;blob;""https://storagesample.blob.core.windows.net/sample-container/Copy-sample-blob.txt"";""/storagesample/sample-container/Copy-sample-blob.txt"";4;5;6;7;8;9;0;1;2;3;4;5;6;7;8;9")]
        [TestCase(@"1.0;2014-09-08T18:49:25.5834856Z;CopyBlob;Success;202;13;13;authenticated;storagesample;storagesample;blob;""https://storagesample.blob.core.windows.net/sample-container/Copy-sample-blob.txt"";""/storagesample/sample-container/Copy-sample-blob.txt"";4;5;6;7;8;9;0;1;2;3;4;5;6;7;8;9;0;")]
        public void TryParseLogEntry_IfMalformedInput_ReturnsNull(string line)
        {
            StorageAnalyticsLogParser parser = new StorageAnalyticsLogParser(NullLogger<BlobListener>.Instance);

            StorageAnalyticsLogEntry entry = parser.TryParseLogEntry(line);

            Assert.Null(entry);
        }

        [TestCase(@"1.0;<REMINDER>", 1, 0)]
        [TestCase(@"1.1;<REMINDER>", 1, 1)]
        [TestCase(@"2.0;<REMINDER>", 2, 0)]
        public void TryParseVersion_IfCorrectVersionFormat_ReturnsVersion(string line, int major, int minor)
        {
            Version version = StorageAnalyticsLogParser.TryParseVersion(line);

            Assert.NotNull(version);
            Assert.AreEqual(new Version(major, minor), version);
        }

        [TestCase(null)]
        [TestCase("")]
        public void TryParseVersion_IfNullOrEmpty_ReturnsNull(string line)
        {
            Version version = StorageAnalyticsLogParser.TryParseVersion(line);

            Assert.Null(version);
        }

        [TestCase(@";2014-09-08T18:49:25.5834856Z;CopyBlob;Success;202;13;13;authenticated;storagesample;storagesample;blob;""https://storagesample.blob.core.windows.net/sample-container/Copy-sample-blob.txt"";""/storagesample/sample-container/Copy-sample-blob.txt"";4;5;6;7;8;9;0;1;2;3;4;5;6;7;8;9;0")]
        [TestCase(@"fake;2014-09-08T18:49:25.5834856Z;CopyBlob;Success;202;13;13;authenticated;storagesample;storagesample;blob;""https://storagesample.blob.core.windows.net/sample-container/Copy-sample-blob.txt"";""/storagesample/sample-container/Copy-sample-blob.txt"";4;5;6;7;8;9;0;1;2;3;4;5;6;7;8;9;0")]
        public void TryParseVersion_IfMalformedVersionFormat_ReturnsNull(string line)
        {
            Version version = StorageAnalyticsLogParser.TryParseVersion(line);

            Assert.Null(version);
        }
    }
}
