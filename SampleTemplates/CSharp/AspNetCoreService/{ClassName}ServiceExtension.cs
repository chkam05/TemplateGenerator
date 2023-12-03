namespace {Namespace}
{
    public static class {ClassName}ServiceExtension
    {

        //  METHODS

        #region REGISTRATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Register and configure {ClassName} service.  </summary>
        /// <param name="services"> ServiceCollection interface that contains collection of services available in application. </param>
        /// <param name="configuration"> Application configuration. </param>
        /// <returns> ServiceCollection interface that contains collection of services available in application. </param>
        public static IServiceCollection RegisterNetworkService(this IServiceCollection services, IConfiguration configuration)
        {
            //  Register {ClassName} service configuration.
            services.RegisterConfiguration(configuration);

            //  Register {ClassName} service.
            services.AddTransient<I{ClassName}Service, {ClassName}Service>();

            return services;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Register {ClassName} service configuration. </summary>
        /// <param name="services"> ServiceCollection interface that contains collection of services available in application. </param>
        /// <param name="configuration"> Application configuration. </param>
        /// <returns> ServiceCollection interface that contains collection of services available in application. </param>
        private static IServiceCollection RegisterConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //  Initialize configuration.
            var config = new {ClassName}ServiceConfig()
            {
                //
            };

            //  Register {ClassName} service configuration.
            services.AddSingleton(config);

            return services;
        }

        #endregion REGISTRATION METHODS

    }
}
