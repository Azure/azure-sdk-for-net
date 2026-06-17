// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    internal static class CustomCallContextHelpers
    {
        /// <summary>
        /// Converts a public TeamsPhoneCallDetails instance to an internal TeamsPhoneCallDetailsInternal instance.
        /// </summary>
        /// <param name="teamsPhoneCallDetails">The public TeamsPhoneCallDetails instance to convert.</param>
        /// <returns>
        /// A new TeamsPhoneCallDetailsInternal instance containing the converted data, or null if the input is null.
        /// </returns>
        internal static TeamsPhoneCallDetailsInternal CreateTeamsPhoneCallDetailsInternal(TeamsPhoneCallDetails teamsPhoneCallDetails)
        {
            if (teamsPhoneCallDetails == null)
            {
                return null;
            }

            return new TeamsPhoneCallDetailsInternal(
                CreateTeamsPhoneCallerDetailsInternal(teamsPhoneCallDetails.TeamsPhoneCallerDetails),
                CreateTeamsPhoneSourceDetailsInternal(teamsPhoneCallDetails.TeamsPhoneSourceDetails),
                teamsPhoneCallDetails.SessionId,
                teamsPhoneCallDetails.Intent,
                teamsPhoneCallDetails.CallTopic,
                teamsPhoneCallDetails.CallContext,
                teamsPhoneCallDetails.TranscriptUrl,
                teamsPhoneCallDetails.CallSentiment,
                teamsPhoneCallDetails.SuggestedActions);
        }

        /// <summary>
        /// Converts a public TeamsPhoneCallerDetails instance to an internal TeamsPhoneCallerDetailsInternal instance.
        /// </summary>
        /// <param name="teamsPhoneCallerDetails">The public TeamsPhoneCallerDetails instance to convert.</param>
        /// <returns>
        /// A new TeamsPhoneCallerDetailsInternal instance containing the converted data, or null if the input is null.
        /// </returns>
        internal static TeamsPhoneCallerDetailsInternal CreateTeamsPhoneCallerDetailsInternal(TeamsPhoneCallerDetails teamsPhoneCallerDetails)
        {
            if (teamsPhoneCallerDetails == null)
            {
                return null;
            }

            return new TeamsPhoneCallerDetailsInternal(
                CommunicationIdentifierSerializer.Serialize(teamsPhoneCallerDetails.Caller),
                teamsPhoneCallerDetails.Name,
                teamsPhoneCallerDetails.PhoneNumber,
                teamsPhoneCallerDetails.RecordId,
                teamsPhoneCallerDetails.ScreenPopUrl,
                teamsPhoneCallerDetails.IsAuthenticated,
                teamsPhoneCallerDetails.AdditionalCallerInformation);
        }

        /// <summary>
        /// Converts a public TeamsPhoneSourceDetails instance to an internal TeamsPhoneSourceDetailsInternal instance.
        /// </summary>
        /// <param name="teamsPhoneSourceDetails">The public TeamsPhoneSourceDetails instance to convert.</param>
        /// <returns>
        /// A new TeamsPhoneSourceDetailsInternal instance containing the converted data, or null if the input is null.
        /// </returns>
        internal static TeamsPhoneSourceDetailsInternal CreateTeamsPhoneSourceDetailsInternal(TeamsPhoneSourceDetails teamsPhoneSourceDetails)
        {
            if (teamsPhoneSourceDetails == null)
            {
                return null;
            }

            return new TeamsPhoneSourceDetailsInternal(
                CommunicationIdentifierSerializer.Serialize(teamsPhoneSourceDetails.Source),
                teamsPhoneSourceDetails.Language,
                teamsPhoneSourceDetails.Status,
                teamsPhoneSourceDetails.IntendedTargets?.ToDictionary(
                    pair => pair.Key,
                    pair => CommunicationIdentifierSerializer.Serialize(pair.Value))
                );
        }

        internal static TeamsPhoneCallDetails CreateTeamsPhoneCallDetails(TeamsPhoneCallDetailsInternal internalTeamsPhoneCallDetails)
        {
            if (internalTeamsPhoneCallDetails == null)
            {
                return null;
            }
            return new TeamsPhoneCallDetails(
                CreateTeamsPhoneCallerDetails(internalTeamsPhoneCallDetails.TeamsPhoneCallerDetails),
                CreateTeamsPhoneSourceDetails(internalTeamsPhoneCallDetails.TeamsPhoneSourceDetails),
                internalTeamsPhoneCallDetails.SessionId,
                internalTeamsPhoneCallDetails.Intent,
                internalTeamsPhoneCallDetails.CallTopic,
                internalTeamsPhoneCallDetails.CallContext,
                internalTeamsPhoneCallDetails.TranscriptUrl,
                internalTeamsPhoneCallDetails.CallSentiment,
                internalTeamsPhoneCallDetails.SuggestedActions);
        }
        internal static TeamsPhoneCallerDetails CreateTeamsPhoneCallerDetails(TeamsPhoneCallerDetailsInternal internalTeamsPhoneCallerDetails)
        {
            if (internalTeamsPhoneCallerDetails == null)
            {
                return null;
            }
            return new TeamsPhoneCallerDetails(
                CommunicationIdentifierSerializer.Deserialize(internalTeamsPhoneCallerDetails.Caller),
                internalTeamsPhoneCallerDetails.Name,
                internalTeamsPhoneCallerDetails.PhoneNumber,
                internalTeamsPhoneCallerDetails.RecordId,
                internalTeamsPhoneCallerDetails.ScreenPopUrl,
                internalTeamsPhoneCallerDetails.IsAuthenticated,
                internalTeamsPhoneCallerDetails.AdditionalCallerInformation
                );
        }
        internal static TeamsPhoneSourceDetails CreateTeamsPhoneSourceDetails(TeamsPhoneSourceDetailsInternal internalTeamsPhoneSourceDetails)
        {
            if (internalTeamsPhoneSourceDetails == null)
            {
                return null;
            }
            return new TeamsPhoneSourceDetails(
                CommunicationIdentifierSerializer.Deserialize(internalTeamsPhoneSourceDetails.Source),
                internalTeamsPhoneSourceDetails.Language,
                internalTeamsPhoneSourceDetails.Status,
                internalTeamsPhoneSourceDetails.IntendedTargets?.ToDictionary(
                    pair => pair.Key,
                    pair => CommunicationIdentifierSerializer.Deserialize(pair.Value))
                );
        }
    }
}
