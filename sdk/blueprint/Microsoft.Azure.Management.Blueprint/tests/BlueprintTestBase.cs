// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Management.Blueprint.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using Microsoft.Azure.Management.Blueprint;
    using Microsoft.Azure.Management.Blueprint.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Newtonsoft.Json;

    public class BlueprintTestBase : TestBase, IDisposable
    {
        public BlueprintManagementClient BlueprintClient { get; private set; }

        public BlueprintTestBase(MockContext context)
        {
            this.BlueprintClient = context.GetServiceClient<BlueprintManagementClient>();
        }

        public void Dispose()
        {
            return;
        }
    }
}
