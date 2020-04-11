// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class RecognizedForm
    {
#pragma warning disable CA1801 // Remove unused parameter
        internal RecognizedForm(DocumentResult_internal documentResult, IList<PageResult_internal> pageResults, IList<ReadResult_internal> readResults)
#pragma warning restore CA1801 // Remove unused parameter
        {
            // Supervised
            FormType = documentResult.DocType;
            //PageRange = new FormPageRange(documentResult.PageRange);

            //Fields = ConvertFields(documentResult.Fields, readResults);
            //Tables = ConvertLabeledTables(pageResults, readResults);

            //// TODO: Populate CheckBoxes

            //if (readResults != null)
            //{
            //    PageText = ConvertPageText(readResults);
            //}
        }

        /// <summary>
        /// </summary>
        // Convert clusterId to a string (ex. "FormType1").
        public string FormType { get; }

        /// <summary>
        /// </summary>
        public FormPageRange PageRange { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyDictionary<string, FormField> Fields { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<RawExtractedPage> Pages { get; }
    }
}
