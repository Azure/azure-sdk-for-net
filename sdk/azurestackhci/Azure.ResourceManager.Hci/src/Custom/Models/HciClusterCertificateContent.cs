// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    public partial class HciClusterCertificateContent
    {
        /// <summary> Cluster certificates. </summary>
        // The new generator flatten this property name as RawCertificateDataCertificates
        [CodeGenMember("RawCertificateDataCertificates")]
        [WirePath("rawCertificateData.certificates")]
        public IList<string> Certificates
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RawCertificateData();
                }
                return Properties.Certificates;
            }
        }
    }
}
