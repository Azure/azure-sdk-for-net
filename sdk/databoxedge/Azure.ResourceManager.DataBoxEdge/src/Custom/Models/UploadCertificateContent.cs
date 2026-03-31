// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Why: Generated AuthenticationType property is getter-only, but baseline API had a setter.
// This Custom/ property shadows the generated one to add a setter for backward compatibility.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public partial class UploadCertificateContent
    {
        /// <summary> The authentication type. </summary>
        public DataBoxEdgeAuthenticationType? AuthenticationType
        {
            get => Properties.AuthenticationType;
            set => Properties.AuthenticationType = value;
        }
    }
}
