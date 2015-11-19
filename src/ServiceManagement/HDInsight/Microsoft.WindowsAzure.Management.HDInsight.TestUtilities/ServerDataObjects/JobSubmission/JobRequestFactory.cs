using System;
using Microsoft.ClusterServices.Core.Utils;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission
{
    public class JobRequestFactory : IJobRequestFactory
    {
        public JobRequest CreateJobRequest(string request)
        {
            ClientJobRequest clientReq = null;
            
            try
            {
                clientReq = UtilsHelper.DeserializeFromXml<ClientJobRequest>(request);
            }
            catch (Exception)
            {
               //TODO: add logging
                return null;
            }

            JobRequest req;
            
            switch (clientReq.JobType)
            {
                case JobType.Hive:
                    if (HiveJobRequest.TryParse(clientReq, out req))
                    {
                        return req;
                    }
                    break;
                case JobType.MapReduce:
                    if (MapReduceJobRequest.TryParse(clientReq, out req))
                    {
                        return req;
                    }
                    break;
            }

            return null;
        }
    }
}