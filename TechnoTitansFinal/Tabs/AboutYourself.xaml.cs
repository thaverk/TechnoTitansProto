using TechnoTitansFinal.Models;
using TechnoTitansFinal.Services;
namespace TechnoTitansFinal.Tabs;

public partial class AboutYourself : ContentPage
{
    public User _user;
    public LocalDb db;
    public User user
    {
        get { return _user; }
        set { _user = value;OnPropertyChanged(); }
    }


    public int IDuser = 0;


    public AboutYourself()
	{
		InitializeComponent();
        db = new LocalDb();
        OnPropertyChanged();
        BindingContext = this;
        Routing.RegisterRoute(nameof(AthleteSignUp), typeof(AthleteSignUp));
        Routing.RegisterRoute(nameof(CoachSignUp), typeof(CoachSignUp));
        Routing.RegisterRoute(nameof(ProviderSignUp), typeof(ProviderSignUp));
    }

    /*public User RegUserID()
    {
        if (Athlete_Clicked)
        {
            user = new User()
            {
                userType = 1,
                userID = 1
            };
            db.InsertClient(_user);
        }
        else if (Coach_Clicked)
        {
            user = new User()
            {
                userType = 2

            };
            db.InsertClient(_user);
        }
        else if (Provider_Clicked)
        {
            db.InsertClient(_user);
        }
    }*/




    private  void Athlete_Clicked(object sender, EventArgs e)
    {
        user = new User()
        {
            userType = 1,
            userID = 1
        };
        db.InsertClient(_user);
        Shell.Current.GoToAsync(nameof(AthleteSignUp));
    }

    private void Coach_Clicked(object sender, EventArgs e)
    {
        user = new User()
        {
            userType = 2

        };
        db.InsertClient(_user);
        Shell.Current.GoToAsync(nameof(CoachSignUp));
    }

    private void Provider_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ProviderSignUp));
    }
}	