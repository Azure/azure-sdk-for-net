namespace Microsoft.Hadoop.Client.WebHCatRest
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Management.Framework.WebRequest;

    internal class HadoopLocalJobSubmissionRestClient : IHadoopJobSubmissionRestClient
    {
        public Task<IHttpResponseMessageAbstraction> ListJobs()
        {
            throw new NotImplementedException();
        }

        public Task<IHttpResponseMessageAbstraction> GetJob(string jobId)
        {
            throw new NotImplementedException();
        }

        public Task<IHttpResponseMessageAbstraction> SubmitMapReduceJob(string jar, string className, IEnumerable<string> files, IEnumerable<string> args, IDictionary<string, string> defines, string statusDirectory)
        {
            throw new NotImplementedException();
        }

        public Task<IHttpResponseMessageAbstraction> SubmitHiveJob(string execute, IDictionary<string, string> defines, string statusDirectory)
        {
            throw new NotImplementedException();
        }
    }
}
