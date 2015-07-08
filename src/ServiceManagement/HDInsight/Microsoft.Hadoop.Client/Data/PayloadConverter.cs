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
namespace Microsoft.Hadoop.Client.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.Json;

    internal class PayloadConverter : PayloadConverterBase
    {
        private readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        private const string ExitValuePropertyName = "exitValue";
        private const string RunStatePropertyName = "runState";
        private const string PercentCompletePropertyName = "percentComplete";
        private const string StatusPropertyName = "status";
        private const string UserArgsPropertyName = "userargs";
        private const string StatusDirectoryPropertyName = "statusdir";
        private const string DefinesPropertyName = "define";
        private const string ArgumentsPropertyName = "arg";
        private const string StartTimePropertyName = "startTime";
        private const string JobNameKey = "hdInsightJobName=";
        private const string DetailPropertyName = "detail";
        private const string ExecutePropertyName = "execute";
        private const string CommandPropertyName = "command";
        private const string UnknownJobId = "unknown";
        private const string ParentId = "parentId";
        private const string JobId = "id";
        private const string ErrorString = "error";
        private const string Callback = "callback";

        internal string DeserializeJobSubmissionResponse(string payload)
        {
            var ret = UnknownJobId;
            using (var parser = new JsonParser(payload))
            {
                var respObj = parser.ParseNext();
                if (respObj == null || respObj.IsError || respObj.IsNullOrMissing || !respObj.IsObject)
                {
                    throw new SerializationException(respObj.ToString());
                }

                var jobId = this.GetJsonPropertyStringValue(respObj, JobId);
                if (string.IsNullOrEmpty(jobId))
                {
                    var errorString = this.GetJsonPropertyStringValue(respObj, ErrorString);
                    if (!string.IsNullOrEmpty(errorString))
                    {
                        throw new InvalidOperationException(errorString);
                    }
                    throw new InvalidOperationException();
                }
                ret = jobId;
            }
            return ret;
        }

        internal JobList DeserializeListJobResult(string payload)
        {
            var ret = new JobList();
            var list = new List<JobDetails>();
            using (var parser = new JsonParser(payload))
            {
                var jobList = parser.ParseNext();
                if (jobList == null || !jobList.IsValidArray())
                {
                    throw new InvalidOperationException();
                }

                if (jobList.IsEmpty)
                {
                    return ret;
                }

                for (var i = 0; i < jobList.Count(); i++)
                {
                    var job = jobList.GetIndex(i);

                    if (job == null || !job.IsValidObject())
                    {
                        continue;
                    }
                    var detailProp = job.GetProperty(DetailPropertyName);
                    if (detailProp != null && detailProp.IsValidObject())
                    {
                        try
                        {
                            var jobDetails = this.DeserializeJobDetails((JsonObject)detailProp);
                            jobDetails.SubmissionTime = jobDetails.SubmissionTime.ToLocalTime();

                            if (jobDetails != null)
                            {
                                list.Add(jobDetails);
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            //Eat it.
                        }
                    }
                }
            }
            ret.Jobs.AddRange((from j in list orderby j.SubmissionTime.ToUniversalTime() select j));
            return ret;
        }

        internal JobDetails DeserializeJobDetails(string payload)
        {
            using (var parser = new JsonParser(payload))
            {
                var job = parser.ParseNext();

                if (!job.IsValidObject())
                {
                    throw new InvalidOperationException();
                }
                return this.DeserializeJobDetails((JsonObject)job);
            }
        }

        private JobDetails DeserializeJobDetails(JsonObject job)
        {
            if (job == null || job.IsError || job.IsNullMissingOrEmpty)
            {
                throw new InvalidOperationException();
            }

            var jobId = string.Empty;
            if (!this.GetJobId(job, out jobId))
            {
                var errorString = this.GetJsonPropertyStringValue(job, ErrorString);
                if (!string.IsNullOrEmpty(errorString))
                {
                    return null;
                }

                throw new InvalidOperationException();
            }

            var ret = new JobDetails()
            {
                JobId = jobId
            };

            //NEIN: this is downcasting a long to an int.... which is ok for an exit code, but we should add a way to parse ints to the json lib
            ret.ExitCode = (int?)this.GetJsonPropertyNullableLongValue(job, ExitValuePropertyName);

            var status = this.GetJsonObject(job, StatusPropertyName);
            if (status != null)
            {
                var startTime = this.GetJsonPropertyLongValue(status, StartTimePropertyName);
                if (startTime != default(long))
                {
                    ret.SubmissionTime = this.unixEpoch.AddMilliseconds(startTime);
                }

                ret.StatusCode = this.GetJobStatusCodeValue(status, RunStatePropertyName);
            }

            var userArgs = this.GetJsonObject(job, UserArgsPropertyName);
            if (userArgs != null)
            {
                ret.StatusDirectory = this.GetJsonPropertyStringValue(userArgs, StatusDirectoryPropertyName);
                ret.Query = this.GetJsonPropertyStringValue(userArgs, ExecutePropertyName);
                if (ret.Query.IsNullOrEmpty())
                {
                    ret.Query = this.GetJsonPropertyStringValue(userArgs, CommandPropertyName);
                }

                var defines = this.GetJsonArray(userArgs, DefinesPropertyName);
                var arguments = this.GetJsonArray(userArgs, ArgumentsPropertyName);

                string jobName = string.Empty;
                if ((defines.IsNull() || !this.TryGetJobNameFromJsonArray(defines, out jobName)) && arguments.IsNotNull())
                {
                    this.TryGetJobNameFromJsonArray(arguments, out jobName);
                }

                ret.Name = jobName;
            }

            ret.PercentComplete = this.GetJsonPropertyStringValue(job, PercentCompletePropertyName);
            ret.Callback = this.GetJsonPropertyStringValue(job, Callback);

            return ret;
        }

        private bool GetJobId(JsonItem details, out string jobId)
        {
            var jobIdJson = details.GetProperty(JobId);
            if (jobIdJson == null || jobIdJson.IsNullOrMissing || jobIdJson.IsError)
            {
                var id = details.GetProperty(ParentId);
                return id.TryGetValue(out jobId);
            }
            return jobIdJson.TryGetValue(out jobId);
        }

        private bool TryGetJobNameFromJsonArray(IEnumerable<string> jsonArray, out string jobName)
        {
            jobName = string.Empty;
            var jobNameItem = jsonArray.FirstOrDefault(s => s.Contains(JobNameKey));
            if (jobNameItem != null)
            {
                var jobNameString = jobNameItem;
                var indexOfNameAssigment = jobNameString.IndexOf('=');
                if (indexOfNameAssigment > -1 && jobNameString.Length > (indexOfNameAssigment + 1))
                {
                    jobName = jobNameString.Substring(indexOfNameAssigment + 1);
                }
            }

            return jobName.IsNotNullOrEmpty();
        }

        private long GetJsonPropertyLongValue(JsonItem item, string property)
        {
            long value;
            var prop = item.GetProperty(property);
            prop.TryGetValue(out value);
            return value;
        }

        private long? GetJsonPropertyNullableLongValue(JsonItem item, string property)
        {
            long value;
            var prop = item.GetProperty(property);
            if (prop.TryGetValue(out value))
            {
                return value;
            }

            return null;
        }

        private JobStatusCode GetJobStatusCodeValue(JsonItem item, string property)
        {
            var jobStatus = JobStatusCode.Unknown;
            var value = string.Empty;
            var prop = item.GetProperty(property);
            prop.TryGetValue(out value);
            if (value.IsNotNullOrEmpty())
            {
                if (!Enum.TryParse(value, true, out jobStatus))
                {
                    jobStatus = JobStatusCode.Unknown;
                }
            }

            return jobStatus;
        }

        private string GetJsonPropertyStringValue(JsonItem item, string property)
        {
            var value = string.Empty;
            var prop = item.GetProperty(property);
            prop.TryGetValue(out value);
            return value;
        }

        private string GetJsonStringValue(JsonItem item)
        {
            var value = string.Empty;
            item.TryGetValue(out value);
            return value;
        }

        private JsonObject GetJsonObject(JsonItem item, string property)
        {
            var prop = item.GetProperty(property);
            if (prop == null || !prop.IsValidObject())
            {
                return null;
            }
            return (JsonObject)prop;
        }

        private IEnumerable<string> GetJsonArray(JsonItem item, string property)
        {
            var prop = item.GetProperty(property);
            if (prop == null || !prop.IsValidArray())
            {
                return null;
            }

            var ret = new List<string>();
            var array = (JsonArray)prop;
            for (var i = 0; i < array.Count(); i++)
            {
                var value = this.GetJsonStringValue(array.GetIndex(i));
                if (!string.IsNullOrEmpty(value))
                {
                    ret.Add(value);
                }
            }
            return ret;
        }
    }

}
