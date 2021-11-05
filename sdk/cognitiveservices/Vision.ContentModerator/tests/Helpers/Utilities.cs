using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Rest.Serialization;
using Microsoft.Azure.CognitiveServices.ContentModerator.Models;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using System.Threading;
using System.IO;
using System.Configuration;
using System.Reflection;
//using d = System.Drawing;
using ContentModeratorTests.Data;
using Newtonsoft.Json;
using Xunit;

namespace ContentModeratorTests.Helpers
{
    public class Utilities
    {
        public Utilities(){}

        public void WaitUntilCompleted(Task tsk)
        {
            while (!tsk.IsCompleted)
                Thread.Sleep(1000);
        }


        public static string GetCorrectedDeploymentDirectory(string path)
        {
            if (path.Contains("TestResults"))
            {
                int startIndex = path.IndexOf("TestResults"), LastIndex = path.IndexOf(@"\Out");
                LastIndex = LastIndex==-1?path.IndexOf(@"\out"):LastIndex;
                string sToReplace = path.Substring(startIndex + 11, LastIndex +4 - startIndex - 11);

                path = path.Replace(sToReplace, "").Replace("TestResults", @"CMTests");
            }

            return path;
        }


        public static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private static void SetObjectProperty(string propertyName, string value, object obj)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            // make sure object has the property we are after
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(obj, value, null);
            }
        }

        public static string GetContentTypeByFile(string filenameWithExtension)
        {
            try
            {
                string contentType = MIMETypes.IMAGE_JPEG.GetDescription();
                if(filenameWithExtension.Contains(".jpg") || filenameWithExtension.Contains(".jpeg"))
                     contentType = MIMETypes.IMAGE_JPEG.GetDescription();
                if (filenameWithExtension.Contains(".bmp"))
                    contentType = MIMETypes.IMAGE_BMP.GetDescription();
                if (filenameWithExtension.Contains(".gif"))
                    contentType = MIMETypes.IMAGE_GIF.GetDescription();
                if (filenameWithExtension.Contains(".png"))
                    contentType = MIMETypes.IMAGE_PNG.GetDescription();
                if (filenameWithExtension.Contains(".tif") || filenameWithExtension.Contains(".tiff"))
                    contentType = "image\tiff";

                return contentType;
            }
            catch (Exception)
            {
                throw new Exception("Unable to file content Type");
            }
        }

        public static string GetDirectoryByFile(string fileName) => fileName.Contains("128px") ? @"TestDataSources\LT128pxImages\" : (fileName.Contains("4MB") ? @"TestDataSources\GT4MBImages\" : @"TestDataSources\NormalImages\");

        public static bool VerifyImageListContents(Body expected, ImageList actual)
        {
            try
            {
                return expected.Name.Equals(actual.Name, StringComparison.InvariantCultureIgnoreCase)
                    && expected.Metadata["Key One"].Equals(actual.Metadata["Key One"], StringComparison.InvariantCultureIgnoreCase)
                    && expected.Metadata["Key Two"].Equals(actual.Metadata["Key Two"], StringComparison.InvariantCultureIgnoreCase);
            }
            catch (Exception e)
            {
                throw new Exception("Unable to verify Image list correctness. Error:" + e.InnerException.Message);
            }

        }

        public static bool VerifyImageListContents(ImageList expected, ImageList actual)
        {
            try
            {
                return expected.Id == Convert.ToDouble(actual.Id)
                    && expected.Name.Equals(actual.Name, StringComparison.InvariantCultureIgnoreCase)
                    && expected.Metadata["Key One"].Equals(actual.Metadata["Key One"], StringComparison.InvariantCultureIgnoreCase)
                    && expected.Metadata["Key Two"].Equals(actual.Metadata["Key Two"], StringComparison.InvariantCultureIgnoreCase);
            }
            catch (Exception e)
            {
                throw new Exception("Unable to verify Image list correctness. Error:" + e.InnerException.Message);
            }

        }

        public static bool VerifyTermListContents(Body expected, TermList actual)
        {
            try
            {
                return expected.Name.Equals(actual.Name, StringComparison.InvariantCultureIgnoreCase)
                    && expected.Metadata["Key One"].Equals(actual.Metadata["Key One"], StringComparison.InvariantCultureIgnoreCase)
                    && expected.Metadata["Key Two"].Equals(actual.Metadata["Key Two"], StringComparison.InvariantCultureIgnoreCase);
            }
            catch (Exception e)
            {
                throw new Exception("Unable to verify Term list correctness. Error:" + e.InnerException.Message);
            }

        }

        public static bool VerifyTermListContents(TermList expected, TermList actual)
        {
            try
            {
                return expected.Id == Convert.ToDouble(actual.Id)
                    && expected.Name.Equals(actual.Name, StringComparison.InvariantCultureIgnoreCase)
                    && expected.Metadata["Key One"].Equals(actual.Metadata["Key One"], StringComparison.InvariantCultureIgnoreCase)
                    && expected.Metadata["Key Two"].Equals(actual.Metadata["Key Two"], StringComparison.InvariantCultureIgnoreCase);
            }
            catch (Exception e)
            {
                throw new Exception("Unable to verify Term list correctness. Error:" + e.InnerException.Message);
            }

        }

        public static bool VerifyRefreshIndex(RefreshIndex b, bool isContentId = true, bool isTrackingid = true, bool isStatus = true, bool isAdvancedInfo = false)
        {
            bool isExpected = false;
            try
            {

                if (isContentId == (b.ContentSourceId != null))
                    if (isTrackingid == (b.TrackingId != null))
                        if (isStatus == (b.Status.Code == 3000))
                            if (isAdvancedInfo == (b.AdvancedInfo.Count != 0))
                                isExpected = true;

                return isExpected;
            }
            catch (Exception e)
            {

                throw new Exception("Unable to verify Status object. Error:" + e.InnerException.Message);
            }
        }


        public static bool VerifyEvaluate(Evaluate eval, bool isCacheImage = false)
        {
            string error = "";
            try
            {
                if (eval.AdultClassificationScore == null || eval.AdultClassificationScore == 0.0)
                    error = "Adult Classification Score is null or 0.0";
                if (eval.IsImageAdultClassified == null )
                    error += "IsImageAdultClassification is null ";
                if (eval.RacyClassificationScore == null || eval.RacyClassificationScore == 0.0)
                    error += "RacyClassificationScore is null or 0.0 ";
                if (eval.IsImageRacyClassified == null)
                    error += "IsImageRacyClassified is null ";
                if (eval.Result == null)
                    error += "Result is null ";
                if (!VerifyStatus(eval.Status))
                    error += TestBase.ErrorMessage;
                if (eval.TrackingId == null)
                    error += "TrackingId is null ";
                if (eval.AdvancedInfo == null)
                    error += "Advanced Info is null ";

                if (isCacheImage)
                    VerifyCacheId(isCacheImage, eval.CacheID);

                TestBase.ErrorMessage = error;
                return string.IsNullOrEmpty(TestBase.ErrorMessage);
            }
            catch (Exception e)
            {
                TestBase.ErrorMessage += "Unable to verify the Evaulate Result. Error:" + e.InnerException.Message;
                return false;
            }
        }


        public static bool VerifyFoundFaces(FoundFaces ff, bool isCacheImage = false)
        {
            string error = "";
            try
            {
                if (isCacheImage)
                    VerifyCacheId(isCacheImage, ff.CacheId);

                if (ff.Faces == null)
                    error = "Faces object is null ";
                if (ff.Count == null)
                    error += "No faces detected";
                if (ff.Result == null)
                    error += "Result is null";
                if (!VerifyStatus(ff.Status))
                    error += TestBase.ErrorMessage;
                if (ff.TrackingId == null)
                    error += "TrackingId is null";
                if (ff.AdvancedInfo == null)
                    error += "Advanced Info is null";

                TestBase.ErrorMessage = error;
                return string.IsNullOrEmpty(TestBase.ErrorMessage);
            }
            catch (Exception e)
            {
                TestBase.ErrorMessage += "Unable to verify the Find Faces Result. Error:" + e.InnerException.Message;
                return false;
            }
        }

        public static bool VerifyOCR(OCR ocr, bool isCacheImage = false,bool isEnhanced = false)
        {
            string error = "";
            try
            {
                if (isCacheImage)
                    VerifyCacheId(isCacheImage, ocr.CacheId);

                if (ocr.Candidates == null)
                    error += "Candidates object is null ";

                if (isEnhanced)
                    if (ocr.Candidates.Count <= 0)
                        error += "Candidate(s) details not populated.";

                if (ocr.Language == null)
                    error += "Language is null ";
                if (ocr.Metadata == null)
                    error += "Metadata is null";
                if (!VerifyStatus(ocr.Status))
                    error += TestBase.ErrorMessage;
                if (ocr.Text == null)
                    error += "Text is null";
                if (ocr.TrackingId == null)
                    error += "Trackingid are null";

                TestBase.ErrorMessage = error;
                return string.IsNullOrEmpty(TestBase.ErrorMessage);
            }
            catch (Exception e)
            {
                TestBase.ErrorMessage += "Unable to verify the Evaulate Result. Error:" + e.InnerException.Message;
                return false;
            }
        }

        public static bool VerifyMatchResponse(MatchResponse mat, bool isCacheImage = false)
        {
            string error = "";
            try
            {
                if (isCacheImage)
                    VerifyCacheId(isCacheImage, mat.CacheID);

                if (mat.IsMatch == null)
                    error += "IsMatch is null";
                if (mat.Matches == null)
                    error += "Matches object is null";
                else
                    {
                    foreach (Match m in mat.Matches)
                    {
                        if (m.MatchId == null) error += "MatchId is null";
                        if (m.Score == null) error += "Score is null";
                        if (m.Source == null) error += "Source is null";
                        if (m.MatchId == null) error += "MatchId is null";
                    }
                }
                if (!VerifyStatus(mat.Status))
                    error += TestBase.ErrorMessage;
                if (mat.TrackingId == null)
                    error += "Trackingid is null";

                TestBase.ErrorMessage = error;
                return string.IsNullOrEmpty(TestBase.ErrorMessage);
            }
            catch (Exception e)
            {
                TestBase.ErrorMessage += "Unable to verify the Match response . Error:" + e.InnerException.Message;
                return false;
            }
        }

        public static bool VerifyDetectLanguage(DetectedLanguage dl)
        {

            string error = "";
            try
            {
                if (dl.DetectedLanguageProperty == null)
                    error += "Detected Language is null";
                if (!VerifyStatus(dl.Status))
                    error += TestBase.ErrorMessage;
                if (dl.TrackingId == null)
                    error += "Trackingid is null";

                TestBase.ErrorMessage = error;
                return string.IsNullOrEmpty(error);
            }
            catch (Exception e)
            {
                TestBase.ErrorMessage += "Unable to verify the detect language response . Error:" + e.InnerException.Message;
                return false;
            }


        }

        public static bool VerifyScreenText(Screen s,bool isAutoCorrect = false, bool isPII = false, bool isClassify = false)
        {

            string error = "";
            try
            {
                //if (s.Misrepresentation == null)
                //    error += " Misrepresentation is null";

                if (isAutoCorrect)
                {
                    if (s.NormalizedText.Equals(s.OriginalText, StringComparison.InvariantCultureIgnoreCase))
                        error += " Autocorrect did not happen.";
                    if (string.IsNullOrEmpty(s.AutoCorrectedText))
                        error += " Autocorrected Text property is null or empty";
                }
                if (isPII)
                    if (s.PII == null)
                        error += " PII is null";
                    else
                    {
                        if (s.PII.Email == null)
                            error += " PII.Email is null";
                        if (s.PII.IPA == null)
                            error += " PII.IPA is null";
                        if (s.PII.Phone == null)
                            error += " PII.Phone is null";
                        if (s.PII.Address == null)
                            error += " PII.Address is null";
                    }

                if (isClassify)
                    if (s.Classification == null)
                        error = " Classification is null";
                    else
                    {
                        if (s.Classification.Category1 == null)
                            error += " Classification.Category1 Score is null";
                        if (s.Classification.Category2 == null)
                            error += " Classification.Category2 Score is null";
                        if (s.Classification.Category3== null)
                            error += " Classification.Category3 Score is null";
                        if (s.Classification.ReviewRecommended == null)
                            error += " Classification.ReviewRecommended is null";
                    }

                if (s.Language == null)
                    error += " Language is null";
                if (s.NormalizedText == null)
                    error += " Normal Text  is null";
                if (s.OriginalText == null)
                    error += " Original Text is null";

                if (s.Terms == null)
                    error += " Terms object is null";
                else
                {
                    if (s.Terms.Count > 0)
                    {
                        if (s.Terms.Any(x => (x.Index == null || x.OriginalIndex == null || x.ListId == null || x.Term == null)))
                            error += " Terms metadata Index or Original index or listId or term is null";
                    }

                }
                if (!VerifyStatus(s.Status))
                    error += TestBase.ErrorMessage;
                if (s.TrackingId == null)
                    error += " Trackingid is null";

                TestBase.ErrorMessage = error;
                return string.IsNullOrEmpty(error);
            }
            catch (Exception e)
            {
                TestBase.ErrorMessage += "Unable to verify the screentext response . Error:" + e.InnerException.Message;
                return false;
            }


        }


        public static bool VerifyAddImageResponse(Image img)
        {
            string error = "";
            try
            {
                if (img.ContentId== null)
                    error += "ContentId is null";
                if (!VerifyStatus(img.Status))
                    error += TestBase.ErrorMessage;
                if (img.TrackingId == null)
                    error += "Trackingid is null";
                if (img.AdditionalInfo == null)
                    error += "Aditional Info is null";

                TestBase.ErrorMessage = error;
                return string.IsNullOrEmpty(error);
            }
            catch (Exception e)
            {
                TestBase.ErrorMessage += "Unable to verify the detect language response . Error:" + e.InnerException.Message;
                return false;
            }




        }


        public static bool VerifyCacheId(bool iscacheImage, string cacheid)
        {
            string error = "";
            if (!string.IsNullOrEmpty(cacheid) != iscacheImage)
                error = $"Cache id is mismatch. IsCacheImage :{iscacheImage} Cacheid:{cacheid}";
            TestBase.ErrorMessage += error;
            return string.IsNullOrEmpty(error);
        }


        public static bool VerifyStatus(Status s)
        {
            string error = "";
            try
            {
                if (s != null)
                {
                    if (s.Code != 3000)
                        error += $"Status code mismatch . Actual<{s.Code}> Expected <'3000'>";
                    if (s.Description != "OK")
                        error += $"Exception occures. Actual<{s.Description}> Expected <'OK'>";
                    if (!string.IsNullOrEmpty(s.Exception))
                        error += $"Exception occured. Actual<{s.Exception}> Expected <null>";
                }
                else
                    error += "Status is null";

                TestBase.ErrorMessage = error;
                return string.IsNullOrEmpty(error);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static bool VerifyBadRequestResponse(BadRequestResponse br,ContentModeratorAPI api)
        {
            string error = "";
            try
            {
                switch (api)
                {
                    case ContentModeratorAPI.CREATE_IMAGE_LIST:
                        break;
                    case ContentModeratorAPI.UPDATE_IMAGE_LIST:
                        break;
                    case ContentModeratorAPI.GET_ALL_IMAGE_LIST:
                        break;
                    case ContentModeratorAPI.GET_DETAILS_IMAGE_LIST:
                        break;
                    case ContentModeratorAPI.DELETE_IMAGE_LIST:
                        break;
                    case ContentModeratorAPI.REFRESH_INDEX_IMAGE_LIST:
                        break;
                    case ContentModeratorAPI.CREATE_TERM_LIST:
                        break;
                    case ContentModeratorAPI.UPDATE_TERM_LIST:
                        break;
                    case ContentModeratorAPI.GET_ALL_TERM_LIST:
                        break;
                    case ContentModeratorAPI.GET_DETAILS_TERM_LIST:
                        break;
                    case ContentModeratorAPI.DELETE_TERM_LIST:
                        break;
                    case ContentModeratorAPI.REFRESH_INDEX_TERM_LIST:
                        break;
                    case ContentModeratorAPI.ADD_IMAGE:
                        break;
                    case ContentModeratorAPI.DELETE_IMAGE:
                        break;
                    case ContentModeratorAPI.DELETE_ALL_IMAGE:
                        break;
                    case ContentModeratorAPI.GET_ALL_IMAGES:
                        break;
                    case ContentModeratorAPI.ADD_TERM:
                        break;
                    case ContentModeratorAPI.DELETE_TERM:
                        break;
                    case ContentModeratorAPI.DELETE_ALL_TERM:
                        break;
                    case ContentModeratorAPI.GET_ALL_TERMS:
                        break;
                    case ContentModeratorAPI.EVALUATE:
                    case ContentModeratorAPI.FIND_FACES:
                    case ContentModeratorAPI.MATCH:
                    case ContentModeratorAPI.OCR:

                        if (!br.Message.Equals(ImageErrorMessages.IMAGE_SIZE_ERROR.GetDescription(),StringComparison.InvariantCultureIgnoreCase))
                            error += $"Error Message mismatch. Actual<{br.Message}> Expected<{ImageErrorMessages.IMAGE_SIZE_ERROR.GetDescription()}>";
                        if (!br.Errors[0].Title.Equals(ImageErrorMessages.IMAGE_SIZE_ERROR.GetDescription(), StringComparison.InvariantCultureIgnoreCase))
                            error += $"Errors object Title mismatch. Actual<{br.Errors[0].Title}> Expected<{ImageErrorMessages.IMAGE_SIZE_ERROR.GetDescription()}>";
                        if (br.TrackingId == null)
                            error = $"Tracking id is null";
                        break;
                    case ContentModeratorAPI.SCREEN_TEXT:
                        break;
                    case ContentModeratorAPI.DETECT_LANGUAGE:
                        break;
                    default:
                        break;
                }

                TestBase.ErrorMessage = error;
                return string.IsNullOrEmpty(error);
            }
            catch (Exception)
            {
                    TestBase.ErrorMessage += $"Unable to verify BadRequestResponse. Response {JsonConvert.SerializeObject(br)}";
                    return false;
            }



        }




        #region EquateMethods

        public static bool EquateEval(Evaluate e1, Evaluate e2)
        {

            return
                e1.AdultClassificationScore.Equals(e2.AdultClassificationScore) &&
                e1.IsImageAdultClassified.Equals(e2.IsImageAdultClassified) &&
                e1.RacyClassificationScore.Equals(e2.RacyClassificationScore) &&
                e1.IsImageRacyClassified.Equals(e2.IsImageRacyClassified) &&
                e1.Result.Equals(e2.Result) &&
                e1.AdvancedInfo.Equals(e2.AdvancedInfo) &&
                e1.Status.Equals(e2.Status);
        }

        public static bool EquateFoundFaces(FoundFaces e1, FoundFaces e2)
        {

            return
                e1.Count.Equals(e2.Count) &&
                e1.Faces.Equals(e2.Faces) &&
                e1.Result.Equals(e2.Result) &&
                e1.AdvancedInfo.Equals(e2.AdvancedInfo) &&
                e1.Status.Equals(e2.Status);
        }


        public static bool EquateMatch(Match e1, Match e2)
        {
            return
                e1.Label.Equals(e2.Label) &&
                e1.Score.Equals(e2.Score) &&
                e1.Source.Equals(e2.Source) &&
                e1.Tags.Count.Equals(e2.Tags.Count);
        }


        public static bool EquateOCR(OCR e1, OCR e2)
        {
            return
                e1.Candidates.Count.Equals(e2.Candidates.Count  ) &&
                e1.Language.Equals(e2.Language) &&
                e1.Metadata.Equals(e2.Metadata) &&
                e1.Text.Equals(e2.Text) &&
                e1.Status.Equals(e2.Status);
        }




        #endregion


        #region Review


        public static bool VerifyJob(Content content, Job j)
        {

            string error = "";
            try
            {
                if (j.Id == null)
                    error += "Job id is null ";
                if (j.JobExecutionReport== null)
                    error += $"JOb Execution Resport is null ";
                if (j.ResultMetaData == null)
                    error += $"Metadata is null ";
                if (j.Type!= content.GetDescription())
                    error += $"Type mismatch,Actual{j.Type}, Expected {content.GetDescription()}";
                if (j.WorkflowId== null)
                    error += "Workflow id is null ";
                if (j.TeamName == null)
                    error += "Team name is null ";
                if (j.Status == null)
                    error += "Status is null ";
                if (j.ReviewId== null)
                    error += "Review Id is null ";

                TestBase.ErrorMessage = $"{content.GetDescription()} job : " + (string.IsNullOrEmpty(j.Id) ? "" : j.Id) + error;
                return string.IsNullOrEmpty(error);
            }
            catch (Exception)
            {
                throw;
            }




        }

        public static bool VerifyReview(Content content,Review r )
        {
            string error = "";
            try
            {
                 if (r.ReviewId == null)
                     error += "Review id is null ";
                 if (r.SubTeam == null)
                     error += $"SubTeam is null ";
                 if (r.Metadata == null)
                     error += $"Metadata is null ";
                 if (r.Type != content.GetDescription())
                     error += $"Type mismatch,Actual{r.Type}, Expected {content.GetDescription()}";
                 if (r.Content == null)
                     error += "Content is null ";
                 if (r.ContentId == null)
                     error += "ContentId  is null ";
                 if (r.Status == null)
                     error += "Status is null ";
                 if (r.CreatedBy== null)
                     error += "CreatedBy is null ";
                 if (r.CreatedBy == null)
                     error += "CreatedBy is null ";

                 if (r.Status.Equals(ReviewStatus.COMPLETE.GetDescription()))
                     if(r.ReviewerResultTags == null)
                         error +="ReviewerResultTags is null ";

                TestBase.ErrorMessage = $"{content.GetDescription()} review : " + (string.IsNullOrEmpty(r.ReviewId) ? "" : r.ReviewId) + error;
                return string.IsNullOrEmpty(error);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static bool VerifyGetFrames(Frames fs)
        {
            string error = "";
            try
            {
                if (fs.ReviewId == null)
                    error += "Review Id is null";

                if (fs.VideoFrames == null)
                    error += "Video frames is null";

                if (fs.VideoFrames.Count != 0)
                {
                    foreach (Frame f in fs.VideoFrames)
                    {
                        if (f.FrameImage == null)
                            error += " FrameImage is null";
                        if (f.Metadata == null)
                            error += " Frame Metadata is null";
                        if (f.ReviewerResultTags == null)
                            error += " ReviewerResultTags is null";
                        if (f.Timestamp == null)
                            error += " Timestamp is null";
                    }

                }

                return string.IsNullOrEmpty(error);

            }
            catch (Exception e)
            {
                TestBase.ErrorMessage = error + e.InnerException;
                return false;
            }

        }
        #endregion


    }
}
