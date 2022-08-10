// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework
{
    /// <summary>Represents an event response based on the event type and request.</summary>
    public abstract class AuthEventResponse : HttpResponseMessage
    {
        // internal HttpResponseMessage HttpResponseMessage { get; set; }
        /// <summary>Invalidates this instance. (Builds the Json payload).</summary>
        internal abstract void Invalidate();

        /// <summary>Gets the Json schema for the event response.</summary>
        /// <value>The schema.</value>
        //  [JsonPropertyName("schema")]
        //  [Required]
        internal string Schema { get; set; }

        /// <summary>Gets or sets the body of the event response.</summary>
        /// <value>The Json payload for the body.</value>
       // [JsonPropertyName("body")]
        [Required]

        public string Body
        {
            get { return Content == null ? string.Empty : Content.ReadAsStringAsync()?.Result; }
            set
            {
                Content = new StringContent(value, Encoding.UTF8, "application/json");
            }
        }

        /// <summary>Creates an instance of a sub class of EventResponse based on type and assigns the json schema and payload to the newly created instance.</summary>
        /// <param name="type">The type to create.</param>
        /// <param name="schema">The Json schema.</param>
        /// <param name="body">The Json payload for the body.</param>
        /// <returns>A created instance of EventResponse based on the Type.</returns>
        /// <seealso cref="AuthEventResponse"/>
        internal static AuthEventResponse CreateInstance(Type type, string schema, string body)
        {
            AuthEventResponse response = (AuthEventResponse)Activator.CreateInstance(type, true);
            response.Schema = schema;
            response.Body = body;
            return response;
        }

        internal virtual void InstanceCreated(AuthEventJsonElement payload)
        {
            AuthEventJsonElement jBody = new(Body);

            Dictionary<string[], string> updates = new();

            if (payload.Properties.ContainsKey("type") && jBody.Properties.ContainsKey("type"))
                updates.Add(new string[] { "type" }, payload.GetPropertyValue("type"));

            if (payload.Properties.ContainsKey("apiSchemaVersion") && jBody.Properties.ContainsKey("apiSchemaVersion"))
                updates.Add(new string[] { "apiSchemaVersion" }, payload.GetPropertyValue("apiSchemaVersion"));

            if (updates.Count != 0)
                SetJsonValue(updates);
        }

        /// <summary>Sets the json value in the current payload if path exists.</summary>
        /// <typeparam name="T">The type of the incoming value to set.</typeparam>
        /// <param name="value">The value to set.</param>
        /// <param name="path">The path to the Json Property, this will not navigate JArrays.</param>
        /// <exception cref="Exception">Thrown if the path cannot be found.</exception>
        internal void SetJsonValue<T>(T value, params string[] path)
        {
            AuthEventJsonElement payload = new(Body);
            (string key, Dictionary<string, object> props) = payload.FindPropertyDictionary(true, path);
            if (key == null)
                throw new Exception(AuthEventResource.Ex_Invalid_JsonPath);

            props[key] = value;
            Body = payload.ToString();
        }

        internal void SetJsonValue<T>(Dictionary<string[], T> values)
        {
            AuthEventJsonElement payload = new(Body);
            foreach (KeyValuePair<string[], T> keyValuePair in values)
            {
                (string key, Dictionary<string, object> props) = payload.FindPropertyDictionary(true, keyValuePair.Key);
                if (key == null)
                    throw new Exception(AuthEventResource.Ex_Invalid_JsonPath);
                props[key] = keyValuePair.Value;
            }

            Body = payload.ToString();
        }

        /// <summary>Validates the current Json body payload against it's associated Json schema.</summary>
        /// <exception cref="AggregateException">An aggregation of the errors within the Json if the payload fails the validation.</exception>
        /// <seealso cref="Schema"/>
        internal void Validate()
        {
            if (Schema != null)
            {
                SchemaValidator schemaValidator = new(new AuthEventJsonElement(Schema));
                schemaValidator.Validate(new AuthEventJsonElement(Body));
                if (!schemaValidator.Valid)
                    throw new AggregateException(AuthEventResource.Ex_Invalid_Response, schemaValidator.Errors);
            }
            Helpers.ValidateGraph(this);
        }

        internal void MarkAsFailed(Exception ex)
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest;
            ReasonPhrase = ex.Message;
            Body = Helpers.GetFailedRequestPayload(ex);
        }

        internal void MarkAsUnauthorised()
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized;
            ReasonPhrase = String.Empty;
            Body = String.Empty;
        }
    }
}
