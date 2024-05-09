using TechnoTitansFinal.Models;
using TechnoTitansFinal.Services;

namespace TechnoTitansFinal.Tabs;

public partial class AthleteDashboard : ContentPage
{
	public LocalDb db;
    public User user;
	public User User
	{
        get { return user; }
        set
		{
            user = value;
            OnPropertyChanged();
        }
    }
	
	
	public AthleteDashboard()
	{
		db.GetUserByemail(user.userEmail);
        InitializeComponent();
        BindingContext = this;
        OnPropertyChanged();
    }
    
}
