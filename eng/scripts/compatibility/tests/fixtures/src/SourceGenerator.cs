using System.Text.Json.Serialization;

namespace CompatibilityFixture;

[JsonSerializable(typeof(Widget))]
internal partial class FixtureJsonContext : JsonSerializerContext { }
