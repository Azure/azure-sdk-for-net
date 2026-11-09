using Azure.Core;

namespace Azure.ResourceManager.Models
{
    public abstract class TrackedResourceData
    {
        protected TrackedResourceData()
        {
        }

        protected TrackedResourceData(AzureLocation location)
        {
            Location = location;
        }

        public AzureLocation Location { get; }
    }
}

namespace Azure.ResourceManager.Test.Models
{
    public class WidgetData : Azure.ResourceManager.Models.TrackedResourceData
    {
    }
}
