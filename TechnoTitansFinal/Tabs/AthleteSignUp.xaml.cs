using TechnoTitansFinal.Models;
using TechnoTitansFinal.Services;

namespace TechnoTitansFinal.Tabs;

public partial class AthleteSignUp : ContentPage
{
	public LocalDb db;
	public AthleteSignUp()
	{
		InitializeComponent();
	}

	/*public void SignUp_Clicked(object sender, EventArgs e)
    {
        db = new LocalDb();
      User user = new User();
        user.userType = 1;
        user.userFirstName = FirstName.Text;
        user.userLastName = LastName.Text;
        user.userEmail = Email.Text;
        user.userPassword = Password.Text;
        user.userPhone = Phone.Text;
        user.userDOB = DOB.Date;
        db.InsertClient(user);
        Shell.Current.GoToAsync("//AthleteDashboard");
    }*/





}