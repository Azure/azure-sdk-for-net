namespace Microsoft.Hadoop.Client
{
    /// <summary>
    /// Base class for all jobs that contain a query or command field.
    /// </summary>
    public abstract class QueryJobCreateParameters : JobCreateParameters
    {
        /// <summary>
        /// Gets or sets a value indicating whether the job should be submitted via the File parameter.
        /// </summary>
        public bool RunAsFileJob { get; set; }

        /// <summary>
        /// Gets or sets the query file to use for this job.
        /// </summary>
        public string File { get; set; }

        internal abstract string GetQuery();

        internal abstract void SetQuery(string queryText);

        internal bool HasQuery()
        {
            return !string.IsNullOrEmpty(this.GetQuery());
        }
    }
}