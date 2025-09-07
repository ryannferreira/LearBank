using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearBank.Model
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("EMAIL", TypeName = "varchar2")]
        [StringLength(255)]
        public string Email { get; set; }

        [Column("SENHA", TypeName = "varchar2")]
        [StringLength(255)]
        public string Senha { get; set; }
    }
}
