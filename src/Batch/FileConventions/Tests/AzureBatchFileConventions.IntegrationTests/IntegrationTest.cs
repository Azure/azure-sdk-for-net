using Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities;
using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using Microsoft.WindowsAzure.Storage;
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
            StorageAccount = StorageConfiguration.GetAccount(output);
            FileBase = new DirectoryInfo("Files");
            _jobIdFixture = jobIdFixture;
        }

        protected ITestOutputHelper Output { get; }

        protected CloudStorageAccount StorageAccount { get; }

        public void CancelTeardown() => _jobIdFixture.CancelTeardown();

        protected DirectoryInfo FileBase { get; }

        protected string FilePath(string relativePath) => Path.Combine(FileBase.Name, relativePath);

        protected DirectoryInfo FileSubfolder(string relativeFolderPath) => new DirectoryInfo(Path.Combine(FileBase.Name, relativeFolderPath));
    }
}
