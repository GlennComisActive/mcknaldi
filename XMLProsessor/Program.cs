using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLProsessor
{
    class Program
    {
        static void Main()
        {
            Entities db = new Entities();

            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList elemList;


            using (db)
            {
                if (!db.Categories.Any())
                {
                    // The table is empty
                    xmlDoc.Load("https://supermaco.starwave.nl/api/categories");
                    elemList = xmlDoc.GetElementsByTagName("Categories");

                    foreach (XmlNode Category in elemList[0].ChildNodes)
                    {
                        Categories c = new Categories();
                        c.Name = Category.ChildNodes[0].InnerXml;
                        c.ParentId = null;
                        c.Type = "Category";
                        db.Categories.Add(c);
                        foreach (XmlNode SubCategory in Category.SelectNodes("Subcategory"))
                        {
                            Categories sc = new Categories();
                            sc.Name = SubCategory.ChildNodes[0].InnerXml;
                            sc.ParentId = c.Id;
                            sc.Type = "SubCategory";
                            db.Categories.Add(sc);
                            foreach (XmlNode SubSubCategory in SubCategory.SelectNodes("Subsubcategory"))
                            {
                                Categories ssc = new Categories();
                                ssc.Name = SubSubCategory.ChildNodes[0].InnerXml;
                                ssc.ParentId = sc.Id;
                                ssc.Type = "SubSubCategory";
                                db.Categories.Add(ssc);
                            }
                        }
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}
