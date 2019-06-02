// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AlertsManagement.Tests.Helpers;
using Microsoft.Azure.Management.AlertsManagement;
using Microsoft.Azure.Management.AlertsManagement.Models;
using Xunit;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlertsManagement.Tests.UnitTests
{
    public class OperationsTests : TestBase
    {
        [Fact]
        [Trait("Category", "Mock")]
        public void ListOperationsTest()
        {
            var handler = new RecordedDelegatingHandler();
            var alertsManagementClient = GetAlertsManagementClient(handler);

            var result = alertsManagementClient.Operations.List();

            Assert.Equal(2, result.Count());
        }
    }
}
