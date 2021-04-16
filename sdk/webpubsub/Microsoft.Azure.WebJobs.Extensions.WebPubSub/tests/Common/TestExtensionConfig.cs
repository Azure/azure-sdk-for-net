using System;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class TestExtensionConfig : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<BindingDataAttribute>().
                BindToInput(attr => attr.ToBeAutoResolve);
        }

        [Binding]
        private sealed class BindingDataAttribute : Attribute
        {
            public BindingDataAttribute(string toBeAutoResolve)
            {
                ToBeAutoResolve = toBeAutoResolve;
            }

            [AutoResolve]
            public string ToBeAutoResolve { get; set; }
        }
    }
}
