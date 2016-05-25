using System;
using System.Collections.Generic;
using System.Text;

namespace CirclePOS.Model
{
    class Database
    {
        public Decimal lastSaleChange = 0.0m;
        public Database()
        {

            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CirclePOS");
            path = System.IO.Path.Combine(path, "Sales.json");

            if(System.IO.File.Exists(path))
                allSales = Newtonsoft.Json.JsonConvert.DeserializeObject<Sale[]>(System.IO.File.ReadAllText(path));
        }
        public void removeSale(Sale s)
        {

            List<Sale> sales = new List<Sale>(allSales);
            if (sales.Contains(s))
                sales.Remove(s);
            allSales = sales.ToArray();

        }
        public string[] getAllGroups()
        {
            List<string> output = new List<string>();
            foreach (Product p in allProducts)
                if (!output.Contains(p.group))
                    output.Add(p.group);
            return output.ToArray();
        }
        public Sale[] salesContainingProductSince(Guid productID, DateTime date)
        {
            List<Sale> sales = new List<Sale>();
            int output = 0;
            foreach (Sale s in allSales)
                if (s.timeCompleted.Ticks >= date.Ticks)
                    if (s.containsProductID(productID))
                        sales.Add(s);

            return sales.ToArray();


        }
        public int itemsGiftedSince(DateTime date)
        {
            int output = 0;
            foreach (Sale s in allSales)
                if (s.timeCompleted.Ticks >= date.Ticks && s.madeFree)
                    output += s.productNames.Length;
            return output;

        }
        public int itemsSoldSince(DateTime date)
        {
            int output = 0;
            foreach (Sale s in allSales)
                if(s.timeCompleted.Ticks >= date.Ticks && !s.madeFree)
                    output += s.productNames.Length;
            return output;

        }
        public Decimal grossGiftedSince(DateTime date)
        {
            Decimal output = 0;
            foreach (Sale s in allSales)
                if (s.timeCompleted.Ticks >= date.Ticks && s.madeFree)
                    foreach (Decimal d in s.productCosts)
                        output += d;
            return output;
        }
        public Decimal grossSalesSince(DateTime date)
        {
            Decimal output = 0;
            foreach (Sale s in allSales)
                if (s.timeCompleted.Ticks >= date.Ticks && !s.madeFree)
                    foreach (Decimal d in s.productCosts)
                        output += d;
            return output;
        }
        public Sale[] salesSince(DateTime date)
        {
            List<Sale> output = new List<Sale>();

            foreach (Sale s in allSales)
                if (s.timeCompleted.Ticks >= date.Ticks)
                    output.Add(s);
            return output.ToArray();
        }
        public Sale[] salesBetween(DateTime start, DateTime end)
        {
            List<Sale> output = new List<Sale>();

            foreach (Sale s in allSales)
                if (s.timeCompleted.Ticks >= start.Ticks && s.timeCompleted.Ticks < end.Ticks)
                    output.Add(s);
            return output.ToArray();
        }
        public string salesLockCode = "";
        public string adminLockCode = "";
        public string giftLockCode = "";
        public bool uiSounds = true;

        public string advertising = "";

        public int controllerScreenNum;
        public int customerScreenNum;

        public string salt = "123456789321654987";

        public Product[] allProducts = new Product[0];
        [Newtonsoft.Json.JsonIgnore]
        Sale[] allSales = new Sale[0];
        public Sale currentSale = new Sale();

        public bool alteredSinceLastSave = true;

        public void addSale(Sale s)
        {
            List<Sale> z = new List<Sale>(allSales);
            z.Add(s);
            allSales = z.ToArray();
            
        }

        public Product getProduct(Guid id)
        {
            foreach (Product p in allProducts)
                if (p.ID == id)
                    return p;
            return null;

        }

        public void saveToDisk()
        {

            alteredSinceLastSave = false;

            string s = Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);

            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CirclePOS");
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            string dataTempPath = System.IO.Path.Combine(path, "Database.Temp");
            System.IO.File.WriteAllText(dataTempPath, s);



            string salesTempPath = System.IO.Path.Combine(path, "Sales.Temp");
            System.IO.File.WriteAllText(salesTempPath, Newtonsoft.Json.JsonConvert.SerializeObject(allSales, Newtonsoft.Json.Formatting.Indented));

            string salesPath = System.IO.Path.Combine(path, "Sales.json");
            if (System.IO.File.Exists(salesPath))
                System.IO.File.Delete(salesPath);
            string dataPath = System.IO.Path.Combine(path, "Database.json");
            if (System.IO.File.Exists(dataPath))
                System.IO.File.Delete(dataPath);

            System.IO.File.Move(salesTempPath, salesPath);
            System.IO.File.Move(dataTempPath, dataPath);
            
        }
        public static Database loadFromDisk()
        {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CirclePOS");
            string dataPath = System.IO.Path.Combine(path, "Database.json");
            string salesPath = System.IO.Path.Combine(path, "Sales.json");
            string salesTempPath = System.IO.Path.Combine(path, "Sales.Temp");
            string dataTempPath = System.IO.Path.Combine(path, "Database.Temp");

            Database output = null;
            if (System.IO.File.Exists(dataPath))
                output = Newtonsoft.Json.JsonConvert.DeserializeObject<Database>(System.IO.File.ReadAllText(dataPath));
            else if (System.IO.File.Exists(dataTempPath))
                output = Newtonsoft.Json.JsonConvert.DeserializeObject<Database>(System.IO.File.ReadAllText(dataTempPath));

            if (output == null)
                output = new Database();
            if(System.IO.File.Exists(salesPath))
                output.allSales = Newtonsoft.Json.JsonConvert.DeserializeObject<Sale[]>(System.IO.File.ReadAllText(salesPath));
            else if (System.IO.File.Exists(salesTempPath))
                output.allSales = Newtonsoft.Json.JsonConvert.DeserializeObject<Sale[]>(System.IO.File.ReadAllText(salesTempPath));

            return output;

        }
    }
}
