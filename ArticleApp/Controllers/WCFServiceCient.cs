using System.Net;

namespace ArticleApp.Controllers
{
    internal class WCFServiceCient
    {
        public ClientCredentials ClientCredentials { get; internal set; }
    }

    internal class ClientCredentials
    {
        public User User { get; internal set; }
        public Windows Windows { get; internal set; }
    }

    internal class Windows
    {
        public NetworkCredential ClientCredential { get; internal set; }
    }
}