using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using Microsoft.ClusterServices.Common.Utils;
using Microsoft.ClusterServices.Core.Logging;
using Microsoft.ClusterServices.Core.Utils;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission;
using Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.JobSubmission.Models;

namespace Microsoft.ClusterServices.RDFEProvider.ResourceExtensions.Common
{
    public class PassthroughActionFactory : IPassthroughActionFactory
    {
        internal IJobRequestFactory jobRequestFactory = new JobRequestFactory();

        /// <summary>
        /// Method that get the correct passthrough action based on the given request. 
        /// </summary>
        /// <param name="resourceExtension">The resource extention that was requested (ie. "/jobs").</param>
        /// <param name="request">The actual http request.</param>
        /// <param name="container">The container that action should be preformed on.</param>
        /// <param name="subscriptionId">The subscription Id that made the request.</param>
        /// <returns></returns>
        public IPassthroughAction GetPassthroughAction(string resourceExtension, HttpRequestMessage request, 
                                                       DataAccess.Context.ClusterContainer container, string subscriptionId)
        {
            Contract.AssertArgNotNull(request,"request");
            Contract.AssertArgNotNull(request.RequestUri,"request.RequestUri");

            switch (resourceExtension.ToLowerInvariant())
            {
                case "jobs":
                    switch (request.Method.ToString().ToLowerInvariant())
                    {
                        case "put":
                            var requestPayload = GetRequestPayload(request);
                            
                            var jobRequest = jobRequestFactory.CreateJobRequest(requestPayload);
                            if (jobRequest == null)
                            {
                                throw new PassthroughActionProcessingException(string.Format(JobSubmissionConstants.InvalidJobRequestLogMessage, requestPayload));
                            }
                            return CreateJobRequestAction(jobRequest, container, subscriptionId);
                        case "get":
                            return CreateJobHistoryAction(request.RequestUri, container, subscriptionId);
                    }
                    break;
            }
            throw new PassthroughActionProcessingException(string.Format(JobSubmissionConstants.PassThroughActionCreationFailedLogMessage, resourceExtension,request.Method));
        }

        internal string GetRequestPayload(HttpRequestMessage request)
        {
            Contract.AssertArgNotNull(request,"request");
            Contract.AssertArgNotNull(request.Content, "request.Content");
            try
            {
                var contentTask = request.Content.ReadAsStringAsync();
                contentTask.Wait();
                return contentTask.Result;
            }
            catch (Exception ex)
            {
                throw new PassthroughActionProcessingException(
                    string.Format(JobSubmissionConstants.ContentReadFailureLogMessage, request.RequestUri,
                                  request.Method, ex.Message));
            }
        }

        internal IPassthroughAction CreateJobHistoryAction(Uri requestUri, DataAccess.Context.ClusterContainer container,
                                                           string subscriptionId)
        {
            Contract.AssertArgNotNull(requestUri, "requestUri");
            Contract.AssertArgNotNull(requestUri.Segments, "requestUri.Segments");
            
            var lastSegs =
                requestUri.Segments.SkipWhile(i => i.ToLowerInvariant().Trim('/') != JobSubmissionConstants.ResourceExtentionName)
                          .ToList();
            Contract.AssertArgNotNull(lastSegs, "lastSegs");

            //If there is one segment, then we know that no JobId was passed, and we should list job history.
            if (lastSegs.Count() == 1)
            {
                return new ListJobsPassthroughAction(container, subscriptionId);
            }

            //If there are two segments, then an jobId was passed, and we should get job details.
            if (lastSegs.Count() == 2)
            {
                return new JobDetailsPassthroughAction(lastSegs.Last().Trim('/'), container, subscriptionId);
            }

            //If zero or more then two segments are present, then the request is invalid, and an action cannot be found to support it.
            throw new PassthroughActionProcessingException(string.Format(JobSubmissionConstants.JobHistoryRequestActionNotFound, container.DnsName, requestUri));
        }

        internal IPassthroughAction CreateJobRequestAction(JobRequest reqeust, DataAccess.Context.ClusterContainer container, string subscriptionId)
        {
            if (reqeust is MapReduceJobRequest)
            {
                return CreateMapReduceJobRequestAction(reqeust as MapReduceJobRequest, container, subscriptionId);
            }
            if (reqeust is HiveJobRequest)
            {
                return CreateHiveJobRequestAction(reqeust as HiveJobRequest, container, subscriptionId);
            }
            throw new PassthroughActionProcessingException(string.Format(JobSubmissionConstants.JobRequestActionNotFound, container.DnsName, UtilsHelper.SerializeToJson(reqeust)));
        }

        internal MapReduceJobRequestPassthroughAction CreateMapReduceJobRequestAction(MapReduceJobRequest request , DataAccess.Context.ClusterContainer container, string subscriptionId)
        {
            //TODO: Create/generate the job folder.
            //This is ok for now. When we start listing jobs we'll need to fix this.
            return new MapReduceJobRequestPassthroughAction(container, subscriptionId)
                {
                    Arguments = request.Arguments,
                    ClassName = request.ApplicationName,
                    JarFile = request.JarFile,
                    Parameters =request.Parameters,
                    Resources = request.Resources
                };
        }

        internal HiveJobRequestPassthroughAction CreateHiveJobRequestAction(HiveJobRequest request, DataAccess.Context.ClusterContainer container, string subscriptionId)
        {
            //TODO: Create/generate the job folder.
            //This is ok for now. When we start listing jobs we'll need to fix this.
            return new HiveJobRequestPassthroughAction(container, subscriptionId)
            {
                Query = request.Query,
                Parameters = request.Parameters,
                Resources = request.Resources
            };
        }
    }
}