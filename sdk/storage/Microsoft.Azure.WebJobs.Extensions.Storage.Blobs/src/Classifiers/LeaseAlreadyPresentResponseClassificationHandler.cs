// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Classifiers
{
    internal class LeaseAlreadyPresentResponseClassificationHandler : ResponseClassificationHandler
    {
        private readonly bool isError;

        private LeaseAlreadyPresentResponseClassificationHandler(bool isError)
        {
            this.isError = isError;
        }

        public override bool TryClassify(HttpMessage message, out bool isError)
        {
            if (message.Response.Status != 409 ||
                !message.Response.Headers.TryGetValue("x-ms-error-code", out string errorCode) ||
                errorCode != "LeaseAlreadyPresent")
            {
                isError = false;
                return false;
            }

            isError = this.isError;
            return true;
        }

        /// <summary>
        /// Gets a response classifier for 409 lease already present.
        /// </summary>
        /// <param name="classifyAsError">Whether to classify this response as an error.</param>
        /// <returns>The <see cref="ResponseClassificationHandler"/>.</returns>
        public static ResponseClassificationHandler GetClassifier(bool classifyAsError)
        {
            return new LeaseAlreadyPresentResponseClassificationHandler(classifyAsError);
        }
    }
}
