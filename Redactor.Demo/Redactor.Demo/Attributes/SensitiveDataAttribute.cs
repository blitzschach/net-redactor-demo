using Microsoft.Extensions.Compliance.Classification;

namespace Redactor.Demo.Attributes;

internal class SensitiveDataAttribute()
    : DataClassificationAttribute(DataTaxonomy.SensitiveData);