using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOOPlayerok
{
    public class GenreOptions
    {
        public int? GenreId { get; set; } // Nullable int, чтобы представлять "Все жанры"
        public string GenreName { get; set; }

        public override string ToString()
        {
            return GenreName ?? "Все жанры"; // Если GenreName null, возвращаем "Все жанры"
        }
    }
}
