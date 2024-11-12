// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage
{
    /// <summary>
    /// Base class for all Sample unit tests that contains minimal utilities
    /// for keeping the samples easy to read.
    /// </summary>
    [TestFixture]
    [Category("Recorded")]
    public abstract class SampleTest
    {
        /// <summary>
        /// Get a connection string to use from our test settings.
        /// </summary>
        public string ConnectionString => TestConfigurations.DefaultTargetTenant.ConnectionString;

        /// <summary>
        /// Get an account name to use from our test settings.
        /// </summary>
        public string StorageAccountName => TestConfigurations.DefaultTargetTenant.AccountName;

        /// <summary>
        /// Get an account key to use from our test settings.
        /// </summary>
        public string StorageAccountKey => TestConfigurations.DefaultTargetTenant.AccountKey;

        /// <summary>
        /// Get a blob endpoint to use from our test settings.
        /// </summary>
        public Uri StorageAccountBlobUri => new Uri(TestConfigurations.DefaultTargetTenant.BlobServiceEndpoint);

        /// <summary>
        /// Get a queue endpoint to use from our test settings.
        /// </summary>
        public Uri StorageAccountQueueUri => new Uri(TestConfigurations.DefaultTargetTenant.QueueServiceEndpoint);

        /// <summary>
        /// Get a file endpoint to use from our test settings.
        /// </summary>
        public Uri StorageAccountFileUri => new Uri(TestConfigurations.DefaultTargetTenant.FileServiceEndpoint);

        /// <summary>
        /// Get a blob endpoint associated with our AD application from our test settings.
        /// </summary>
        public Uri ActiveDirectoryBlobUri => new Uri(TestConfigurations.DefaultTargetOAuthTenant.BlobServiceEndpoint);

        /// <summary>
        /// Get a queue endpoint associated with our AD application from our test settings.
        /// </summary>
        public Uri ActiveDirectoryQueueUri => new Uri(TestConfigurations.DefaultTargetOAuthTenant.BlobServiceEndpoint);

        /// <summary>
        /// Get a namespace account name to use from our test settings.
        /// </summary>
        public string NamespaceStorageAccountName => TestConfigurations.DefaultTargetHierarchicalNamespaceTenant.AccountName;

        /// <summary>
        /// Get an namespace account key to use from our test settings.
        /// </summary>
        public string NamespaceStorageAccountKey => TestConfigurations.DefaultTargetHierarchicalNamespaceTenant.AccountKey;

        /// <summary>
        /// Get a namespace endpoint to use from our test settings.
        /// </summary>
        public Uri NamespaceBlobUri => new Uri(TestConfigurations.DefaultTargetHierarchicalNamespaceTenant.BlobServiceEndpoint);

        /// <summary>
        /// Get a random name so we won't have any conflicts when creating
        /// resources.
        /// </summary>
        /// <param name="prefix">Optional prefix for the random name.</param>
        /// <returns>A random name.</returns>
        public string Randomize(string prefix = "sample") =>
            $"{prefix}-{Guid.NewGuid()}";

        /// <summary>
        /// Lorem Ipsum sample file content
        /// </summary>
        protected const string SampleFileContent = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras dolor purus, interdum in turpis ut, ultrices ornare augue. Donec mollis varius sem, et mattis ex gravida eget. Duis nibh magna, ultrices a nisi quis, pretium tristique ligula. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Vestibulum in dui arcu. Nunc at orci volutpat, elementum magna eget, pellentesque sem. Etiam id placerat nibh. Vestibulum varius at elit ut mattis.  Suspendisse ipsum sem, placerat id blandit ac, cursus eget purus. Vestibulum pretium ante eu augue aliquam, ultrices fermentum nibh condimentum. Pellentesque pulvinar feugiat augue vel accumsan. Nulla imperdiet viverra nibh quis rhoncus. Nunc tincidunt sollicitudin urna, eu efficitur elit gravida ut. Quisque eget urna convallis, commodo diam eu, pretium erat. Nullam quis magna a dolor ullamcorper malesuada. Donec bibendum sem lectus, sit amet faucibus nisi sodales eget. Integer lobortis lacus et volutpat dignissim. Suspendisse cras amet.";

        /// <summary>
        /// Create a temporary path for creating files.
        /// </summary>
        /// <param name="extension">An optional file extension.</param>
        /// <returns>A temporary path for creating files.</returns>
        public string CreateTempPath(string extension = ".txt") =>
            Path.ChangeExtension(Path.GetTempFileName(), extension);

        /// <summary>
        /// Create a temporary path for directories
        /// </summary>
        /// <returns>A temporary path for creating files.</returns>
        public string CreateTempDirectoryPath() =>
            Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

        /// <summary>
        /// Create a temporary file on disk.
        /// </summary>
        /// <param name="content">Optional content for the file.</param>
        /// <returns>Path to the temporary file.</returns>
        public string CreateTempFile(string content = SampleFileContent)
        {
            string path = CreateTempPath();
            File.WriteAllText(path, content);
            return path;
        }

        /// <summary>
        /// Create a temporary directory tree on disk.
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public string CreateSampleDirectoryTree()
        {
            // TODO: create directory tree
            string path = CreateTempDirectoryPath();
            Directory.CreateDirectory(path);
            return path;
        }
    }
}
