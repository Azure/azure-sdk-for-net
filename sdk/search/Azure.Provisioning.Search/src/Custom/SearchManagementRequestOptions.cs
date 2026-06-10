// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.Search
{
    /// <summary> Request options for Search management operations. </summary>
    public partial class SearchManagementRequestOptions : ProvisionableConstruct
    {
        private BicepValue<System.Guid> _clientRequestId;

        /// <summary> Creates a new SearchManagementRequestOptions. </summary>
        public SearchManagementRequestOptions()
        {
        }

        /// <summary> Gets or sets the client request id. </summary>
        public BicepValue<System.Guid> ClientRequestId
        {
            get { Initialize(); return _clientRequestId; }
            set { Initialize(); _clientRequestId.Assign(value); }
        }

        /// <inheritdoc/>
        protected override void DefineProvisionableProperties()
        {
            base.DefineProvisionableProperties();
            _clientRequestId = DefineProperty<System.Guid>(nameof(ClientRequestId), new string[] { "clientRequestId" });
        }
    }
}
