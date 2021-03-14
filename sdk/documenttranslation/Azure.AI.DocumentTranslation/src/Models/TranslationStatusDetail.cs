// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.DocumentTranslation.Models
{
    [CodeGenModel("BatchStatusDetail")]
    public partial class TranslationStatusDetail
    {
        /// <summary> Id of the operation. </summary>
        [CodeGenMember("Id")]
        public string TranslationId { get; }

        /// <summary> Operation created date time. </summary>
        [CodeGenMember("CreatedDateTimeUtc")]
        public DateTimeOffset CreatedOn { get; }

        /// <summary> Date time in which the operation's status has been updated. </summary>
        [CodeGenMember("LastActionDateTimeUtc")]
        public DateTimeOffset LastModified { get; }

        /// <summary> The Status Summary of the operation. </summary>
        [CodeGenMember("Summary")]
        internal StatusSummary Summary { get; set; }

        /// <summary> Total count. </summary>
        public int DocumentsTotal => Summary.Total;

        /// <summary> Failed count. </summary>
        public int DocumentsFailed => Summary.Failed;

        /// <summary> Number of Success. </summary>
        public int DocumentsSucceeded => Summary.Success;

        /// <summary> Number of in progress. </summary>
        public int DocumentsInProgress => Summary.InProgress;

        /// <summary> Count of not yet started. </summary>
        public int DocumentsNotStarted => Summary.NotYetStarted;

        /// <summary> Number of cancelled. </summary>
        public int DocumentsCancelled => Summary.Cancelled;

        /// <summary> Total characters charged by the API. </summary>
        public long TotalCharacterCharged => Summary.TotalCharacterCharged;
    }
}
