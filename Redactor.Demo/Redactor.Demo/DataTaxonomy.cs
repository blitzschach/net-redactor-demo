using Microsoft.Extensions.Compliance.Classification;

namespace Redactor.Demo;

internal static class DataTaxonomy
{
    private static string Name { get; } = typeof(DataTaxonomy).FullName!;

    public static DataClassification SensitiveData = new(Name, nameof(SensitiveData));
}