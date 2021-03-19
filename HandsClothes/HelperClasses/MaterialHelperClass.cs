using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsClothes.EFData;

namespace HandsClothes.HelperClasses
{
    class MaterialHelperClass
    {
        public static List<Material> GetAllMaterials()
        {
            var query = (from item in DataFrame.Context.Material 
                         select item);

            return query.ToList();
        }

        public static Material GetMaterial(int materialId)
        {
            var query = (from item in DataFrame.Context.Material
                         where item.Id == materialId
                         select item).SingleOrDefault();

            return query;
        }

        public static List<Suplier> GetMeterialSupliers(int materialId)
        {
            var query = (from item 
                         in DataFrame.Context.Suplier 
                         where item.Material.Contains(DataFrame.Context.Material.Where(i => i.Id == materialId).FirstOrDefault()) 
                         select item);

            return query.ToList();
        }

        public static string StringOfMeterialSupliers(int materialId)
        {
            string result = " ";

            var list = GetMeterialSupliers(materialId);

            foreach (Suplier element in list)
            {
                result += result == " " ? element.SuplierName : ", " + element.SuplierName;
            }

            return result;
        }
    }
}
