namespace Microsoft.Hadoop.Client.HadoopJobSubmissionPocoClient.LocalHadoop
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class LocalHadoopJobSubmissionPocoClient : IHadoopJobSubmissionPocoClient
    {
        public IEnumerable<HadoopJob> ListJobs()
        {
            throw new NotImplementedException();
        }

        Task<HadoopJobList> IHadoopJobSubmissionPocoClient.ListJobs()
        {
            throw new NotImplementedException();
        }

        public Task<HadoopJob> GetJob(string jobId)
        {
            throw new NotImplementedException();
        }

        public Task<HadoopJobCreationResults> SubmitMapReduceJob(HadoopMapReduceJobCreationDetails details)
        {
            throw new NotImplementedException();
        }

        public Task<HadoopJobCreationResults> SubmitHiveJob(HadoopHiveJobCreationDetails details)
        {
            throw new NotImplementedException();
        }

        public Task<HadoopJobCreationResults> SubmitPigJob(HadoopPigJobCreationDetails details)
        {
            throw new NotImplementedException();
        }

        public Task<HadoopJobCreationResults> SubmitStreamingJob(HadoopStreamingMapReduceJobCreationDetails details)
        {
            throw new NotImplementedException();
        }

        public Task<HadoopJob> StopJob(string jobId)
        {
            throw new NotImplementedException();
        }
    }
}
