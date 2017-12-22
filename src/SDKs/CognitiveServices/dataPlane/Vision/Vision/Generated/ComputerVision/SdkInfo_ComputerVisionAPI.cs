
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
                new Tuple<string, string, string>(null, "AnalyzeImage", "1.0"),
                new Tuple<string, string, string>(null, "AnalyzeImageByDomain", "1.0"),
                new Tuple<string, string, string>(null, "AnalyzeImageByDomainInStream", "1.0"),
                new Tuple<string, string, string>(null, "AnalyzeImageInStream", "1.0"),
                new Tuple<string, string, string>(null, "DescribeImage", "1.0"),
                new Tuple<string, string, string>(null, "DescribeImageInStream", "1.0"),
                new Tuple<string, string, string>(null, "GenerateThumbnail", "1.0"),
                new Tuple<string, string, string>(null, "GenerateThumbnailInStream", "1.0"),
                new Tuple<string, string, string>(null, "GetTextOperationResult", "1.0"),
                new Tuple<string, string, string>(null, "ListModels", "1.0"),
                new Tuple<string, string, string>(null, "RecognizePrintedText", "1.0"),
                new Tuple<string, string, string>(null, "RecognizePrintedTextInStream", "1.0"),
                new Tuple<string, string, string>(null, "RecognizeText", "1.0"),
                new Tuple<string, string, string>(null, "RecognizeTextInStream", "1.0"),
                new Tuple<string, string, string>(null, "TagImage", "1.0"),
                new Tuple<string, string, string>(null, "TagImageInStream", "1.0"),
            }.AsEnumerable();
        }
    }
}
