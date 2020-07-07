// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Executors
{
    public class StorageAccountParserTests
    {
        [Fact(Skip = "Missing StorageAccountParser")]
        public void TryParseAccount_WithEmpty_Fails()
        {
            //string connectionString = string.Empty;

            //StorageAccountParseResult result = StorageAccountParser.TryParseAccount(connectionString, out CloudStorageAccount ignore);

            //Assert.Equal(StorageAccountParseResult.MissingOrEmptyConnectionStringError, result);
        }

        [Fact(Skip = "Missing StorageAccountParser")]
        public void TryParseAccount_WithNull_Fails()
        {
            //string connectionString = null;

            //StorageAccountParseResult result = StorageAccountParser.TryParseAccount(connectionString, out CloudStorageAccount ignore);

            //Assert.Equal(StorageAccountParseResult.MissingOrEmptyConnectionStringError, result);
        }

        [Fact(Skip = "Missing StorageAccountParser")]
        public void TryParseAccount_WithMalformed_Fails()
        {
            //string connectionString = "DefaultEndpointsProtocol=https;AccountName=[NOVALUE];AccountKey=[NOVALUE]";

            //StorageAccountParseResult result = StorageAccountParser.TryParseAccount(connectionString, out CloudStorageAccount ignore);

            //Assert.Equal(StorageAccountParseResult.MalformedConnectionStringError, result);
        }
    }
}
