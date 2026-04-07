// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.HDInsight.Job.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Parameters specifying the HDInsight Hive job definition.
    /// </summary>
    public partial class SqoopJobSubmissionParameters
    {
        /// <summary>
        /// Optional. Gets or sets the command to use for a Sqoop job.
        /// </summary>
        public string Command { get; set; }
        
        /// <summary>
        /// Optional. Gets or sets the command file to use for a Sqoop job.
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Optional. Gets or sets the files to be copied to the cluster.
        /// </summary>
        public IList<string> Files { get; set; }

        /// <summary>
        /// Optional. Directory where libjar can be found to use by Sqoop.
        /// </summary>
        public string LibDir { get; set; }
                
        /// <summary>
        /// Optional. Status directory in the default storage account to store job files stderr, stdout and exit.
        /// </summary>
        public string StatusDir { get; set; }

        /// <summary>
        /// Initializes a new instance of the SqoopJobSubmissionParameters
        /// class.
        /// </summary>
        public SqoopJobSubmissionParameters()
        {
        }

        internal string GetJobPostRequestContent()
        {
            // Check input parameters and transform them to required format before sending request to templeton.
            var values = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrEmpty(this.Command))
            {
                values.Add(new KeyValuePair<string, string>("command", this.Command));
            }

            if (!string.IsNullOrEmpty(this.File))
            {
                values.Add(new KeyValuePair<string, string>("file", this.File));
            }

            if (!string.IsNullOrEmpty(this.LibDir))
            {
                values.Add(new KeyValuePair<string, string>("libdir", this.LibDir));
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
