using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using RussianCal.Properties;
using Newtonsoft.Json;

namespace RussianCal.JSON
{
    public class JSONEditor
    {
       
        
        public static void Serialize<T>(List<T> dataList)
        {
            try
            {
                if (dataList is List<Note>)
                {
                    File.WriteAllText("../../Notes.json", JsonConvert.SerializeObject(dataList));
                }
           
                else
                {
                    MessageBox.Show("Таким как " + dataList.GetType() + " здесь не рады. Ошибка сериализации");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Андрюха, у нас \n" + exception + "\n возможно криминал, по коням");
            }
           
  
        }

        public static T Deserialize<T>(string path)
        {
            T dataList =  JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
            return dataList;
        }
        
        
    }
}