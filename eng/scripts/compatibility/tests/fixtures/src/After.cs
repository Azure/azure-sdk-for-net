namespace CompatibilityFixture;

public class Widget : FixtureDependency.Parent
{
    public void NewName() { }
    public string Signature() => "";
    public void Parameter(string newName) { }
    [Marker(2)]
    public void AttributeChange() { }
    public void Virtual() { }
    public int Value { get; }
}

public interface IContract { void Required(); }
public enum Flavor : int { Default = 2 }
public enum ValueOnly { Default = 2 }
