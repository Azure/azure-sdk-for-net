// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public static class TestEnvironment
    {
        /// <summary>The name of the environment variable from which the Form Recognizer resource's endpoint will be extracted for the live tests.</summary>
        public const string EndpointEnvironmentVariableName = "FORM_RECOGNIZER_ENDPOINT";

        /// <summary>The name of the environment variable from which the Form Recognizer resource's API key will be extracted for the live tests.</summary>
        public const string ApiKeyEnvironmentVariableName = "FORM_RECOGNIZER_API_KEY";

        /// <summary>The name of the folder in which test assets are stored.</summary>
        private const string AssetsFolderName = "Assets";

        /// <summary>The name of the JPG file which contains the receipt to be used for tests.</summary>
        private const string ReceiptFilename = "contoso-receipt.jpg";

        /// <summary>The format to generate the filenames of the PDF forms to be used for tests.</summary>
        private const string InvoiceFilenameFormat = "Invoice_{0}.pdf";

        /// <summary>The format to generate the GitHub URIs of the files to be used for tests.</summary>
        private const string FileUriFormat = "https://raw.githubusercontent.com/Azure/azure-sdk-for-net/master/sdk/formrecognizer/Azure.AI.FormRecognizer/tests/{0}/{1}";

        /// <summary>
        /// The relative path to the JPG file which contains the receipt to be used for tests.
        /// </summary>
        /// <value>The relative path to the JPG file.</value>
        public static string ReceiptPath => Path.Combine(AssetsFolderName, ReceiptFilename);

        /// <summary>
        /// The URI string to the JPG file which contains the receipt to be used for tests.
        /// </summary>
        /// <value>The URI string to the JPG file.</value>
        public static string ReceiptUri => string.Format(FileUriFormat, AssetsFolderName, ReceiptFilename);

        /// <summary>
        /// Retrieves the relative path to a PDF form available in the test assets.
        /// </summary>
        /// <param name="index">The index to specify the form to be retrieved.</param>
        /// <returns>The relative path to the PDF form corresponding to the specified index.</returns>
        public static string RetrieveInvoicePath(int index)
        {
            var filename = string.Format(InvoiceFilenameFormat, index);
            return Path.Combine(AssetsFolderName, filename);
        }

        /// <summary>
        /// Retrieves the URI string to a PDF form available in the test assets.
        /// </summary>
        /// <param name="index">The index to specify the form to be retrieved.</param>
        /// <returns>The URI string to the PDF form corresponding to the specified index.</returns>
        public static string RetrieveInvoiceUri(int index)
        {
            var filename = string.Format(InvoiceFilenameFormat, index);
            return string.Format(FileUriFormat, AssetsFolderName, filename);
        }
    }
}
