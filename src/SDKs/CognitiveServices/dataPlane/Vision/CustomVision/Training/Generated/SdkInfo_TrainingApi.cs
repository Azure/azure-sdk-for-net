
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
                new Tuple<string, string, string>("TrainingApi", "CreateImagesFromData", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "CreateImagesFromFiles", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "CreateImagesFromPredictions", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "CreateImagesFromUrls", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "CreateProject", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "CreateTag", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "DeleteImageTags", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "DeleteImages", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "DeleteIteration", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "DeletePrediction", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "DeleteProject", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "DeleteTag", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "ExportIteration", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetAccountInfo", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetDomain", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetDomains", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetExports", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetIteration", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetIterationPerformance", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetIterations", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetProject", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetProjects", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetTag", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetTaggedImages", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetTags", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "GetUntaggedImages", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "PostImageTags", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "QueryPredictionResults", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "QuickTestImage", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "QuickTestImageUrl", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "TrainProject", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "UpdateIteration", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "UpdateProject", "1.2"),
                new Tuple<string, string, string>("TrainingApi", "UpdateTag", "1.2"),
            }.AsEnumerable();
        }
    }
}
