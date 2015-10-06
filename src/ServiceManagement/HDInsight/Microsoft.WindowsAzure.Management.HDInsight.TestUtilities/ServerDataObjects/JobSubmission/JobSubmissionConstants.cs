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
namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission
{
    using Microsoft.Hadoop.Client;

    public static class JobSubmissionConstants
    {
        //Misc jobDetails related constants
        public const string ResourceExtentionName = "jobs";
        public const string JobIdPropertyName = "id";
        public const string DefaultJobsContainer = "hdinsightjobhistory";
        public const string SasPolicyName = "HdInsightJobHistoryReadOnlyPolicy";
        public const string WasbFormatString = Constants.WabsProtocolSchemeName + "{0}@{1}/{2}";
        public const string JobNameDefine = "hdInsightJobName";

        //ErrorId
        public const string InvalidJobSumbmissionRequestErrorId = "INVALID_JOBREQUEST";
        public const string ClusterUnavailableErrorId = "CLUSTER_UNAVAILABLE";
        public const string JobSubmissionFailedErrorId = "JOB_SUBMISSION_FAILED";

        //Log Messages
        public const string JobSubmissionFailedLogMessage = "jobDetails submission failed for cluster: '{0}' ErrorId: '{1}'";
        public const string ClusterRequestErrorLogMessage = "An error was returned from the cluster/container while submitting a jobDetails request. Cluster: '{0}' HttpStatusCode: '{1}' ReasonPhrase: '{2}'";
        public const string UnkownJobSubmissionErrorLogMessage = "jobDetails submission failed for an unknown reason. Cluster: '{0}' Details: '{1}'";

        public const string InvalidJobRequestLogMessage = "An invalid jobDetails request was submitted. Details: {0}";
        public const string InvalidJobHistoryRequestLogMessage = "An invalid jobDetails history request was submitted. RequestUri: {0}";
        public const string PassThroughActionCreationFailedLogMessage = "An action could not be created for the given request. ResourceExtension: '{0}' HttpMethod: '{1}'";
        public const string ContentReadFailureLogMessage = "Failed to read the content of a request. RequestUri: '{0}' HttpMethod: '{1}' Details: '{2}'";
        public const string BypassServerCertValidationLogMessage = "No validating server certificates for cluster: '{0}'";

        public const string JobRequestActionNotFound = "A passthrough action could not be created for the given jobDetails request. ResourceName: '{0}' Request: '{1}'";
        public const string JobHistoryRequestActionNotFound = "A passthrough action could not be created for the given jobDetails history request. ResourceName: '{0}' RequestUri: '{1}'";
        public const string UnableToParseJobDetailsLogMessage = "Unable to parse jobDetails details from the server response. ErrorMessage: '{0}' Server Response: '{1}'";

        public const string FailedToCreateOutputContainer = "Could not create jobDetails History Container. AsvAccountName: '{0}' ContainerName: '{1}' Details: '{2}'";

    }
}