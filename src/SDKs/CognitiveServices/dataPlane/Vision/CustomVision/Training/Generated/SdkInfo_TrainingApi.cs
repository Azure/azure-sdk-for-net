
using System;
using System.Collections.Generic;
using System.Linq;

internal static partial class SdkInfo
{
    public static IEnumerable<Tuple<string, string, string>> ApiInfo_TrainingApi
    {
        get
        {
            return new Tuple<string, string, string>[]
            {
                new Tuple<string, string, string>("TrainingApi", "CreateImageRegions", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "CreateImageTags", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "CreateImagesFromData", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "CreateImagesFromFiles", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "CreateImagesFromPredictions", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "CreateImagesFromUrls", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "CreateProject", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "CreateTag", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "DeleteImageRegions", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "DeleteImageTags", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "DeleteImages", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "DeleteIteration", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "DeletePrediction", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "DeleteProject", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "DeleteTag", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "ExportIteration", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetDomain", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetDomains", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetExports", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetImagePerformanceCount", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetImagePerformances", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetImageRegionProposals", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetImagesByIds", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetIteration", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetIterationPerformance", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetIterations", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetProject", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetProjects", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetTag", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetTaggedImageCount", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetTaggedImages", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetTags", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetUntaggedImageCount", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "GetUntaggedImages", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "QueryPredictions", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "QuickTestImage", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "QuickTestImageUrl", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "TrainProject", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "UpdateIteration", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "UpdateProject", "2.0"),
                new Tuple<string, string, string>("TrainingApi", "UpdateTag", "2.0"),
            }.AsEnumerable();
        }
    }
}
