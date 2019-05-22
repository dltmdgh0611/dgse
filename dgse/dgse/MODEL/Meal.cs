using dgse.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dgse.MODEL
{
    class Meal
    {

        public string json = null;
        public string[][] meal_arr = new string[3][];
        public string[] meal = new string[3]
        {
            "정보를 불러오는 중",
            "정보를 불러오는 중",
            "정보를 불러오는 중",
        };

        public void Parse_Meal(string[][] meal)
        {
            if (json != null)
            {
                JObject jo = JObject.Parse(json);
                meal_arr[0] = JsonConvert.DeserializeObject<List<string>>(jo["menu"]["breakfast"].ToString()).ToArray();
                meal_arr[1] = JsonConvert.DeserializeObject<List<string>>(jo["menu"]["lunch"].ToString()).ToArray();
                meal_arr[2] = JsonConvert.DeserializeObject<List<string>>(jo["menu"]["dinner"].ToString()).ToArray();
            }

        }


        public string Get_Meal_Json()
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;

            return (json = client.DownloadString("https://schoolmenukr.ml/api/high/D100000282/?hideAllergy=true&year=2019&month=3&date=27"));
        }

        public string Meal_Get(int i)
        {

            return meal[i];
        }

    }
}
