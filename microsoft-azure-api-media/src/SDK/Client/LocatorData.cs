// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Data.Services.Client;
using System.Data.Services.Common;
using System.Linq;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    [DataServiceKey("Id")]
    partial class LocatorData : ILocator, ICloudMediaContextInit
    {
        private CloudMediaContext _cloudMediaContext;
        private AccessPolicyData _accessPolicy;
        private AssetData _asset;

        public LocatorData()
        {
        }

        public LocatorData(CloudMediaContext cloudMediaContext)
        {
            if (cloudMediaContext == null)
            {
                throw new ArgumentNullException("cloudMediaContext");
            }

            _cloudMediaContext = cloudMediaContext;
        }

        void ICloudMediaContextInit.InitCloudMediaContext(CloudMediaContext context)
        {
            _cloudMediaContext = context;
        }

        public AccessPolicyData AccessPolicy { get { return _accessPolicy; } set { _accessPolicy = value; } }
        public AssetData Asset { get { return _asset; } set { _asset = value; } }

        IAccessPolicy ILocator.AccessPolicy
        {
            get
            {
                if (_accessPolicy == null && _cloudMediaContext != null)
                {
                    EntityDescriptor entityDescriptor = _cloudMediaContext.DataContext.GetEntityDescriptor(this);
                    if (entityDescriptor != null && (entityDescriptor.State == EntityStates.Unchanged || entityDescriptor.State == EntityStates.Modified))
                    {
                        _cloudMediaContext.DataContext.LoadProperty(this, "AccessPolicy");
                    }
                }
                return _accessPolicy;
            }
        }

        IAsset ILocator.Asset
        {
            get
            {
                if (_asset == null && _cloudMediaContext != null)
                {
                    EntityDescriptor entityDescriptor = _cloudMediaContext.DataContext.GetEntityDescriptor(this);
                    if (entityDescriptor != null && (entityDescriptor.State == EntityStates.Unchanged || entityDescriptor.State == EntityStates.Modified))
                    {
                        _cloudMediaContext.DataContext.LoadProperty(this, "Asset");
                    }
                }
                return _asset;
            }
        }

        private static LocatorType GetExposedType(int type)
        {
            return (LocatorType)type;
        }
    }
}
