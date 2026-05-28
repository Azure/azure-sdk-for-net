// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities;
using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

[assembly: TestFramework("Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Xunit.ExtendedTestFramework", "Microsoft.Azure.Batch.Conventions.Files.IntegrationTests")]

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests
{
    public class IntegrationTest
    {
        private readonly JobIdFixture _jobIdFixture;

        public IntegrationTest(JobIdFixture jobIdFixture, ITestOutputHelper output)
        {
            Output = output;
            blobClient = StorageConfiguration.GetAccount(output);
            FileBase = new DirectoryInfo("Files");
            _jobIdFixture = jobIdFixture;
        }

        protected ITestOutputHelper Output { get; }

        protected BlobServiceClient blobClient { get; }

        public void CancelTeardown() => _jobIdFixture.CancelTeardown();

        protected DirectoryInfo FileBase { get; }

        protected string FilePath(string relativePath) => Path.Combine(FileBase.Name, relativePath);

        protected DirectoryInfo FileSubfolder(string relativeFolderPath) => new DirectoryInfo(Path.Combine(FileBase.Name, relativeFolderPath));
    }
}
