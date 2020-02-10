using Newtonsoft.Json;
using SUM200_AndroidLab_Max_Jern.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;


namespace SUM200_AndroidLab_Max_Jern.ViewModel
{
    public class DogViewModel
    {
        private ObservableCollection<Dog> _dog = new ObservableCollection<Dog>();

        public ObservableCollection<Dog> Dog
        {
            get
            {
                return this._dog;
            }
        }
        //Randomized dog pictures. I just think it's kinda funny, I had to include it.
        //Displays random dog pictures
        public async void GetRandomDog()
        {
            try
            {
                //Dog api
                string URL = "https://dog.ceo/api/breeds/image/random";

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(URL));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var answer = JsonConvert.DeserializeObject<Dog>(content);

                    this.Dog.Insert(0, new Dog() { message = answer.message, status = answer.status });
                    //I feel like this might be cheating?
                    //But I had no idea how to bind the viewmodel to the view unless connected to a list.
                    //Instead of just displaying my one object, I fill the list whilst simultaneously removing the previous entry.
                    Dog.RemoveAt(1);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
        //Fetches dog pictures based on the breed inserted into the editor
        public async void GetDogByBreed(string breed)
        {
            try
            {
                //Dog api for specific breed
                string URL = "https://dog.ceo/api/breed/" + breed + "/images/random";

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(URL));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var answer = JsonConvert.DeserializeObject<Dog>(content);

                    this.Dog.Insert(0, new Dog() { message = answer.message, status = answer.status });
                    Dog.RemoveAt(1);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
        /* Data used for testing
        public void TestDog()
        {
            LoadTestData();
        }
        //Hardcoded pupper
        private void LoadTestData()
        {
            this.Dog.Add(new Dog() { message = "https://images.dog.ceo/breeds/terrier-sealyham/n02095889_6485.jpg", status = "test" });
        }
        */
    }
}
