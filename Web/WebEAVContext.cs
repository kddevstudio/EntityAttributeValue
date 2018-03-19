using System.Data.Entity;
using Models;

namespace Web
{
    public class WebEAVContext : EAVContext
    {
        public WebEAVContext(): base("name=WebEAVContext") {
            
            // override default initializer
            
            //Database.SetInitializer<WebEAVContext>(new DropCreateDatabaseAlways<WebEAVContext>());
            Database.SetInitializer<WebEAVContext>(new DropCreateDatabaseIfModelChanges<WebEAVContext>());
        }
    }
}
