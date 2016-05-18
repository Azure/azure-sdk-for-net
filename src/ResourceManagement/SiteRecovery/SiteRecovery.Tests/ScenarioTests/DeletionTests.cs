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

using Microsoft.Azure.Management.SiteRecovery.Models;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Test;
using System.Net;
using System.Linq;
using Xunit;


namespace SiteRecovery.Tests
{
    public class DeletionTests : SiteRecoveryTestsBase
    {
        public void RemoveServer()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetSiteRecoveryClient(CustomHttpHandler);

                FabricListResponse responseServers = client.Fabrics.List(RequestHeaders);

                FabricResponse response = client.Fabrics.Get(responseServers.Fabrics[0].Name, RequestHeaders);

                foreach (Fabric fabric in responseServers.Fabrics)
                {
                    var dras = client.RecoveryServicesProvider.List(fabric.Name, RequestHeaders).RecoveryServicesProviders;

                    var removeServerResponse = client.RecoveryServicesProvider.Delete(fabric.Name, dras[0].Name, RequestHeaders);
                }

                Assert.NotNull(response.Fabric);
                Assert.NotNull(response.Fabric.Name);
                Assert.NotNull(response.Fabric.Id);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
