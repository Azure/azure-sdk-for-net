// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.JobRouter
{
    public partial class ExceptionPolicy : IUtf8JsonSerializable
    {
        /// <summary> Initializes a new instance of ExceptionPolicy. </summary>
        /// <param name="exceptionPolicyId"> Id of the policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionPolicyId"/> is null. </exception>
        public ExceptionPolicy(string exceptionPolicyId)
        {
            Argument.AssertNotNullOrWhiteSpace(exceptionPolicyId, nameof(exceptionPolicyId));

            Id = exceptionPolicyId;
        }

        /// <summary> (Optional) A collection of exception rules on the exception policy. Key is the Id of each exception rule. </summary>
        public IList<ExceptionRule> ExceptionRules { get; } = new List<ExceptionRule>();

        /// <summary> (Optional) The name of the exception policy. </summary>
        public string Name { get; set; }

        [CodeGenMember("Etag")]
        internal string _etag
        {
            get
            {
                return ETag.ToString();
            }
            set
            {
                ETag = new ETag(value);
            }
        }

        /// <summary> Concurrency Token. </summary>
        public ETag ETag { get; internal set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsCollectionDefined(ExceptionRules))
            {
                writer.WritePropertyName("exceptionRules"u8);
                writer.WriteStartArray();
                foreach (var item in ExceptionRules)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(ETag))
            {
                writer.WritePropertyName("etag"u8);
                writer.WriteStringValue(ETag.ToString());
            }
            writer.WriteEndObject();
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
