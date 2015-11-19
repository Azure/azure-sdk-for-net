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
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using Microsoft.Hadoop.Client.WebHCatResources;
    using Microsoft.Hadoop.Client.WebHCatRest;
    using Microsoft.WindowsAzure.Management.HDInsight;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    /// <summary>
    /// Base class for Remote jobDetails Payload Conversions.
    /// </summary>
    internal class PayloadConverterBase
    {
        internal const string HadoopStreamingJarFile = "hadoop-streaming.jar";
        internal const string NoneReducer = "NONE";

        /// <summary>
        /// Creates the payload for a MapReduce request.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="details">
        /// The details.
        /// </param>
        /// <returns>
        /// A string that represents the payload for the request.
        /// </returns>
        public string SerializeMapReduceRequest(string userName, MapReduceJobCreateParameters details)
        {
            details.ArgumentNotNull("details");
            var values = new List<KeyValuePair<string, string>>();
            values.AddRange(this.SerializeJobRequest(userName, details, details.JobName, details.Arguments, details.Defines));
            values.Add(new KeyValuePair<string, string>(WebHCatConstants.Jar, details.JarFile));
            values.Add(new KeyValuePair<string, string>(WebHCatConstants.Class, details.ClassName));
            var retval = this.ConvertItems(values.Where(kvp => kvp.Value != null));
            return retval;
        }

        /// <summary>
        /// Creates the payload for a Streaming MapReduce request.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="details">
        /// The details.
        /// </param>
        /// <returns>
        /// A string that represents the payload for the request.
        /// </returns>
        public string SerializeStreamingMapReduceRequest(string userName, StreamingMapReduceJobCreateParameters details)
        {
            details.ArgumentNotNull("details");
            var values = new List<KeyValuePair<string, string>>();

            values.Add(new KeyValuePair<string, string>(WebHCatConstants.Input, details.Input));
            values.Add(new KeyValuePair<string, string>(WebHCatConstants.Output, details.Output));
            values.Add(new KeyValuePair<string, string>(WebHCatConstants.Mapper, details.Mapper));

            if (!details.Combiner.IsNullOrEmpty())
            {
                values.Add(new KeyValuePair<string, string>(WebHCatConstants.Combiner, details.Combiner));
            }

            if (details.Reducer.IsNullOrEmpty())
            {
                values.Add(new KeyValuePair<string, string>(WebHCatConstants.Reducer, NoneReducer));
            }
            else
            {
                values.Add(new KeyValuePair<string, string>(WebHCatConstants.Reducer, details.Reducer));
            }

            values.AddRange(this.SerializeJobRequest(userName, details, details.JobName, details.Arguments, details.Defines));
            values.AddRange(this.BuildList(WebHCatConstants.CmdEnv, details.CommandEnvironment));
            var retval = this.ConvertItems(values.Where(kvp => kvp.Value != null));
            return retval;
        }

        /// <summary>
        /// Creates the payload for a Hive request.
        /// </summary>
        /// <param name="userName"> The user name.</param>
        /// <param name="details"> The details.</param>
        /// <returns>A string that represents the payload for the request.</returns>
        public string SerializeHiveRequest(string userName, HiveJobCreateParameters details)
        {
            details.ArgumentNotNull("details");
            return this.SerializeQueryRequest(userName, details, details.JobName, details.File, details.Query, WebHCatConstants.Execute, details.Arguments, details.Defines);
        }

        /// <summary>
        /// Creates the payload for a Pig request.
        /// </summary>
        /// <param name="userName"> The user name.</param>
        /// <param name="details"> The details.</param>
        /// <returns>A string that represents the payload for the request.</returns>
        public string SerializePigRequest(string userName, PigJobCreateParameters details)
        {
            details.ArgumentNotNull("details");
            return this.SerializeQueryRequest(userName, details, string.Empty, details.File, details.Query, WebHCatConstants.Execute, details.Arguments, null);
        }

        /// <summary>
        /// Creates the payload for a Sqoop request.
        /// </summary>
        /// <param name="userName"> The user name.</param>
        /// <param name="details"> The details.</param>
        /// <returns>A string that represents the payload for the request.</returns>
        public string SerializeSqoopRequest(string userName, SqoopJobCreateParameters details)
        {
            details.ArgumentNotNull("details");
            return this.SerializeQueryRequest(userName, details, string.Empty, details.File, details.Command, WebHCatConstants.Command, null, null);
        }

        private string SerializeQueryRequest(string userName, JobCreateParameters details, string jobName, string file, string query, string queryFieldName, ICollection<string> arguments, IDictionary<string, string> defines)
        {
            queryFieldName.ArgumentNotNullOrEmpty("queryFieldName");
            details.ArgumentNotNull("details");

            var values = new List<KeyValuePair<string, string>>();
            values.AddRange(this.SerializeJobRequest(userName, details, jobName, arguments, defines));
            if (query.IsNullOrEmpty())
            {
                file.ArgumentNotNullOrEmpty("file");
                values.Add(new KeyValuePair<string, string>(WebHCatConstants.File, file));
            }
            else
            {
                values.Add(new KeyValuePair<string, string>(queryFieldName, query));
            }

            return this.ConvertItems(values.Where(kvp => kvp.Value != null));
        }

        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase", Justification = "The boolean value needs to be in lower case for Templeton.")]
        private IEnumerable<KeyValuePair<string, string>> SerializeJobRequest(string userName, JobCreateParameters details, string jobName, ICollection<string> arguments, IDictionary<string, string> defines)
        {
            var values = new List<KeyValuePair<string, string>>();

            if (defines.IsNotNull())
            {
                if (jobName.IsNotNullOrEmpty() && !defines.ContainsKey(WebHCatConstants.DefineJobName))
                {
                    defines.Add(WebHCatConstants.DefineJobName, jobName);
                }

                values.AddRange(this.BuildNameValueList(WebHCatConstants.Define, defines));
            }

            if (arguments.IsNotNull())
            {
                if (jobName.IsNotNullOrEmpty() && defines.IsNull())
                {
                    arguments.Add(string.Format(CultureInfo.InvariantCulture, "{0}={1}", WebHCatConstants.DefineJobName, jobName));
                }

                values.AddRange(this.BuildList(WebHCatConstants.Arg, arguments));
            }

            values.Add(new KeyValuePair<string, string>(WebHCatConstants.StatusDirectory, details.StatusFolder));
            values.Add(new KeyValuePair<string, string>(WebHCatConstants.Files, this.BuildCommaSeparatedList(details.Files)));
            values.Add(new KeyValuePair<string, string>(WebHCatConstants.UserName, userName));
            values.Add(new KeyValuePair<string, string>(WebHCatConstants.Callback, details.Callback));
            values.Add(new KeyValuePair<string, string>(HadoopRemoteRestConstants.EnableLogging, details.EnableTaskLogs.ToString().ToLowerInvariant()));

            return values;
        }

        private string ConvertItems(IEnumerable<KeyValuePair<string, string>> args)
        {
            var strings = (from kvp in args
                           select kvp.Key.EscapeDataString() + "=" + kvp.Value.EscapeDataString()).ToList();
            return string.Join("&", strings);
        }

        private string BuildCommaSeparatedList(IEnumerable<string> input)
        {
            return string.Join(",", input.ToArray());
        }

        private IEnumerable<KeyValuePair<string, string>> BuildList(string type, IEnumerable<string> args)
        {
            List<KeyValuePair<string, string>> retval = new List<KeyValuePair<string, string>>();

            foreach (var arg in args)
            {
                retval.Add(new KeyValuePair<string, string>(type, arg));
            }
            return retval;
        }

        private IEnumerable<KeyValuePair<string, string>> BuildNameValueList(string paramName, IEnumerable<KeyValuePair<string, string>> nameValuePairs)
        {
            List<KeyValuePair<string, string>> retval = new List<KeyValuePair<string, string>>();

            foreach (var kvp in nameValuePairs)
            {
                retval.Add(new KeyValuePair<string, string>(paramName, kvp.Key + "=" + kvp.Value));
            }
            return retval;
        }
    }
}