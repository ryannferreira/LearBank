using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearBank.Model
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public long Id { get; set; }

        [Required] 
        [StringLength(150)]
        [Column("NOME_COMPLETO", TypeName = "varchar2")]
        public string NomeCompleto { get; set; }

        [Required]
        [StringLength(11)]
        [Column("CPF")]
        public string Cpf { get; set; }

        [Column("EMAIL", TypeName = "varchar2")]
        [StringLength(255)]
        public string Email { get; set; }

        [Column("SENHA_HASH", TypeName = "varchar2")]
        [StringLength(255)]
        public string SenhaHash { get; set; }

        [Column("DATA_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [Column("DATA_CADASTRO")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [Column("ATIVO")]
        public bool Ativo { get; set; }

        public virtual ICollection<Conta> Contas { get; set; }
    }
}
