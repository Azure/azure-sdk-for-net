// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json;
using Azure.Communication.CallAutomation.Models.Transcription;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Parser of the different packages received as part of
    /// Transcription data streaming.
    /// </summary>
    public static class TranscriptionPackageParser
    {
        /// <summary>
        /// Parsing a Transcription package from BinaryData.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static TranscriptionPackageBase Parse(BinaryData json)
        {
            return Parse(json.ToString());
        }

        /// <summary>
        /// Parsing a Transcription package from a byte array.
        /// </summary>
        /// <param name="receivedBytes">a UTF8 byte array.</param>
        /// <returns></returns>
        public static TranscriptionPackageBase Parse(byte[] receivedBytes)
        {
            return Parse(Encoding.UTF8.GetString(receivedBytes));
        }

        /// <summary>
        /// Parse the incoming package.
        /// </summary>
        /// <param name="stringJson"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static TranscriptionPackageBase Parse(string stringJson)
        {
            JsonElement package = JsonDocument.Parse(stringJson).RootElement;
            if (package.GetProperty("kind").ToString() == "TranscriptionMetadata")
            {
                return JsonSerializer.Deserialize<TranscriptionMetadata>(package.GetProperty("transcriptionMetadata").ToString());
            }
            else if (package.GetProperty("kind").ToString() == "TranscriptionData")
            {
                TranscriptionDataInternal transcriptionDataInternal = JsonSerializer.Deserialize<TranscriptionDataInternal>(
                    package.GetProperty("transcriptionData").ToString()
                    );
                return new TranscriptionData(
                    transcriptionDataInternal.Text,
                    transcriptionDataInternal.Format,
                    transcriptionDataInternal.Confidence,
                    transcriptionDataInternal.Offset,
                    transcriptionDataInternal.Words,
                    transcriptionDataInternal.ParticipantRawID,
                    transcriptionDataInternal.ResultStatus
                    );
            }
            else
                throw new NotSupportedException(stringJson);
        }
    }
}
