namespace Azure.ResourceManager.AlertRuleRecommendations
{
    public static partial class AlertRuleRecommendationsExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource> GetByResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource> GetByResourceAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource> GetByTargetType(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string targetType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource> GetByTargetTypeAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string targetType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerAlertRuleRecommendationsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAlertRuleRecommendationsContext() { }
        public static Azure.ResourceManager.AlertRuleRecommendations.AzureResourceManagerAlertRuleRecommendationsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.AlertRuleRecommendations.Mocking
{
    public partial class MockableAlertRuleRecommendationsArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertRuleRecommendationsArmClient() { }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource> GetByResource(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource> GetByResourceAsync(Azure.Core.ResourceIdentifier scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableAlertRuleRecommendationsSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAlertRuleRecommendationsSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource> GetByTargetType(string targetType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource> GetByTargetTypeAsync(string targetType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AlertRuleRecommendations.Models
{
    public partial class AlertRuleRecommendationResource : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource>
    {
        internal AlertRuleRecommendationResource() { }
        public string AlertRuleType { get { throw null; } }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> DisplayInformation { get { throw null; } }
        public Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate RuleArmTemplate { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAlertRuleRecommendationsModelFactory
    {
        public static Azure.ResourceManager.AlertRuleRecommendations.Models.AlertRuleRecommendationResource AlertRuleRecommendationResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string alertRuleType = null, string category = null, System.Collections.Generic.IDictionary<string, string> displayInformation = null, Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate ruleArmTemplate = null) { throw null; }
        public static Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate RuleArmTemplate(string schema = null, string contentVersion = null, System.BinaryData variables = null, System.BinaryData parameters = null, System.Collections.Generic.IEnumerable<System.BinaryData> resources = null) { throw null; }
    }
    public partial class RuleArmTemplate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate>
    {
        internal RuleArmTemplate() { }
        public string ContentVersion { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Resources { get { throw null; } }
        public string Schema { get { throw null; } }
        public System.BinaryData Variables { get { throw null; } }
        protected virtual Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AlertRuleRecommendations.Models.RuleArmTemplate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
