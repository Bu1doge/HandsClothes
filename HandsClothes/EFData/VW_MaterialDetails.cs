//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HandsClothes.EFData
{
    using System;
    using System.Collections.Generic;
    
    public partial class VW_MaterialDetails
    {
        public string Тип_материала { get; set; }
        public string Наименование_материала { get; set; }
        public int Количество_на_складе { get; set; }
        public Nullable<int> Количество_возможных_поставщиков { get; set; }
        public string Текущая_стоимость { get; set; }
        public Nullable<int> Кол_во_на_начало_месаца { get; set; }
        public string Описание { get; set; }
    }
}
