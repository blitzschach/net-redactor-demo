using Redactor.Demo.Models;

namespace Redactor.Demo;

internal static partial class Logging
{
    [LoggerMessage(LogLevel.Information, "User created")]
    public static partial void UserCreatedLog(
        this ILogger logger,
        [LogProperties] User user);
    
    [LoggerMessage(LogLevel.Information, "User deleted")]
    public static partial void UserDeletedLog(
        this ILogger logger,
        [LogProperties] User user);
}