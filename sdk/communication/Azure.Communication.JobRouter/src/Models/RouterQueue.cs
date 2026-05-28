// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class RouterQueue
    {
        /// <summary> Initializes a new instance of a queue. </summary>
        /// <param name="queueId"> Id of a queue. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="queueId"/> is null. </exception>
        public RouterQueue(string queueId)
        {
            Argument.AssertNotNullOrWhiteSpace(queueId, nameof(queueId));

            Id = queueId;
        }

        [CodeGenMember("Labels")]
        internal IDictionary<string, object> _labels
        {
            get
            {
                return Labels != null && Labels.Count != 0
                    ? Labels?.ToDictionary(x => x.Key, x => x.Value?.Value)
                    : new ChangeTrackingDictionary<string, object>();
            }
            set
            {
                if (value != null && value.Count != 0)
                {
                    foreach (var label in value)
                    {
                        Labels[label.Key] = new RouterValue(label.Value);
                    }
                }
            }
        }

        /// <summary>
        /// A set of key/value pairs that are identifying attributes used by the rules engines to make decisions. Values must be primitive values - number, string, boolean.
        /// </summary>
        public IDictionary<string, RouterValue> Labels { get; } = new Dictionary<string, RouterValue>();

        /// <summary> Friendly name of this queue. </summary>
        public string Name { get; set; }

        /// <summary> Id of a distribution policy that will determine how a job is distributed to workers. </summary>
        public string DistributionPolicyId { get; set; }

        /// <summary> Id of an exception policy that determines various job escalation rules. </summary>
        public string ExceptionPolicyId { get; set; }

        /// <summary> The entity tag for this resource. </summary>
        [CodeGenMember("Etag")]
        public ETag ETag { get; }

        /// <summary> Initializes a new instance of a queue. </summary>
        internal RouterQueue()
        {
            _labels = new ChangeTrackingDictionary<string, object>();
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
