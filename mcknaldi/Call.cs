using mcknaldi.Models;
using System;
using System.Linq;
using System.Xml;

namespace mcknaldi.ApiCall
{
    public static class Call
    {
        public static void Init()
        {
            //Database stuff
            ApplicationDbContext db = new ApplicationDbContext();

            //Xml stuff
            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList elemList;

            //check if tables are empty
            using (db)
            {
                if (!db.Categories.Any())
                {
                    // The table is empty
                    xmlDoc.Load("https://supermaco.starwave.nl/api/categories");
                    elemList = xmlDoc.GetElementsByTagName("Categories");

                    foreach (XmlNode Category in elemList[0].ChildNodes)
                    {
                        Category c = new Category();
                        c.Name = Category.ChildNodes[0].InnerXml;
                        c.ParentId = null;
                        c.Type = "Category";
                        db.Categories.Add(c);
                        foreach (XmlNode SubCategory in Category.SelectNodes("Subcategory"))
                        {
                            Category sc = new Category();
                            sc.Name = SubCategory.ChildNodes[0].InnerXml;
                            sc.Parent = c;
                            sc.Type = "SubCategory";
                            db.Categories.Add(sc);
                            foreach (XmlNode SubSubCategory in SubCategory.SelectNodes("Subsubcategory"))
                            {
                                Category ssc = new Category();
                                ssc.Name = SubSubCategory.ChildNodes[0].InnerXml;
                                ssc.Parent = sc;
                                ssc.Type = "SubSubCategory";
                                db.Categories.Add(ssc);
                            }
                        }
                    }
                    db.SaveChanges();
                }
                if (!db.Deliveryslots.Any())
                {
                    // THe table is empty
                    xmlDoc.Load("https://supermaco.starwave.nl/api/deliveryslots");
                    elemList = xmlDoc.GetElementsByTagName("Deliveryslots");

                    foreach (XmlNode DeliverySlot in elemList[0].ChildNodes)
                    {
                        Deliveryslots Deliveryslot = new Deliveryslots();
                        Deliveryslot.DateSlot = DateTime.ParseExact(DeliverySlot.ChildNodes[0].InnerXml, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                        foreach (XmlNode Timestamp in DeliverySlot.SelectNodes("Timeslots/Timeslot"))
                        {
                            Deliveryslots Slot2 = new Deliveryslots();
                            Slot2.DateSlot = Deliveryslot.DateSlot;
                            Slot2.StartTime = Timestamp.SelectSingleNode("StartTime").InnerXml;
                            Slot2.EndTime = Timestamp.SelectSingleNode("EndTime").InnerXml;
                            Slot2.Price = decimal.Parse(Timestamp.SelectSingleNode("Price").InnerXml) / 100;
                            db.Deliveryslots.Add(Slot2);
                        }
                    }
                    db.SaveChanges();
                }
                if (!db.Products.Any())
                {
                    // The table is empty
                    xmlDoc.Load("https://supermaco.starwave.nl/api/products");
                    elemList = xmlDoc.GetElementsByTagName("Products");

                    foreach (XmlNode CurrProduct in elemList[0].ChildNodes)
                    {
                        Product product = new Product();
                        product.ApiId = Int32.Parse(CurrProduct.Attributes["Id"].InnerXml);
                        product.EAN = long.Parse(CurrProduct.SelectSingleNode("EAN").InnerXml);
                        product.Title = CurrProduct.SelectSingleNode("Title").InnerXml.Trim();
                        product.Brand = CurrProduct.SelectSingleNode("Brand").InnerXml;
                        product.ShortDescription = CurrProduct.SelectSingleNode("Shortdescription").InnerXml;
                        product.FullDescription = CurrProduct.SelectSingleNode("Fulldescription").InnerXml;
                        product.Image = CurrProduct.SelectSingleNode("Image").InnerXml;
                        product.Weight = CurrProduct.SelectSingleNode("Weight").InnerXml;
                        product.Price = Decimal.Parse(CurrProduct.SelectSingleNode("Price").InnerXml) / 100;
                        var SSC = CurrProduct.SelectSingleNode("Subsubcategory").InnerXml;
                        var query =
                                 (from c in db.Categories
                                  where c.Name == SSC
                                  select new { c.Id }).FirstOrDefault();
                        product.CategoryId = query.Id;
                        db.Products.Add(product);
                    }
                    db.SaveChanges();
                }
                if (!db.Promotions.Any())
                {
                    // The table is empty
                    xmlDoc.Load("https://supermaco.starwave.nl/api/promotions");
                    elemList = xmlDoc.GetElementsByTagName("Promotion");
                    var Title = elemList[0].SelectSingleNode("Title").InnerXml;

                    foreach (XmlNode CurrDisc in xmlDoc.GetElementsByTagName("Discount"))
                    {
                        Promotion promo = new Promotion();
                        promo.Title = Title;
                        promo.ProductEAN = long.Parse(CurrDisc.SelectSingleNode("EAN").InnerXml);
                        promo.DiscountPrice = decimal.Parse(CurrDisc.SelectSingleNode("DiscountPrice").InnerXml) / 100;
                        var cunt = CurrDisc.SelectSingleNode("ValidUntil").InnerXml;
                        promo.ValidUntil = DateTime.ParseExact(CurrDisc.SelectSingleNode("ValidUntil").InnerXml, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        db.Promotions.Add(promo);
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}