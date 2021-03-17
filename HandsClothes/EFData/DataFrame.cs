using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsClothes.EFData
{
    public class DataFrame
    {
        public static HandsClothesEntities Context { get; } = new HandsClothesEntities();
    }
}
