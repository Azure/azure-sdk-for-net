// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using Azure.Core.Testing;
using Azure.AI.FormRecognizer.Models;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class FormRecognizerTestEnvironment: TestEnvironment
    {
        public FormRecognizerTestEnvironment() : base("formrecognizer")
        {
        }

        /// <summary>The name of the environment variable from which the Form Recognizer resource's endpoint will be extracted for the live tests.</summary>
        private const string EndpointEnvironmentVariableName = "FORM_RECOGNIZER_ENDPOINT";

        /// <summary>The name of the environment variable from which the Form Recognizer resource's API key will be extracted for the live tests.</summary>
        private const string ApiKeyEnvironmentVariableName = "FORM_RECOGNIZER_API_KEY";

        /// <summary>The name of the environment variable for the Blob Container SAS Url use for storing documents used for live tests.</summary>
        private const string BlobContainerSasUrlEnvironmentVariableName = "FORM_RECOGNIZER_BLOB_CONTAINER_SAS_URL";

        /// <summary>The name of the folder in which test assets are stored.</summary>
        private const string AssetsFolderName = "Assets";

        /// <summary>The name of the JPG file which contains the receipt to be used for tests.</summary>
        private const string JpgReceiptFilename = "contoso-receipt.jpg";

        /// <summary>The name of the PNG file which contains the receipt to be used for tests.</summary>
        private const string PngReceiptFilename = "contoso-allinone.png";

        /// <summary>The format to generate the filenames of the forms to be used for tests.</summary>
        private const string InvoiceFilenameFormat = "Invoice_{0}.{1}";

        /// <summary>The name of the JPG file which contains the form to be used for tests.</summary>
        private const string FormFilename = "Form_1.jpg";

        /// <summary>The format to generate the GitHub URIs of the files to be used for tests.</summary>
        private const string FileUriFormat = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/{0}/{1}";

        public string ApiKey => GetRecordedVariable(ApiKeyEnvironmentVariableName);
        public string Endpoint => GetRecordedVariable(EndpointEnvironmentVariableName);
        public string BlobContainerSasUrl => GetRecordedVariable(BlobContainerSasUrlEnvironmentVariableName);

        /// <summary>
        /// The name of the directory where the running assembly is located.
        /// </summary>
        /// <value>The name of the current working directory.</value>
        private static string CurrentWorkingDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        /// <summary>
        /// The relative path to the JPG file which contains the form to be used for tests.
        /// </summary>
        /// <value>The relative path to the JPG file.</value>
        public static string FormPath => CreatePath(FormFilename);

        /// <summary>
        /// The URI string to the JPG file which contains the form to be used for tests.
        /// </summary>
        /// <value>The URI string to the JPG file.</value>
        public static string FormUri => CreateUri(FormFilename);

        /// <summary>
        /// The relative path to the JPG file which contains the receipt to be used for tests.
        /// </summary>
        /// <value>The relative path to the JPG file.</value>
        public static string JpgReceiptPath => CreatePath(JpgReceiptFilename);

        /// <summary>
        /// The relative path to the PNG file which contains the receipt to be used for tests.
        /// </summary>
        /// <value>The relative path to the PNG file.</value>
        public static string PngReceiptPath => CreatePath(PngReceiptFilename);

        /// <summary>
        /// The URI string to the JPG file which contains the receipt to be used for tests.
        /// </summary>
        /// <value>The URI string to the JPG file.</value>
        public static string JpgReceiptUri => CreateUri(JpgReceiptFilename);

        /// <summary>
        /// Retrieves the relative path to a PDF or TIFF form available in the test assets.
        /// </summary>
        /// <param name="index">The index to specify the form to be retrieved.</param>
        /// <param name="contentType">The type of the form to be retrieved. Currently only PDF and TIFF are available.</param>
        /// <returns>The relative path to the PDF or TIFF form corresponding to the specified index.</returns>
        public static string RetrieveInvoicePath(int index, ContentType contentType)
        {
            var extension = contentType switch
            {
                ContentType.Pdf => "pdf",
                ContentType.Tiff => "tiff",
                _ => throw new ArgumentException("The requested content type is not available.", nameof(contentType))
            };

            var filename = string.Format(InvoiceFilenameFormat, index, extension);
            return CreatePath(filename);
        }

        /// <summary>
        /// Retrieves the URI string to a PDF form available in the test assets.
        /// </summary>
        /// <param name="index">The index to specify the form to be retrieved.</param>
        /// <returns>The URI string to the PDF form corresponding to the specified index.</returns>
        public static string RetrieveInvoiceUri(int index)
        {
            var filename = string.Format(InvoiceFilenameFormat, index, "pdf");
            return CreateUri(filename);
        }

        public static string CreatePath(string fileName, string assetFolder = default)
        {
            return Path.Combine(CurrentWorkingDirectory, assetFolder ?? AssetsFolderName, fileName);
        }

        public static string CreateUri(string fileName, string assetFolder = default, string fileUriFormat = default)
        {
            return string.Format(fileUriFormat ?? FileUriFormat, assetFolder ?? AssetsFolderName, fileName);
        }
    }
}
