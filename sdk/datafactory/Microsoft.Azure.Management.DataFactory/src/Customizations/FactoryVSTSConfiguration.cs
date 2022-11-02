namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class FactoryVSTSConfiguration : FactoryRepoConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the FactoryVSTSConfiguration class.
        /// </summary>
        /// <param name="accountName">Account name.</param>
        /// <param name="repositoryName">Repository name.</param>
        /// <param name="collaborationBranch">Collaboration branch.</param>
        /// <param name="rootFolder">Root folder.</param>
        /// <param name="projectName">VSTS project name.</param>
        /// <param name="lastCommitId">Last commit id.</param>
        /// <param name="tenantId">VSTS tenant id.</param>
        public FactoryVSTSConfiguration(string accountName, string repositoryName, string collaborationBranch, string rootFolder, string projectName, string lastCommitId, string tenantId)
            : base(accountName, repositoryName, collaborationBranch, rootFolder, lastCommitId)
        {
            ProjectName = projectName;
            TenantId = tenantId;
            CustomInit();
        }
    }
}
