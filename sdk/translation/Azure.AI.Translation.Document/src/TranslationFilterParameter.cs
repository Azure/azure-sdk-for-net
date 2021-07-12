using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// asd
    /// </summary>
    public class TranslationFilterParameter
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset CreatedOnEnd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset CreatedOnStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IList<string> Ids { get; }
        /// <summary>
        /// 
        /// </summary>
        public IList<TranslationFilterOrderBy> OrderBy { get; }
        /// <summary>
        /// 
        /// </summary>
        public IList<DocumentTranslationStatus> Statuses { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TranslationFilterOrderBy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="order"></param>
        public TranslationFilterOrderBy(TranslationFilterOrderField orderBy, TranslationFilterOrder order);
        /// <summary>
        /// 
        /// </summary>
        public TranslationFilterOrder Order { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TranslationFilterOrderField OrderBy { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum TranslationFilterOrder
    {
        /// <summary>
        /// 
        /// </summary>
        Asc = 1,
        /// <summary>
        /// 
        /// </summary>
        Desc = 2,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum TranslationFilterOrderField
    {
        /// <summary>
        /// 
        /// </summary>
        Id = 0,
        /// <summary>
        /// 
        /// </summary>
        CreatedOn = 1,
        /// <summary>
        /// 
        /// </summary>
        LastModified = 2,
        DocumentsTotal = 3,
        DocumentsFailed = 4,
        DocumentsSucceeded = 5,
        DocumentsInProgress = 6,
        DocumentsNotStarted = 7,
        DocumentsCancelled = 8,
        TotalCharactersCharged = 9,
    }
}
