using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JMHDESIGN.Models
{
    public class Formularios {
      

    [Key]
    public int IDform { get; set; }

    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [StringLength(70, ErrorMessage = "Não pode ter mais do que {1} caráteres.")]
    [Display(Name = "Assunto")]
    public string Assunto { get; set; }

    public DateTime Data { get; set; }

     [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
     [Display(Name = "Descrição")]
     public string Descricao { get; set; }


    [ForeignKey("Cliente")] 
    public int ClienteFK { get; set; } 
    public Clientes Cliente { get; set; } 

    

    }
}
