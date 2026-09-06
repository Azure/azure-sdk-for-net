namespace CompatibilityFixture;

public class Widget : FixtureDependency.Parent
{
    public void Removed() { }
    public void OldName() { }
    public int Signature() => 0;
    public void Parameter(string oldName) { }
    [Marker(1)]
    public void AttributeChange() { }
    public virtual void Virtual() { }
    public int Value { get; set; }
}

public interface IContract { }
public enum Flavor : byte { Default = 1 }
public enum ValueOnly { Default = 1 }
public class RemovedType { }
