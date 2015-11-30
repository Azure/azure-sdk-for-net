namespace Microsoft.WindowsAzure.Management.HDInsight
{
    /// <summary>
    /// The type of Operating System installed on VMs of HDInsight clusters.
    /// </summary>
    public enum OSType
    {
        /// <summary>
        /// The Operating System installed on VMs of IaaS clusters.
        /// </summary>
        Linux,

        /// <summary>
        /// The Operating System installed on VMs of PaaS clusters.
        /// </summary>
        Windows
    }
}
