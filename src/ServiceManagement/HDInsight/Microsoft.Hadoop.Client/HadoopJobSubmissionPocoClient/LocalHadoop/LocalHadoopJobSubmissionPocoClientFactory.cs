namespace Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient.LocalHadoop;

    internal class LocalHadoopJobSubmissionPocoClientFactory : IHadoopJobSubmissionPocoClientFactory
    {
        public IHadoopJobSubmissionPocoClient Create(IHadoopConnectionCredentials credentials, CancellationToken cancellationToken)
        {
            return new LocalHadoopJobSubmissionPocoClient();
        }
    }
}
