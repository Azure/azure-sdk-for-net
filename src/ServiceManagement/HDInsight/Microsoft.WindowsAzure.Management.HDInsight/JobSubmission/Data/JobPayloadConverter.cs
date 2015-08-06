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
namespace Microsoft.WindowsAzure.Management.HDInsight.JobSubmission.Data
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using Microsoft.Hadoop.Client;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Reader;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library.DynamicXml.Writer;

    /// <summary>
    /// Converts jobDetails payloads to and from objects as needed by the SDK.
    /// </summary>
    internal class JobPayloadConverter
    {
        /// <summary>
        /// Deserializes a jobDetails creation result object from a payload string.
        /// </summary>
        /// <param name="payload">
        /// The payload.
        /// </param>
        /// <returns>
        /// A JobCreationResults object representing the payload.
        /// </returns>
        public JobCreationResults DeserializeJobCreationResults(string payload)
        {
            JobCreationResults results = new JobCreationResults();
            results.ErrorCode = string.Empty;
            results.HttpStatusCode = HttpStatusCode.Accepted;
            XmlDocumentConverter documentConverter = new XmlDocumentConverter();
            var document = documentConverter.GetXmlDocument(payload);
            DynaXmlNamespaceTable nameTable = new DynaXmlNamespaceTable(document);
            var node = document.SelectSingleNode("//def:PassthroughResponse/def:Data", nameTable.NamespaceManager);
            results.JobId = node.InnerText;
            XmlElement error = (XmlElement)document.SelectSingleNode("//def:PassthroughResponse/def:Error", nameTable.NamespaceManager);
            if (error.IsNotNull())
            {
                var errorId = error.SelectSingleNode("//def:ErrorId", nameTable.NamespaceManager);
                if (errorId.IsNotNull())
                {
                    results.ErrorCode = errorId.InnerText;
                }
                var statusCode = error.SelectSingleNode("//def:StatusCode", nameTable.NamespaceManager);
                if (statusCode.IsNotNull())
                {
                    HttpStatusCode httpStatusCode = HttpStatusCode.Accepted;
                    if (HttpStatusCode.TryParse(statusCode.InnerText, out httpStatusCode))
                    {
                        results.HttpStatusCode = httpStatusCode;
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Deserailzies a payload into a JobList.
        /// </summary>
        /// <param name="payload">
        /// The payload.
        /// </param>
        /// <returns>
        /// An JobList representing the payload.
        /// </returns>
        public JobList DeserializeJobList(string payload)
        {
            var jobs = new List<JobDetails>();
            JobList results = new JobList();
            XmlDocumentConverter documentConverter = new XmlDocumentConverter();
            var document = documentConverter.GetXmlDocument(payload);
            DynaXmlNamespaceTable nameTable = new DynaXmlNamespaceTable(document);
            var prefix = nameTable.GetPrefixesForNamespace("http://schemas.microsoft.com/2003/10/Serialization/Arrays").SingleOrDefault();
            if (prefix.IsNotNull())
            {
                var query = string.Format(CultureInfo.InvariantCulture, "//def:PassthroughResponse/def:Data/{0}:string", prefix);
                var nodes = document.SelectNodes(query, nameTable.NamespaceManager);
                foreach (XmlNode node in nodes)
                {
                    jobs.Add(new JobDetails() { JobId = node.InnerText });
                }
            }
            results.ErrorCode = string.Empty;
            results.HttpStatusCode = HttpStatusCode.Accepted;
            XmlElement error = (XmlElement)document.SelectSingleNode("//def:PassthroughResponse/def:Error", nameTable.NamespaceManager);
            if (error.IsNotNull())
            {
                var errorId = error.SelectSingleNode("//def:ErrorId", nameTable.NamespaceManager);
                if (errorId.IsNotNull())
                {
                    results.ErrorCode = errorId.InnerText;
                }
                var statusCode = error.SelectSingleNode("//def:StatusCode", nameTable.NamespaceManager);
                if (statusCode.IsNotNull())
                {
                    HttpStatusCode httpStatusCode = HttpStatusCode.Accepted;
                    if (HttpStatusCode.TryParse(statusCode.InnerText, out httpStatusCode))
                    {
                        results.HttpStatusCode = httpStatusCode;
                    }
                }
            }
            results.Jobs.AddRange(jobs);
            return results;
        }

        /// <summary>
        /// Serializes a jobDetails creation object into a payload that can be sent to the server by a rest client.
        /// </summary>
        /// <param name="job">
        /// The jobDetails creation details to send to the server.
        /// </param>
        /// <returns>
        /// A string that represents the payload.
        /// </returns>
        [SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode",
            Justification = "This is a result of dynaXml and interface flowing, which makes the code easer to maintain not harder. [tgs]")]
        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity",
            Justification = "This is a result of dynaXml and interface flowing, which makes the code easer to maintain not harder. [tgs]")]
        public string SerializeJobCreationDetails(JobCreateParameters job)
        {
            if (job.IsNull())
            {
                throw new ArgumentNullException("job");
            }

            if (job.StatusFolder.IsNullOrEmpty())
            {
                job.StatusFolder = "(ignore)";
            }
            var asHiveJob = job as HiveJobCreateParameters;
            var asMapReduceJob = job as MapReduceJobCreateParameters;
            var jobType = asHiveJob.IsNotNull() ? "Hive" : "MapReduce";

            if (asHiveJob.IsNull() && asMapReduceJob.IsNull())
            {
                throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "Unsupported job type :{0}", job.GetType().FullName));
            }

            var jobName = asHiveJob == null ? asMapReduceJob.JobName : asHiveJob.JobName;
            if (jobName.IsNullOrEmpty())
            {
                throw new ArgumentException("A jobDetails name is required when submitting a jobDetails.", "job");
            }

            dynamic dynaXml = DynaXmlBuilder.Create();
            dynaXml.b
                     .xmlns("http://schemas.datacontract.org/2004/07/Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models")
                     .xmlns.i("http://www.w3.org/2001/XMLSchema-instance")
                     .xmlns.a("http://schemas.microsoft.com/2003/10/Serialization/Arrays")
                     .xmlns.s("http://www.w3.org/2001/XMLSchema")
                     .ClientJobRequest
                     .b
                     .End();

            if (asMapReduceJob.IsNotNull() && asMapReduceJob.ClassName.IsNotNullOrEmpty())
            {
                dynaXml.ApplicationName(asMapReduceJob.ClassName);
            }
            else
            {
                dynaXml.ApplicationName.End();
            }

            dynaXml.Arguments
                   .b
                     .sp("arguments")
                   .d
                   .End();

            if (asMapReduceJob.IsNotNull() && asMapReduceJob.JarFile.IsNotNullOrEmpty())
            {
                dynaXml.JarFile(asMapReduceJob.JarFile);
            }
            else
            {
                dynaXml.JarFile.End();
            }

            dynaXml.JobName(jobName)
                   .JobType(jobType.ToString())
                   .OutputStorageLocation(job.StatusFolder)
                   .Parameters
                   .b
                     .sp("parameters")
                   .d
                   .Query
                   .b
                     .sp("query")
                   .d
                   .Resources
                   .b
                     .sp("resources")
                   .d
                   .End();

            dynaXml.d.d.End();

            if (asHiveJob.IsNotNull() && asHiveJob.Query.IsNotNull())
            {
                dynaXml.rp("query")
                       .text(asHiveJob.Query);

                if (asHiveJob.Defines.IsNotNull())
                {
                    foreach (var parameter in asHiveJob.Defines)
                    {
                        dynaXml.rp("parameters")
                               .JobRequestParameter
                               .b
                                 .Key(parameter.Key)
                                 .Value
                                 .b
                                   .at.xmlns.i.type("s:string")
                                   .text(parameter.Value)
                                 .d
                               .d
                               .End();
                    }
                }
            }
            if (asMapReduceJob.IsNotNull() && asMapReduceJob.Arguments.IsNotNull())
            {
                foreach (var argument in asMapReduceJob.Arguments)
                {
                    dynaXml.rp("arguments").xmlns.a.@string(argument);
                }

                if (asMapReduceJob.Defines.IsNotNull())
                {
                    foreach (var parameter in asMapReduceJob.Defines)
                    {
                        dynaXml.rp("parameters")
                               .JobRequestParameter
                               .b
                                 .Key(parameter.Key)
                                 .Value
                                 .b
                                   .at.xmlns.i.type("s:string")
                                   .text(parameter.Value)
                                 .d
                               .d
                               .End();
                    }
                }
            }

            if (job.Files.IsNotNull())
            {
                foreach (var resource in job.Files)
                {
                    dynaXml.rp("resources")
                           .JobRequestParameter
                           .b
                             .Key(resource)
                             .Value
                             .b
                               .at.xmlns.i.type("s:string")
                               .text(resource)
                             .d
                           .d
                           .End();
                }
            }
            return dynaXml.ToString();
        }

        /// <summary>
        /// Desterilizes the jobDetails details payload data.
        /// </summary>
        /// <param name="payload">
        /// The payload data returned from a server.
        /// </param>
        /// <param name="jobId">
        /// The jobId for the jobDetails requested.
        /// </param>
        /// <returns>
        /// A new JobDetails object representing the jobDetails.
        /// </returns>
        public JobDetails DeserializeJobDetails(string payload, string jobId)
        {
            JobDetails retval = new JobDetails();
            XmlDocumentConverter documentConverter = new XmlDocumentConverter();
            var document = documentConverter.GetXmlDocument(payload);
            DynaXmlNamespaceTable nameTable = new DynaXmlNamespaceTable(document);
            var query = "//def:PassthroughResponse/def:Data";
            var node = document.SelectSingleNode(query, nameTable.NamespaceManager);
            if (node.IsNotNull())
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    XmlElement element = child as XmlElement;
                    if (element.IsNotNull())
                    {
                        switch (element.LocalName)
                        {
                            case "ErrorOutputPath":
                                retval.ErrorOutputPath = element.InnerText;
                                break;
                            case "ExitCode":
                                var errorCode = element.InnerText;
                                if (errorCode.IsNotNullOrEmpty())
                                {
                                    int outCode;
                                    if (int.TryParse(errorCode, NumberStyles.Integer, CultureInfo.InvariantCulture, out outCode))
                                    {
                                        retval.ExitCode = outCode;
                                    }
                                }
                                break;
                            case "LogicalOutputPath":
                                retval.LogicalOutputPath = element.InnerText;
                                break;
                            case "Name":
                                retval.Name = element.InnerText;
                                break;
                            case "PhysicalOutputPath":
                                retval.PhysicalOutputPath = element.InnerText;
                                break;
                            case "Query":
                                retval.Query = element.InnerText;
                                break;
                            case "StatusCode":
                                JobStatusCode statusCode;
                                retval.StatusCode = Enum.TryParse(element.InnerText, true, out statusCode) ? statusCode : JobStatusCode.Unknown;
                                break;
                            case "SubmissionTime":
                                var submissionTime = element.InnerText;
                                if (submissionTime.IsNotNullOrEmpty())
                                {
                                    long timeInTicks;
                                    if (long.TryParse(submissionTime, NumberStyles.Integer, CultureInfo.InvariantCulture, out timeInTicks))
                                    {
                                        retval.SubmissionTime = new DateTime(timeInTicks);
                                    }
                                }
                                break;
                        }
                    }
                }
            }
            retval.ErrorCode = string.Empty;
            retval.HttpStatusCode = HttpStatusCode.Accepted;
            XmlElement error = (XmlElement)document.SelectSingleNode("//def:PassthroughResponse/def:Error", nameTable.NamespaceManager);
            if (error.IsNotNull())
            {
                var errorId = error.SelectSingleNode("//def:ErrorId", nameTable.NamespaceManager);
                if (errorId.IsNotNull())
                {
                    retval.ErrorCode = errorId.InnerText;
                }
                var statusCode = error.SelectSingleNode("//def:StatusCode", nameTable.NamespaceManager);
                if (statusCode.IsNotNull())
                {
                    HttpStatusCode httpStatusCode = HttpStatusCode.Accepted;
                    if (HttpStatusCode.TryParse(statusCode.InnerText, out httpStatusCode))
                    {
                        retval.HttpStatusCode = httpStatusCode;
                    }
                }
            }
            retval.JobId = jobId;
            return retval;
        }
    }
}
