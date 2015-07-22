using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.ClusterServices.Common.Utils;
using Microsoft.ClusterServices.Core.Logging;
using Microsoft.ClusterServices.Core.Utils;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common
{
    /// <summary>
    /// Low level class that contains the logic and implementation details for talking to WebHcat.
    /// </summary>
    public class WebHCatHttpClient : IWebHCatHttpClient
    {
        private static readonly Logger Log = Logger.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);

        private string hadoopUserName;
        
        private bool validateServerCert;

        private HttpClient client = new HttpClient();

        public TimeSpan Timeout
        {
            get { return this.client.Timeout; }
            set { this.client.Timeout = value; }
        }

        public WebHCatHttpClient(Uri baseUri, string username, string password, string hadoopUserName = null,
                                 HttpMessageHandler handler = null, bool validateServerCert = true)
        {
            if (hadoopUserName == null)
            {
                hadoopUserName = username;
            }
            Initialize(baseUri, username, password, hadoopUserName, handler, validateServerCert);
        }

        private void Initialize(Uri baseUri, string username, string password, string hadoopUserName,
                                HttpMessageHandler handler, bool validateServerCert = true)
        {
            Contract.AssertArgNotNull(baseUri, "baseUri");
            Contract.AssertArgNotNull(username, "username");
            Contract.AssertArgNotNull(password, "password");
            Contract.AssertArgNotNull(hadoopUserName, "hadoopUserName");

            this.validateServerCert = validateServerCert;

            // TODO - have version passed in
            if (handler != null)
            {
                client = new HttpClient(handler);
            }
            else
            {
                client =
                    new HttpClient(new HttpClientHandler() {Credentials = new NetworkCredential(username, password)});
            }

            this.hadoopUserName = hadoopUserName;
            client.BaseAddress = new Uri(baseUri, WebHCatResources.RelativeWebHCatPath);

            var byteArray = Encoding.ASCII.GetBytes(username + ":" + password);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                                                                                       Convert.ToBase64String(
                                                                                           byteArray));
            this.Timeout = WebHCatResources.DefaultHCatRequestTimout;
        }

        public string HadoopUserName
        {
            get { return this.hadoopUserName; }
        }

        private List<KeyValuePair<string, string>> GetDefaultPigAndHiveValues(string execute, string statusDir,
                                                                              string callback)
        {
            return new List<KeyValuePair<string, string>>()
                {
                    {new KeyValuePair<string, string>(WebHCatResources.Execute, execute)},
                    {new KeyValuePair<string, string>(WebHCatResources.StatusDirectory, statusDir)},
                    {new KeyValuePair<string, string>(WebHCatResources.Callback, callback)}
                };
        }

        public async Task<HttpResponseMessage> CreateHiveJob(string execute, IEnumerable<string> file,
                                                 IDictionary<string, string> defines,
                                                 string statusDirectory, string callback)
        {
            var values = GetDefaultPigAndHiveValues(execute, statusDirectory, callback);

            values.AddRange(file.Select(f => new KeyValuePair<string, string>(WebHCatResources.File, f)));
            values.AddRange(
                defines.Select(
                    kvp =>
                    new KeyValuePair<string, string>(WebHCatResources.Define,
                                                     string.Format("{0}={1}", kvp.Key, kvp.Value))));
            return await SendAsyncRequest(HttpMethod.Post, WebHCatResources.Hive, values);
        }

        public async Task<HttpResponseMessage> CreatePigJob(string execute, IEnumerable<string> file,
                                                IEnumerable<string> args, IEnumerable<string> files,
                                                string statusDirectory, string callback)
        {
            var values = GetDefaultPigAndHiveValues(execute, statusDirectory, callback);

            AddResourcesToList(WebHCatResources.Files, files, values);

            values.AddRange(file.Select(f => new KeyValuePair<string, string>(WebHCatResources.File, f)));
            values.AddRange(args.Select(a => new KeyValuePair<string, string>(WebHCatResources.Arg, a)));
            return await SendAsyncRequest(HttpMethod.Post, WebHCatResources.Pig, values);
        }

        public async Task<HttpResponseMessage> CreateMapReduceJob(string jar,
                                                      string className,
                                                      IEnumerable<string> libjars,
                                                      IEnumerable<string> files,
                                                      IEnumerable<string> args,
                                                      IDictionary<string, string> defines,
                                                      string statusDirectory,
                                                      string callback)
        {
            var values = new List<KeyValuePair<string, string>>()
                {
                    {new KeyValuePair<string, string>(WebHCatResources.Jar, jar)},
                    {new KeyValuePair<string, string>(WebHCatResources.Class, className)},
                    {new KeyValuePair<string, string>(WebHCatResources.StatusDirectory, statusDirectory)},
                    {new KeyValuePair<string, string>(WebHCatResources.Callback, callback)}
                };

            AddResourcesToList(WebHCatResources.Libjars, libjars, values);
            AddResourcesToList(WebHCatResources.Files, files, values);

            values.AddRange(args.Select(a => new KeyValuePair<string, string>(WebHCatResources.Arg, a)));
            values.AddRange(
                defines.Select(
                    kvp =>
                    new KeyValuePair<string, string>(WebHCatResources.Define,
                                                     string.Format("{0}={1}", kvp.Key, kvp.Value))));
            return await SendAsyncRequest(HttpMethod.Post, WebHCatResources.MapReduceJar, values);
        }

        public async Task<HttpResponseMessage> GetJob(string jobID)
        {
            return await SendAsyncRequest(HttpMethod.Get, string.Format("{0}/{1}", WebHCatResources.Queue, jobID), null);
        }

        public async Task<HttpResponseMessage> GetJobs()
        {
            return await SendAsyncRequest(HttpMethod.Get, WebHCatResources.Queue, null);
        }

        public async Task<HttpResponseMessage> DeleteJob(string jobID)
        {
            return await SendAsyncRequest(HttpMethod.Delete, string.Format("{0}/{1}", WebHCatResources.Queue, jobID), null);
        }

        private string UserNameParam()
        {
            return string.Format("?{0}={1}", WebHCatResources.UserName, this.hadoopUserName);
        }

        private async Task<HttpResponseMessage> SendAsyncRequest(HttpMethod method, string requestUri,
                                                     List<KeyValuePair<string, string>> parameters)
        {
            if (parameters == null && (method == HttpMethod.Post || method == HttpMethod.Put))
            {
                throw new InvalidOperationException("Attempt to perform a post or put with no parameters.");
            }

            if (method == HttpMethod.Get || method == HttpMethod.Delete)
            {
                requestUri = requestUri + UserNameParam();
            }
            else
            {
                parameters.Add(new KeyValuePair<string, string>(WebHCatResources.UserName, this.hadoopUserName));
            }

            var request = new HttpRequestMessage(method, requestUri);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(WebHCatResources.ApplicationJson));
            if (method == HttpMethod.Post || method == HttpMethod.Put)
            {
                request.Content = new FormUrlEncodedContent(parameters.Where(kvp => kvp.Value != null));
            }
            var certValidationCallback = new ClusterAmbariApiHelper.CertificateValidationHelper();

            try
            {
                if (!validateServerCert)
                {
                    ServicePointManager.ServerCertificateValidationCallback +=
                        certValidationCallback.ServerCertificateValidationCallback;
                }

                var cts = new CancellationTokenSource();
                cts.CancelAfter(this.Timeout);
                try
                {
                    return await client.SendAsync(request, HttpCompletionOption.ResponseContentRead, cts.Token);
                }
                catch(TaskCanceledException)
                {
                    throw new HttpResponseException(HttpStatusCode.GatewayTimeout);
                }

            }
            finally
            {
                if (!validateServerCert)
                {
                    ServicePointManager.ServerCertificateValidationCallback -=
                        certValidationCallback.ServerCertificateValidationCallback;
                }

            }
        }

        private void AddResourcesToList(string key, IEnumerable<string> input, IList<KeyValuePair<string,string>> values )
        {
            if (input != null)
            {
                var inputList = input.Where(i => i != null).ToList();
                if (inputList.Any())
                {
                    var inputString = UtilsHelper.FlattenList(inputList);
                    values.Add(new KeyValuePair<string, string>(key, inputString));
                }
            }
          
        }
    }
}