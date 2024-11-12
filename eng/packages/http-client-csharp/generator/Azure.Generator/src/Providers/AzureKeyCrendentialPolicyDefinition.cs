using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Generator.CSharp.Expressions;
using Microsoft.Generator.CSharp.Primitives;
using Microsoft.Generator.CSharp.Providers;
using Microsoft.Generator.CSharp.Statements;
using System.IO;
using static Microsoft.Generator.CSharp.Snippets.Snippet;

namespace Azure.Generator.Providers
{
    internal class AzureKeyCrendentialPolicyDefinition : TypeProvider
    {
        private readonly FieldProvider _prefixField;
        private readonly FieldProvider _credentialField;

        public AzureKeyCrendentialPolicyDefinition()
        {
            _prefixField = new FieldProvider(FieldModifiers.Private, new CSharpType(typeof(string), isNullable: true), "_prefix", this);
            _credentialField = new FieldProvider(FieldModifiers.Private, typeof(AzureKeyCredential), "_credential", this);
        }

        protected override string BuildName() => "AzureKeyCredentialPolicy";

        protected override string BuildRelativeFilePath() => Path.Combine("src", "Generated", "Internal", $"{Name}.cs");

        protected override MethodProvider[] BuildMethods()
        {
            return new MethodProvider[]
            {
                BuildOnSedingRequest()
            };
        }

        protected override CSharpType? GetBaseType() => new CSharpType(typeof(HttpPipelineSynchronousPolicy));

        private const string onSendingRequestMethodName = "OnSendingRequest";
        private MethodProvider BuildOnSedingRequest()
        {
            var messageParameter = new ParameterProvider("message", $"", typeof(HttpMessage));
            var signature = new MethodSignature(
                onSendingRequestMethodName,
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Override,
                null,
                null,
                [messageParameter]);

            var value = new TernaryConditionalExpression(_prefixField)
            var method = new MethodProvider(signature, new MethodBodyStatement[]
            {
                Base.Invoke(onSendingRequestMethodName, [messageParameter]).Terminate(),
                messageParameter.Property(nameof(HttpMessage.Request)).Property(nameof(Request.Headers)).Invoke(nameof(RequestHeaders.SetValue))
            }, this);
            return method;
        }
    }
}
