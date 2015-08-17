using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission
{
    public interface IClusterJobServiceProxy
    {
        string ClusterAddress { get; set; }
        string ClusterUserName { get; set; }
        string ClusterPassword { get; set; }
        Task<string> CreateMapReduceJob(string jarFile, string className, IEnumerable<string> resources, IEnumerable<string> arguments, IDictionary<string, string> parameters, string jobFolder);
        Task<string> CreateHiveJob(string query, IEnumerable<string> resources, IDictionary<string, string> parameters, string jobFolder);
        Task<IEnumerable<string>> GetJobs();
        Task<JobDetails> GetJob(string jobId);
    }
}