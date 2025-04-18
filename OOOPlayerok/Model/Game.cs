//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OOOPlayerok.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Windows.Media.Imaging;
    public partial class Game
    {
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public int GenreId { get; set; }
        public int DeveloperId { get; set; }
        public string GameDescription { get; set; }
        public double GamePrice { get; set; }
        public double GameDiscount { get; set; }
    
        public virtual Developer Developer { get; set; }
        public virtual Genre Genre { get; set; }
        [NotMapped] public BitmapImage Image { get; set; }
        public double DiscountPercent { get; set; }
    }
}
