// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Communication.MediaComposition;
using Azure.Communication.MediaComposition.Models;

namespace Azure.Communication.MediaComposition.Samples
{
    /// <summary>
    /// Basic Azure Communication Media Composition samples.
    /// </summary>
    public partial class Sample1_CommunicationMediaCompositionClient
    {
        private static Uri _endpoint = new Uri("SERVICE_ENDPOINT");
        private static string _mediaCompositionId = "myMediaComposition";
        private static string _teamsJoinUrl = "TEAMS_JOIN_URL";
        private static string _presenterParticipantId = "PARTICIPANT_ID";

        public void CreateAndStartMediaComposition()
        {
            var teamsMeetingInput = new MediaInput()
            {
                MediaType = MediaType.TeamsMeeting,
                TeamsMeeting = new TeamsMeeting
                {
                    TeamsJoinUrl = _teamsJoinUrl
                }
            };

            var mediaInputs = new Dictionary<string, MediaInput>
            {
                { "teamsMeeting", teamsMeetingInput }
            };

            var teamsMeetingOutput = new MediaOutput()
            {
                MediaType = MediaType.TeamsMeeting,
                TeamsMeeting = new TeamsMeeting
                {
                    TeamsJoinUrl = _teamsJoinUrl
                }
            };

            var mediaOutputs = new Dictionary<string, MediaOutput>
            {
                { "teamsMeeting", teamsMeetingOutput }
            };

            var presenter = new MediaSource()
            {
                MediaInputId = "teamsMeeting",
                SourceType = SourceType.Participant,
                Participant = new CommunicationIdentifierModel
                {
                    Id = _presenterParticipantId
                }
            };

            var sources = new Dictionary<string, MediaSource>
            {
                { "presenter", presenter }
            };

            var layout = new MediaLayout()
            {
                Type = LayoutType.Warhol,
                Resolution = new MediaResolution
                {
                    Width = 1920,
                    Height = 1080
                }
            };

            var mediaCompositionClient = new MediaCompositionClient(_endpoint);
            mediaCompositionClient.CreateMediaComposition(_mediaCompositionId, layout, mediaInputs, mediaOutputs, sources);
            mediaCompositionClient.StartMediaComposition(_mediaCompositionId);
        }
    }
}
