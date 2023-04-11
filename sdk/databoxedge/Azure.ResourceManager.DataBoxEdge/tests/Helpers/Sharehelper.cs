// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DataBoxEdge.Models;

namespace Azure.ResourceManager.DataBoxEdge.Tests.Helpers
{
    public partial class TestUtilities
    {
        /// <summary>
        /// Gets an smb share object
        /// </summary>
        /// <param name="sacId"></param>
        /// <param name="userId"></param>
        /// <returns>Share</returns>
        public static DataBoxEdgeShareData GetSMBShareObject(ResourceIdentifier id)
        {
            ShareProperties properties = new ShareProperties(ShareStatus.Offline,DataBoxEdgeShareMonitoringStatus.Disabled,ShareAccessProtocol.Smb);
            properties.AzureContainerInfo = new DataBoxEdgeStorageContainerInfo(id, "testContainersmb", DataBoxEdgeStorageContainerDataFormat.BlockBlob);
            properties.UserAccessRights = new List<UserAccessRight>();
            properties.UserAccessRights.Add(new UserAccessRight(id, ShareAccessType.Change));
            DataBoxEdgeShareData share = new DataBoxEdgeShareData(properties);
            return share;
        }
    }
}
