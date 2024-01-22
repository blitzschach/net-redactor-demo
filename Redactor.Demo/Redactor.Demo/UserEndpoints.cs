using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Redactor.Demo.Models;
using Redactor.Demo.Models.Requests;

namespace Redactor.Demo;

internal static class UserEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapPost("/users", async (
                DemoDbContext context,
                [FromBody] CreateUserRequest request,
                ILogger<Program> logger) =>
            {
                var user = new User(
                    Guid.NewGuid(),
                    request.Firstname,
                    request.Lastname,
                    request.Email);
        
                await context.AddAsync(user);
                await context.SaveChangesAsync();
        
                logger.UserCreatedLog(user);
        
                return user;
            })
            .Produces<User>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);
        
        app.MapGet("/users", async (DemoDbContext context) =>
            {
                var users = await context.Users.ToListAsync();
                return users;
            })
            .Produces<List<User>>();
        
        app.MapGet("/users/{id:Guid}", async (
                DemoDbContext context,
                [FromRoute] Guid id) =>
            {
                var user = await context.Users.FindAsync(id);
        
                return
                    user is null
                        ? Results.NotFound()
                        : Results.Ok(user);
            })
            .Produces<User>()
            .Produces(StatusCodes.Status404NotFound);
        
        app.MapDelete("/users/{id:Guid}", async (
                DemoDbContext context,
                [FromRoute] Guid id,
                ILogger<Program> logger) =>
            {
                var user = await context.FindAsync<User>(id);
        
                if (user is null)
                {
                    return Results.NoContent();
                }
        
                context.Remove(user);
                await context.SaveChangesAsync();
        
                logger.UserDeletedLog(user);
        
                return Results.NoContent();
            })
            .Produces(StatusCodes.Status204NoContent);
    }
}