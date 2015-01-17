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
namespace Microsoft.Hadoop.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.Serialization;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Formatters;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers;

    [HttpRestDefinition]
    [JsonRequestFormatter, JsonResponseFormatter]
    internal interface IHadoopApplicationHistoryRestReadClient
    {
        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK })]
        [HttpRestInvoke("GET", "ws/v1/applicationhistory/apps?submittedTimeBegin={submittedTimeBegin}&submittedTimeEnd={submittedTimeEnd}")]
        Task<ApplicationListResult> ListCompletedApplicationsAsync(string submittedTimeBegin, string submittedTimeEnd);

        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK })]
        [HttpRestInvoke("GET", "ws/v1/applicationhistory/apps/{applicationId}/")]
        Task<ApplicationGetResult> GetApplicationDetailsAsync(string applicationId);

        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK })]
        [HttpRestInvoke("GET", "ws/v1/applicationhistory/apps/{applicationId}/appattempts/")]
        Task<ApplicationAttemptListResult> ListApplicationAttemptsAsync(string applicationId);

        [ExpectedStatusCodeValidator(new[] { HttpStatusCode.OK })]
        [HttpRestInvoke("GET", "ws/v1/applicationhistory/apps/{applicationId}/appattempts/{applicationAttemptId}/containers/")]
        Task<ApplicationContainerListResult> ListApplicationContainersAsync(string applicationId, string applicationAttemptId);
    }
}
