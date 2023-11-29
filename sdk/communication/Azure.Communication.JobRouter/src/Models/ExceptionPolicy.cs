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
        /// <summary> Initializes a new instance of an exception policy. </summary>
        /// <param name="exceptionPolicyId"> Id of an exception policy. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="exceptionPolicyId"/> is null. </exception>
        public ExceptionPolicy(string exceptionPolicyId)
        {
            Argument.AssertNotNullOrWhiteSpace(exceptionPolicyId, nameof(exceptionPolicyId));

            Id = exceptionPolicyId;
        }

        /// <summary> A collection of exception rules on the exception policy. </summary>
        public IList<ExceptionRule> ExceptionRules { get; } = new List<ExceptionRule>();

        /// <summary> Friendly name of this policy. </summary>
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

        /// <summary> The entity tag for this resource. </summary>
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
