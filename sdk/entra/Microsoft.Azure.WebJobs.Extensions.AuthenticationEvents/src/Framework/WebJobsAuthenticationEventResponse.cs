// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>Represents an event response based on the event type and request.</summary>
    public abstract class WebJobsAuthenticationEventResponse : HttpResponseMessage
    {
        // internal HttpResponseMessage HttpResponseMessage { get; set; }
        /// <summary>Invalidates this instance. (Builds the Json payload).</summary>
        internal abstract void BuildJsonElement();

        /// <summary>Gets or sets the body of the event response.</summary>
        [Required]
        public string Body
        {
            get
            {
                if (_body == null)
                {
                    _body = Content == null ? string.Empty : Content.ReadAsStringAsync()?.Result;
                }
                return _body;
            }
            set
            {
                _body = value;
                Content = new StringContent(value, Encoding.UTF8, "application/json");
            }
        }

        private string _body;

        /// <summary>Creates an instance of a sub class of EventResponse based on type and assigns the json schema and payload to the newly created instance.</summary>
        /// <param name="type">The type to create.</param>
        /// <param name="body">The Json payload for the body.</param>
        /// <returns>A created instance of EventResponse based on the Type.</returns>
        /// <seealso cref="WebJobsAuthenticationEventResponse"/>
        internal static WebJobsAuthenticationEventResponse CreateInstance(Type type, string body)
        {
            WebJobsAuthenticationEventResponse response = (WebJobsAuthenticationEventResponse)Activator.CreateInstance(type, true);
            response.Body = body;
            return response;
        }

        internal virtual void InstanceCreated(AuthenticationEventJsonElement payload)
        {
            AuthenticationEventJsonElement jBody = new AuthenticationEventJsonElement(Body);

            Dictionary<string[], string> updates = new Dictionary<string[], string>();

            if (payload.Properties.ContainsKey("type") && jBody.Properties.ContainsKey("type"))
            {
                updates.Add(new string[] { "type" }, payload.GetPropertyValue("type"));
            }

            if (payload.Properties.ContainsKey("apiSchemaVersion") && jBody.Properties.ContainsKey("apiSchemaVersion"))
            {
                updates.Add(new string[] { "apiSchemaVersion" }, payload.GetPropertyValue("apiSchemaVersion"));
            }

            if (updates.Count != 0)
            {
                SetJsonValue(updates);
            }
        }

        /// <summary>Sets the json value in the current payload if path exists.</summary>
        /// <typeparam name="T">The type of the incoming value to set.</typeparam>
        /// <param name="value">The value to set.</param>
        /// <param name="path">The path to the Json Property, this will not navigate JArrays.</param>
        /// <exception cref="Exception">Thrown if the path cannot be found.</exception>
        internal void SetJsonValue<T>(T value, params string[] path)
        {
            AuthenticationEventJsonElement payload = new AuthenticationEventJsonElement(Body);
            (string key, Dictionary<string, object> props) = payload.FindPropertyDictionary(true, path);
            if (key == null)
            {
                throw new Exception(AuthenticationEventResource.Ex_Invalid_JsonPath);
            }

            props[key] = value;
            Body = payload.ToString();
        }

        internal void SetJsonValue<T>(Dictionary<string[], T> values)
        {
            AuthenticationEventJsonElement payload = new AuthenticationEventJsonElement(Body);
            foreach (KeyValuePair<string[], T> keyValuePair in values)
            {
                (string key, Dictionary<string, object> props) = payload.FindPropertyDictionary(true, keyValuePair.Key);
                if (key == null)
                {
                    throw new Exception(AuthenticationEventResource.Ex_Invalid_JsonPath);
                }

                props[key] = keyValuePair.Value;
            }

            Body = payload.ToString();
        }

        /// <summary>
        /// Performs the validation and throws an exception if it fails.
        /// </summary>
        /// <exception cref="AuthenticationEventTriggerResponseValidationException">
        /// The exception that is thrown when a validation exception is thrown
        /// </exception>
        internal void Validate()
        {
            try
            {
                Helpers.ValidateGraph(this);
                BuildJsonElement();
            }
            catch (ValidationException exception)
            {
                throw new AuthenticationEventTriggerResponseValidationException(exception.Message);
            }
        }
    }
}
