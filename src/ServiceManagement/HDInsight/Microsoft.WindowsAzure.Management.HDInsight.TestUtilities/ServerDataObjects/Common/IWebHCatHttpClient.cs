using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common
{
    /// <summary>
    /// Very thin abstraction on top of the webHcat Client. (mainly here for injecting/mocking in unit tests).
    /// </summary>
    public interface IWebHCatHttpClient
    {
        Task<HttpResponseMessage> CreateHiveJob(string query, IEnumerable<string> file,
                                                  IDictionary<string,string> defines,
                                                  string statusDirectory, string callback);

        Task<HttpResponseMessage> CreatePigJob(string query, IEnumerable<string> file,
                                         IEnumerable<string> args, IEnumerable<string> files,
                                         string statusDirectory, string callback);

        Task<HttpResponseMessage> CreateMapReduceJob(string jar,
                                                  string className,
                                                  IEnumerable<string> libjars,
                                                  IEnumerable<string> files,
                                                  IEnumerable<string> args,
                                                  IDictionary<string,string> defines,
                                                  string statusDirectory,
                                                  string callback);

        Task<HttpResponseMessage> GetJob(string jobID);
        Task<HttpResponseMessage> GetJobs();
    }
}