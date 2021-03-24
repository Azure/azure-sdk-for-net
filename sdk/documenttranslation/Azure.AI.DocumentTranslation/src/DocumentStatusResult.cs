// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.DocumentTranslation
{
    [CodeGenModel("DocumentStatusDetail")]
    public partial class DocumentStatusResult
    {
        /// <summary> Document Id. </summary>
        [CodeGenMember("Id")]
        public string DocumentId { get; }
        /// <summary> URI of the translated document. </summary>
        [CodeGenMember("Path")]
        public Uri TranslatedDocumentUri { get; }

        /// <summary> To language. </summary>
        [CodeGenMember("To")]
        public string TranslateTo { get; }

        /// <summary> Document created date time. </summary>
        [CodeGenMember("CreatedDateTimeUtc")]
        public DateTimeOffset CreatedOn { get; }

        /// <summary> Date time in which the Document's status has been updated. </summary>
        [CodeGenMember("LastActionDateTimeUtc")]
        public DateTimeOffset LastModified { get; }

        /// <summary> Character charged by the API. </summary>
        [CodeGenMember("CharacterCharged")]
        public long CharactersCharged { get; }

        /// <summary> Progress of the translation if available. </summary>
        public float TranslationProgressPercentage => Progress * 100;

        /// <summary> Returns true if the translation on the document is completed, independent if it succeeded or failed. </summary>
        public bool HasCompleted => Status == TranslationStatus.Succeeded
                                    || Status == TranslationStatus.Failed
                                    || Status == TranslationStatus.Cancelled
                                    || Status == TranslationStatus.ValidationFailed;

        [CodeGenMember("Progress")]
        internal float Progress { get; }
    }
}
