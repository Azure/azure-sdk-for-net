// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Framework;
using Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.TokenIssuanceStart.Actions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    internal static class Helpers
    {
        internal static Dictionary<string, Type> _actionMapping = new Dictionary<string, Type>()
        {
            {"microsoft.graph.provideclaimsfortoken",typeof(ProvideClaimsForToken) },
            {"provideclaimsfortoken",typeof(ProvideClaimsForTokenLegacy) }
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

                throw new Exception(string.Format(CultureInfo.CurrentCulture, AuthenticationEventResource.Ex_Comparable_Not_Found, comparable));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, AuthenticationEventResource.Ex_Event_Missing, ex.Message));
            }
        }

        internal static HttpResponseMessage HttpErrorResponse(Exception ex)
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
            {
                Content = new StringContent(GetFailedRequestPayload(ex))
            };
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
        /// <returns>
        ///   <c>true</c> if the specified input is json; otherwise, <c>false</c>.</returns>
        internal static bool IsJson(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            input = input.Trim();
            return (input.StartsWith("{", StringComparison.OrdinalIgnoreCase) && input.EndsWith("}", StringComparison.OrdinalIgnoreCase))
                || (input.StartsWith("[", StringComparison.OrdinalIgnoreCase) && input.EndsWith("]", StringComparison.OrdinalIgnoreCase));
        }

        internal static AuthenticationEventAction GetEventActionForActionType(string actionType)
        {
            return actionType != null && _actionMapping.ContainsKey(actionType.ToLower(CultureInfo.CurrentCulture))
                 ? (AuthenticationEventAction)Activator.CreateInstance(_actionMapping[actionType.ToLower(CultureInfo.CurrentCulture)])
                 : throw new Exception(String.Format(CultureInfo.CurrentCulture, AuthenticationEventResource.Ex_Action_Invalid, actionType, String.Join("', '", _actionMapping.Select(x => x.Key))));
        }

        internal static void ValidateGraph(object graph)
        {
            var validationResults = new List<ValidationResult>();

            ValidateGraph(graph, validationResults);

            if (validationResults.Count > 0)
            {
                throw new AggregateException(AuthenticationEventResource.Ex_Invalid_Payload, validationResults.Select(v => new Exception(v.ErrorMessage)));
            }
        }

        private static void ValidateGraph(object obj, List<ValidationResult> validationResults)
        {
            List<ValidationResult> objectValidations = new List<ValidationResult>();

            var props = obj.GetType().GetProperties().Where(p => p.GetCustomAttributes(false).FirstOrDefault(a => typeof(ValidationAttribute).IsAssignableFrom(a.GetType())) != null);

            foreach (var prop in props)
            {
                object inst = prop.GetValue(obj);

                Validator.TryValidateProperty(inst, new ValidationContext(obj) { MemberName = prop.Name }, objectValidations);

                if (inst != null)//Short circuit the validation if the parent is null.
                {
                    ValidateGraph(inst, validationResults);
                }
            }

            validationResults.AddRange(objectValidations.Select(f => { f.ErrorMessage = $"{obj.GetType().Name}: {f.ErrorMessage}"; return f; }));
        }
    }
}
