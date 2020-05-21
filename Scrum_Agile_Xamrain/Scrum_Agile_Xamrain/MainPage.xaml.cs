using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Scrum_Agile_Xamrain
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            

            if (txtName.Text != null && txtPass.Text != null)
             {
                 Person person = new Person();

                 person.Name = txtName.Text;
                 person.Passwrd = txtPass.Text;


                 await App.SQLiteDb.SaveItemAsync(person);
                 txtName.Text = string.Empty;
                 txtPass.Text = string.Empty;
                 await DisplayAlert("Success", "Person added Successfully", "OK");
                 
             }
             else
             {
                 await DisplayAlert("Required", "Please Enter name!", "OK");
             }
            
        }

        private async void BtnRead_Clicked(object sender, EventArgs e)
        {

           
            
            if (txtName.Text != null && txtPass .Text != null)
               
            {

                var record = await App.SQLiteDb.LoginValidate(txtName.Text, txtPass.Text);
                 if (record != null)
                {
                    await Navigation.PushAsync(new After_Login(txtName.Text));

                }
                else
                {
                    await DisplayAlert("Login", "In Valid User ", "OK");
                }


               
            }
            else
            {
                await DisplayAlert("Required", "Please Enter Deatils", "OK");
            }
            
        }




    }
}
