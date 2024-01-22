namespace Redactor.Demo.Models.Requests;

internal sealed record CreateUserRequest(
    string Firstname,
    string Lastname,
    string Email);