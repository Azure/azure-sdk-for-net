namespace Microsoft.Azure.Management.DataFactory.Models
{
    public partial class FactoryGitHubConfiguration : FactoryRepoConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the FactoryGitHubConfiguration class.
        /// </summary>
        /// <param name="accountName">Account name.</param>
        /// <param name="repositoryName">Repository name.</param>
        /// <param name="collaborationBranch">Collaboration branch.</param>
        /// <param name="rootFolder">Root folder.</param>
        /// <param name="lastCommitId">Last commit id.</param>
        /// ADF studio to favor automated publish.</param>
        /// <param name="hostName">GitHub Enterprise host name. For example:
        /// `https://github.mydomain.com`</param>
        /// <param name="clientId">GitHub bring your own app client id.</param>
        /// <param name="clientSecret">GitHub bring your own app client secret
        /// information.</param>
        public FactoryGitHubConfiguration(string accountName, string repositoryName, string collaborationBranch, string rootFolder, string lastCommitId, string hostName, string clientId = default(string), GitHubClientSecret clientSecret = default(GitHubClientSecret))
            : base(accountName, repositoryName, collaborationBranch, rootFolder, lastCommitId)
        {
            HostName = hostName;
            ClientId = clientId;
            ClientSecret = clientSecret;
            CustomInit();
        }
    }
}
