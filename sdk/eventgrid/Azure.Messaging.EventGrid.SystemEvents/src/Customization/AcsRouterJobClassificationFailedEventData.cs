// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Messaging.EventGrid.SystemEvents
{
    /// <summary> Schema of the Data property of an EventGridEvent for a Microsoft.Communication.RouterJobClassificationFailed event. </summary>
    public partial class AcsRouterJobClassificationFailedEventData
    {
        /// <summary> List of Router Communication Errors. </summary>
        [CodeGenMember("Errors")]
        internal IReadOnlyList<AcsRouterCommunicationError> ErrorsInternal { get; }

        /// <summary> List of Router Communication Errors. </summary>
        public IReadOnlyList<ResponseError> Errors
        {
            get
            {
                if (_errors == null)
                {
                    // Need to re-serialize to be able to deserialize as ResponseError with the internal properties populated.
                    var serialized = JsonSerializer.Serialize(
                        ErrorsInternal,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                    _errors = JsonSerializer.Deserialize<List<ResponseError>>(serialized);
                }

                return _errors;
            }
        }

        private List<ResponseError> _errors;
    }
}