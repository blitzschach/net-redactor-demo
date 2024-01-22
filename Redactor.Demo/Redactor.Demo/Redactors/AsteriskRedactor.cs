namespace Redactor.Demo.Redactors;

internal class AsteriskRedactor : Microsoft.Extensions.Compliance.Redaction.Redactor
{
    public override int Redact(ReadOnlySpan<char> source, Span<char> destination)
    {
        destination.Fill('*');
        return destination.Length;
    }

    public override int GetRedactedLength(ReadOnlySpan<char> input)
        => input.Length;
}