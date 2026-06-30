// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

#nullable disable

namespace Azure.Provisioning.Search
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsoleted and will be removed in a future versions, please use search service resource properties instead.")]
    public partial class SearchManagementRequestOptions : ProvisionableConstruct
    {
        private BicepValue<Guid> _clientRequestId;

        public SearchManagementRequestOptions()
        {
        }

        public BicepValue<Guid> ClientRequestId
        {
            get { Initialize(); return _clientRequestId; }
            set { Initialize(); _clientRequestId.Assign(value); }
        }

        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _clientRequestId = DefineProperty<Guid>(nameof(ClientRequestId), new string[] { "x-ms-client-request-id" });
        }
    }
}
