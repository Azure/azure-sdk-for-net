// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.HDInsight.Job.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Parameters specifying the HDInsight MapReduce Streaming job definition.
    /// </summary>
    public partial class MapReduceStreamingJobSubmissionParameters
    {
        /// <summary>
        /// Optional. Gets the arguments for the jobDetails.
        /// </summary>
        public IList<string> Arguments { get; set; }

        /// <summary>
        /// Optional. Set list of environment variables.
        /// </summary>
        public IDictionary<string, string> CmdEnv { get; set; }

        /// <summary>
        /// Optional. Gets or sets define parameters.
        /// </summary>
        public IDictionary<string, string> Defines { get; set; }
        
        /// <summary>
        /// Optional. File to add to the distributed cache.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Optional. List of files to be copied to the cluster.
        /// </summary>
        public IList<string> Files { get; set; }
        
        /// <summary>
        /// Optional. Location of the input data in Hadoop.
        /// </summary>
        public string Input { get; set; }
        
        /// <summary>
        /// Optional. Gets or sets Mapper executable or Java class name.
        /// </summary>
        public string Mapper { get; set; }
        
        /// <summary>
        /// Optional. Location in which to store the output data.
        /// </summary>
        public string Output { get; set; }
        
        /// <summary>
        /// Optional. Gets or sets Reducer executable or Java class name.
        /// </summary>
        public string Reducer { get; set; }
        
        /// <summary>
        /// Optional. Status directory in the default storage account to store job files stderr, stdout and exit.
        /// </summary>
        public string StatusDir { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the
        /// MapReduceStreamingJobSubmissionParameters class.
        /// </summary>
        public MapReduceStreamingJobSubmissionParameters()
        {
        }

        internal string GetJobPostRequestContent()
        {
            // Check input parameters and transform them to required format before sending request to templeton.
            var values = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrEmpty(this.Input))
            {
                values.Add(new KeyValuePair<string, string>("input", this.Input));
            }

            if (!string.IsNullOrEmpty(this.Output))
            {
                values.Add(new KeyValuePair<string, string>("output", this.Output));
            }

            if (!string.IsNullOrEmpty(this.Mapper))
            {
                values.Add(new KeyValuePair<string, string>("mapper", this.Mapper));
            }

            if (!string.IsNullOrEmpty(this.Reducer))
            {
                values.Add(new KeyValuePair<string, string>("reducer", this.Reducer));
            }

            if (!string.IsNullOrEmpty(this.File))
            {
                values.Add(new KeyValuePair<string, string>("file", this.File));
            }

            if (this.Files != null && this.Files.Count > 0)
            {
                values.Add(new KeyValuePair<string, string>("files", ModelHelper.BuildListToCommaSeparatedString(this.Files)));
            }

            if (this.Arguments != null && this.Arguments.Count > 0)
            {
                values.AddRange(ModelHelper.BuildList("arg", this.Arguments));
            }

            if (this.Defines != null && this.Defines.Count > 0)
            {
                values.AddRange(ModelHelper.BuildNameValueList("define", this.Defines));
            }

            if (this.CmdEnv != null && this.CmdEnv.Count > 0)
            {
                values.AddRange(ModelHelper.BuildNameValueList("cmdenv", this.CmdEnv));
            }

            values.Add(new KeyValuePair<string, string>("statusdir", ModelHelper.GetStatusDirectory(this.StatusDir)));

            return ModelHelper.ConvertItemsToString(values);
        }
    }
}
