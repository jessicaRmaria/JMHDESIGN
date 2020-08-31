using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JMHDESIGN.Models {
    public class Projetos {
        public Projetos()
        {

            ListaRelacionamento = new HashSet<ProjetosFuncionarios>();
          
        }

    [Key]
    public int IDproj { get; set; }

    [Required]
    public string Nome { get; set; }

    public string Descricao { get; set; }

    [Required]
    public string Categoria { get; set; }

    /// <summary>
    /// Data de criação do projeto
    /// </summary>
    public DateTime Data { get; set; }

    public string Fotografia { get; set; }

    public string Ficheiro { get; set; }


    [ForeignKey("Cliente")]
    public int ClienteFK { get; set; }
    public Clientes Cliente { get; set; }


    public ICollection<ProjetosFuncionarios> ListaRelacionamento { get; set; }
    

    }
}


