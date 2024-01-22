using Redactor.Demo.Attributes;

namespace Redactor.Demo.Models;

internal sealed record User(
    Guid Id,
    string Firstname,
    string Lastname,
    [SensitiveData] string Email);