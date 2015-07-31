namespace Microsoft.Azure.Management.HDInsight.Models
{
    /// <summary>
    /// A list of roles in a HDInsight Hadoop cluster to run config action on.
    /// </summary>
    public enum ClusterNodeType
    {
        /// <summary> 
        /// The head nodes of the cluster.
        /// </summary> 
        HeadNode,

        /// <summary> 
        /// The worker nodes of the cluster.
        /// </summary> 
        WorkerNode,

        /// <summary>
        /// The zookeper nodes of the cluster.
        /// </summary>
        ZookeeperNode
    }
}