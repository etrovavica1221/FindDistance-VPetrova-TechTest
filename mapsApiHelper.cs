using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Configuration;

namespace postcodesDistance
{
  class mapsApiHelper
  {
    public httpResponseModel CallApi(string firstPostcode, string secondPostcode)
    { 
        string apiKey = ConfigurationManager.AppSettings["ApiKey"];
        string url = $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={firstPostcode}&destinations={secondPostcode}&key={apiKey}";

        WebRequest request = HttpWebRequest.Create(url);  
        WebResponse response = request.GetResponse();  

        StreamReader reader = new StreamReader(response.GetResponseStream()); 
        string responseText = reader.ReadToEnd();
        
        var model = JsonConvert.DeserializeObject<httpResponseModel>(responseText);
        return model;
    }
  }

}
