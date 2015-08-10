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

using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using Xunit;

namespace RemoteApp.Tests
{
    /// <summary>
    /// RemoteApp VM specific test cases
    /// </summary>
    public class VmTests : RemoteAppTestBase
    {
        /// <summary>
        /// Testing of querying of a list of VMs in a collection
        /// </summary>
        [Fact]
        public void CanListVms()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                CollectionListResult collectionList = null;
                Assert.DoesNotThrow(() =>
                {
                    collectionList = client.Collections.List();
                });

                Assert.NotNull(collectionList);

                Assert.NotEmpty(collectionList.Collections);

                foreach (Collection collection in collectionList.Collections)
                {
                    CollectionVmsListResult vmsList = null;

                    Assert.DoesNotThrow(() =>
                    {
                        vmsList = client.Collections.ListVms(collection.Name);
                    });

                    Assert.NotNull(vmsList);

                    Assert.NotEmpty(vmsList.Vms);

                    foreach (RemoteAppVm vm in vmsList.Vms)
                    {
                        Assert.NotNull(vm.VirtualMachineName);

                        Assert.NotNull(vm.LoggedOnUserUpns);
                    }
                }
            }
        }

        /// <summary>
        /// Testing of restart VM command
        /// </summary>
        [Fact]
        public void CanRestartVm()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                RemoteAppManagementClient client = GetRemoteAppManagementClient();

                CollectionListResult collectionList = null;
                Assert.DoesNotThrow(() =>
                {
                    collectionList = client.Collections.List();
                });

                Assert.NotNull(collectionList);

                Assert.NotEmpty(collectionList.Collections);

                foreach (Collection collection in collectionList.Collections)
                {
                    CollectionVmsListResult vmsList = null;

                    Assert.DoesNotThrow(() =>
                    {
                        vmsList = client.Collections.ListVms(collection.Name);
                    });

                    Assert.NotNull(vmsList);

                    Assert.NotEmpty(vmsList.Vms);

                    Assert.DoesNotThrow(() =>
                    {
                        RestartVmCommandParameter restartParam = new RestartVmCommandParameter();

                        restartParam.VirtualMachineName = vmsList.Vms[0].VirtualMachineName;
                        restartParam.LogoffMessage = "You will be logged off after 2 minutes";
                        restartParam.LogoffWaitTimeInSeconds = 120;

                        OperationResultWithTrackingId restartResult = client.Collections.RestartVm(collection.Name, restartParam);

                        Assert.True(restartResult.StatusCode == HttpStatusCode.OK);

                        Assert.NotNull(restartResult.TrackingId);
                    });

                    break;
                }
            }
        }
    }
}
