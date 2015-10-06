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
namespace Microsoft.WindowsAzure.Management.HDInsight.TestUtilities.ServerDataObjects
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization;
    using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common.Models;
    using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models;
    using Microsoft.Hadoop.Client;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    public class JobPayloadServerConverter
    {
        public string SerializeJobList(JobList jobs)
        {
            var result = new PassthroughResponse();
            if (jobs.ErrorCode.IsNotNullOrEmpty() || jobs.HttpStatusCode != HttpStatusCode.Accepted)
            {
                result.Error = new PassthroughErrorResponse { StatusCode = jobs.HttpStatusCode, ErrorId = jobs.ErrorCode };
            }
            result.Data = jobs.Jobs.Select(j => j.JobId).ToList();
            return this.SerializeJobDetails(result);
        }

        public string SerializeJobCreationResults(JobCreationResults jobResults)
        {
            var result = new PassthroughResponse();
            if (jobResults.ErrorCode.IsNotNullOrEmpty() || jobResults.HttpStatusCode != HttpStatusCode.Accepted)
            {
                result.Error = new PassthroughErrorResponse { StatusCode = jobResults.HttpStatusCode, ErrorId = jobResults.ErrorCode };
            }
            result.Data = jobResults.JobId;
            return this.SerializeJobDetails(result);
        }

        private ClientJobRequest DeserializePayload(string payload)
        {
            ClientJobRequest request;
            var knowTypes = new Type[]
            {
                typeof(JobRequest), 
                typeof(HiveJobRequest), 
                typeof(MapReduceJobRequest)
            };
            DataContractSerializer ser = new DataContractSerializer(typeof(ClientJobRequest), knowTypes);
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(payload);
                writer.Flush();
                stream.Flush();
                stream.Position = 0;
                request = (ClientJobRequest)ser.ReadObject(stream);
            }
            return request;
        }

        private void SetStandardProperties(ClientJobRequest request, JobCreateParameters details)
        {
            foreach (var jobRequestParameter in request.Resources)
            {
                details.Files.Add(jobRequestParameter.Value.ToString());
            }
        }

        public HiveJobCreateParameters DeserializeHiveJobCreationDetails(string content)
        {
            var request = this.DeserializePayload(content);
            var result = new HiveJobCreateParameters()
            {
                JobName = request.JobName,
                StatusFolder = request.OutputStorageLocation,
                Query = request.Query
            };

            foreach (var jobRequestParameter in request.Parameters)
            {
                result.Defines.Add(jobRequestParameter.Key, jobRequestParameter.Value.ToString());
            }

            this.SetStandardProperties(request, result);
            return result;
        }

        public MapReduceJobCreateParameters DeserializeMapReduceJobCreationDetails(string content)
        {
            var request = this.DeserializePayload(content);
            var result = new MapReduceJobCreateParameters()
            {
                ClassName = request.ApplicationName,
                JarFile = request.JarFile,
                JobName = request.JobName,
                StatusFolder = request.OutputStorageLocation,
            };
            result.Arguments.AddRange(request.Arguments);

            foreach (var jobRequestParameter in request.Parameters)
            {
                result.Defines.Add(jobRequestParameter.Key, jobRequestParameter.Value.ToString());
            }

            this.SetStandardProperties(request, result);
            return result;
        }

        public string SerializeJobDetails(Hadoop.Client.JobDetails jobDetails)
        {
            var result = new PassthroughResponse();
            if (jobDetails.ErrorCode.IsNotNullOrEmpty() || jobDetails.HttpStatusCode != HttpStatusCode.Accepted)
            {
                result.Error = new PassthroughErrorResponse { StatusCode = jobDetails.HttpStatusCode, ErrorId = jobDetails.ErrorCode };
            }
            var details = new Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models.JobDetails()
            {
                ErrorOutputPath = jobDetails.ErrorOutputPath,
                ExitCode = jobDetails.ExitCode,
                LogicalOutputPath = jobDetails.LogicalOutputPath,
                Name = jobDetails.Name,
                PhysicalOutputPath = new Uri(jobDetails.PhysicalOutputPath),
                Query = jobDetails.Query,
                SubmissionTime = jobDetails.SubmissionTime.Ticks.ToString()
            };
            Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models.JobStatusCode statusCode;
            Assert.IsTrue(Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models.JobStatusCode.TryParse(jobDetails.StatusCode.ToString(), out statusCode));
            details.StatusCode = statusCode;
            result.Data = details;
            return this.SerializeJobDetails(result);
        }

        private string SerializeJobDetails(PassthroughResponse result)
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(PassthroughResponse));
            using (var stream = new MemoryStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    ser.WriteObject(stream, result);
                    stream.Flush();
                    stream.Position = 0;
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
