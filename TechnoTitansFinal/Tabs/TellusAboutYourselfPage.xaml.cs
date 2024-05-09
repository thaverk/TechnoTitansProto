using SQLite;
using TechnoTitansFinal.Models;
using TechnoTitansFinal.Services;

namespace TechnoTitansFinal.Tabs;

public partial class TellusAboutYourselfPage : ContentPage
{
	public LocalDb db;
    public User _user;
    public SQLiteConnection conn;
    public User user
    {
        get { return _user; }
        set { _user = value; }
    }   

    public TellusAboutYourselfPage()
	{
        InitializeComponent();
        db = new LocalDb();

        db.GetUserById(1);
        db.GetSportById(1);
        db.GetTreatmentById(1);

        Routing.RegisterRoute("AthleteSignUp", typeof(AthleteSignUp));
        Routing.RegisterRoute("CoachSignUp", typeof(CoachSignUp));
        Routing.RegisterRoute("ProviderSignUp", typeof(ProviderSignUp));
       
    }

    private async void Athlete_Clicked(object sender, EventArgs e)
    {
        
        user=new User()
        {
            userType = 1

        };
        db.InsertClient(_user);
       
        await Navigation.PushAsync(new AthleteSignUp());

    }

    private async void Coach_Clicked(object sender, EventArgs e)
    {
       
        user = new User()
        {
            userType = 2

        }; 
        db.InsertClient(_user);
        await Shell.Current.GoToAsync("CoachSignUp",true);
        await Navigation.PushAsync(new CoachSignUp());
    }
    private async void Provider_Clicked(object sender, EventArgs e)
    {
        
        await Shell.Current.GoToAsync("ProviderSignUp");
    }


}