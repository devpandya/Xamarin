using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using XamarinApp.BusinessLogic;
using XamarinApp.Models;

namespace XamarinApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public int? _studentId = 0;
        public MainPage(int? studentId)
        {
            _studentId = studentId;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Student student = new Student { StudentId = _studentId, ErrorCode = "OK"};
            if (_studentId > 0)
            {
                await new StudentBusiness().Get_Student_Async(student);
            }
            if (student.ErrorCode == "OK")
            {
                txtName.Text = student.Name;
                txtSchool.Text = student.SchoolName;
                txtGuardianName.Text = student.GaurdianName;
                txtAge.Text = Convert.ToString(student.Age);
                txtClass.Text = Convert.ToString(student.Class);
                txtFees.Text =  Convert.ToString(student.TotalFees);
                txtBalance.Text = Convert.ToString(student.FeesBalance);
            }

        }
        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            string ErrorCode = "OK";
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ErrorCode = "Please Enter a Name";
                
            }
            else if (!txtName.Text.All(Char.IsLetter))
            {
                ErrorCode = "Please Enter a  Valid Name";
                
            }
            else if (string.IsNullOrWhiteSpace(txtGuardianName.Text))
            {
                ErrorCode = "Please Enter Guardian Name";
                
            }
            else if (!txtGuardianName.Text.All(Char.IsLetter))
            {
                ErrorCode = "Please Enter a Valid Guardian Name";
                
            }
            else if (string.IsNullOrWhiteSpace(txtAge.Text))
            {
                ErrorCode = "Please Enter valid Age";
                
            }
            else if (!txtAge.Text.All(Char.IsNumber) ||  Convert.ToInt32(txtAge.Text) < 1)
            {
                ErrorCode = "Please Enter a Valid Age";
                
            }
            else if (txtClass.Text == null)
            {
                ErrorCode = "Please Enter valid Class";
                
            }
            else if (string.IsNullOrWhiteSpace(txtFees.Text))
            {
                ErrorCode = "Please Enter valid Age";

            }
            else if (txtFees.Text.All(Char.IsLetter) || Convert.ToInt32(txtFees.Text) < 0)
            {
                ErrorCode = "Please Enter a Valid Fees";

            }
            else if (string.IsNullOrWhiteSpace(txtBalance.Text))
            {
                ErrorCode = "Please Enter valid Age";

            }
            else if (txtBalance.Text.All(Char.IsLetter) || Convert.ToInt32(txtBalance.Text) < 0)
            {
                ErrorCode = "Please Enter a Valid Fees";

            }
            if (ErrorCode == "OK")
            {
                Student student = new Student
                {
                    StudentId = _studentId,
                    Name = txtName.Text,
                    Age = Convert.ToInt32(txtAge.Text),
                    SchoolName = txtSchool.Text,
                    GaurdianName = txtGuardianName.Text,
                    Class = txtClass.Text,
                    TotalFees = Convert.ToDouble(txtFees.Text),
                    FeesBalance = Convert.ToDouble(txtBalance.Text),
                };
                await new StudentBusiness().Save_Student_Async(student);
                if (student.ErrorCode == "OK")
                {
                   await  Navigation.PopAsync();
                }
            }
            else
            {
                await DisplayAlert("Error", ErrorCode, "Cancel");
            }
        }
    }
}
