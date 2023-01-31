using jsonParser.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace jsonParser.Functions
{
    public class parseJson
    {
        public List<clsOsosModel> parseJsonData(String data)
        {
            //JSON DOSYASINI OKUYOR
            var jsonFile = File.ReadAllText(data);

            //OKUDUĞUMUZ DOSYAYI PARSE EDİYOR
            JObject jobj = JObject.Parse(jsonFile);

            //PARSE EDİLEN DOSYADAN SAYAÇ DATALARININ OLDUĞU LİSTEYİ STRING FORMATINDA ÇEKİYOR
            var body = jobj["body"].ToString();

            //SAYAÇ KAYIT MODELİ
            clsOsosModel model = new clsOsosModel();

            //ELİMİZDEKİ VERİYİ SAYAÇ MODELİNE YERLEŞTİRİYORUZ
            var jsonModel = JsonConvert.DeserializeObject<List<clsOsosModel>>(body);
            return jsonModel;
        }
    }
}
