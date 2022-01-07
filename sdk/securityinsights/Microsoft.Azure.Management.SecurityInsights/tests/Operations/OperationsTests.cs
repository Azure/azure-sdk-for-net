// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.SecurityInsights;
using Microsoft.Azure.Management.SecurityInsights.Models;
using Microsoft.Azure.Management.SecurityInsights.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.SecurityInsights.Tests
{
    public class OperationsTests : TestBase
    {
        #region Test setup

        #endregion

        #region Operations

        [Fact]
        public void Operations_List()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var SecurityInsightsClient = TestHelper.GetSecurityInsightsClient(context);
                var Operations = SecurityInsightsClient.Operations.List();
                ValidateOperations(Operations);
            }
        }

        #endregion

        #region Validations

        private void ValidateOperations(IPage<Operation> Operationpage)
        {
            Assert.True(Operationpage.IsAny());

            Operationpage.ForEach(ValidateOperation);
        }

        private void ValidateOperation(Operation Operation)
        {
            Assert.NotNull(Operation);
        }

        #endregion
    }
}
