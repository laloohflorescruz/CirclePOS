using System;
using System.Collections.Generic;
using System.Text;

namespace CirclePOS.Model
{
    class Sale
    {
        public Guid saleID;
        public Guid[] productIDs = new Guid[0];
        public string[] productNames = new string[0];
        public decimal[] productCosts = new decimal[0];
        public DateTime timeCompleted;
        public Decimal totalAmount;
        public bool madeFree = false;

        public void removeAllProducts()
        {
            productCosts = new decimal[] { };
            productIDs = new Guid[] { };
            productNames = new string[] { };

        }
        public bool containsProductID(Guid id)
        {
            foreach (Guid z in productIDs)
                if (z == id)
                    return true;
            return false;
        }
        public void removeProductIndex(int i)
        {
            List<Guid> ids = new List<Guid>(productIDs);
            List<string> names = new List<string>(productNames);
            List<decimal> costs = new List<decimal>(productCosts);
            ids.RemoveAt(i);
            names.RemoveAt(i);
            costs.RemoveAt(i);

            productIDs = ids.ToArray();
            productNames = names.ToArray();
            productCosts = costs.ToArray();


        }

        public void addProduct(Product p)
        {
            if (productNames == null)
                productNames = new string[0];
            if (productIDs == null)
                productIDs = new Guid[0];
            if (productCosts == null)
                productCosts = new decimal[0];
            string[] names = new string[productNames.Length + 1];
            Guid[] ids = new Guid[productIDs.Length + 1];
            decimal[] costs = new decimal[productCosts.Length + 1];
            Array.Copy(productIDs, ids, productIDs.Length);
            Array.Copy(productCosts, costs, productCosts.Length);
            Array.Copy(productNames, names, productNames.Length);
            ids[ids.Length - 1] = p.ID;
            costs[costs.Length - 1] = p.cost;
            names[names.Length - 1] = p.name;
            productIDs = ids;
            productCosts = costs;
            productNames = names;
        }
    }
}
