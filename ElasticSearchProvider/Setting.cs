using System;
using Nest;

namespace ElasticSearchProvider
{
    public static  class Setting
    {
        public static Uri Node
        {
            get
            {
                return new Uri("http://localhost:9200");
            }
        }

        public static ConnectionSettings ConnectionSettings
        {
            get
            {
                return new ConnectionSettings(Node,defaultIndex: "elastic-search-app");
            }
        }

    }
}
