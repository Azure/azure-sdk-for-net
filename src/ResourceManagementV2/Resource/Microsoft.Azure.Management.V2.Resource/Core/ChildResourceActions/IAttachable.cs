namespace Microsoft.Azure.Management.V2.Resource.Core.ChildResourceActions
{
    /// <summary>
    /// The final stage of child object definition, at which it can be attached to the parent <cref="Attach()" />
    /// </summary>
    /// <typeparam name="ParentT"></typeparam>
    public interface IAttachable<ParentT>
    {
        /// <summary>
        /// Attaches this child object's definition to it's parent definition.
        /// </summary>
        /// <returns>The next stage of parent object definition</returns>
        ParentT Attach();
    }
}
