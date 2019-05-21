using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace dgse.MODEL
{
    class Meal
    {

        public String breakfast;
        String lunch;
        String dinner;

        string newline = "\n";

        public void Get_Meal_Date(DateTime date)
        {
            WebClient client = new WebClient(); // 웹 URL을 통해 String 데이터로 반환 
            client.Encoding = Encoding.UTF8;
            string jsonStr = client.DownloadString("https://schoolmenukr.ml/api/high/D100000282/?hideAllergy=true&year=2019&month=3&date=27");

            JObject jo = JObject.Parse(jsonStr);
            string[][] meal = new string[3][];
            meal[0] = JsonConvert.DeserializeObject<List<string>>(jo["menu"]["breakfast"].ToString()).ToArray();
            meal[1] = JsonConvert.DeserializeObject<List<string>>(jo["menu"]["lunch"].ToString()).ToArray();
            meal[2] = JsonConvert.DeserializeObject<List<string>>(jo["menu"]["dinner"].ToString()).ToArray();

            for (int i = 0; i < meal[0].Length; i++)
            {
                breakfast += meal[0][i] + newline;
            }
            for (int i = 0; i < meal[1].Length; i++)
            {
                lunch += meal[1][i] + newline;
            }
            for (int i = 0; i < meal[2].Length; i++)
            {
                dinner += meal[2][i] + newline;
            }

        }

    }
}
