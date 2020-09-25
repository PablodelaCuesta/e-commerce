using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProductUrlResolver
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(string url)
        {
            if(!string.IsNullOrEmpty(url))
            {
                return _config["ApiUrl"] + url;
            }

            return null;
        }
    }
}