using Azure.AI.AgentServer.Responses.Internal;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.Validation;

/// <summary>
/// Tests for builder lifecycle validation — missing required fields at EmitDone()/EmitAdded(),
/// and valid usage passing through without errors.
/// Covers T031, T032.
/// </summary>
public class BuilderLifecycleValidationTests
{
    // -----------------------------------------------------------------------
    // T031 — Missing required fields at emit time
    // -----------------------------------------------------------------------

    [Test]
    public void OutputItemMessageBuilder_EmitDone_WithoutContent_ThrowsValidation()
    {
        var stream = CreateTestStream();
        var builder = stream.AddOutputItemMessage();
        builder.EmitAdded();

        // EmitDone without any content parts should throw
        var ex = Assert.Throws<ResponseValidationException>(() => builder.EmitDone());
        Assert.IsNotEmpty(ex.Errors);
    }

    [Test]
    public void OutputItemFunctionCallBuilder_EmitDone_SetsArguments()
    {
        var stream = CreateTestStream();
        var builder = stream.AddOutputItemFunctionCall("get_weather", "call_123");
        builder.EmitAdded();
        builder.EmitArgumentsDone("""{"location": "Seattle"}""");

        // EmitDone with arguments set should succeed
        var evt = builder.EmitDone();
        Assert.IsNotNull(evt);
    }

    // -----------------------------------------------------------------------
    // T032 — Valid response objects pass through both layers
    // -----------------------------------------------------------------------

    [Test]
    public void OutputItemMessageBuilder_ValidLifecycle_Succeeds()
    {
        var stream = CreateTestStream();
        var builder = stream.AddOutputItemMessage();
        builder.EmitAdded();
        var textBuilder = builder.AddTextContent();
        textBuilder.EmitAdded();
        textBuilder.EmitDone("Hello, world!");
        builder.EmitContentDone(textBuilder);

        // EmitDone with content should succeed
        var evt = builder.EmitDone();
        Assert.IsNotNull(evt);
    }

    [Test]
    public void OutputItemBuilder_EmitAdded_ThenDone_ValidLifecycle()
    {
        var stream = CreateTestStream();
        var builder = stream.AddOutputItemFunctionCall("test", "call_1");
        builder.EmitAdded();
        builder.EmitArgumentsDone("{}");
        var evt = builder.EmitDone();
        Assert.IsNotNull(evt);
    }

    [Test]
    public void OutputItemBuilder_DoubleEmitAdded_Throws()
    {
        var stream = CreateTestStream();
        var builder = stream.AddOutputItemFunctionCall("test", "call_1");
        builder.EmitAdded();

        Assert.Throws<InvalidOperationException>(() => builder.EmitAdded());
    }

    [Test]
    public void OutputItemBuilder_EmitDone_BeforeAdded_Throws()
    {
        var stream = CreateTestStream();
        var builder = stream.AddOutputItemFunctionCall("test", "call_1");
        builder.EmitArgumentsDone("{}");

        Assert.Throws<InvalidOperationException>(() => builder.EmitDone());
    }

    [Test]
    public void OutputItemBuilder_EmitAfterDone_Throws()
    {
        var stream = CreateTestStream();
        var builder = stream.AddOutputItemFunctionCall("test", "call_1");
        builder.EmitAdded();
        builder.EmitArgumentsDone("{}");
        builder.EmitDone();

        Assert.Throws<InvalidOperationException>(() => builder.EmitDone());
    }

    // -----------------------------------------------------------------------
    // Helpers
    // -----------------------------------------------------------------------

    private static ResponseEventStream CreateTestStream()
    {
        var context = new ResponseContext("resp_test_123");
        return new ResponseEventStream(context, new CreateResponse { Model = "gpt-4o" });
    }
}
