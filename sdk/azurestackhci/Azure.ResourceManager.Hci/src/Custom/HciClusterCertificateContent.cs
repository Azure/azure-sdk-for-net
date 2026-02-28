// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class HciClusterCertificateContent
    {
        /// <summary> Cluster certificates. </summary>
        [WirePath("rawCertificateData.certificates")]
        public IList<string> Certificates => RawCertificateDataCertificates;
    }
}
