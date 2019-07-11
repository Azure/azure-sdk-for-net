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
   public class Responses
    {
        public Responses(){}

        //ListManagementImageLIsts
        public HttpOperationResponse<IList<ImageList>> GetAllImageLists { get; set; }
        public HttpOperationResponse<string> DeleteImageLists { get; set; }
        public HttpOperationResponse<ImageList> CreateImageList { get; set; }
        public HttpOperationResponse<ImageList> GetDetailsImageList { get; set; }
        public HttpOperationResponse<ImageList> UpdateImageList { get; set; }
        public HttpOperationResponse<RefreshIndex> RefreshIndexImageList { get; set; }

        //ListManagementTermLIsts
        public HttpOperationResponse<IList<TermList>> GetAllTermLists { get; set; }
        public HttpOperationResponse<string> DeleteTermLists { get; set; }
        public HttpOperationResponse<TermList> CreateTermList { get; set; }
        public HttpOperationResponse<TermList> GetDetailsTermList { get; set; }
        public HttpOperationResponse<TermList> UpdateTermList { get; set; }
        public HttpOperationResponse<RefreshIndex> RefreshIndexTermList { get; set; }

        //ListManagementImages
        public HttpOperationResponse<ImageIds> GetAllImages { get; set; }
        public HttpOperationResponse<string> DeleteImage { get; set; }
        public HttpOperationResponse<string> DeleteImages { get; set; }
        public HttpOperationResponse<Image> AddImage { get; set; }
        //ListManagementTerms
        public HttpOperationResponse<Terms> GetAllTerms { get; set; }
        public HttpOperationResponse<string> DeleteTerm { get; set; }
        public HttpOperationResponse<string> DeleteTerms { get; set; }
        public HttpOperationResponse<Object> AddTerm { get; set; }

        //ImageModerator
        public HttpOperationResponse<Evaluate> Evaluate { get; set; }
        public HttpOperationResponse<FoundFaces> FoundFaces { get; set; }
        public HttpOperationResponse<MatchResponse> MatchImage { get; set; }
        public HttpOperationResponse<OCR> OCR{ get; set; }

        //Text
        public HttpOperationResponse<DetectedLanguage> DetectLanguage { get; set; }
        public HttpOperationResponse<Screen> ScreenText { get; set; }

        public APIErrorException InnerException { get; set; }
    }
}
