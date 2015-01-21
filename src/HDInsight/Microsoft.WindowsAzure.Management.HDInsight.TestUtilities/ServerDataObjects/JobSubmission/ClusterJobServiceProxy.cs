using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.ClusterServices.Common.Utils;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission
{
    /// <summary>
    /// Class that acts as a proxy for submitting and working with jobs on a cluster.
    /// </summary>
    public class ClusterJobServiceProxy : IClusterJobServiceProxy
    {
        internal IWebHCatHttpClient hCatClient { get; set; }
        public string ClusterAddress { get; set; }
        public string ClusterUserName { get; set; }
        public string ClusterPassword { get; set; }

        public ClusterJobServiceProxy(string address, string userName, string password, bool validateServerCert)
        {
            Contract.AssertArgNotNull(address, "address");
            Contract.AssertArgNotNull(userName, "userName");
            Contract.AssertArgNotNull(password, "password");

            ClusterAddress = address;
            ClusterUserName = userName;
            ClusterPassword = password;
            Uri clusterUri;
            if (!Uri.TryCreate(ClusterAddress, UriKind.Absolute, out clusterUri))
            {
                throw new InvalidDataException("ClusterAddress");
            }
            hCatClient = new WebHCatHttpClient(new Uri(ClusterAddress), ClusterUserName, ClusterPassword,
                                               validateServerCert: validateServerCert);
        }

        public async Task<string> CreateMapReduceJob(string jarFile, string className, IEnumerable<string> resources,
                                         IEnumerable<string> arguments,
                                         IDictionary<string,string> parameters, string jobFolder)
        {
            var request = await hCatClient.CreateMapReduceJob(jarFile, className, null, resources, arguments, parameters,
                                                          jobFolder, null);
            if (!request.IsSuccessStatusCode)
            {
                throw new HttpResponseException(request);
            }

            try
            {
                return await GetJobIdFromServerResponse(request.Content);
            }
            catch (Exception)
            {
                //502: The server, while acting as a gateway or proxy, received an invalid response from the upstream server. 
                //This is caught and logged upstream. 
                throw new HttpResponseException(HttpStatusCode.BadGateway);
            }
        }

        public async Task<string> CreateHiveJob(string query, IEnumerable<string> resources, IDictionary<string, string> parameters, string jobFolder)
        {
            Contract.AssertArgNotNullOrEmpty(query,"query");
            Contract.AssertArgNotNull(resources, "resources");
            Contract.AssertArgNotNull(parameters, "parameters");
            Contract.AssertArgNotNullOrEmpty(jobFolder, jobFolder);

            var request = await hCatClient.CreateHiveJob(query, resources, parameters, jobFolder, callback: null);
            
            if (!request.IsSuccessStatusCode)
            {
                throw new HttpResponseException(request);
            }
            
            try
            {
                return await GetJobIdFromServerResponse(request.Content);
            }
            catch (HttpParseException)
            {
                //502: The server, while acting as a gateway or proxy, received an invalid response from the upstream server. 
                //This is caught and logged upstream. 
                throw new HttpResponseException(HttpStatusCode.BadGateway);
            }
        }

        public async Task<IEnumerable<string>> GetJobs()
        {
            var request = await hCatClient.GetJobs();

            if (!request.IsSuccessStatusCode)
            {
                throw new HttpResponseException(request);
            }

            try
            {
                return await GetJobIdListFromServerResponse(request.Content);
            }
            catch (HttpParseException)
            {
                //502: The server, while acting as a gateway or proxy, received an invalid response from the upstream server. 
                //This is caught and logged upstream.
                throw new HttpResponseException(HttpStatusCode.BadGateway);
            }
        }

        public async Task<JobDetails> GetJob(string jobId)
        {
            Contract.AssertArgNotNullOrEmpty(jobId,"jobId");

            var request = await hCatClient.GetJob(jobId);

            if (!request.IsSuccessStatusCode)
            {
                throw new HttpResponseException(request);
            }

            try
            {
                return await GetJobDetailsFromServerResponse(request.Content);
            }
            catch (HttpParseException)
            {
                //502: The server, while acting as a gateway or proxy, received an invalid response from the upstream server. 
                //This is caught and logged upstream.
                throw new HttpResponseException(HttpStatusCode.BadGateway);
            }
        }

        //This code is tightly coupled to Templeton. If parsing fails, we capture the full json payload, the error
        //then log it upstream.
        internal async Task<List<string>> GetJobIdListFromServerResponse(HttpContent content)
        {
            Contract.AssertArgNotNull(content, "content");
            try
            {
                var result = await content.ReadAsAsync<JArray>();

                if (result == null || !result.HasValues)
                {
                    return new List<string>();
                }
                var ret = result.Values<string>();
                return ret.ToList();

            }
            catch (Exception ex)
            {
                throw new HttpParseException(ex.Message);
            }
        }


        //This code is tightly coupled to Templeton. If parsing fails, we capture the full json payload, the error
        //then log it upstream.
        internal async Task<string> GetJobIdFromServerResponse(HttpContent content)
        {
            Contract.AssertArgNotNull(content,"content");
            try
            {
                var result = await content.ReadAsAsync<JObject>();
                Contract.Assert(result != null);
                
                JToken jobId;
                Contract.Assert(result.TryGetValue(JobSubmissionConstants.JobIdPropertyName,out jobId));
                Contract.Assert(jobId != null);
                return jobId.ToString();
            }
            catch (Exception ex)
            {
                throw new HttpParseException(ex.Message);
            }
        }

        //This code is tightly coupled to Templeton. If parsing fails, we capture the full json payload, the error
        //then log it upstream. I've left the constants here, since this is A) The only place they are used and B) there are a lot of them. 
        //In the future, if we see this being something that is reused, they could be moved.
        //For a sample response see the large comment at the end of this file. 
        internal async Task<JobDetails> GetJobDetailsFromServerResponse(HttpContent content)
        {
            const string userArgsSection = "userargs";
            const string defineSection = "define";
            const string statusSection = "status";

            const string jobNameKey = "hdInsightJobName=";
            const string statusDirectory = "statusdir";
            const string exitCodeValue = "exitValue";
            const string startTimeValue = "startTime";
            const string jobStatusValue = "runState";
            const string hiveQueryValue = "execute";

            const string outputFile = "/stdout";
            const string errorFile = "/stderr";

           Contract.AssertArgNotNull(content, "content");
           
            JObject result = null;
            try
            {
                result = await content.ReadAsAsync<JObject>();
                Contract.Assert(result != null);

                var outputAsvPath = (string)result[userArgsSection][statusDirectory];
                var outputFolderUri = GetOutputFolderUri(outputAsvPath);

                var defines = result[userArgsSection][defineSection].ToArray();
                var jobNameItem = (string)defines.First(s => ((string)s).Contains(jobNameKey));
                var jobName = jobNameItem.Split('=')[1];

                var details = new JobDetails
                    {
                        ExitCode = (int)result[exitCodeValue],
                        SubmissionTime = result[statusSection][startTimeValue].ToString(),
                        Name = jobName,
                        StatusCode = (JobStatusCode)Enum.Parse(typeof(JobStatusCode), result[statusSection][jobStatusValue].ToString()),
                        PhysicalOutputPath = new Uri(outputFolderUri + outputFile),
                        LogicalOutputPath = outputAsvPath + outputFile,
                        ErrorOutputPath = outputFolderUri + errorFile,
                        Query = (string)result[userArgsSection][hiveQueryValue],
                    };
                return details;
            }
            catch (Exception ex)
            {
                var rawJson = string.Empty;
                if(result != null)
                {
                    rawJson = result.ToString();
                    if (rawJson.Length > 4000)
                    {
                        //truncating the response if its large then 4000 char, in order to prevent large data in the logs
                        rawJson = rawJson.Substring(0, 4000);
                    }
                }
             
                throw new HttpParseException(string.Format(JobSubmissionConstants.UnableToParseJobDetailsLogMessage, ex.Message, rawJson));
            }
        }

        internal string GetOutputFolderUri(string asvPath)
        {
            Contract.AssertArgNotNullOrEmpty(asvPath,"asvPath");
            Uri asvUri;
            if (Uri.TryCreate(asvPath, UriKind.Absolute, out asvUri))
            {
                //only parse the string/uri if its asv, otherwise fall through and reutrn an argument exception.
                if (asvUri.Scheme.ToLowerInvariant() == "asv")
                {
                    return string.Format("https://{0}/{1}{2}", asvUri.Host, asvUri.UserInfo, asvUri.LocalPath);
                }
            }
            throw new ArgumentException();
        }
    }
}

//SAMPLE JOB DETAILS RESPONSE FROM TEMPELTON
//{"status":
//    {"startTime":1371147916636,
//    "jobPriority":"NORMAL",
//    "runState":2,
//    "username":"admin",
//    "failureInfo":"NA",
//    "schedulingInfo":"1 running map tasks using 1 map slots. 0 additional slots reserved. 0 running reduce tasks using 0 reduce slots. 0 additional slots reserved.",
//    "jobComplete":true,
//    "jobACLs":{},
//    "jobId":"job_201306130113_0003",
//    "jobID":
//        {"jtIdentifier":"201306130113","id":3}
//},
//"profile":
//    {"url":"http://jobtrackerhost:50030/jobdetails.jsp?jobid=job_201306130113_0003",
//    "user":"admin",
//    "jobName":"TempletonControllerJob",
//    "queueName":"joblauncher",
//    "jobFile":"hdfs://namenodehost:9000/mapred/staging/admin/.staging/job_201306130113_0003/job.xml",
//    "jobId":"job_201306130113_0003",
//    "jobID":
//        {"jtIdentifier":"201306130113","id":3}
//},
//    "id":"job_201306130113_0003",
//    "parentId":null,
//    "percentComplete":null,
//    "exitValue":0,
//    "user":"admin",
//    "callback":null,
//    "completed":"done",
//    "userargs"
//        :{"statusdir":"asv://testjobfolder@wfoleyeastus.blob.core.windows.net/stdout",
//        "define":["hdInsightJobName=TestJob"],
//        "execute":"SHOW TABLES;",
//        "user.name":"admin",
//        "file":null,
//        "callback":null
//        }
//    }