namespace Client;

/// <summary>
/// This is used to configure this application.
/// </summary>
internal interface IConfig
{
    // other application settings go here

    /// <summary>
    /// Call this method to validate the configuration.
    /// </summary>
    public void Validate();
}