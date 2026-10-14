public virtual global::Samples.ChildClient GetChildClient(string tenant)
{
    global::Samples.Argument.AssertNotNull(tenant, nameof(tenant));
    return new global::Samples.ChildClient(Pipeline, _endpoint, _apiVersion, tenant);
}
