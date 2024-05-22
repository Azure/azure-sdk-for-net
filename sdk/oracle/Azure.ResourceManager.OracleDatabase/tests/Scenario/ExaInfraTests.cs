// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using Azure.Core;
using Azure.ResourceManager.OracleDatabase.Models;
using System;

namespace Azure.ResourceManager.OracleDatabase.Tests.Scenario
{
    [TestFixture]
    public class ExaInfraTests : OracleDatabaseManagementTestBase
    {
        public ExaInfraTests() : base(true)
        {
        }
    }
}