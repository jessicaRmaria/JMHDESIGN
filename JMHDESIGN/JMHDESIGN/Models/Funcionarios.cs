using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JMHDESIGN.Models
{
    public class Funcionarios {
        public Funcionarios() {

            
            ListaRelacionamento = new HashSet<ProjetosFuncionarios>();
        }
    
    [Key]  
    public int IDfunc { get; set; }

    [Required]
    public string Nome { get; set; }

    [Required]
    public string Cargo { get; set; }

    [Required]
    public int Contacto { get; set; }

    [Required]
    public string Morada { get; set; }

    [Required]
    public string CodPostal { get; set; }

        // ***********************************************************************************
        // relacionamento com os dados da autenticação
        // ***********************************************************************************
        /// <summary>
        /// Atributo utilizado para quando um Cliente se autentica, 
        /// relacionar esse cliente com os seus projetos
        /// </summary>
        public string UserNameId { get; set; }

        public ICollection<ProjetosFuncionarios> ListaRelacionamento { get; set; }

    }

}
