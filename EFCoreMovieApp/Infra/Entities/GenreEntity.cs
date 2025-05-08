using EFCoreMovieApp.Infra.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMovieApp.Infra.Entities
{
    public class GenreEntity : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<MovieEntity> Movies { get; set; }
    }
}
