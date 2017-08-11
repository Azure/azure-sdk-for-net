// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.FlowLogSettings.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;

    /// <summary>
    /// Implementation for  FlowLogSettings and its create and update interfaces.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uRmxvd0xvZ1NldHRpbmdzSW1wbA==
    internal partial class FlowLogSettingsImpl :
        IndexableRefreshableWrapper<Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings,
            Models.FlowLogInformationInner>,
        IFlowLogSettings,
        IUpdate
    {
        private NetworkWatcherImpl parent;
        private string nsgId;

        
        ///GENMHASH:2A2EBEB6F72F109F77161BBA48F6F051:5A0D8BEF8119FEF38FD59B1B9113F631
        public IUpdate WithRetentionPolicyDisabled()
        {
            EnsureRetentionPolicy();
            Inner.RetentionPolicy.Enabled = false;
            return this;
        }

        
        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public NetworkWatcherImpl Parent()
        {
            return parent;
        }

        
        ///GENMHASH:93F5525F475C77754B229151C3005F4B:660F3C397772C20E7F05BE32F86BCF53
        public async Task<Microsoft.Azure.Management.Network.Fluent.IFlowLogSettings> ApplyAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var response =
                await parent.Manager.Inner.NetworkWatchers.SetFlowLogConfigurationAsync(parent.ResourceGroupName,
                    parent.Name, Inner);
            SetInner(response);
            return this;
        }

        
        ///GENMHASH:9AAC47DA169F42F8CA46D0FE0B02F7F6:9AAD7FAF579052B374A9FC19AF26F830
        internal FlowLogSettingsImpl(NetworkWatcherImpl parent, FlowLogInformationInner inner, string nsgId)
            : base(inner.TargetResourceId, inner)
        {
            this.parent = parent;
            this.nsgId = nsgId;
        }

        
        ///GENMHASH:34214CDA694B09312AB4062B1B86A083:78BC1A0C35B3DBA398DA69B055831420
        public IUpdate WithStorageAccount(string storageId)
        {
            Inner.StorageId = storageId;
            return this;
        }

        
        ///GENMHASH:7A26D184347EA91F532899FC93DA3E8B:8456BBCBBB11CEBC17C9ECE561F7920E
        public IFlowLogSettings Apply()
        {
            return Extensions.Synchronize(() => ApplyAsync(CancellationToken.None));
        }

        
        ///GENMHASH:4A094106DADD6C15CD0CE10301E60136:8076B63FCD1974CC6F6FC168E61D2AE1
        public bool IsRetentionEnabled()
        {
            // will return default values if server response for retention policy was empty
            EnsureRetentionPolicy();
            if (Inner.RetentionPolicy.Enabled == null)
            {
                return false;
            }
            return Inner.RetentionPolicy.Enabled.Value;
        }

        
        ///GENMHASH:6BCE517E09457FF033728269C8936E64:40A980295F5EA8FF8304DA8C06E899BF
        public IUpdate Update()
        {
            return this;
        }

        
        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:7CC0D32AF84BB88BD5A25CDA32AF494D
        protected override async Task<Models.FlowLogInformationInner> GetInnerAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await parent.Manager.Inner.NetworkWatchers
                .GetFlowLogStatusAsync(parent.ResourceGroupName, parent.Name, Inner.TargetResourceId);
        }

        
        ///GENMHASH:1703877FCECC33D73EA04EEEF89045EF:6B299A044CA354BDC95361765063D1CA
        public bool Enabled()
        {
            return Inner.Enabled;
        }

        
        ///GENMHASH:CBBDB8F088AF6BA0FB509AD8B40CFBD7:D02493859278C3FFE53D554079C7E81E
        public IUpdate WithRetentionPolicyEnabled()
        {
            EnsureRetentionPolicy();
            Inner.RetentionPolicy.Enabled = true;
            return this;
        }

        
        ///GENMHASH:54FF9EAE063A707BF467152E850B0B04:A01C5FFE224D1492FE3A3B71BFD3B1A1
        internal string TargetResourceId()
        {
            return Inner.TargetResourceId;
        }

        
        ///GENMHASH:C9DAE3BAB95892E4FF99FE95FA410262:B605F0C6D20484DEA14055C58519B8C8
        public IUpdate WithLogging()
        {
            Inner.Enabled = true;
            return this;
        }

        
        ///GENMHASH:7E6E33D4F5F7BD1DEF53283532842A03:9A4882A827B87B926799484B506DA9A3
        public IUpdate WithoutLogging()
        {
            Inner.Enabled = false;
            return this;
        }

        
        ///GENMHASH:A76077A28BA478BBD88C0C45A7F96B0D:7285F1F962D2BD01A4073680C57C8E6F
        public IUpdate WithRetentionPolicyDays(int days)
        {
            EnsureRetentionPolicy();
            Inner.RetentionPolicy.Days = days;
            return this;
        }

        
        ///GENMHASH:07AF9F940CE3DFB3A10677B53AE6C972:29BF476B4ABD5B204DDCAC78D6FFA361
        public int RetentionDays()
        {
            // will return default values if server response for retention policy was empty
            EnsureRetentionPolicy();
            if (Inner.RetentionPolicy.Days == null)
            {
                return 0;
            }
            return (int) Inner.RetentionPolicy.Days;
        }

        
        ///GENMHASH:5F4A13752CB382E12751790C70C8D4B9:6EBBA9524915E935FDF1EB090D05F567
        private void EnsureRetentionPolicy()
        {
            if (Inner.RetentionPolicy == null)
            {
                Inner.RetentionPolicy = new RetentionPolicyParameters();
            }
        }
        
        ///GENMHASH:3199B79470C9D13993D729B188E94A46:9790D012FA64E47343F12DB13F0AA212
        public string Key()
        {
            return null;
        }

        
        ///GENMHASH:A9777D8010E6AF7B603113E49858FE75:13F9A734647D69D812FAF407A9786D1C
        public string NetworkSecurityGroupId()
        {
            return nsgId;
        }

        
        ///GENMHASH:377F5AE3B24673ACE3FC01FC20F6ABBD:55F63929DF4309D7FA8D93D145C9FEDD
        public string StorageId()
        {
            return Inner.StorageId;
        }
    }
}
