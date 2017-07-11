// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation of SecurityGroupView.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uU2VjdXJpdHlHcm91cFZpZXdJbXBs
    internal partial class SecurityGroupViewImpl  :
        IndexableRefreshableWrapper<ISecurityGroupView, SecurityGroupViewResultInner>,
        ISecurityGroupView
    {
        private Dictionary<string,Models.SecurityGroupNetworkInterface> networkInterfaces;
        private NetworkWatcherImpl parent;
        private string vmId;
        ///GENMHASH:D1BD3457E045FEE686C86F1C26552B9C:B92E1D4D4C3695DC7B968B13FC624251
        internal  SecurityGroupViewImpl(NetworkWatcherImpl parent, SecurityGroupViewResultInner innerObject, string vmId)
            : base(vmId, innerObject)
        {
            this.parent = parent;
            this.vmId = vmId;
            //$ initializeFromInner();
            //$ }

        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public INetworkWatcher Parent()
        {
            return parent;
        }

        ///GENMHASH:D8C26169BA1ED47B274A3F5C3A6AEB4D:BC9BE47CF9ABFA874A532AB6B9ABB4CB
        public IReadOnlyDictionary<string,Models.SecurityGroupNetworkInterface> NetworkInterfaces()
        {
            //$ return Collections.UnmodifiableMap(this.networkInterfaces);

            return null;
        }

        ///GENMHASH:F91DF44F14D53833479DE592AB2B2890:4D7A48FC8E563CCD5ADFF99417BEF439
        public string VMId()
        {
            return vmId;
        }

        ///GENMHASH:5A2D79502EDA81E37A36694062AEDC65:574C8EAB1E1A7D0C399D331F9DB49796
        public async Task<Microsoft.Azure.Management.Network.Fluent.ISecurityGroupView> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return super.RefreshAsync().Map(new Func1<SecurityGroupView, SecurityGroupView>() {
            //$ @Override
            //$ public SecurityGroupView call(SecurityGroupView securityGroupView) {
            //$ SecurityGroupViewImpl impl = (SecurityGroupViewImpl) securityGroupView;
            //$ impl.InitializeFromInner();
            //$ return impl;
            //$ }
            //$ });

            return null;
        }

        ///GENMHASH:01F524DA5AA652262BA1AF0E9631A47C:2A9D85FE8DCC85D018523FEA761BEE74
        private void InitializeFromInner()
        {
            //$ this.networkInterfaces = new TreeMap<>();
            //$ List<SecurityGroupNetworkInterface> securityGroupNetworkInterfaces = this.Inner.NetworkInterfaces();
            //$ if (securityGroupNetworkInterfaces != null) {
            //$ foreach(var networkInterface in securityGroupNetworkInterfaces) {
            //$ this.networkInterfaces.Put(networkInterface.Id(), networkInterface);
            //$ }
            //$ }
            //$ }

        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:29FDDD910D0A86955AD7149F68B5DD60
        protected override async Task<Models.SecurityGroupViewResultInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //$ return this.parent().Manager().Inner.NetworkWatchers()
            //$ .GetVMSecurityRulesAsync(parent.ResourceGroupName(), parent.Name(), vmId);

            return null;
        }
    }
}