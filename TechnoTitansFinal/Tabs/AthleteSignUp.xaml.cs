using TechnoTitansFinal.Models;
using TechnoTitansFinal.Services;

namespace TechnoTitansFinal.Tabs;

public partial class AthleteSignUp : ContentPage
{
	 public User user;
    public LocalDb db;
    public User User
    {
        get { return user; }
        set { user = value;OnPropertyChanged(); }
    }
    public AthleteSignUp()
	{
        Routing.RegisterRoute(nameof(AthleteDashboard), typeof(AthleteDashboard));
        db = new LocalDb();
        InitializeComponent();
        BindingContext = this;
        OnPropertyChanged();
        
    }

	public async void SignUp_Clicked(object sender, EventArgs e)
    {

        user = new User();
        user.userName = AthleteName.Text;
        user.userSurname = AthleteSurname.Text;
        user.userGender = AthleteGender.Text;
        user.userEmail = AthleteEmail.Text;
        user.userPassword = AthletePassword.Text;
        user.userID = 1;

        db.UpdateClient(user);

    }

    public async void NextPage_clicked(object sender, EventArgs e)
    {
          await Shell.Current.GoToAsync(nameof(AthleteDashboard));
    }



}