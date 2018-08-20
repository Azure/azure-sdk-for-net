
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using DedicatedServices.Tests.Helpers;
using Microsoft.Azure;
using Microsoft.Azure.Management.Kusto;
using Microsoft.Azure.Management.Kusto.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;

namespace Kusto.Tests.ScenarioTests
{
    public class KustoOperationsTests : TestBase
    {
        [Fact]
        public void OperationsTest()
        {
            string executingAssemblyPath = typeof(KustoOperationsTests).GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");

            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var client = this.GetKustoManagementClient(context);

                try
                {
                    // Create a test capacity
                    var resultOperationsList = client.Operations.List();
                    // validate the operations result
                    Assert.Equal(9, resultOperationsList.Count());

                    var operationsPageLink = "https://api-dogfood.resources.windows-int.net/providers/Microsoft.Kusto/operations?api-version=2017-09-07-privatepreview";
                    var resultOperationsNextPage = client.Operations.ListNext(operationsPageLink);

                    // validate the operations result
                    Assert.Equal(5, resultOperationsNextPage.Count());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
            }
        }
    }
}
