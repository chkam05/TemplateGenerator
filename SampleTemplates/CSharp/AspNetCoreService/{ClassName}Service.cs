namespace {Namespace}
{
    public class {ClassName}Service : I{ClassName}Service
    {
        
        //  VARIABLES
		
		private readonly {ClassName}ServiceConfig _config;
		private readonly ILogger _logger;
		
		
		//  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> {ClassName}Service class constructor. </summary>
        /// <param name="config"> {ClassName} service config. </param>
        /// <param name="logger"> Application logger. </param>
        public {ClassName}Service({ClassName}ServiceConfig config, ILogger<{ClassName}Service> logger)
        {
            _config = config;
			_logger = logger;
        }

        #endregion CLASS METHODS
		
    }
}
