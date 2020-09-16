using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JMHDESIGN.Models
{
    public class Formularios {

    /// <summary>
    /// ID do formulário
    /// </summary>
    [Key]
    public int IDform { get; set; }


    /// <summary>
    /// Assunto do formulário
    /// </summary>
    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [StringLength(70, ErrorMessage = "Não pode ter mais do que {1} caráteres.")]
    [Display(Name = "Assunto")]
    public string Assunto { get; set; }

    /// <summary>
    /// Data do formulário
    /// </summary>
    public DateTime Data { get; set; }

    /// <summary>
    /// Descrição do formulário
    /// </summary>
    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    /// <summary>
    /// Chave estrangeira
    /// </summary>
    [ForeignKey("Cliente")] 
    public int ClienteFK { get; set; } 
    public Clientes Cliente { get; set; } 

    

    }
}
