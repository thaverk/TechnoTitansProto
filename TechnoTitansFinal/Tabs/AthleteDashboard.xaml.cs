using TechnoTitansFinal.Models;
using TechnoTitansFinal.Services;

namespace TechnoTitansFinal.Tabs;

public partial class AthleteDashboard : ContentPage
{
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
	public LocalDb db;
	
	public AthleteDashboard()
	{
		InitializeComponent();
	}
}