namespace Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models
{
    using Newtonsoft.Json;

    public partial class ErrorResponse
    {
        private string code;
        private string message;

        /// <summary>
        /// Error code.
        /// </summary>
        public string Code
        {
            get
            {
                if (code == null)
                {
                    code = GetCodeFromAdditionalProperties();
                }
                return code;
            }
        }

        /// <summary>
        /// A description of the error.
        /// </summary>
        public string Message
        {
            get
            {
                if (message == null)
                {
                    message = GetMessageFromAdditionalProperties();
                }
                return message;
            }
        }

        private string GetCodeFromAdditionalProperties()
        {
            if (AdditionalProperties == null) return "Generic error";
            if (AdditionalProperties.TryGetValue("error", out object data))
            {
                var error = JsonConvert.DeserializeObject<OperationError>(data.ToString());
                return error.Code;
            }
            if (AdditionalProperties.TryGetValue("statusCode", out data))
            {
                return data.ToString();
            }
            return "Generic error";
        }

        private string GetMessageFromAdditionalProperties()
        {
            if (AdditionalProperties == null) return "Generic error";
            if (AdditionalProperties.TryGetValue("error", out object data))
            {
                var error = JsonConvert.DeserializeObject<OperationError>(data.ToString());
                return error.Message;
            }
            if (AdditionalProperties.TryGetValue("message", out data))
            {
                return data.ToString();
            }
            return "Generic message";
        }
    }
}
