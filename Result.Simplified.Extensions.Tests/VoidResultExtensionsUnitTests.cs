namespace Result.Simplified.Extensions.Tests;

public class VoidResultExtensionsUnitTests
{
    private const string FirstErrorDescription = "First error description";
    private const string SecondErrorDescription = "Second error description";

    // ThenIf
    [Test]
    public void ThenIf_SuccessfulResultAndSuccessCondition_ReturnsSuccessfulResult()
    {
        var first = VoidResult.Success();
        var second = first.ThenIf(() => 1 == 1, SecondErrorDescription);
        Assert.Multiple(() =>
        {
            Assert.That(second.IsSuccess, Is.True);
            Assert.That(second.ErrorDescription, Is.Null);
        });
    }

    [Test]
    public void ThenIf_SuccessfulResultAndFailCondition_ReturnsFailedResult()
    {
        
        var first = VoidResult.Success();
        var second = first.ThenIf(() => 1 == 2, SecondErrorDescription);
        Assert.Multiple(() =>
        {
            Assert.That(second.IsSuccess, Is.False);
            Assert.That(second.ErrorDescription, Is.EqualTo(SecondErrorDescription));
        });
    }

    [Test]
    public void ThenIf_FailedResultAndSuccessCondition_ReturnsFailedResult()
    {
        var first = VoidResult.Fail(FirstErrorDescription);
        var second = first.ThenIf(() => 1 == 1, SecondErrorDescription);
        Assert.Multiple(() =>
        {
            Assert.That(second.IsSuccess, Is.False);
            Assert.That(second.ErrorDescription, Is.EqualTo(FirstErrorDescription));
        });
    }

    [Test]
    public void ThenIf_FailedResultAndFailCondition_ReturnsFFailedResult()
    {
        var first = VoidResult.Fail(FirstErrorDescription);
        var second = first.ThenIf(() => 1 == 2, SecondErrorDescription);
        Assert.Multiple(() =>
        {
            Assert.That(second.IsSuccess, Is.False);
            Assert.That(second.ErrorDescription, Is.EqualTo(FirstErrorDescription));
        });
    }


    // TODO: Add similar tests for the following methods:
    // ThenFailIf
    // OtherwiseIf
    // OtherwiseFailIf
}