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
    public partial class Create_Project : ContentPage
    {
        public Create_Project()
        {
            InitializeComponent();
            
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
               Project project = new Project()
                {
                    Name = txtName.Text,
                  

                };

                if (txtName.Text != null)

                {

                    //var record = await App.SQLiteDb.GetItem_Story_Name(txtName.Text);
                    // if (record != null)
                    // {
                    //Add New Story
                    await App.SQLiteDb.Save_Project_ItemAsync(project);
                    txtName.Text = string.Empty;
                  
                    await DisplayAlert("Success", "Story added Successfully", "OK");

                    //  }
                    //  else
                    // {
                    //    await DisplayAlert("Check", "Already Exists ", "OK");
                    // }



                }
                else
                {
                    await DisplayAlert("Required", "Please Enter Deatils", "OK");
                }
                               
                //Get All Project
                var projectList = await App.SQLiteDb.Get_All_ProjectItemsAsync();
                if (projectList != null)
                {
                    lstProject.ItemsSource = projectList;
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter name!", "OK");
            }


        }

        

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtProjectId.Text))
            {
                Project project = new Project()
                {
                   // ProjectID = Convert.ToInt32(txtProjectId.Text),
                    Name = txtName.Text
                };

                //Update Project
                await App.SQLiteDb.Save_Project_ItemAsync(project);

                txtProjectId.Text = string.Empty;
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Project Updated Successfully", "OK");
                //Get All Persons
                var projectList = await App.SQLiteDb.Get_All_ProjectItemsAsync();
                if (projectList != null)
                {
                    lstProject.ItemsSource = projectList;
                }

            }
            else
            {
                await DisplayAlert("Required", "Please Enter ProjectID", "OK");
            }


        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnShow_Clicked(object sender, EventArgs e)
        {
            var projectList = await App.SQLiteDb.Get_All_ProjectItemsAsync();
            if (projectList != null)
            {
                lstProject.ItemsSource = projectList;
            }

        }
    }
}