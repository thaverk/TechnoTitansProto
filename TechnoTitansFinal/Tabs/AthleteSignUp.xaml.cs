using TechnoTitansFinal.Models;
using TechnoTitansFinal.Services;

namespace TechnoTitansFinal.Tabs;

public partial class AthleteSignUp : ContentPage
{
	public LocalDb db;
    public User _user;
    public User user
    {
        get { return _user; }
        set
        {
            _user = value;
            OnPropertyChanged();
        }
    }
	public AthleteSignUp()
	{
        db = new LocalDb();
        InitializeComponent();
        
    }

	public void SignUp_Clicked(object sender, EventArgs e)
    {
        db.UpdateClient(user);
        Shell.Current.GoToAsync("//AthleteDashboard");
    }





}