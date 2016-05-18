﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Test;
using System.Net;
using Xunit;
using System.Collections.Generic;
using System;


namespace SiteRecovery.Tests
{
    public class SiteTests : SiteRecoveryTestsBase
    {
        string siteName = "site3";

        [Fact]
        public void CreateSite()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                FabricCreationInput siteInput = new FabricCreationInput();
                siteInput.Properties = new FabricCreationInputProperties();
                siteInput.Properties.FabricType = "";

                var site = client.Fabrics.Create(siteName, siteInput, RequestHeaders);
                var response = client.Fabrics.Get(siteName, RequestHeaders);
                Assert.True(response.Fabric.Name == siteName, "Site Name can not be different");

            }
        }

        [Fact]
        public void DeleteSite()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                var site = client.Fabrics.Delete(siteName, RequestHeaders);
                Assert.True(site.StatusCode == HttpStatusCode.NoContent, "Site Name should have been deleted");
            }
        }
    }
}
