# Handle Ambiguity Between Protocol Method and Convenience Method

## Background

In a DPG library, protocol methods will be generated for a swagger input, and both protocol methods and convenience methods will be generated for a TypeSpec input. We expect to make the convenience method an overload of its protocol method, so that users could be very clear they are representing the same operation. For example,

```C#
public virtual async Task<Response<Model>> OperationAsync(string requiredId, string optionalId = null, CancellationToken cancellationToken = default) // Convenience method
{
    ...
}

public virtual async Task<Response> OperationAsync(string requiredId, string optionalId = null, RequestContext context = null) // Protocol method
{
    ...
}
```
However, this might lead to the compilation error
```
Error   CS0121  The call is ambiguous between the following methods or properties: 'SomeClass.OperationAsync(string, CancellationToken)' and 'SomeClass.OperationAsync(string, RequestContext)'
```
when calling `OperationAsync("<some string>")`.

This article is to explain how we handle this ambiguity issue and how our solution impacts the generated API.

## Solutions

There are two ways to handle this error:

1. Make all the parameters in **protocol methods** required.
```C#
public virtual async Task<Response<Model>> OperationAsync(string requiredId, string optionalId = null, CancellationToken cancellationToken = default) // Convenience method
{
    ...
}

public virtual async Task<Response> OperationAsync(string requiredId, string optionalId, RequestContext context) // Protocol method
{
    ...
}
```
2. Append `Value` to the name of the **convenience method**.
```C#
public virtual async Task<Response<Model>> OperationValueAsync(string requiredId, string optionalId = null, CancellationToken cancellationToken = default) // Convenience method
{
    ...
}

public virtual async Task<Response> OperationAsync(string requiredId, string optionalId = null, RequestContext context = null) // Protocol method
{
    ...
}
```

Our strategy is:
- If the protocol method hasn’t been GAed, the first solution is taken if there exists an ambiguous call.
- If the protocol method is already GAed, the second solution is taken because we cannot change protocol method anymore.

## Scope of ambiguity we handle

Not all the pairs of protocol method and convenience method will have such problem. Below is a case when there is no ambiguity if users are calling normally by passing a `model` or a `content`. (They could not pass in `null` because it will throw error)
```C#
public virtual async Task<Response<Model>> OperationAsync(Model model, CancellationToken cancellationToken = default) // Convenience method
{
    Argument.AssertNotNull(model, nameof(model));
    ...
}

public virtual async Task<Response> OperationAsync(RequestContent content, RequestContext context = null) // Protocol method
{
    Argument.AssertNotNull(content, nameof(content));
    ...
}
```
Not all the ambiguities could be resolved by the first solution. For example, even we handle the example in **Background** section as follows
```C#
public virtual async Task<Response<Model>> OperationAsync(string requiredId, string optionalId = null, CancellationToken cancellationToken = default) // Convenience method
{
    ...
}

public virtual async Task<Response> OperationAsync(string requiredId, string optionalId, RequestContext context) // Protocol method
{
    ...
}
```
`OperationAsync("required", "optional", default)` and `OperationAsync("required", "optional", new())` are two examples that still lead to compilation error of ambiguity.

Considering all of these, we only guarantee that we will not generate code which leads to ambiguous call when:
1. The call doesn't have any actual parameter of `null`, `default`, `new()`. For example, we don't care whether `OperationAsync("required", "optional", default)` will lead to ambiguity. Details [here](#special-values-not-taken-into-ambiguity-consideration).
2. The call only has its required parameters passed in. For example, we can only ensure `OperationAsync("required")` is not an ambiguous call.

See below section for more specific examples and corresponding explanation.

## Examples

### Operation without input
Spec:
```
model Model {}
op operation(@path requiredId: string, @path optionalId?: string): Model;
```
What we try to generate:
```C#
public virtual async Task<Response<Model>> OperationAsync(string requiredId, string optionalId = null, CancellationToken cancellationToken = default) // Convenience method
{
    ...
}

public virtual async Task<Response> OperationAsync(string requiredId, string optionalId = null, RequestContext context = null) // Protocol method
{
    ...
}
```
It only has one required parameter `requiredId`, so the call that we guarantee will not have ambiguity is
```C#
OperationAsync("requiredId");
```
Then we find that this call has ambiguity error, so we have to change our signature by choosing from [one of these solutions](#solution).

### Operation with input
Spec:
```
model Model {}
op operation(@body model: Model): Model;
```
```C#
public virtual async Task<Response<Model>> OperationAsync(Model model, CancellationToken cancellationToken = default) // Convenience method
{
    ...
}

public virtual async Task<Response> OperationAsync(RequestContent content, RequestContext context = null) // Protocol method
{
    ...
}
```
No matter if the input model is required or optional in spec, it is a required parameter in the signature. So, what we care about are:
```C#
OperationAsync(new Model());
OperationAsync(new RequestContent());
```
Then we find out these calls are fine, so just keep these signatures.

### Operation without both input and output
Spec:
```
op operation(@path requiredId: string, @path optionalId?: string): void;
```
What we try to generate:
```C#
public virtual async Task<Response> OperationAsync(string requiredId, string optionalId = null, RequestContext context = null) // Protocol method
{
    ...
}
```
We don't generate convenience method for this case (see [this](#convenience-method-not-always-generated) to see why), so there will be no ambiguity.
### Operation with spread scenario
Spec:
```
alias OperationAlias = {
  requiredId: string;
  optionalId?: string;
};
op operation(...OperationAlias): void;
```
What we try to generate:
```C#
public virtual async Task<Response> OperationAsync(string requiredId, string optionalId = null, CancellationToken cancellationToken = default) // Convenience method
{
    ...
}
public virtual async Task<Response> OperationAsync(RequestContent content, RequestContext context = null) // Protocol method
{
    ...
}
```
The convenience method has a required parameter `requiredId` and protocol method has a required method `content`, so what we guarantee will not have ambiguity are
```C#
OperationAsync("requiredId");
OperationAsync(new RequestContent());
```
Then we find these calls are fine, so just keep these signatures.

## Appendix
### Convenience method not always generated
There is one [situation](#operation-without-both-input-and-output) we don't generate convenience method. Think about what would be like if we generate the convenience method.
```C#
public virtual async Task<Response> OperationAsync(string requiredId, string optionalId = null, CancellationToken cancellationToken = default) // Convenience method
{
    ...
    RequestContext context = FromCancellationToken(cancellationToken);
    OperationAsync(requiredId, optionalId, context);
    ...
}
public virtual async Task<Response> OperationAsync(string requiredId, string optionalId = null, RequestContext context = null) // Protocol method
{
    ...
}
```
The convenience method is just a wrapper and doesn't have any value. So, we just skip generating it.

### Special values not taken into ambiguity consideration
Think about these totally valid overloads that you've seen many times in your daily development.
```C#
class IntModel
{
    public int Value {get; set;}
}

class DoubleModel
{
    public double Value {get; set;}
}

int Add(IntModel a, IntModel b)
{
    return a.Value + b.Value;
}
double Add(DoubleModel a, DoubleModel b)
{
    return a.Value + b.Value;
}
```
When calling `Add(null, null)` or `Add(default, default)` or `Add(new(), new())`, ambiguity error still exists. Therefore we don't care about `null`, or `default`, or `new()`.