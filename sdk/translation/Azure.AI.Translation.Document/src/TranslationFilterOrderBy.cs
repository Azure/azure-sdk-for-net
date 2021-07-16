// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// asd.
    /// </summary>
    public class TranslationFilterOrderBy
    {
        /// <summary>
        /// asd.
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="order"></param>
        public TranslationFilterOrderBy(TranslationFilterOrderField orderBy, TranslationFilterOrder order)
        {
            Order = order;
            OrderBy = orderBy;
        }
        /// <summary>
        /// asd.
        /// </summary>
        public TranslationFilterOrder Order { get; set; }
        /// <summary>
        /// asd.
        /// </summary>
        public TranslationFilterOrderField OrderBy { get; set; }

        /// <summary>
        /// asd.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{OrderBy} {Order}";
        }
    }

    /// <summary>
    /// asd.
    /// </summary>
    public enum TranslationFilterOrder
    {
        /// <summary>
        /// asd.
        /// </summary>
        Asc = 1,
        /// <summary>
        /// asd.
        /// </summary>
        Desc = 2,
    }

    /// <summary>
    /// asd.
    /// </summary>
    public enum TranslationFilterOrderField
    {
        /// <summary>
        /// asd.
        /// </summary>
        Id = 0,
        /// <summary>
        /// asd.
        /// </summary>
        CreatedOn = 1,
        /// <summary>
        /// asd.
        /// </summary>
        LastModified = 2,
        /// <summary>
        /// asd.
        /// </summary>
        DocumentsTotal = 3,
        /// <summary>
        /// asd.
        /// </summary>
        DocumentsFailed = 4,
        /// <summary>
        /// asd.
        /// </summary>
        DocumentsSucceeded = 5,
        /// <summary>
        /// asd.
        /// </summary>
        DocumentsInProgress = 6,
        /// <summary>
        /// asd.
        /// </summary>
        DocumentsNotStarted = 7,
        /// <summary>
        /// asd.
        /// </summary>
        DocumentsCancelled = 8,
        /// <summary>
        /// asd.
        /// </summary>
        TotalCharactersCharged = 9,
    }
}
