// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormPageContent
    {
        internal FormPageContent(PageResult_internal pageResult, ReadResult_internal readResult)
        {
            Tables = ConvertTables(pageResult.Tables, readResult);

            // TODO: Set CheckBoxes

            if (readResult != null)
            {
                PageNumber = readResult.Page;
                TextElements = new FormPageElements(readResult);
            }
        }

        /// <summary> The 1-based page number in the input document. </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<FormTable> Tables { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<FormCheckBox> CheckBoxes { get; }

        /// <summary>
        /// </summary>
        public FormPageElements TextElements { get; }

        internal static IReadOnlyList<FormTable> ConvertTables(ICollection<DataTable_internal> tablesResult, ReadResult_internal readResult)
        {
            List<FormTable> tables = new List<FormTable>();

            foreach (var result in tablesResult)
            {
                tables.Add(new FormTable(result, readResult));
            }

            return tables;
        }
    }
}
