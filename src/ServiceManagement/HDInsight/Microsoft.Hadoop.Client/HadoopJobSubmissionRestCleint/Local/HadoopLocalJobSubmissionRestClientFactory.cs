namespace Microsoft.Hadoop.Client.HadoopJobSubmissionRestCleint.Local
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Hadoop.Client.HadoopJobSubmissionRestCleint.Remote;
    using Microsoft.Hadoop.Client.WebHCatRest;

    internal class HadoopLocalJobSubmissionRestClientFactory : IHadoopLocalJobSubmissionRestClientFactory
    {
        public IHadoopJobSubmissionRestClient Create(IHadoopConnectionCredentials credentials)
        {
            // The local Hadoop connection does not actually use connection credentials other than
            // to identify that a local Hadoop connection was desired.
            return new HadoopLocalJobSubmissionRestClient();
        }
    }
}
