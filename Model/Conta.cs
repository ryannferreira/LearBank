using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearBank.Model
{
    [Table("CONTAS")]
    public class Conta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public long Id { get; set; }

        [Required]
        [StringLength(10)]
        [Column("AGENCIA")]
        public string Agencia { get; set; }

        [Required]
        [StringLength(20)]
        [Column("NUMERO_CONTA")]
        public string NumeroConta { get; set; }

        [Required]
        [Column("TIPO_CONTA")]
        public TipoDeConta TipoConta { get; set; }

        [Required]
        [Column("SALDO")]
        public decimal Saldo { get; set; }

        [Required]
        [Column("DATA_ABERTURA")]
        public DateTime DataAbertura { get; set; }

        [Required]
        [Column("ATIVA")]
        public bool Ativa { get; set; }

        [Column("ID_USUARIO")]
        public long UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }
    }

    public enum TipoDeConta
    {
        Corrente = 1,
        Poupanca = 2
    }
}
