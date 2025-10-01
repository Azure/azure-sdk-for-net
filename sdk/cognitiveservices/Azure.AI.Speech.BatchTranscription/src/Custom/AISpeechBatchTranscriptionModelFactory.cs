// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Speech.BatchTranscription
{
    /// <summary> Model factory for models. </summary>
    public static partial class AISpeechBatchTranscriptionModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="BatchTranscription.TranscriptionJob"/>. </summary>
        /// <param name="properties"> TranscriptionProperties. </param>
        /// <param name="id"> The id of this entity. </param>
        /// <param name="self"> The location of this entity. </param>
        /// <param name="model"> EntityReference. </param>
        /// <param name="dataset"> EntityReference. </param>
        /// <param name="contentUrls"> A list of content urls to get audio files to transcribe. Up to 1000 urls are allowed. This property will not be returned in a response. </param>
        /// <param name="contentContainerUrl"> A URL for an Azure blob container that contains the audio files. A container is allowed to have a maximum size of 5GB and a maximum number of 10000 blobs. The maximum size for a blob is 2.5GB. Container SAS should contain 'r' (read) and 'l' (list) permissions. This property will not be returned in a response. </param>
        /// <param name="locale"> The locale of the contained data. If Language Identification is used, this locale is used to transcribe speech for which no language could be detected. </param>
        /// <param name="displayName"> The display name of the object. </param>
        /// <param name="description"> The description of the object. </param>
        /// <param name="customProperties"> The custom properties of this entity. The maximum allowed key length is 64 characters, the maximum allowed value length is 256 characters and the count of allowed entries is 10. </param>
        /// <param name="lastActionDateTime"> The time-stamp when the current status was entered. The time stamp is encoded as ISO 8601 date and time format ("YYYY-MM-DDThh:mm:ssZ", see https://en.wikipedia.org/wiki/ISO_8601#Combined_date_and_time_representations). </param>
        /// <param name="status"> The status of the object. </param>
        /// <param name="createdDateTime"> The time-stamp when the object was created. The time stamp is encoded as ISO 8601 date and time format ("YYYY-MM-DDThh:mm:ssZ", see https://en.wikipedia.org/wiki/ISO_8601#Combined_date_and_time_representations). </param>
        /// <returns> A new <see cref="BatchTranscription.TranscriptionJob"/> instance for mocking. </returns>
        public static TranscriptionJob TranscriptionJob(
            TranscriptionProperties properties = null,
            string id = null,
            Uri self = null,
            EntityReference model = null,
            EntityReference dataset = null,
            IList<Uri> contentUrls = null,
            Uri contentContainerUrl = null,
            string locale = null,
            string displayName = null,
            string description = null,
            IDictionary<string, string> customProperties = null,
            DateTimeOffset? lastActionDateTime = null,
            TranscriptionStatus status = default,
            DateTimeOffset? createdDateTime = null)
        {
            contentUrls ??= new List<Uri>();
            customProperties ??= new Dictionary<string, string>();

            return new TranscriptionJob(
                links: null, // TranscriptionLinks is internal, so we pass null
                properties,
                id,
                self,
                model,
                dataset,
                contentUrls,
                contentContainerUrl,
                locale,
                displayName,
                description,
                customProperties,
                lastActionDateTime,
                status,
                createdDateTime,
                serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of <see cref="BatchTranscription.TranscriptionFile"/>. </summary>
        /// <param name="createdDateTime"> The creation time of this file. The time stamp is encoded as ISO 8601 date and time format. </param>
        /// <param name="kind"> FileKind. </param>
        /// <param name="links"> FileLinks. </param>
        /// <param name="displayName"> The name of this file. </param>
        /// <param name="properties"> FileProperties. </param>
        /// <param name="id"> The id of this entity. </param>
        /// <param name="self"> The location of this entity. </param>
        /// <returns> A new <see cref="BatchTranscription.TranscriptionFile"/> instance for mocking. </returns>
        public static TranscriptionFile TranscriptionFile(
            DateTimeOffset createdDateTime = default,
            FileKind kind = default,
            FileLinks links = null,
            string displayName = null,
            FileProperties properties = null,
            string id = null,
            Uri self = null)
        {
            var transcriptionFile = new TranscriptionFile(
                createdDateTime,
                kind,
                links,
                displayName,
                properties,
                self,
                serializedAdditionalRawData: null);

            if (id != null)
            {
                transcriptionFile.Id = id;
            }

            return transcriptionFile;
        }
    }
}
