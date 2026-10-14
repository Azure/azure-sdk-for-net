public virtual global::Samples.ChildClient GetChildClient(string other)
{
    return new global::Samples.ChildClient(Pipeline, _endpoint, _apiVersion, other);
}
