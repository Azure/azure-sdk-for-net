// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.HDInsight.Job.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Parameters specifying the HDInsight Pig job definition.
    /// </summary>
    public partial class PigJobSubmissionParameters
    {
        /// <summary>
        /// Optional. Gets the arguments for the jobDetails.
        /// </summary>
        public IList<string> Arguments { get; set; }
        
        /// <summary>
        /// Optional. Gets or sets the query file to use for a Pig job.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Optional. Gets or sets the files to be copied to the cluster.
        /// </summary>
        public IList<string> Files { get; set; }
        
        /// <summary>
        /// Optional. Gets or sets the query to use for a Pig job.
        /// </summary>
        public string Query { get; set; }
        
        /// <summary>
        /// Optional. Status directory in the default storage account to store job files stderr, stdout and exit.
        /// </summary>
        public string StatusDir { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the PigJobSubmissionParameters class.
        /// </summary>
        public PigJobSubmissionParameters()
        {
        }

        internal string GetJobPostRequestContent()
        {
            // Check input parameters and transform them to required format before sending request to templeton.
            var values = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrEmpty(this.Query))
            {
                values.Add(new KeyValuePair<string, string>("execute", this.Query));
            }

            if (!string.IsNullOrEmpty(this.File))
            {
                values.Add(new KeyValuePair<string, string>("file", this.File));
            }

            if (this.Arguments != null && this.Arguments.Count > 0)
            {
                values.AddRange(ModelHelper.BuildList("arg", this.Arguments));
            }

            if (this.Files != null && this.Files.Count > 0)
            {
                values.Add(new KeyValuePair<string, string>("files", ModelHelper.BuildListToCommaSeparatedString(this.Files)));
            }

            values.Add(new KeyValuePair<string, string>("statusdir", ModelHelper.GetStatusDirectory(this.StatusDir)));

            return ModelHelper.ConvertItemsToString(values);
        }
    }
}
