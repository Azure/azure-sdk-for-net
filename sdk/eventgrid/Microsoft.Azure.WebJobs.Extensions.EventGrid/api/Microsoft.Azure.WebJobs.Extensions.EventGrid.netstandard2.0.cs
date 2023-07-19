namespace Microsoft.Azure.WebJobs.Extensions.EventGrid
{
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter | System.AttributeTargets.ReturnValue)]
    public sealed partial class EventGridAttribute : System.Attribute
    {
        public EventGridAttribute() { }
        public string Connection { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AppSettingAttribute]
        public string TopicEndpointUri { get { throw null; } set { } }
        [Microsoft.Azure.WebJobs.Description.AppSettingAttribute]
        public string TopicKeySetting { get { throw null; } set { } }
    }
    [Microsoft.Azure.WebJobs.Description.BindingAttribute]
    [System.AttributeUsageAttribute(System.AttributeTargets.Parameter)]
    public sealed partial class EventGridTriggerAttribute : System.Attribute
    {
        public EventGridTriggerAttribute() { }
    }
    public static partial class EventGridWebJobsBuilderExtensions
    {
        public static Microsoft.Azure.WebJobs.IWebJobsBuilder AddEventGrid(this Microsoft.Azure.WebJobs.IWebJobsBuilder builder) { throw null; }
    }
}
