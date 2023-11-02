// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal static class Helpers
    {
        internal static Dictionary<string, Type> _actionMapping = new Dictionary<string, Type>()
        {
            {"microsoft.graph.tokenissuancestart.provideclaimsfortoken", typeof(ProvideClaimsForToken) }
        };

        internal static EventDefinition GetEventDefintionFromPayload(string payload)
        {
            try
            {
                AuthenticationEventJsonElement jPayload = new AuthenticationEventJsonElement(payload);
                string comparable = string.Empty;
                if (jPayload.Properties.ContainsKey("type"))
                {
                    comparable = jPayload.GetPropertyValue("type");
                }

                foreach (EventDefinition eventDefinition in Enum.GetValues(typeof(EventDefinition)))
                {
                    AuthenticationEventMetadataAttribute eventMetadata = eventDefinition.GetAttribute<AuthenticationEventMetadataAttribute>();
                    if (eventMetadata.EventIdentifier.Equals(comparable, StringComparison.OrdinalIgnoreCase))
                    {
                        return eventDefinition;
                    }
                }

                throw new InvalidOperationException(
                    string.Format(CultureInfo.CurrentCulture, AuthenticationEventResource.Ex_Comparable_Not_Found, comparable));
            }
            catch (Exception ex)
            {
                throw new AuthenticationEventTriggerRequestValidationException(ex.Message, ex.InnerException);
            }
        }

        internal static HttpResponseMessage HttpErrorResponse(Exception ex)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
            {
                Content = new StringContent(GetFailedRequestPayload(ex))
            };

            // Set the metrics on header
            EventTriggerMetrics.Instance.SetMetricHeaders(response);

            return response;
        }

        internal static string GetFailedRequestPayload(Exception ex)
        {
            List<string> errors = new List<string>();
            if (ex != null)
            {
                errors.Add(ex.Message);
                ex = ex.InnerException;
                while (ex != null)
                {
                    if (ex is AggregateException agEx)
                    {
                        errors.AddRange(agEx.InnerExceptions.Select(m => m.Message).ToArray());
                    }
                    else
                    {
                        errors.Add(ex.Message);
                    }

                    ex = ex.InnerException;
                }
            }
            else
            {
                errors.Add(AuthenticationEventResource.Ex_Gen_Failure);
            }

            return $"{{\"errors\":[\"{String.Join("\",\"", errors.Select(m => m))}\"]}}";
        }

        internal static HttpResponseMessage HttpUnauthorizedResponse()
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        }

        internal static HttpResponseMessage HttpJsonResponse(AuthenticationEventJsonElement json)
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(json.ToString(), Encoding.UTF8, "application/json")
            };
        }

        /// <summary>Determines whether the specified input is json.</summary>
        /// <param name="input">The input.</param>
        internal static void ValidateJson(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new JsonException(AuthenticationEventResource.Ex_Empty_Json);
            }

            // try parsing input to json object
            using var _ = JsonDocument.Parse(input);
        }

        internal static AuthenticationEventAction GetEventActionForActionType(string actionType)
        {
            return actionType != null && _actionMapping.ContainsKey(actionType.ToLower(CultureInfo.CurrentCulture))
                 ? (AuthenticationEventAction)Activator.CreateInstance(_actionMapping[actionType.ToLower(CultureInfo.CurrentCulture)])
                 : throw new Exception(String.Format(CultureInfo.CurrentCulture, AuthenticationEventResource.Ex_Invalid_Action, actionType, String.Join("', '", _actionMapping.Select(x => x.Key))));
        }

        internal static void ValidateGraph(object obj)
        {
            if (obj == null) return;//Fail safe not to try validate any null objects.
            try
            {
                Validator.ValidateObject(obj, new ValidationContext(obj), true);
                foreach (var prop in obj.GetType().GetProperties())
                {
                    if (prop.PropertyType == typeof(string) || prop.PropertyType.IsValueType) continue;

                    object value = prop.GetValue(obj);
                    if (value == null) continue;

                    if (value is IEnumerable values)
                    {
                        foreach (object i in values)
                        {
                            ValidateGraph(i);
                        }
                    }
                    else
                    {
                        ValidateGraph(value);
                    }
                }
            }
            catch (ValidationException val)
            {
                throw new ValidationException($"{obj.GetType().Name}: {val.Message}");
            }
        }
    }
}
