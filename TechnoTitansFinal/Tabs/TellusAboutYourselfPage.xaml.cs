using SQLite;
using TechnoTitansFinal.Models;
using TechnoTitansFinal.Services;

namespace TechnoTitansFinal.Tabs;

public partial class TellusAboutYourselfPage : ContentPage
{
	private LocalDb db;
    private User _user;
    public SQLiteConnection conn;
    public User user
    {
        get { return _user; }
        set { _user = value; }
    }   

    public TellusAboutYourselfPage()
	{
		db = new LocalDb();
        InitializeComponent();
       
    }

    private async void Athlete_Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute("AthleteSignUp", typeof(AthleteSignUp));
        user=new User()
        {
            userType = 1

        };
        db.InsertClient(_user);
        await Shell.Current.GoToAsync("AthleteSignUp");

    }

    private async void Coach_Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute("CoachSignUp", typeof(CoachSignUp));
        user = new User()
        {
            userType = 2

        };
        db.InsertClient(_user);
        await Shell.Current.GoToAsync("CoachSignUp");
    }
    private async void Provider_Clicked(object sender, EventArgs e)
    {
        Routing.RegisterRoute("ProviderSignUp", typeof(ProviderSignUp));
        await Shell.Current.GoToAsync("ProviderSignUp");
    }


}