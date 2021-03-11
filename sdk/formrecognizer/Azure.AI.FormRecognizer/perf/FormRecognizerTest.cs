// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Test.Perf;

namespace Azure.AI.FormRecognizer.Perf
{
    public abstract class FormRecognizerTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        /// <summary>The name of the folder in which test assets are stored.</summary>
        private const string AssetsFolderName = "Assets";

        /// <summary>The format to generate the GitHub URIs of the files to be used for tests.</summary>
        private const string FileUriFormat = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/{0}/{1}";

        public FormRecognizerTest(TOptions options) : base(options)
        {
            if (options.Parallel > 1)
            {
                throw new InvalidOperationException("Do not stress the service until we can reduce testing costs. Set '--parallel 1'.");
            }
        }

        protected string Endpoint => GetEnvironmentVariable("FORM_RECOGNIZER_ENDPOINT");

        protected string ApiKey => GetEnvironmentVariable("FORM_RECOGNIZER_API_KEY");

        protected string BlobContainerSasUrl => GetEnvironmentVariable("FORM_RECOGNIZER_BLOB_CONTAINER_SAS_URL");

        /// <summary>
        /// Creates a URI to a file contained in the test assets folder stored in the
        /// azure-sdk-for-net GitHub repo.
        /// </summary>
        /// <param name="filename">The name of the file to create a URI to.</param>
        /// <returns>A URI to the specified file.</returns>
        protected Uri CreateUri(string filename) =>
            new Uri(string.Format(FileUriFormat, AssetsFolderName, filename));
    }
}
