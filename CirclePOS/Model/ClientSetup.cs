using System;
using System.Collections.Generic;
using System.Text;

namespace CirclePOS.Model
{
    class ClientSetup
    {
        public bool playInterfaceSounds = true;
        public int controlScreenNumber = 0;
        public int customerScreenNumber = 1;

        public string oneMomentText = "We'll be with you in a moment...";
        public string purchaseText = "Transaction";
        public string forSaleText = "Available";
        public string thankYou = "Thank you!";

        public static ClientSetup loadFromFile()
        {

            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CirclePOS");
            string filePath = System.IO.Path.Combine(path, "ClientSetup.json");

            if (System.IO.File.Exists(filePath))
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ClientSetup>(System.IO.File.ReadAllText(filePath));
            else
                return new ClientSetup();
        }
        public void saveToFile()
        {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CirclePOS");
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            string filePath = System.IO.Path.Combine(path, "ClientSetup.json");
            System.IO.File.WriteAllText(filePath, Newtonsoft.Json.JsonConvert.SerializeObject(this));
        }
    }
}
