using SUM200_AndroidLab_Max_Jern.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SUM200_Lab2_Max_Jern
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //Sets binding context to our ViewModel.
            BindingContext = App.DogModel;
        }

        //Gets you pictures of dogs from the specified breed
        void OnClickDog(object sender, ItemTappedEventArgs e)
        {
            App.DogModel.GetDogByBreed(Editor.Text.ToLower());
        }
        //Dogs for the people!
        void OnClickRnd(object sender, ItemTappedEventArgs e)
        {
            App.DogModel.GetRandomDog();
        }
    }
}
