namespace Microsoft.Azure.Batch.Common
{
    /// <summary>
    /// The status of an individual task in an add task collection operation.
    /// </summary>
    public enum AddTaskStatus
    {
        /// <summary>
        /// The task addition was successful.
        /// </summary>
        Success,

        /// <summary>
        /// The task addition failed due to user error.
        /// </summary>
        ClientError,

        /// <summary>
        /// The task addition failed due to an unforseen server error.
        /// </summary>
        ServerError,

        /// <summary>
        /// The service reported an option that is not recognized by this
        /// version of the Batch client.
        /// </summary>
        Unmapped
    }
}
