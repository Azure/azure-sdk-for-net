// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    [CodeGenModel("Error")]
    public partial class DocumentAnalysisError
    {
        internal IDictionary<string, string> ToAdditionalInfo()
        {
            if (Details.Count == 0)
                return null;

            var details = new Dictionary<string, string>();
            int i = 0;
            foreach (DocumentAnalysisError detail in Details)
            {
                var errorInfo = new StringBuilder();

                errorInfo.Append($"Code: {detail.Code}\n");
                errorInfo.Append($"Message: {detail.Message}\n");
                if (!string.IsNullOrEmpty(detail.Target))
                {
                    errorInfo.Append($"Target: {detail.Target}");
                }

                details.Add($"Error {i++}", errorInfo.ToString());
            }

            return details;
        }
    }
}
