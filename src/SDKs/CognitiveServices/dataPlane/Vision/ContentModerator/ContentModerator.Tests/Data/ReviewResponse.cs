using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Microsoft.Azure.CognitiveServices.ContentModerator;

namespace ContentModeratorTests
{
   public class ReviewResponses
    {
        public ReviewResponses(){}

        //JobAPIS
        public HttpOperationResponse<JobId> CreateJob { get; set; }
        public HttpOperationResponse<Job> GetJobDetails { get; set; }
        
        //Reviews
        public HttpOperationResponse<IList<string>> CreateReview { get; set; }
        public HttpOperationResponse<Review> GetReview{ get; set; }

        //Workflows
        //public HttpOperationResponse<IList<string>> CreateWorkflow { get; set; }
        //public HttpOperationResponse<Workflow> GetWorkflowDetails { get; set; }
        public HttpOperationResponse AddFrames{ get; set; }
        public HttpOperationResponse<Frames> GetFrames { get; set; }
        public HttpOperationResponse PublishVideo{ get; set; }
        public HttpOperationResponse AddTranscripts { get; set; }
        public HttpOperationResponse AddTranscriptsModerationResult { get; set; }

        public APIErrorException InnerException { get; set; }
        public Exception StandardException { get; set; }
    }
}
