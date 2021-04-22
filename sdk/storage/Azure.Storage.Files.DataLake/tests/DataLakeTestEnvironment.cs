// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DataLakeTestEnvironment : StorageTestEnvironment
    {
        protected override async ValueTask<bool> IsEnvironmentReadyAsync()
        {
            return await DoesOAuthWorkAsync();
        }

        private async Task<bool> DoesOAuthWorkAsync()
        {
            TestContext.Error.WriteLine("Datalake Probing OAuth");
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(
                new Uri(TestConfigurations.DefaultTargetHierarchicalNamespaceTenant.BlobServiceEndpoint),
                GetOAuthCredential(TestConfigurations.DefaultTargetHierarchicalNamespaceTenant));
            try
            {
                await serviceClient.GetPropertiesAsync();
                var fileSystemName = Guid.NewGuid().ToString();
                var fileSystemClient = serviceClient.GetFileSystemClient(fileSystemName);
                await fileSystemClient.CreateIfNotExistsAsync();
                try
                {
                    var directoryName = Guid.NewGuid().ToString();
                    var directoryClient = fileSystemClient.GetDirectoryClient(directoryName);
                    await directoryClient.CreateIfNotExistsAsync();
                    await directoryClient.GetPropertiesAsync();
                    var fileName = Guid.NewGuid().ToString();
                    var fileClient = directoryClient.GetFileClient(fileName);
                    await fileClient.CreateIfNotExistsAsync();
                    await fileClient.GetPropertiesAsync();
                    // call some APIs that talk to DFS endoint as well.
                    await fileClient.AppendAsync(new MemoryStream(new byte[] { 1 }), 0);
                    await fileClient.GetAccessControlAsync();
                }
                finally
                {
                    await fileSystemClient.DeleteIfExistsAsync();
                }
            }
            catch (RequestFailedException e) when (e.Status == 403 && e.ErrorCode == "AuthorizationPermissionMismatch")
            {
                TestContext.Error.WriteLine("Datalake Probing OAuth - not ready");
                return false;
            }
            TestContext.Error.WriteLine("Datalake Probing OAuth - ready");
            return true;
        }
    }
}
