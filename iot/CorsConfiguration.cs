namespace iot.API
{
    public static class CorsConfiguration
    {

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, string policyName, string origins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: policyName,
                    policy =>
                    {
                        policy.WithOrigins(origins);
                        policy.AllowAnyHeader().AllowAnyMethod();
                    });
            });

            return services;
        }
    }
}
