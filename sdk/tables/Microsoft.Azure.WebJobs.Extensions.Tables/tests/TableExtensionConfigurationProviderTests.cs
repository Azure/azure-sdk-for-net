// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.WebJobs.Host.Bindings;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Tables.Tests
{
    internal class TableExtensionConfigurationProviderTests
    {
        [Test]
        public async Task CreateParameterBindingData_CreatesValidParameterBindingDataObject()
        {
            var config = new TablesExtensionConfigProvider(null, null, null);

            var attribute = new TableAttribute("tableName", "partitionKey", "rowKey");
            var data = @"{""TableName"":""tableName"",""Take"":0,""Filter"":null,""Connection"":null,""PartitionKey"":""partitionKey"",""RowKey"":""rowKey""}";
            var expectedBinaryData = new BinaryData(data).ToString();

            // Act
            var pbdObj = await config.CreateParameterBindingData(attribute, null);

            // Assert
            Assert.AreEqual("AzureStorageTables", pbdObj.Source);
            Assert.AreEqual("1.0", pbdObj.Version);
            Assert.AreEqual(expectedBinaryData, pbdObj.Content.ToString());
            Assert.AreEqual("application/json", pbdObj.ContentType);
        }
    }
}
