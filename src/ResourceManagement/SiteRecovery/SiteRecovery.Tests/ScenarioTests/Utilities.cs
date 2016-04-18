//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
using System.Net;
using Xunit;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Xml;
using Microsoft.Azure.Test;
using System.IO;
using System;
using System.Threading;

namespace SiteRecovery.Tests
{
    /// <summary>
    /// Helper around serialization/deserialization of objects. This one is a thin wrapper around
    /// DataContractUtils<T> which is the one doing the heavy lifting.
    /// </summary>
    public static class DataContractUtils
    {
        /// <summary>
        /// Serializes the supplied object to the string.
        /// </summary>
        /// <typeparam name="T">The object type.</typeparam>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>Serialized string.</returns>
        public static string Serialize<T>(T obj)
        {
            return DataContractUtils<T>.Serialize(obj);
        }

        /// <summary>
        /// Deserialize the string to the expected object type.
        /// </summary>
        /// <param name="xmlString">Serialized string.</param>
        /// <param name="result">Deserialized object.</param>
        public static void Deserialize<T>(string xmlString, out T result)
        {
            result = DataContractUtils<T>.Deserialize(xmlString);
        }
    }

    public static class DataContractUtils<T>
    {
        /// <summary>
        /// Serializes the propertyBagContainer to the string. 
        /// </summary>
        /// <param name="propertyBagContainer"></param>
        /// <returns></returns>
        public static string Serialize(T propertyBagContainer)
        {
            var serializer = new DataContractSerializer(typeof(T));
            string xmlString;
            StringWriter sw = null;
            try
            {
                sw = new StringWriter();
                using (var writer = new XmlTextWriter(sw))
                {
                    // Indent the XML so it's human readable.
                    writer.Formatting = Formatting.Indented;
                    serializer.WriteObject(writer, propertyBagContainer);
                    writer.Flush();
                    xmlString = sw.ToString();
                }
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }

            return xmlString;
        }

        /// <summary>
        /// Deserialize the string to the propertyBagContainer.
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static T Deserialize(string xmlString)
        {
            T propertyBagContainer;
            using (Stream stream = new MemoryStream())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xmlString);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
                propertyBagContainer = (T)deserializer.ReadObject(stream);
            }

            return propertyBagContainer;
        }
    }

    public static class MonitoringHelper
    {
        #region Protection jobs
        public const string PrimaryIrJobName = "PrimaryIrCompletion";

        public const string SecondaryIrJobName = "SecondaryIrCompletion";

        public const string AzureIrJobName = "IrCompletion";

        public const string EnableDrJobName = "EnableDr";

        public const string DisableDrJobName = "DisableDr";

        public const string ReverseReplicationJobName = "ReverseReplication";

        public const string Reprotect = "ReprotectReplicationGroup";
        #endregion

        #region Failover jobs
        public const string PlannedFailoverJobName = "PlannedFailover";

        public const string CommitFailoverJobName = "CommitFailover";

        public const string TestFailoverJobName = "TestFailover";

        public const string UnplannedFailoverJobName = "UnplannedFailover";
        #endregion

        #region Cloud pairing jobs
        public const string AddProtectionProfileJobName = "AddProtectionProfile";

        public const string AssociateProtectionProfileJobName = "AssociateProtectionProfile";
        #endregion

        /// <summary>
        /// Monitors jobs for specific object id.
        /// </summary>
        /// <param name="jobName">Name of the job to monitor.</param>
        /// <param name="startTime">Start time of job</param>
        /// <param name="client">SiteRecovery client.</param>
        /// <param name="requestHeaders">Request headers.</param>
        public static void MonitorJobs(
            string jobName,
            DateTime startTime,
            SiteRecoveryManagementClient client,
            CustomRequestHeaders requestHeaders)
        {
            bool trackingFinished = false;

            while (!trackingFinished)
            {

                if (!trackingFinished)
                {
                    Thread.Sleep(new TimeSpan(0, 1, 0));
                }

                JobQueryParameter queryParam = new JobQueryParameter();
                JobListResponse jobList = client.Jobs.List(queryParam, requestHeaders);
                trackingFinished = true;

                foreach (var job in jobList.Jobs)
                {
                    if (job.Properties.ScenarioName.Contains(jobName)
                        && job.Properties.State.Equals(
                            "InProgress",
                            StringComparison.InvariantCultureIgnoreCase))
                    {
                        trackingFinished = false;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Returns job id of the job.
        /// </summary>
        /// <param name="jobName">Name of the job to check for.</param>
        /// <param name="startTime">Start time of job</param>
        /// <param name="client">SiteRecovery client.</param>
        /// <param name="requestHeaders">Request headers.</param>
        /// <returns>Job object of the job queried.</returns>
        public static Job GetJobId(
            string jobName,
            DateTime startTime,
            SiteRecoveryManagementClient client,
            CustomRequestHeaders requestHeaders)
        {

            JobQueryParameter queryParam = new JobQueryParameter();
            JobListResponse jobList = client.Jobs.List(queryParam, requestHeaders);

            foreach (var job in jobList.Jobs)
            {
                if (job.Properties.ScenarioName.Contains(jobName))
                {
                    return job;
                }
            }

            return new Job();
        }
    }
}
