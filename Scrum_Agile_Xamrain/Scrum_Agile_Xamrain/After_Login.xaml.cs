using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Scrum_Agile_Xamrain
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class After_Login : ContentPage
    {

       

       



        public After_Login(string username)
        {
            InitializeComponent();
            lbl_name.Text = username;
           
        }

        private async void btn_NewProject_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Create_Project());
        }

        private async void btn_NewStory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Create_Story(lbl_name.Text));
        }
    }
}