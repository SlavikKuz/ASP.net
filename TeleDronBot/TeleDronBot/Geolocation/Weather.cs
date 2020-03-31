﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TeleDronBot.Geolocation
{
    class Weather
    {
        public async static ValueTask<string> GetWeather(float longtitude, float lautitude)
        {
            string url = Commons.Constant.WeatherURL + $"lat={lautitude}&lon={longtitude}" + Commons.Constant.WeatherAPIKEY;
            WebRequest request = WebRequest.Create($"http://api.openweathermap.org/data/2.5/weather?q=Lviv,ua{Commons.Constant.WheatherAPIKey}&units=metric");
            WebResponse response = await request.GetResponseAsync();
            
            string result = ""; using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = await reader.ReadToEndAsync();
                }
            }
            return result;
        }
    }
}
