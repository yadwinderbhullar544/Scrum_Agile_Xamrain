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
    public partial class Create_Story : ContentPage
    {
        public Create_Story(string username)
        {
            InitializeComponent();
            lbl_username.Text = username;
           
            


        }


        private async void btnAdd_Clicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtName.Text))
            {
                Story var_story = new Story()
                {
                   // Name = txtName.Text,
                  // Description= txtDescription.Text
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    ProjectName = myPicker.SelectedItem.ToString(),
                    PersonName = lbl_username.Text

                };

                if (txtName.Text != null)

                {

                   
                    //Add New Story
                    await App.SQLiteDb.Save_Story_ItemAsync(var_story);
                    txtName.Text = string.Empty;
                    txtDescription.Text = string.Empty;
                    txtStoryId.Text = string.Empty;

                   




                    await DisplayAlert("Success", "Story added Successfully", "OK");

                }
                else
                {
                    await DisplayAlert("Required", "Please Enter Deatils", "OK");
                }






                var story_Name_List = await App.SQLiteDb.GetItem_Story_Name(myPicker.SelectedItem.ToString());
                if (story_Name_List != null)
                {
                    lstStory.ItemsSource = story_Name_List;
                }

                //Get All Project
                // var storyList = await App.SQLiteDb.GetItem_All_Story();
                //if (storyList != null)
                //{
                //  lstStory.ItemsSource = storyList;
                //}
            }
            else
            {
                await DisplayAlert("Required", "Please Enter name!", "OK");
            }

        }

       

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStoryId.Text))
            {
                Story var_story = new Story()
                {
                    StoryID = Convert.ToInt32(txtStoryId.Text),
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    ProjectName = myPicker.SelectedItem.ToString(),
                    PersonName = lbl_username.Text
                };
            
            //Update Project
            await App.SQLiteDb.Save_Story_ItemAsync(var_story);


                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtStoryId.Text = string.Empty;
                await DisplayAlert("Success", "Story Updated Successfully", "OK");
            //Get All Persons
            var storyList = await App.SQLiteDb.GetItem_All_Story();
            if (storyList != null)
            {
                lstStory.ItemsSource = storyList;
            }


            else
            {
                await DisplayAlert("Required", "Please Enter ProjectID", "OK");
            }
        }
    
    }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(txtStoryId.Text))
            {
                Story var_story = new Story()
                {
                    StoryID = Convert.ToInt32(txtStoryId.Text),
                   
                };

                //Update Project
                await App.SQLiteDb.Delete_stroy_ItemAsync(var_story);


              
                await DisplayAlert("Success", "Deleted Successfully", "OK");
                //Get All Persons
                var storyList = await App.SQLiteDb.GetItem_All_Story();
                if (storyList != null)
                {
                    lstStory.ItemsSource = storyList;
                }


                else
                {
                    await DisplayAlert("Required", "Please Enter StoryID", "OK");
                }
            }


        }

        private async void btnShow_Clicked(object sender, EventArgs e)
        {
            btnAdd.IsVisible = true;
            btnDelete.IsVisible = true;
            btnUpdate.IsVisible = true;
            var projectList = await App.SQLiteDb.Get_All_ProjectItemsAsync();
            if (projectList != null)
            {
                myPicker.ItemsSource = projectList;
            }
        }
    }

    
    }
