// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Protocols;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Queues
{
    /// <summary>
    /// Tracks causality via JSON formatted queue message content.
    /// Adds an extra field to the JSON object for the parent guid name.
    /// </summary>
    /// <remarks>
    /// Important that this class can interoperate with external queue messages,
    /// so be resilient to a missing guid marker.
    /// Can we switch to some auxiliary table? Beware, CloudQueueMessage.
    /// Id is not filled out until after the message is queued,
    /// but then there's a race between updating the aux storage and another function picking up the message.
    /// </remarks>
    internal class QueueCausalityManager
    {
        private const string ParentGuidFieldName = "$AzureWebJobsParentId";

        private readonly ILogger<QueueCausalityManager> _logger;

        public QueueCausalityManager(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<QueueCausalityManager>();
        }

        public static void SetOwner(Guid functionOwner, JObject token)
        {
            if (token == null)
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (!Guid.Equals(Guid.Empty, functionOwner))
            {
                token[ParentGuidFieldName] = functionOwner.ToString();
            }
        }

        [DebuggerNonUserCode]
        public Guid? GetOwner(QueueMessage msg)
        {
            string text = msg.TryGetAsString(_logger);

            if (text == null)
            {
                return null;
            }

            IDictionary<string, JToken> json;
            try
            {
                json = JsonSerialization.ParseJObject(text);
            }
            catch (Exception)
            {
                return null;
            }

            if (json == null || !json.ContainsKey(ParentGuidFieldName) || json[ParentGuidFieldName].Type != JTokenType.String)
            {
                return null;
            }

            string val = (string)json[ParentGuidFieldName];

            Guid guid;
            if (Guid.TryParse(val, out guid))
            {
                return guid;
            }
            return null;
        }
    }
}
