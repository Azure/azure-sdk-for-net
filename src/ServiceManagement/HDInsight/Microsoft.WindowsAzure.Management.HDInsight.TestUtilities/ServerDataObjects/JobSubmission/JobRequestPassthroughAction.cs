using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.ClusterServices.Common.Utils;
using Microsoft.ClusterServices.Core.Logging;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common.Models;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission
{
    /// <summary>
    /// Action for submitting a new job request.
    /// </summary>
    public abstract class JobRequestPassthroughAction : PassthroughAction
    {
        static readonly Logger Log = Logger.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);

        internal IClusterJobServiceProxyFactory jobServiceProxyFactory = new ClusterJobServiceProxyFactory();
        internal IEnumerable<string> Resources { get; set; }
        internal IDictionary<string,string> Parameters { get; set; }
        internal string JobFolder { get; set; }

        /// <summary>
        /// The given cluster.
        /// </summary>
        internal DataAccess.Context.ClusterContainer Container { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        protected JobRequestPassthroughAction(DataAccess.Context.ClusterContainer container, string subscriptionId) : base(subscriptionId)
        {
            Contract.AssertArgNotNull(container,"container");

            Container = container;
        }

        /// <summary>
        /// Executes a method and handles any exceptions that might be thrown. 
        /// Specific to job submission, this wraps calls to templelton and handles the cases when errors occure sending the request
        /// or any errors returned by the cluster/templeton.
        /// </summary>
        /// <typeparam name="T">The return type of the function.</typeparam>
        /// <param name="func">The function to be executed.</param>
        /// <returns>The value that the function returned.</returns>
        protected async Task<PassthroughResponse> ExecuteAndHandleResponse<T>(Func<Task<T>> func)
        {
            Contract.AssertArgNotNull(func,"func");

            try
            {
                var ret = await func();
                return new PassthroughResponse() { Data = ret, Error = null };
            }
            catch (ArgumentException ex)
            {
                Log.LogResourceExtensionEvent(this.subscriptionId, JobSubmissionConstants.ResourceExtentionName, Container.DnsName,
                                          ex.Message, TraceEventType.Warning);
                var error = new PassthroughErrorResponse()
                {
                    ErrorId = JobSubmissionConstants.InvalidJobSumbmissionRequestErrorId,
                    StatusCode = HttpStatusCode.BadGateway
                };
                return new PassthroughResponse() { Data = null, Error = error };
            }
            catch (HttpResponseException ex)
            {
                var errorId = JobSubmissionConstants.JobSubmissionFailedErrorId;
                if (ex.Response != null)
                {
                    switch (ex.Response.StatusCode)
                    {
                        case HttpStatusCode.BadRequest:
                        case HttpStatusCode.BadGateway:
                        case HttpStatusCode.Unauthorized:
                            errorId = JobSubmissionConstants.JobSubmissionFailedErrorId;
                            break;
                        case HttpStatusCode.ServiceUnavailable:
                        case HttpStatusCode.InternalServerError:
                        case HttpStatusCode.NotFound:
                        case HttpStatusCode.GatewayTimeout:
                            errorId = JobSubmissionConstants.ClusterUnavailableErrorId;
                            break;
                        default:
                            errorId = JobSubmissionConstants.JobSubmissionFailedErrorId;
                            break;
                    }
                    Log.LogResourceExtensionEvent(this.subscriptionId,
                                                         JobSubmissionConstants.ResourceExtentionName,
                                                         Container.DnsName, string.Format(
                                                            JobSubmissionConstants.ClusterRequestErrorLogMessage,
                                                             this.Container.DnsName, ex.Response.StatusCode,
                                                             ex.Response.ReasonPhrase), TraceEventType.Warning);
                }
                Log.LogResourceExtensionEvent(this.subscriptionId,
                                                         JobSubmissionConstants.ResourceExtentionName,
                                                         Container.DnsName, string.Format(
                                                             JobSubmissionConstants.JobSubmissionFailedLogMessage,
                                                             this.Container.DnsName, errorId), TraceEventType.Warning);
                var error = new PassthroughErrorResponse() { ErrorId = errorId, StatusCode = HttpStatusCode.BadGateway };
                return new PassthroughResponse() { Data = null, Error = error };
            }
            catch (Exception ex)
            {
                Log.LogResourceExtensionEvent(this.subscriptionId,
                                                         JobSubmissionConstants.ResourceExtentionName,
                                                         Container.DnsName, string.Format(
                                                             JobSubmissionConstants.UnkownJobSubmissionErrorLogMessage,
                                                             this.Container.DnsName, ex.Message), TraceEventType.Warning);
                var error = new PassthroughErrorResponse() { ErrorId = JobSubmissionConstants.JobSubmissionFailedErrorId, StatusCode = HttpStatusCode.BadGateway };
                return new PassthroughResponse() { Data = null, Error = error };
            }
        }

        internal string CreateJobFolder(DataAccess.Context.ClusterContainer container)
        {
            Contract.AssertArgNotNull(container,"container");
            Contract.AssertArgNotNull(container.Deployment,"container.Deployment");
            Contract.AssertArgNotNull(container.Deployment.ASVAccounts,"container.Deployment.ASVAccounts");
            
            var asvAccount = container.Deployment.ASVAccounts.FirstOrDefault();
            Contract.AssertArgNotNull(asvAccount, "asvAccount");
            
            var jobFolder = Guid.NewGuid().ToString();
            
            return string.Format(JobSubmissionConstants.AsvFormatString, JobSubmissionConstants.DefaultJobsContainer,
                                 asvAccount.AccountName, jobFolder);
        }
    }
}