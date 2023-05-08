// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.DataBox.Models
{
    public partial class MitigateJobContent
    {
        /// <summary> Initializes a new instance of MitigateJobContent. </summary>
        /// <param name="customerResolutionCode"> Resolution code for the job. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MitigateJobContent(CustomerResolutionCode customerResolutionCode)
        {
            CustomerResolutionCode = customerResolutionCode;
        }
    }
}
