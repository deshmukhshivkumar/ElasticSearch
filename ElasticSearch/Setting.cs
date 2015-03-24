using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Nest;

namespace ElasticSearch
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
