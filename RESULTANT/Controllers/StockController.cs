using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Mvc;
using Resultant.Models;
using Newtonsoft.Json;

namespace Resultant.Controllers
{
    public class StockController: Controller
    {
        private string _address = "http://phisix-api3.appspot.com/stocks.json"; //Адрес сервера с данными
        
        
        public JsonResult GetStocks()
        {
            
            try
            {
                string textFromFile;
                var request = (HttpWebRequest)WebRequest.Create(_address);
                var response = (HttpWebResponse)request.GetResponse(); //составляем запрос и получаем ответ от сервера

                using (var stream = response.GetResponseStream())
                {
                    var reader = new StreamReader(stream ?? throw new InvalidOperationException(), Encoding.UTF8);
                    textFromFile = reader.ReadToEnd(); //Записываем JSON Ответ в строку
                }
                
                return Json(JsonConvert.DeserializeObject<StockJson>(textFromFile).Stock, JsonRequestBehavior.AllowGet);//Берём из JSON ответа только данные без заголовка и возвращаем их
            }
            catch (WebException e)
            {
                return Json(e.Message);
            }
            

            
        }

       
    }
}