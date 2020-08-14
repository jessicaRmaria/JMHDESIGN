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
    
    [Required]
    public string Assunto { get; set; }

    public DateTime Data { get; set; }

    [Required]
    public string Descricao { get; set; }


    [ForeignKey("Cliente")] 
    public int ClienteFK { get; set; } 
    public Clientes Cliente { get; set; } 

    

    }
}
