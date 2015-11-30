// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.PocoClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Hadoop.Client;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.WebRequest;

    /// <summary>
    /// Provides helper functions to the Poco layer.
    /// </summary>
    internal class HDInsightManagementPocoHelper
    {
        /// <summary>
        /// Validates that a response is valid.  This method throws an exception if there
        /// was an error in the response payload.
        /// </summary>
        /// <typeparam name="T">
        /// The type name of the payload response.
        /// </typeparam>
        /// <param name="response">
        /// The response object.
        /// </param>
        public void ValidateResponse<T>(PayloadResponse<T> response)
        {
            response.ArgumentNotNull("response");
            if (response.ErrorDetails.IsNotNull())
            {
                throw new HttpLayerException(response.ErrorDetails.StatusCode, response.ErrorDetails.ErrorMessage);
            }
        }

    }
}
