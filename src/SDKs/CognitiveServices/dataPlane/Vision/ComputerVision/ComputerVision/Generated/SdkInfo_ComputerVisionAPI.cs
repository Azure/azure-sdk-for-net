
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_ComputerVisionAPI
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("ComputerVisionAPI", "AnalyzeImage", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "AnalyzeImageByDomain", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "AnalyzeImageByDomainInStream", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "AnalyzeImageInStream", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "DescribeImage", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "DescribeImageInStream", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "GenerateThumbnail", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "GenerateThumbnailInStream", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "GetTextOperationResult", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "ListModels", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "RecognizePrintedText", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "RecognizePrintedTextInStream", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "RecognizeText", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "RecognizeTextInStream", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "TagImage", "1.0"),
                new Tuple<string, string, string>("ComputerVisionAPI", "TagImageInStream", "1.0"),
            }.AsEnumerable();
        }
    }
}
