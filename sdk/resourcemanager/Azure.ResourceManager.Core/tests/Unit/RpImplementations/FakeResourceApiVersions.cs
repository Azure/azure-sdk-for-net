namespace Azure.ResourceManager.Core.Tests
{
    public class FakeResourceApiVersions : ApiVersionsBase
    {
        public static readonly FakeResourceApiVersions V2020_06_01 = new FakeResourceApiVersions("2020-06-01");
        public static readonly FakeResourceApiVersions V2019_12_01 = new FakeResourceApiVersions("2019-12-01");
        public static readonly FakeResourceApiVersions V2019_12_01_preview = new FakeResourceApiVersions("2019-12-01-preview");
        public static readonly FakeResourceApiVersions V2019_12_01_preview_1 = new FakeResourceApiVersions("2019-12-01-preview-1");
        public static readonly FakeResourceApiVersions V2019_12_01_foobar = new FakeResourceApiVersions("2019-12-01-foobar");
        public static readonly FakeResourceApiVersions Default = V2020_06_01;

        private FakeResourceApiVersions(string value) : base(value) { }

        public static implicit operator string(FakeResourceApiVersions version)
        {
            if (version == null)
                return null;
            return version.ToString();
        }
    }
}
