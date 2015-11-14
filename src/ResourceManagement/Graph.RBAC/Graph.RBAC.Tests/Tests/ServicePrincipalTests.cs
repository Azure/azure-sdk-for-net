//
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

using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Graph.RBAC.Tests
{
    public class ServicePrincipalTests : GraphTestBase
    {
        [Fact(Skip = "TODO: Fix test")]
        public void CreateDeleteApplicationTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                //Test
                var passwordCredential = CreatePasswordCredential();
                var keyCredential = CreateKeyCredential();
                var application = CreateApplication(context, passwordCredential, keyCredential);
                var newPasswordCredential = CreatePasswordCredential();
                UpdateApplication(context, application.ObjectId, newPasswordCredential);
                DeleteApplication(context, application.ObjectId);
                //verify the user has been deleted.
                Assert.Throws(typeof(CloudException), () => { SearchApplication(context, application.ObjectId); });
            }
        }

        [Fact(Skip = "TODO: Fix test")]
        public void CreateDeleteServicePrincipalTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                ServicePrincipal sp = null;

                //Test
                var passwordCredential = CreatePasswordCredential();
                var application = CreateApplication(context, passwordCredential);
                try
                {
                    sp = CreateServicePrincipal(context, application.AppId);
                    DeleteServicePrincipal(context, sp.ObjectId);
                }
                finally
                {
                    DeleteApplication(context, application.ObjectId);
                }

                //verify the user has been deleted.
                Assert.Throws(typeof(CloudException), () => { SearchServicePrincipal(context, sp.ObjectId); });
            }
        }
    }
}
