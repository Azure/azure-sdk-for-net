using System;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using System.Collections.Generic;
using ContentModeratorTests.Helpers;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.IO;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Test.HttpRecorder;

namespace ContentModeratorTests
{
        public class ReviewAPIs : TestBase
    {
        ContentModeratorClient client = null;
        ReviewResponses results = new ReviewResponses();
        JobId Job = new JobId();
        IList<string> ReviewIds = new List<string>();
        static ReviewAPI api;
        static ReviewStatus rvwStatus;
        static Content content;


        public ReviewAPIs()
        {
            TestSetUpConfiguration();
        }

        internal void TestCleanup()
        {
            TestCleanupConfiguration();
        }


        #region Jobs

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void CreateImageJob()
        {

            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    content = Content.IMAGE;
                    api = ReviewAPI.JOB_CREATE;
                    HttpMockServer.Initialize("ReviewAPIs", "CreateImageJob");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetReviewResponse(client, api, content, MIMETypes.JSON.GetDescription(), teamName, "Public", Workflow.IMAGE_WORKFLOW.GetDescription(), content.GetDescription() + " Review");

                    var job = results.CreateJob;
                    Assert.NotNull(job);
                    Assert.Equal(HttpStatusCode.OK, job.Response.StatusCode);
                    Job = job.Body;
                    Assert.NotNull(Job);
                    Assert.NotNull(Job.JobIdProperty);

                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        [Fact]
        public void CreateTextJob()
        {
            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {

                    content = Content.TEXT;
                    api = ReviewAPI.JOB_CREATE;
                    HttpMockServer.Initialize("ReviewAPIs", "CreateTextJob");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetReviewResponse(client, api, content, MIMETypes.JSON.GetDescription(), teamName, "Public", Workflow.TEXT_WORKFLOW.GetDescription(), content.GetDescription() + " Review");

                    var job = results.CreateJob;
                    Assert.NotNull(job);
                    Assert.Equal(HttpStatusCode.OK, job.Response.StatusCode);
                    Job = job.Body;
                    Assert.NotNull(Job);
                    Assert.NotNull(Job.JobIdProperty);

                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void GetImageJob()
        {

            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    //CreateImageJob();
                    //wait(2);
                    content = Content.IMAGE;
                    //string Jobid = Job.JobIdProperty;
                    api = ReviewAPI.JOB_GET;
                    HttpMockServer.Initialize("ReviewAPIs", "GetImageJob");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetReviewResponse(client, api, content, MIMETypes.JSON.GetDescription(), teamName, null, null, null, Jobid);
                    results = Constants.GetReviewResponse(client, api, content, MIMETypes.JSON.GetDescription(), teamName, null, null, null, "201712471f16b6733748a69e3cf66126d337fb");

                    var jobdetails = results.GetJobDetails;
                    Assert.NotNull(jobdetails);
                    var job = jobdetails.Body;
                    Assert.Equal("201712471f16b6733748a69e3cf66126d337fb", job.Id);
                    //Assert.Equal(Jobid, job.Id);
                    Assert.True(Helpers.Utilities.VerifyJob(Content.IMAGE, job), " " + TestBase.ErrorMessage);




                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void GetTextJob()
        {

            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    //CreateTextJob();
                    wait(2);
                    content = Content.TEXT;
                    //string Jobid = Job.JobIdProperty;
                    api = ReviewAPI.JOB_GET;
                    HttpMockServer.Initialize("ReviewAPIs", "GetTextJob");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetReviewResponse(client, api, content, MIMETypes.JSON.GetDescription(), teamName, null, null, null, Jobid);
                    results = Constants.GetReviewResponse(client, api, content, MIMETypes.JSON.GetDescription(), teamName, null, null, null, "201712b43444e4be70470b80bff6605a33e77d");

                    var jobdetails = results.GetJobDetails;
                    Assert.NotNull(jobdetails);
                    var job = jobdetails.Body;
                    Assert.Equal("201712b43444e4be70470b80bff6605a33e77d", job.Id);
                    //Assert.Equal(Jobid, job.Id);
                    Assert.True(Helpers.Utilities.VerifyJob(Content.TEXT, job), " " + TestBase.ErrorMessage);

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion

        #region Review

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void CreateImageReview()
        {
            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    api = ReviewAPI.REVIEW_CREATE;
                    HttpMockServer.Initialize("ReviewAPIs", "CreateImageReview");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetReviewResponse(client, api, Content.IMAGE, MIMETypes.JSON.GetDescription(), teamName, null);

                    var review = results.CreateReview;
                    Assert.NotNull(review);
                    Assert.Equal(HttpStatusCode.OK, review.Response.StatusCode);
                    ReviewIds = review.Body.ToList();
                    Assert.True(ReviewIds.Count > 0, "Image Reviewid did not get generated");
                    Assert.NotNull(ReviewIds[0]);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Fact]
        public void CreateTextReview()
        {
            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    api = ReviewAPI.REVIEW_CREATE;
                    HttpMockServer.Initialize("ReviewAPIs", "CreateTextReview");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetReviewResponse(client, api, Content.TEXT, MIMETypes.JSON.GetDescription(), teamName, null);

                    var review = results.CreateReview;
                    Assert.NotNull(review);
                    Assert.Equal(HttpStatusCode.OK, review.Response.StatusCode);
                    ReviewIds = review.Body.ToList();
                    Assert.True(ReviewIds.Count > 0, "Text Reviewid did not get generated");
                    Assert.NotNull(ReviewIds[0]);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Fact]
        public void CreateVideoReview()
        {
            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    api = ReviewAPI.REVIEW_CREATE;
                    HttpMockServer.Initialize("ReviewAPIs", "CreateVideoReview");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    results = Constants.GetReviewResponse(client, api, Content.VIDEO, MIMETypes.JSON.GetDescription(), teamName, null, null, null, null, null, rvwStatus);

                    var review = results.CreateReview;
                    Assert.NotNull(review);
                    Assert.Equal(HttpStatusCode.OK, review.Response.StatusCode);
                    ReviewIds = review.Body.ToList();
                    Assert.True(ReviewIds.Count > 0, "Video Reviewid did not get generated");
                    Assert.NotNull(ReviewIds[0]);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Fact]
        public void GetImageReview()
        {

            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    //CreateImageReview();
                    wait(2);
                    //string reviewid = ReviewIds.Count > 0 ? ReviewIds[0] : null;
                    api = ReviewAPI.REVIEW_GET;
                    HttpMockServer.Initialize("ReviewAPIs", "GetImageReview");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetReviewResponse(client, api, Content.IMAGE, MIMETypes.JSON.GetDescription(), teamName, null, null, null, null, ReviewIds[0]);
                    results = Constants.GetReviewResponse(client, api, Content.IMAGE, MIMETypes.JSON.GetDescription(), teamName, null, null, null, null, "201712if012516997aa4d19befb3129c1082c48");
                    Review r = results.GetReview.Body;
                    Assert.NotNull(r);
                    Assert.Equal(HttpStatusCode.OK, results.GetReview.Response.StatusCode);
                    Assert.Equal("201712if012516997aa4d19befb3129c1082c48", r.ReviewId);
                    //Assert.Equal(reviewid, r.ReviewId);
                    Assert.True(Helpers.Utilities.VerifyReview(Content.IMAGE, r), " " + TestBase.ErrorMessage);






                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Fact]
        public void GetTextReview()
        {
            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {

                    //CreateTextReview();
                    wait(2);
                    //string reviewid = ReviewIds.Count > 0 ? ReviewIds[0] : null;
                    api = ReviewAPI.REVIEW_GET;
                    HttpMockServer.Initialize("ReviewAPIs", "GetTextReview");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetReviewResponse(client, api, Content.TEXT, MIMETypes.JSON.GetDescription(), teamName, null, null, null, null, reviewid);
                    results = Constants.GetReviewResponse(client, api, Content.TEXT, MIMETypes.JSON.GetDescription(), teamName, null, null, null, null, "201712t9c7880135e834a939e4902ab82b5e97e");
                    Review r = results.GetReview.Body;
                    Assert.NotNull(r);
                    Assert.Equal(HttpStatusCode.OK, results.GetReview.Response.StatusCode);
                    Assert.Equal("201712t9c7880135e834a939e4902ab82b5e97e", r.ReviewId);
                    //Assert.Equal(reviewid, r.ReviewId);
                    Assert.True(Helpers.Utilities.VerifyReview(Content.TEXT, r), " " + TestBase.ErrorMessage);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void GetVideoReview()
        {
            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {

                    //CreateVideoReview();
                    wait(2);
                    //string reviewid = ReviewIds.Count > 0 ? ReviewIds[0] : null;
                    api = ReviewAPI.REVIEW_GET;
                    HttpMockServer.Initialize("ReviewAPIs", "GetVideoReview");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetReviewResponse(client, api, Content.VIDEO, MIMETypes.JSON.GetDescription(), teamName, null, null, null, null, reviewid);
                    results = Constants.GetReviewResponse(client, api, Content.VIDEO, MIMETypes.JSON.GetDescription(), teamName, null, null, null, null, "201712ve9d5eb16c9a247389ed371dbbf380b3c");
                    Review r = results.GetReview.Body;
                    Assert.NotNull(r);
                    Assert.Equal(HttpStatusCode.OK, results.GetReview.Response.StatusCode);
                    Assert.Equal("201712ve9d5eb16c9a247389ed371dbbf380b3c", r.ReviewId);
                    //Assert.Equal(reviewid, r.ReviewId);
                    Assert.True(Helpers.Utilities.VerifyReview(Content.VIDEO, r), " " + TestBase.ErrorMessage);

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region VideoReview
        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void AddURLFramesVideoReview()
        {
            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    rvwStatus = ReviewStatus.UNPUBLISHED;
                    //CreateVideoReview();

                    api = ReviewAPI.FRAMES_ADD;
                    HttpMockServer.Initialize("ReviewAPIs", "AddURLFramesVideoReview");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetVideoFramesReviewResponse(client, api, Content.VIDEO, MIMETypes.JSON.GetDescription(), teamName, ReviewIds[0]);
                    results = Constants.GetVideoFramesReviewResponse(client, api, Content.VIDEO, MIMETypes.JSON.GetDescription(), teamName, "201712v1f35675ed4d8457cbf84f4890ce59c58");

                    var review = results.AddFrames;
                    Assert.NotNull(review);
                    Assert.Equal(HttpStatusCode.NoContent, review.Response.StatusCode);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void AddZipFramesVideoReview()
        {
            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    rvwStatus = ReviewStatus.UNPUBLISHED;
                    //CreateVideoReview();
                    api = ReviewAPI.FRAMES_ADD;
                    HttpMockServer.Initialize("ReviewAPIs", "AddZipFramesVideoReview");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetVideoFramesReviewResponse(client, api, Content.VIDEO, MIMETypes.MULTI_PART_FORM_DATA.GetDescription(), teamName, ReviewIds[0], false);
                    results = Constants.GetVideoFramesReviewResponse(client, api, Content.VIDEO, MIMETypes.MULTI_PART_FORM_DATA.GetDescription(), teamName, "201712vc779930a65dc4de993d25bc21f53f928", false);

                    var review = results.AddFrames;
                    Assert.NotNull(review);
                    Assert.Equal(HttpStatusCode.NoContent, review.Response.StatusCode);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void GetFramesVideoReview()
        {
            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    rvwStatus = ReviewStatus.UNPUBLISHED;
                    //CreateVideoReview();
                    api = ReviewAPI.FRAMES_GET;
                    HttpMockServer.Initialize("ReviewAPIs", "GetFramesVideoReview");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetVideoFramesReviewResponse(client, api, Content.VIDEO, MIMETypes.JSON.GetDescription(), teamName, ReviewIds[0]);
                    results = Constants.GetVideoFramesReviewResponse(client, api, Content.VIDEO, MIMETypes.JSON.GetDescription(), teamName, "201712vbb90cbd620c0433dbecf70ad51e5563d");

                    var frames = results.GetFrames;
                    Assert.NotNull(frames);
                    Assert.Equal(HttpStatusCode.OK, frames.Response.StatusCode);
                    Assert.True(Helpers.Utilities.VerifyGetFrames(frames.Body), "Frames verification failed" + TestBase.ErrorMessage);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void PublishVideo()
        {
            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    rvwStatus = ReviewStatus.UNPUBLISHED;
                    //CreateVideoReview();
                    api = ReviewAPI.PUBLISH_VIDEO;
                    HttpMockServer.Initialize("ReviewAPIs", "PublishVideo");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetReviewResponse(client, api, Content.VIDEO, MIMETypes.JSON.GetDescription(), teamName, null, null, null, null, ReviewIds[0]);
                    results = Constants.GetReviewResponse(client, api, Content.VIDEO, MIMETypes.JSON.GetDescription(), teamName, null, null, null, null, "201712v0e8053914c4a465c97fe401789364c71");
                    var review = results.PublishVideo;
                    Assert.NotNull(review);
                    Assert.Equal(HttpStatusCode.NoContent, review.Response.StatusCode);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void AddTranscripts()
        {
            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    rvwStatus = ReviewStatus.UNPUBLISHED;
                    //CreateVideoReview();

                    api = ReviewAPI.TRANSCRIPTS_ADD;
                    using (Stream s = new FileStream(currentExecutingDirectory + @"\TestDataSources\vttF.vtt", FileMode.Open, FileAccess.Read))
                    {
                        HttpMockServer.Initialize("ReviewAPIs", "AddTranscripts");
                        client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());

                        //results = Constants.GetTranscriptReviewResponse(client, api, Content.VIDEO, MIMETypes.TEXT_PLAIN.GetDescription(), teamName, ReviewIds[0], s);
                        results = Constants.GetTranscriptReviewResponse(client, api, Content.VIDEO, MIMETypes.TEXT_PLAIN.GetDescription(), teamName, "201712v67b52dea7aa94a669c766af506fd55d5", s);
                    }
                    var addTransacripts = results.AddTranscripts;
                    Assert.NotNull(addTransacripts);
                    Assert.Equal(HttpStatusCode.NoContent, addTransacripts.Response.StatusCode);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Fact(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/6215")]
        public void AddTranscriptsModerationResult()
        {
            try
            {
                using (MockContext context = MockContext.Start("ReviewAPIs"))
                {
                    rvwStatus = ReviewStatus.UNPUBLISHED;
                    //CreateVideoReview();
                    AddTranscripts();

                    api = ReviewAPI.TRANSCRIPTS_ADD_MODERATION_RESULT;
                    HttpMockServer.Initialize("ReviewAPIs", "AddTranscriptsModerationResult");
                    client = Constants.GenerateClient(api, HttpMockServer.CreateInstance());
                    //results = Constants.GetReviewResponse(client, api, Content.VIDEO, MIMETypes.JSON.GetDescription(), teamName, null, null, null, null, ReviewIds[0]);
                    results = Constants.GetReviewResponse(client, api, Content.VIDEO, MIMETypes.JSON.GetDescription(), teamName, null, null, null, null, "201712v67b52dea7aa94a669c766af506fd55d5");

                    var review = results.AddTranscriptsModerationResult;
                    Assert.NotNull(review);
                    Assert.Equal(HttpStatusCode.NoContent, review.Response.StatusCode);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        #endregion










    }
}
