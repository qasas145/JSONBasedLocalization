public static class RequestCultureMiddlewareExtension {
    public static IApplicationBuilder  UseRequestCulture(this IApplicationBuilder builder) {
        return builder.UseMiddleware<RequestultureMiddleware>();
    }
}