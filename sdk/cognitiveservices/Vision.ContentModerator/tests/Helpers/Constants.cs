using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Rest.Serialization;
using System.ComponentModel;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Microsoft.Azure.CognitiveServices.ContentModerator;
//using System.Net.Mime;
//using System.Configuration;
using ContentModeratorTests.Helpers;
using Microsoft.Rest;
using System.IO;
using Newtonsoft.Json;

namespace ContentModeratorTests
{
	#region Enums

	public enum DataRepresentation
	{
		[Description("URL")]
		URL,
		[Description("INLINE")]
		INLINE,
	}

	public enum MIMETypes
	{
		[Description("application/json")]
		JSON,
		[Description("image/gif")]
		IMAGE_GIF,
		[Description("image/jpeg")]
		IMAGE_JPEG,
		[Description("image/png")]
		IMAGE_PNG,
		[Description("image/bmp")]
		IMAGE_BMP,
		[Description("text/html")]
		TEXT_HTML,
		[Description("text/xml")]
		TEXT_XML,
		[Description("text/markdown")]
		TEXT_MARKDOWN,
		[Description("text/plain")]
		TEXT_PLAIN,
        [Description("multipart/form-data")]
        MULTI_PART_FORM_DATA

    }

    public enum Content
	{
		[Description("Image")]
		IMAGE,
		[Description("Text")]
		TEXT,
		[Description("Video")]
		VIDEO
	}

	public enum EntityType
	{
		[Description("Image List")]
		IMAGE_LIST,
		[Description("Term List")]
		TEXT_LIST,
		[Description("Image")]
		IMAGE,
		[Description("Term")]
		TEXT
	}

	public enum Operations
	{
		[Description("Add")]
		ADD,
		[Description("Update")]
		UPDATE,
		[Description("Get All")]
		GET_ALL,
		[Description("Get Details")]
		GET_DETAILS,
		[Description("Delete")]
		DELETE,
		[Description("Delete All")]
		DELETE_ALL,
		[Description("Refresh Search Index")]
		REFRESH_INDEX,
		[Description("Import")]
		IMPORT,
		[Description("Reset")]
		RESET
	}

	public enum ImageUrls
	{
		[Description("https://hashblobsm2.blob.core.windows.net/testimages/BMPOCR.bmp")]
		BMPOCR,
		[Description("https://hashblobsm2.blob.core.windows.net/testimages/GifOCR.gif")]
		GifOCR,
		[Description("https://hashblobsm2.blob.core.windows.net/testimages/JpegOCR.jpg")]
		JpegOCR,
		[Description("https://hashblobsm2.blob.core.windows.net/testimages/PNGOCR.png")]
		PNGOCR,

		[Description("https://hashblobsm2.blob.core.windows.net/testimages/BMPOCR_lessthan_128px.bmp")]
		BMPOCR_LT128PX,
		[Description("https://hashblobsm2.blob.core.windows.net/testimages/GifOCR_lessthan_128px.gif")]
		GifOCR_LT128PX,
		[Description("https://hashblobsm2.blob.core.windows.net/testimages/JpegOCR_lessthan_128px.jpg")]
		JpegOCR_LT128PX,
		[Description("https://hashblobsm2.blob.core.windows.net/testimages/PNGOCR_lessthan_128px.png")]
		PNGOCR_LT128PX,

		[Description("https://hashblobsm2.blob.core.windows.net/testimages/BMPOCR_greaterthan4MB.bmp")]
		BMPOCR_GT4MB,
		[Description("https://hashblobsm2.blob.core.windows.net/testimages/GifOCR_greaterthan4MB.gif")]
		GifOCR_GT4MB,
		[Description("https://hashblobsm2.blob.core.windows.net/testimages/JpegOCR_greaterthan4MB.jpg")]
		JpegOCR_GT4MB,
		[Description("https://hashblobsm2.blob.core.windows.net/testimages/PNGOCR_greaterthan4MB.png")]
		PNGOCR_GT4MB



	}

	public enum ImageFiles
	{
		[Description("BMPOCR.bmp")]
		BMPOCR,
		[Description("GifOCR.gif")]
		GifOCR,
		[Description("JpegOCR.jpg")]
		JpegOCR,
		[Description("PNGOCR.png")]
		PNGOCR,

		[Description("BMPOCR_lessthan_128px.bmp")]
		BMPOCR_LT128PX,
		[Description("GifOCR_lessthan_128px.gif")]
		GifOCR_LT128PX,
		[Description("JpegOCR_lessthan_128px.jpg")]
		JpegOCR_LT128PX,
		[Description("PNGOCR_lessthan_128px.png")]
		PNGOCR_LT128PX,

		[Description("BMPOCR_greaterthan4MB.bmp")]
		BMPOCR_GT4MB,
		[Description("GifOCR_greaterthan4MB.gif")]
		GifOCR_GT4MB,
		[Description("JpegOCR_greaterthan4MB.jpg")]
		JpegOCR_GT4MB,
		[Description("PNGOCR_greaterthan4MB.png")]
		PNGOCR_GT4MB
	}

	public enum ContentModeratorAPI
	{
		[Description("Create Image List")]
		CREATE_IMAGE_LIST,
		[Description("Update Image List Details")]
		UPDATE_IMAGE_LIST,
		[Description("Get All Image LIst")]
		GET_ALL_IMAGE_LIST,
		[Description("Get Details Image List")]
		GET_DETAILS_IMAGE_LIST,
		[Description("Delete Image List")]
		DELETE_IMAGE_LIST,
		[Description("Refresh Search Index Image List")]
		REFRESH_INDEX_IMAGE_LIST,

		[Description("Create Term List")]
		CREATE_TERM_LIST,
		[Description("Update Term List Details")]
		UPDATE_TERM_LIST,
		[Description("Get All Term List")]
		GET_ALL_TERM_LIST,
		[Description("Get Details Term List")]
		GET_DETAILS_TERM_LIST,
		[Description("Delete Term List")]
		DELETE_TERM_LIST,
		[Description("Refresh Search Index Term List")]
		REFRESH_INDEX_TERM_LIST,

		[Description("Add Image")]
		ADD_IMAGE,
		[Description("Delete Image")]
		DELETE_IMAGE,
		[Description("Delete All Image")]
		DELETE_ALL_IMAGE,
		[Description("Delete All Image")]
		GET_ALL_IMAGES,

		[Description("Add Term")]
		ADD_TERM,
		[Description("Delete Term")]
		DELETE_TERM,
		[Description("Delete All Term")]
		DELETE_ALL_TERM,
		[Description("Delete All Term")]
		GET_ALL_TERMS,

		[Description("Evaluate")]
		EVALUATE,
		[Description("Find Faces")]
		FIND_FACES,
		[Description("Match")]
		MATCH,
		[Description("OCR")]
		OCR,
		[Description("Screen Text")]
		SCREEN_TEXT,
		[Description("Detect Language")]
		DETECT_LANGUAGE
	}
	public enum ReviewAPI
	{
		[Description("Create Job")]
		JOB_CREATE,
		[Description("Get Job")]
		JOB_GET,

		[Description("Create Review")]
		REVIEW_CREATE,
		[Description("Get Review")]
		REVIEW_GET,

		[Description("Create Workflow")]
		WORKFLOW_CREATE,
		[Description("Create Update")]
		WORKFLOW_UPDATE,
		[Description("Get Workflow")]
		WORKFLOW_GET,
		[Description("Get All Workflows")]
		WORKFLOW_GETALL,

		[Description("Add Frames")]
		FRAMES_ADD,
		[Description("Get Frames")]
		FRAMES_GET,
		[Description("Publish Video")]
		PUBLISH_VIDEO,

		[Description("Add video transcripts")]
		TRANSCRIPTS_ADD,
		[Description("Add video transcript moderation result")]
		TRANSCRIPTS_ADD_MODERATION_RESULT
	}

	public enum ReviewStatus
	{
		[Description("Pending")]
		PENDING,
		[Description("Complete")]
		COMPLETE,
		[Description("UnPublished")]
		UNPUBLISHED,
		[Description("Publish")]
		PUBLISH
	}

	public enum Workflow
	{
		[Description("Default")]
		DEFAULT,
		[Description("BVTImageWorkflow")]
		IMAGE_WORKFLOW,
		[Description("BVTTextWorkflow")]
		TEXT_WORKFLOW,
		[Description("BVTVideoWorkflow")]
		VIDEO_WORKFLOW
	}



	public enum StandardReviewRequests
	{
		[Description(@"")]
		CREATE_TEXT_REVIEW,
		[Description(@"[   {     ""Type"": ""Image"",    ""Content"": ""https://pbs.twimg.com/media/BfopodJCUAAjmkU.jpg:large"",     ""ContentId"": ""ImageReview"",    ""Metadata"": [      {        ""Key"": ""KeyNote1"",        ""Value"": ""KeyNote2""      }    ]  }]")]
		CREATE_IMAGE_REVIEW,
		[Description(@"[ {    ""VideoFrames"": [   { ""Id"":""frm1"", ""Timestamp"":0, ""FrameImage"":""http://cvs-docs.azurewebsites.net/test-data/A1.jpg"",""Metadata"":[ {""Key"":""apiScoreVal"",""Value"":""0.206""}, {""Key"":""a"",""Value"":""False""}],""ReviewerResultTags"": [] },   { ""Id"":""frm2"",""Timestamp"":1,""FrameImage"":""http://cvs-docs.azurewebsites.net/test-data/A2.jpg"",""Metadata"":[ {""Key"":""apiScoreVal"",""Value"":""0.206""}, {""Key"":""a"",""Value"":""False""}],""ReviewerResultTags"": []},   { ""Id"":""frm3"",""Timestamp"":4,""FrameImage"":""http://cvs-docs.azurewebsites.net/test-data/A1.jpg"",""Metadata"":[ {""Key"":""apiScoreVal"",""Value"":""0.206""}, {""Key"":""a"",""Value"":""False""}],""ReviewerResultTags"": [] }],
		""Metadata"":[{""Key"":""apiScoreVal"", ""Value"":0.206},{""Key"":""a"",""Value"":""False"" },{""Key"":""racyScore"",""Value"":""0.151""}, {""Key"":""r"",""Value"":""False""},{""Key"":""ExternalId"",""Value"":""roar.mp4"" } ],""Type"":""Video"",""Content"":""https://rvdevmediaservicetest.streaming.mediaservices.windows.net/f7f073c3-66e5-436d-acee-827d3437df29/Roar.ism/manifest"",""ContentId"":""image02"",""Status"":""UnPublished"",""CallbackEndpoint"":"""", ""TimeScale"":""10""}]")]
		CREATE_VIDEO_REVIEW,
		[Description(@"[ 
			 { 
					""Timestamp"": ""1289"",
					""FrameImage"":""http://cvs-docs.azurewebsites.net/test-data/A2.jpg"", 
					""Metadata"": [ 
					  { 
					""Key"": ""apiScoreVal"",
					""Value"": ""0.206""
				  } 
					], 
					""ReviewerResultTags"": [
					]
			}, 
 
				  { 
					""Timestamp"": ""1389"", 
					""FrameImage"":""http://cvs-docs.azurewebsites.net/test-data/A2.jpg"", 
					""Metadata"": [
					  { 
					""Key"": ""apiScoreVal"",
					""Value"": ""0.206"" 
				  } 
					], 
					""ReviewerResultTags"": [
					] 
				  } 
				  ] ")]
		ADD_VIDEO_Frames,
		[Description(@"WEBVTT

		00:11.000 --> 00:13.000
		<v Roger Bingham>We are in New York City

		00:13.000 --> 00:16.000
		<v Roger Bingham>We're actually at the Lucern Hotel, just down the street

		00:16.000 --> 00:18.000
		<v Roger Bingham>from the American Museum of Natural History

		00:18.000 --> 00:20.000
		<v Roger Bingham>And with me is Neil deGrasse Tyson

		00:20.000 --> 00:22.000
		<v Roger Bingham>Astrophysicist, Director of the Hayden Planetarium")]
		ADD_VIDEO_TRANSCRIPTS,
		[Description(@"[
			{
				""TimeStamp"": ""123"",

				""Terms"":

				[
					{
						""Index"": 0,
						""Term"" : ""fck""

					}
				]
			},
			{
				""TimeStamp"": ""223"",
				""Terms"":
				[
					{
						""Index"": 0,
						""Term"" : ""shit""
					}
				]
			},
			{
				""TimeStamp"": ""333"",
				""Terms"":
				[
					{
						""Index"": 0,
						""Term"" : ""damn""
					}
				]
			},
		]")]
		ADD_VIDEO_TRANSCRIPTS_MODERATION_RESULT,
		[Description(@"")]
		CREATE_IMAGE_JOB,
		[Description(@"")]
		CREATE_TEXT_JOB,
		[Description(@"")]
		CREATE_VIDEO_JOB
	}

	#region ErrorMessageEnums

	public enum ImageErrorMessages
	{
		[Description("Image Size Error")]
		IMAGE_SIZE_ERROR
	}

	public enum TextErrorMessages
	{
		[Description("Screen Text")]
		SCREEN_TEXT,
		[Description("Detect Language")]
		DETECT_LANGUAGE
	}

	#endregion


	#endregion

	public  static class Constants
	{



        #region Declarations
        // variables
        public static string ContentModeratorSubscriptionKey= "", ReviewAPISubscriptionKey,TeamName="TeamNov2017";

        // optional Parameters
        public static BodyModel  AddImage, matchImage ;
        //for Add Transcripts
        public static Stream transcriptFile;
        //for Add Image
        public static string label;
        public static int tag, TermOffset=0, TermLimit = 50;
        public static List<string> tags;

		public static readonly string ImageForModeration = "https://pbs.twimg.com/media/BfopodJCUAAjmkU.jpg:large";
		public static readonly string TextForModeration = "Crappy";
		public static readonly string VideoForModeration = "https://rvdevmediaservicetest.streaming.mediaservices.windows.net/f7f073c3-66e5-436d-acee-827d3437df29/Roar.ism/manifest";
		public static List<VideoFrameBodyItemMetadataItem> vdoFrmMetadata = new List<VideoFrameBodyItemMetadataItem>()
		{
					new VideoFrameBodyItemMetadataItem("apiScoreVal","0.3"),
					new VideoFrameBodyItemMetadataItem("a","False"),
					new VideoFrameBodyItemMetadataItem("racyScore","0.2"),
					new VideoFrameBodyItemMetadataItem("ExternalId","Image"),
					new VideoFrameBodyItemMetadataItem("FrameCount","5")
		};
		public static List<CreateVideoReviewsBodyItemMetadataItem> createVdoReviewsMetadata = new List<CreateVideoReviewsBodyItemMetadataItem>()
		{
					new CreateVideoReviewsBodyItemMetadataItem("apiScoreVal","0.206"),
					new CreateVideoReviewsBodyItemMetadataItem("a","False"),
					new CreateVideoReviewsBodyItemMetadataItem("racyScore","0.151"),
					new CreateVideoReviewsBodyItemMetadataItem("ExternalId","Video1.mp4")

		};
		public static List<TranscriptModerationBodyItemTermsItem> transcriptTermsList = new List<TranscriptModerationBodyItemTermsItem>()
		{
					new TranscriptModerationBodyItemTermsItem(1,"gonna"),
					new TranscriptModerationBodyItemTermsItem(6,"crap"),
					new TranscriptModerationBodyItemTermsItem(7,"shit"),
					new TranscriptModerationBodyItemTermsItem(8,"damn")
		};


		#endregion

		#region ReviewAPIs

		public static List<TranscriptModerationBodyItem> GetTranscriptModerationBodyList(int transcriptCount = 3)
		{
			List<TranscriptModerationBodyItem> tList = new List<TranscriptModerationBodyItem>();
			try
			{
				int counter = transcriptCount;
				while (counter != 0)
				{
					TranscriptModerationBodyItem t = new TranscriptModerationBodyItem("10"+counter.ToString(), transcriptTermsList);
					tList.Add(t);
					counter--;
				}
				return tList;
			}
			catch (Exception)
			{
				throw;
			}
		}
		public static CreateVideoReviewsBodyItem GenerateVideoReviewBody(ReviewStatus rs = ReviewStatus.PENDING)
		{
			CreateVideoReviewsBodyItem cbi = new CreateVideoReviewsBodyItem();
			try
			{
				cbi.ContentId = $"roar - {Content.VIDEO.GetDescription() } Review";
				cbi.Content = VideoForModeration;
				cbi.Metadata = createVdoReviewsMetadata;
				cbi.Status = rs.GetDescription();
				cbi.VideoFrames = GetVideoFrames();
				cbi.Timescale = 30;
				cbi.CallbackEndpoint = "";
				return cbi;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public static List<CreateVideoReviewsBodyItemVideoFramesItem> GetVideoFrames(int count = 3)
		{
			List<CreateVideoReviewsBodyItemVideoFramesItem> cvri = new List<CreateVideoReviewsBodyItemVideoFramesItem>();
			try
			{
				cvri.Add(new CreateVideoReviewsBodyItemVideoFramesItem("frm1", 0, "http://cvs-docs.azurewebsites.net/test-data/A1.jpg", new List<CreateVideoReviewsBodyItemVideoFramesItemReviewerResultTagsItem>(), new List<CreateVideoReviewsBodyItemVideoFramesItemMetadataItem>() { new CreateVideoReviewsBodyItemVideoFramesItemMetadataItem("apiScoreVal", "0.206"), new CreateVideoReviewsBodyItemVideoFramesItemMetadataItem("a", "False") }));
				cvri.Add(new CreateVideoReviewsBodyItemVideoFramesItem("frm2", 15, "http://cvs-docs.azurewebsites.net/test-data/A2.jpg", new List<CreateVideoReviewsBodyItemVideoFramesItemReviewerResultTagsItem>(), new List<CreateVideoReviewsBodyItemVideoFramesItemMetadataItem>() { new CreateVideoReviewsBodyItemVideoFramesItemMetadataItem("apiScoreVal", "0.206"), new CreateVideoReviewsBodyItemVideoFramesItemMetadataItem("a", "False") }));
				cvri.Add(new CreateVideoReviewsBodyItemVideoFramesItem("frm4", 25, "http://cvs-docs.azurewebsites.net/test-data/A1.jpg", new List<CreateVideoReviewsBodyItemVideoFramesItemReviewerResultTagsItem>(), new List<CreateVideoReviewsBodyItemVideoFramesItemMetadataItem>() { new CreateVideoReviewsBodyItemVideoFramesItemMetadataItem("apiScoreVal", "0.206"), new CreateVideoReviewsBodyItemVideoFramesItemMetadataItem("a", "False") }));
				return cvri;
			}
			catch (Exception)
			{
				throw;
			}

		}

		public static List<VideoFrameBodyItem> GenerateFrames(bool isurl = true, int frameCount = 5)
		{
			List<VideoFrameBodyItem> fList = new List<VideoFrameBodyItem>();
			int counter = 0;
			try
			{
				string[] url = new string[] { "http://cvs-docs.azurewebsites.net/test-data/A2.jpg", ImageUrls.BMPOCR.GetDescription(), ImageUrls.GifOCR.GetDescription(), ImageUrls.JpegOCR.GetDescription(), ImageUrls.PNGOCR.GetDescription() };
                string[] OnlyImages = new string[] { "A2.jpg", ImageFiles.BMPOCR.GetDescription(), ImageFiles.GifOCR.GetDescription(), ImageFiles.JpegOCR.GetDescription(), ImageFiles.PNGOCR.GetDescription() };

                for (int i = 0; i < frameCount; i++)
				{
					vdoFrmMetadata.Find(x=> x.Key.Equals("ExternalId") ).Value = "Image" + i.ToString();
					VideoFrameBodyItem v = new VideoFrameBodyItem((i+2).ToString(),(isurl?url[counter]:OnlyImages[counter]),new List<VideoFrameBodyItemReviewerResultTagsItem>(), vdoFrmMetadata);

					if (counter >= 5)
						counter = 0;
					else
						counter++;
					fList.Add(v);
                }
				return fList;
			}
			catch (Exception)
			{
				throw;
			}

		}
		public static Body GenerateRequestBody()
		{
			Body b = new Body();
			try
			{
				b.Name = "test";
				return b;
			}
			catch (Exception e )
			{
				throw new Exception("Failed to generate request body"+ e.InnerException.Message);
			}
		}


		public static ContentModeratorClient GenerateClient(ReviewAPI api)
		{

			try
			{
				ContentModeratorClient client = new ContentModeratorClient(new ApiKeyServiceClientCredentials(ReviewAPISubscriptionKey));

                client.Endpoint = "https://southeastasia.api.cognitive.microsoft.com";

                return client;

			}
			catch (Exception)
			{
				throw;
			}
		}
        public static ContentModeratorClient GenerateClient(ReviewAPI api, DelegatingHandler handler)
        {

            try
            {
                ContentModeratorClient client = new ContentModeratorClient(new ApiKeyServiceClientCredentials(ReviewAPISubscriptionKey),handlers: handler);

                client.Endpoint = "https://southeastasia.api.cognitive.microsoft.com";
                return client;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public static ReviewResponses GetVideoFramesReviewResponse(ContentModeratorClient client, ReviewAPI api, Content reviewContentType, string contentType, string teamName, string reviewId,bool isUrl = true )
		{
			ReviewResponses rr = new ReviewResponses();
			Utilities u = new Utilities();
			Stream zipFramesStream;
            string s = @"
                [
                {""Timestamp"":""5"",""FrameImage"":""201708vc884ee3ad69e439eaaf5e57940c2f7a2_9.png"", ""Metadata"":[{""Key"":""adultScore"",""Value"":""0.0040786""},{""Key"":""a"",""Value"":""False""},{""Key"":""racyScore"",""Value"":""0.101146""},{""Key"":""r"",""Value"":""False""},{""Key"":""ExternalId"",""Value"":""testone.png""}],""ReviewerResultTags"":[], ""FrameImageBytes"":[]},
                {""Timestamp"":""6"",""FrameImage"":""201708vc884ee3ad69e439eaaf5e57940c2f7a2_29.png"",""Metadata"":[{""Key"":""adultScore"",""Value"":""0.0040786""},{""Key"":""a"",""Value"":""False""},{""Key"":""racyScore"",""Value"":""0.101146""},{""Key"":""r"",""Value"":""False""},{""Key"":""ExternalId"",""Value"":""testtwo.png""}],""ReviewerResultTags"":[], ""FrameImageBytes"":[]},
                {""Timestamp"":""7"",""FrameImage"":""201708vc884ee3ad69e439eaaf5e57940c2f7a2_41.png"",""Metadata"":[{""Key"":""adultScore"",""Value"":""0.0040786""},{""Key"":""a"",""Value"":""False""},{""Key"":""racyScore"",""Value"":""0.101146""},{""Key"":""r"",""Value"":""False""},{""Key"":""ExternalId"",""Value"":""testthree.png""}],""ReviewerResultTags"":[], ""FrameImageBytes"":[]},
                {""Timestamp"":""8"",""FrameImage"":""201708vc884ee3ad69e439eaaf5e57940c2f7a2_60.png"",""Metadata"":[{""Key"":""adultScore"",""Value"":""0.0040786""},{""Key"":""a"",""Value"":""False""},{""Key"":""racyScore"",""Value"":""0.101146""},{""Key"":""r"",""Value"":""False""},{""Key"":""ExternalId"",""Value"":""testfour.png""}],""ReviewerResultTags"":[], ""FrameImageBytes"":[]},
                {""Timestamp"":""9"",""FrameImage"":""201708vc884ee3ad69e439eaaf5e57940c2f7a2_72.png"",""Metadata"":[{""Key"":""adultScore"",""Value"":""0.0040786""},{""Key"":""a"",""Value"":""False""},{""Key"":""racyScore"",""Value"":""0.101146""},{""Key"":""r"",""Value"":""False""},{""Key"":""ExternalId"",""Value"":""testfive.png""}],""ReviewerResultTags"":[], ""FrameImageBytes"":[]}
                ]";

			try
			{

				zipFramesStream = new FileStream(Path.Combine(TestBase.currentExecutingDirectory, "RoarFrames.zip"), FileMode.Open, FileAccess.Read);
				switch (api)
				{
					case ReviewAPI.FRAMES_ADD:
						var tempaddFrames = isUrl?client.Reviews.AddVideoFrameUrlWithHttpMessagesAsync(reviewContentType.GetDescription(), teamName, reviewId, GenerateFrames()) :client.Reviews.AddVideoFrameStreamWithHttpMessagesAsync(reviewContentType.GetDescription(),teamName,reviewId, zipFramesStream, s.Replace(@"""""",@""""), 300); //JsonConvert.SerializeObject(GenerateFrames(false)[0])
                        u.WaitUntilCompleted(tempaddFrames);
						if (tempaddFrames.Exception != null)
						{
							APIErrorException ex = (APIErrorException)tempaddFrames.Exception.InnerException;
							throw ex;
						}
						if (tempaddFrames.Result != null)
							rr.AddFrames = tempaddFrames.Result;

						break;
					case ReviewAPI.FRAMES_GET:
						var tempGetFrames = client.Reviews.GetVideoFramesWithHttpMessagesAsync(teamName, reviewId,0,3);
						u.WaitUntilCompleted(tempGetFrames);
						if (tempGetFrames.Exception != null)
						{
							APIErrorException ex = (APIErrorException)tempGetFrames.Exception.InnerException;
							throw ex;
						}
						if (tempGetFrames.Result != null)
							rr.GetFrames = tempGetFrames.Result;

						break;
					default:
						break;
				}
				return rr;

			}
			catch (APIErrorException e)
			{
				rr.InnerException = e;
				return rr;
			}
			catch (Exception)
			{
				throw;
			}
		}


		public static ReviewResponses GetTranscriptReviewResponse(ContentModeratorClient client, ReviewAPI api, Content reviewContentType, string contentType, string teamName, string reviewId, Stream transcriptFileStream)
		{
            ReviewResponses rr = new ReviewResponses();
            Utilities u = new Utilities();

            try
            {
             transcriptFile = transcriptFileStream;
                return GetReviewResponse(client, api, reviewContentType, contentType, teamName, "public", null, null, null, reviewId);
            }
            catch (APIErrorException e)
            {
                rr.InnerException = e;
                return rr;
            }
            catch (Exception ee)
			{
                rr.StandardException = ee;
                return rr;
            }
		}

		public static ReviewResponses GetReviewResponse(ContentModeratorClient client, ReviewAPI api, Content reviewContentType, string contentType,  string teamName, string subTeamName,string workflowName = null, string contentId = null,string jobId = null,string reviewId = null, ReviewStatus rs = ReviewStatus.PENDING)
		{
			Utilities u = new Utilities();
			CreateReviewBodyItem c = new CreateReviewBodyItem();
			ReviewResponses rr = new ReviewResponses();
			TestBase.wait(2);
			//Create Job
			Microsoft.Azure.CognitiveServices.ContentModerator.Models.Content content = new Microsoft.Azure.CognitiveServices.ContentModerator.Models.Content();
			// For Create Review
			IList<CreateReviewBodyItem> crList = new List<CreateReviewBodyItem>();
			List<CreateReviewBodyItemMetadataItem> lst = new List<CreateReviewBodyItemMetadataItem>();
			lst.Add(new CreateReviewBodyItemMetadataItem("KeyNote1", "KeyNote2"));

			IList<CreateVideoReviewsBodyItem> cvrList = new List<CreateVideoReviewsBodyItem>();


			switch (reviewContentType)
			{
				case Content.IMAGE:
					crList.Add(new CreateReviewBodyItem(Content.IMAGE.GetDescription(), ImageForModeration, Content.IMAGE.GetDescription()+"Review", "", lst));
					content.ContentValue = ImageForModeration;
					break;
				case Content.TEXT:
					crList.Add(new CreateReviewBodyItem(Content.TEXT.GetDescription(), TextForModeration, Content.TEXT.GetDescription() + "Review", "", lst));
					content.ContentValue = TextForModeration;
					break;
				case Content.VIDEO:
					cvrList.Add(GenerateVideoReviewBody(rs));
					content.ContentValue = VideoForModeration;
					break;
				default:
					break;
			}

            try
            {
                switch (api)
                {
                    case ReviewAPI.JOB_CREATE:
                        var tempCreateJob = client.Reviews.CreateJobWithHttpMessagesAsync(teamName, reviewContentType.GetDescription(), contentId, workflowName, reviewContentType.GetDescription(), content);
                        u.WaitUntilCompleted(tempCreateJob);
                        if (tempCreateJob.Exception != null)
                        {
                            APIErrorException ex = (APIErrorException)tempCreateJob.Exception.InnerException;
                            throw ex;
                        }
                        if (tempCreateJob.Result != null)
                            rr.CreateJob = tempCreateJob.Result;
                        break;
                    case ReviewAPI.JOB_GET:
                        var tempGetJob = client.Reviews.GetJobDetailsWithHttpMessagesAsync(teamName, jobId);
                        u.WaitUntilCompleted(tempGetJob);
                        if (tempGetJob.Exception != null)
                        {
                            APIErrorException ex = (APIErrorException)tempGetJob.Exception.InnerException;
                            throw ex;
                        }
                        if (tempGetJob.Result != null)
                            rr.GetJobDetails = tempGetJob.Result;
                        break;
                    case ReviewAPI.REVIEW_CREATE:
                        var tempCreateReview = (reviewContentType != Content.VIDEO) ? client.Reviews.CreateReviewsWithHttpMessagesAsync(contentType, teamName, crList) : client.Reviews.CreateVideoReviewsWithHttpMessagesAsync(contentType, teamName, cvrList);

                        u.WaitUntilCompleted(tempCreateReview);
                        if (tempCreateReview.Exception != null)
                        {
                            APIErrorException ex = (APIErrorException)tempCreateReview.Exception.InnerException;
                            throw ex;
                        }
                        if (tempCreateReview.Result != null)
                            rr.CreateReview = tempCreateReview.Result;
                        break;
                    case ReviewAPI.REVIEW_GET:
                        var tempGetReview = client.Reviews.GetReviewWithHttpMessagesAsync(teamName, reviewId);
                        u.WaitUntilCompleted(tempGetReview);
                        if (tempGetReview.Exception != null)
                        {
                            APIErrorException ex = (APIErrorException)tempGetReview.Exception.InnerException;
                            throw ex;
                        }
                        if (tempGetReview.Result != null)
                            rr.GetReview = tempGetReview.Result;
                        break;
                    case ReviewAPI.WORKFLOW_CREATE:
                        break;
                    case ReviewAPI.WORKFLOW_UPDATE:
                        break;
                    case ReviewAPI.WORKFLOW_GET:
                        break;
                    case ReviewAPI.WORKFLOW_GETALL:
                        break;

                    case ReviewAPI.PUBLISH_VIDEO:
                        var tempPusblishVideo = client.Reviews.PublishVideoReviewWithHttpMessagesAsync(teamName, reviewId);
                        u.WaitUntilCompleted(tempPusblishVideo);
                        if (tempPusblishVideo.Exception != null)
                        {
                            APIErrorException ex = (APIErrorException)tempPusblishVideo.Exception.InnerException;
                            throw ex;
                        }
                        if (tempPusblishVideo.Result != null)
                            rr.PublishVideo = tempPusblishVideo.Result;

                        break;

                    case ReviewAPI.TRANSCRIPTS_ADD:
                        var tempAddTranscripts = client.Reviews.AddVideoTranscriptWithHttpMessagesAsync(teamName, reviewId, transcriptFile);
                        u.WaitUntilCompleted(tempAddTranscripts);
                        if (tempAddTranscripts.Exception != null)
                        {
                            APIErrorException ex = (APIErrorException)tempAddTranscripts.Exception.InnerException;
                            throw ex;
                        }
                        if (tempAddTranscripts.Result != null)
                            rr.AddTranscripts = tempAddTranscripts.Result;
                        break;
                    case ReviewAPI.TRANSCRIPTS_ADD_MODERATION_RESULT:
                        var tempAddTranscriptsModerationResult = client.Reviews.AddVideoTranscriptModerationResultWithHttpMessagesAsync(contentType, teamName, reviewId, GetTranscriptModerationBodyList());
                        u.WaitUntilCompleted(tempAddTranscriptsModerationResult);
                        if (tempAddTranscriptsModerationResult.Exception != null)
                        {
                            APIErrorException ex = (APIErrorException)tempAddTranscriptsModerationResult.Exception.InnerException;
                            throw ex;
                        }
                        if (tempAddTranscriptsModerationResult.Result != null)
                            rr.AddTranscriptsModerationResult = tempAddTranscriptsModerationResult.Result;
                        break;
                    default:
                        break;
                }
                return rr;
            }
            catch (APIErrorException e)
            {
                rr.InnerException = e;
                return rr;
            }
            catch (Exception ee)
            {
                rr.StandardException = ee;
                return rr;
            }
		}
		#endregion

		#region ContentModeratorAPIS


		public static ContentModeratorClient GenerateClient(ContentModeratorAPI api)
		{

			try
			{
				ContentModeratorClient client = new ContentModeratorClient(new ApiKeyServiceClientCredentials(ContentModeratorSubscriptionKey));
                client.Endpoint = "https://southeastasia.api.cognitive.microsoft.com";
                return client;

			}
			catch (Exception)
			{
				throw;
			}
		}

        public static ContentModeratorClient GenerateClient(ContentModeratorAPI api, DelegatingHandler handler)
        {

            try
            {
                ContentModeratorClient client = new ContentModeratorClient(new ApiKeyServiceClientCredentials(ContentModeratorSubscriptionKey),handlers: handler);
                client.Endpoint = "https://southeastasia.api.cognitive.microsoft.com";
                return client;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static BodyModel  GetImageURL(DataRepresentation dr, string value)
		{
			try
			{

				return new BodyModel (dr.GetDescription(), value);

			}
			catch (Exception)
			{
				throw;
			}


		}

		public static Body GetListBody(Content c)
		{
			Body b = new Body();
			try
			{
				Random r = new Random();
				string num = r.Next(0,1000).ToString();
				b.Name = $"BVT{c.GetDescription()}List" + num;
				b.Description = $"BVT{c.GetDescription()}List" + num;
                b.Metadata = new Dictionary<string, string>();
                b.Metadata["Key One"] = $"BVT{c.GetDescription()}ListKeyNote1" + num;
				b.Metadata["Key Two"] = $"BVT{c.GetDescription()}ListKeyNote2" + num;
				return b;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// This method is for TEXT moderator apis
		/// </summary>
		/// <param name="client"></param>
		/// <param name="api"></param>
		/// <param name="listid"></param>
		/// <param name="language"></param>
		/// <param name="contentType"></param>
		/// <param name="textContent"></param>
		/// <returns></returns>
		public static Responses GetTextResponse(ContentModeratorClient client, ContentModeratorAPI api, string listid, Stream textContent, string contentType = "text/plain", string language = default(string),bool? isAutoCorrect = false, bool? isPii = false, bool? isClassify = false)
		{
            Responses r = new Responses();
            Utilities u = new Utilities();
			try
			{
				//string tc = "Is this a crap email abcdef@abcd.com, phone: 6657789887, IP: 255.255.255.255, 1 Microsoft Way, Redmond, WA 98052 <HTML>HTML tags</HTML>";


				TestBase.wait(2);

				switch (api)
				{
					case ContentModeratorAPI.SCREEN_TEXT:
						var tempST = client.TextModeration.ScreenTextWithHttpMessagesAsync(contentType,textContent,language,isAutoCorrect,isPii,listid,isClassify);
                        u.WaitUntilCompleted(tempST);
                        if (tempST.Exception != null)
                        {
                            APIErrorException ex = (APIErrorException)tempST.Exception.InnerException;
                            throw ex;
                        }
                        if (tempST.Result != null)
							r.ScreenText = tempST.Result;
						break;
					case ContentModeratorAPI.DETECT_LANGUAGE:
						var tempDL = client.TextModeration.DetectLanguageWithHttpMessagesAsync(contentType,textContent);
                        u.WaitUntilCompleted(tempDL);
                        if (tempDL.Exception != null)
                        {
                            APIErrorException ex = (APIErrorException)tempDL.Exception.InnerException;
                            throw ex;
                        }
                        if (tempDL.Result != null)
							r.DetectLanguage = tempDL.Result;
						break;
					default:
						break;
				}
				return r;
			}
            catch (APIErrorException e)
            {
                r.InnerException = e;
                return r;
            }
            catch (Exception)
            {
                throw;
            }

		}

		/// <summary>
		/// This method is for Image Moderator apis
		/// </summary>
		/// <param name="client"></param>
		/// <param name="api"></param>
		/// <param name="listid"></param>
		/// <param name="language"></param>
		/// <param name="contentType"></param>
		/// <param name="isCacheImage"></param>
		/// <param name="Imageid"></param>
		/// <returns></returns>
		public static Responses GetImageResponse(ContentModeratorClient client, ContentModeratorAPI api, string listid,BodyModel imgUrl,  string contentType = "application/json", string language = "eng", bool isCacheImage = false, string Imageid = "", bool isEnchanced = true)
		{
			Responses r = new Responses();
			try
			{
				TestBase.wait(2);
				Utilities u = new Utilities();
				switch (api)
				{
					case ContentModeratorAPI.EVALUATE:
						var tempEval = client.ImageModeration.EvaluateUrlInputWithHttpMessagesAsync(contentType, imgUrl, isCacheImage);
						u.WaitUntilCompleted(tempEval);
						if (tempEval.Exception != null)
						{
							APIErrorException ex = (APIErrorException)tempEval.Exception.InnerException;
							throw ex;
						}
						if (tempEval.Result != null)
							r.Evaluate = tempEval.Result;
						break;
					case ContentModeratorAPI.FIND_FACES:
						var tempFF = client.ImageModeration.FindFacesUrlInputWithHttpMessagesAsync(contentType, imgUrl, isCacheImage);
						u.WaitUntilCompleted(tempFF);
						if (tempFF.Exception != null)
						{
							APIErrorException ex = (APIErrorException)tempFF.Exception.InnerException;
							throw ex;
						}
						if (tempFF.Result != null)
							r.FoundFaces = tempFF.Result;
						break;
					case ContentModeratorAPI.MATCH:
						var tempMI = client.ImageModeration.MatchUrlInputWithHttpMessagesAsync(contentType, imgUrl, listid, isCacheImage);
						u.WaitUntilCompleted(tempMI);
						if (tempMI.Exception != null)
						{
							APIErrorException ex = (APIErrorException)tempMI.Exception.InnerException;
							throw ex;
						}
						if (tempMI.Result != null)
							r.MatchImage = tempMI.Result;
						break;
					case ContentModeratorAPI.OCR:
						var tempOC = client.ImageModeration.OCRUrlInputWithHttpMessagesAsync(language, contentType, imgUrl, isCacheImage,isEnchanced);
						u.WaitUntilCompleted(tempOC);
						if (tempOC.Exception != null)
						{
							APIErrorException ex = (APIErrorException)tempOC.Exception.InnerException;
							throw ex;
						}
						if (tempOC.Result != null)
							r.OCR = tempOC.Result;
						break;
					default:
						break;
				}
				return r;
			}
			catch (APIErrorException e)
			{
				r.InnerException = e;
				return r;
			}

		}

		/// <summary>
		/// This method is for Image Moderator apis with File Input
		/// </summary>
		/// <param name="client"></param>
		/// <param name="api"></param>
		/// <param name="listid"></param>
		/// <param name="language"></param>
		/// <param name="contentType"></param>
		/// <param name="isCacheImage"></param>
		/// <param name="Imageid"></param>
		/// <returns></returns>
		public static Responses GetImageResponseRaw(ContentModeratorClient client, ContentModeratorAPI api, string listid, Stream imgStream,  string contentType = "application/json", string language = "eng", bool isCacheImage = false, string Imageid = "")
		{
			Responses r = new Responses();
			Utilities u = new Utilities();
			TestBase.wait(2);

   try
            {
                switch (api)
				{
                    case ContentModeratorAPI.ADD_IMAGE:
                        var tempAddImage = client.ListManagementImage.AddImageFileInputWithHttpMessagesAsync(listid, imgStream, tag,label);
                        u.WaitUntilCompleted(tempAddImage);
                        if (tempAddImage.Exception != null)
                        {
                            APIErrorException ex = (APIErrorException)tempAddImage.Exception.InnerException;
                            throw ex;
                        }
                        if (tempAddImage.Result != null)
                            r.AddImage = tempAddImage.Result;
                        break;

                    case ContentModeratorAPI.EVALUATE:
						var tempEval = client.ImageModeration.EvaluateFileInputWithHttpMessagesAsync(imgStream, isCacheImage);
						u.WaitUntilCompleted(tempEval);
						if (tempEval.Exception != null)
						{
							APIErrorException ex = (APIErrorException)tempEval.Exception.InnerException;
							throw ex;
						}
						if (tempEval.Result != null)
							r.Evaluate = tempEval.Result;
						break;
					case ContentModeratorAPI.FIND_FACES:
						var tempFF = client.ImageModeration.FindFacesFileInputWithHttpMessagesAsync( imgStream, isCacheImage);
						u.WaitUntilCompleted(tempFF);
						if (tempFF.Exception != null)
						{
							APIErrorException ex = (APIErrorException)tempFF.Exception.InnerException;
							throw ex;
						}
						if (tempFF.Result != null)
							r.FoundFaces = tempFF.Result;
						break;
					case ContentModeratorAPI.MATCH:
						var tempMI = client.ImageModeration.MatchFileInputWithHttpMessagesAsync( imgStream,listid, isCacheImage);
						u.WaitUntilCompleted(tempMI);
						if (tempMI.Exception != null)
						{
							APIErrorException ex = (APIErrorException)tempMI.Exception.InnerException;
							throw ex;
						}
						if (tempMI.Result != null)
							r.MatchImage = tempMI.Result;
						break;
					case ContentModeratorAPI.OCR:
						var tempOC = client.ImageModeration.OCRFileInputWithHttpMessagesAsync(language, imgStream, isCacheImage);
						u.WaitUntilCompleted(tempOC);
						if (tempOC.Exception != null)
						{
							APIErrorException ex = (APIErrorException)tempOC.Exception.InnerException;
							throw ex;
						}
						if (tempOC.Result != null)
							r.OCR = tempOC.Result;
						break;
					default:
						break;
				}

				return r;

			}
			catch (APIErrorException e)
			{
				r.InnerException = e;
				return r;
			}
			catch (Exception)
			{

				throw;
			}
		}



		/// <summary>
		/// This method is for Listmanagement apis
		/// </summary>
		/// <param name="client"></param>
		/// <param name="api"></param>
		/// <param name="listid"></param>
		/// <param name="language"></param>
		/// <param name="contentType"></param>
		/// <param name="isCacheImage"></param>
		/// <param name="Imageid"></param>
		/// <returns></returns>
		public static Responses GetResponse(ContentModeratorClient client,ContentModeratorAPI api,string listid, string contentType = "application/json", string language = "eng",string term = "sucks!" ,bool isCacheImage= false, string Imageid = "")
		{
			Responses r = new Responses();
			Utilities u = new Utilities();

			try

			{
				TestBase.wait(2);
			switch (api)
				{
                    // ImageListsManagement
                    case ContentModeratorAPI.CREATE_IMAGE_LIST:
						var tempCI = client.ListManagementImageLists.CreateWithHttpMessagesAsync(contentType, GetListBody(Content.IMAGE));
                        if (tempCI.Exception != null)
                        {
                            APIErrorException ex = (APIErrorException)tempCI.Exception.InnerException;
                            throw ex;
                        }
                        if (tempCI.Result != null)
							r.CreateImageList = tempCI.Result;
						break;
					case ContentModeratorAPI.UPDATE_IMAGE_LIST:
						var tempUI = client.ListManagementImageLists.UpdateWithHttpMessagesAsync(listid, contentType, GetListBody(Content.IMAGE));
						if (tempUI.Result != null)
							r.UpdateImageList = tempUI.Result;
						break;
					case ContentModeratorAPI.GET_ALL_IMAGE_LIST:
						var tempResponse = client.ListManagementImageLists.GetAllImageListsWithHttpMessagesAsync();
						if (tempResponse.Result != null)
							r.GetAllImageLists = tempResponse.Result;
						break;
					case ContentModeratorAPI.GET_DETAILS_IMAGE_LIST:
						var tempGIL = client.ListManagementImageLists.GetDetailsWithHttpMessagesAsync(listid);
						if (tempGIL.Result != null)
							r.GetDetailsImageList = tempGIL.Result;
						break;
					case ContentModeratorAPI.DELETE_IMAGE_LIST:
						var tempDIL = client.ListManagementImageLists.DeleteWithHttpMessagesAsync(listid);
						if (tempDIL.Result != null)
							r.DeleteImageLists = tempDIL.Result;
						break;
					case ContentModeratorAPI.REFRESH_INDEX_IMAGE_LIST:
						var tempRIL = client.ListManagementImageLists.RefreshIndexMethodWithHttpMessagesAsync(listid);
						if (tempRIL.Result != null)
							r.RefreshIndexImageList = tempRIL.Result;
						break;

                    // TermListsManagement
					case ContentModeratorAPI.CREATE_TERM_LIST:
						var tempCTL = client.ListManagementTermLists.CreateWithHttpMessagesAsync(contentType, GetListBody(Content.TEXT));
						if (tempCTL.Result != null)
							r.CreateTermList = tempCTL.Result;
						break;
					case ContentModeratorAPI.UPDATE_TERM_LIST:
						var tempUTL = client.ListManagementTermLists.UpdateWithHttpMessagesAsync(listid, contentType, GetListBody(Content.TEXT));
						if (tempUTL.Result != null)
							r.UpdateTermList = tempUTL.Result;
						break;
					case ContentModeratorAPI.GET_ALL_TERM_LIST:
						var tempGTL = client.ListManagementTermLists.GetAllTermListsWithHttpMessagesAsync();
                        if (tempGTL.Exception != null)
                        {
                            APIErrorException ex = (APIErrorException)tempGTL.Exception.InnerException;
                            throw ex;
                        }
                        if (tempGTL.Result != null)
							r.GetAllTermLists = tempGTL.Result;
						break;
					case ContentModeratorAPI.GET_DETAILS_TERM_LIST:
						var tempGDTL = client.ListManagementTermLists.GetDetailsWithHttpMessagesAsync(listid);
						if (tempGDTL.Result != null)
							r.GetDetailsTermList = tempGDTL.Result;
						break;
					case ContentModeratorAPI.DELETE_TERM_LIST:
						var tempDTL = client.ListManagementTermLists.DeleteWithHttpMessagesAsync(listid);
						if (tempDTL.Result != null)
							r.DeleteTermLists = tempDTL.Result;
						break;
					case ContentModeratorAPI.REFRESH_INDEX_TERM_LIST:
						var tempRTL = client.ListManagementTermLists.RefreshIndexMethodWithHttpMessagesAsync(listid, language);
						if (tempRTL.Result != null)
							r.RefreshIndexTermList = tempRTL.Result;
						break;
                    //ListManagementImage
					case ContentModeratorAPI.ADD_IMAGE:
						var tempAI = client.ListManagementImage.AddImageUrlInputWithHttpMessagesAsync(listid, contentType, AddImage,tag,label);
						u.WaitUntilCompleted(tempAI);
						if (tempAI.Exception != null)
						{
							APIErrorException ex = (APIErrorException)tempAI.Exception.InnerException;
							throw ex;
						}
						if (tempAI.Result != null)
							r.AddImage = tempAI.Result;
						break;
					case ContentModeratorAPI.DELETE_IMAGE:
						var tempDI = client.ListManagementImage.DeleteImageWithHttpMessagesAsync(listid, Imageid);
						u.WaitUntilCompleted(tempDI);
						if (tempDI.Result != null)
							r.DeleteImage = tempDI.Result;
						break;
					case ContentModeratorAPI.DELETE_ALL_IMAGE:
						var tempDAI = client.ListManagementImage.DeleteAllImagesWithHttpMessagesAsync(listid);
						u.WaitUntilCompleted(tempDAI);
						if (tempDAI.Result != null)
							r.DeleteImages = tempDAI.Result;
						break;
					case ContentModeratorAPI.GET_ALL_IMAGES:
						var tempGAI = client.ListManagementImage.GetAllImageIdsWithHttpMessagesAsync(listid);
						if (tempGAI.Result != null)
							r.GetAllImages = tempGAI.Result;
						break;


                    //Listmanagement Term
					case ContentModeratorAPI.ADD_TERM:
						var tempAT = client.ListManagementTerm.AddTermWithHttpMessagesAsync(listid, term, language);
						if (tempAT.Result != null)
							r.AddTerm = tempAT.Result;
						break;
					case ContentModeratorAPI.DELETE_TERM:
						var tempDT = client.ListManagementTerm.DeleteTermWithHttpMessagesAsync(listid, term, language);
						if (tempDT.Result != null)
							r.DeleteTerm = tempDT.Result;
						break;
					case ContentModeratorAPI.DELETE_ALL_TERM:
						var tempDAT = client.ListManagementTerm.DeleteAllTermsWithHttpMessagesAsync(listid, language);
						if (tempDAT.Result != null)
							r.DeleteTerms = tempDAT.Result;
						break;
					case ContentModeratorAPI.GET_ALL_TERMS:
						var tempGAT = client.ListManagementTerm.GetAllTermsWithHttpMessagesAsync(listid, language,TermOffset, TermLimit);
						if (tempGAT.Result != null)
							r.GetAllTerms = tempGAT.Result;
						break;


					default:
						break;
				}

				return r;
			}
			catch (APIErrorException ee)
			{
				r.InnerException = ee;
				return r;
			}
			catch (Exception)
			{
				throw;
			}

		}

		#endregion
	}
}
