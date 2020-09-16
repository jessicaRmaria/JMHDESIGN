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
            // Estou a colocar dados na Lista de relacionamento de ProjetosFuncionarios
            ListaRelacionamento = new HashSet<ProjetosFuncionarios>();
          
        }

    /// <summary>
    /// ID do Projeto - Chave primária
    /// </summary>
        [Key]
    public int IDproj { get; set; }

    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [StringLength(70, ErrorMessage = "Não pode ter mais do que {1} caráteres.")]
    [RegularExpression("[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+(( | d[ao](s)? | e |-|'| d')[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+){1,5}",
                            ErrorMessage = "Deve escrever 2 a 6 nomes, começando por Maiúsculas, seguido de  minúsculas.")]
    [Display(Name = "Nome")]

    /// <summary>
    /// Nome do projeto
    /// </summary>
    public string Nome { get; set; }

    /// <summary>
    /// Descrição do projeto
    /// </summary>
    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    /// <summary>
    /// Categoria do projeto
    /// </summary>
    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
    [Display(Name = "Categoria")]
    public string Categoria { get; set; }

    /// <summary>
    /// Data de entrega do projeto
    /// </summary>
    public DateTime Data { get; set; }

    /// <summary>
    /// Fotografia do projeto
    /// </summary>
    public string Fotografia { get; set; }

    /// <summary>
    /// Ficheiro do projeto
    /// </summary>
    public string Ficheiro { get; set; }

    /// <summary>
    /// Chave estrangeira
    /// </summary>
    [ForeignKey("Cliente")]
    [Display(Name = "Cliente")]
    public int ClienteFK { get; set; }
    public Clientes Cliente { get; set; }

    /// <summary>
    /// Lista de funcionários associados a um projeto
    /// </summary>
        public ICollection<ProjetosFuncionarios> ListaRelacionamento { get; set; }
    

    }
}


