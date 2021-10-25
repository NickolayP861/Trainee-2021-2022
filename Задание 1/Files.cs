using System;
using System.Text.Json;
using System.IO;

namespace JSON_to_html
{
    class Files
    {
        // Процедура создает html файл в папке решения.
        public static void WriteFile(Rootobject rotoobject)
        {
            try
            {
                StreamWriter sw = new StreamWriter("Test.html");
                
                sw.WriteLine("<!DOCTYPE HTML>");
                sw.WriteLine("<html>");
                sw.WriteLine("\t<head>");
                sw.WriteLine("\t\t<meta http-equiv = \'Content - Type\' content = \'text/html\'; charset = utf - 8>");
                sw.WriteLine("\t\t<title>Парсинг json файла</title>");
                sw.WriteLine("\t</head>");
                sw.WriteLine("\t<body>");
                sw.WriteLine("\t<h1>" + rotoobject.form.name + "</h1>");

                foreach (Item item in rotoobject.form.items)
                {
                    sw.Write("\t\t<p>");
                    sw.Write("<input type = \'" + item.type + "\'");
                    WriteAttritubes(sw, item);
                    sw.Write(">");
                    sw.WriteLine("</p>");
                }

                sw.WriteLine("\t</body>");
                sw.WriteLine("</html>");

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + rotoobject.form.postmessage);
            }
        }

        // Процедура записывает строку атрибутов из переданного элемента.
        static void WriteAttritubes(StreamWriter sw, dynamic item)
        {
            string[] result = new string[9];

            if (Convert.ToString(item.attributes.message) != "")
                result[0] = " message = \'" + Convert.ToString(item.attributes.message) + "\'";

            if (Convert.ToString(item.attributes.name) != "")
                result[1] = " name = \'" + Convert.ToString(item.attributes.name) + "\'";

            if (Convert.ToString(item.attributes.placeholder) != "")
                result[2] = " placeholder = \'" + Convert.ToString(item.attributes.placeholder) + "\'";

            if (Convert.ToString(item.attributes.required) != "")
                result[3] = " required = \'" + Convert.ToString(item.attributes.required) + "\'";

            if (Convert.ToString(item.attributes.value) != "")
                result[4] = " value = \'" + Convert.ToString(item.attributes.value) + "\'";

            if (Convert.ToString(item.attributes.label) != "")
                result[5] = " label = \'" + Convert.ToString(item.attributes.label) + "\'";

            if (Convert.ToString(item.attributes._class) != "")
                result[6] = " class = \'" + Convert.ToString(item.attributes._class) + "\'";

            //if ((item.attributes.validationRules == null) == false)
            //result[0] = item.attributes.validationRules;

            if (Convert.ToString(item.attributes.disabled) != "")
                result[7] = " message = \'" + Convert.ToString(item.attributes.disabled) + "\'";

            foreach (string attribute in result)
                sw.Write(attribute);
        }

        // Функция возвращает json файл в виде объекта Rootobject.
        public static Rootobject GetJsonFile()
        {
            string jsonString = File.ReadAllText("Form.json");
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
            };

            return JsonSerializer.Deserialize<Rootobject>(jsonString, options);
        }
    }
}
