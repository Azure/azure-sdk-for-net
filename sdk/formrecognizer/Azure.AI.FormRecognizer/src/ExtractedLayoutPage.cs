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
                PageInfo = new FormPageInfo(readResult);

                if (readResult.Lines != null)
                {
                    TextElements = new FormPageText(readResult.Lines);
                }
            }
        }

        /// <summary>
        /// </summary>
        public FormPageInfo PageInfo { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<FormTable> Tables { get; }

        /// <summary>
        /// </summary>
        public IReadOnlyList<FormCheckBox> CheckBoxes { get; }

        /// <summary>
        /// </summary>
        public FormPageText TextElements { get; }

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
