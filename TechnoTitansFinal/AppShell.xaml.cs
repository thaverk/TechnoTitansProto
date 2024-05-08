
using TechnoTitansFinal.Models;
using TechnoTitansFinal.Services;
using TechnoTitansFinal.Tabs;

namespace TechnoTitansFinal
{
    
    public partial class AppShell : Shell
    {
        public LocalDb db;
        public User user;


        public AppShell()
        {
            InitializeComponent();
            Shelltab();
        }

        

        public void Shelltab() 
        {
           
            
            
            if (user.userType == 1)
            {

                Routing.RegisterRoute("Tab1", typeof(ProviderList));
                Routing.RegisterRoute("Tab2", typeof(BodyPartSelect));
                Routing.RegisterRoute("Dashboard", typeof(AthleteDashboard));
            }

            else if (user.userType == 2)
            {
                Routing.RegisterRoute("Tab1", typeof(ProviderList));
                Routing.RegisterRoute("Tab2", typeof(TACPage));
                Routing.RegisterRoute("Dashboard", typeof(CoachDashboard));
            }
            else
            {
                Routing.RegisterRoute("Tab1", typeof(ProviderList));
                Routing.RegisterRoute("Tab2", typeof(PrivacyPolicy));
                Routing.RegisterRoute("Dashboard", typeof(ProviderDashboard));

            }
            
        }
    
        
    
    
    }


    


}
