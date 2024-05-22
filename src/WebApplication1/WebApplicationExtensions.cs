public static class WebApplicationExtensions
{
    public static WebApplication MapOpenApiEndpoints(this WebApplication webApplication)
    {
        webApplication.MapPost("/pet/{petId}/uploadImage",
            (int petId, string additionalMetadata, byte[] file) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapPost("/pet",
            (object body) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapPut("/pet",
            (object body) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapGet("/pet/findByStatus",
            (Array status) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapGet("/pet/findByTags",
            (Array tags) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapGet("/pet/{petId}",
            (int petId) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapPost("/pet/{petId}",
            (int petId, string name, string status) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapDelete("/pet/{petId}",
            (string api_key, int petId) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapGet("/store/inventory",
            () =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapPost("/store/order",
            (object body) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapGet("/store/order/{orderId}",
            (int orderId) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapDelete("/store/order/{orderId}",
            (int orderId) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapPost("/user/createWithList",
            (Array body) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapGet("/user/{username}",
            (string username) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapPut("/user/{username}",
            (string username, object body) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapDelete("/user/{username}",
            (string username) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapGet("/user/login",
            (string username, string password) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapGet("/user/logout",
            () =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapPost("/user/createWithArray",
            (Array body) =>
            {
                return Task.FromResult(Results.Ok());
            });

        webApplication.MapPost("/user",
            (object body) =>
            {
                return Task.FromResult(Results.Ok());
            });

        return webApplication;
    }
}
