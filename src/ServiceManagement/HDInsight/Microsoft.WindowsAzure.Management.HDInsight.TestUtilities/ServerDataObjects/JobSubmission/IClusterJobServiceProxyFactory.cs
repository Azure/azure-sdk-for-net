namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission
{
    public interface IClusterJobServiceProxyFactory
    {
        /// <summary>
        /// Creates ClusterJobServiceProxy objects for the given cluster/container.
        /// </summary>
        /// <param name="container">The given cluster/container.</param>
        /// <returns>The proxy object.</returns>
        IClusterJobServiceProxy CreateClusterJobServiceProxy(DataAccess.Context.ClusterContainer container);
    }
}