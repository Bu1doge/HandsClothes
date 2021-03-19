using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsClothes.EFData
{
    public partial class VW_MaterialSuplier
    {
        public string GetImage
        {
            get
            {
                if (string.IsNullOrEmpty(PhotoPath))
                {
                    return $"/Resourses/nullValuePic.png";
                }
                else
                {
                    return $"/Resourses/PhotoMaterials/{PhotoPath}";
                }
            }
        }

        public string GetTypeAndName
        {
            get
            {
                return "Тип материала: " + MaterialType + " | Наиминование материала " + MaterialName;
            }
        }
    }
}
