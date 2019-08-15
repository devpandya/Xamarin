using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.BusinessLogic;
using XamarinApp.Models;

namespace XamarinApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Students : ContentPage
    {
        public Students()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            StudentsDTO students = new StudentsDTO();
            students = await new StudentBusiness().Get_Students_Async();
            if (students.ErrorCode == "OK")
            {
                studentList.ItemsSource = students.Students;
            }
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage(0));
        }

        private void StudentList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectdItem = (Student)e.SelectedItem;
            if (selectdItem.StudentId > 0)
            {
                Navigation.PushAsync(new MainPage(selectdItem.StudentId));
            }
        }
    }
}