namespace Microsoft.WindowsAzure.Storage
{
    using System;

    public sealed class DescriptionAttribute : Attribute
    {
        public DescriptionAttribute(string description)
        {
            this.Description = description;
        }

        public string Description { get; internal set; }
    }
}
