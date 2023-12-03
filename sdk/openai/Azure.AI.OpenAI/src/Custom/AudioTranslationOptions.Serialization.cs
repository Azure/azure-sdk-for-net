// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Net.Http;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    public partial class AudioTranslationOptions
    {
        internal virtual RequestContent ToRequestContent()
        {
            var content = new MultipartFormDataRequestContent();
            content.Add(new StringContent(DeploymentName), "model");
            content.Add(new ByteArrayContent(AudioData.ToArray()), "file", "@file.wav");
            if (Optional.IsDefined(ResponseFormat))
            {
                content.Add(new StringContent(ResponseFormat.ToString()), "response_format");
            }
            if (Optional.IsDefined(Prompt))
            {
                content.Add(new StringContent(Prompt), "prompt");
            }
            if (Optional.IsDefined(Temperature))
            {
                content.Add(new StringContent($"{Temperature}"), "temperature");
            }
            return content;
        }
    }
}
