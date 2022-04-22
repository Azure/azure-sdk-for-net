// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class DeploymentProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Template))
            {
                writer.WritePropertyName("template");
                //If Template is a string, then SDK should convert it into a json object
                //see https://github.com/Azure/azure-rest-api-specs/blob/b6b834584cb58a3c2cbe887570fa0942b397dfc7/specification/resources/resource-manager/Microsoft.Resources/stable/2021-04-01/resources.json#L4564
                if (Template is string s)
                {
                    var rootElement = JsonDocument.Parse(s).RootElement;
                    writer.WriteObjectValue(rootElement);
                }
                else
                {
                    writer.WriteObjectValue(Template);
                }
            }
            if (Optional.IsDefined(TemplateLink))
            {
                writer.WritePropertyName("templateLink");
                writer.WriteObjectValue(TemplateLink);
            }
            if (Optional.IsDefined(Parameters))
            {
                writer.WritePropertyName("parameters");
                //If Parameters is a string, then SDK should convert it into a json object
                //see https://github.com/Azure/azure-rest-api-specs/blob/b6b834584cb58a3c2cbe887570fa0942b397dfc7/specification/resources/resource-manager/Microsoft.Resources/stable/2021-04-01/resources.json#L4570
                if (Parameters is string s)
                {
                    var rootElement = JsonDocument.Parse(s).RootElement;
                    writer.WriteObjectValue(rootElement);
                }
                else
                {
                    writer.WriteObjectValue(Parameters);
                }
            }
            if (Optional.IsDefined(ParametersLink))
            {
                writer.WritePropertyName("parametersLink");
                writer.WriteObjectValue(ParametersLink);
            }
            writer.WritePropertyName("mode");
            writer.WriteStringValue(Mode.ToString());
            if (Optional.IsDefined(DebugSetting))
            {
                writer.WritePropertyName("debugSetting");
                writer.WriteObjectValue(DebugSetting);
            }
            if (Optional.IsDefined(OnErrorDeployment))
            {
                writer.WritePropertyName("onErrorDeployment");
                writer.WriteObjectValue(OnErrorDeployment);
            }
            if (Optional.IsDefined(ExpressionEvaluationOptions))
            {
                writer.WritePropertyName("expressionEvaluationOptions");
                writer.WriteObjectValue(ExpressionEvaluationOptions);
            }
            writer.WriteEndObject();
        }
    }
}
