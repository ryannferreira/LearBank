using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearBank.Model
{
    [Table("TRANSACOES")]
    public class Transacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public long Id { get; set; }

        [Required]
        [Column("VALOR")]
        public decimal Valor { get; set; }

        [Required]
        [Column("DATA_HORA")]
        public DateTime DataHora { get; set; }

        [Required]
        [Column("TIPO_TRANSACAO")]
        public TipoDeTransacao TipoTransacao { get; set; }

        [StringLength(200)]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [Column("ID_CONTA_ORIGEM")]
        public long? ContaOrigemId { get; set; }

        [Column("ID_CONTA_DESTINO")]
        public long? ContaDestinoId { get; set; }

        [ForeignKey("ContaOrigemId")]
        public virtual Conta ContaOrigem { get; set; }

        [ForeignKey("ContaDestinoId")]
        public virtual Conta ContaDestino { get; set; }
    }

    public enum TipoDeTransacao
    {
        Transferencia = 1,
        Deposito = 2,
        Saque = 3,
        Pagamento = 4
    }
}
