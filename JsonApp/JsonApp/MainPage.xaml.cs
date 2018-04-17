using System;
using System.Collections.Generic;
using System.Linq;
using JsonApp.Helpers;
using JsonApp.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace JsonApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

	    public async void SaveButton(object sender, EventArgs args)
	    {
	        var json = "[{\r\n\t\t\"Id\": \"1\",\r\n\t\t\"Nome\": \"John\",\r\n\t\t\"Sobrenome\": \"Cena\"\r\n\t},\r\n\t{\r\n\t\t\"Id\": \"2\",\r\n\t\t\"Nome\": \"Steve\",\r\n\t\t\"Sobrenome\": \"Jobs\"\r\n\t}\r\n]";
            
            await Storage.WriteTextAllAsync("jsonText", json);
	    }

	    public async void RecoverButton(object sender, EventArgs args)
	    {
	        var Json = await Storage.ReadAllTextAsync("jsonText");
            var newJson = JsonConvert.DeserializeObject<List<Perfil>>(Json);
            newJson.Where(perfil => perfil.Id == "2");
	    }
    }
}
