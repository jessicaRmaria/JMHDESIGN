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

    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [StringLength(70, ErrorMessage = "Não pode ter mais do que {1} caráteres.")]
    [RegularExpression("[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+(( | d[ao](s)? | e |-|'| d')[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+){1,5}",
                            ErrorMessage = "Deve escrever 2 a 6 nomes, começando por Maiúsculas, seguido de  minúsculas.")]
    [Display(Name = "Nome")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [Display(Name = "Categoria")]
    public string Categoria { get; set; }

    /// <summary>
    /// Data de entrega do projeto
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


