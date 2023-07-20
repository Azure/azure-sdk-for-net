// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.DocumentAnalysis
{
    public partial class DocumentTableCell
    {
        private const int DefaultSpanValue = 1;

        private static readonly DocumentTableCellKind DefaultTableCellKind = DocumentTableCellKind.Content;

        /// <summary>
        /// Table cell kind.
        /// </summary>
        public DocumentTableCellKind Kind => KindPrivate ?? DefaultTableCellKind;

        /// <summary>
        /// Number of rows spanned by this cell.
        /// </summary>
        public int RowSpan => RowSpanPrivate ?? DefaultSpanValue;

        /// <summary>
        /// Number of columns spanned by this cell.
        /// </summary>
        public int ColumnSpan => ColumnSpanPrivate ?? DefaultSpanValue;

        [CodeGenMember("Kind")]
        private DocumentTableCellKind? KindPrivate { get; }

        [CodeGenMember("RowSpan")]
        private int? RowSpanPrivate { get; }

        [CodeGenMember("ColumnSpan")]
        private int? ColumnSpanPrivate { get; }
    }
}
